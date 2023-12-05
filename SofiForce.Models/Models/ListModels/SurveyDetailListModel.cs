using System;
using System.Collections.Generic;

namespace Models
{
    public class SurveyDetailListModel
    {
        public string Id { get; set; }
        public int? SurveyDetailId { get; set; }
        public string SurveyQuestion { get; set; }
        public bool? IsMuliSelect { get; set; }

        public List<SurveyDetailAnswerListModel> Answers { get; set; }=new List<SurveyDetailAnswerListModel>();
        public int SelectedAnswerSingle { get; set; }
        public List<int> SelectedAnswerMulti { get; set; }

    }
    public class SurveyDetailAnswerListModel
    {
        public string Id { get; set; }
        public int? DetailAnswerId { get; set; }
        public string Answer { get; set; }
        public bool? IsSelected { get; set; }


    }
}
