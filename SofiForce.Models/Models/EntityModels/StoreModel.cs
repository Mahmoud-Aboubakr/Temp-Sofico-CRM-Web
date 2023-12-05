using System;

namespace Models
{
    public class StoreModel
    {
        public int StoreId { get; set; }
        public int? BranchId { get; set; }
        public int? StoreTypeId { get; set; }
        public string StoreNameEn { get; set; }
        public string StoreNameAr { get; set; }
        public string StoreCode { get; set; }
        public bool? IsActive { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanEdit { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
