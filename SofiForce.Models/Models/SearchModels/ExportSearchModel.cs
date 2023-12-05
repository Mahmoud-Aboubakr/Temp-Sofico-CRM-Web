using System;
using System.Collections.Generic;

namespace Models
{
    public class ExportSearchModel : BaseSearchModel
    {
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }

		public Int32? ClientId { get; set; }

		public Int32? BranchId { get; set; }

		public Int32? StoreId { get; set; }


		public Int32? VendorId { get; set; }


		public Int32? RepresentativeId { get; set; }
		

		public Int32? ItemId { get; set; }

		


	}
}