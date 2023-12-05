using System;
using System.Collections.Generic;

namespace Models
{
    public class NotificationListModel
    {
        public int NotificationId { get; set; }
        public DateTime? NotificationDate { get; set; }
        public DateTime? ScheduleTime { get; set; }
        public DateTime? NotificationDateTime { get; set; }
        public int? PriorityId { get; set; }
        public string PriorityName { get; set; }
        public int? NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        public int? UserGroupId { get; set; }
        public string UserGroupName { get; set; }   
        public string PriorityColor { get; set; }
        public int? UserCount { get; set; }
        public int? Readed { get; set; }
        public int? NotReaded { get; set; }

        public string Message { get; set; }
        public decimal Performance { get; set; }

    }

    public class UserNotificationListModel
    {
        public int NotificationId { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool? IsReaded { get; set; }
        public string Message { get; set; }
        public string PriorityName { get; set; }
        public string NotificationTypeName { get; set; }
        public DateTime? NotificationDate { get; set; }
        public string PriorityColor { get; set; }
        public string UserGroupName { get; set; }


    }
}
