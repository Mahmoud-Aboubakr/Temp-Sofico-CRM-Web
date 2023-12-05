using System;

namespace Models
{
    public class BranchModel
    {
        public int BranchId { get; set; }
        public string BranchNameEn { get; set; }
        public string BranchNameAr { get; set; }
        public string BranchCode { get; set; }
        public bool? IsActive { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? DisplayOrder { get; set; }
        public decimal? ExpenseRate { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
