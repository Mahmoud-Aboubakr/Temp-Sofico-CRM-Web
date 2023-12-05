using System;
using System.Collections.Generic;

namespace Models
{
    public class RouteSetupModel
    {


		public Int32? RouteId { get; set; }
		public Int32? RouteTypeId { get; set; }
		public Int32? BranchId { get; set; }
		public string RouteCode { get; set; }
		public string RouteNameEn { get; set; }
		public string RouteNameAr { get; set; }

		public bool? IsActive { get; set; }
		public string Color { get; set; }
		public string Icon { get; set; }
		public bool? CanEdit { get; set; }
		public bool? CanDelete { get; set; }
	}
}
