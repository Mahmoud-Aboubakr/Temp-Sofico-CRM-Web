using AutoMapper;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Promotion;
using SofiForce.Web.Common;
using SofiForce.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SofiForce.Web.Dapper.Interface;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class ReturnOrderController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IOrderLoggerService orderLoggerService;
        private readonly IPromotionReturnCalculator promotionCalculator;
        private readonly ISalesOrderManager salesOrderManager;

        public ReturnOrderController(
            IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper, IOrderLoggerService orderLoggerService, IPromotionReturnCalculator promotionCalculator, ISalesOrderManager salesOrderManager ) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
            this.orderLoggerService = orderLoggerService;
            this.promotionCalculator = promotionCalculator;
            this.salesOrderManager = salesOrderManager;
        }


        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(SalesOrderSearchModel model)
        {


            ResponseModel<List<SalesOrderListModel>> responseModel = new ResponseModel<List<SalesOrderListModel>>();
            try
            {
                string convertedString = string.Empty;

                if (model.SalesOrderSourceId.Contains(1) || model.SalesOrderSourceId.Contains(2) || model.SalesOrderSourceId.Contains(3) || model.SalesOrderSourceId.Contains(4))
                {
                    var origin = string.Join(",", model.SalesOrderSourceId);
                    string[] splitElements = origin.Split(',');
                    convertedString = string.Join(",", Array.ConvertAll(splitElements, element => $"{element}"));

                }
                string branches = string.Empty;
                if (FullDataAccess == false)
                {
                    branches = this.Branchs;

                }
                string orderTermBy = string.Empty;
                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {
                    switch (model.SortBy.Property)
                    {
                        case "clientName":
                            orderTermBy = string.Format("clientName{0}", Language);
                            break;
                        case "representativeName":
                            orderTermBy = string.Format("representativeName{0}", Language);
                            break;
                        default:
                            orderTermBy = model.SortBy.Property;
                            break;
                    }
                }

                var res = salesOrderManager.filter(model,
                                                   AppRoleId,
                                                    UserId,
                                                    branches,
                                                    convertedString,
                                                    SalesOrderTypeId: 2,
                                                    IsDeleted: false,
                                                    orderTermBy
                                                    ,CashDiscountTotal: 0
                                                    );
                // get count
                var Total = res.Count() > 0 ? res.FirstOrDefault().pageCount : 0;
                res = res.Select(a => new SalesOrderListModel()
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
                    salesOrderTypeId = a.salesOrderTypeId,
                    salesOrderSourceId = a.salesOrderSourceId,
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
                    IsBackoffice = a.IsBackoffice,
                    Inprogress = a.Inprogress,
                    CashDiscountTotal = a.CashDiscountTotal,
                    ItemDiscountTotal = a.ItemDiscountTotal,
                    ItemTotal = a.ItemTotal,
                    TaxTotal = a.TaxTotal

                }).ToList();


                responseModel.Data = res;
                responseModel.Total = Total;

            }
            catch (Exception ex)
            {
                responseModel.Succeeded = false;
                responseModel.StatusCode = 500;
                responseModel.Message = ex.Message; ;
            }

            return Ok(await Task.FromResult(responseModel));
        }



        //[CheckAuthorizedAttribute]
        //[HttpPost("filter")]
        //public async Task<IActionResult> filter(SalesOrderSearchModel model)
        //{

        //    var task = Task.Factory.StartNew(() =>
        //    {
        //        ResponseModel<List<SalesOrderListModel>> responseModel = new ResponseModel<List<SalesOrderListModel>>();

        //        try
        //        {
        //            var ctr = new Criteria<BOSalesOrderVw>();
        //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.IsDeleted), false));
        //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderTypeId), 2));
        //            // get by term
        //            if (!string.IsNullOrEmpty(model.Term))
        //            {

        //                if (!string.IsNullOrEmpty(model.TermBy))
        //                {
        //                    switch (model.TermBy)
        //                    {
        //                        case "representativeCode":
        //                            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.RepresentativeCode), model.Term));
        //                            break;
        //                        case "clientCode":
        //                            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.ClientCode), model.Term));
        //                            break;
        //                        case "branchCode":
        //                            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.BranchCode), model.Term));
        //                            break;
        //                        case "storeCode":
        //                            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.StoreCode), model.Term));
        //                            break;
        //                        case "invoiceCode":
        //                            ctr.Add(Expression.EndWith(nameof(BOSalesOrderVw.InvoiceCode), model.Term));
        //                            break;
        //                        case "salesCode":
        //                            ctr.Add(Expression.EndWith(nameof(BOSalesOrderVw.SalesCode), model.Term));
        //                            break;

        //                        default:
        //                            break;
        //                    }
        //                }

        //            }

        //            if (FullDataAccess == false)
        //            {
        //                ctr.Add(Expression.In(nameof(BOSalesOrderVw.BranchId), Branchs));


        //                if (this.AppRoleId == 6)
        //                {
        //                    // get By Suppervisor
        //                    var clients = new Criteria<BORepresentativeClientVw>()
        //                                .Add(Expression.Eq(nameof(BORepresentativeClientVw.SupervisorUserId), UserId))
        //                                .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

        //                    ctr.Add(Expression.InSubQuery(nameof(BOSalesOrderVw.ClientId), clients));
        //                }

        //                if (this.AppRoleId == 7)
        //                {
        //                    // get by Sales Rep

        //                    var clients = new Criteria<BORepresentativeClientVw>()
        //                           .Add(Expression.Eq(nameof(BORepresentativeClientVw.RepresentativeUserId), UserId))
        //                           .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

        //                    ctr.Add(Expression.InSubQuery(nameof(BOSalesOrderVw.ClientId), clients));

        //                }

        //            }

        //            if (model.SalesOrderSourceId.Contains(1) || model.SalesOrderSourceId.Contains(2))
        //            {
        //                var origin = string.Join(",", model.SalesOrderSourceId);
        //                string[] splitElements = origin.Split(',');
        //                string convertedString = string.Join(",", Array.ConvertAll(splitElements, element => $"'{element}'"));
        //                ctr.Add(Expression.In(nameof(BOSalesOrderVw.SalesOrderSourceId), convertedString));
        //            }



        //            if (model.ClientId > 0)
        //                ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.ClientId), model.ClientId));



        //            if (model.BranchId > 0)
        //                ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.BranchId), model.BranchId));

        //            if (model.RepresentativeId > 0)
        //                ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.RepresentativeId), model.RepresentativeId));

        //            if (model.StoreId > 0)
        //                ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.StoreId), model.StoreId));

        //            if (model.SalesOrderStatusId > 0)
        //                ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderStatusId), model.SalesOrderStatusId));

        //            if (model.PriorityTypeId > 0)
        //                ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.PriorityTypeId), model.PriorityTypeId));


        //            if (model.IsInvoiced > 0)
        //                ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.IsInvoiced), model.IsInvoiced == 1 ? true : false));

        //            if (model.SalesDate != null && model.SalesDate.Value.Year > 1900)
        //                ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesDate), model.SalesDate, dateformatter));

        //            // sort by 
        //            if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
        //            {
        //                switch (model.SortBy.Property)
        //                {
        //                    case "storeName":
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("storeName{0}", Language)) : OrderBy.Desc(string.Format("storeName{0}", Language)));
        //                        break;
        //                    case "branchName":
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
        //                        break;
        //                    case "clientName":
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
        //                        break;
        //                    case "paymentTermName":
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("paymentTermName{0}", Language)) : OrderBy.Desc(string.Format("paymentTermName{0}", Language)));
        //                        break;
        //                    case "representativeName":
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
        //                        break;
        //                    case "salesOrderSourceName":
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("salesOrderSourceName{0}", Language)) : OrderBy.Desc(string.Format("salesOrderSourceName{0}", Language)));
        //                        break;
        //                    case "salesOrderStatusName":
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("salesOrderStatusName{0}", Language)) : OrderBy.Desc(string.Format("salesOrderStatusName{0}", Language)));
        //                        break;
        //                    case "salesOrderTypeName":
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("salesOrderTypeName{0}", Language)) : OrderBy.Desc(string.Format("salesOrderTypeName{0}", Language)));
        //                        break;
        //                    case "priorityName":
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("priorityName{0}", Language)) : OrderBy.Desc(string.Format("priorityName{0}", Language)));
        //                        break;
        //                    default:
        //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
        //                        break;
        //                }
        //            }
        //            else
        //            {
        //                ctr.Add(OrderBy.Asc(nameof(BOSalesOrderVw.SalesOrderStatusId)));
        //            }

        //            // get count

        //            var Total = ctr.Count();

        //            // get paged

        //            var res = ctr.Skip(model.Skip)
        //                         .Take(model.Take > 0 ? model.Take : 30)
        //                         .List<BOSalesOrderVw>().Select(a => new SalesOrderListModel()
        //                         {
        //                             SalesCode = a.SalesCode,
        //                             BranchCode = a.BranchCode,
        //                             ClientCode = a.ClientCode,
        //                             ClientId = a.ClientId,
        //                             InvoiceCode = a.InvoiceCode,
        //                             InvoiceDate = a.InvoiceDate,
        //                             NetTotal = a.NetTotal,
        //                             RepresentativeCode = a.RepresentativeCode,
        //                             SalesDate = a.SalesDate,
        //                             SalesId = a.SalesId.Value,
        //                             IsInvoiced = a.IsInvoiced,
        //                             StoreCode = a.StoreCode,
        //                             SalesOrderStatusId = a.SalesOrderStatusId,
        //                             salesOrderTypeId = a.SalesOrderTypeId,
        //                             salesOrderSourceId = a.SalesOrderSourceId,
        //                             StoreName = Language == "ar" ? a.StoreNameAr : a.StoreNameEn,
        //                             BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
        //                             ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
        //                             PaymentTermName = Language == "ar" ? a.PaymentTermNameAr : a.PaymentTermNameEn,
        //                             RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
        //                             SalesOrderSourceName = Language == "ar" ? a.SalesOrderSourceNameAr : a.SalesOrderSourceNameEn,
        //                             SalesOrderStatusName = Language == "ar" ? a.SalesOrderStatusNameAr : a.SalesOrderStatusNameEn,
        //                             SalesOrderTypeName = Language == "ar" ? a.SalesOrderTypeNameAr : a.SalesOrderTypeNameEn,
        //                             PriorityName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
        //                             HasError = a.HasError,
        //                             IsBackoffice = a.IsBackoffice,
        //                             Inprogress = a.Inprogress,

        //                         }).ToList();



        //            responseModel.Data = res;
        //            responseModel.Total = Total;
        //        }
        //        catch (Exception ex)
        //        {
        //            responseModel.Succeeded = false;
        //            responseModel.StatusCode = 500;
        //            responseModel.Message = ex.Message; ;
        //        }

        //        return responseModel;

        //    });
        //    await task;

        //    return Ok(task.Result);
        //}


        [CheckAuthorizedAttribute]
        [HttpPost("save")]
        public async Task<IActionResult> save(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (model == null || model.SalesPerenId == null || model.SalesPerenId == 0)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.Data = model;
                    return responseModel;
                }


                try
                {
                    model.AgentId = UserId;
                    model = await promotionCalculator.CaluclucateTotals(model);
                    var bo = new Criteria<BOSalesOrder>()
                    .Add(Expression.Eq(nameof(BOSalesOrder.SalesId), model.SalesId))
                    .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                    .FirstOrDefault<BOSalesOrder>();

                    if (bo == null)
                        bo = new BOSalesOrder();

                    bo.SalesPerenId = (long?)model.SalesPerenId;

                    bo.ClientId = model.ClientId;
                    bo.BranchId = model.BranchId;
                    bo.AgentId = UserId;
                    bo.SalesOrderTypeId = 2;
                    bo.RepresentativeId = model.RepresentativeId;
                    bo.StoreId = model.StoreId;
                    bo.PriorityTypeId = model.PriorityTypeId > 0 ? model.PriorityTypeId : 1;


                    if (model.PaymentTermId > 0)
                    {
                        bo.PaymentTermId = model.PaymentTermId;

                    }
                    else
                    {
                        var PaymentTermId = new BOClient(bo.ClientId.Value).PaymentTermId;
                        if (PaymentTermId > 0)
                        {
                            bo.PaymentTermId = PaymentTermId;
                        }
                        else
                        {
                            bo.PaymentTermId = 1;
                        }
                    }

                    bo.SalesDate = model.SalesDate != null ? model.SalesTime : DateTime.Now;
                    bo.SalesTime = model.SalesTime != null ? model.SalesTime : DateTime.Now;

                    if (bo.SalesDate.Value.Date < DateTime.Now.Date)
                    {
                        bo.SalesDate = DateTime.Now;
                        bo.SalesTime = DateTime.Now;
                    }

                    bo.SalesOrderStatusId = model.SalesOrderStatusId;
                    bo.SalesOrderSourceId = model.SalesOrderSourceId;
                    bo.Latitude = model.Latitude;
                    bo.Longitude = model.Longitude;

                    bo.ItemTotal = -1 * Math.Abs((decimal)model.ItemTotal.Value);
                    bo.ItemDiscountTotal = -1 * Math.Abs((decimal)model.ItemDiscountTotal);
                    bo.CustomDiscountTotal = -1 * Math.Abs((decimal)model.CustomDiscountTotal);
                    bo.TaxTotal = -1 * Math.Abs((decimal)model.TaxTotal);
                    bo.CashDiscountTotal = -1 * Math.Abs((decimal)model.CashDiscountTotal);
                    bo.NetTotal = -1 * Math.Abs((decimal)model.NetTotal);
                    bo.DeliveryTotal = 0;

                    bo.Notes = model.Notes;
                    bo.InvoiceRetry = 0;
                    bo.IsInvoiced = null;
                    bo.HasError = false;
                    bo.InvoiceCode = null;
                    bo.InvoiceDate = null;

                    if (bo.SalesId == null)
                    {
                        bo.CBy = UserId;
                        bo.CDate = DateTime.Now;
                        bo.SaveNew();

                        if (bo.SalesId > 0)
                        {
                            model.SalesId = bo.SalesId.Value;



                            var branch = new BOBranch(bo.BranchId.Value);
                            bo.SalesCode = string.Format(_configuration["settings:prefix:return"], bo.SalesId.Value.ToString().PadLeft(9, '0'));
                            bo.Update();


                            model.IsSynced = true;
                            model.SyncDate = DateTime.Now;
                            model.SalesCode = bo.SalesCode;

                            var boStatus = new BOSalesOrderStatus(bo.SalesOrderStatusId.Value);
                            model.SalesOrderStatusName = Language == "ar" ? boStatus.SalesOrderStatusNameAr : boStatus.SalesOrderStatusNameEn;
                            model.SalesOrderStatusId = bo.SalesOrderStatusId;

                            if (model.SalesOrderDetails != null)
                            {
                                foreach (var item in model.SalesOrderDetails)
                                {
                                    if (item.ItemId == 0 || item.ReturnQuantity == null || item.ReturnQuantity == 0)
                                        continue;

                                    var detail = new BOSalesOrderDetail();
                                    detail.SalesId = bo.SalesId;
                                    detail.ItemId = item.ItemId;
                                    detail.PublicPrice = (decimal?)item.PublicPrice;
                                    detail.ClientPrice = (decimal?)item.ClientPrice;
                                    detail.Quantity = -1* Math.Abs(item.Quantity.Value);
                                    detail.LineValue = -1 * Math.Abs((decimal)item.LineValue);
                                    detail.Discount = -1 * Math.Abs((decimal)item.Discount);
                                    detail.CustomDiscount = item.CustomDiscount > 0 ? -1 * Math.Abs((decimal)item.CustomDiscount) : 0;
                                    detail.TaxValue = -1 * Math.Abs((decimal)item.TaxValue);
                                    detail.IsBouns = false;
                                    detail.PromotionCode = "";
                                    detail.Batch = item.Batch;
                                    detail.Expiration = item.Expiration;
                                    detail.ItemStoreId = item.ItemStoreId;
                                    detail.UnitId = item.UnitId;
                                    detail.RecId = 0;
                                    detail.ReturnQuantity = 0;
                                    detail.TotalReturn = Math.Abs(item.TotalReturn.Value);
                                    detail.ReturnReasonId = null;

                                    detail.SaveNew();

                                    item.SalesId = detail.SalesId;
                                }
                            }

                            // check 

                            var OrderCount = model.SalesOrderDetails.Where(a => a.ItemId > 0).Where(a => a.ReturnQuantity > 0).Count();
                            var BoCount = bo.SalesOrderDetailCollection().Count;
                            if (OrderCount != BoCount)
                            {
                                bo.Delete();
                                model.SalesId = 0;
                                model.SalesCode = "";

                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 500;
                                responseModel.Data = model;
                                return responseModel;
                            }

                        }
                    }
                    else
                    {
                        if (bo.SalesOrderStatusId == 1)
                        {
                            bo.EBy = UserId;
                            bo.EDate = DateTime.Now;
                            bo.Update();

                            if (bo.SalesId > 0)
                            {

                                model.IsSynced = true;
                                model.SyncDate = DateTime.Now;
                                model.SalesCode = bo.SalesCode;

                                var boStatus = new BOSalesOrderStatus(bo.SalesOrderStatusId.Value);
                                model.SalesOrderStatusName = Language == "ar" ? boStatus.SalesOrderStatusNameAr : boStatus.SalesOrderStatusNameEn;
                                model.SalesOrderStatusId = bo.SalesOrderStatusId;

                                if (model.SalesOrderDetails != null)
                                {

                                    bo.DeleteAllSalesOrderDetail();
                                    bo.DeleteAllSalesOrderError();

                                    foreach (var item in model.SalesOrderDetails)
                                    {
                                        if (item.ItemId == 0 || item.ReturnQuantity == null || item.ReturnQuantity == 0)
                                            continue;

                                        var detail = new BOSalesOrderDetail();
                                        detail.SalesId = bo.SalesId;
                                        detail.ItemId = item.ItemId;
                                        detail.PublicPrice = (decimal?)item.PublicPrice;
                                        detail.ClientPrice = (decimal?)item.ClientPrice;
                                        detail.Quantity = Math.Abs(item.Quantity.Value);
                                        detail.LineValue = -1 * Math.Abs((decimal)item.LineValue);
                                        detail.Discount = -1 * Math.Abs((decimal)item.Discount);
                                        detail.CustomDiscount = item.CustomDiscount > 0 ? -1 * Math.Abs((decimal)item.CustomDiscount) : 0;
                                        detail.TaxValue = -1 * Math.Abs((decimal)item.TaxValue);
                                        detail.IsBouns = false;
                                        detail.PromotionCode = "";
                                        detail.Batch = item.Batch;
                                        detail.Expiration = item.Expiration;
                                        detail.ItemStoreId = item.ItemStoreId;
                                        detail.UnitId = item.UnitId;
                                        detail.RecId = 0;
                                        detail.ReturnQuantity = -1 * Math.Abs(item.ReturnQuantity.Value);
                                        detail.TotalReturn = Math.Abs(item.TotalReturn.Value);
                                        detail.ReturnReasonId = null;
                                        detail.SaveNew();

                                        item.SalesId = detail.SalesId;
                                    }
                                }

                                // check 

                                var OrderCount = model.SalesOrderDetails.Where(a => a.ItemId > 0).Where(a => a.ReturnQuantity > 0).Count();
                                var BoCount = bo.SalesOrderDetailCollection().Count;
                                if (OrderCount != BoCount)
                                {
                                    bo.Delete();
                                    model.SalesId = 0;
                                    model.SalesCode = "";

                                    responseModel.Succeeded = false;
                                    responseModel.Message = Messages.Invalid_Model;
                                    responseModel.StatusCode = 500;
                                    responseModel.Data = model;
                                    return responseModel;
                                }

                            }
                        }

                    }


                    orderLoggerService.Log(bo.SalesId.Value, OrderLogType.Save, UserId);


                    if (bo.SalesId > 0)
                    {
                        bo.DeleteAllSalesOrderError();
                        if (model.HasError == true)
                        {
                            foreach (var err in model.Errors)
                            {
                                orderLoggerService.LogError((long)model.SalesId.Value, err);

                            }

                        }
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




                model.ItemTotal = Math.Abs((double)model.ItemTotal.Value);
                model.ItemDiscountTotal = Math.Abs((double)model.ItemDiscountTotal);
                model.CustomDiscountTotal = Math.Abs((double)model.CustomDiscountTotal);
                model.TaxTotal = Math.Abs((double)model.TaxTotal);
                model.CashDiscountTotal = Math.Abs((double)model.CashDiscountTotal);
                model.NetTotal = Math.Abs((double)model.NetTotal);

                responseModel.Data = model;
                return responseModel;

            });
            await task;

            return Ok(task.Result.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpPost("promotion")]
        public async Task<IActionResult> promotion(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (model == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.Data = model;
                    return responseModel;
                }


                try
                {

                    model.AgentId = UserId;
                    model = await promotionCalculator.ValidateValidOrder(model,Language);

                    if (model.SalesId > 0)
                    {
                        var bo = new Criteria<BOSalesOrder>()
                                     .Add(Expression.Eq(nameof(BOSalesOrder.SalesId), model.SalesId))
                                     .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                     .FirstOrDefault<BOSalesOrder>();

                        if (bo != null && bo.SalesId > 0 && bo.SalesOrderStatusId == 1)
                        {
                            orderLoggerService.Log((long)model.SalesId.Value, OrderLogType.Calculate, UserId);

                            if (model.HasError == true)
                            {
                                bo.DeleteAllSalesOrderError();
                                foreach (var err in model.Errors)
                                {
                                    orderLoggerService.LogError((long)model.SalesId.Value, err);

                                }

                            }

                            //save details


                            if (bo != null && bo.SalesId > 0 && bo.SalesOrderStatusId == 1 && model.SalesOrderDetails != null)
                            {
                                //if (model.SalesOrderDetails != null)
                                //{    xxxx

                                    bo.DeleteAllSalesOrderDetail();
                                    bo.DeleteAllSalesOrderError();

                                foreach (var item in model.SalesOrderDetails)
                                {
                                    //if (item.ItemId == 0)
                                    //    continue;
                                    if (item.ItemId != 0)
                                    {
                                        var detail = new BOSalesOrderDetail();
                                        detail.SalesId = bo.SalesId;
                                        detail.ItemId = item.ItemId;
                                        detail.PublicPrice = (decimal?)item.PublicPrice;
                                        detail.ClientPrice = (decimal?)item.ClientPrice;
                                        detail.Quantity = item.Quantity;
                                        detail.LineValue = (decimal?)item.LineValue;
                                        detail.Discount = (decimal?)item.Discount;
                                        detail.CustomDiscount = item.CustomDiscount > 0 ? (decimal?)item.CustomDiscount : 0;
                                        detail.TaxValue = (decimal?)item.TaxValue;
                                        detail.IsBouns = item.IsBouns;
                                        detail.PromotionCode = "";
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
                                //}
                            }

                            //calc Total

                            var details = bo.SalesOrderDetailCollection();
                            bo.HasError = model.HasError;
                            bo.ItemTotal = details.Sum(a => a.Quantity * a.ClientPrice);
                            bo.ItemDiscountTotal = details.Sum(a => a.Quantity * a.Discount);
                            bo.CustomDiscountTotal = details.Sum(a => a.Quantity * a.CustomDiscount);
                            bo.TaxTotal = details.Sum(a => a.Quantity * a.TaxValue);
                            bo.DeliveryTotal = 0;
                            bo.NetTotal = bo.ItemTotal + bo.TaxTotal - bo.ItemDiscountTotal - bo.CustomDiscountTotal - bo.DeliveryTotal;
                            bo.CashDiscountTotal = (decimal?)model.CashDiscountTotal;
                            bo.EBy = UserId;
                            bo.EDate = DateTime.Now;
                            bo.Update();


                            model.ItemDiscountTotal = bo.ItemDiscountTotal > 0 ? (double)bo.ItemDiscountTotal.Value : 0;
                            model.TaxTotal = bo.TaxTotal > 0 ? (double)bo.TaxTotal.Value : 0;
                            model.ItemTotal = bo.ItemTotal > 0 ? (double)bo.ItemTotal.Value : 0;
                            model.CustomDiscountTotal = bo.CustomDiscountTotal > 0 ? (double)bo.CustomDiscountTotal.Value : 0;
                            model.CashDiscountTotal = bo.CashDiscountTotal > 0 ? (double)bo.CashDiscountTotal.Value : 0;


                        }
                    }

                }
                catch { }

                responseModel.Data = model;
                return responseModel;

            });
            await task;

            return Ok(task.Result.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpGet("getByCode")]
        public async Task<IActionResult> getByCode(string InvoiceCode)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (string.IsNullOrEmpty(InvoiceCode))
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else
                {
                    try
                    {

                        // check if exit code
                        var exist = new Criteria<BOSalesOrderVw>()
                                        .Add(Expression.Eq(nameof(BOSalesOrderVw.InvoiceCode), InvoiceCode))
                                        .Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderTypeId), 1))
                                        .Add(Expression.Eq(nameof(BOSalesOrderVw.IsDeleted), false))
                                        .List<BOSalesOrderVw>()
                                        .Select(a => new SalesOrderModelWeb()
                                        {
                                            AgentId = a.AgentId,
                                            BranchId = a.BranchId.Value,
                                            CashDiscountTotal = (double?)a.CashDiscountTotal,
                                            ClientId = a.ClientId,
                                            InvoiceCode = a.InvoiceCode,
                                            InvoiceDate = a.InvoiceDate,
                                            ItemDiscountTotal = (double?)a.ItemDiscountTotal,
                                            IsInvoiced = a.IsInvoiced,
                                            ItemTotal = (double?)a.ItemTotal,
                                            Latitude = (double?)a.Latitude,
                                            Longitude = a.Longitude,
                                            NetTotal = (double?)a.NetTotal,
                                            Notes = a.Notes,
                                            PaymentTermId = a.PaymentTermId.Value,
                                            InvoiceRetry = a.InvoiceRetry,
                                            SalesTime = a.SalesTime,
                                            PriorityTypeId = a.PriorityTypeId,
                                            RepresentativeId = a.RepresentativeId,
                                            SalesCode = a.SalesCode,
                                            SalesId = a.SalesId.Value,
                                            SalesOrderSourceId = a.SalesOrderSourceId,
                                            SalesDate = a.SalesDate,
                                            SalesOrderTypeId = a.SalesOrderTypeId,
                                            StoreId = a.StoreId.Value,
                                            TaxTotal = (double?)a.TaxTotal,
                                            CustomDiscountTotal = (double?)a.CustomDiscountTotal,
                                            SalesOrderStatusId = a.SalesOrderStatusId,
                                            BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                            ClientCode = a.ClientCode,
                                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                            Id = null,
                                            CustomDiscountTypeId = 0,
                                            CustomDiscountValue = (double?)a.CustomDiscountTotal,
                                            Errors = new List<string>(),
                                            HasError = false,
                                            DeliveryTotal = (double?)a.DeliveryTotal,
                                            IsSynced = false,
                                            SalesPerenId=null,
                                            PriorityTypeName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                                            PromotionOptions = new List<SalesOrderPromotionOptionModel>(),
                                            Warnings = new List<string>(),
                                            SyncDate = null,
                                            AgentName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                            SalesOrderTypeName = Language == "ar" ? a.SalesOrderTypeNameAr : a.SalesOrderTypeNameEn,
                                            SalesOrderStatusName = Language == "ar" ? a.SalesOrderStatusNameAr : a.SalesOrderStatusNameEn,
                                            SalesOrderSourceName = Language == "ar" ? a.SalesOrderSourceNameAr : a.SalesOrderSourceNameEn,
                                            RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                            StoreName = Language == "ar" ? a.StoreNameAr : a.StoreNameEn,
                                            PaymentTermName = Language == "ar" ? a.PaymentTermNameAr : a.PaymentTermNameEn,
                                            SalesOrderDetails = new List<SalesOrderDetailListModel>(),
                                        }).FirstOrDefault();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = exist;
                            responseModel.Data.SalesOrderDetails = new Criteria<BOSalesOrderDetailVw>()
                                                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailVw.SalesId), exist.SalesId))
                                                                   .List<BOSalesOrderDetailVw>()
                                                                   .Select(a => new SalesOrderDetailListModel()
                                                                   {
                                                                       ClientPrice = (double?)a.ClientPrice,
                                                                       DetailId = a.DetailId,
                                                                       Discount = (double?)a.Discount,
                                                                       IsBouns = a.IsBouns,
                                                                       ItemCode = a.ItemCode,
                                                                       ItemId = a.ItemId,
                                                                       ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                                                                       Batch = a.Batch,
                                                                       Expiration = a.Expiration,
                                                                       LineValue = 0,
                                                                       PromotionCode = a.PromotionCode,
                                                                       PublicPrice = (double?)a.PublicPrice,
                                                                       Quantity = a.Quantity,
                                                                       SalesId = a.SalesId,
                                                                       TaxValue = (double?)a.TaxValue,
                                                                       VendorCode = a.VendorCode,
                                                                       VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
                                                                       ItemStoreId = a.ItemStoreId,
                                                                       UnitId = a.UnitId,
                                                                       CashDiscount = 0,
                                                                       Id = null,
                                                                       parentId = null,
                                                                       HasPromotion = a.HasPromotion,
                                                                       CustomDiscount = (double?)a.CustomDiscount,

                                                                       ReturnQuantity = 0,
                                                                       TotalReturn = a.TotalReturn != null ? a.TotalReturn.Value : 0,

                                                                       ItemGroupId = a.ItemGroupId

                                                                   }).ToList();




                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Not_Found;
                        }

                        responseModel.Total = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpGet("getById")]
        public async Task<IActionResult> getById(long Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (Id==0)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else
                {
                    try
                    {

                        // check if exit code
                        var exist = new Criteria<BOSalesOrderVw>()
                                        .Add(Expression.Eq(nameof(BOSalesOrderVw.SalesId), Id))
                                        .Add(Expression.Eq(nameof(BOSalesOrderVw.IsDeleted), false))
                                        .Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderTypeId), 2))
                                        .List<BOSalesOrderVw>()
                                        .Select(a => new SalesOrderModelWeb()
                                        {
                                            AgentId = a.AgentId,
                                            BranchId = a.BranchId.Value,
                                            CashDiscountTotal = Math.Abs((double)a.CashDiscountTotal),
                                            ClientId = a.ClientId,
                                            InvoiceCode = a.InvoiceCode,
                                            InvoiceDate = a.InvoiceDate,
                                            ItemDiscountTotal =Math.Abs((double)a.ItemDiscountTotal),
                                            IsInvoiced = a.IsInvoiced,
                                            ItemTotal = Math.Abs((double)a.ItemTotal),
                                            Latitude =  a.Latitude,
                                            Longitude = a.Longitude,
                                            NetTotal = Math.Abs((double)a.NetTotal),
                                            Notes = a.Notes,
                                            PaymentTermId = a.PaymentTermId.Value,
                                            InvoiceRetry = a.InvoiceRetry,
                                            SalesTime = a.SalesTime,
                                            PriorityTypeId = a.PriorityTypeId,
                                            RepresentativeId = a.RepresentativeId,
                                            SalesCode = a.SalesCode,
                                            SalesId = a.SalesId.Value,
                                            SalesOrderSourceId = a.SalesOrderSourceId,
                                            SalesDate = a.SalesDate,
                                            SalesOrderTypeId = a.SalesOrderTypeId,
                                            StoreId = a.StoreId.Value,
                                            TaxTotal = Math.Abs((double)a.TaxTotal),
                                            CustomDiscountTotal = Math.Abs( (double)a.CustomDiscountTotal),
                                            CustomDiscountValue = Math.Abs((double)a.CustomDiscountTotal),
                                            SalesOrderStatusId = a.SalesOrderStatusId,
                                            BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                            ClientCode = a.ClientCode,
                                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                            Id = null,
                                            CustomDiscountTypeId = null,
                                            
                                            Errors = new List<string>(),
                                            HasError = false,
                                            DeliveryTotal = 0,
                                            
                                            
                                            IsSynced = false,
                                            SalesPerenId=a.SalesPerenId,
                                            PriorityTypeName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                                            PromotionOptions = new List<SalesOrderPromotionOptionModel>(),
                                            Warnings = new List<string>(),
                                            SyncDate = null,
                                            AgentName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                            SalesOrderTypeName = Language == "ar" ? a.SalesOrderTypeNameAr : a.SalesOrderTypeNameEn,
                                            SalesOrderStatusName = Language == "ar" ? a.SalesOrderStatusNameAr : a.SalesOrderStatusNameEn,
                                            SalesOrderSourceName = Language == "ar" ? a.SalesOrderSourceNameAr : a.SalesOrderSourceNameEn,
                                            RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                            StoreName = Language == "ar" ? a.StoreNameAr : a.StoreNameEn,
                                            PaymentTermName = Language == "ar" ? a.PaymentTermNameAr : a.PaymentTermNameEn,
                                            
                                            SalesOrderDetails = new List<SalesOrderDetailListModel>(),
                                        }).FirstOrDefault();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = exist;
                            responseModel.Data.SalesOrderDetails = new Criteria<BOSalesOrderDetailVw>()
                                                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailVw.SalesId), exist.SalesId))
                                                                   .List<BOSalesOrderDetailVw>()
                                                                   .Select(a => new SalesOrderDetailListModel()
                                                                   {
                                                                       ClientPrice = (double?)a.ClientPrice,
                                                                       DetailId = a.DetailId,
                                                                       Discount = (double?)a.Discount,
                                                                       IsBouns = a.IsBouns,
                                                                       ItemCode = a.ItemCode,
                                                                       ItemId = a.ItemId,
                                                                       ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                                                                       Batch = a.Batch,
                                                                       Expiration = a.Expiration,
                                                                       LineValue = Math.Abs((double)a.LineValue),
                                                                       PromotionCode = a.PromotionCode,
                                                                       PublicPrice = (double?)a.PublicPrice,
                                                                       Quantity = a.Quantity,
                                                                       SalesId = a.SalesId,
                                                                       TaxValue = Math.Abs((double)a.TaxValue),
                                                                       VendorCode = a.VendorCode,
                                                                       VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
                                                                       ItemStoreId = a.ItemStoreId,
                                                                       UnitId = a.UnitId,
                                                                       CashDiscount = 0,
                                                                       Id = null,
                                                                       parentId = null,
                                                                       HasPromotion = a.HasPromotion,
                                                                       CustomDiscount = Math.Abs((double)a.CustomDiscount),
                                                                       ReturnQuantity = a.ReturnQuantity != null ?  Math.Abs(a.ReturnQuantity.Value) : 0,
                                                                       TotalReturn = a.TotalReturn != null ? Math.Abs(a.TotalReturn.Value) : 0,

                                                                       ItemGroupId = a.ItemGroupId

                                                                   }).ToList();




                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Not_Found;
                        }

                        responseModel.Total = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }





    }
}
