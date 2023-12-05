using System;

namespace Models
{
    public class PreferredTypeModel
    {
        public int PreferredTypeId { get; set; }
        public string PreferredTypeCode { get; set; }
        public string PreferredTypeNameEn { get; set; }
        public string PreferredTypeNameAr { get; set; }
        public int? DiaplayOrder { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? CBy { get; set; }
        public int? EBy { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? EDate { get; set; }
    }
}
