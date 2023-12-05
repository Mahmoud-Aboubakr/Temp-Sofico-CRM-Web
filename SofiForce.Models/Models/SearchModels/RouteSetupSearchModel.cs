using System;
using System.Collections.Generic;

namespace Models
{
    public class RouteSetupSearchModel : BaseSearchModel
    {

		public Int32? BranchId { get; set; }
		public Int32? RouteTypeId { get; set; }
		public Int32? IsActive { get; set; }
		
	}
}