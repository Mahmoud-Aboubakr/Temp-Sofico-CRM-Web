using System;

namespace Models
{
    public class AppUserLocationModel
    {
        public long TrackingId { get; set; }
        public int? UserId { get; set; }
        public int? TrackingTypeId { get; set; }
        public DateTime? TrackingDate { get; set; }
        public DateTime? TrackingTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool? IsPositive { get; set; }
    }
}
