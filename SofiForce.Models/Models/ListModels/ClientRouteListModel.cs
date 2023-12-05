using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientRouteListModel
    {

		public Int32? ClientRouteId { get; set; }
		public Int32? RouteTypeId { get; set; }
		public Int32? RouteId { get; set; }
		public Int32? ClientId { get; set; }
		public bool? Day1 { get; set; }
		public bool? Day2 { get; set; }
		public bool? Day3 { get; set; }
		public bool? Day4 { get; set; }
		public bool? Day5 { get; set; }
		public bool? Day6 { get; set; }
		public bool? Day7 { get; set; }
		public string RouteCode { get; set; }
		public string RouteName { get; set; }
		public string RouteTypeCode { get; set; }
		public string RouteTypeName { get; set; }
		public string ClientCode { get; set; }
		public string ClientName { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }
		public Int32? BranchId { get; set; }
		public bool? IsActive { get; set; }


	}
}
