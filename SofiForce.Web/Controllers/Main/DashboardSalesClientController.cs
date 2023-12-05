using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class DashboardSalesClientController : BaseController
    {
        private IClientSalesManager _IClientSalesManager;
        public DashboardSalesClientController(IHttpContextAccessor contextAccessor, IClientSalesManager IClientSalesManager) : base(contextAccessor)
        {
            _IClientSalesManager = IClientSalesManager;

        }



        [HttpPost("all")]
        public async Task<IActionResult> all(DashboardSalesClientSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<ClientStatisticalModel> responseModel = new ResponseModel<ClientStatisticalModel>();
                try
                {

                    var timeLine = _IClientSalesManager.getSalesTimeline(DateTime.Now.FirstDayOfYear(), DateTime.Now,model.ClientId);
                    var performance = _IClientSalesManager.getPerformance(DateTime.Now.FirstDayOfYear(), DateTime.Now, model.ClientId);
                    var item = _IClientSalesManager.getItemSales(DateTime.Now.FirstDayOfYear(), DateTime.Now, model.ClientId.Value,Language);
                    var vendor = _IClientSalesManager.getVendorSales(DateTime.Now.FirstDayOfYear(), DateTime.Now, model.ClientId.Value,Language);




                    var Orders = new Criteria<BOSalesOrderVw>()
                                       .Add(Expression.Gte(nameof(BOSalesOrderVw.SalesDate), DateTime.Now.AddYears(-1)))
                                       .Add(Expression.Eq(nameof(BOSalesOrderVw.ClientId), model.ClientId))
                                       .Add(Expression.Eq(nameof(BOSalesOrderVw.IsDeleted), false))
                                       .List<BOSalesOrderVw>();



                    var Visits = new Criteria<BOClientActivityVw>()
                                        .Add(Expression.Gte(nameof(BOClientActivityVw.ActivityDate), DateTime.Now.AddYears(-1)))
                                        .Add(Expression.Eq(nameof(BOClientActivityVw.ClientId), model.ClientId))
                                        .Add(Expression.Eq(nameof(BOClientActivityVw.ActivityTypeId), 1))
                                        .List<BOClientActivityVw>();

                    var Calls = new Criteria<BOClientActivityVw>()
                                .Add(Expression.Gte(nameof(BOClientActivityVw.ActivityDate), DateTime.Now.AddYears(-1)))
                                .Add(Expression.Eq(nameof(BOClientActivityVw.ClientId), model.ClientId))
                                .Add(Expression.Eq(nameof(BOClientActivityVw.ActivityTypeId), 2))
                                .List<BOClientActivityVw>();


                    var Complains = new Criteria<BOClientComplainVw>()
                                    .Add(Expression.Gte(nameof(BOClientComplainVw.ComplainDate), DateTime.Now.AddYears(-1)))
                                    .Add(Expression.Eq(nameof(BOClientComplainVw.ClientId), model.ClientId))
                                    .List<BOClientComplainVw>();

                    var Requests = new Criteria<BOClientServiceRequestVw>()
                                        .Add(Expression.Gte(nameof(BOClientServiceRequestVw.RequestDate), DateTime.Now.AddYears(-1)))
                                        .Add(Expression.Eq(nameof(BOClientServiceRequestVw.ClientId), model.ClientId))
                                        .List<BOClientServiceRequestVw>();


                    var Surveis = new Criteria<BOClientSurveyVw>()
                                .Add(Expression.Gte(nameof(BOClientSurveyVw.StartDate), DateTime.Now.AddYears(-1)))
                                .Add(Expression.Eq(nameof(BOClientSurveyVw.ClientId), model.ClientId))
                                .List<BOClientSurveyVw>();


                    var Client = new Criteria<BOClientVw>()
                        .Add(Expression.Eq(nameof(BOClientVw.ClientId), model.ClientId))
                        .List<BOClientVw>();


                    responseModel.Data = new ClientStatisticalModel()
                    {
                        Timelines = timeLine,
                        PerfromanceModel = performance,
                        Items=item,
                        Vendors=vendor,
                        Calls = Calls.Select(a => new ClientActivityListModel()
                        {
                            ActivityId = a.ActivityId.Value,
                            ActivityDate = a.ActivityDate,
                            ActivityTime = a.ActivityTime,
                            ActivityTypeId = a.ActivityTypeId,
                            BranchCode = a.BranchCode,
                            BranchId = a.BranchId,
                            ClientCode = a.ClientCode,
                            ClientId = a.ClientId,
                            Distance = a.Distance,
                            Duration = a.Duration,
                            InJourney = a.InJourney,
                            IsPositive = a.IsPositive,
                            Latitude = a.Latitude,
                            Longitude = a.Longitude,
                            RepresentativeCode = a.RepresentativeCode,
                            RepresentativeId = a.RepresentativeId,
                            SalesId = a.SalesId,
                            CallAgain = a.CallAgain,
                            InZone = a.InZone,

                            BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                            RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,

                        }).ToList(),
                        Visits = Visits.Select(a => new ClientActivityListModel()
                        {
                            ActivityId = a.ActivityId.Value,
                            ActivityDate = a.ActivityDate,
                            ActivityTime = a.ActivityTime,
                            ActivityTypeId = a.ActivityTypeId,
                            BranchCode = a.BranchCode,
                            BranchId = a.BranchId,
                            ClientCode = a.ClientCode,
                            ClientId = a.ClientId,
                            Distance = a.Distance,
                            Duration = a.Duration,
                            InJourney = a.InJourney,
                            IsPositive = a.IsPositive,
                            Latitude = a.Latitude,
                            Longitude = a.Longitude,
                            RepresentativeCode = a.RepresentativeCode,
                            RepresentativeId = a.RepresentativeId,
                            SalesId = a.SalesId,
                            CallAgain = a.CallAgain,
                            InZone = a.InZone,

                            BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                            RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,

                        }).ToList(),

                        Complains = Complains.Select(a => new ClientComplainListModel()
                        {
                            ComplainId = a.ComplainId.Value,
                            PriorityId = a.PriorityId,
                            Phone = a.Phone,
                            ComplainTypeId = a.ComplainTypeId,
                            DepartmentId = a.DepartmentId,
                            ComplainStatusId = a.ComplainStatusId,
                            BranchId = a.BranchId,
                            ClientCode = a.ClientCode,
                            ClientId = a.ClientId,
                            ComplainTypeDetailId = a.ComplainTypeDetailId,
                            Duration = a.Duration,
                            IsClosed = a.IsClosed,
                            BranchCode = a.BranchCode,
                            CloseDate = a.CloseDate,
                            ComplainCode = a.ComplainCode,
                            ComplainDate = a.ComplainDate,
                            RepresentativeCode = a.RepresentativeCode,
                            RepresentativeId = a.RepresentativeId,
                            ComplainTime = a.ComplainTime,
                            PriorityColor = a.PriorityColor,
                            BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                            ComplainStatusName = Language == "ar" ? a.ComplainStatusNameAr : a.ComplainStatusNameEn,
                            ComplainTypeName = Language == "ar" ? a.ComplainTypeNameAr : a.ComplainTypeNameEn,
                            DepartmentName = Language == "ar" ? a.DepartmentNameAr : a.DepartmentNameEn,
                            PriorityName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                            RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,

                        }).ToList(),


                        Requests = Requests.Select(a => new ClientServiceRequestListModel()
                        {
                            RequestId = a.RequestId.Value,
                            PriorityId = a.PriorityId,
                            Phone = a.Phone,
                            RequestTypeId = a.RequestTypeId,
                            DepartmentId = a.DepartmentId,
                            RequestStatusId = a.RequestStatusId,
                            BranchId = a.BranchId,
                            ClientCode = a.ClientCode,
                            ClientId = a.ClientId,
                            RequestTypeDetailId = a.RequestTypeDetailId,
                            Duration = a.Duration,
                            IsClosed = a.IsClosed,
                            BranchCode = a.BranchCode,
                            CloseDate = a.CloseDate,
                            RequestCode = a.RequestCode,
                            RequestDate = a.RequestDate,
                            RepresentativeCode = a.RepresentativeCode,
                            RepresentativeId = a.RepresentativeId,
                            RequestTime = a.RequestTime,
                            PriorityColor = a.PriorityColor,
                            BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                            RequestStatusName = Language == "ar" ? a.RequestStatusNameAr : a.RequestStatusNameEn,
                            RequestTypeName = Language == "ar" ? a.RequestTypeNameAr : a.RequestTypeNameEn,
                            DepartmentName = Language == "ar" ? a.DepartmentNameAr : a.DepartmentNameEn,
                            PriorityName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                            RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,

                        }).ToList(),

                        Survies = Surveis.Select(a => new ClientSurveyListModel()
                        {
                            RepresentativeId = a.RepresentativeId,
                            CreateDate = a.CreateDate,
                            ClientTypeId = a.ClientTypeId,
                            BranchId = a.BranchId,
                            ClientCode = a.ClientCode,
                            ClientId = a.ClientId,
                            ClientServeyId = a.ClientServeyId,
                            CreateTime = a.CreateTime,
                            IsClosed = a.IsClosed,
                            RepresentativeCode = a.RepresentativeCode,
                            ServeyGroupId = a.ServeyGroupId,
                            ServeyStatusId = a.ServeyStatusId,
                            StartDate = a.StartDate,
                            SurveyId = a.SurveyId.Value,
                            StartTime = a.StartTime,
                            BranchCode = a.BranchCode,
                            ServeyStatusColor = a.ServeyStatusColor,
                            BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,

                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                            RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                            ServeyGroupName = Language == "ar" ? a.ServeyGroupNameAr : a.ServeyGroupNameEn,
                            ServeyStatusName = Language == "ar" ? a.ServeyStatusNameAr : a.ServeyStatusNameEn,
                            SurveyName = Language == "ar" ? a.SurveyNameAr : a.SurveyNameEn,

                        }).ToList(),
                        ClientModel = Client.Select(a => new ClientListModel()
                        {
                            BranchCode = a.BranchCode,

                            ClientAccountId = a.ClientAccountId,
                            ClientCode = a.ClientCode,
                            ClientId = a.ClientId.Value,
                            Latitude = a.Latitude,
                            Longitude = a.Longitude,
                            CreditBalance = a.CreditBalance,
                            CreditLimit = a.CreditLimit,
                            IsActive = a.IsActive,
                            IsTaxable = a.IsTaxable,
                            Mobile = a.Mobile,
                            Phone = a.Phone,
                            WhatsApp = a.WhatsApp,
                            BranchId = a.BranchId,
                            CityId = a.CityId,
                            ClientClassificationId = a.ClientClassificationId,
                            ClientGroupId = a.ClientGroupId,
                            ClientGroupSubId = a.ClientGroupSubId,
                            ClientTypeId = a.ClientTypeId,
                            GovernerateId = a.GovernerateId,
                            PaymentTermId = a.PaymentTermId,
                            RegionId = a.RegionId,
                            BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                            ClientTypeName = Language == "ar" ? a.ClientTypeNameAr : a.ClientTypeNameEn,
                            GovernerateName = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,
                            CityName = Language == "ar" ? a.CityNameAr : a.CityNameEn,

                        }).FirstOrDefault(),

                        Orders = Orders.Select(a => new SalesOrderListModel()
                        {

                            SalesCode = a.SalesCode,
                            BranchCode = a.BranchCode,
                            ClientCode = a.ClientCode,
                            ClientId = a.ClientId,
                            InvoiceCode = a.InvoiceCode,
                            InvoiceDate = a.InvoiceDate,
                            NetTotal = a.NetTotal,
                            RepresentativeCode = a.RepresentativeCode,
                            SalesDate = a.SalesDate,
                            SalesId = a.SalesId.Value,
                            IsInvoiced = a.IsInvoiced,
                            StoreCode = a.StoreCode,
                            SalesOrderStatusId = a.SalesOrderStatusId,
                            salesOrderTypeId = a.SalesOrderTypeId,
                            salesOrderSourceId = a.SalesOrderSourceId,
                            StoreName = Language == "ar" ? a.StoreNameAr : a.StoreNameEn,
                            BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                            PaymentTermName = Language == "ar" ? a.PaymentTermNameAr : a.PaymentTermNameEn,
                            RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                            SalesOrderSourceName = Language == "ar" ? a.SalesOrderSourceNameAr : a.SalesOrderSourceNameEn,
                            SalesOrderStatusName = Language == "ar" ? a.SalesOrderStatusNameAr : a.SalesOrderStatusNameEn,
                            SalesOrderTypeName = Language == "ar" ? a.SalesOrderTypeNameAr : a.SalesOrderTypeNameEn,
                            PriorityName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                            HasError = a.HasError,

                        }).ToList()

                    };
                
                    responseModel.Total = 1;

                }
                catch (Exception ex)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;;
                }


                return responseModel;
            });

            await task;
            return Ok(task.Result);
        }

    }
}
