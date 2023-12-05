using System;

namespace Models
{
    public class AppRoleFeaturePermissionModel
    {
        public int RolePermissionId { get; set; }
        public int? AppRoleFeatueId { get; set; }
        public int? FeaturePermissionId { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
