using System;

namespace Models
{
    public class GovernerateModel
    {
        public int GovernerateId { get; set; }
        public int? RegionId { get; set; }
        public string GovernerateCode { get; set; }
        public string GovernerateNameAr { get; set; }
        public string GovernerateNameEn { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
