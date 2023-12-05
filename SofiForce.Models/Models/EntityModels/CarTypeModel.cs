using System;

namespace Models
{
    public class CarTypeModel
    {
        public int CarTypeId { get; set; }
        public string CarTypeCode { get; set; }
        public string CarTypeNameEn { get; set; }
        public string CarTypeNameAr { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
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
