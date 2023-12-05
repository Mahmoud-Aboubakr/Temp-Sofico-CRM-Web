using System;
using System.Collections.Generic;

namespace SofiForce.Models.StatisticalModels
{
    public class SalesRepresentativeControlModel
    {
        public int ClientCoverage { get; set; }
        public int Orders { get; set; }
        public DateTime? SalesDate { get; set; }
        public int SalesDays { get; set; }
        public long SalesValue { get; set; }
        public int ClientAll { get; set; }
        public int TargetCall { get; set; }
        public long TargetValue { get; set; }
        public int TargetVisit { get; set; }
        public int callAll { get; set; }
        public int CallNegative { get; set; }
        public int CallPostitive { get; set; }
        public int VisitAll { get; set; }
        public int VisitNegative { get; set; }
        public int VisitPostitive { get; set; }

        public decimal SalesPercentage { get; set; }
        public decimal VisitPercentage { get; set; }
        public decimal CallPercentage { get; set; }
        public decimal PerormancePercentage { get; set; }

        public string PerormanceLabel { get; set; }

        public IEnumerable<SalesRepresentativeControlDetailModel> SalesControlDetails { get; set; } = new List<SalesRepresentativeControlDetailModel>();

    }

    public class SalesRepresentativeControlDetailModel
    {

        public int RepresentativeId { get; set; }
        public string BranchCode { get; set; }
        public int UserId   { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }
        public bool IsActive { get; set; }

        public int SupervisorId { get; set; }
        public string KindName { get; set; }

        public int ClientCoverage { get; set; }
        public int Orders { get; set; }
        public DateTime? SalesDate { get; set; }
        public int SalesDays { get; set; }
        public long SalesValue { get; set; }
        public int ClientAll { get; set; }
        public int TargetCall { get; set; }
        public long TargetValue { get; set; }
        public int TargetVisit { get; set; }
        public int callAll { get; set; }
        public int CallNegative { get; set; }
        public int CallPostitive { get; set; }
        public int VisitAll { get; set; }
        public int VisitNegative { get; set; }
        public int VisitPostitive { get; set; }

        public decimal SalesPercentage { get; set; }
        public decimal VisitPercentage { get; set; }
        public decimal CallPercentage { get; set; }
        public decimal PerormancePercentage { get; set; }

        public string PerormanceLabel { get; set; }

    }
}
