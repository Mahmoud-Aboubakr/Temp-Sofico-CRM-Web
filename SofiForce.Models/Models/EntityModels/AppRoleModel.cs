using System;

namespace Models
{
    public class AppRoleModel
    {
        public int AppRoleId { get; set; }
        public string AppRoleCode { get; set; }
        public string AppRoleNameEn { get; set; }
        public string AppRoleNameAr { get; set; }
        public string icon { get; set; }
        public string color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? FullAccess { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
