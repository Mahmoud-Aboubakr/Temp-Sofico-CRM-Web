using System;

namespace Models
{
    public class ApplicationSettingModel
    {
        public int AppSettingId { get; set; }
        public int? ApplicationId { get; set; }
        public string AppSettingCode { get; set; }
        public string AppSettingName { get; set; }
        public string AppSettingValue { get; set; }
        public DateTime? AppSettingLastDate { get; set; }
    }
}
