
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class SupplementryItemMigrator
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
and ACCOUNTCODE='1' and ACCOUNTRELATION='1'
                        ";
        public SupplementryItemMigrator(IConfiguration configuration)
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
                _TempCommand.CommandText = "truncate table Supplementary";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_Supl;
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


                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Batch_Promotion_Supplementary";
                _TempCommand.Parameters.Add(new SqlParameter("UserId", 1));
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
