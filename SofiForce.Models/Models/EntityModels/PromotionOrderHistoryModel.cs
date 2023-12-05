using System;

namespace Models
{
    public class PromotionOrderHistoryModel
    {
        public int HistoryId { get; set; }
        public int? PromotionId { get; set; }
        public int? ClientId { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime? InvoiceDate { get; set; }
    }
}
