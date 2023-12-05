using System;
using System.Collections.Generic;

namespace Models
{
    public class SalesOrderListModel
    {
		public Int64? SalesId{get;set;}
		public string SalesCode{get;set;}
		
		public DateTime? SalesDate{get;set;}
		public Int32? SalesOrderStatusId{get;set;}
		public Int32? salesOrderTypeId { get; set; }
		public Int32? salesOrderSourceId { get; set; }

		public Int32? ClientId { get;set;}
		public decimal? NetTotal{get;set;}
		public decimal? TaxTotal { get; set; }
		public decimal? CashDiscountTotal { get;set;}
		public decimal? ItemTotal { get; set; }
		public decimal? ItemDiscountTotal { get; set; }

		public bool? IsInvoiced{get;set;}
		public string InvoiceCode{get;set;}
		public DateTime? InvoiceDate{get;set;}
		public string ClientCode{get;set;}
		public string BranchName{get;set;}
		public string BranchCode{get;set;}
		public string RepresentativeCode{get;set;}
		public string RepresentativeName{get;set;}
		public string StoreCode{get;set;}
		public string PriorityName{get;set;}
		public string SalesOrderSourceName{get;set;}
		public string SalesOrderStatusName{get;set;}
		public string SalesOrderTypeName{get;set;}
		public string StoreName{get;set;}
		public string PaymentTermName{get;set;}
		public string ClientName{get;set;}

		public bool? HasError { get;set;}
		public bool? Inprogress { get; set; }

		public bool? IsBackoffice { get; set; }

		public double? Latitude { get; set; }
		public double? Longitude { get; set; }

	}
}
