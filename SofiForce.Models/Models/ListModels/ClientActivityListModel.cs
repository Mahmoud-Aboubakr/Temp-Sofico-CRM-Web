using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientActivityListModel
    {

        public long ActivityId { get; set; }
        public int? ClientId { get; set; }
        public int? ActivityTypeId { get; set; }
        public DateTime? ActivityDate { get; set; }
        public DateTime? ActivityTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool? IsPositive { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public int? RepresentativeId { get; set; }
        public int? Duration { get; set; }
        public bool? InJourney { get; set; }
        public decimal? Distance { get; set; }
        public long? SalesId { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int? BranchId { get; set; }

        public bool? InZone { get; set; }
        public DateTime? CallAgain { get; set; }


    }
}
