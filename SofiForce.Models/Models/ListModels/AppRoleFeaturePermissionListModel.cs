using System;

namespace Models
{
    public class AppRoleFeaturePermissionListModel
    {
        public int RolePermissionId { get; set; }
        public int? AppRoleFeatueId { get; set; }
        public int? FeaturePermissionId { get; set; }
        public int? FeatueId { get; set; }

        public string FeatueCode { get; set; }
        public string FeatueName { get; set; }
        public string PermissionCode { get; set; }
        public string PermissionName { get; set; }
    }
}
