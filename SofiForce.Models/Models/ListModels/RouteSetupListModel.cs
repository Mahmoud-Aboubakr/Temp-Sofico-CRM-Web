using System;
using System.Collections.Generic;

namespace Models
{
    public class RouteSetupListModel
    {


		public Int32? RouteId { get; set; }
		public Int32? RouteTypeId { get; set; }
		public Int32? BranchId { get; set; }
		public string RouteCode { get; set; }
		public string RouteName { get; set; }
		public bool? IsActive { get; set; }
		public string Color { get; set; }
		public string Icon { get; set; }
		public bool? CanEdit { get; set; }
		public bool? CanDelete { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }
		public string RouteTypeCode { get; set; }
		public string RouteTypeName { get; set; }
	}
}
