using System;

namespace Models
{
    public class PromotionItemBundleListModel
	{
		public Int32? BundleId { get; set; }
		public Int32? PromotionId { get; set; }
		public int ItemId { get; set; }
		public string ItemCode { get; set; }
		public string ItemName { get; set; }

		public Int32? Quantity { get; set; }
		public bool? IsMandatory { get; set; }

	}
}
