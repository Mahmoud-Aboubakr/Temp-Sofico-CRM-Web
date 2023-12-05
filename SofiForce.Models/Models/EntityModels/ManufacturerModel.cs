using System;

namespace Models
{
    public class ManufacturerModel
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerNameEn { get; set; }
        public string ManufacturerNameAr { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? IsActive { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
