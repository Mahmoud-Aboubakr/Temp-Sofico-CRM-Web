using System;

namespace Models
{
    public class PromotionInputModel
    {
        public int PromotionInputId { get; set; }
        public string PromotionInputCode { get; set; }
        public string PromotionInputNameEn { get; set; }
        public string PromotionInputNameAr { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
