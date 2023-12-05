using System;

namespace Models
{
    public class DocumentTypeModel
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentTypeNameEn { get; set; }
        public string DocumentTypeNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
