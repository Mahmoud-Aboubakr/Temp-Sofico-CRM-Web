using System;

namespace Models
{
    public class SupervisorModel
    {
        public int SupervisorId { get; set; }
        public int? SupervisorTypeId { get; set; }
        public int? BusinessUnitId { get; set; }
        public string CompanyCode { get; set; }
        public string SupervisorCode { get; set; }
        public string SupervisorNameEn { get; set; }
        public string SupervisorNameAr { get; set; }
        public string Phone { get; set; }
        public string PhoneAlternative { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? UserId { get; set; }
        public int? BranchId { get; set; }
        public bool? IsActive { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public string Icon { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Notes { get; set; }
        public bool? IsTerminated { get; set; }
        public DateTime? TerminationDate { get; set; }
        public int? TerminationReasonId { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
