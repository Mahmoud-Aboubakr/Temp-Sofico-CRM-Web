
using SofiForce.Integration.Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class ClientQuotaMigrator
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
			--and ss.MODIFIEDDATETIME>DATEADD(day,-3,GETDATE())
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


        public ClientQuotaMigrator(IConfiguration configuration)
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


                // execute AX

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table ClientQuota";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_ClientQuota;
                DataTable dt = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                _AXAdapter.Fill(dt);


                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "ClientQuota";

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
                _SqlBulkCopy.WriteToServer(dt);


                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_ClientQuota";
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
