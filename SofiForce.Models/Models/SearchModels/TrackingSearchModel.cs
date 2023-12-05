using System;
using System.Collections.Generic;

namespace Models
{
    public class TrackingSearchModel : BaseSearchModel
    {
        public Int32 BranchId { get; set; }
        public Int32 SupervisorId { get; set; }
        public Int32 RepresentativeId { get; set; }
        public Int32 RepresentativeKindId { get; set; }

        public Int32 StatusId { get; set; }




    }
}