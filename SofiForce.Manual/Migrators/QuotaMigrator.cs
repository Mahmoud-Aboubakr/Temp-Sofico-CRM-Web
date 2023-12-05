

using SofiForce.Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class QuotaMigrator
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

        public static string SP_ItemQuota =
@"
select 
	   ss.ITEMID,
	   ss.FROMDATE,
	   ss.TODATE,
	   ss.QTY       as CeillingQty	   
from 
      [SOF-SRV-DB12].[SofDynAXLive].dbo.Sofico_SalesItemLimit         as SS join
	  [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTTABLE                   as Inv on ss.ITEMID  = Inv.ITEMID join
	  [SOF-SRV-DB12].[SofDynAXLive].dbo.VENDTABLE                     as Vend on Vend.ACCOUNTNUM = ss.PRIMARYVENDORID
where ss.FROMDATE<=cast(GETDATE() as date) and ss.TODATE>=cast(GETDATE() as date)
And ss.ITEMID in (@ItemCode)
 group by ss.ITEMID,
	  -- Inv.ITEMNAME,
	   ss.FROMDATE,
	   ss.TODATE,
	   ss.PRIMARYVENDORID,
	   ss.QTY       ,
	   ss.SALESPRICE,
	   ss.VALUE
                  
";

public static string SP_ClientExceptionQuota =
@"
            select CustomerAccountNum as ClientCode
               ,ItemConditions as ItemCode
	           ,FromDate  as FromDate
	           ,Todate as ToDate
	           ,QtyConditions as QTY
                from [SOF-SRV-DB12].[SofDynAXLive].dbo.OverCeilingConditions
				where  Falg = 0 
                and FROMDATE<=cast(GETDATE() as date) and TODATE>=cast(GETDATE() as date) 
And CustomerAccountNum in (@ClientCode)
And ItemConditions in (@ItemCode)
";

        public static string SP_ClientQuota = @"
            select 
                   cov.ACCOUNTNUM as CustomerCode,
	               ss.ITEMID as ItemId,
	               ss.FROMDATE as FromDate,
	               ss.TODATE as ToDate,
	               ss.PRIMARYVENDORID as VendorCode,
	               COV.QTY      as CurrentQty,
	               ss.QTY       as CeillingQty,
	               ss.SALESPRICE as SalesPrice,
	               ss.VALUE as Value,
	               ss.QTY - COV.QTY as RemainQty
	   
            from  [SOF-SRV-DB12].[SofDynAXLive].dbo.CustomerOverceilingValidation  as COV left join
                  [SOF-SRV-DB12].[SofDynAXLive].dbo.Sofico_SalesItemLimit         as SS on  ss.RECID = COV.SOFICO_SALESLIMITRECID  
	        where ss.FROMDATE<=cast(GETDATE() as date) and ss.TODATE>=cast(GETDATE() as date)
			And cov.ACCOUNTNUM in (@ClientCode)
            And ss.ITEMID in (@ItemCode)
            group by cov.ACCOUNTNUM,
	               ss.ITEMID,
	               ss.FROMDATE,
	               ss.TODATE,
	               ss.PRIMARYVENDORID,
	               COV.QTY     ,
	               ss.QTY       ,
	               ss.SALESPRICE,
	               ss.VALUE
";

        public QuotaMigrator(IConfiguration configuration)
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

                _AXCommand.CommandTimeout = 5000;
                _RemoteCommand.CommandTimeout = 5000;
                _TempCommand.CommandTimeout = 5000;
                _SqlBulkCopy.BulkCopyTimeout = 5000;

                _AXCommand.Connection = _AXConnection;
                _RemoteCommand.Connection = _RemoteConnection;
                _TempCommand.Connection = _TempConnection;

                _AXAdapter = new SqlDataAdapter();
                _RemoteAdapter = new SqlDataAdapter();
                _TempAdapter = new SqlDataAdapter();


                // get Params

                _RemoteCommand.CommandType = CommandType.Text;
                _RemoteCommand.CommandText = @"select top 10 DetailId, Payload3 as ClientCode, Payload1 as ItemCode  from SyncSetup_Detail where SetupId=3";

                var reader = _RemoteCommand.ExecuteReader();
                List<string> ItemCodeList = new List<string>();
                List<string> ClientCodeList = new List<string>();
                List<int> DetailIdList = new List<int>();

                while (reader.Read())
                {
                    if ( reader["ItemCode"] != null && !string.IsNullOrEmpty(reader["ItemCode"].ToString()))
                    {
                        var existItemCode = ItemCodeList.Where(a => a.Equals(reader["ItemCode"].ToString())).FirstOrDefault();
                        if (existItemCode == null)
                        {
                            ItemCodeList.Add("'" + reader["ItemCode"].ToString() + "'");
                        }
                    }

                    if (reader["ClientCode"] != null && !string.IsNullOrEmpty(reader["ClientCode"].ToString()))
                    {
                        var existClientCode = ClientCodeList.Where(a => a.Equals(reader["ClientCode"].ToString())).FirstOrDefault();
                        if (existClientCode == null)
                        {
                            ClientCodeList.Add("'" + reader["ClientCode"].ToString() + "'");
                        }
                    }

                    if (reader["DetailId"] != null && !string.IsNullOrEmpty(reader["DetailId"].ToString()))
                    {
                        DetailIdList.Add(int.Parse(reader["DetailId"].ToString()));
                    }

                }

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table ItemQuota";
                _TempCommand.ExecuteNonQuery();

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table ClientQuotaException";
                _TempCommand.ExecuteNonQuery();

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table ClientQuota";
                _TempCommand.ExecuteNonQuery();

                if (ItemCodeList.Count > 0)
                {
                    // execute AX
                    var ItemCodes = string.Join(',', ItemCodeList);
                    _AXCommand.CommandType = CommandType.Text;
                    _AXCommand.CommandText = SP_ItemQuota.Replace("@ItemCode", ItemCodes);
                    DataTable dtItem = new DataTable();
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dtItem);
                    _SqlBulkCopy.DestinationTableName = "ItemQuota";
                    _SqlBulkCopy.ColumnMappings.Clear();
                    _SqlBulkCopy.ColumnMappings.Add("ITEMID", "ITEMID");
                    _SqlBulkCopy.ColumnMappings.Add("FROMDATE", "FROMDATE");
                    _SqlBulkCopy.ColumnMappings.Add("TODATE", "TODATE");
                    _SqlBulkCopy.ColumnMappings.Add("CeillingQty", "CeillingQty");
                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dtItem);
                }



                if (ItemCodeList.Count > 0 && ClientCodeList.Count > 0)
                {
                    var ItemCodes = string.Join(',', ItemCodeList);

                    var ClientCodes = string.Join(',', ClientCodeList);

                    _AXCommand.CommandType = CommandType.Text;
                    _AXCommand.CommandText = SP_ClientExceptionQuota.Replace("@ItemCode",ItemCodes).Replace("@ClientCode",ClientCodes);
                    DataTable dtExeption = new DataTable();
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dtExeption);
                    _SqlBulkCopy.DestinationTableName = "ClientQuotaException";
                    _SqlBulkCopy.ColumnMappings.Clear();
                    _SqlBulkCopy.ColumnMappings.Add("ClientCode", "ClientCode");
                    _SqlBulkCopy.ColumnMappings.Add("ItemCode", "ItemCode");
                    _SqlBulkCopy.ColumnMappings.Add("FromDate", "FromDate");
                    _SqlBulkCopy.ColumnMappings.Add("ToDate", "ToDate");
                    _SqlBulkCopy.ColumnMappings.Add("QTY", "QTY");
                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dtExeption);


                    // execute AX

                  
                    _AXCommand.CommandType = CommandType.Text;
                    _AXCommand.CommandText = SP_ClientQuota.Replace("@ItemCode", ItemCodes).Replace("@ClientCode", ClientCodes);
                    DataTable dtClientQuota = new DataTable();
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dtClientQuota);

                    _SqlBulkCopy.DestinationTableName = "ClientQuota";
                    _SqlBulkCopy.ColumnMappings.Clear();
                    _SqlBulkCopy.ColumnMappings.Add("CustomerCode", "CustomerCode");
                    _SqlBulkCopy.ColumnMappings.Add("ItemId", "ItemId");
                    _SqlBulkCopy.ColumnMappings.Add("FromDate", "FromDate");
                    _SqlBulkCopy.ColumnMappings.Add("ToDate", "ToDate");
                    _SqlBulkCopy.ColumnMappings.Add("VendorCode", "VendorCode");
                    _SqlBulkCopy.ColumnMappings.Add("CurrentQty", "CurrentQty");
                    _SqlBulkCopy.ColumnMappings.Add("CeillingQty", "CeillingQty");
                    _SqlBulkCopy.ColumnMappings.Add("SalesPrice", "SalesPrice");
                    _SqlBulkCopy.ColumnMappings.Add("Value", "Value");
                    _SqlBulkCopy.ColumnMappings.Add("RemainQty", "RemainQty");

                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dtClientQuota);

                }

                var DetailId= string.Join(',', DetailIdList);
                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_Quota";
                _TempCommand.Parameters.Add(new SqlParameter("DetailId", DetailId));
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
