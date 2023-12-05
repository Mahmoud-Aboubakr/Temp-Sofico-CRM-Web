using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface IOperationRequestManager
    {
        void CreateValidationClients(int UserId,int OperationId, List<string> clients);
        void CreateValidationClient(int UserId, int OperationId, int ClientId);

    }
}
