using System;

namespace Models
{
    public class AppUserListModel
    {
		public Int32? UserId { get; set; }
		public Int32? AppRoleId { get; set; }
		public Int32? UserGroupId { get; set; }
		public string RealName { get; set; }
		public string UserName { get; set; }
		public bool? IsOnline { get; set; }
		public bool? IsLocked { get; set; }
		public bool? MustChangeData { get; set; }
		public DateTime? LastLogin { get; set; }
		public bool? MustChangePassword { get; set; }
		public bool? EmailVerified { get; set; }
		public string DefaultRoute { get; set; }
		public string Phone { get; set; }
		public string WhatsApp { get; set; }
		public string UserGroupCode { get; set; }
		public string UserGroupName { get; set; }
		public string AppRoleCode { get; set; }
		public string AppRoleName { get; set; }
	}
}
