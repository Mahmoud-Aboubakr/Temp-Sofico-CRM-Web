using System;

namespace Models
{
    public class AppUserNotificationModel
    {
        public int UserNotificationId { get; set; }
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool? IsReaded { get; set; }
    }
}
