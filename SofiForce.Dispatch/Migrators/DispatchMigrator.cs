

using SofiForce.Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class DispatchMigrator
    {
        private readonly IConfiguration _configuration;

        private SqlConnection _DispatchConnection;
        private SqlConnection _RemoteConnection;
        private SqlConnection _TempConnection;

        private SqlCommand _DispatchCommand;
        private SqlCommand _RemoteCommand;
        private SqlCommand _TempCommand;

        private SqlDataAdapter _RemoteAdapter;
        private SqlDataAdapter _AXAdapter;
        private SqlDataAdapter _TempAdapter;

        private SqlBulkCopy _SqlBulkCopy;

        public static string SP_Dispatch =
@"
SELECT        
ClientOrder_Dispach.DispatchCode, 
ClientOrder_Dispach.DispatchDate, 
ClientOrder_Dispach.DispatchStatusId, 
ClientOrder_Dispach.InvoiceCode, 
Distributor.DistributorCode,
Distributor.DistributorName, 
Driver.DriverCode, 
Driver.DriverName, 
Branch.BranchCode, 
Branch.BranchName
FROM            ClientOrder_Dispach INNER JOIN
                         Car ON ClientOrder_Dispach.CarId = Car.CarId LEFT OUTER JOIN
                         Branch ON ClientOrder_Dispach.BranchId = Branch.BranchId LEFT OUTER JOIN
                         Driver ON ClientOrder_Dispach.DriverId = Driver.DriverId LEFT OUTER JOIN
                         Distributor ON ClientOrder_Dispach.DistributorId = Distributor.DistributorId
where ClientOrder_Dispach.EditDate > DATEADD(day,-1,GETDATE())
";
               
        public DispatchMigrator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MigrationDTO Migrate()
        {
            MigrationDTO Res = new MigrationDTO();
            try
            {
                _DispatchConnection = new SqlConnection(_configuration["DispatchConnection"]);
                _RemoteConnection = new SqlConnection(_configuration["RemoteConnection"]);
                _TempConnection = new SqlConnection(_configuration["TempConnection"]);

                _SqlBulkCopy = new SqlBulkCopy(_configuration["TempConnection"]);

                _RemoteConnection.Open();
                _DispatchConnection.Open();
                _TempConnection.Open();

                _DispatchCommand = new SqlCommand();
                _RemoteCommand = new SqlCommand();
                _TempCommand = new SqlCommand();

                _DispatchCommand.CommandTimeout = 5000;
                _RemoteCommand.CommandTimeout = 5000;
                _TempCommand.CommandTimeout = 5000;
                _SqlBulkCopy.BulkCopyTimeout = 5000;

                _DispatchCommand.Connection = _DispatchConnection;
                _RemoteCommand.Connection = _RemoteConnection;
                _TempCommand.Connection = _TempConnection;

                _AXAdapter = new SqlDataAdapter();
                _RemoteAdapter = new SqlDataAdapter();
                _TempAdapter = new SqlDataAdapter();


                // execute AX

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table Dispatch";
                _TempCommand.ExecuteNonQuery();

                _DispatchCommand.CommandType = CommandType.Text;
                _DispatchCommand.CommandText = SP_Dispatch;
                DataTable dt = new DataTable();
                _AXAdapter.SelectCommand = _DispatchCommand;
                _AXAdapter.Fill(dt);


                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "Dispatch";

                _SqlBulkCopy.ColumnMappings.Add("DispatchCode", "DispatchCode");
                _SqlBulkCopy.ColumnMappings.Add("DispatchDate", "DispatchDate");
                _SqlBulkCopy.ColumnMappings.Add("DispatchStatusId", "DispatchStatusId");
                _SqlBulkCopy.ColumnMappings.Add("InvoiceCode", "InvoiceCode");
                _SqlBulkCopy.ColumnMappings.Add("DistributorCode", "DistributorCode");
                _SqlBulkCopy.ColumnMappings.Add("DistributorName", "DistributorName");
                _SqlBulkCopy.ColumnMappings.Add("DriverCode", "DriverCode");
                _SqlBulkCopy.ColumnMappings.Add("DriverName", "DriverName");
                _SqlBulkCopy.ColumnMappings.Add("BranchCode", "BranchCode");
                _SqlBulkCopy.ColumnMappings.Add("BranchName", "BranchName");


                _SqlBulkCopy.BatchSize = 5000;
                _SqlBulkCopy.WriteToServer(dt);



                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_Dispatch";
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
                _DispatchConnection.Close();
                _TempConnection.Close();

                _DispatchCommand.Dispose();
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
