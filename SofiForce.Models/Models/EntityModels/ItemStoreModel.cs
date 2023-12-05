using System;

namespace Models
{
    public class ItemStoreModel
    {
        public int ItemStoreId { get; set; }
        public int? ItemId { get; set; }
        public int? BranchId { get; set; }
        public int? StoreId { get; set; }
        public int? Quantity { get; set; }
        public int? OnHand { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string BatchNo { get; set; }
    }
}
