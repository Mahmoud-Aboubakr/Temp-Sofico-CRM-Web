using SofiForce.Models.StatisticalModels;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface IJourneyPlanManager
    {
        public Task Upload(DataTable dt, int UserId);
        public Task clear();
        public Task duplicate(int UserId, int JourneyYear, int JourneyMonth);

    }
}
