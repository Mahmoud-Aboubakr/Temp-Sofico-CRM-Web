using Models;
using SofiForce.Models.StatisticalModels;
using System;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface ISalesOrderControlManager
    {
        int markConfirm(string salesIds ,int UserId);
        int markTransfer(string salesIds, int UserId);
        
    }
}
