using System;

namespace Models
{
    public class ActivityTypeModel
    {
        public int ActivityTypeId { get; set; }
        public string ActivityTypeCode { get; set; }
        public string ActivityTypeNameEn { get; set; }
        public string ActivityTypeNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanEdit { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? CBy { get; set; }
        public int? EBy { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? EDate { get; set; }
    }
}
