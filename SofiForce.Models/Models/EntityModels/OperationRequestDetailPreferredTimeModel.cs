using System;

namespace Models
{
    public class OperationRequestDetailPreferredTimeModel
    {
        public long PreferredId { get; set; }
        public long? DetailId { get; set; }
        public int? PreferredTypeId { get; set; }
        public int? PreferredOperationId { get; set; }
        public int? WeekDayId { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
    }
}
