
using Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class InvoiceDiscountMigrator
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



        public static string SP_InvoiceHeader = @"
            SELECT 

            CJ.INVOICEID         AS InvoiceCode,	
            CJ.CashDisc

            FROM  
            [SOF-SRV-DB12].SofDynAXLive.dbo.CUSTINVOICEJOUR  CJ
            WHERE 
            (
                 CJ.DATAAREAID='SFC'
             and CJ.CREATEDDATETIME>=dateadd(MONTH,-3,getdate())
            )
        ";
        public InvoiceDiscountMigrator(IConfiguration configuration)
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


                _AXCommand.Connection = _AXConnection;
                _RemoteCommand.Connection = _RemoteConnection;
                _TempCommand.Connection = _TempConnection;

                _AXCommand.CommandTimeout = 5000;
                _RemoteCommand.CommandTimeout = 5000;
                _TempCommand.CommandTimeout = 5000;
                _SqlBulkCopy.BulkCopyTimeout = 5000;

                _AXAdapter = new SqlDataAdapter();
                _RemoteAdapter = new SqlDataAdapter();
                _TempAdapter = new SqlDataAdapter();


                // execute AX



                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table Invoice_Cash";
                _TempCommand.ExecuteNonQuery();



                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_InvoiceHeader;
                DataTable dtHeader = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                _AXAdapter.Fill(dtHeader);

                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "Invoice_Cash";
                _SqlBulkCopy.ColumnMappings.Add("InvoiceCode", "InvoiceCode");
                _SqlBulkCopy.ColumnMappings.Add("CashDisc", "CashDisc");
                _SqlBulkCopy.BatchSize = 5000;
                _SqlBulkCopy.WriteToServer(dtHeader);

                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_Invoice_Cash";
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
