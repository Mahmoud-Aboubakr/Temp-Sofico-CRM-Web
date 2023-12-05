using System;

namespace Models
{
    public class ActivityChannelModel
    {
        public int ActivityChannelId { get; set; }
        public string ActivityChannelCode { get; set; }
        public string ActivityChannelNameEn { get; set; }
        public string ActivityChannelNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanEdit { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? CBy { get; set; }
        public int? EBy { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? EDate { get; set; }
    }
}
