using System;

namespace Models
{
    public class LandmarkModel
    {
        public int LandmarkId { get; set; }
        public string LandmarkCode { get; set; }
        public string LandmarkNameEn { get; set; }
        public string LandmarkNameAr { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool? IsActive { get; set; }
        public int? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? DisplayOrder { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
