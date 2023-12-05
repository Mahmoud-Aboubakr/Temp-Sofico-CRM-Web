using System;

namespace Models
{
    public class SalesOrderTypeModel
    {
        public int SalesOrderTypeId { get; set; }
        public string SalesOrderTypeCode { get; set; }
        public string SalesOrderTypeNameEn { get; set; }
        public string SalesOrderTypeNameAr { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanEdit { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
