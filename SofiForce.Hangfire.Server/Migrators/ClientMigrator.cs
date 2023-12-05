
using System.Data;
using System.Data.SqlClient;


namespace SofiForce.Hangfire.Server
{
    public class ClientMigrator
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
        public static string SP_Clients = @"
					   SELECT  
                      c.CUSTGROUP AS  ClientGroupid,           
                      c.ACCOUNTNUM AS ClientCode,
					  c.INVOICEACCOUNT as CustomerAccountCode,
                      c.SALESPOOLID as SalesPoolCode,
                      ltrim(rtrim((replace(Dir.NAME,',',' ')))) AS ClientName,
                      c.InventSiteId as BranchId,
                      c.InvoiceAccount AS IsSeries,    
                      '' AS  ADDRESS,
                      '' as Phone1,
                      '' as Phone2, --c.PhoneLocal
                      ''  as Whatsup,--c.CellularPhone
                      c.BLOCKED as Blocked,
                      0 as Latitude,
                      0  as Longitude,
                      null              AS GOVCODE,
                      null           AS DISTCODE,
                      c.SalesGroup         as MainSect,
                      c.Field1             as Subcode,
                      ''               as subbranch,
                      case when C.CREDITMAX <> 0 then C.CREDITMAX else C.CREDITMAX   end       AS CREDITLIMITE,
                      C.PAYMTERMID,
                      CB.USED              AS OPENTRANS,
                      CB.USED  AS NET,
					  C.TAXGROUP           AS TAXGROUP,
					  C.CashDisc           as CashDisc
                     
                      

FROM                   [SOF-SRV-DB12].[SofDynAXLive].dbo.CUSTTABLE AS c  full outer join
                        [SOF-SRV-DB12].[SofDynAXLive].dbo.[DIRPARTYTABLE] as Dir on c.PARTY= Dir.RECID full outer join 
                       [SOF-SRV-DB12].[SofDynAXLive].dbo.CUSTBALANCE AS CB ON CB.ACCOUNTNUM=C.ACCOUNTNUM
                     
                      
WHERE     c.DATAAREAID = 'sfc' 
and  c.ACCOUNTNUM='CAI1021353'
";
        public ClientMigrator(IConfiguration configuration)
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
                _TempCommand.CommandText = "truncate table Clients";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_Clients;
                DataTable dt = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                _AXAdapter.Fill(dt);


                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "Clients";

                _SqlBulkCopy.ColumnMappings.Add("ClientGroupid", "ClientGroupid");
                _SqlBulkCopy.ColumnMappings.Add("ClientCode", "ClientCode");
                _SqlBulkCopy.ColumnMappings.Add("CustomerAccountCode", "CustomerAccountCode");
                _SqlBulkCopy.ColumnMappings.Add("SalesPoolCode", "SalesPoolCode");

                _SqlBulkCopy.ColumnMappings.Add("ClientName", "ClientName");
                _SqlBulkCopy.ColumnMappings.Add("BranchId", "BranchId");
                _SqlBulkCopy.ColumnMappings.Add("IsSeries", "IsSeries");
                _SqlBulkCopy.ColumnMappings.Add("ADDRESS", "ADDRESS");
                _SqlBulkCopy.ColumnMappings.Add("Phone1", "Phone1");
                _SqlBulkCopy.ColumnMappings.Add("Phone2", "Phone2");
                _SqlBulkCopy.ColumnMappings.Add("Whatsup", "Whatsup");
                _SqlBulkCopy.ColumnMappings.Add("Blocked", "Blocked");
                _SqlBulkCopy.ColumnMappings.Add("Latitude", "Latitude");
                _SqlBulkCopy.ColumnMappings.Add("Longitude", "Longitude");
                _SqlBulkCopy.ColumnMappings.Add("GOVCODE", "GOVCODE");
                _SqlBulkCopy.ColumnMappings.Add("DISTCODE", "DISTCODE");
                _SqlBulkCopy.ColumnMappings.Add("MainSect", "MainSect");
                _SqlBulkCopy.ColumnMappings.Add("Subcode", "Subcode");
                _SqlBulkCopy.ColumnMappings.Add("subbranch", "subbranch");
                _SqlBulkCopy.ColumnMappings.Add("CREDITLIMITE", "CREDITLIMITE");
                _SqlBulkCopy.ColumnMappings.Add("PAYMTERMID", "PAYMTERMID");
                _SqlBulkCopy.ColumnMappings.Add("OPENTRANS", "OPENTRANS");
                _SqlBulkCopy.ColumnMappings.Add("NET", "NET");
                _SqlBulkCopy.ColumnMappings.Add("TAXGROUP", "TAXGROUP");
                _SqlBulkCopy.ColumnMappings.Add("CashDisc", "CashDisc");

                _SqlBulkCopy.BatchSize = 5000;
                _SqlBulkCopy.WriteToServer(dt);


                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_Clients";
                _TempCommand.ExecuteNonQuery();

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
