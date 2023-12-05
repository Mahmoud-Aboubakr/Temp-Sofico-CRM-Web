
using SofiForce.Integration.Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class PurchaseMigrator
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
VJ.PURCHID,
(select DELIVERYDATE from [SOF-SRV-DB12].[SofDynAXLive].dbo.PURCHTABLE where PURCHID=VJ.PURCHID AND DATAAREAID='SFC')AS DELIVERYDATE,
(select INVENTSITEID from [SOF-SRV-DB12].[SofDynAXLive].dbo.PURCHTABLE where PURCHID=VJ.PURCHID AND DATAAREAID='SFC')AS INVENTSITEID,
(select INVENTLOCATIONID from [SOF-SRV-DB12].[SofDynAXLive].dbo.PURCHTABLE where PURCHID=VJ.PURCHID AND DATAAREAID='SFC')AS INVENTLOCATIONID,
 VJ.ORDERACCOUNT,
 VJ.INVOICEID,
 VJ.INVOICEDATE,
 VJ.INVOICEAMOUNT,
 VJ.CURRENCYCODE,
 VJ.INVOICEAMOUNTMST,
 VJ.EXCHRATE,
 VJ.SUMTAX,
 VJ.RecId

 FROM [SOF-SRV-DB12].[SofDynAXLive].dbo.VENDINVOICEJOUR    AS VJ 
 WHERE VJ.DATAAREAID='SFC'
  AND YEAR(VJ.INVOICEDATE) = YEAR(GETDATE())
 AND VJ.PURCHID <> ' '
ORDER BY VJ.PURCHID
";
        public static string SP_InvoiceDetail = @"

select 
       IT.ITEMID,
       IT.INVOICEID , 
       IT.QTY ,
       Origin.REFERENCEID AS PURCHID , 
       IB.INVENTBATCHID ,
       IB.EXPDATE ,

       IT.DATEPHYSICAL ,
       PU.LINEAMOUNT ,
       ( SELECT LINEAMOUNTMST FROM  [SOF-SRV-DB12].[SofDynAXLive].dbo.VENDINVOICETRANS WHERE PURCHID=PU.PURCHID AND ITEMID=PU.ITEMID AND PU.INVENTTRANSID=INVENTTRANSID AND DATAAREAID='SFC')AS AMOUNTMST,
	   PU.PURCHUNIT,
	   PU.CURRENCYCODE,
PU.TAXAMOUNT,
	   PU.RecId,
IT.STATUSRECEIPT,
0 as DiscountValue
    FROM
        [SOF-SRV-DB12].[SofDynAXLive].dbo.VENDINVOICETRANS   AS PU INNER  JOIN
		[SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTTRANSORIGIN  AS Origin ON  Pu.INVENTTRANSID     = Origin.INVENTTRANSID AND PU.PURCHID        = Origin.REFERENCEID inner join 
        [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTTRANS        AS IT     ON  IT.INVENTTRANSORIGIN = Origin.RECID         AND Origin.DATAAREAID = IT.DATAAREAID INNER JOIN
        [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTDIM          AS ID     ON  ID.INVENTDIMID       = IT.INVENTDIMID       AND IT.DATAAREAID     = ID.DATAAREAID LEFT OUTER JOIN
        [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTBATCH        AS IB     ON  IB.INVENTBATCHID     = ID.INVENTBATCHID     AND IB.ITEMID         = IT.ITEMID     AND IB.DATAAREAID = ID.DATAAREAID  INNER JOIN
        [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTTABLE        AS IV     ON  IV.ITEMID            = PU.ITEMID            AND IV.ITEMID         = IT.ITEMID     AND IV.DATAAREAID = PU.DATAAREAID
       
    WHERE 
        IT.DATAAREAID='SFC'
        AND  Origin.ReferenceCategory='3'
        AND  IT.DATAAREAID='SFC'


";
        public PurchaseMigrator(IConfiguration configuration)
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

                _RemoteCommand.CommandType = CommandType.Text;
                _RemoteCommand.CommandText = "select max(RecId) from SalesOrder";
                double recId_Header = 0;
                double.TryParse(_RemoteCommand.ExecuteScalar().ToString(), out recId_Header);
                if (recId_Header==0)
                    recId_Header = 0;
                

                _RemoteCommand.CommandType = CommandType.Text;
                _RemoteCommand.CommandText = "select max(RecId) from SalesOrder_Detail";
                double recId_Detail = 0;
                double.TryParse(_RemoteCommand.ExecuteScalar().ToString(), out recId_Detail);
                if (recId_Detail==0)
                    recId_Detail = 0;


                //_TempCommand.CommandType = CommandType.Text;
                //_TempCommand.CommandText = "truncate table Invoice_Header";
                //_TempCommand.ExecuteNonQuery();

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table Invoice_Detail";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_InvoiceHeader;
                _AXCommand.Parameters.Add(new SqlParameter("RECID", recId_Header));
                DataTable dtHeader = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                //_AXAdapter.Fill(dtHeader);

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

                _SqlBulkCopy.BatchSize = 5000;
                //_SqlBulkCopy.WriteToServer(dtHeader);
                _AXCommand.CommandText = SP_InvoiceDetail;
                _AXCommand.Parameters.Clear();
                _AXCommand.Parameters.Add(new SqlParameter("RECID", recId_Detail));
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
                _SqlBulkCopy.WriteToServer(dtDetail);

                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_Invoice";
                _TempCommand.ExecuteNonQuery();

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
