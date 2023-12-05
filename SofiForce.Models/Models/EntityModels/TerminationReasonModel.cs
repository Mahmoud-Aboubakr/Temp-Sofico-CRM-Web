using System;

namespace Models
{
    public class TerminationReasonModel
    {
        public int TerminationReasonId { get; set; }
        public string TerminationReasonCode { get; set; }
        public string TerminationReasonNameEn { get; set; }
        public string TerminationReasonNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? DisplayOrder { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? CBy { get; set; }
        public int? EBy { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? EDate { get; set; }
    }
}
