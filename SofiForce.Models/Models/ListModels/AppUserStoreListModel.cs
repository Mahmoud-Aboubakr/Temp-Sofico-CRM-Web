using System;

namespace Models
{
    public class AppUserStoreListModel
    {
        public int AppUserStoreId { get; set; }
        public int? UserId { get; set; }
        public int? StoreId { get; set; }
        public string? StoreName { get; set; }
        public string StoreCode { get; set; }
    }
}
