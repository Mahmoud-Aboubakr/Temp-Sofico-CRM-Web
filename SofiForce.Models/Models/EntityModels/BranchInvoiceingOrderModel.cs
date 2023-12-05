using System;

namespace Models
{
    public class BranchInvoiceingOrderModel
    {
        public int SortOrderId { get; set; }
        public int? BranchId { get; set; }

        public int? SortOrder { get; set; }
        public string SortProperty { get; set; }
        public string SortDirection { get; set; }
    }
}
