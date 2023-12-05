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
    public class SalesManager : ISalesManager
    {

        private readonly DapperContext _context;
        public SalesManager(DapperContext context)
        {
            _context = context;
        }



        public DashboardKBI getKBI(DateTime from, DateTime to, string BranchId, string ChannelId)
        {
            DashboardKBI model = new DashboardKBI();

            try
            {
                using (var connection = _context.CreateConnection())
                {


                    // get target kbi
                    var param = new
                    {
                        @from = from,
                        @to = to,
                        @BranchId = BranchId,
                        @ChannelId=ChannelId

                    };

                    model = connection.Query<DashboardKBI>("Query_Sales_ByKBI", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (model != null)
                    {
                        if (model.AllBranchs > 0)
                        {
                            model.BranchPercentage = (double)Math.Round((decimal)model.Branchs / (decimal)model.AllBranchs * 100, 0);
                        }

                        if (model.AllClients > 0)
                        {
                            model.ClientPercentage = (double)Math.Round((decimal)model.Clients / (decimal)model.AllClients * 100, 0) ;
                        }

                        if (model.AllDistributors > 0)
                        {
                            model.DistributorPercentage = (double)Math.Round((decimal)model.Distributors / (decimal)model.AllDistributors * 100, 0);
                        }

                        if (model.AllItems > 0)
                        {
                            model.ItemPercentage = (double)Math.Round((decimal)model.Items / (decimal)model.AllItems * 100, 0);
                        }

                        if (model.AllRepresentative > 0)
                        {
                            model.RepresentativePercentage = (double)Math.Round((decimal)model.Representatives / (decimal)model.AllRepresentative * 100, 0);
                        }

                        if (model.AllVendors > 0)
                        {
                            model.VendorPercentage = (double)Math.Round((decimal)model.Vendors / (decimal)model.AllVendors * 100, 0);
                        }
                    }


                }
            }
            catch (Exception ex)
            {

            }


            return model;
        }

        public DashboardOrderKBIModel getOrderKBI(DateTime from, DateTime to, string BranchId, string ChannelId,string KBIMode)
        {
            DashboardOrderKBIModel model = new DashboardOrderKBIModel();

            try
            {
                using (var connection = _context.CreateConnection())
                {


                    // get target kbi
                    var param = new
                    {
                        @from = from,
                        @to = to,
                        @BranchId = BranchId,
                        @ChannelId = ChannelId
                    };

                    model = connection.Query<DashboardOrderKBIModel>(KBIMode=="O" ? "Query_Sales_ByStatus": "Query_Sales_ByStatus_ByValue", param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (model != null)
                    {
                        if (model.AllOrder > 0)
                        {
                            model.OpenedPercentage =(double) Math.Round((decimal)model.Opened / (decimal)model.AllOrder * 100, 0);
                            model.ConfirmedPercentage = (double)Math.Round((decimal)model.Confirmed / (decimal)model.AllOrder * 100, 0);
                            model.InvoicedPercentage = (double)Math.Round((decimal)model.Invoiced / (decimal)model.AllOrder * 100, 0);
                            model.RejectedPercentage = (double)Math.Round((decimal)model.Rejected / (decimal)model.AllOrder * 100, 0);
                            model.PrintedPercentage = (double)Math.Round((decimal)model.Printed / (decimal)model.AllOrder * 100, 0);
                            model.DispatchedPercentage = (double)Math.Round((decimal)model.Dispatched / (decimal)model.AllOrder * 100, 0);
                            model.DeliveredPercentage = (double)Math.Round((decimal)model.Delivered / (decimal)model.AllOrder * 100, 0);

                        }
                    }
                   

                }
            }
            catch (Exception ex)
            {

            }


            return model;
        }

        public DashboardPerfromanceModel getPerformance(DateTime from, DateTime to, string BranchId, string ChannelId, int? ClientId)
        {
            DashboardPerfromanceModel model = new DashboardPerfromanceModel();





            try
            {
                using (var connection = _context.CreateConnection())
                {


                    // get target kbi
                    var param = new
                    {
                        @from = from,
                        @to = to,
                        @BranchId = BranchId,
                        @ChannelId = ChannelId,
                        @ClientId = ClientId > 0 ? ClientId : null,

                    };

                    var res = connection.Query<DashboardTimelineModel>("Query_Sales_Performance", param, commandType: CommandType.StoredProcedure).ToList().FirstOrDefault();

                    if (res!=null)
                    {

                        model.Sales = Math.Round(res.LineValue,0);

                        if (res.LineTarget > 0)
                        {
                            if (from.Month == to.Month)
                            {
                                res.LineTarget = res.LineTarget ;
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

        public List<TimelineModel> getSalesByHour(DateTime from, DateTime to, string BranchId, string ChannelId)
        {
            List<TimelineModel> model = new List<TimelineModel>();

            try
            {
                using (var connection = _context.CreateConnection())
                {


                    // get target kbi
                    var param = new
                    {
                        @from = from,
                        @to = to,
                        @BranchId = BranchId,
                        @ChannelId = ChannelId

                    };

                    model = connection.Query<TimelineModel>("Query_Sales_ByOrderTime", param, commandType: CommandType.StoredProcedure).ToList();

                    

                }
            }
            catch (Exception ex)
            {

            }


            return model;
        }

        public List<DashboardChannelModel> getSalesChannel(DateTime from, DateTime to, string BranchId, string ChannelId, string lan)
        {

            List<DashboardChannelModel> model = new List<DashboardChannelModel>();

            try
            {
                using (var connection = _context.CreateConnection())
                {


                    // get target kbi
                    var param = new
                    {
                        @from = from,
                        @to = to,
                        @BranchId = BranchId,
                        @ChannelId = ChannelId,
                        @lan = lan

                    };

                    model = connection.Query<DashboardChannelModel>("Query_Sales_ByChannel", param, commandType: CommandType.StoredProcedure).ToList();

                    if(model.Count > 0)
                    {
                        var SalesAll = model.Sum(a => a.Sales);
                        if (SalesAll > 0)
                        {
                            foreach (var item in model)
                            {
                                item.Percentage = Math.Round(item.Sales / SalesAll * 100, 0);
                                item.Sales = Math.Round(item.Sales, 0);
                                item.Label = string.Format("{0} ({1}%)", item.Label, item.Percentage);
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {

            }


            return model.OrderByDescending(a=>a.Sales).ToList();
        }

        public List<DashboardTimelineModel> getSalesTimeline(DateTime from, DateTime to, string TimelineMode, string BranchId, string ChannelId, int? ClientId)
        {
            List<DashboardTimelineModel> model = new List<DashboardTimelineModel>();


            if (TimelineMode == "D")
            {
                from = from.FirstDayOfMonth();
                to= to.LastDayOfMonth();
            }
            else
            {
                from = from.FirstDayOfYear();
                to = to.LastDayOfYear();
            }


            try
            {
                using (var connection = _context.CreateConnection())
                {


                    // get target kbi
                    var param = new
                    {
                        @from = from,
                        @to = to,
                        @TimelineMode = TimelineMode,
                        @BranchId = BranchId,
                        @ChannelId = ChannelId,
                        @ClientId = ClientId>0?ClientId:null,

                    };

                    model = connection.Query<DashboardTimelineModel>("Query_Sales_Timeline", param, commandType: CommandType.StoredProcedure).ToList();


                    int maxLabel = model.Max(a => a.LineLabel);
                    if (TimelineMode == "M")
                    {
                        for (int i = maxLabel + 1; i <= 12; i++)
                        {
                            model.Add(new DashboardTimelineModel() { LineLabel = i, LineValue = 0, LineTarget = 0 });
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }


            return model;

        }

        public List<DashboardSalesVendorModel> getVendorHotSales(DateTime from, DateTime to, string BranchId, string ChannelId, string lan)
        {
            List<DashboardSalesVendorModel> model = new List<DashboardSalesVendorModel>();

            double Total = 0;
            try
            {
                using (var connection = _context.CreateConnection())
                {


                    

                    var param = new DynamicParameters();
                    param.Add("from", from);
                    param.Add("to", to);
                    param.Add("BranchId", BranchId);
                    param.Add("ChannelId", ChannelId);
                    param.Add("lan", lan);

                    param.Add("total", dbType: DbType.Double, direction: ParameterDirection.Output);


                    model = connection.Query<DashboardSalesVendorModel>("Query_Sales_ByVendor_Hot", param, commandType: CommandType.StoredProcedure).ToList();

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

        public List<DashboardSalesVendorModel> getVendorSales(DateTime from, DateTime to, string BranchId, string ChannelId, string lan)
        {
            List<DashboardSalesVendorModel> model = new List<DashboardSalesVendorModel>();

            double Total = 0;
            try
            {
                using (var connection = _context.CreateConnection())
                {


                    var param = new DynamicParameters();
                    param.Add("from", from);
                    param.Add("to", to);
                    param.Add("BranchId", BranchId);
                    param.Add("lan", lan);
                    param.Add("ChannelId", ChannelId);
                    param.Add("total", dbType: DbType.Double, direction: ParameterDirection.Output);


                    model = connection.Query<DashboardSalesVendorModel>("Query_Sales_ByVendor", param, commandType: CommandType.StoredProcedure).ToList();

                    Total= param.Get<double>("total");

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

        public List<DashboardSalesItemModel> getItemSales(DateTime from, DateTime to, string BranchId, string ChannelId, string lan)
        {
            List<DashboardSalesItemModel> model = new List<DashboardSalesItemModel>();

            double Total = 0;
            try
            {
                using (var connection = _context.CreateConnection())
                {



                    var param = new DynamicParameters();
                    param.Add("from", from);
                    param.Add("to", to);
                    param.Add("BranchId", BranchId);
                    param.Add("ChannelId", ChannelId);
                    param.Add("lan", lan);

                    param.Add("total", dbType: DbType.Double, direction: ParameterDirection.Output);


                    model = connection.Query<DashboardSalesItemModel>("Query_Sales_ByItem", param, commandType: CommandType.StoredProcedure).ToList();

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
