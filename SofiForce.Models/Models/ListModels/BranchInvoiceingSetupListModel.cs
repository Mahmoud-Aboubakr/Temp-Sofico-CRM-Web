using System;

namespace Models
{
    public class BranchInvoiceingSetupListModel
    {
        public int? ServiceWorkerId { get; set; }
        public bool? IsEnabled { get; set; }
        public int? BranchId { get; set; }
        public int SetupId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string ServiceWorkerCode { get; set; }
        public string ServiceWorkerName { get; set; }

    }
}
