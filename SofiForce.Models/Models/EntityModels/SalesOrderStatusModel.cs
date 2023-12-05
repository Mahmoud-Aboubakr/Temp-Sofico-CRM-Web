using System;

namespace Models
{
    public class SalesOrderStatusModel
    {
        public int SalesOrderStatusId { get; set; }
        public string SalesOrderStatusCode { get; set; }
        public string SalesOrderStatusNameEn { get; set; }
        public string SalesOrderStatusNameAr { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanEdit { get; set; }
    }
}
