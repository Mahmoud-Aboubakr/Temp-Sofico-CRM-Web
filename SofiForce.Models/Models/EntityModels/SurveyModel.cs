using System;
using System.Collections.Generic;

namespace Models
{
    public class SurveyModel
    {
        public string Id { get; set; }
        public int? SurveyId { get; set; }
        public string SurveyCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ServeyGroupId { get; set; }
        public string SurveyNameEn { get; set; }
        public string SurveyNameAr { get; set; }
        public bool? IsActive { get; set; }

        public List<SurveyDetailListModel> Details { get; set; } = new List<SurveyDetailListModel>();
    }
}
