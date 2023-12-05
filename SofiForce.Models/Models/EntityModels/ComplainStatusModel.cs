using System;

namespace Models
{
    public class ComplainStatusModel
    {
        public int ComplainStatusId { get; set; }
        public string ComplainStatusCode { get; set; }
        public string ComplainStatusNameAr { get; set; }
        public string ComplainStatusNameEn { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
