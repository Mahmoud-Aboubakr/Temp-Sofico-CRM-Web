using System;
using System.Collections.Generic;

namespace Models
{
    public class SalesOrderDetailListModel
	{
		public string Id { get; set; }

		public int? parentId { get; set; }
		public double? DetailId { get; set; }
		public double? SalesId { get; set; }
		public int? ItemId { get; set; }
		public int? ItemGroupId { get; set; }

		public double? PublicPrice { get; set; }
		public double? ClientPrice { get; set; }

		public int? Quantity { get; set; }

		public double? LineValue { get; set; }
		public double? Discount { get; set; }

		public double? TaxValue { get; set; }

		public bool? IsBouns { get; set; }
		public bool? HasPromotion { get; set; }

		public string PromotionCode { get; set; } = string.Empty;

		public int? ItemStoreId { get; set; }
		public string Batch { get; set; } = string.Empty;
		public DateTime? Expiration { get; set; }

		public string ItemCode { get; set; } = string.Empty;
		public string ItemName { get; set; } = string.Empty;
		public string VendorName { get; set; } = string.Empty;
		public string VendorCode { get; set; } = string.Empty;


		//2022-06-01
		public int? UnitId { get; set; }
		public double? CustomDiscount { get; set; }
		public double? CashDiscount { get; set; }

		//2022-08-14

		public int? TotalReturn { get; set; }
		public int? ReturnQuantity { get; set; }

		public int? Availability { get; set; }

		public int? ClientId { get; set; }
		public string InvoiceCode { get; set; }
		public DateTime? InvoiceDate { get; set; }


		//2023-1-14
	
		public bool IsNewStocked { get; set; }
		public bool IsNewAdded { get; set; }

		public int Quota { get; set; }

	}

	public class SalesOrderPromotionOptionModel
    {
		public int RowId { get; set; }
		public bool Selected { get; set; }
		public string ItemCode { get; set; } = string.Empty;
		public string ItemName { get; set; } = string.Empty;
		public string PromotionId { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public List<SalesOrderDetailListModel> Batchs { get; set; } = new List<SalesOrderDetailListModel>();

    }


	public class SalesOrderDetailMobileListModel
	{
		public double? DetailId { get; set; }
		public double? SalesId { get; set; }
		public int? ItemId { get; set; }
		public double? PublicPrice { get; set; }
		public double? ClientPrice { get; set; }
		public int? Quantity { get; set; }
		public double? LineValue { get; set; }
		public double? Discount { get; set; }
		public double? TaxValue { get; set; }
		public bool? IsBouns { get; set; }
		public int? ItemStoreId { get; set; }
		public string Batch { get; set; } = string.Empty;
		public DateTime? Expiration { get; set; }
		public string ItemCode { get; set; } = string.Empty;
		public string ItemName { get; set; } = string.Empty;
		public string VendorName { get; set; } = string.Empty;
		public string VendorCode { get; set; } = string.Empty;
		public int? UnitId { get; set; }

		public int? Availability { get; set; }
		public string PromotionCode { get; set; } = string.Empty;


		public bool HasPromotion { get; set; }
		public bool IsNewStocked { get; set; }
		public bool IsNewAdded { get; set; }


		public int Quota { get; set; }


	}

	public class SalesOrderPromotionMobileOptionModel
	{
		public int RowId { get; set; }
		public bool Selected { get; set; }
		public string ItemCode { get; set; } = string.Empty;
		public string ItemName { get; set; } = string.Empty;
		public string PromotionId { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public List<SalesOrderDetailMobileListModel> Batchs { get; set; } = new List<SalesOrderDetailMobileListModel>();

	}
}
