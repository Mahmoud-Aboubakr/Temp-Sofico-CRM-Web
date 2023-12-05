using System;

namespace Models
{
    public class TempSalesOrderModel
    {
        public string InvoiceCode { get; set; }
        public string BranchCode { get; set; }
        public string ClientCode { get; set; }
        public int? OrderTypeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public object OrderTime { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public object InvoiceTime { get; set; }
        public decimal? OrderValue { get; set; }
        public decimal? DiscountItem { get; set; }
        public decimal? DiscountOrder { get; set; }
        public decimal? Tax { get; set; }
        public string InvoiceId { get; set; }
        public string RepresentativeCode { get; set; }
    }
}
