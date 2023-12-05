using System;

namespace Models
{
    public class ItemGroupModel
    {
        public int ItemGroupId { get; set; }
        public string ItemGroupCode { get; set; }
        public string ItemGroupNameEn { get; set; }
        public string ItemGroupNameAr { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? IsActive { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
