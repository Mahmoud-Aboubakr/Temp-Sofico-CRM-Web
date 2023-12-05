using Models;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface IOrderMonitorManager
    {

        OrderMonitorModel getMonitor(int? BranchId,string lan);

      

    }
}
