using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientPlanSearchModel : BaseSearchModel
    {


        public int? ClientId { get; set; }
        public int? BranchId { get; set; }
        public int? ClientTypeId { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}