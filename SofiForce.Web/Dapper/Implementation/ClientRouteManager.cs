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
    public class ClientRouteManager : IClientRouteManager
    {

        private readonly DapperContext _context;
        public ClientRouteManager(DapperContext context)
        {
            _context = context;
        }

        public Task ClearAll()
        {
            using (var connection = _context.CreateConnection())
            {
               connection.Execute(string.Format("truncate table temp_ClientRoute"), commandType: CommandType.Text);
               connection.Execute(string.Format("truncate table Client_Route"), commandType: CommandType.Text);
            }

            return Task.CompletedTask;
        }

        public Task Upload(DataTable dt,int UserId)
        {

            if (dt != null)
            {

                using (var connection = _context.CreateConnection())
                {
                    var Res = connection.Execute(string.Format("truncate table temp_ClientRoute"), commandType: CommandType.Text);
                }

                using (var _SqlBulkCopy = new SqlBulkCopy(_context.CreateConnection().ConnectionString))
                {
                    _SqlBulkCopy.DestinationTableName = "temp_ClientRoute";

                    _SqlBulkCopy.ColumnMappings.Add("ClientCode", "ClientCode");
                    _SqlBulkCopy.ColumnMappings.Add("RouteCode", "RouteCode");

                    _SqlBulkCopy.ColumnMappings.Add("Day1", "Day1");
                    _SqlBulkCopy.ColumnMappings.Add("Day2", "Day2");
                    _SqlBulkCopy.ColumnMappings.Add("Day3", "Day3");
                    _SqlBulkCopy.ColumnMappings.Add("Day4", "Day4");
                    _SqlBulkCopy.ColumnMappings.Add("Day5", "Day5");
                    _SqlBulkCopy.ColumnMappings.Add("Day6", "Day6");
                    _SqlBulkCopy.ColumnMappings.Add("Day7", "Day7");

                    _SqlBulkCopy.BatchSize = 5000;
                    _SqlBulkCopy.WriteToServer(dt);
                }



                using (var connection = _context.CreateConnection())
                {
                    var Res = connection.Execute(string.Format("exec Batch_ClientRoute_Migrator {0} ", UserId), commandType: CommandType.Text);
                }
            }


            return Task.CompletedTask;
        }
    }
}
