using System;

namespace Models
{
    public class TrackMeModel
    {
        public int? TrackingTypeId { get; set; } = 1;

        public DateTime? TrackingTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool? IsPositive { get; set; } = true;

        public int? ClientId { get; set; }
    }
}
