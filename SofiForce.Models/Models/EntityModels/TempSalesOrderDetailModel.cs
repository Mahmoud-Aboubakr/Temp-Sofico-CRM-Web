using System;

namespace Models
{
    public class TempSalesOrderDetailModel
    {
        public string VendorCode { get; set; }
        public string ItemCode { get; set; }
        public string InvoiceId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public int? Quantity { get; set; }
        public int? bonus { get; set; }
        public decimal? LineValue { get; set; }
        public decimal? ItemDiscount { get; set; }
    }
}
