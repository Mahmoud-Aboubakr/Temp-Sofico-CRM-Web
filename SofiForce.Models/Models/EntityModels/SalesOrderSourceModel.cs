using System;

namespace Models
{
    public class SalesOrderSourceModel
    {
        public int SalesOrderSourceId { get; set; }
        public string SalesOrderSourceCode { get; set; }
        public string SalesOrderSourceNameEn { get; set; }
        public string SalesOrderSourceNameAr { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
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
