using System;

namespace Models
{
    public class PromotionMixGroupModel
    {
        public int GroupId { get; set; }
        public int? GroupNo { get; set; }

        public int? PromotionId { get; set; }
        public decimal? Slice { get; set; }
        public bool? IsActive { get; set; }

        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
