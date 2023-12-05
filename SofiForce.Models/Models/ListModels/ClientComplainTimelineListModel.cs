using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientComplainTimelineListModel
    {

        public string Id { get; set; }
        public long TimelineId { get; set; }
        public long? ComplainId { get; set; }
        public int? ComplainStatusId { get; set; }
        public string ComplainStatusName { get; set; }

        public int? UserId { get; set; }
        public string UserName { get; set; }

        public DateTime? TimelineDate { get; set; }
        public string Notes { get; set; }
    }
}
