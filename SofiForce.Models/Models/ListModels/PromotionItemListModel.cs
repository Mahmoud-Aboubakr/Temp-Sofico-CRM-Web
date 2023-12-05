using System;
using System.Collections.Generic;

namespace Models
{
    public class PromotionItemListModel
    {
		public Int32? PromotionCategoryId { get; set; }
		public bool? IsApproved { get; set; }
		public bool? IsActive { get; set; }
		public DateTime? ValidTo { get; set; }
		public DateTime? ValidFrom { get; set; }
		public Int32? Priority { get; set; }
		public string ItemCode { get; set; }
		public string ItemName { get; set; }

		public Int32? GroupId { get; set; }
		public Int64? PromotionItemId { get; set; }
		public Int32? PromotionId { get; set; }
		public Int32? RepeatTypeId { get; set; }
		public Int32? Repeats { get; set; }
		public Int32? PromotionTypeId { get; set; }
		public string PromotionCode { get; set; }
		public Int32? PromotionGroupId { get; set; }


	}
}
