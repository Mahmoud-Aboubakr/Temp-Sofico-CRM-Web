using System;

namespace Models
{
    public class VendorGroupModel
    {
        public int VendorGroupId { get; set; }
        public string VendorGroupCode { get; set; }
        public string VendorGroupNameEn { get; set; }
        public string VendorGroupNameAr { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
