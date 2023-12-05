using System;

namespace Models
{
    public class ServeyGroupModel
    {
        public int ServeyGroupId { get; set; }
        public string ServeyGroupCode { get; set; }
        public string ServeyGroupNameEn { get; set; }
        public string ServeyGroupNameAr { get; set; }
        public int? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
