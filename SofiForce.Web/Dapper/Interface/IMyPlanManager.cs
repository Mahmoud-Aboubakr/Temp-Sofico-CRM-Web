using SofiForce.Models.StatisticalModels;
using System;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface IMyPlanManager
    {
        MyPlanModel getMyPlan(int RepresentativeId, string lan, int? ClientId, DateTime from, DateTime to);
    }
}
