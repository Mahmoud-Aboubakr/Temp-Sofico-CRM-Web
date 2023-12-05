using System;

namespace Models
{
    public class TrakingRepresentativeDetailModel
    {
        public long TrackingId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool? IsPositive { get; set; }
        
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string TrackTypeName { get; set; }
        public int TrackTypeId { get; set; }

        public double? SalesId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? TrackTime { get; set; }

        public bool? InZone { get; set; }
        public int Distance { get; set; }


    }
}
