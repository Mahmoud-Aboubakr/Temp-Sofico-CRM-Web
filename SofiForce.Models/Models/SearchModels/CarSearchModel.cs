using System;
using System.Collections.Generic;

namespace Models
{
    public class CarSearchModel : BaseSearchModel
    {
        public int BranchId { get; set; }
        public int ManufacturerId { get; set; }
        public int CarTypeId { get; set; }


    }
}