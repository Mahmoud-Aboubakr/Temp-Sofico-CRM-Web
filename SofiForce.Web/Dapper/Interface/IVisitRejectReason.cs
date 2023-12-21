using SofiForce.Models.Models.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SofiForce.Web.Dapper.Interface;

public interface IVisitRejectReason 
{
    Task<IEnumerable<VisitRejectReasonModel>> GetAllVisitRejectReasonASync();
    Task<VisitRejectReasonModel> GetVisitRejectReasonByIdAsync(int id);
    Task<int> CreateVisitRejectReasonAsync(VisitRejectReasonModel2 entity, int userId);
    Task<bool> UpdateVisitRejectReasonAsync(VisitRejectReasonModel2 entity, int userId);
    Task<bool> DeleteVisitRejectReasonAsync(int id);
}
