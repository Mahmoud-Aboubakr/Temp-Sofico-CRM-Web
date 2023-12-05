
using SofiForce.Integration.Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class StoreMigrator
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



        //Done
        public static string SP_Location = @"
            select 
	             L.RecId
                  ,L.InventLocationId as InventLocationId
                  , Sl.SiteType as SiteType
	              , L.InventSiteID as BranchCode
	              , L.name AS InventSiteName
            from  [SOF-SRV-DB12].SofDynAXLive.dbo.InventLocation as L  
            left join [SOF-SRV-DB12].SofDynAXLive.dbo.Sofico_SiteTypeLocation as SL ON l.InventLocationId = sl.InventLocationId

            where L.DataAreaId = 'sfc' 
            and  L.MODIFIEDDATETIME>DATEADD(day,-3,GETDATE())
        ";


        public StoreMigrator( IConfiguration configuration)
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
                _TempCommand.CommandText = "truncate table Locations";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_Location;


                DataTable dt = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                _AXAdapter.Fill(dt);


                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "Locations";

                _SqlBulkCopy.ColumnMappings.Add("RecId", "RecId");
                _SqlBulkCopy.ColumnMappings.Add("InventLocationId", "InventLocationId");
                _SqlBulkCopy.ColumnMappings.Add("SiteType", "SiteType");
                _SqlBulkCopy.ColumnMappings.Add("BranchCode", "BranchCode");
                _SqlBulkCopy.ColumnMappings.Add("InventSiteName", "InventSiteName");



                _SqlBulkCopy.BatchSize = 5000;
                _SqlBulkCopy.WriteToServer(dt);


                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_Locations";
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
