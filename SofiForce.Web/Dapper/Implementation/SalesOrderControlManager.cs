using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using SofiForce.Models.StatisticalModels;
using System.Collections.Generic;
using Models;
using static SofiForce.Web.Common.DateTimExtensions;
using SofiForce.Web.Common;

namespace SofiForce.Web.Dapper.Implementation
{
    public class SalesOrderControlManager : ISalesOrderControlManager
    {

        private readonly DapperContext _context;
        public SalesOrderControlManager(DapperContext context)
        {
            _context = context;
        }



        public int markConfirm(string salesIds, int UserId)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new
                    {
                        @SalesIds = salesIds,
                        @UserId = UserId
                    };

                    return connection.Execute("Batch_Mark_confirm", param, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int markTransfer(string salesIds, int UserId)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new
                    {
                        @SalesIds = salesIds,
                        @UserId = UserId
                    };

                    return connection.Execute("Batch_Mark_Transfer", param, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
