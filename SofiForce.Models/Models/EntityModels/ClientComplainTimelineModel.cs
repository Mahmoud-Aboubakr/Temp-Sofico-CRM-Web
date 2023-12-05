using System;

namespace Models
{
    public class ClientComplainTimelineModel
    {
        public long TimelineId { get; set; }
        public long? ComplainId { get; set; }
        public int? ComplainStatusId { get; set; }
        public int? UserId { get; set; }
        public DateTime? TimelineDate { get; set; }
        public string Notes { get; set; }
    }
}
