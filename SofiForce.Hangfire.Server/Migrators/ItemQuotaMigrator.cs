

using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class ItemQuotaMigrator
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
Select 
		  ItemId as ITEMID, 
		  FromDate as FROMDATE , 
		  ToDate as TODATE, 
		  Qty as CeillingQty

From [SOF-SRV-DB12].[SofDynAXLive].dbo.SFC_ItemLimit ss
Where Operational   = 1
and ss.FROMDATE<=cast(GETDATE() as date) and ss.TODATE>=cast(GETDATE() as date)
Order By FromDate Desc      
";
               
        public ItemQuotaMigrator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Migrate()
        {
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
                _TempCommand.CommandText = "truncate table ItemQuota";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_ItemQuota;
                DataTable dt = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                _AXAdapter.Fill(dt);


                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "ItemQuota";

                _SqlBulkCopy.ColumnMappings.Add("ITEMID", "ITEMID");
                _SqlBulkCopy.ColumnMappings.Add("FROMDATE", "FROMDATE");
                _SqlBulkCopy.ColumnMappings.Add("TODATE", "TODATE");
                _SqlBulkCopy.ColumnMappings.Add("CeillingQty", "CeillingQty");


                _SqlBulkCopy.BatchSize = 5000;
                _SqlBulkCopy.WriteToServer(dt);



            }
            catch (Exception ex)
            {
                throw;
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

        }
    }
}
