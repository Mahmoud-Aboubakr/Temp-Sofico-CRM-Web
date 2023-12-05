using System;

namespace Models
{
    public class RequestTypeModel
    {
        public int RequestTypeId { get; set; }
        public string RequestTypeCode { get; set; }
        public string RequestTypeNameEn { get; set; }
        public string RequestTypeNameAr { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
