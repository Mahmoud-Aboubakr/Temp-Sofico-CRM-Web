using System;

namespace Models
{
    public class TrackingTypeModel
    {
        public int TrackingTypeId { get; set; }
        public string TrackingTypeCode { get; set; }
        public string TrackingTypeNameEn { get; set; }
        public string TrackingTypeNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? DisplayOrder { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
