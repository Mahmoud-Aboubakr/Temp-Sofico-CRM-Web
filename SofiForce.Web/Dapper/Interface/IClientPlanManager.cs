using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface IClientPlanManager
    {
        public Task Upload(DataTable dt, int UserId);
        public Task clear();
        public Task duplicate(int UserId, int PlanYear, int PlanMonth);

    }
}
