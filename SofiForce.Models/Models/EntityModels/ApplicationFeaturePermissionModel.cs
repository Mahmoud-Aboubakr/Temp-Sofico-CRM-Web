using System;

namespace Models
{
    public class ApplicationFeaturePermissionModel
    {
        public int FeaturePermissionId { get; set; }
        public int? FeatueId { get; set; }
        public string FeaturePermissionCode { get; set; }
        public string FeaturePermissionNameEn { get; set; }
        public string FeaturePermissionNameAr { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
