using System;

namespace Models
{
    public class SurveyDetailModel
    {
        public int SurveyDetailId { get; set; }
        public int? SurveyId { get; set; }
        public string SurveyQuestionEn { get; set; }
        public string SurveyQuestionAr { get; set; }
        public bool? IsMuliSelect { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
