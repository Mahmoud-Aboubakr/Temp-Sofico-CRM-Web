using System;

namespace Models
{
    public class ComplainTypeDetailModel
    {
        public int ComplainTypeDetailId { get; set; }
        public int? ComplainTypeId { get; set; }
        public string ComplainTypeDetailCode { get; set; }
        public string ComplainTypeDetailNameAr { get; set; }
        public string ComplainTypeDetailNameEn { get; set; }
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
