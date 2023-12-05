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
    public class SalesControlManager : ISalesControlManager
    {

        private readonly DapperContext _context;
        public SalesControlManager(DapperContext context)
        {
            _context = context;
        }
        public SalesBranchControlModel getBranch(string lan, string BranchId, DateTime from, DateTime to)
        {
            SalesBranchControlModel model =new SalesBranchControlModel();

   

            try
            {
                using (var connection = _context.CreateConnection())
                {


                    // get target kbi
                    var paramTarget = new
                    {
                        @from = from,
                        @to = to,
                        @BranchId = BranchId,

                    };
                    


                    // get details

                    var param = new 
                    {
                        @lan = lan,
                        @branchId = BranchId,
                        @from = from,
                        @to = to,
                    };

                    var Totals = connection.Query<SalesBranchControlDetailModel>("Query_SalesControl_Branch_Total_KBI", param, commandType: CommandType.StoredProcedure).ToList();

                    if (Totals.Count>0)
                    {
                        model.SalesDate = Totals[0].SalesDate;
                        model.ClientAll = Totals[0].ClientAll;
                        model.ClientCoverage = Totals[0].ClientCoverage;
                        model.Orders = Totals[0].Orders;
                        model.SalesDays = Totals[0].SalesDays;
                        model.SalesValue = Totals[0].SalesValue;
                        model.TargetValue = Totals[0].TargetValue;
                        model.TargetCall = Totals[0].TargetCall;
                        model.callAll = Totals[0].callAll;
                        model.CallNegative = Totals[0].CallNegative;
                        model.CallPostitive = Totals[0].CallPostitive;
                        model.TargetVisit = Totals[0].TargetVisit;
                        model.VisitAll = Totals[0].VisitAll;
                        model.VisitNegative = Totals[0].VisitNegative;
                        model.VisitPostitive = Totals[0].VisitPostitive;

                        if (model.TargetValue > 0)
                            model.SalesPercentage = Math.Round((decimal)model.SalesValue / (decimal)model.TargetValue * 100, 0);

                        if (model.TargetVisit > 0)
                            model.VisitPercentage = Math.Round((decimal)model.VisitAll / (decimal)model.TargetVisit * 100, 0);

                        if (model.TargetCall > 0)
                            model.CallPercentage = Math.Round((decimal)model.VisitAll / (decimal)model.TargetCall * 100, 0);

                        model.PerormancePercentage = Math.Round(model.SalesPercentage * 100 / 100 + model.CallPercentage * 0 / 100 + model.VisitPercentage * 0 / 100, 0);
                        model.PerormanceLabel = Utils.getPerformanceLabel(model.PerormancePercentage);

                    }

                    model.SalesControlDetails = connection.Query<SalesBranchControlDetailModel>("Query_SalesControl_Branch_KBI", param, commandType: CommandType.StoredProcedure);

                    foreach (var item in model.SalesControlDetails)
                    {


                        item.TargetValue = item.TargetValue ;
                        item.TargetVisit = item.TargetVisit ;
                        item.TargetCall = item.TargetCall;

                        if (item.TargetValue > 0)
                            item.SalesPercentage = Math.Round((decimal)item.SalesValue / (decimal)item.TargetValue * 100, 0);

                        if (item.TargetVisit > 0)
                            item.VisitPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetVisit * 100, 0);

                        if (item.TargetCall > 0)
                            item.CallPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetCall * 100, 0);

                        item.PerormancePercentage = Math.Round(item.SalesPercentage * 100 / 100 + item.CallPercentage * 0 / 100 + item.VisitPercentage * 0 / 100, 0);
                        item.PerormanceLabel = Utils.getPerformanceLabel(item.PerormancePercentage);

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return model;
        }

        public SalesSupervisorControlModel getSupervisor(string lan, string BranchId, int? SupervisorId, DateTime from, DateTime to)
        {
            SalesSupervisorControlModel model = new SalesSupervisorControlModel();



            try
            {
                using (var connection = _context.CreateConnection())
                {



                    // get details

                    var paramAll = new
                    {
                        @lan = lan,
                        @branchId = BranchId,
                        @from = from,
                        @to = to,
                    };

                    var Totals = connection.Query<SalesBranchControlDetailModel>("Query_SalesControl_Branch_Total_KBI", paramAll, commandType: CommandType.StoredProcedure).ToList();

                    if (Totals.Count > 0)
                    {
                        model.SalesDate = Totals[0].SalesDate;
                        model.ClientAll = Totals[0].ClientAll;
                        model.ClientCoverage = Totals[0].ClientCoverage;
                        model.Orders = Totals[0].Orders;
                        model.SalesDays = Totals[0].SalesDays;
                        model.SalesValue = Totals[0].SalesValue;
                        model.TargetValue = Totals[0].TargetValue;
                        model.TargetCall = Totals[0].TargetCall;
                        model.callAll = Totals[0].callAll;
                        model.CallNegative = Totals[0].CallNegative;
                        model.CallPostitive = Totals[0].CallPostitive;
                        model.TargetVisit = Totals[0].TargetVisit;
                        model.VisitAll = Totals[0].VisitAll;
                        model.VisitNegative = Totals[0].VisitNegative;
                        model.VisitPostitive = Totals[0].VisitPostitive;

                        if (model.TargetValue > 0)
                            model.SalesPercentage = Math.Round((decimal)model.SalesValue / (decimal)model.TargetValue * 100, 0);

                        if (model.TargetVisit > 0)
                            model.VisitPercentage = Math.Round((decimal)model.VisitAll / (decimal)model.TargetVisit * 100, 0);

                        if (model.TargetCall > 0)
                            model.CallPercentage = Math.Round((decimal)model.VisitAll / (decimal)model.TargetCall * 100, 0);

                        model.PerormancePercentage = Math.Round(model.SalesPercentage * 100 / 100 + model.CallPercentage * 0 / 100 + model.VisitPercentage * 0 / 100, 0);
                        model.PerormanceLabel = Utils.getPerformanceLabel(model.PerormancePercentage);

                    }



                    var param = new
                    {
                        @lan = lan,
                        @branchId = BranchId,
                        @from = from,
                        @to = to,
                        @SupervisorId = SupervisorId > 0 ? SupervisorId : null,

                    };

                    model.SalesControlDetails = connection.Query<SalesSupervisorControlDetailModel>("Query_SalesControl_Supervisor_KBI", param, commandType: CommandType.StoredProcedure);



                    foreach (var item in model.SalesControlDetails)
                    {


                        item.TargetValue = item.TargetValue ;
                        item.TargetVisit = item.TargetVisit ;
                        item.TargetCall = item.TargetCall ;

                        if (item.TargetValue > 0)
                            item.SalesPercentage = Math.Round((decimal)item.SalesValue / (decimal)item.TargetValue * 100, 0);

                        if (item.TargetVisit > 0)
                            item.VisitPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetVisit * 100, 0);

                        if (item.TargetCall > 0)
                            item.CallPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetCall * 100, 0);

                        item.PerormancePercentage = Math.Round(item.SalesPercentage * 100 / 100 + item.CallPercentage * 0 / 100 + item.VisitPercentage * 0 / 100, 0);
                        item.PerormanceLabel = Utils.getPerformanceLabel(item.PerormancePercentage);

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return model;
        }

        public SalesRepresentativeControlModel getRepresentative(string lan, string BranchId, int? SupervisorId, int? RepresentativeId, DateTime from, DateTime to)
        {
            SalesRepresentativeControlModel model = new SalesRepresentativeControlModel();


            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var paramAll = new
                    {
                        @lan = lan,
                        @branchId = BranchId,
                        @from = from,
                        @to = to,
                        @SupervisorId = SupervisorId,

                    };

                    var Totals = connection.Query<SalesSupervisorControlDetailModel>("Query_SalesControl_Supervisor_KBI", paramAll, commandType: CommandType.StoredProcedure).ToList();

                    if (Totals.Count > 0)
                    {
                        model.SalesDate = Totals[0].SalesDate;
                        model.ClientAll = Totals[0].ClientAll;
                        model.ClientCoverage = Totals[0].ClientCoverage;
                        model.Orders = Totals[0].Orders;
                        model.SalesDays = Totals[0].SalesDays;
                        model.SalesValue = Totals[0].SalesValue;
                        model.TargetValue = Totals[0].TargetValue;
                        model.TargetCall = Totals[0].TargetCall;
                        model.callAll = Totals[0].callAll;
                        model.CallNegative = Totals[0].CallNegative;
                        model.CallPostitive = Totals[0].CallPostitive;
                        model.TargetVisit = Totals[0].TargetVisit;
                        model.VisitAll = Totals[0].VisitAll;
                        model.VisitNegative = Totals[0].VisitNegative;
                        model.VisitPostitive = Totals[0].VisitPostitive;

                        if (model.TargetValue > 0)
                            model.SalesPercentage = Math.Round((decimal)model.SalesValue / (decimal)model.TargetValue * 100, 0);

                        if (model.TargetVisit > 0)
                            model.VisitPercentage = Math.Round((decimal)model.VisitAll / (decimal)model.TargetVisit * 100, 0);

                        if (model.TargetCall > 0)
                            model.CallPercentage = Math.Round((decimal)model.VisitAll / (decimal)model.TargetCall * 100, 0);

                        model.PerormancePercentage = Math.Round(model.SalesPercentage * 100 / 100 + model.CallPercentage * 0 / 100 + model.VisitPercentage * 0 / 100, 0);
                        model.PerormanceLabel = Utils.getPerformanceLabel(model.PerormancePercentage);

                    }


                    var param = new
                    {
                        @lan = lan,
                        @branchId = BranchId,
                        @from = from,
                        @to = to,
                        @SupervisorId = SupervisorId > 0 ? SupervisorId : null,
                        @RepresentativeId = RepresentativeId > 0 ? RepresentativeId : null,

                    };

                    model.SalesControlDetails = connection.Query<SalesRepresentativeControlDetailModel>("Query_SalesControl_Representative_KBI", param, commandType: CommandType.StoredProcedure);



                    foreach (var item in model.SalesControlDetails)
                    {


                        item.TargetValue = item.TargetValue ;
                        item.TargetVisit = item.TargetVisit ;
                        item.TargetCall = item.TargetCall;

                        if (item.TargetValue > 0)
                            item.SalesPercentage = Math.Round((decimal)item.SalesValue / (decimal)item.TargetValue * 100, 0);

                        if (item.TargetVisit > 0)
                            item.VisitPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetVisit * 100, 0);

                        if (item.TargetCall > 0)
                            item.CallPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetCall * 100, 0);

                        item.PerormancePercentage = Math.Round(item.SalesPercentage * 100 / 100 + item.CallPercentage * 0 / 100 + item.VisitPercentage * 0 / 100, 0);
                        item.PerormanceLabel = Utils.getPerformanceLabel(item.PerormancePercentage);

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return model;
        }


        public List<PerformanceSalesmanModel> getPerformanceSalesman(string lan, string BranchId, int? SupervisorId, int? RepresentativeId, DateTime from, DateTime to)
        {
            List<PerformanceSalesmanModel> model = new List<PerformanceSalesmanModel>();


            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var paramAll = new
                    {
                        @lan = lan,
                        @branchId = BranchId,
                        @from = from,
                        @to = to,
                        @SupervisorId = SupervisorId>0?SupervisorId:null,
                        @RepresentativeId = RepresentativeId>0?RepresentativeId:null,

                    };

                    model = connection.Query<PerformanceSalesmanModel>("Query_Performance_Salesman", paramAll, commandType: CommandType.StoredProcedure).ToList();

                    


                    foreach (var item in model)
                    {

                        if (item.TargetValue > 0)
                            item.SalesPercentage = Math.Round((decimal)item.RouteSales / (decimal)item.TargetValue * 100, 0);

                        if (item.TargetVisit > 0)
                            item.VisitPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetVisit * 100, 0);

                        if (item.TargetCall > 0)
                            item.CallPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetCall * 100, 0);

                        item.PerormancePercentage = Math.Round(item.SalesPercentage * 100 / 100 + item.CallPercentage * 0 / 100 + item.VisitPercentage * 0 / 100, 0);
                        item.PerormanceLabel = Utils.getPerformanceLabel(item.PerormancePercentage);

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return model;
        }

        public PerformanceClientModel getPerformanceClient(string lan, int? RepresentativeId, DateTime from, DateTime to)
        {
            PerformanceClientModel model = new PerformanceClientModel();


            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var paramAll = new
                    {
                        @lan = lan,
                        @from = from,
                        @to = to,
                        @RepresentativeId = RepresentativeId,

                    };

                    model.DetailModels = connection.Query<PerformanceClientDetailModel>("Query_Performance_Client", paramAll, commandType: CommandType.StoredProcedure).ToList();

                    if (model.DetailModels.Count > 0)
                    {
                        model.MySales = model.DetailModels.Sum(a => a.MySales);
                        model.MyOrders = model.DetailModels.Sum(a => a.MyOrders);
                        model.TargetValue = model.DetailModels.Sum(a => a.TargetValue);

                        model.callAll = model.DetailModels.Sum(a => a.callAll);
                        model.VisitAll = model.DetailModels.Sum(a => a.VisitAll);

                        model.CallPostitive = model.DetailModels.Sum(a => a.CallPostitive);
                        model.CallNegative = model.DetailModels.Sum(a => a.CallNegative);

                        model.VisitNegative = model.DetailModels.Sum(a => a.VisitNegative);
                        model.VisitPostitive = model.DetailModels.Sum(a => a.VisitPostitive);

                        model.TargetCall = model.DetailModels.Sum(a => a.TargetCall);
                        model.TargetVisit = model.DetailModels.Sum(a => a.TargetVisit);

                        model.ClientCoverage = model.DetailModels.Sum(a => a.ClientCoverage);
                        model.ClientAll = model.DetailModels.Count;



                        if (model.TargetValue > 0)
                            model.SalesPercentage = Math.Round((decimal)model.MySales / (decimal)model.TargetValue * 100, 0);

                        if (model.TargetVisit > 0)
                            model.VisitPercentage = Math.Round((decimal)model.VisitAll / (decimal)model.TargetVisit * 100, 0);

                        if (model.TargetCall > 0)
                            model.CallPercentage = Math.Round((decimal)model.VisitAll / (decimal)model.TargetCall * 100, 0);

                        model.PerormancePercentage = Math.Round(model.SalesPercentage * 100 / 100 + model.CallPercentage * 0 / 100 + model.VisitPercentage * 0 / 100, 0);
                        model.PerormanceLabel = Utils.getPerformanceLabel(model.PerormancePercentage);


                    }



                    foreach (var item in model.DetailModels)
                    {

                        if (item.TargetValue > 0)
                            item.SalesPercentage = Math.Round((decimal)item.MySales / (decimal)item.TargetValue * 100, 0);

                        if (item.TargetVisit > 0)
                            item.VisitPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetVisit * 100, 0);

                        if (item.TargetCall > 0)
                            item.CallPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetCall * 100, 0);

                        item.PerormancePercentage = Math.Round(item.SalesPercentage * 100 / 100 + item.CallPercentage * 0 / 100 + item.VisitPercentage * 0 / 100, 0);
                        item.PerormanceLabel = Utils.getPerformanceLabel(item.PerormancePercentage);

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
