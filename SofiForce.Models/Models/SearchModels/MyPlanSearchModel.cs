using System;
using System.Collections.Generic;

namespace Models
{
    public class MyPlanSearchModel : BaseSearchModel
    {
        public Int32 ClientId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

    }
}