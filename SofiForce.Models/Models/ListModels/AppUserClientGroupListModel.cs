using System;

namespace Models
{
    public class AppUserClientGroupListModel
    {
        public int AppUserGroupId { get; set; }
        public int? UserId { get; set; }
        public int? ClientGroupId { get; set; }
        public string? ClientGroupName { get; set; }
        public string ClientGroupCode { get; set; }
    }
}
