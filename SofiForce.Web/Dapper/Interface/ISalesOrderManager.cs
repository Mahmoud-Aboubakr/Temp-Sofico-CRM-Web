using Models;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface ISalesOrderManager
    {
        int UpdateOnhand(double SalesId,bool IsOpen);

        public List<SalesOrderListModel> filter(SalesOrderSearchModel searchModel, int AppRoleId, int UserId, string Branchs, string convertedString, int SalesOrderTypeId, bool IsDeleted, string orderTermBy, int CashDiscountTotal);


    }
}
