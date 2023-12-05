using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface IPromotionManager
    {
        public Task Upload(DataTable dt, int UserId);
        public Task UploadClients(DataTable dt,int clientAttributeId, int UserId);
        public Task UploadCutomItems(DataTable dt, int attributeId, int UserId);

        public Task ClearCustomClient( int clientAttributeId);
        public Task ClearCustomItem(int attributeId);


    }
}
