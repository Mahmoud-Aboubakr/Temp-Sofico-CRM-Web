using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestDetailPreferredTimeListModel
    {

        public string Id { get; set; }
        public long PreferredId { get; set; }
        public long? DetailId { get; set; }
        public int? PreferredOperationId { get; set; }
        public int? WeekDayId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string WeekDayName { get; set; }
        public string PreferredOperationName { get; set; }
    }
}
