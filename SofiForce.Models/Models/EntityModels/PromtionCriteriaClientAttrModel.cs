using System;

namespace Models
{
    public class PromtionCriteriaClientAttrModel
    {
        public int ClientAttributeId { get; set; }
        public string ClientAttributeCode { get; set; }
        public string ClientAttributeNameAr { get; set; }
        public string ClientAttributeNameEn { get; set; }
        public string ClientAttributeDesc { get; set; }
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
