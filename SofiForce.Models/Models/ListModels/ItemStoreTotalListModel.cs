using System;
using System.Collections.Generic;

namespace Models
{
    public class ItemStoreTotalListModel
	{

        public int? ItemId { get; set; }
        public int? BranchId { get; set; }
        public int? StoreId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StoreTypeName { get; set; }
        public int? StoreTypeId { get; set; }
        public int? Quantity { get; set; }
        public int? VendorId { get; set; }
        public string ItemName { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }

        public int Quota { get; set; }

    }

}

