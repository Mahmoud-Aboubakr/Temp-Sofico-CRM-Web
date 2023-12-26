using SofiForce.Models.Models.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SofiForce.Web.Dapper.Interface;

public interface IVisitRejectReason 
{

    Task<IEnumerable<GetVisitRejectReasonModel>> GetAllVisitRejectReasonASync();
    Task<GetVisitRejectReasonModel> GetVisitRejectReasonByIdAsync(int id);
    Task<int> CreateVisitRejectReasonAsync(CreateVisitRejectReasonModel entity, int userId);
    Task<bool> UpdateVisitRejectReasonAsync(UpdateVisitRejectReasonModel entity, int userId);
    Task<bool> DeleteVisitRejectReasonAsync(int id);
}
