using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientRouteSearchModel : BaseSearchModel
    {

		public int? ClientId { get; set; }    
		public int? RouteId { get; set; }
        public int? BranchId { get; set; }
        public int? IsActive { get; set; }

        public int? RouteTypeId { get; set; }


    }
}