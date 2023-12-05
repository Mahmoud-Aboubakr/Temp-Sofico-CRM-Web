using System;

namespace Models
{
    public class PromotionCriteriaModel
    {
        public int CriteriaId { get; set; }
        public int? PromotionId { get; set; }


        public int? GroupId { get; set; }
        public int? GroupNo { get; set; }
        public double? Slice { get; set; }

        public int? AttributeId { get; set; }
        public string AttributeCode { get; set; }

        public string ValueFrom { get; set; }
        public bool? IsActive { get; set; }
        public bool? Excluded { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
