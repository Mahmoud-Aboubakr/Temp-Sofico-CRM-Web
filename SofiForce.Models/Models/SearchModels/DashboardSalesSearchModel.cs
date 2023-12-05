using System;
using System.Collections.Generic;

namespace Models
{

    public class DashboardSearchModel 
    {

        public List<int> Branchs { get; set; }
        public List<int> Channels { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int TimePeriod { get; set; }
        public string LineChartMode { get; set; }
        public string orderKBIMode { get; set; }
        public int VendorId { get; set; }
        public int ItemId { get; set; }
        public int RepresentativeId { get; set; }
        public int ClientId { get; set; }
        public int SupervisorId { get; set; }


    }

    public class DashboardSalesSearchModel : BaseSearchModel
    {

        public KbiSearchModel KbiSearchModel { get; set; }

        public PerfromanceSearchModel PerfromanceSearchModel { get; set; }

        public TimeLineSearchModel TimeLineSearchModel { get; set; }
        public OrderKBISearchModel OrderKBISearchModel { get; set; }
        public SalesChannelSearchModel SalesChannelSearchModel { get; set; }
        public SalesHourSearchModel SalesHourSearchModel { get; set; }

        public SalesVendorSearchModel SalesVendorSearchModel { get; set; }
        public SalesItemSearchModel SalesItemSearchModel { get; set; }
        public SalesVendorSearchModel SalesHotSearchModel { get; set; }


    }

    public class TimeLineSearchModel
    {
        public  string Mode { get; set; } = "M";
        public  int BranchId { get; set; }

    }

    public class KbiSearchModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public int BranchId { get; set; }

    }

    public class PerfromanceSearchModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public int BranchId { get; set; }

    }

    public class OrderKBISearchModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public int BranchId { get; set; }

    }

    public class SalesChannelSearchModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public int BranchId { get; set; }

    }

    public class SalesHourSearchModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public int BranchId { get; set; }

    }

    public class SalesVendorSearchModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public int BranchId { get; set; }

    }

    public class SalesItemSearchModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public int BranchId { get; set; }

    }
    public class SalesHotSearchModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public int BranchId { get; set; }

    }
}