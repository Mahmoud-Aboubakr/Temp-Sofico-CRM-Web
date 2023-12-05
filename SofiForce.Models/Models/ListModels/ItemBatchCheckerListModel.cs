using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemBatchCheckerListModel
    {
		public string BatchNo { get; set; }
		public Int32? ItemId { get; set; }
		public Int32? VendorId { get; set; }
		public string ItemCode { get; set; }
		public string ItemName { get; set; }
		public decimal? PublicPrice { get; set; }
		public decimal? ClientPrice { get; set; }
		public decimal? Discount { get; set; }
		public string VendorName { get; set; }
		public string VendorCode { get; set; }
		public Int32? Quota { get; set; }
	}
}
