using System;

namespace Models
{
    public class TempClientPlanModel
    {
        public string ClientCode { get; set; }
        public decimal? TargetValue { get; set; }
        public int? TargetVisit { get; set; }
        public int? TargetCall { get; set; }
    }
}
