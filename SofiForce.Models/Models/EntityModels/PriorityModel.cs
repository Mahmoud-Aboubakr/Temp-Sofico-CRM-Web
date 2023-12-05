using System;

namespace Models
{
    public class PriorityModel
    {
        public int PriorityId { get; set; }
        public string PriorityCode { get; set; }
        public string PriorityNameAr { get; set; }
        public string PriorityNameEn { get; set; }
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
