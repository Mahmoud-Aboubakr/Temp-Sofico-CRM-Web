using System;
using System.Collections.Generic;

namespace Models
{
    public class SalesOrderSearchModel : BaseSearchModel
    {
		public Int32? ClientId { get; set; }
		public string SalesCode { get; set; }
		public string ClientCode { get; set; }

		public Int32? BranchId { get; set; }
		public Int32? RepresentativeId { get; set; }

		public Int32? StoreId { get; set; }

		public Int32? PriorityTypeId { get; set; }

		public DateTime? SalesDate { get; set; }
		public Int32? SalesOrderStatusId { get; set; }
		public List<int>? SalesOrderSourceId { get; set; }
		public Int32? SalesOrderTypeId { get; set; }
		public DateTime? InvoiceDate { get; set; }

		public Int32? IsInvoiced { get; set; }

		public int FilterMode { get; set; }

		public bool? CashDiscountOnly { get; set; }=false;

	}
}