using System;
using System.Collections.Generic;

namespace Models
{
    public class ItemStoreTotalSearchModel : BaseSearchModel
    {
        public Int32? VendorId { get; set; }
        public Int32? ItemId { get; set; }
        public Int32? BranchId { get; set; }

        public Int32? StoreId { get; set; }



    }
}