using System;
using System.Collections.Generic;

namespace Models
{
    public class SalesControlSearchModel : BaseSearchModel
    {
        public Int32 BranchId { get; set; }
        public Int32 SupervisorId { get; set; }
        public Int32 RepresentativeId { get; set; }
        public Int32 ClientId { get; set; }


        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }


    }
}