using System;

namespace Models
{
    public class SalesOrderDetailModel
    {
        public long DetailId { get; set; }
        public long? SalesId { get; set; }
        public int? ItemId { get; set; }
        public decimal? PublicPrice { get; set; }
        public decimal? ClientPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? LineValue { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TaxValue { get; set; }
        public bool? IsBouns { get; set; }
        public string PromotionCode { get; set; }
        public int? ItemStoreId { get; set; }
        public long? RecId { get; set; }
    }
}
