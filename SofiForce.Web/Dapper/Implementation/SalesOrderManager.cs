using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using SofiForce.Models.StatisticalModels;
using System.Collections.Generic;
using Models;
using static SofiForce.Web.Common.DateTimExtensions;
using SofiForce.Web.Common;

namespace SofiForce.Web.Dapper.Implementation
{
    public class SalesOrderManager : ISalesOrderManager
    {

        private readonly DapperContext _context;
        public SalesOrderManager(DapperContext context)
        {
            _context = context;
        }

        public int UpdateOnhand(double SalesId, bool IsOpen)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var param = new
                    {
                        @SalesId = SalesId
                    };

                    if (IsOpen == true)
                    {
                        return connection.Execute("Batch_SalesOrder_updateOnhand_Order_Open", param, commandType: CommandType.StoredProcedure);

                    }
                    else
                    {
                        return connection.Execute("Batch_SalesOrder_updateOnhand_Order", param, commandType: CommandType.StoredProcedure);

                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<SalesOrderListModel> filter(SalesOrderSearchModel searchModel, int AppRoleId, int UserId, string Branchs, string convertedString, int SalesOrderTypeId, bool IsDeleted, string orderTermBy, int CashDiscountTotal)
        {
            var model = new List<SalesOrderListModel>();
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new
                    {

                        @PageNumber = searchModel.Skip + 1 ,
                        @PageSize = searchModel.Take,
                        @Branches = Branchs,
                        @UserId = UserId,
                        @AppRoleId = AppRoleId,
                        @IsDeleted = IsDeleted.ToString() ?? "",
                        @SalesOrderTypeId = SalesOrderTypeId,
                        @SearchTermBy = searchModel.TermBy,
                        @Term = searchModel.Term,
                        @BranchId = searchModel.BranchId ?? 0,
                        @ClientId = searchModel.ClientId ?? 0,
                        @StoreId = searchModel.StoreId ?? 0,
                        @SalesOrderStatusId = searchModel.SalesOrderStatusId ?? 0,
                        @PriorityTypeId = searchModel.PriorityTypeId ?? 0,
                        @IsInvoiced = searchModel.IsInvoiced.ToString()?? "",
                        @SalesDate = searchModel.SalesDate != null ? searchModel.SalesDate.Value.ToString("yyyy-MM-dd") : "",
                        @RepresentativeId = searchModel.RepresentativeId ?? 0,
                        @ConvertedString = convertedString,
                        @CashDiscountTotal = CashDiscountTotal,
                        @SortByTerm = orderTermBy,
                        @SortDirection = searchModel.SortBy.Order ?? "",


                    };
                    model = connection.Query<SalesOrderListModel>("GetSalesOrdersData", param,
                        commandType: CommandType.StoredProcedure,
                        commandTimeout: 120)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return model;
        }

    }
}
