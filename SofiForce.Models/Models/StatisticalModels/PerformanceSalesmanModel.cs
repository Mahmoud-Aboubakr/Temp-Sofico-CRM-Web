using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PerformanceSalesmanModel
    {
        public int RepresentativeId { get; set; }
        public int? SupervisorId { get; set; }
        public int BranchId { get; set; }
        public bool? IsActive { get; set; }
        public string BranchCode { get; set; }
        public string CompanyCode { get; set; }
        public string RepresentativeCode { get; set; }
        public int? RouteId { get; set; }
        public string RouteCode { get; set; }
        public string KindName { get; set; }
        public string RepresentativeName { get; set; }
        public decimal RouteSales { get; set; }
        public long ClientCoverage { get; set; }
        public decimal TargetValue { get; set; }
        public int TargetCall { get; set; }
        public int TargetVisit { get; set; }
        public long RouteClient { get; set; }
        public int callAll { get; set; }
        public int CallInJourney { get; set; }
        public int CallInZone { get; set; }
        public int CallNegative { get; set; }
        public int CallPostitive { get; set; }
        public int CallOutJourney { get; set; }
        public int CallOutZone { get; set; }
        public int VisitAll { get; set; }
        public int VisitInJourney { get; set; }
        public int VisitInZone { get; set; }
        public int VisitNegative { get; set; }
        public int VisitPostitive { get; set; }
        public int VisitOutJourney { get; set; }
        public int VisitOutZone { get; set; }
        public decimal MySales { get; set; }
        public long MyOrders { get; set; }


        public decimal SalesPercentage { get; set; }
        public decimal VisitPercentage { get; set; }
        public decimal CallPercentage { get; set; }
        public decimal PerormancePercentage { get; set; }

        public string PerormanceLabel { get; set; }

    }

    public class PerformanceSalesmanDetailModel
    {
        

    }
}
