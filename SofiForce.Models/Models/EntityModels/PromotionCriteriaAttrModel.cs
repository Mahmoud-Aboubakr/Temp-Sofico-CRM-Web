using System;

namespace Models
{
    public class PromotionCriteriaAttrModel
    {
        public int AttributeId { get; set; }
        public string AttributeCode { get; set; }
        public string AttributeNameAr { get; set; }
        public string AttributeNameEn { get; set; }
        public string AttributeNameDesc { get; set; }
        public bool? IsCustom { get; set; }
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
