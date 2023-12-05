using System;

namespace Models
{
    public class PromtionCriteriaSalesManAttrModel
    {
        public int SalesManAttributeId { get; set; }
        public string SalesManAttributeCode { get; set; }
        public string SalesManAttributeNameAr { get; set; }
        public string SalesManAttributeNameEn { get; set; }
        public string SalesManAttributeDesc { get; set; }
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
