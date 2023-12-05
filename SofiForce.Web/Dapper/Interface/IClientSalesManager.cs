using Models;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface IClientSalesManager
    {
        List<DashboardClientTimelineModel> getSalesTimeline(DateTime from,DateTime to ,int? ClientId);
        DashboardClientPerfromanceModel getPerformance(DateTime from, DateTime to, int? ClientId);

        List<DashboardClientSalesVendorModel> getVendorSales(DateTime from, DateTime to, int ClientId, string lan);
        List<DashboardClientSalesItemModel> getItemSales(DateTime from, DateTime to, int ClientId, string lan);

    }
}
