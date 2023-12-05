using System;

namespace Models
{
    public class BranchInvoiceingOrderListModel
    {
        public string SortDirection { get; set; }
        public string SortProperty { get; set; }
        public int? SortOrder { get; set; }
        public int? BranchId { get; set; }
        public int SortOrderId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
    }
}
