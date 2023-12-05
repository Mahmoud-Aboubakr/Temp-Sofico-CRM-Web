using System;
using System.Collections.Generic;

namespace Models
{
    public class VendorListModel
    {
        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        public int? VendorGroupId { get; set; }
        public string VendorName { get; set; }
        public bool? IsLocal { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string VendorGroupName { get; set; }
    }
}
