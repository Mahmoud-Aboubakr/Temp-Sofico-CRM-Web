using System;

namespace Models
{
    public class PreferredOperationModel
    {
        public int PreferredOperationId { get; set; }
        public string PreferredOperationCode { get; set; }
        public string PreferredOperationNameEn { get; set; }
        public string PreferredOperationNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? DisplayOrder { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
