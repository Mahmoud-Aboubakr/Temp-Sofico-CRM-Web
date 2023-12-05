using System;

namespace Models
{
    public class WeekDayModel
    {
        public int WeekDayId { get; set; }
        public string WeekDayCode { get; set; }
        public string WeekDayNameEn { get; set; }
        public string WeekDayNameAr { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public int? CBy { get; set; }
        public int? CDate { get; set; }
    }
}
