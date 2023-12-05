using System;

namespace Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public int? VendorId { get; set; }
        public int? ItemGroupId { get; set; }
        public int? AcceptDays { get; set; }
        public bool? IsTaxable { get; set; }
        public string ItemCode { get; set; }
        public string ItemNameEn { get; set; }
        public string ItemNameAr { get; set; }
        public decimal? PublicPrice { get; set; }
        public decimal? ClientPrice { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsLocal { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public bool? HasPromotion { get; set; }
        public bool? IsNewAdded { get; set; }
        public bool? IsNewStocked { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime LastStockDate { get; set; }
        public bool HasQuota { get; set; }
        public string VendorCode { get; set; }
    }
}
