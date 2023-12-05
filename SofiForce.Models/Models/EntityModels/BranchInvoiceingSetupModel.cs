using System;

namespace Models
{
    public class BranchInvoiceingSetupModel
    {
        public int SetupId { get; set; }
        public int? BranchId { get; set; }
        public bool? IsEnabled { get; set; }
        public int? ServiceWorkerId { get; set; }
    }
}
