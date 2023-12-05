using System;
using System.Collections.Generic;

namespace Models
{
    public class SupervisorListModel
    {

        public int SupervisorId { get; set; }
        public string SupervisorCode { get; set; }
        public string SupervisorName { get; set; }
        public int? UserId { get; set; }

        public int? BusinessUnitId { get; set; }
        public string BusinessUnitCode { get; set; }
        public string BusinessUnitName { get; set; }
        public string CompanyCode { get; set; }

        public int? BranchId { get; set; }
        public bool? IsActive { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public string Icon { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public DateTime? JoinDate { get; set; }
        public string SupervisorTypeName { get; set; }

        public string Notes { get; set; }
        public string Phone { get; set; }
        public string PhoneAlternative { get; set; }
        public bool? IsTerminated { get; set; }
        public DateTime? TerminationDate { get; set; }
        public Int32? TerminationReasonId { get; set; }

        public int? Representatives { get; set; }   
    }
}
