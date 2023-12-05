using System;

namespace Models
{
    public class ClientServiceRequestTimlineModel
    {
        public long TimelineId { get; set; }
        public long? RequestId { get; set; }
        public int? RequestStatusId { get; set; }
        public int? UserId { get; set; }
        public DateTime? TimelineDate { get; set; }
        public string Notes { get; set; }
    }
}
