using System;
using System.Collections.Generic;

namespace Models
{
    public class ItemSearchModel : BaseSearchModel
    {
        public Int32? ItemId { get; set; }

        public Int32? VendorId { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public int? IsNewAdded { get; set; }
        public int? IsNewStocked { get; set; }
        public int? HasPromotion { get; set; }
        public int? IsActive { get; set; }

        public decimal? PublicPrice { get; set; }
        public decimal? ClientPrice { get; set; }

        public Int32? StoreId { get; set; }


    }
}