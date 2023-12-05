using System;

namespace Models
{
    public class SurveyDetailAnswerModel
    {
        public int DetailAnswerId { get; set; }
        public int? SurveyDetailId { get; set; }
        public int? SurveyId { get; set; }
        public string AnswerEn { get; set; }
        public string AnswerAr { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
