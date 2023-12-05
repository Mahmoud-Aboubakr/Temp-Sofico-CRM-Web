using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Models.StatisticalModels;
using SofiForce.Models.SyncModels;
using SofiForce.Promotion;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using SofiForce.Models.StatisticalModels;
using SofiForce.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class SyncController : BaseController
    {
        private const double V = 64.50;
        private readonly IPromotionCalculator promotionCalculator;
        private readonly IWebHostEnvironment _env;
        private readonly ISalesControlManager iSalesControlManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IOrderLoggerService orderLoggerService;

        public SyncController(
            IPromotionCalculator promotionCalculator,
            IHttpContextAccessor contextAccessor, IWebHostEnvironment env, ISalesControlManager ISalesControlManager, IConfiguration configuration, IMapper mapper, IOrderLoggerService orderLoggerService) : base(contextAccessor)
        {
            this.promotionCalculator = promotionCalculator;
            _env = env;
            iSalesControlManager = ISalesControlManager;
            _configuration = configuration;
            _mapper = mapper;
            this.orderLoggerService = orderLoggerService;
        }

        [HttpGet("SalesOrderType")]
        public async Task<IActionResult> SalesOrderType()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                try
                {

                    responseModel.Data = new List<LookupModel>();
                    responseModel.Data=new Criteria<BOSalesOrderType>()
                                            .List<BOSalesOrderType>()
                                            .Select(a=> new LookupModel()
                                            {
                                                Id=a.SalesOrderTypeId.Value,
                                                Code=a.SalesOrderTypeCode,
                                                ParentId=0,
                                                Name=Language=="ar"?a.SalesOrderTypeNameAr:a.SalesOrderTypeNameEn

                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpGet("Client")]
        public async Task<IActionResult> Client(int BranchId)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientSyncModel>> responseModel = new ResponseModel<List<ClientSyncModel>>();

                try
                {

                    responseModel.Data = new List<ClientSyncModel>();

                    // get routes
                    var RouteId = new Criteria<BORepresentativeJourneyVw>()
                                .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.ReprestitiveUserId), UserId))
                                .List<BORepresentativeJourneyVw>()
                                .Select(a => a.RouteId)
                                .ToList();


                    // get CLients routes
                    var ClientIdRange = new Criteria<BOClientRoute>()
                                  .Add(Expression.In(nameof(BOClientRoute.RouteId), string.Join(',', RouteId)))
                                  .Add(new Projection(nameof(BOClientRoute.ClientId)));


                    
                    responseModel.Data = new Criteria<BOClientVw>()
                                            .Add(Expression.Eq(nameof(BOClientVw.IsActive), true))
                                            .Add(Expression.InSubQuery(nameof(BOClientVw.ClientId), ClientIdRange))
                                            .List<BOClientVw>()
                                            .Select(a => new ClientSyncModel()
                                            {
                                                
                                                ClientCode = a.ClientCode,
                                                ClientId = a.ClientId.Value,
                                                Latitude = a.Latitude,
                                                Longitude = a.Longitude,
                                                CreditBalance = a.CreditBalance,
                                                CreditLimit = a.CreditLimit,
                                                IsTaxable = a.IsTaxable,
                                                Mobile = a.Mobile,
                                                Phone = a.Phone,
                                                WhatsApp = a.WhatsApp,
                                                Address="",
                                                ClientName=Language=="ar"?a.ClientNameAr:a.ClientNameEn

                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpGet("VisitDays")]
        public async Task<IActionResult> VisitDays()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientVisitPlan>> responseModel = new ResponseModel<List<ClientVisitPlan>>();

                try
                {

                    responseModel.Data = new List<ClientVisitPlan>();

                    // get routes
                    var RouteId = new Criteria<BORepresentativeJourneyVw>()
                                .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.ReprestitiveUserId), UserId))
                                .List<BORepresentativeJourneyVw>()
                                .Select(a => a.RouteId)
                                .ToList();


                    // get CLients routes
                    var ClientIdRange = new Criteria<BOClientRoute>()
                                  .Add(Expression.In(nameof(BOClientRoute.RouteId), string.Join(',', RouteId)))
                                  .Add(new Projection(nameof(BOClientRoute.ClientId)));



                    responseModel.Data = new Criteria<BOClientRoute>()
                                            .Add(Expression.InSubQuery(nameof(BOClientRoute.ClientId), ClientIdRange))
                                            .List<BOClientRoute>()
                                            .Select(a => new ClientVisitPlan()
                                            {
                                               ClientId = a.ClientId,
                                               Day1 = a.Day1,
                                               Day2 = a.Day2,
                                               Day3 = a.Day3,
                                               Day4 =a.Day4,
                                               Day5 = a.Day5,
                                               Day6 = a.Day6,
                                               Day7 = a.Day7,
                                               ClientRouteId = a.ClientRouteId
                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpGet("Invoices")]
        public async Task<IActionResult> Invoices()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<InvoiceSyncModel>> responseModel = new ResponseModel<List<InvoiceSyncModel>>();

                try
                {

                    responseModel.Data = new List<InvoiceSyncModel>();

                    // get routes
                    var RouteId = new Criteria<BORepresentativeJourneyVw>()
                                .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.ReprestitiveUserId), UserId))
                                .List<BORepresentativeJourneyVw>()
                                .Select(a => a.RouteId)
                                .ToList();


                    // get CLients routes
                    var ClientIdRange = new Criteria<BOClientRoute>()
                                  .Add(Expression.In(nameof(BOClientRoute.RouteId), string.Join(',', RouteId)))
                                  .Add(new Projection(nameof(BOClientRoute.ClientId)));



                    responseModel.Data = new Criteria<BOSalesOrderVw>()
                                            .Add(Expression.InSubQuery(nameof(BOSalesOrderVw.ClientId), ClientIdRange))
                                            .Add(Expression.Gte(nameof(BOSalesOrderVw.SalesOrderStatusId), 4))
                                            .Add(Expression.Gte(nameof(BOSalesOrderVw.InvoiceDate), DateTime.Now.FirstDayOfMonth()))
                                            .List<BOSalesOrderVw>()
                                            .Select(a => new InvoiceSyncModel()
                                            {
                                               
                                                ClientId = a.ClientId,
                                                InvoiceCode = a.InvoiceCode,
                                                InvoiceDate = a.InvoiceDate,
                                                NetTotal = (double?)a.NetTotal,
                                                TaxTotal=(double?)a.TaxTotal,
                                                CashDiscountTotal=(double?)a.CashDiscountTotal,
                                                ItemTotal=(double?)a.ItemTotal,
                                                ItemDiscountTotal=(double?)a.ItemDiscountTotal,
                                                SalesId = a.SalesId.Value,
                                                ClientCode=a.ClientCode,
                                                ClientName= Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                                SalesOrderTypeName = Language == "ar" ? a.SalesOrderTypeNameAr : a.SalesOrderTypeNameEn,
                                                PaymentTermName= Language == "ar" ? a.PaymentTermNameAr : a.PaymentTermNameEn,
                                                

                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpGet("InvoiceItems")]
        public async Task<IActionResult> InvoiceItems()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<InvoiceDetailSyncModel>> responseModel = new ResponseModel<List<InvoiceDetailSyncModel>>();

                try
                {

                    responseModel.Data = new List<InvoiceDetailSyncModel>();

                    // get routes
                    var RouteId = new Criteria<BORepresentativeJourneyVw>()
                                .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.ReprestitiveUserId), UserId))
                                .List<BORepresentativeJourneyVw>()
                                .Select(a => a.RouteId)
                                .ToList();


                    // get CLients routes
                    var ClientIdRange = new Criteria<BOClientRoute>()
                                  .Add(Expression.In(nameof(BOClientRoute.RouteId), string.Join(',', RouteId)))
                                  .Add(new Projection(nameof(BOClientRoute.ClientId)));



                    responseModel.Data = new Criteria<BOSalesOrderDetailWithHeaderVw>()
                                            .Add(Expression.InSubQuery(nameof(BOSalesOrderDetailWithHeaderVw.ClientId), ClientIdRange))
                                            .Add(Expression.Gte(nameof(BOSalesOrderDetailWithHeaderVw.SalesOrderStatusId), 4))
                                            .Add(Expression.Gte(nameof(BOSalesOrderDetailWithHeaderVw.InvoiceDate), DateTime.Now.FirstDayOfMonth()))
                                            .List<BOSalesOrderDetailWithHeaderVw>()
                                            .Select(a => new InvoiceDetailSyncModel()
                                            {
                                                
                                                ClientPrice = (double?)a.ClientPrice,
                                                DetailId = a.DetailId,
                                                Discount = (double?)a.Discount,
                                                IsBouns = a.IsBouns,
                                                ItemCode = a.ItemCode,
                                                ItemId = a.ItemId,
                                                ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                                                BatchNo = a.Batch,
                                                ExpireDate = a.Expiration,
                                                LineValue = (double?)a.LineValue,
                                                PublicPrice = (double?)a.PublicPrice,
                                                Quantity = a.Quantity,
                                                SalesId = a.SalesId,
                                                TaxValue = (double?)a.TaxValue,
                                                VendorCode = a.VendorCode,
                                                VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
                                                ItemStoreId =(int?) a.ItemStoreId,
                                                
                                                
                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpGet("Item")]
        public async Task<IActionResult> Item()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ItemSyncModel>> responseModel = new ResponseModel<List<ItemSyncModel>>();

                try
                {


                    var ctr = new Criteria<BOItemTotalVw>();


                    ctr.Add(Expression.Eq(nameof(BOItemTotalVw.IsActive), true));
                    ctr.Add(Expression.Gt(nameof(BOItemTotalVw.Quantity), 0));
                    ctr.Add(Expression.In(nameof(BOItemTotalVw.StoreId), Stores));



                    ctr.Add(OrderBy.Desc(nameof(BOItemTotalVw.ItemId)));


                    // get All

                    var res = ctr.List<BOItemTotalVw>()
                                 .Select(a => new ItemSyncModel()
                                 {
                                     ClientPrice =(double?) a.ClientPrice,
                                     Discount = (double?)a.Discount,
                                     HasPromotion = a.HasPromotion,
                                     IsActive = a.IsActive,
                                     IsNewAdded = a.IsNewAdded,
                                     IsNewStocked = a.IsNewStocked,
                                     IsTaxable = a.IsTaxable,
                                     ItemCode = a.ItemCode,
                                     ItemId = a.ItemId,
                                     PublicPrice = (double?)a.PublicPrice,
                                     VendorId = a.VendorId,
                                     UnitId = a.UnitId,
                                     CreateDate=DateTime.Now,
                                     HasQuota=a.Quota>0?true:false,
                                     LastStockDate=DateTime.Now,
                                     VendorCode=a.VendorId.ToString(),
                                     VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
                                     ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                                     Quantity = a.Available>0?a.Available.Value:0,

                                 }).ToList();


                    

                    responseModel.Data = res;
                    responseModel.Total = res.Count;
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message; ;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpGet("ItemStore")]
        public async Task<IActionResult> ItemStore(int StoreId)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ItemStoreSyncModel>> responseModel = new ResponseModel<List<ItemStoreSyncModel>>();

                try
                {

                    responseModel.Data = new Criteria<BOItemStoreVw>()
                                            .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), StoreId))
                                            .Add(Expression.Eq(nameof(BOItemStoreVw.IsActive), true))
                                            .Add(Expression.Gt(nameof(BOItemStoreVw.Quantity), 0))
                                            .List<BOItemStoreVw>()
                                            .Select(a => new ItemStoreSyncModel()
                                            {
                                                ItemId = a.ItemId,
                                                BatchNo = a.BatchNo,
                                                Available = a.Available,
                                                ExpireDate = a.ExpireDate,
                                                ItemStoreId = a.ItemStoreId,
                                                OnHand = a.OnHand,
                                                Quantity = a.Quantity,
                                                

                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpGet("SalesOrderStatus")]
        public async Task<IActionResult> SalesOrderStatus()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                try
                {

                    responseModel.Data = new List<LookupModel>();
                    responseModel.Data = new Criteria<BOSalesOrderStatus>()
                                            .List<BOSalesOrderStatus>()
                                            .Select(a => new LookupModel()
                                            {
                                                Id = a.SalesOrderStatusId.Value,
                                                Code = a.SalesOrderStatusCode,
                                                ParentId = 0,
                                                Name = Language == "ar" ? a.SalesOrderStatusNameAr : a.SalesOrderStatusNameEn

                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpGet("SalesOrderSource")]
        public async Task<IActionResult> SalesOrderSource()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                try
                {

                    responseModel.Data = new List<LookupModel>();
                    responseModel.Data = new Criteria<BOSalesOrderSource>()
                                            .List<BOSalesOrderSource>()
                                            .Select(a => new LookupModel()
                                            {
                                                Id = a.SalesOrderSourceId.Value,
                                                Code = a.SalesOrderSourceCode,
                                                ParentId = 0,
                                                Name = Language == "ar" ? a.SalesOrderSourceNameAr : a.SalesOrderSourceNameEn

                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpGet("PaymentTerm")]
        public async Task<IActionResult> PaymentTerm()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                try
                {

                    responseModel.Data = new List<LookupModel>();
                    responseModel.Data = new Criteria<BOPaymentTerm>()
                                            .List<BOPaymentTerm>()
                                            .Select(a => new LookupModel()
                                            {
                                                Id = a.PaymentTermId.Value,
                                                Code = a.PaymentTermCode,
                                                ParentId = 0,
                                                Name = Language == "ar" ? a.PaymentTermNameAr : a.PaymentTermNameEn

                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpGet("PriorityType")]
        public async Task<IActionResult> PriorityType()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                try
                {

                    responseModel.Data = new List<LookupModel>();
                    responseModel.Data = new Criteria<BOPriority>()
                                            .List<BOPriority>()
                                            .Select(a => new LookupModel()
                                            {
                                                Id = a.PriorityId.Value,
                                                Code = a.PriorityCode,
                                                ParentId = 0,
                                                Name = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn

                                            }).ToList();

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpGet("salesKBI")]
        public async Task<IActionResult> salesKBI()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepKBIModel> responseModel = new ResponseModel<RepKBIModel>();

                try
                {

                    responseModel.Data = new RepKBIModel();

                    var bo = new BORepresentative(RepresentativeId);

                    var res = iSalesControlManager.getPerformanceSalesman(Language, Branchs, bo.SupervisorId, bo.RepresentativeId, DateTime.Now.FirstDayOfMonth(), DateTime.Now);
                    
                    if (res.Count > 0)
                    {

                        responseModel.Data.Sales.Target = (double)res[0].TargetValue;
                        responseModel.Data.Sales.Value = (double)res[0].RouteSales;
                        if (res[0].TargetValue > 0)
                        {
                            responseModel.Data.Sales.Percentage = Math.Round((double)res[0].RouteSales/ (double)res[0].TargetValue*100,0);
                            if (responseModel.Data.Sales.Percentage > 100)
                                responseModel.Data.Sales.Percentage = 100;
                        }
                        
                    }
                    else
                    {
                        responseModel.Data.Sales.Target = 0;
                        responseModel.Data.Sales.Value = 0;
                        responseModel.Data.Sales.Percentage = 0;
                    }

                    return responseModel;
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpGet("PromotionDetails")]
        public async Task<IActionResult> PromotionDetails()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ItemPromotionOutComeModel>> responseModel = new ResponseModel<List<ItemPromotionOutComeModel>>();

                try
                {


                    var res = new Criteria<BOPromotionOutcomeVw>()
                                .Add(Expression.Eq(nameof(BOPromotionOutcomeVw.PromotionCategoryId), 1))
                                .Add(Expression.Lte(nameof(BOPromotionOutcomeVw.ValidFrom), DateTime.Now, dateformatter))
                                .Add(Expression.Gte(nameof(BOPromotionOutcomeVw.ValidTo), DateTime.Now, dateformatter))
                                .Add(Expression.Eq(nameof(BOPromotionOutcomeVw.IsActive), true))
                                .Add(Expression.Eq(nameof(BOPromotionOutcomeVw.IsApproved), true))
                                .Add(OrderBy.Desc(nameof(BOPromotionOutcomeVw.PromotionCategoryId)))
                                .Add(OrderBy.Asc(nameof(BOPromotionOutcomeVw.Priority)))
                                .List<BOPromotionOutcomeVw>()
                                .Select(a => new ItemPromotionOutComeModel()
                                {

                                    ItemCode = a.ItemCode,
                                    ItemId=a.ItemId.Value,
                                    ItemName=Language=="ar"?a.ItemNameAr:a.ItemNameEn,
                                    Value=a.Value,
                                    OutcomeId=a.OutcomeId.Value,
                                    PromotionId=a.PromotionId.Value,   
                                    Slice=a.Slice,
                                    
                                })
                                .ToList();



                    responseModel.Data = res;
                    responseModel.Total = res.Count;

                    return responseModel;
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 503;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpPost("saveOrder")]
        public async Task<IActionResult> saveOrder(SalesOrderMobileModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderMobileModel> responseModel = new ResponseModel<SalesOrderMobileModel>();

                if (model == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.Data = model;
                    return responseModel;
                }
                if (model.ClientId==null || model.ClientId==0)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Please Select Client";
                    responseModel.Data = model;
                    responseModel.StatusCode = 503;

                    return responseModel;
                }
                if (model.BranchId == null || model.BranchId == 0)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Please Select Branch";
                    responseModel.Data = model;
                    responseModel.StatusCode = 503;

                    return responseModel;
                }
                if (model.RepresentativeId == null || model.RepresentativeId == 0)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Please Select Representative";
                    responseModel.Data = model;
                    responseModel.StatusCode = 503;
                    return responseModel;
                }
                if (model.StoreId == null || model.StoreId == 0)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Please Select Store";
                    responseModel.Data = model;
                    responseModel.StatusCode = 503;

                    return responseModel;
                }

                try
                {

                    //model = PromotionCalculator.CaluclucateTotals(model);
                    var bo = new Criteria<BOSalesOrder>()
                    .Add(Expression.Eq(nameof(BOSalesOrder.SalesId), model.SalesId))
                    .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                    .FirstOrDefault<BOSalesOrder>();

                    if (bo == null)
                        bo = new BOSalesOrder();

                    bo.ClientId = model.ClientId;
                    bo.BranchId = model.BranchId;
                    bo.AgentId = UserId;
                    bo.SalesOrderTypeId = 1;
                    bo.RepresentativeId = model.RepresentativeId;
                    bo.StoreId = model.StoreId;
                    bo.PriorityTypeId = 1;
                    bo.IsDeleted = false;
                    var PaymentTermId = new BOClient(bo.ClientId.Value).PaymentTermId;
                    if (PaymentTermId > 0)
                    {
                        bo.PaymentTermId = PaymentTermId;
                    }
                    else
                    {
                        bo.PaymentTermId = 1;
                    }

                    bo.SalesDate = model.SalesDate != null ? model.SalesTime : DateTime.Now;
                    bo.SalesTime = model.SalesTime != null ? model.SalesTime : DateTime.Now;

                    if (bo.SalesDate.Value.Date < DateTime.Now.Date)
                    {
                        bo.SalesDate = DateTime.Now;
                        bo.SalesTime = DateTime.Now;
                    }

                    bo.SalesOrderStatusId = 1;
                    bo.SalesOrderSourceId = 1;
                    bo.Latitude = model.Latitude;
                    bo.Longitude = model.Longitude;
                    bo.ItemTotal = (decimal?)model.ItemTotal;
                    bo.ItemDiscountTotal = (decimal?)model.ItemDiscountTotal;
                    bo.CustomDiscountTotal = (decimal?)model.CustomDiscountTotal;
                    bo.TaxTotal = (decimal?)model.TaxTotal;
                    bo.CashDiscountTotal = (decimal?)model.CashDiscountTotal;
                    bo.NetTotal = (decimal?)model.NetTotal;
                    bo.Notes = model.Notes;
                    bo.InvoiceRetry = 0;
                    bo.IsInvoiced = null;
                    bo.HasError = false;
                    bo.InvoiceCode = string.Empty;
                    bo.InvoiceDate = null;

                    if (bo.SalesId == null)
                    {
                        bo.IsBackoffice = false;

                        bo.CBy = UserId;
                        bo.CDate = DateTime.Now;
                        bo.SaveNew();

                        var branch = new BOBranch(bo.BranchId.Value);
                        bo.SalesCode = string.Format(_configuration["settings:prefix:order"], bo.SalesId.Value.ToString().PadLeft(12, '0'));
                        bo.Update();

                       
                    }
                    else
                    {
                        bo.EBy = UserId;
                        bo.EDate = DateTime.Now;
                        bo.Update();
                    }

                    if (bo.SalesId > 0)
                    {
                        model.IsSynced = true;
                        model.SyncDate = DateTime.Now;
                        model.SalesCode = bo.SalesCode;
                        model.SalesId = bo.SalesId;

                        bo.DeleteAllSalesOrderDetail();
                        bo.DeleteAllSalesOrderAddress();
                        bo.DeleteAllSalesOrderDispatch();
                        bo.DeleteAllSalesOrderError();

                        //add delivery address
                        var client = new BOClient(bo.ClientId.Value);
                        var address = new BOSalesOrderAddress();
                        address.SalesId = bo.SalesId;
                        address.RegionId = client.RegionId;
                        address.GovernerateId = client.GovernerateId;
                        address.CityId = client.CityId;
                        address.Building = client.Building;
                        address.Floor = client.Floor;
                        address.Property = client.Property;
                        address.Landmark = client.Landmark;
                        address.Address = client.Address;
                        address.Latitude = client.Latitude;
                        address.Longitude = client.Longitude;
                        address.Mobile = client.Mobile;
                        address.WhatsApp = client.WhatsApp;
                        address.Phone = client.Phone;
                        address.EBy = UserId;
                        address.EDate = DateTime.Now;
                        address.SaveNew();



                        if (model.SalesOrderDetails != null)
                        {
                            foreach (var item in model.SalesOrderDetails)
                            {
                                if (item.ItemId == 0)
                                    continue;

                                var detail = new BOSalesOrderDetail();
                                detail.SalesId = bo.SalesId;
                                detail.ItemId = item.ItemId;
                                detail.PublicPrice = (decimal?)item.PublicPrice;
                                detail.ClientPrice = (decimal?)item.ClientPrice;
                                detail.Quantity = item.Quantity;
                                detail.LineValue = (decimal?)item.LineValue;
                                detail.Discount = (decimal?)item.Discount;
                                detail.CustomDiscount = 0;
                                detail.TaxValue = (decimal?)item.TaxValue;
                                detail.IsBouns = item.IsBouns;
                                detail.PromotionCode = (item.IsBouns == true || item.Discount > 0) ? item.PromotionCode : "";
                                detail.Batch = item.Batch;
                                detail.Expiration = item.Expiration;
                                detail.ItemStoreId = item.ItemStoreId;
                                detail.UnitId = item.UnitId;
                                detail.RecId = 0;
                                detail.ReturnQuantity = 0;
                                detail.TotalReturn = 0;
                                detail.TotalReturn = 0;
                                detail.ReturnReasonId = null;

                                detail.SaveNew();

                                item.SalesId = detail.SalesId;
                            }
                        }



                        BOAppUserLocation location = new BOAppUserLocation();
                        location.UserId = UserId;
                        location.TrackingTypeId = 2;
                        location.TrackingDate = model.SalesTime != null ? model.SalesTime : DateTime.Now;
                        location.TrackingTime = model.SalesTime != null ? model.SalesTime : DateTime.Now;
                        location.Latitude = model.Latitude;
                        location.Longitude = model.Longitude;
                        location.IsPositive = true;
                        location.ClientId = model.ClientId;
                        location.SalesId = bo.SalesId;
                        location.SaveNew();


                        var user = new BOAppUser(UserId);
                        user.Latitude = model.Latitude;
                        user.Longitude = model.Longitude;
                        user.EDate = DateTime.Now;
                        user.EBy = UserId;
                        user.Update();

                    }
                    orderLoggerService.Log(bo.SalesId.Value, OrderLogType.Save, UserId);
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 500;
                    responseModel.Data = model;
                    return responseModel;
                }



                responseModel.Data = model;
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
        [HttpPost("calcPromo")]
        public async Task<IActionResult> calcPromo(SalesOrderMobileModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<SalesOrderMobileModel> responseModel = new ResponseModel<SalesOrderMobileModel>();


                if (model == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.Data = model;
                    return responseModel;
                }
                if (model.ClientId == null || model.ClientId == 0)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Please Select Client";
                    responseModel.Data = model;
                    responseModel.StatusCode = 503;

                    return responseModel;
                }
                if (model.BranchId == null || model.BranchId == 0)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Please Select Branch";
                    responseModel.Data = model;
                    responseModel.StatusCode = 503;

                    return responseModel;
                }
                if (model.RepresentativeId == null || model.RepresentativeId == 0)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Please Select Representative";
                    responseModel.Data = model;
                    responseModel.StatusCode = 503;
                    return responseModel;
                }
                if (model.StoreId == null || model.StoreId == 0)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Please Select Store";
                    responseModel.Data = model;
                    responseModel.StatusCode = 503;

                    return responseModel;
                }

                try
                {
                    var orderModel = new SalesOrderModelWeb()
                    {
                        Id = model.Id,
                        AgentId = UserId,
                        BranchId = model.BranchId,
                        ClientCode = model.ClientCode,
                        CashDiscountTotal = model.CashDiscountTotal,
                        ClientId = model.ClientId,
                        CustomDiscountTotal = model.CustomDiscountTotal,
                        DeliveryTotal = model.DeliveryTotal,
                        Errors =new List<string>(),
                        HasError = false,
                        IsInvoiced = null,
                        Warnings = new List<string>(),
                        TaxTotal = model.TaxTotal,
                        SyncDate = model.SyncDate,
                        StoreId = model.StoreId,
                        SalesTime = model.SalesTime,
                        RepresentativeId = model.RepresentativeId,
                        SalesOrderTypeId = 1,
                        SalesOrderStatusId = 1,
                        SalesOrderSourceId = 1,
                        SalesId = model.SalesId,
                        PriorityTypeId = 1,
                        SalesDate = model.SalesDate,
                        SalesOrderDetails = model.SalesOrderDetails.Select(a => new SalesOrderDetailListModel()
                        {
                            Availability = a.Availability,
                            Batch = a.Batch,
                            CashDiscount = 0,
                            ClientId = 0,
                            ClientPrice = a.IsBouns!=true ? a.ClientPrice:0,
                            DetailId = a.DetailId,
                            Discount = a.Discount,
                            Expiration = a.Expiration,
                            Id = null,
                            IsBouns = a.IsBouns,
                            ItemId = a.ItemId,
                            HasPromotion = false,
                            CustomDiscount = 0,
                            InvoiceCode = "",
                            InvoiceDate = null,
                            ItemCode = a.ItemCode,
                            ItemGroupId = null,
                            ItemName = a.ItemName,
                            ItemStoreId = a.ItemStoreId,
                            LineValue = a.LineValue,
                            parentId = null,
                            PromotionCode = "",
                            PublicPrice = a.PublicPrice,
                            Quantity = a.Quantity,
                            ReturnQuantity = 0,
                            SalesId = a.SalesId,
                            TaxValue = a.TaxValue,
                            TotalReturn = 0,
                            UnitId = a.UnitId,
                            VendorCode = a.VendorCode,
                            VendorName = a.VendorName,
                            IsNewAdded = a.IsNewAdded,
                            IsNewStocked=a.IsNewStocked,
                            Quota=a.Quota,
                            

                        }).ToList(),
                        ItemTotal = model.ItemTotal,
                        Longitude = model.Longitude,
                        Latitude = model.Latitude,
                        PromotionOptions = new List<SalesOrderPromotionOptionModel>(),
                        StoreName="",
                        AgentName="",
                        BranchName="",
                        ClientName=model.ClientName,
                        CustomDiscountTypeId=null,
                        CustomDiscountValue=0,
                        InvoiceCode="",
                        InvoiceDate=null,
                        InvoiceRetry=0,
                        IsSynced=false,
                        NetTotal=model.NetTotal,
                        ItemDiscountTotal=model.ItemDiscountTotal,
                        Notes="",
                        PaymentTermId=null,
                        PaymentTermName="",
                        PriorityTypeName="",
                        RepresentativeName="",
                        SalesCode=model.SalesCode,
                        SalesOrderSourceName="",
                        SalesOrderStatusName="",
                        SalesOrderTypeName="",
                        SalesPerenId=null,
                    };
                    var res = await promotionCalculator.ValidateOrder(orderModel, Language);


                    if (res != null)
                    {
                        model.SalesOrderDetails.Clear();

                        model.ItemTotal = res.ItemTotal;
                        model.TaxTotal = res.TaxTotal;
                        model.CashDiscountTotal = res.CashDiscountTotal;
                        model.ItemDiscountTotal = res.ItemDiscountTotal;
                        model.CustomDiscountTotal = res.CustomDiscountTotal;
                        model.NetTotal = res.NetTotal;
                        model.HasError = res.HasError;
                        model.Errors = res.Errors;
                        model.SalesOrderDetails = res.SalesOrderDetails.Select(a => new SalesOrderDetailMobileListModel()
                        {
                            Availability = a.Availability>0?a.Availability:0,
                            Batch = a.Batch,
                            ClientPrice =a.IsBouns!=true? a.ClientPrice:0,
                            DetailId = a.DetailId,
                            Discount = a.Discount,
                            Expiration = a.Expiration,
                            IsBouns = a.IsBouns,
                            ItemCode = a.ItemCode,
                            ItemId = a.ItemId,
                            ItemName = a.ItemName,
                            ItemStoreId = a.ItemStoreId,
                            LineValue = a.LineValue,
                            PromotionCode = a.PromotionCode,
                            PublicPrice = a.PublicPrice,
                            Quantity = a.Quantity,
                            SalesId = a.SalesId,
                            TaxValue = a.TaxValue,
                            UnitId = a.UnitId,
                            VendorCode = a.VendorCode,
                            VendorName = a.VendorName,
                            HasPromotion=a.HasPromotion!=null,
                            IsNewAdded=a.IsNewAdded,
                            IsNewStocked=a.IsNewStocked,
                            Quota=a.Quota,

                        }).ToList();
                        model.PromotionOptions = res.PromotionOptions.Select(a => new SalesOrderPromotionMobileOptionModel()
                        {
                            ItemCode = a.ItemCode,
                            ItemName = a.ItemName,
                            PromotionId = a.PromotionId,
                            Quantity = a.Quantity,
                            RowId = a.RowId,
                            Selected = false,
                            Batchs = a.Batchs.Select(a => new SalesOrderDetailMobileListModel()
                            {
                                ItemStoreId=a.ItemStoreId,
                                Availability=a.Availability,
                                Batch=a.Batch,
                                ClientPrice=a.IsBouns!=true? a.ClientPrice:0,
                                DetailId=a.DetailId,
                                Discount=a.Discount,
                                Expiration=a.Expiration,
                                IsBouns=a.IsBouns,
                                ItemCode=a.ItemCode,
                                ItemId=a.ItemId,
                                ItemName=a.ItemName,
                                LineValue=a.LineValue,
                                PromotionCode=a.PromotionCode,
                                PublicPrice=a.PublicPrice,
                                Quantity=a.Quantity,
                                SalesId=a.SalesId,
                                TaxValue=a.TaxValue,
                                UnitId=a.UnitId,
                                VendorCode=a.VendorCode,
                                VendorName=a.VendorName

                            }).ToList(),

                        }).ToList();

                    }

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                    responseModel.StatusCode = 500;
                    responseModel.Data = model;
                    return responseModel;
                }

                if(model.Errors.Count>0 && model.HasError == true)
                {
                    responseModel.Message = model.Errors[0];
                }

                responseModel.Data = model;
                return responseModel;

            });
            await task;

            return Ok(task.Result.Result);
        }
    }
}
