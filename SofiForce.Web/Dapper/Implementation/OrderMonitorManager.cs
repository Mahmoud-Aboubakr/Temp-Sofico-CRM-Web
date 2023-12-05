using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using SofiForce.Models.StatisticalModels;
using System.Collections.Generic;
using SofiForce.Web.Common;
using Models;

namespace SofiForce.Web.Dapper.Implementation
{
    public class OrderMonitorManager : IOrderMonitorManager
    {

        private readonly DapperContext _context;
        public OrderMonitorManager(DapperContext context)
        {
            _context = context;
        }

        public OrderMonitorModel getMonitor(int? BranchId, string lan)
        {
            OrderMonitorModel model = new OrderMonitorModel();



            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new
                    {
                        @lan = lan,
                        @BranchId= BranchId>0?BranchId:null
                    };

                    model.Details = connection.Query<OrderMonitorDetailModel>("Query_Order_Monitor", param, commandType: CommandType.StoredProcedure);

                    if (model.Details != null && model.Details.Count() > 0)
                    {

                        model.Invoiced = model.Details.Sum(a => a.Invoiced);
                        model.Confirmed = model.Details.Sum(a => a.Confirmed);
                        model.Opened = model.Details.Sum(a => a.Opened);
                        model.Transfered = model.Details.Sum(a => a.Transfered);
                        model.Rejected = model.Details.Sum(a => a.Rejected);

                        model.All = model.Opened + model.Confirmed + model.Transfered+model.Invoiced;


                        if (model.All > 0)
                            model.Perormance = Math.Round((decimal)model.Invoiced / (decimal)model.All * 100, 0);



                        //model.PerormancePercentage = 30;
                        foreach (var item in model.Details)
                        {
                            item.All = item.Opened + item.Confirmed + item.Transfered+ item.Invoiced;
                            if (item.All > 0)
                                item.Perormance = Math.Round((decimal)(item.Invoiced) / (decimal)item.All * 100, 0);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return model;
        }
    }
}
