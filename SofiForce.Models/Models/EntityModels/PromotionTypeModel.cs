using System;

namespace Models
{
    public class PromotionTypeModel
    {
        public int PromotionTypeId { get; set; }
        public string PromotionTypeCode { get; set; }
        public string PromotionTypeNameAr { get; set; }
        public string PromotionTypeNameEn { get; set; }
        public string PromotionTypeDesc { get; set; }
        public int? PromotionInputId { get; set; }
        public string PromotionInputCode { get; set; }

        public int? PromotionOutputId { get; set; }
        public string PromotionOutputCode { get; set; }

        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? DisplayOrder { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
