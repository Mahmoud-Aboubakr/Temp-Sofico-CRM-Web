using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface IClientRouteManager
    {
        public Task Upload(DataTable dt, int UserId);

        public Task ClearAll();

    }
}
