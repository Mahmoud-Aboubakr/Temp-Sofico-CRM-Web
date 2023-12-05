using Models;
using System;
using System.Collections.Generic;

namespace SofiForce.Models.StatisticalModels
{
    public class ClientStatisticalModel
    {

        public List<DashboardClientTimelineModel> Timelines { get; set; } = new List<DashboardClientTimelineModel>();

        public DashboardClientPerfromanceModel PerfromanceModel { get; set; } = new DashboardClientPerfromanceModel();
        public ClientListModel ClientModel { get; set; } = new ClientListModel();


        public List<SalesOrderListModel> Orders { get; set; } = new List<SalesOrderListModel>();
        public List<ClientActivityListModel> Visits { get; set; } = new List<ClientActivityListModel>();
        public List<ClientActivityListModel> Calls { get; set; } = new List<ClientActivityListModel>();
        public List<ClientComplainListModel> Complains { get; set; } = new List<ClientComplainListModel>();
        public List<ClientServiceRequestListModel> Requests { get; set; } = new List<ClientServiceRequestListModel>();
        public List<ClientSurveyListModel> Survies { get; set; } = new List<ClientSurveyListModel>();

        public List<DashboardClientSalesVendorModel> Vendors { get; set; } = new List<DashboardClientSalesVendorModel>();
        public List<DashboardClientSalesItemModel> Items { get; set; } = new List<DashboardClientSalesItemModel>();


    }

    public class DashboardClientTimelineModel
    {
        public int LineLabel { get; set; }
        public double LineValue { get; set; }

        public double LineTarget { get; set; }


    }

    public class DashboardClientPerfromanceModel
    {
        public string Label { get; set; }
        public double Percentage { get; set; }
        public double Sales { get; set; }
        public double Target { get; set; }

    }

    public class DashboardClientSalesItemModel
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double LineValue { get; set; }
        public double Percentage { get; set; }

        public DateTime? LastInvoice { get; set; }
    }

    public class DashboardClientSalesVendorModel
    {
        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public double LineValue { get; set; }
        public double Percentage { get; set; }

        public DateTime? LastInvoice { get; set; }


    }
}
