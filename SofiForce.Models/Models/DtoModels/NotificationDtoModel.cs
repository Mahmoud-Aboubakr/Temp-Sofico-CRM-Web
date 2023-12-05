using System;

namespace Models
{
    public class NotificationDtoModel
    {
        public int NotificationId { get; set; }
        public DateTime? NotificationDateTime { get; set; }
        public string Message { get; set; }

    }
}
