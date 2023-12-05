using System;

namespace Models
{
    public class PromotionOutcomeModel
    {
        public int OutcomeId { get; set; }
        public int? PromotionId { get; set; }
        public bool? IsActive { get; set; }
        public int? Count { get; set; }
        public int? DisplayOrder { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public decimal? Slice { get; set; }
        public decimal? Value { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
