using Models;
using SofiForce.Models.StatisticalModels;
using System;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface ISalesOrderManager
    {
        int UpdateOnhand(double SalesId,bool IsOpen);

    }
}
