using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesOrderLinePromotionListModel
    {
        public Int64? LineId { get; set; }
        public Int64? SalesId { get; set; }
        public Int32? ItemId { get; set; }
        public Int32? PromotionId { get; set; }
        public decimal? Outcome { get; set; }
        public Int32? SalesOrderStatusId { get; set; }
        public string InvoiceCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public Int32? BranchId { get; set; }
        public Int32? ClientId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string PromotionCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public Int32? ItemStoreId { get; set; }
        public string BatchNo { get; set; }
        public bool? IsInvoiced { get; set; }
        public bool? IsDeleted { get; set; }

        public int? OutcomeType { get; set; }
        public string ItemCode { get; set; }
        public string VendorCode { get; set; }
        public int? VendorId { get; set; }
        public string VendorName { get; set; }
        public string ItemName { get; set; }

        public int? ItemGroupId { get; set; }
    }
}
