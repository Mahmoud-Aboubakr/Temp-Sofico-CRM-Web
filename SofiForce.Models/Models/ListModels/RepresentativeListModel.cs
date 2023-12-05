using System;
using System.Collections.Generic;

namespace Models
{
    public class RepresentativeListModel
    {

		public Int32? RepresentativeId { get; set; }
		public Int32? BranchId { get; set; }
		public Int32? UserId { get; set; }
		public Int32? SupervisorId { get; set; }
		public Int32? KindId { get; set; }

		public int? BusinessUnitId { get; set; }
		public string BusinessUnitCode { get; set; }
		public string BusinessUnitName { get; set; }
		public string CompanyCode { get; set; }


		public string RepresentativeCode { get; set; }
		public string RepresentativeName { get; set; }
		public string KindCode { get; set; }
		public string KindName { get; set; }
		public bool? IsActive { get; set; }
		public Int32? DisplayOrder { get; set; }
		public bool? CanEdit { get; set; }
		public bool? CanDelete { get; set; }
		public string Icon { get; set; }
		public string Color { get; set; }
		public string SupervisorName { get; set; }
		public string BranchName { get; set; }
		public string BranchCode { get; set; }
		public DateTime? JoinDate { get; set; }
		public string Notes { get; set; }
		public string Phone { get; set; }
		public string PhoneAlternative { get; set; }
		public bool? IsTerminated { get; set; }
		public DateTime? TerminationDate { get; set; }
		public Int32? TerminationReasonId { get; set; }


	}
}
