
using SofiForce.Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class PromotionMigrator
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

        public static string SP_Supl = @"
SELECT 
       Supp.[FROMDATE] as FromDate
      ,Supp.[TODATE] as ToDate
	  ,Supp.[ITEMRELATION] as InputCode
	  ,0 as Slice
	  ,Supp.[MINIMUMQTY] as Quantity
      ,Supp.[SUPPITEMQTY] as Bouns
      ,Supp.[SUPPITEMID] as OutputCode
	  ,1 as Activate

      
  FROM  [SOF-SRV-DB12].[SofDynAXLive].dbo.[SUPPITEMTABLE] as Supp 
  where Supp.[FROMDATE]<=cast(GETDATE() as date) and Supp.[TODATE]>=cast(GETDATE() as date)
and Supp.[ITEMRELATION] in (@ItemCode)
                        ";
        public PromotionMigrator(IConfiguration configuration)
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


                // get param


                _RemoteCommand.CommandType = CommandType.Text;
                _RemoteCommand.CommandText = @"select top 10 DetailId, Payload1 as ItemCode  from SyncSetup_Detail where SetupId=4";

                var reader = _RemoteCommand.ExecuteReader();
                List<string> ItemCodeList = new List<string>();
                List<int> DetailIdList = new List<int>();

                while (reader.Read())
                {
                    if (reader["ItemCode"] != null && !string.IsNullOrEmpty(reader["ItemCode"].ToString()))
                    {
                        var existItemCode = ItemCodeList.Where(a => a.Equals(reader["ItemCode"].ToString())).FirstOrDefault();
                        if (existItemCode == null)
                        {
                            ItemCodeList.Add("'" + reader["ItemCode"].ToString() + "'");
                        }
                    }

                    if (reader["DetailId"] != null && !string.IsNullOrEmpty(reader["DetailId"].ToString()))
                    {
                        DetailIdList.Add(int.Parse(reader["DetailId"].ToString()));
                    }

                }

                // execute AX

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table Supplementary";
                _TempCommand.ExecuteNonQuery();

                if (ItemCodeList.Count > 0)
                {
                    var ItemCodes = string.Join(',', ItemCodeList);
                    _AXCommand.CommandType = CommandType.Text;
                    _AXCommand.CommandText = SP_Supl.Replace("@ItemCode", ItemCodes);
                    DataTable dt = new DataTable();
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dt);


                    // Migrrate Data
                    _SqlBulkCopy.DestinationTableName = "Supplementary";

                    _SqlBulkCopy.ColumnMappings.Add("FromDate", "FromDate");
                    _SqlBulkCopy.ColumnMappings.Add("ToDate", "ToDate");
                    _SqlBulkCopy.ColumnMappings.Add("InputCode", "InputCode");
                    _SqlBulkCopy.ColumnMappings.Add("Slice", "Slice");
                    _SqlBulkCopy.ColumnMappings.Add("Quantity", "Quantity");
                    _SqlBulkCopy.ColumnMappings.Add("Bouns", "Bouns");
                    _SqlBulkCopy.ColumnMappings.Add("OutputCode", "OutputCode");
                    _SqlBulkCopy.ColumnMappings.Add("Activate", "Activate");

                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dt);

                    var DetailId = string.Join(',', DetailIdList);
                    _TempCommand.CommandType = CommandType.StoredProcedure;
                    _TempCommand.CommandText = "Batch_Promotion_Supplementary";
                    _TempCommand.Parameters.Add(new SqlParameter("UserId", 1));
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
