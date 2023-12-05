using Models;
using SofiForce.Models.StatisticalModels;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface ISalesManager
    {

        DashboardKBI getKBI(DateTime from, DateTime to, string BranchId, string GroupId);

        List<DashboardTimelineModel> getSalesTimeline(DateTime from,DateTime to ,string TimelineMode,string BranchId, string GroupId, int? ClientId);
        DashboardPerfromanceModel getPerformance(DateTime from, DateTime to, string BranchId, string GroupId, int? ClientId);

        DashboardOrderKBIModel getOrderKBI(DateTime from, DateTime to, string BranchId, string GroupId,string KBIMode);

        List<DashboardChannelModel> getSalesChannel (DateTime from, DateTime to, string BranchId, string GroupId, string lan);

        List<TimelineModel> getSalesByHour(DateTime from, DateTime to, string BranchId, string GroupId);


        List<DashboardSalesVendorModel> getVendorSales(DateTime from, DateTime to, string BranchId, string GroupId, string lan);
        List<DashboardSalesVendorModel> getVendorHotSales(DateTime from, DateTime to, string BranchId, string GroupId, string lan);
        List<DashboardSalesItemModel> getItemSales(DateTime from, DateTime to, string BranchId, string GroupId, string lan);

    }
}
