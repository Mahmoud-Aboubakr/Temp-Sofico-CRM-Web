using System;

namespace Models
{
    public class PromotionItemBundleModel
    {
		public Int32? BundleId { get; set; }
		public Int32? PromotionId { get; set; }
		public int ItemId { get; set; }
		public string ItemCode { get; set; }

		public Int32? Quantity { get; set; }
		public bool? IsMandatory { get; set; }
		public Int32? CBy { get; set; }
		public DateTime? CDate { get; set; }
		public Int32? EBy { get; set; }
		public DateTime? EDate { get; set; }
	}
}
