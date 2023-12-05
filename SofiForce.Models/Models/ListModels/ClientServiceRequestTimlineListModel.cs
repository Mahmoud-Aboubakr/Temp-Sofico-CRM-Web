using System;

namespace Models
{
    public class ClientServiceRequestTimlineListModel
    {
        public string Id { get; set; }
        public long TimelineId { get; set; }
        public long? RequestId { get; set; }
        public int? RequestStatusId { get; set; }
        public int? UserId { get; set; }
        public DateTime? TimelineDate { get; set; }
        public string Notes { get; set; }
        public string RequestStatusName{ get; set; }
        public string RealName { get; set; }
        public string Color { get; set; }
    }
}
