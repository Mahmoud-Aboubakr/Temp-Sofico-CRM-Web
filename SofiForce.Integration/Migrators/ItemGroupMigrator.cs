
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class ItemGroupMigrator
    {
        private readonly ILogger _logger;
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

        private string Command = "";

        public ItemGroupMigrator(ILogger logger, IConfiguration configuration)
        {
            _logger = logger;
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
                _TempCommand.CommandText = "truncate table Vendors";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = Command;
                DataTable dt = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                _AXAdapter.Fill(dt);


                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "Vendors";

                _SqlBulkCopy.ColumnMappings.Add("VendorCode", "VendorCode");
                _SqlBulkCopy.ColumnMappings.Add("VendorName", "VendorName");
                _SqlBulkCopy.ColumnMappings.Add("IsActive", "IsActive");


                _SqlBulkCopy.BatchSize = 5000;
                _SqlBulkCopy.WriteToServer(dt);


                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_Vendors";
                _TempCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                _logger.LogError("Vendor Migrator: {error}: {time}", ex.Message, DateTimeOffset.Now);
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
