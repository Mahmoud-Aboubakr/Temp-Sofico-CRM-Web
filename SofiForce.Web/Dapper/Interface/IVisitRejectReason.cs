using SofiForce.Models.Models.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SofiForce.Web.Dapper.Interface;

public interface IVisitRejectReason 
{
    Task<IEnumerable<VisitRejectReasonModel>> GetAllVisitRejectReasonASync();
    Task<VisitRejectReasonModel> GetVisitRejectReasonByIdAsync(int id);
    Task<int> CreateVisitRejectReasonAsync(VisitRejectReasonModel entity);
    Task<bool> UpdateVisitRejectReasonAsync(VisitRejectReasonModel entity);
    Task<bool> DeleteVisitRejectReasonAsync(int id);
}
