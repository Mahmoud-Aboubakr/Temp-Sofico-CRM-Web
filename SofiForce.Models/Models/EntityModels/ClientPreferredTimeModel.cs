using System;

namespace Models
{
    public class ClientPreferredTimeModel
    {
        public int PreferredId { get; set; }
        public int? ClientId { get; set; }
        public int? PreferredTypeId { get; set; }
        public int? PreferredOperationId { get; set; }
        public int? WeekDayId { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
    }
}
