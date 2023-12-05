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
    public class SalesOrderManager : ISalesOrderManager
    {

        private readonly DapperContext _context;
        public SalesOrderManager(DapperContext context)
        {
            _context = context;
        }

        public int UpdateOnhand(double SalesId, bool IsOpen)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var param = new
                    {
                        @SalesId = SalesId
                    };

                    if (IsOpen == true)
                    {
                        return connection.Execute("Batch_SalesOrder_updateOnhand_Order_Open", param, commandType: CommandType.StoredProcedure);

                    }
                    else
                    {
                        return connection.Execute("Batch_SalesOrder_updateOnhand_Order", param, commandType: CommandType.StoredProcedure);

                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
