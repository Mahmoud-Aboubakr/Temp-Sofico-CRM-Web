using System;
using System.Collections.Generic;

namespace Models
{
    public class SalesOrderControlSearchModel : BaseSearchModel
    {
		public Int32? ClientId { get; set; }
		public string SalesCode { get; set; }
		public string ClientCode { get; set; }
		public Int32? BranchId { get; set; }
		public Int32? RepresentativeId { get; set; }
		public Int32? StoreId { get; set; }
		public Int32? PriorityTypeId { get; set; }
		public DateTime? SalesDateFrom { get; set; }
		public DateTime? SalesDateTo { get; set; }
		public Int32? SalesOrderTypeId { get; set; }

		public Int32? SalesOrderStatusId { get; set; }
		public Int32? RejectedOnly { get; set; }
	}
}