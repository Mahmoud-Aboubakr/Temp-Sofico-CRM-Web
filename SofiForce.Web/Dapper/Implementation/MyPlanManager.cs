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

namespace SofiForce.Web.Dapper.Implementation
{
    public class MyPlanManager : IMyPlanManager
    {

        private readonly DapperContext _context;
        public MyPlanManager(DapperContext context)
        {
            _context = context;
        }

        public MyPlanModel getMyPlan(int RepresentativeId, string lan, int? ClientId, DateTime from, DateTime to)
        {
            MyPlanModel model = new MyPlanModel();

            int MonthDays = from.FirstDayOfMonth().BusinessDaysUntil(from.LastDayOfMonth());
            int workDays = from.BusinessDaysUntil(to);

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new
                    {
                        @lan = lan,
                        @RepresentativeId = RepresentativeId,
                        @ClientId = ClientId > 0 ? ClientId : null,
                        @from = from,
                        @to = to,
                    };

                    model.SalesControlDetails = connection.Query<MyPlanDetailModel>("Query_MyPlan_Client_KBI", param, commandType: CommandType.StoredProcedure);

                    if (model.SalesControlDetails != null && model.SalesControlDetails.Count() > 0)
                    {

                        model.ClientCoverage = model.SalesControlDetails.Sum(a => a.ClientCoverage);
                        model.ClientAll = model.SalesControlDetails.Sum(a => a.ClientAll);
                        model.Orders = model.SalesControlDetails.Sum(a => a.Orders);

                        model.SalesDays = workDays;

                        model.SalesValue = model.SalesControlDetails.Sum(a => a.SalesValue);
                        model.TargetValue = model.SalesControlDetails.Sum(a => a.TargetValue) / MonthDays * workDays;

                        if (model.TargetValue > 0)
                            model.SalesPercentage = Math.Round((decimal)model.SalesValue / (decimal)model.TargetValue * 100, 0);

                        model.VisitAll = model.SalesControlDetails.Sum(a => a.VisitAll);
                        model.TargetVisit = model.SalesControlDetails.Sum(a => a.TargetVisit) / MonthDays * workDays;
                        model.VisitPostitive = model.SalesControlDetails.Sum(a => a.VisitPostitive);
                        model.VisitNegative = model.SalesControlDetails.Sum(a => a.VisitNegative);


                        if (model.TargetVisit > 0)
                            model.VisitPercentage = Math.Round((decimal)model.VisitAll / (decimal)model.TargetVisit * 100, 0);


                        model.callAll = model.SalesControlDetails.Sum(a => a.callAll);
                        model.TargetCall = model.SalesControlDetails.Sum(a => a.TargetCall) / MonthDays * workDays;
                        model.CallNegative = model.SalesControlDetails.Sum(a => a.CallNegative) / MonthDays * workDays;
                        model.CallPostitive = model.SalesControlDetails.Sum(a => a.CallPostitive) / MonthDays * workDays;


                        if (model.TargetCall > 0)
                            model.CallPercentage = Math.Round((decimal)model.callAll / (decimal)model.TargetCall * 100, 0);

                        model.PerormancePercentage = Math.Round(model.SalesPercentage * 100 / 100 + model.CallPercentage * 0 / 100 + model.VisitPercentage * 0 / 100, 0);
                        model.PerormanceLabel = getPerformanceLabel(model.PerormancePercentage);

                        //model.PerormancePercentage = 30;
                        foreach (var item in model.SalesControlDetails)
                        {


                            item.TargetValue = item.TargetValue / MonthDays * workDays;
                            item.TargetVisit = item.TargetVisit / MonthDays * workDays;
                            item.TargetCall = item.TargetCall / MonthDays * workDays;

                            if (item.TargetValue > 0)
                                item.SalesPercentage = Math.Round((decimal)item.SalesValue / (decimal)item.TargetValue * 100, 0);

                            if (item.TargetVisit > 0)
                                item.VisitPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetVisit * 100, 0);

                            if (item.TargetCall > 0)
                                item.CallPercentage = Math.Round((decimal)item.VisitAll / (decimal)item.TargetCall * 100, 0);

                            item.PerormancePercentage = Math.Round(item.SalesPercentage * 100 / 100 + item.CallPercentage * 0 / 100 + item.VisitPercentage * 0 / 100, 0);
                            item.PerormanceLabel = getPerformanceLabel(item.PerormancePercentage);

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

        string getPerformanceLabel(decimal percentage)
        {
            string label = "Low";

            if (percentage >= 0 && percentage < 60)
                label = "Low";
            if (percentage >= 60 && percentage < 70)
                label = "Medium";
            if (percentage >= 80 && percentage < 90)
                label = "Normal";
            if (percentage >= 90 && percentage < 100)
                label = "High";
            if (percentage > 100)
                label = "Premium";

            return label;

        }
    }
}
