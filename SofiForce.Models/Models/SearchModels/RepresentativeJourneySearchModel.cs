using System;
using System.Collections.Generic;

namespace Models
{
    public class RepresentativeJourneySearchModel : BaseSearchModel
    {


		public Int32? RepresentativeId { get; set; }
		public Int32? ReprestitiveUserId { get; set; }
		public Int32? SupervisorId { get; set; }
		public Int32? RouteId { get; set; }
		public Int32? BranchId { get; set; }
		public Int32? KindId { get; set; }

		public Int32? RouteTypeId { get; set; }

	}
}