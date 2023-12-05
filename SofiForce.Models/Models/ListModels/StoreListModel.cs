using System;
using System.Collections.Generic;

namespace Models
{
    public class StoreListModel
    {

		public Int32? StoreId { get; set; }
		public Int32? BranchId { get; set; }
		public Int32? StoreTypeId { get; set; }
		public string StoreName { get; set; }
		public string StoreCode { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsOrder { get; set; }

		public string Icon { get; set; }
		public string Color { get; set; }
		public Int32? DisplayOrder { get; set; }
		public bool? CanDelete { get; set; }
		public bool? CanEdit { get; set; }
		public string BranchName { get; set; }
		public string BranchCode { get; set; }
		public string StoreTypeName { get; set; }
	}
}
