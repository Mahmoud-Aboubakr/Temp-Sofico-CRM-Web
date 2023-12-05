using System;
using System.Collections.Generic;

namespace Models
{
    public class NotificationSearchModel : BaseSearchModel
    {

        public DateTime? NotificationDate { get; set; }

        public int? PriorityId { get; set; }

        public int? NotificationTypeId { get; set; }

        public int? UserGroupId { get; set; }

        public int? IsReaded { get; set; }
    }
}