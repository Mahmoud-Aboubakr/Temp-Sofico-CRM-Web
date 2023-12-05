using System;
using System.Collections.Generic;

namespace Models
{
    public class StoreSearchModel : BaseSearchModel
    {
        public int? BranchId {get; set;}
        public int? StoreTypeId { get; set; }
        public int? IsOrder { get; set; }
        public int? IsActive { get; set; }
    }
}