using System;

namespace Models
{
    public class VendorModel
    {
        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        public int? VendorGroupId { get; set; }
        public string VendorNameEn { get; set; }
        public string VendorNameAr { get; set; }
        public bool? IsLocal { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
