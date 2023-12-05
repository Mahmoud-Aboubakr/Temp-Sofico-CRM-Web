using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using Models;
using System.Collections.Generic;

namespace SofiForce.Web.Dapper.Implementation
{
    public class ClientPlanManager : IClientPlanManager
    {

        private readonly DapperContext _context;
        public ClientPlanManager(DapperContext context)
        {
            _context = context;
        }

        public Task clear()
        {
            using (var connection = _context.CreateConnection())
            {
                var Res = connection.Query(string.Format("delete from Client_plan where year(TargetDate)=YEAR(GETDATE()) and month(TargetDate)=MONTH(GETDATE())"), commandType: CommandType.Text);
            }

            return Task.CompletedTask;
        }

        public Task duplicate(int UserId,int Year, int Month)
        {
            using (var connection = _context.CreateConnection())
            {
                var Res = connection.Query(string.Format("exec Batch_ClientPlan_Duplicate {0},{1},{2}", UserId, Year, Month), commandType: CommandType.Text);
            }
            return Task.CompletedTask;
        }

        public Task Upload(DataTable dt,int UserId)
        {

            if (dt != null)
            {

                using (var _SqlBulkCopy = new SqlBulkCopy(_context.CreateConnection().ConnectionString))
                {
                    _SqlBulkCopy.DestinationTableName = "temp_ClientPlan";

                    _SqlBulkCopy.ColumnMappings.Add("ClientCode", "ClientCode");
                    _SqlBulkCopy.ColumnMappings.Add("TargetValue", "TargetValue");

                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dt);
                }



                using (var connection = _context.CreateConnection())
                {
                    var Res = connection.Query(string.Format("exec Batch_ClientPlan_Migrator {0} ", UserId), commandType: CommandType.Text);
                }
            }


            return Task.CompletedTask;
        }
    }
}
