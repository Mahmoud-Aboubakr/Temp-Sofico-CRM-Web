using System;

namespace Models
{
    public class SupervisorTypeModel
    {
        public int SupervisorTypeId { get; set; }
        public string SupervisorTypeCode { get; set; }
        public string SupervisorTypeNameEn { get; set; }
        public string SupervisorTypeNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
