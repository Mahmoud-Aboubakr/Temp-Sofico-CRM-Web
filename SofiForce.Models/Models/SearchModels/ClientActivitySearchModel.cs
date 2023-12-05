using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientActivitySearchModel : BaseSearchModel
    {
        public int? ClientId { get; set; }
        public int? BranchId { get; set; }
        public int? RepresentativeId { get; set; }

        public DateTime? ActivityTimeFrom { get; set; }
        public DateTime? ActivityTimeTo { get; set; }

        public DateTime? CallAgainFrom { get; set; }
        public DateTime? CallAgainTo { get; set; }

        public int? InJourney { get; set; }
        public int? InZone { get; set; }

        public int? IsPositive { get; set; }
        public int? ActivityTypeId { get; set; }


    }
}