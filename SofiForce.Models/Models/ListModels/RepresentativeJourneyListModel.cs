using System;
using System.Collections.Generic;

namespace Models
{
    public class RepresentativeJourneyListModel
    {
		public Int64? JourneyId { get; set; }
		public Int32? RepresentativeId { get; set; }
		public string KindName { get; set; }
		public string RepresentativeName { get; set; }
		public string RepresentativeCode { get; set; }
		public Int32? ReprestitiveUserId { get; set; }
		public Int32? SupervisorId { get; set; }
		public string RouteCode { get; set; }
		public string RouteName { get; set; }
		public Int32? RouteId { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }
		public Int32? BranchId { get; set; }
		public Int32? KindId { get; set; }
		public string Phone { get; set; }
		public bool? IsTerminated { get; set; }
		public bool? IsActive { get; set; }

		public Int32? RouteTypeId { get; set; }
		public string RouteTypeName { get; set; }
		public string RouteTypeCode { get; set; }
	}
}
