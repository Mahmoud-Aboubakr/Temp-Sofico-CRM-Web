using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClientQuotaHistoryListModel
    {
		public Int32? ItemId { get; set; }
		public string ItemCode { get; set; }
		public string ItemName { get; set; }
		public Int32? VendorId { get; set; }
		public Int32? ClientId { get; set; }
		public Int32? BranchId { get; set; }
		public Int32? Quantity { get; set; }
		public DateTime? CreateDate { get; set; }
		public string ClientCode { get; set; }
		public string ClientName { get; set; }

		public string InvoiceCode { get; set; }

	}
}
