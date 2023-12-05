using SofiForce.Models.StatisticalModels;

namespace SofiForce.Models.StatisticalModels
{
    public class DashboardSalesModel
    {

        public DashboardKBI KbiModel { get; set; } = new DashboardKBI();


        public List<DashboardTimelineModel> Timelines { get; set; }=new List<DashboardTimelineModel>();

        public DashboardPerfromanceModel PerfromanceModel { get; set; }=new DashboardPerfromanceModel();

        public DashboardOrderKBIModel OrderKBIModel { get; set; } = new DashboardOrderKBIModel();

        public List<DashboardChannelModel> Channels { get; set; } = new List<DashboardChannelModel>();
        public List<TimelineModel> Hours { get; set; } = new List<TimelineModel>();


        public List<DashboardSalesItemModel> ItemSales { get; set; } = new List<DashboardSalesItemModel>();
        public List<DashboardSalesVendorModel> VendorSales { get; set; } = new List<DashboardSalesVendorModel>();
        public List<DashboardSalesVendorModel> VendorHotSales { get; set; } = new List<DashboardSalesVendorModel>();


    }


    public class DashboardKBI
    {
        public int Branchs { get; set; }
        public int Clients { get; set; }
        public int Distributors { get; set; }
        public int Representatives { get; set; }
        public int Items { get; set; }
        public int Vendors { get; set; }
        public int AllBranchs { get; set; }
        public int AllClients { get; set; }
        public int AllRepresentative { get; set; }
        public int AllDistributors { get; set; }
        public int AllItems { get; set; }
        public int AllVendors { get; set; }



        public double BranchPercentage { get; set; }
        public double ClientPercentage { get; set; }
        public double DistributorPercentage { get; set; }
        public double RepresentativePercentage { get; set; }
        public double ItemPercentage { get; set; }
        public double VendorPercentage { get; set; }

    }
    public class DashboardTimelineModel
    {
        public int LineLabel { get; set; }
        public double LineValue { get; set; }

        public double LineTarget { get; set; }


    }

    public class DashboardPerfromanceModel
    {
        public string Label { get; set; }
        public double Percentage { get; set; }
        public double Sales { get; set; }
        public double Target { get; set; }

        

    }

    public class DashboardChannelModel
    {
        public string Label { get; set; }
        public double Percentage { get; set; }
        public double Sales { get; set; }

        public string Color { get; set; }
    }

    public class DashboardSalesItemModel
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double LineValue { get; set; }
        public double Percentage { get; set; }

    }

    public class DashboardSalesVendorModel
    {
        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public double LineValue { get; set; }
        public double Percentage { get; set; }

    }

    public class DashboardOrderKBIModel
    {
        public long AllOrder { get; set; }
        public long Opened { get; set; }
        public long Confirmed { get; set; }
        public long Invoiced { get; set; }
        public long Rejected { get; set; }
        public long Printed { get; set; }
        public long Dispatched { get; set; }
        public long Delivered { get; set; }

        public double OpenedPercentage { get; set; }
        public double ConfirmedPercentage { get; set; }
        public double InvoicedPercentage { get; set; }
        public double RejectedPercentage { get; set; }
        public double PrintedPercentage { get; set; }
        public double DispatchedPercentage { get; set; }
        public double DeliveredPercentage { get; set; }

    }


}
