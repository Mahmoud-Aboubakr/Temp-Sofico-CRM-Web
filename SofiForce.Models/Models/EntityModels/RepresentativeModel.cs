using System;

namespace Models
{
    public class RepresentativeModel
    {
        public int RepresentativeId { get; set; }
        public int? BranchId { get; set; }
        public int? UserId { get; set; }
        public int? SupervisorId { get; set; }
        public int? KindId { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeNameAr { get; set; }
        public string RepresentativeNameEn { get; set; }
        public string Phone { get; set; }
        public string PhoneAlternative { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public DateTime? JoinDate { get; set; }
        public string Notes { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool? IsTerminated { get; set; }
        public DateTime? TerminationDate { get; set; }
        public int? TerminationReasonId { get; set; }


        public string CompanyCode { get; set; }


    }
}
