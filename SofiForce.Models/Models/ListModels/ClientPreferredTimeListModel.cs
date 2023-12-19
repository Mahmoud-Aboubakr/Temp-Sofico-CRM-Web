using System;

namespace Models
{
    public class ClientPreferredTimeListModel
    {
        public long? PreferredId { get; set; }
        public int? ClientId { get; set; }
        public int? PreferredOperationId { get; set; }
        public int? WeekDayId { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public string WeekDayName { get; set; }
        public string PreferredOperationName { get; set; }

    }
}
