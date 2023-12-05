using System;
using System.Collections.Generic;

namespace Models
{
    public class SurveyListModel
    {

        public int SurveyId { get; set; }
        public string SurveyCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ServeyGroupId { get; set; }
        public string SurveyName { get; set; }
        public bool? IsActive { get; set; }
        public string ServeyGroupName { get; set; }

    }
}
