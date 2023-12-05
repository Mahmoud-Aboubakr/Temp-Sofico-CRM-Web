using System;

namespace Models
{
    public class ClientPlanModel
    {
        public long PlanId { get; set; }
        public int? ClientId { get; set; }
        public string ClientCode { get; set; }
        public DateTime? TargetDate { get; set; }
        public decimal? TargetValue { get; set; }
        public int? TargetVisit { get; set; }
        public int? TargetCall { get; set; }

    }
}
