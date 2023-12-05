
using SofiForce.Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class InvoiceMigrator
    {
        private readonly IConfiguration _configuration;

        private SqlConnection _AXConnection;
        private SqlConnection _RemoteConnection;
        private SqlConnection _TempConnection;

        private SqlCommand _AXCommand;
        private SqlCommand _RemoteCommand;
        private SqlCommand _TempCommand;

        private SqlDataAdapter _RemoteAdapter;
        private SqlDataAdapter _AXAdapter;
        private SqlDataAdapter _TempAdapter;

        private SqlBulkCopy _SqlBulkCopy;



        public static string SP_InvoiceHeader = @"
SELECT 
   ST.SHIPCARRIERACCOUNT AS ShippmentNo ,
   ST.INVENTSITEID       AS BranchId,
   ST.SALESPOOLID as SalesPoolCode,
   CJ.INVOICEACCOUNT as CustomerAccountCode,
   CJ.INVENTLOCATIONID   AS WarehouseId,
   (select PersonnelNumber from  [SOF-SRV-DB12].[SofDynAXLive].dbo.HcmWorker where HcmWorker.recid = st.workerSALESTAKER  )        AS DistributerId,
   (select PersonnelNumber from  [SOF-SRV-DB12].[SofDynAXLive].dbo.HcmWorker where HcmWorker.recid = st.workerSalesResponsible )  AS SalesManId,	
   CJ.ORDERACCOUNT       AS CustomerCode,
   CJ.RECID             AS RecId,	
   CJ.INVOICEID         AS InvoiceCode,	
   CJ.INVOICEDATE       AS orderDate,
   CJ.INVOICEAMOUNT     AS InvoiceAmount,	
   ST.PurchOrderFormNum           AS SaleOrderId,
   CJ.INVOICEDATE   as INVOICEDATE,

  (SELECT PaymTermId FROM [SOF-SRV-DB12].[SofDynAXLive].dbo.CUSTTABLE WHERE DATAAREAID='SFC' AND ST.CUSTACCOUNT= ACCOUNTNUM) AS PaymentTermId,
   null as Longitude ,
   null as Latitude ,
  dateadd(hour,2,CJ.CREATEDDATETIME) as   SBDATE,
  CJ.SumLineDisc, ---
  CJ.SalesBalance,---
  CJ.SumTax,---
  CJ.CashDisc,----
  dateadd(hour,2,CJ.CREATEDDATETIME)   as CreateDate
 FROM 
 [SOF-SRV-DB12].SofDynAXLive.dbo.CUSTINVOICEJOUR AS CJ  left join 
 [SOF-SRV-DB12].SofDynAXLive.dbo.SALESTABLE ST  ON CJ.SALESID=ST.SALESID  

 WHERE (
    CJ.DATAAREAID='SFC'
and CJ.InvoiceId in (@InvoiceId)
)
";
        public static string SP_InvoiceDetail = @"
SELECT 
CJ.INVOICEID         AS InvoiceCode,	
ct.ItemId as ItemId,
ct.Qty as Qty,
ct.SalesPrice as SalesPrice,


   isnull((
	 SELECT     top 1 amount 
                           FROM         [SOF-SRV-DB12].[SofDynAXLive].dbo.PriceDiscTable AS p
                           WHERE     (dataareaid = 'sfc') 
						   AND (accountrelation = 'PUB') 
						   --AND (ItemCode = 0) 
						   --AND (AccountCode = 1)  
						   --AND (Module = 0) 
						   --AND (Relation = 4) 
						   AND (FromDate <= GETDATE())
						   and P.ItemRelation =ct.ItemId

							order by FromDate desc
	 ),0) AS PublicPrice,

   null as Batch,
   null as ExpDate,
   CT.TAXAMOUNT as TAXAMOUNT,
   CT.LINEDISC as LINEDISC,
   CT.SALESUNIT as SALESUNIT,
   CT.RecId as RecId,
   Cj.RecId as RecIdParent
   
 FROM 
 [SOF-SRV-DB12].[SofDynAXLive].dbo.CUSTINVOICEJOUR  CJ INNER JOIN
 [SOF-SRV-DB12].[SofDynAXLive].dbo.CustInvoiceTrans AS CT  ON  Cj.invoiceid   = Ct.invoiceid   AND CT.DATAAREAID=CJ.DATAAREAID  left join 
 [SOF-SRV-DB12].SofDynAXLive.dbo.SALESTABLE ST  ON CJ.SALESID=ST.SALESID

WHERE (CJ.DATAAREAID='SFC'
and CJ.InvoiceId in (@InvoiceId)
)
";

        public string SP_InvoiceBatch = @"SELECT                
                      j.INVOICEID, 
					  j.INVOICEDATE, 
					  i.ITEMID,  
					  d.INVENTBATCHID as BatchNO,
					  IB.EXPDATE as EXPDATE,
					  cast(t.QTY as int) as QTY,
					  j.RecId as RecIdParent
FROM                  
                      
                       [SOF-SRV-DB12].[SofDynAXLive].dbo.CUSTINVOICEJOUR      AS j  INNER JOIN
                       [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTTRANS          AS t  ON j.INVOICEID = t.INVOICEID AND t.DATAAREAID='sfc' INNER JOIN
                       [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTDIM            AS d  ON t.INVENTDIMID = d.INVENTDIMID  AND d.DATAAREAID='sfc' INNER JOIN
                       [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTTABLE          AS i  ON t.ITEMID = i.ITEMID AND i.DATAAREAID='sfc' INNER JOIN
                       [SOF-SRV-DB12].[SofDynAXLive].dbo.SALESTABLE           AS st ON j.SALESID = st.SALESID AND st.DATAAREAID='sfc' inner join
                       [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTBATCH          AS IB ON IB.INVENTBATCHID=d.INVENTBATCHID and IB.DATAAREAID='sfc'and IB.ITEMID=i.ITEMID
 WHERE (

j.DATAAREAID='SFC' 
and j.CREATEDDATETIME >=dateadd(day,-1,getdate())
)
GROUP BY    j.INVOICEID, 
					  j.INVOICEDATE, 
					  i.ITEMID,  
					  d.INVENTBATCHID ,
					  IB.EXPDATE ,
					  t.QTY,
					  j.RecId ";
        public InvoiceMigrator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MigrationDTO Migrate()
        {
            MigrationDTO Res = new MigrationDTO();

            try
            {
                _AXConnection = new SqlConnection(_configuration["AxConnection"]);
                _RemoteConnection = new SqlConnection(_configuration["RemoteConnection"]);
                _TempConnection = new SqlConnection(_configuration["TempConnection"]);
                _SqlBulkCopy = new SqlBulkCopy(_configuration["TempConnection"]);

                _RemoteConnection.Open();
                _AXConnection.Open();
                _TempConnection.Open();

                _AXCommand = new SqlCommand();
                _RemoteCommand = new SqlCommand();
                _TempCommand = new SqlCommand();


                _AXCommand.Connection = _AXConnection;
                _RemoteCommand.Connection = _RemoteConnection;
                _TempCommand.Connection = _TempConnection;

                _AXCommand.CommandTimeout = 5000;
                _RemoteCommand.CommandTimeout = 5000;
                _TempCommand.CommandTimeout = 5000;
                _SqlBulkCopy.BulkCopyTimeout = 5000;

                _AXAdapter = new SqlDataAdapter();
                _RemoteAdapter = new SqlDataAdapter();
                _TempAdapter = new SqlDataAdapter();


                // execute AX
                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table Invoice_Header";
                _TempCommand.ExecuteNonQuery();

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table Invoice_Detail";
                _TempCommand.ExecuteNonQuery();

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table Invoice_Batch";
                _TempCommand.ExecuteNonQuery();

                // get param


                _RemoteCommand.CommandType = CommandType.Text;
                _RemoteCommand.CommandText = @"select top 10 DetailId, Payload1 as InvoiceId  from SyncSetup_Detail where SetupId=6";
                var reader = _RemoteCommand.ExecuteReader();
                List<string> InvoiceList = new List<string>();
                List<int> DetailIdList = new List<int>();

                while (reader.Read())
                {
                    if (reader["InvoiceId"] != null && !string.IsNullOrEmpty(reader["InvoiceId"].ToString()))
                    {
                        var existItemCode = InvoiceList.Where(a => a.Equals(reader["InvoiceId"].ToString())).FirstOrDefault();
                        if (existItemCode == null)
                        {
                            InvoiceList.Add("'" + reader["InvoiceId"].ToString() + "'");
                        }
                    }

                    if (reader["DetailId"] != null && !string.IsNullOrEmpty(reader["DetailId"].ToString()))
                    {
                        DetailIdList.Add(int.Parse(reader["DetailId"].ToString()));
                    }

                }


                if (InvoiceList.Count > 0)
                {
                    var Invoices = string.Join(',', InvoiceList);

                    _AXCommand.CommandType = CommandType.Text;
                    _AXCommand.CommandText = SP_InvoiceHeader.Replace("@InvoiceId", Invoices);
                    DataTable dtHeader = new DataTable();
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dtHeader);


                    // Migrrate Data
                    _SqlBulkCopy.DestinationTableName = "Invoice_Header";
                    _SqlBulkCopy.ColumnMappings.Add("ShippmentNo", "ShippmentNo");
                    _SqlBulkCopy.ColumnMappings.Add("BranchId", "BranchId");
                    _SqlBulkCopy.ColumnMappings.Add("CustomerAccountCode", "CustomerAccountCode");
                    _SqlBulkCopy.ColumnMappings.Add("SalesPoolCode", "SalesPoolCode");
                    _SqlBulkCopy.ColumnMappings.Add("WarehouseId", "WarehouseId");
                    _SqlBulkCopy.ColumnMappings.Add("DistributerId", "DistributerId");
                    _SqlBulkCopy.ColumnMappings.Add("SalesManId", "SalesManId");
                    _SqlBulkCopy.ColumnMappings.Add("CustomerCode", "CustomerCode");
                    _SqlBulkCopy.ColumnMappings.Add("RecId", "RecId");
                    _SqlBulkCopy.ColumnMappings.Add("InvoiceCode", "InvoiceCode");
                    _SqlBulkCopy.ColumnMappings.Add("orderDate", "orderDate");
                    _SqlBulkCopy.ColumnMappings.Add("InvoiceAmount", "InvoiceAmount");
                    _SqlBulkCopy.ColumnMappings.Add("SaleOrderId", "SaleOrderId");
                    _SqlBulkCopy.ColumnMappings.Add("invoicedate", "invoicedate");
                    _SqlBulkCopy.ColumnMappings.Add("PaymentTermId", "PaymentTermId");
                    _SqlBulkCopy.ColumnMappings.Add("Longitude", "Longitude");
                    _SqlBulkCopy.ColumnMappings.Add("Latitude", "Latitude");
                    _SqlBulkCopy.ColumnMappings.Add("SBDATE", "SBDATE");
                    _SqlBulkCopy.ColumnMappings.Add("SumLineDisc", "SumLineDisc");
                    _SqlBulkCopy.ColumnMappings.Add("SalesBalance", "SalesBalance");
                    _SqlBulkCopy.ColumnMappings.Add("SumTax", "SumTax");
                    _SqlBulkCopy.ColumnMappings.Add("CashDisc", "CashDisc");
                    _SqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dtHeader);


                    _AXCommand.CommandText = SP_InvoiceDetail.Replace("@InvoiceId", Invoices);
                    _AXCommand.Parameters.Clear();
                    DataTable dtDetail = new DataTable();
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dtDetail);


                    _SqlBulkCopy.DestinationTableName = "Invoice_Detail";
                    _SqlBulkCopy.ColumnMappings.Clear();
                    _SqlBulkCopy.ColumnMappings.Add("InvoiceCode", "InvoiceCode");
                    _SqlBulkCopy.ColumnMappings.Add("ItemId", "ItemId");
                    _SqlBulkCopy.ColumnMappings.Add("Qty", "Qty");
                    _SqlBulkCopy.ColumnMappings.Add("SalesPrice", "SalesPrice");
                    _SqlBulkCopy.ColumnMappings.Add("PublicPrice", "PublicPrice");
                    _SqlBulkCopy.ColumnMappings.Add("Batch", "Batch");
                    _SqlBulkCopy.ColumnMappings.Add("ExpDate", "ExpDate");

                    _SqlBulkCopy.ColumnMappings.Add("TAXAMOUNT", "TAXAMOUNT");
                    _SqlBulkCopy.ColumnMappings.Add("LINEDISC", "LINEDISC");
                    _SqlBulkCopy.ColumnMappings.Add("SALESUNIT", "SALESUNIT");

                    _SqlBulkCopy.ColumnMappings.Add("RecId", "RecId");
                    _SqlBulkCopy.ColumnMappings.Add("RecIdParent", "RecIdParent");
                    _SqlBulkCopy.WriteToServer(dtDetail);

                    _AXCommand.CommandText = SP_InvoiceBatch.Replace("@InvoiceId", Invoices);
                    _AXCommand.Parameters.Clear();
                    DataTable dtBatch = new DataTable();
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dtBatch);


                    _SqlBulkCopy.DestinationTableName = "Invoice_Batch";
                    _SqlBulkCopy.ColumnMappings.Clear();
                    _SqlBulkCopy.ColumnMappings.Add("INVOICEID", "INVOICEID");
                    _SqlBulkCopy.ColumnMappings.Add("INVOICEDATE", "INVOICEDATE");
                    _SqlBulkCopy.ColumnMappings.Add("ITEMID", "ITEMID");
                    _SqlBulkCopy.ColumnMappings.Add("BatchNO", "BatchNO");
                    _SqlBulkCopy.ColumnMappings.Add("EXPDATE", "EXPDATE");
                    _SqlBulkCopy.ColumnMappings.Add("QTY", "QTY");
                    _SqlBulkCopy.ColumnMappings.Add("RecIdParent", "RecIdParent");


                    _SqlBulkCopy.WriteToServer(dtBatch);


                    var DetailId = string.Join(',', DetailIdList);
                    _TempCommand.CommandType = CommandType.StoredProcedure;
                    _TempCommand.CommandText = "Migrate_Invoice";
                    _TempCommand.Parameters.Add(new SqlParameter("DetailId", DetailId));
                    _TempCommand.ExecuteNonQuery();
                }

                

                

            }
            catch (Exception ex)
            {
                Res.Message = ex.Message;
                Res.IsCompleted = false;
            }
            finally
            {
                _RemoteConnection.Close();
                _AXConnection.Close();
                _TempConnection.Close();

                _AXCommand.Dispose();
                _RemoteCommand.Dispose();
                _TempCommand.Dispose();

                _AXAdapter.Dispose();
                _RemoteAdapter.Dispose();
                _TempAdapter.Dispose();

                _SqlBulkCopy.Close();
            }





            return Res;




        }
    }
}
