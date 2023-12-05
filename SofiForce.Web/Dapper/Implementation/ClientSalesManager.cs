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
    public class ClientSalesManager : IClientSalesManager
    {

        private readonly DapperContext _context;
        public ClientSalesManager(DapperContext context)
        {
            _context = context;
        }




        public DashboardClientPerfromanceModel getPerformance(DateTime from, DateTime to, int? ClientId)
        {
            DashboardClientPerfromanceModel model = new DashboardClientPerfromanceModel();



            int MonthDays = from.FirstDayOfMonth().BusinessDaysUntil(from.LastDayOfMonth());
            int workDays = from.BusinessDaysUntil(to);

            try
            {
                using (var connection = _context.CreateConnection())
                {


                    // get target kbi
                    var param = new
                    {
                        @from = from,
                        @to = to,
                        @ClientId = ClientId > 0 ? ClientId : 0,

                    };

                    var res = connection.Query<DashboardTimelineModel>("Query_Sales_Performance_ByClient", param, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();

                    if (res!=null)
                    {

                        model.Sales = Math.Round(res.LineValue,0);

                        if (res.LineTarget > 0)
                        {
                            if (from.Month == to.Month)
                            {
                                res.LineTarget = res.LineTarget / MonthDays * workDays;
                            }

                            model.Target =Math.Round(res.LineTarget,0);

                            if (model.Target>0)
                            {
                                model.Percentage = Math.Round(model.Sales / model.Target * 100, 0);

                            }
                            model.Label = Utils.getPerformanceLabel((decimal)model.Percentage);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }


            return model;
        }

        public List<DashboardClientTimelineModel> getSalesTimeline(DateTime from, DateTime to, int? ClientId)
        {
            List<DashboardClientTimelineModel> model = new List<DashboardClientTimelineModel>();



            int MonthDays = from.FirstDayOfMonth().BusinessDaysUntil(from.LastDayOfMonth());
            int workDays = from.BusinessDaysUntil(to);

            try
            {
                using (var connection = _context.CreateConnection())
                {


                    // get target kbi
                    var param = new
                    {
                        @from = from,
                        @to = to,
                        @ClientId = ClientId > 0 ? ClientId : 0,

                    };

                    model = connection.Query<DashboardClientTimelineModel>("Query_Sales_Timeline_ByClient", param, commandType: CommandType.StoredProcedure).ToList();

                    int maxLabel = 1;
                    double maxValue = 0;
                    if (model.Count > 0)
                    {
                       maxLabel = model.Max(a => a.LineLabel);
                       maxValue = model.Max(a => a.LineTarget);
                    }


                    for (int i = maxLabel + 1; i <= 12; i++)
                    {
                        model.Add(new DashboardClientTimelineModel() { LineLabel = i, LineValue = 0, LineTarget = 0 });
                    }



                }
            }
            catch (Exception ex)
            {

            }


            return model;

        }


        public List<DashboardClientSalesVendorModel> getVendorSales(DateTime from, DateTime to, int ClientId, string lan)
        {
            List<DashboardClientSalesVendorModel> model = new List<DashboardClientSalesVendorModel>();

            double Total = 0;
            try
            {
                using (var connection = _context.CreateConnection())
                {


                    var param = new DynamicParameters();
                    param.Add("from", from);
                    param.Add("to", to);
                    param.Add("ClientId", ClientId);
                    param.Add("lan", lan);

                    param.Add("total", dbType: DbType.Double, direction: ParameterDirection.Output);


                    model = connection.Query<DashboardClientSalesVendorModel>("Query_Sales_ByVendor_ByClient", param, commandType: CommandType.StoredProcedure).ToList();

                    Total = param.Get<double>("total");

                    if (Total > 0)
                    {
                        foreach (var item in model)
                        {
                            item.Percentage = Math.Round(item.LineValue / Total * 100, 0);
                        }
                    }


                }
            }
            catch (Exception ex)
            {

            }


            return model;
        }

        public List<DashboardClientSalesItemModel> getItemSales(DateTime from, DateTime to, int ClientId, string lan)
        {
            List<DashboardClientSalesItemModel> model = new List<DashboardClientSalesItemModel>();

            double Total = 0;
            try
            {
                using (var connection = _context.CreateConnection())
                {



                    var param = new DynamicParameters();
                    param.Add("from", from);
                    param.Add("to", to);
                    param.Add("ClientId", ClientId);
                    param.Add("lan", lan);

                    param.Add("total", dbType: DbType.Double, direction: ParameterDirection.Output);


                    model = connection.Query<DashboardClientSalesItemModel>("Query_Sales_ByItem_ByClient", param, commandType: CommandType.StoredProcedure).ToList();

                    Total = param.Get<double>("total");

                    if (Total > 0)
                    {
                        foreach (var item in model)
                        {
                            item.Percentage = Math.Round(item.LineValue / Total * 100, 0);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }


            return model;
        }

    }
}
