using System;
using System.Collections.Generic;

namespace Models
{
    public class ItemStoreListModel
    {

		public Int32? ItemStoreId { get; set; }
		public Int32? ItemId { get; set; }
		public Int32? BranchId { get; set; }
		public Int32? StoreId { get; set; }
		public Int32? Quantity { get; set; }
		public Int32? OnHand { get; set; }
		public DateTime? ExpireDate { get; set; }
		public string BatchNo { get; set; }
		public Int32? AcceptDays { get; set; }
		public string ItemCode { get; set; }
		public string ItemName { get; set; }
		public string VendorName { get; set; }
		public Int32? VendorId { get; set; }
		public Int32? Available { get; set; }

		public string StoreCode { get; set; }
		public string StoreName { get; set; }
		public string BranchCode { get; set; }
		public string BranchName { get; set; }

		public int? UnitId { get; set; }
		public bool? IsActive { get; set; }


		public int Quota { get; set; }


	}
}
