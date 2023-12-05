using System;
using System.Collections.Generic;

namespace SofiForce.Models.StatisticalModels
{


    public class SalesClientControlModel
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


        public IEnumerable<SalesClientControlDetailModel> SalesControlDetails { get; set; } = new List<SalesClientControlDetailModel>();

    }

    public class SalesClientControlDetailModel
    {


        public int BranchId { get; set; }
        public int ClientId { get; set; }

        public string BranchCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientGroupName { get; set; }
        public bool IsActive { get; set; }

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
