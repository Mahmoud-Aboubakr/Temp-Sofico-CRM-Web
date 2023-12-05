
using System.Data;
using System.Data.SqlClient;


namespace SFFService.Services
{
    public class DistributorMigrator
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


        public static string SP_Distributors = @"select    e.Inventsiteid   as BranchCode,
		   e.EMPLID as RepresentativeCode,
		               ltrim(rtrim((replace(d.NAME,',',' '))))  as RepresentativeName,
		               e.STATUS as IsActive
            from
             DB.DynamicsAX.dbo.EMPLTABLE             AS e   inner join
             DB.DynamicsAX.dbo.DIRPARTYTABLE         AS d  ON e.PARTYID = d.PARTYID AND e.DATAAREAID = d.DATAAREAID 
             where e.dataareaid= 'sfc'
             and title='Distributor'
             and cast (d.MODIFIEDDATETIME as date)>DATEADD(DAY,-3,GETDATE())";
        public DistributorMigrator(ILogger logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public  void Migrate()
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
                _TempCommand.CommandText = "truncate table Distributors";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_Distributors;
                DataTable dt = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                _AXAdapter.Fill(dt);


                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "Distributors";

                _SqlBulkCopy.ColumnMappings.Add("BranchCode", "BranchCode");
                _SqlBulkCopy.ColumnMappings.Add("RepresentativeCode", "RepresentativeCode");
                _SqlBulkCopy.ColumnMappings.Add("RepresentativeName", "RepresentativeName");
                _SqlBulkCopy.ColumnMappings.Add("IsActive", "IsActive");
                

                _SqlBulkCopy.BatchSize = 5000;
                _SqlBulkCopy.WriteToServer(dt);


                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_Distributors";
                _TempCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                _logger.LogError("Distributor Migrator: {error}: {time}", ex.Message, DateTimeOffset.Now);
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
