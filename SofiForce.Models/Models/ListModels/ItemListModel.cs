using System;
using System.Collections.Generic;

namespace Models
{
    public class ItemListModel
    {
        public int? ItemId { get; set; }
        public int? VendorId { get; set; }
        public int? AcceptDays { get; set; }
        public bool? IsTaxable { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal? PublicPrice { get; set; }
        public decimal? ClientPrice { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsLocal { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public bool? IsNewAdded { get; set; }
        public bool? HasPromotion { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? IsNewStocked { get; set; }
        public int? VendorGroupId { get; set; }
        public string VendorName { get; set; }
        public int? ItemGroupId { get; set; }
        public int? UnitId { get; set; }    

        public string ItemGroupName { get; set; }

        public int Quantity { get; set; }

        public int Quota { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastStockDate { get; set; }
        public bool HasQuota { get; set; }
        public string VendorCode { get; set; }
        public int pageCount { get; set; }


    }
}
