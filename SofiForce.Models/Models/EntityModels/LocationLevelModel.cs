using System;

namespace Models
{
    public class LocationLevelModel
    {
        public int LocationLevelId { get; set; }
        public string LocationLevelCode { get; set; }
        public string LocationLevelNameEn { get; set; }
        public string LocationLevelNameAr { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? CBy { get; set; }
        public int? EBy { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? EDate { get; set; }
    }
}
