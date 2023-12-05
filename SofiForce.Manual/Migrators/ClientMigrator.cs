
using SofiForce.Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
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
                      case when ac.CREDITMAX <> 0 then ac.CREDITMAX else C.CREDITMAX   end       AS CREDITLIMITE,
                      C.PAYMTERMID,
                      CB.USED              AS OPENTRANS,
                      CB.USED  AS NET,
					  C.TAXGROUP           AS TAXGROUP,
					  C.CashDisc           as CashDisc
                     
                      

FROM                   [SOF-SRV-DB12].[SofDynAXLive].dbo.CUSTTABLE AS c  inner join
                        [SOF-SRV-DB12].[SofDynAXLive].dbo.[DIRPARTYTABLE] as Dir on c.PARTY= Dir.RECID inner join 
						--[SOF-SRV-DB12].[SofDynAXLive].dbo.CustomerInfo   as info on c.ACCOUNTNUM = info.ACCOUNTNUM   inner join 
                      [10.100.1.183].[SoficoSBDB].dbo.HH_Customer AS u ON c.ACCOUNTNUM collate SQL_Latin1_General_CP1256_CI_AS = u.CustomerNo collate SQL_Latin1_General_CP1256_CI_AS LEFT OUTER join
                     -- SoficoDynAXR3Test.dbo.ADDRESSZIPCODE as z on c.ZIPCODE=z.ZIPCODE and c.DATAAREAID=z.DATAAREAID LEFT OUTER JOIN
                       [SOF-SRV-DB12].[SofDynAXLive].dbo.CUSTBALANCE AS CB ON CB.ACCOUNTNUM=C.ACCOUNTNUM left join

                     [SOF-SRV-DB12].[SofDynAXLive].dbo.CUSTTABLE ac on c.InvoiceAccount=ac.ACCOUNTNUM
                      
WHERE     c.DATAAREAID = 'sfc' 
and c.ACCOUNTNUM in (@ClientCode)
";

        public static string SP_ClientBalances = @"
select ACCOUNTNUM,	USED from
[SOF-SRV-DB12].[SofDynAXLive].dbo.CUSTBALANCE
where ACCOUNTNUM in (@ClientCode)
";
        public ClientMigrator(IConfiguration configuration)
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

                // get Params

                _RemoteCommand.CommandType = CommandType.Text;
                _RemoteCommand.CommandText = @"select top 10 DetailId, Payload2 as ClientCode  from SyncSetup_Detail where SetupId=1";

                var reader = _RemoteCommand.ExecuteReader();
                List<string> ClientCodeList = new List<string>();
                List<int> DetailIdList = new List<int>();

                while (reader.Read())
                {
                    

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
                _TempCommand.CommandText = "truncate table Clients";
                _TempCommand.ExecuteNonQuery();

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table ClientBalance";
                _TempCommand.ExecuteNonQuery();

                if (ClientCodeList.Count > 0)
                {
                    var ClientCodes = string.Join(',', ClientCodeList);



                    _AXCommand.CommandType = CommandType.Text;
                    _AXCommand.CommandText = SP_Clients.Replace("@ClientCode", ClientCodes);

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


                    // execute AX

                  

                    _AXCommand.CommandType = CommandType.Text;
                    _AXCommand.CommandText = SP_ClientBalances.Replace("@ClientCode", ClientCodes);
                    DataTable dtBalance = new DataTable();
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dtBalance);


                    // Migrrate Data
                    _SqlBulkCopy.ColumnMappings.Clear();
                    _SqlBulkCopy.DestinationTableName = "ClientBalance";
                    _SqlBulkCopy.ColumnMappings.Add("ACCOUNTNUM", "ACCOUNTNUM");
                    _SqlBulkCopy.ColumnMappings.Add("USED", "USED");
                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dtBalance);

                    var DetailId = string.Join(',', DetailIdList);
                    _TempCommand.CommandType = CommandType.StoredProcedure;
                    _TempCommand.CommandText = "Migrate_Clients";
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
