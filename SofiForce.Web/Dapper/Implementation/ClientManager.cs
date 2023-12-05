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
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Bibliography;
using SofiForce.BusinessObjects;
using System.Drawing;
using System.Reflection;

namespace SofiForce.Web.Dapper.Implementation
{
    public class ClientManager : IClientManager
    {

        private readonly DapperContext _context;
        public ClientManager(DapperContext context)
        {
            _context = context;
        }




        public List<ClientListModel> filter(ClientSearchModel searchModel, int UserId, int AppRoleId,string Branches)
        {
            List<ClientListModel> model = new List<ClientListModel>();
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new
                    {
                        @Branches = Branches,
                        @UserId = UserId,
                        @ClientCode = searchModel.ClientCode,
                        @AppRoleId = AppRoleId,
                        @PageNumber = searchModel.Skip+1,
                        @PageSize = searchModel.Take,
                        @Phone = searchModel.Phone,
                        @WhatsApp = searchModel.WhatsApp,
                        @Mobile = searchModel.Mobile,
                        @TaxCode = searchModel.TaxCode,
                        @CommercialCode = searchModel.CommercialCode,
                        @IsActive = searchModel.IsActive==0 ? "" : searchModel.IsActive.ToString(),
                        @IsTaxable = searchModel.IsTaxable==0 ? "" : searchModel.IsTaxable.ToString(),
                        @IsChain = searchModel.IsChain == 0 ? "" : searchModel.IsChain.ToString(),
                        @LocationLevelId = searchModel.LocationLevelId,
                        @ClientClassificationId = searchModel.ClientClassificationId,
                        @PaymentTermId = searchModel.PaymentTermId,
                        @BranchId = searchModel.BranchId,
                        @ClientTypeId = searchModel.ClientTypeId,
                        @RegionId = searchModel.RegionId,
                        @GovernerateId = searchModel.GovernerateId,
                        @CityId = searchModel.CityId,
                        @ClientGroupId = searchModel.ClientGroupId,
                        @BusinessUnitId = searchModel.BusinessUnitId,
                        @InRoute = searchModel.InRoute == 0 ? "" : searchModel.InRoute.ToString(),
                        @NeedValidation = searchModel.NeedValidation == 0 ? "" : searchModel.NeedValidation.ToString(),
                        @IsNew = searchModel.IsNew == 0 ? "" : searchModel.IsNew.ToString(),
                        @OrderBy = searchModel.SortBy.Property,
                        @SortedDirection = searchModel.SortBy.Order,
                        @SearchTermBy =   searchModel.TermBy,
                        @Term   =   searchModel.Term,

                    };

                     model = connection.Query<ClientListModel>("GetClientData",param ,commandType: CommandType.StoredProcedure).ToList();

                    
                }
            }
            catch (Exception ex)
            {

            }


            return model;
        }


    }
}
