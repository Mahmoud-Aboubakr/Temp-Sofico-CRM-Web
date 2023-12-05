using System;

namespace Models
{
    public class OperationTypeModel
    {
        public int OperationTypeId { get; set; }
        public string OperationTypeCode { get; set; }
        public string OperationTypeNameEn { get; set; }
        public string OperationTypeNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? CBy { get; set; }
        public int? EBy { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? EDate { get; set; }
    }
}
