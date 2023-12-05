using System;

namespace Models
{
    public class SalesErrorModel
    {
        public int SalesErrorId { get; set; }
        public string SalesErrorCode { get; set; }
        public string SalesErrorNameEn { get; set; }
        public string SalesErrorNameAr { get; set; }
        public string SalesErrorTemplateAr { get; set; }
        public string SalesErrorTemplateEn { get; set; }
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
