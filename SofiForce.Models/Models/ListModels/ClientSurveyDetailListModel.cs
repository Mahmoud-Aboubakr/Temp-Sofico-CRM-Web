using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientSurveyDetailListModel
    {

        public long? ClientDetailId { get; set; }
        public long? ClientServeyId { get; set; }
        public int? SurveyDetailId { get; set; }
        public string SurveyQuestion { get; set; }
        public bool? IsMuliSelect { get; set; }

        public List<ClientSurveyDetailAnswerListModel> Answers { get; set; }=new List<ClientSurveyDetailAnswerListModel>();


    }
    public class ClientSurveyDetailAnswerListModel
    {
        public long ClientAnswerId { get; set; }
        public long ClientDetailId { get; set; }
        public int DetailAnswerId { get; set; }
        public string Answer { get; set; }
        public bool? IsSelected { get; set; }


    }
}
