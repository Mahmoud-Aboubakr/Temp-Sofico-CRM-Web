using System;

namespace Models
{
    public class ApplicationFeatureModel
    {
        public int FeatueId { get; set; }
        public int? ApplicationId { get; set; }
        public string FeatueCode { get; set; }
        public string FeatueNameEn { get; set; }
        public string FeatueNameAr { get; set; }
        public string FeatuePath { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplyOrder { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsUpdated { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
