using System;
using System.Collections.Generic;

namespace Models
{
    public class AppUserSearchModel : BaseSearchModel
    {


		public Int32? AppRoleId;
		public Int32? UserGroupId;
		public int? IsOnline;
		public int? IsLocked;
		public DateTime? LastLogin;
		public int? MustChangePassword;
		
	}
}