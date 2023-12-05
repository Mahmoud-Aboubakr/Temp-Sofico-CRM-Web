using System;
using System.Collections.Generic;

namespace Models
{
    public class BusinessUnitListModel
    {


		public Int32? BusinessUnitId { get; set; }
		public Int32? BranchId { get; set; }
		public string BusinessUnitCode { get; set; }
		public string BusinessUnitName { get; set; }
		public string Icon { get; set; }
		public string Color { get; set; }
		public Int32? DisplayOrder { get; set; }
		public bool? IsActive { get; set; }
		public bool? CanEdit { get; set; }
		public bool? CanDelete { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }


	}
}
