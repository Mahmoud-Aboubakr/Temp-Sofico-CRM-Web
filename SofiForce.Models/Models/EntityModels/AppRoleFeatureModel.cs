using System;

namespace Models
{
    public class AppRoleFeatureModel
    {
        public int AppRoleFeatueId { get; set; }
        public int? AppRoleId { get; set; }
        public int? FeatueId { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
