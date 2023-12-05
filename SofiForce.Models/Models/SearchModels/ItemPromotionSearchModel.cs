using System;
using System.Collections.Generic;

namespace Models
{
    public class ItemPromotionSearchModel : BaseSearchModel
    {

		public Int32? VendorId { get; set; }
		public Int32? ItemId { get; set; }

		public decimal? Discount { get; set; }
		public DateTime? ValidTo { get; set; }
		public DateTime? ValidFrom { get; set; }



	}
}