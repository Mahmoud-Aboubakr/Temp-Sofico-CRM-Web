using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using DocumentFormat.OpenXml.Spreadsheet;

namespace SofiForce.Web.Dapper.Implementation
{
    public class SalesLimitManager : ISalesLimitManager
    {

        private readonly DapperTempContext _tempContext;
        private readonly DapperContext _context;

        public SalesLimitManager(DapperTempContext tempContext, DapperContext context)
        {
            _tempContext = tempContext;
            _context = context;
        }

        public Task ClearMonth()
        {


            using (var connection = _context.CreateConnection())
            {
                var Res = connection.Query(string.Format("delete from SFF_DB_TEST.dbo.Client_CreditLimit where LimitYear=year(GETDATE()) and LimitMonth = MONTH(GETDATE()) "), commandType: CommandType.Text);
            }

            return Task.CompletedTask;
        }

        public Task Upload(DataTable dt,int UserId)
        {

            if (dt != null)
            {

                using (var connection = _tempContext.CreateConnection())
                {
                    var Res = connection.Query(string.Format("truncate table Client_CreditLimit"), commandType: CommandType.Text);
                }

                using (var _SqlBulkCopy = new SqlBulkCopy(_tempContext.CreateConnection().ConnectionString))
                {
                    _SqlBulkCopy.DestinationTableName = "Client_CreditLimit";

                    _SqlBulkCopy.ColumnMappings.Add("ClientCode", "ClientCode");
                    _SqlBulkCopy.ColumnMappings.Add("LimitYear", "LimitYear");
                    _SqlBulkCopy.ColumnMappings.Add("LimitMonth", "LimitMonth");
                    _SqlBulkCopy.ColumnMappings.Add("LimitValue", "LimitValue");
   

                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dt);
                }



                using (var connection = _tempContext.CreateConnection())
                {
                    var Res = connection.Query(string.Format("exec Batch_Client_CreditLimit {0} ", UserId), commandType: CommandType.Text);
                }
            }


            return Task.CompletedTask;
        }

    }
}
