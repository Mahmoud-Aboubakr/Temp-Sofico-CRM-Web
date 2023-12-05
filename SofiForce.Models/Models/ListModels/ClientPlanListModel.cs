using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientPlanListModel
    {
		public Int32? ClientId { get; set; }
		public string ClientCode { get; set; }
		public string ClientName { get; set; }
		public Int32? BranchId { get; set; }
		public string BranchName { get; set; }
		public string BranchCode { get; set; }
		public Int32? ClientGroupId { get; set; }
		public string ClientGroupCode { get; set; }
		public string ClientGroupName { get; set; }
		public decimal? CreditLimit { get; set; }
		public decimal? CreditBalance { get; set; }
		public Int64? PlanId { get; set; }
		public decimal? TargetValue { get; set; }
		public Int32? TargetVisit { get; set; }
		public Int32? TargetCall { get; set; }
		public DateTime? TargetDate { get; set; }
	}
}
