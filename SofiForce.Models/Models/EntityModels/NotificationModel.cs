using System;
using System.Collections.Generic;

namespace Models
{
    public class NotificationModel
    {
        public int NotificationId { get; set; }
        public DateTime? NotificationDate { get; set; }
        public DateTime? ScheduleTime { get; set; }
        public DateTime? NotificationDateTime { get; set; }
        public int? PriorityId { get; set; }
        public string Message { get; set; }
        public int? NotificationTypeId { get; set; }
        public int? NotificationGroupId { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }

        public int UserGroupId { get; set; }
        public int? UserId { get; set; }

    }
}
