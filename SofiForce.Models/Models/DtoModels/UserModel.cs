using System.Collections.Generic;

namespace Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public bool IsLocked { get; set; }
        public int BranchId { get; set; }
        public int StoreId { get; set; }
        public int RepresentativeId { get; set; }

        public bool MustChangePassword { get; set; }
        public bool MustChangeData { get; set; }


        public int AppRoleId { get; set; }
        public string RealName { get; set; }
        public string Username { get; set; }
        public string WhatsApp { get; set; }
        public string JobTitle { get; set; }
        public string Internal { get; set; }
        public string Zoom { get; set; }
        public string Linkedin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string DefualtUrl { get; set; }
        public string Avatar { get; set; }
        public string Token { get; set; }

        public List<UserFeature> UserFeatures { get; set; }=new List<UserFeature> { };
    }
    public class UserFeature
    {
        public bool? IsNew { get; set; }
        public bool? IsUpdated { get; set; }
        public string FeatureCode { get; set; }
        public string FeatureName { get; set; }
        public List<UserFeaturePermission> UserFeaturePermissions { get; set; } = new List<UserFeaturePermission>(); 
    }
    public class UserFeaturePermission
    {
        public string PermissionCode { get; set; }
        public string PermissionName { get; set; }
        public bool IsAllowed { get; set; }

    }
}