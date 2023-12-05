using System;

namespace Models
{
    public class ActivityDirectionModel
    {
        public int ActivityDirectionId { get; set; }
        public string ActivityDirectionCode { get; set; }
        public string ActivityDirectionNameEn { get; set; }
        public string ActivityDirectionNameAr { get; set; }
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
