using System;

namespace Models
{
    public class ClientSurveyDetailModel
    {
        public long ClientDetailId { get; set; }
        public int? DetailAnswerId { get; set; }
        public bool? IsSelected { get; set; }
    }
}
