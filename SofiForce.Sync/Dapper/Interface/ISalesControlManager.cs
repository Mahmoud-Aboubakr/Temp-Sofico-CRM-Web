using Models;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Sync.Dapper.Interface
{
    public interface ISalesControlManager
    {
        SalesBranchControlModel getBranch(string lan, string BranchId, DateTime from, DateTime to);
        SalesSupervisorControlModel getSupervisor(string lan, string BranchId, int? Supervisor, DateTime from, DateTime to);
        SalesRepresentativeControlModel getRepresentative(string lan, string BranchId, int? Supervisor, int? RepresentativeId, DateTime from, DateTime to);

        List<PerformanceSalesmanModel> getPerformanceSalesman(string lan, string BranchId, int? Supervisor, int? RepresentativeId, DateTime from, DateTime to);
        PerformanceClientModel getPerformanceClient(string lan, int? RepresentativeId, DateTime from, DateTime to);
    }
}
