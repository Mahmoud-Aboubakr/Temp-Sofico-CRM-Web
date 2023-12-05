using System;

namespace Models
{
    public class PromotionGroupModel
    {
        public int PromotionGroupId { get; set; }
        public string PromotionGroupCode { get; set; }
        public string PromotionGroupNameEn { get; set; }
        public string PromotionGroupNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? DisplayOrder { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
