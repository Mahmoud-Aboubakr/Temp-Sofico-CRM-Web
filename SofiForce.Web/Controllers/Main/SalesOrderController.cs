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
using SofiForce.Web.Dapper.Implementation;
using SofiForce.Web.Dapper.Interface;
using SofiForce.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class SalesOrderController : BaseController
    {
        private readonly IPromotionCalculator promotionCalculator;
        private readonly ISalesOrderManager salesOrderManager;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IOrderLoggerService orderLoggerService;


        public SalesOrderController(
            IPromotionCalculator promotionCalculator,
            ISalesOrderManager salesOrderManager, 
            IHttpContextAccessor contextAccessor, 
            IWebHostEnvironment env, 
            IConfiguration configuration, 
            IMapper mapper, 
            IOrderLoggerService orderLoggerService) : base(contextAccessor)
        {
            this.promotionCalculator = promotionCalculator;
            this.salesOrderManager = salesOrderManager;
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
            this.orderLoggerService = orderLoggerService;
        }

        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(SalesOrderSearchModel model)
        {
            #region old buisness Code 
            //var task = Task.Factory.StartNew(() =>
            //{
            //    ResponseModel<List<SalesOrderListModel>> responseModel = new ResponseModel<List<SalesOrderListModel>>();

            //    try
            //    {
            //        var ctr = new Criteria<BOSalesOrderVw>();
            //        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.IsDeleted), false));
            //        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderTypeId), 1));
            //        // get by term
            //        if (!string.IsNullOrEmpty(model.Term))
            //        {

            //            if (!string.IsNullOrEmpty(model.TermBy))
            //            {
            //                switch (model.TermBy)
            //                {
            //                    case "representativeCode":
            //                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.RepresentativeCode), model.Term));
            //                        break;
            //                    case "clientCode":
            //                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.ClientCode), model.Term));
            //                        break;
            //                    case "branchCode":
            //                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.BranchCode), model.Term));
            //                        break;
            //                    case "storeCode":
            //                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.StoreCode), model.Term));
            //                        break;
            //                    case "invoiceCode":
            //                        ctr.Add(Expression.EndWith(nameof(BOSalesOrderVw.InvoiceCode), model.Term));
            //                        break;
            //                    case "salesCode":
            //                        ctr.Add(Expression.EndWith(nameof(BOSalesOrderVw.SalesCode), model.Term));
            //                        break;
                                
            //                    default:
            //                        break;
            //                }
            //            }

            //        }

            //        if (FullDataAccess == false)
            //        {
            //            ctr.Add(Expression.In(nameof(BOSalesOrderVw.BranchId), Branchs));


            //            if (this.AppRoleId == 6)
            //            {
            //                // get By Suppervisor
            //                var clients = new Criteria<BORepresentativeClientVw>()
            //                            .Add(Expression.Eq(nameof(BORepresentativeClientVw.SupervisorUserId), UserId))
            //                            .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

            //                ctr.Add(Expression.InSubQuery(nameof(BOSalesOrderVw.ClientId), clients));
            //            }

            //            if (this.AppRoleId == 7)
            //            {
            //                // get by Sales Rep

            //                var clients = new Criteria<BORepresentativeClientVw>()
            //                       .Add(Expression.Eq(nameof(BORepresentativeClientVw.RepresentativeUserId), UserId))
            //                       .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

            //                ctr.Add(Expression.InSubQuery(nameof(BOSalesOrderVw.ClientId), clients));

            //            }

            //        }

            //        if (model.SalesOrderSourceId.Contains(1) || model.SalesOrderSourceId.Contains(2))
            //        {
            //            var origin = string.Join(",", model.SalesOrderSourceId);
            //            string[] splitElements = origin.Split(',');
            //            string convertedString = string.Join(",", Array.ConvertAll(splitElements, element => $"'{element}'"));
            //            ctr.Add(Expression.In(nameof(BOSalesOrderVw.SalesOrderSourceId), convertedString));
            //        }

            //        if (model.ClientId > 0)
            //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.ClientId), model.ClientId));

            //        if (model.BranchId > 0)
            //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.BranchId), model.BranchId));

            //        if (model.RepresentativeId > 0)
            //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.RepresentativeId), model.RepresentativeId));

            //        if (model.StoreId > 0)
            //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.StoreId), model.StoreId));

            //        if (model.SalesOrderStatusId > 0)
            //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderStatusId), model.SalesOrderStatusId));

            //        if (model.PriorityTypeId > 0)
            //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.PriorityTypeId), model.PriorityTypeId));
                        

            //        if (model.IsInvoiced > 0)
            //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.IsInvoiced), model.IsInvoiced==1?true:false));

            //        if (model.SalesDate !=null && model.SalesDate.Value.Year>1900)
            //            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesDate), model.SalesDate,dateformatter));

            //        if (model.CashDiscountOnly == true)
            //            ctr.Add(Expression.Gt(nameof(BOSalesOrderVw.CashDiscountTotal), 0));


            //        // sort by 
            //        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
            //        {
            //            switch (model.SortBy.Property)
            //            {
            //                case "storeName":
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("storeName{0}", Language)) : OrderBy.Desc(string.Format("storeName{0}", Language)));
            //                    break;
            //                case "branchName":
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
            //                    break;
            //                case "clientName":
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
            //                    break;
            //                case "paymentTermName":
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("paymentTermName{0}", Language)) : OrderBy.Desc(string.Format("paymentTermName{0}", Language)));
            //                    break;
            //                case "representativeName":
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
            //                    break;
            //                case "salesOrderSourceName":
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("salesOrderSourceName{0}", Language)) : OrderBy.Desc(string.Format("salesOrderSourceName{0}", Language)));
            //                    break;
            //                case "salesOrderStatusName":
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("salesOrderStatusName{0}", Language)) : OrderBy.Desc(string.Format("salesOrderStatusName{0}", Language)));
            //                    break;
            //                case "salesOrderTypeName":
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("salesOrderTypeName{0}", Language)) : OrderBy.Desc(string.Format("salesOrderTypeName{0}", Language)));
            //                    break;
            //                case "priorityName":
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("priorityName{0}", Language)) : OrderBy.Desc(string.Format("priorityName{0}", Language)));
            //                    break;
            //                default:
            //                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            ctr.Add(OrderBy.Asc(nameof(BOSalesOrderVw.SalesOrderStatusId)));
            //        }

            //        // get count

            //        var Total = ctr.Count();

            //        // get paged

            //        var res = ctr.Skip(model.Skip)
            //                     .Take(model.Take>0?model.Take:30)
            //                     .List<BOSalesOrderVw>().Select(a => new SalesOrderListModel()
            //                     {
            //                         SalesCode = a.SalesCode,
            //                         BranchCode = a.BranchCode,
            //                         ClientCode = a.ClientCode,
            //                         ClientId = a.ClientId,
            //                         InvoiceCode = a.InvoiceCode,
            //                         InvoiceDate = a.InvoiceDate,
            //                         NetTotal = a.NetTotal,
            //                         RepresentativeCode = a.RepresentativeCode,
            //                         SalesDate = a.SalesDate,
            //                         SalesId = a.SalesId.Value,
            //                         IsInvoiced = a.IsInvoiced,
            //                         StoreCode = a.StoreCode,
            //                         SalesOrderStatusId = a.SalesOrderStatusId,
            //                         salesOrderTypeId=a.SalesOrderTypeId,
            //                         salesOrderSourceId=a.SalesOrderSourceId,
            //                         StoreName =Language=="ar"?a.StoreNameAr:a.StoreNameEn,
            //                         BranchName=Language=="ar"?a.BranchNameAr:a.BranchNameEn,
            //                         ClientName=Language=="ar"?a.ClientNameAr:a.ClientNameEn,
            //                         PaymentTermName=Language=="ar"?a.PaymentTermNameAr:a.PaymentTermNameEn,
            //                         RepresentativeName=Language=="ar"?a.RepresentativeNameAr:a.RepresentativeNameEn,
            //                         SalesOrderSourceName=Language=="ar"?a.SalesOrderSourceNameAr:a.SalesOrderSourceNameEn,
            //                         SalesOrderStatusName=Language=="ar"?a.SalesOrderStatusNameAr:a.SalesOrderStatusNameEn,
            //                         SalesOrderTypeName=Language=="ar"?a.SalesOrderTypeNameAr:a.SalesOrderTypeNameEn,
            //                         PriorityName=Language=="ar"?a.PriorityNameAr:a.PriorityNameEn,
            //                         HasError=a.HasError,
            //                         IsBackoffice=a.IsBackoffice,
            //                         Inprogress=a.Inprogress,
            //                         CashDiscountTotal=a.CashDiscountTotal,
            //                         ItemDiscountTotal=a.ItemDiscountTotal,
            //                         ItemTotal=a.ItemTotal,
            //                         TaxTotal=a.TaxTotal

            //                     }).ToList();



            //        responseModel.Data = res;
            //        responseModel.Total = Total;
            //    }
            //    catch (Exception ex)
            //    {
            //        responseModel.Succeeded = false;
            //        responseModel.StatusCode = 500;
            //        responseModel.Message = ex.Message;;
            //    }

            //    return responseModel;

            //});
            //await task;

            //return Ok(task.Result);
            #endregion

            ResponseModel<List<SalesOrderListModel>> responseModel = new ResponseModel<List<SalesOrderListModel>>();
            try
            {
                string convertedString = string.Empty;
                if (model.SalesOrderSourceId.Contains(1) || model.SalesOrderSourceId.Contains(2))
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
                                                    UserId,
                                                    AppRoleId,
                                                    branches,
                                                    convertedString,
                                                    SalesOrderTypeId: 1, 
                                                    IsDeleted:false,
                                                    orderTermBy,
                                                    CashDiscountTotal: 0);
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

        [CheckAuthorizedAttribute]
        [HttpPost("saveHeader")]
        public async Task<IActionResult> saveHeader(SalesOrderModelWeb model)
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
                    model =  promotionCalculator.CaluclucateTotals(model); //xxxx
                    var bo = new Criteria<BOSalesOrder>()
                                .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                .Add(Expression.Eq(nameof(BOSalesOrder.SalesId), model.SalesId))
                                .FirstOrDefault<BOSalesOrder>();

                    if (bo == null)
                        bo = new BOSalesOrder();


                    bo.ClientId = model.ClientId;


                    var branchs = new BOStore(model.StoreId.Value);
                    bo.BranchId = branchs.BranchId;

                    

                    bo.AgentId = UserId;
                    bo.SalesOrderTypeId = model.SalesOrderTypeId > 0 ? model.SalesOrderTypeId : 1;
                    bo.RepresentativeId = model.RepresentativeId;
                    bo.StoreId = model.StoreId;
                    bo.PriorityTypeId = model.PriorityTypeId > 0 ? model.PriorityTypeId : 1;
                    bo.IsDeleted = false;

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
                    bo.ItemTotal = 0;
                    bo.ItemDiscountTotal = 0;
                    bo.CustomDiscountTotal = 0;
                    bo.TaxTotal = 0;
                    bo.CashDiscountTotal = 0;
                    bo.NetTotal = 0;
                    bo.Notes = model.Notes;
                    bo.InvoiceRetry = 0;
                    bo.IsInvoiced = null;
                    bo.HasError = false;
                    bo.InvoiceCode = string.Empty;
                    bo.InvoiceDate = null;

                    if (bo.SalesId == null)
                    {
                        bo.IsBackoffice = true;
                        bo.CBy = UserId;
                        bo.CDate = DateTime.Now;
                        bo.SaveNew();
                        if (bo.SalesId > 0)
                        {
                            
                            var branch = new BOBranch(bo.BranchId.Value);
                            bo.SalesCode = string.Format(_configuration["settings:prefix:order"], bo.SalesId.Value.ToString().PadLeft(12, '0'));
                            bo.Update();

                            model.SalesId = bo.SalesId;
                            model.SalesCode = bo.SalesCode;

                            //add delivery address
                            var client = new BOClient(bo.ClientId.Value);
                            var address = new BOSalesOrderAddress();
                            address.SalesId = bo.SalesId;
                            address.RegionId = client.RegionId;
                            address.GovernerateId = client.GovernerateId;
                            address.CityId= client.CityId;
                            address.Building=client.Building;
                            address.Floor=client.Floor;
                            address.Property=client.Property;
                            address.Landmark = client.Landmark;
                            address.Address= client.Address;
                            address.Latitude= client.Latitude;
                            address.Longitude= client.Longitude;
                            address.Mobile = client.Mobile;
                            address.WhatsApp=client.WhatsApp;
                            address.Phone=client.Phone;
                            address.EBy = UserId;
                            address.EDate = DateTime.Now;
                            address.SaveNew();
                        }


                    }
                    else
                    {
                        if (bo.SalesOrderStatusId == 1)
                        {
                            bo.EBy = UserId;
                            bo.EDate = DateTime.Now;
                            bo.Update();

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



                responseModel.Data = model;
                return responseModel;

            });
            await task;

            return Ok(task.Result.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("saveItems")]
        public async Task<IActionResult> saveItems(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(() =>
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
                  
                    var bo = new Criteria<BOSalesOrder>()
                    .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                    .Add(Expression.Eq(nameof(BOSalesOrder.SalesId), model.SalesId))
                    .FirstOrDefault<BOSalesOrder>();


                    if(bo!=null && bo.SalesId>0 && bo.SalesOrderStatusId == 1)
                    {
                        if (model.SalesOrderDetails != null)
                        {

                            bo.DeleteAllSalesOrderDetail();
                            bo.DeleteAllSalesOrderError();

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
                                detail.CustomDiscount = item.CustomDiscount > 0 ? (decimal?)item.CustomDiscount : 0;
                                detail.TaxValue = (decimal?)item.TaxValue;
                                detail.IsBouns = item.IsBouns;
                                detail.PromotionCode =  item.PromotionCode;
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
                    }

                    //calc Total

                    var details = bo.SalesOrderDetailCollection();
                    bo.ItemTotal = details.Sum(a => a.Quantity * a.ClientPrice);
                    bo.ItemDiscountTotal = details.Sum(a => a.Quantity * a.Discount);
                    bo.CustomDiscountTotal = details.Sum(a => a.Quantity * a.CustomDiscount);
                    bo.TaxTotal = details.Sum(a => a.Quantity * a.TaxValue);
                    bo.DeliveryTotal = 0;
                    bo.NetTotal = bo.ItemTotal + bo.TaxTotal - bo.ItemDiscountTotal - bo.CustomDiscountTotal - bo.DeliveryTotal;
                    bo.EBy = UserId;
                    bo.EDate = DateTime.Now;
                    bo.Update();


                    model.ItemDiscountTotal = bo.ItemDiscountTotal > 0 ? (double)bo.ItemDiscountTotal.Value : 0;
                    model.TaxTotal = bo.TaxTotal > 0 ? (double)bo.TaxTotal.Value : 0;
                    model.ItemTotal = bo.ItemTotal > 0 ? (double)bo.ItemTotal.Value : 0;
                    model.CustomDiscountTotal = bo.CustomDiscountTotal > 0 ? (double)bo.CustomDiscountTotal.Value : 0;
                    model.CashDiscountTotal = bo.CashDiscountTotal > 0 ? (double)bo.CashDiscountTotal.Value : 0;

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

        [CheckAuthorizedAttribute]
        [HttpPost("saveAddress")]
        public async Task<IActionResult> saveAddress(SalesOrderAddressModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderAddressModel> responseModel = new ResponseModel<SalesOrderAddressModel>();

                if (model == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.Data = model;
                    return responseModel;
                }


                try
                {

                    var address = new Criteria<BOSalesOrderAddress>()
                            .Add(Expression.Eq(nameof(BOSalesOrderAddress.SalesId), model.SalesId))
                            .FirstOrDefault<BOSalesOrderAddress>();

                    if (address != null)
                    {
                        address.RegionId=model.RegionId>0?model.RegionId:null;
                        address.GovernerateId = model.GovernerateId>0?model.GovernerateId:null;
                        address.CityId=model.CityId>0?model.CityId:null;
                        address.Address = model.Address;
                        address.Landmark = model.Landmark;
                        address.Building=model.Building;
                        address.Floor = model.Floor;
                        address.Property=model.Property;
                        address.Latitude=model.Latitude;
                        address.Longitude=model.Longitude;
                        address.Phone=model.Phone;
                        address.WhatsApp = model.WhatsApp;
                        address.Mobile=model.Mobile;
                        address.EBy = UserId;
                        address.EDate = DateTime.Now;
                        address.Update();
                    }
                    else
                    {
                        address = new BOSalesOrderAddress();

                        address.RegionId = model.RegionId > 0 ? model.RegionId : null;
                        address.GovernerateId = model.GovernerateId > 0 ? model.GovernerateId : null;
                        address.CityId = model.CityId > 0 ? model.CityId : null;
                        address.Address = model.Address;
                        address.Landmark = model.Landmark;
                        address.Building = model.Building;
                        address.Floor = model.Floor;
                        address.Property = model.Property;
                        address.Latitude = model.Latitude;
                        address.Longitude = model.Longitude;
                        address.Phone = model.Phone;
                        address.WhatsApp = model.WhatsApp;
                        address.Mobile = model.Mobile;
                        address.EBy = UserId;
                        address.EDate = DateTime.Now;
                        address.SaveNew();
                    }

                    if (model.UpdateClient == true)
                    {
                        var order = new Criteria<BOSalesOrder>()
                                .Add(Expression.Eq(nameof(BOSalesOrder.SalesId), model.SalesId))
                                .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                .FirstOrDefault<BOSalesOrder>();
                        if(order != null)
                        {
                            var client = new Criteria<BOClient>()
                                .Add(Expression.Eq(nameof(BOClient.ClientId), order.ClientId))
                                .FirstOrDefault<BOClient>();

                            if(client != null)
                            {
                                client.RegionId = model.RegionId > 0 ? model.RegionId : null;
                                client.GovernerateId = model.GovernerateId > 0 ? model.GovernerateId : null;
                                client.CityId = model.CityId > 0 ? model.CityId : null;
                                client.Address = model.Address;
                                client.Landmark = model.Landmark;
                                client.Building = model.Building;
                                client.Floor = model.Floor;
                                client.Property = model.Property;
                                client.Latitude = model.Latitude;
                                client.Longitude = model.Longitude;
                                client.Phone = model.Phone;
                                client.WhatsApp = model.WhatsApp;
                                client.Mobile = model.Mobile;
                                client.EBy = UserId;
                                client.EDate = DateTime.Now;
                                address.Update();
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



                responseModel.Data = model;
                return responseModel;

            });
            await task;

            return Ok(task.Result);
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

                    model =await promotionCalculator.ValidateOrder(model,Language);

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
                                if (model.SalesOrderDetails != null) //xxxx
                                {

                                    bo.DeleteAllSalesOrderDetail();
                                    //bo.DeleteAllSalesOrderError();
                                    bo.DeleteAllSalesOrderLinePromotion();
                                    bo.DeleteAllSalesOrderPromotion();

                                    foreach (var item in model.SalesOrderDetails)
                                    {
                                        //if (item.ItemId == 0)
                                        //    continue;    xxxxx
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
                                            detail.PromotionCode = item.PromotionCode;
                                            detail.Batch = item.Batch;
                                            detail.Expiration = item.Expiration;
                                            detail.ItemStoreId = item.ItemStoreId;
                                            detail.UnitId = item.UnitId;
                                            detail.RecId = 0;
                                            detail.ReturnQuantity = 0;
                                            detail.TotalReturn = 0;
                                            detail.ReturnReasonId = null;
                                            detail.PromotionId = !string.IsNullOrEmpty(item.PromotionCode) ? int.Parse(item.PromotionCode) : null;
                                            detail.SaveNew();

                                            item.SalesId = detail.SalesId;
                                        }
                                    }
                                    foreach (var item in model.LineBouns)
                                    {
                                        var line = new BOSalesOrderLinePromotion();

                                        line.SalesId = bo.SalesId;
                                        line.ItemId= item.ItemId;
                                        line.Outcome = (decimal?)item.Outcome;
                                        line.PromotionId = item.PromotionId;
                                        line.ItemStoreId = item.ItemStoreId;
                                        line.OutcomeType= item.OutcomeType;
                                        line.SaveNew();
                                    }
                                }
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
                            bo.CashDiscountTotal =(decimal?) model.CashDiscountTotal;
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
        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (Id == 0)
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
                                        .List<BOSalesOrderVw>()
                                        .Select(a => new SalesOrderModelWeb() {
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
                                                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailVw.SalesId), Id))
                                                                   .List<BOSalesOrderDetailVw>()
                                                                   .Select(a => new SalesOrderDetailListModel()
                                                                   {
                                                                      ClientPrice= (double?)a.ClientPrice,
                                                                      DetailId=a.DetailId,
                                                                      Discount= (double?)a.Discount,
                                                                      IsBouns=a.IsBouns,
                                                                      ItemCode=a.ItemCode,
                                                                      ItemId=a.ItemId,
                                                                      ItemName=Language=="ar"?a.ItemNameAr:a.ItemNameEn,
                                                                      Batch=a.Batch,
                                                                      Expiration=a.Expiration,
                                                                      LineValue= (double?)a.LineValue,
                                                                      PromotionCode=a.PromotionCode,
                                                                      PublicPrice= (double?)a.PublicPrice,
                                                                      Quantity=a.Quantity,
                                                                      SalesId=a.SalesId,
                                                                      TaxValue= (double?)a.TaxValue,
                                                                      VendorCode=a.VendorCode,
                                                                      VendorName=Language=="ar"?a.VendorNameAr:a.VendorNameEn,
                                                                      ItemStoreId=a.ItemStoreId,
                                                                      UnitId=a.UnitId,
                                                                      CashDiscount=0,
                                                                      Id=null,
                                                                      parentId=null,
                                                                      HasPromotion= a.HasPromotion,
                                                                      CustomDiscount=(double?)a.CustomDiscount

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
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpGet("getAddress")]
        public async Task<IActionResult> getAddress(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderAddressModel> responseModel = new ResponseModel<SalesOrderAddressModel>();

                if (Id == 0)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else
                {
                    try
                    {
                        var bo = new Criteria<BOSalesOrderAddress>()
                        .Add(Expression.Eq(nameof(BOSalesOrderAddress.SalesId), Id))
                        .FirstOrDefault<BOSalesOrderAddress>();
                        responseModel.Data = _mapper.Map<SalesOrderAddressModel>(bo);
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
        [HttpPost("delete")]
        public async Task<IActionResult> delete(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (model == null)
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
                        var exist = new Criteria<BOSalesOrder>()
                                        .Add(Expression.Eq(nameof(model.SalesId), model.SalesId))
                                        .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                        .FirstOrDefault<BOSalesOrder>();


                        if (exist != null)
                        {
                            if (exist.SalesOrderStatusId == 1)
                            {
                                exist.IsDeleted = true;
                                exist.Update();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                                return responseModel;
                            }

                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                            return responseModel;
                        }

                        responseModel.Data = model;
                        responseModel.Total = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("clear-cash")]
        public async Task<IActionResult> ClearCash(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (model == null)
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
                        var exist = new Criteria<BOSalesOrder>()
                                        .Add(Expression.Eq(nameof(model.SalesId), model.SalesId))
                                        .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                        .FirstOrDefault<BOSalesOrder>();


                        if (exist != null)
                        {
                            if (exist.SalesOrderStatusId == 2 && exist.CashDiscountTotal > 0)
                            {
                                exist.CashDiscountTotal = 0;
                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;
                                exist.Update();

                                orderLoggerService.Log(exist.SalesId.Value, OrderLogType.Save, UserId);
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                                return responseModel;
                            }

                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                            return responseModel;
                        }

                        responseModel.Data = model;
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
        [HttpPost("copy")]
        public async Task<IActionResult> copy(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (model == null)
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
                        var exist = new Criteria<BOSalesOrder>()
                                        .Add(Expression.Eq(nameof(model.SalesId), model.SalesId))
                                        .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                        .FirstOrDefault<BOSalesOrder>();


                        if (exist != null)
                        {
                            var bo = new BOSalesOrder();
                            bo.HasError = false;
                            bo.SalesOrderSourceId = 1;
                            bo.IsDeleted = false;
                            bo.SalesOrderTypeId = 1;
                            bo.ClientId = exist.ClientId;
                            bo.BranchId = exist.BranchId;
                            bo.AgentId = UserId;
                            bo.RepresentativeId = exist.RepresentativeId;
                            bo.StoreId = exist.StoreId;
                            bo.PriorityTypeId = exist.PriorityTypeId;
                            bo.PaymentTermId = exist.PaymentTermId;
                            bo.SalesDate = DateTime.Now;
                            bo.SalesTime = DateTime.Now;
                            bo.SalesOrderStatusId = 1;
                            bo.SalesOrderSourceId = 1;
                            bo.SalesChannelId = exist.SalesChannelId;
                            bo.SalesPoolId = exist.SalesPoolId;
                            bo.IsOpened = true;
                            bo.OpenValue = 0;
                            bo.Latitude = exist.Latitude;
                            bo.Longitude = exist.Longitude;
                            bo.ItemTotal = exist.ItemTotal;
                            bo.ItemDiscountTotal = exist.ItemDiscountTotal;
                            bo.TaxTotal = exist.TaxTotal;

                            bo.CashDiscountTotal = exist.CashDiscountTotal;
                            bo.CustomDiscountTypeId = exist.CustomDiscountTypeId;
                            bo.CustomDiscountValue = exist.CustomDiscountValue;
                            bo.CustomDiscountTotal = exist.CustomDiscountTotal;
                            bo.DeliveryTotal = exist.DeliveryTotal;
                            bo.NetTotal = exist.NetTotal;
                            bo.TaxTotal = exist.TaxTotal;

                            bo.Notes = "";
                            bo.InvoiceRetry = 0;
                            bo.IsInvoiced = null;
                            bo.HasError = false;
                            bo.InvoiceCode = string.Empty;
                            bo.InvoiceDate = null;
                            bo.CreateDate = null;
                            bo.RecId = null;
                            bo.CBy = UserId;
                            bo.CDate = DateTime.Now;
                            bo.EBy = null;
                            bo.EDate = null;
                            bo.SalesPerenId = null;
                            bo.Inprogress = false;
                            bo.IsBackoffice = true;

                            bo.SaveNew();


                            if (bo.SalesId > 0)
                            {
                                bo.SalesCode = string.Format(_configuration["settings:prefix:order"], bo.SalesId.Value.ToString().PadLeft(12, '0'));
                                bo.Update();



                                foreach (var item in exist.SalesOrderDetailCollection())
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
                                    detail.CustomDiscount = item.CustomDiscount > 0 ? (decimal?)item.CustomDiscount : 0;
                                    detail.TaxValue = (decimal?)item.TaxValue;
                                    detail.IsBouns = item.IsBouns;
                                    detail.PromotionCode = item.PromotionCode;
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
                                }

                                // addd order address

                                var address = new Criteria<BOSalesOrderAddress>()
                                       .Add(Expression.Eq(nameof(BOSalesOrderAddress.SalesId), exist.SalesId))
                                       .FirstOrDefault<BOSalesOrderAddress>();

                                if (address != null)
                                {
                                    address.SalesId = bo.SalesId;
                                    address.SaveNew();
                                }

                                // add order log

                                orderLoggerService.Log(bo.SalesId.Value, OrderLogType.Save, UserId);

                            }




                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                            return responseModel;
                        }

                        responseModel.Data = model;
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
        [HttpPost("approve")]
        public async Task<IActionResult> approve(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (model == null)
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
                        var found = new Criteria<BOSalesOrder>()
                                             .Add(Expression.Eq(nameof(model.SalesId), model.SalesId))
                                             .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                             .FirstOrDefault<BOSalesOrder>();


                        if (found != null)
                        {
                            if (found.SalesOrderStatusId == 1 && found.HasError==false && found.NetTotal>0)
                            {

                                found.DeleteAllSalesOrderError();

                                found.SalesOrderStatusId = 2;
                                found.Update();

                               

                                var res = salesOrderManager.UpdateOnhand(found.SalesId.Value,false);
                               

                                responseModel.Data = model;
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                            }


                            orderLoggerService.Log(found.SalesId.Value, OrderLogType.Confirm, UserId);

                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                        }


                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;
                    }
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("validate")]
        public async Task<IActionResult> Validate(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (model == null)
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
                        var found = new Criteria<BOSalesOrder>()
                                             .Add(Expression.Eq(nameof(model.SalesId), model.SalesId))
                                             .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                             .FirstOrDefault<BOSalesOrder>();


                        if (found.Inprogress == true)
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                            return responseModel;
                        }


                        if (found != null)
                        {
                            if (found.SalesOrderStatusId == 1)
                            {

                                //model = PromotionCalculator.ValidateOrder(model, Language);
                                //model.HasError = false;

                                found.DeleteAllSalesOrderError();

                                if (model.HasError == true)
                                {
                                    foreach (var item in model.Errors)
                                    {
                                        var error = new BOSalesOrderError();
                                        error.SalesId = (long)model.SalesId;
                                        error.ErrorDate = DateTime.Now;
                                        error.ErrorDetail = item;
                                        error.SaveNew();
                                    }

                                    found.HasError = true;
                                    found.Update();
                                }


                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                            }


                            orderLoggerService.Log(found.SalesId.Value, OrderLogType.Confirm, UserId);

                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                        }


                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;
                    }
                }
                responseModel.Data = model;
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpPost("Open")]
        public async Task<IActionResult> Open(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (model == null)
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
                        var exist = new Criteria<BOSalesOrder>()
                                        .Add(Expression.Eq(nameof(model.SalesId), model.SalesId))
                                        .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                        .FirstOrDefault<BOSalesOrder>();


                        if (exist != null)
                        {
                            if (exist.Inprogress == true)
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                                return responseModel;
                            }

                            if (exist.SalesOrderStatusId == 2 || exist.IsInvoiced == null || exist.IsInvoiced==false)
                            {
                                exist.SalesOrderStatusId = 1;
                                exist.IsInvoiced = null;
                                exist.InvoiceDate = null;
                                exist.InvoiceCode = null;
                                exist.Update();

                                var res = salesOrderManager.UpdateOnhand(exist.SalesId.Value,true);

                                orderLoggerService.Log(exist.SalesId.Value, OrderLogType.Reopen, UserId);
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                                return responseModel;
                            }

                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                            return responseModel;
                        }

                        responseModel.Data = model;
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
        [HttpPost("OpenAll")]
        public async Task<IActionResult> OpenAll(ListNumberDto model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ListNumberDto> responseModel = new ResponseModel<ListNumberDto>();

                if (model == null)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else
                {
                    try
                    {
                        foreach (var item in model.Ids)
                        {
                            // check if exit code
                            var exist = new Criteria<BOSalesOrder>()
                                            .Add(Expression.Eq(nameof(BOSalesOrder.SalesId), item))
                                            .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                            .FirstOrDefault<BOSalesOrder>();


                            if (exist != null)
                            {
                                if (exist.Inprogress != true)
                                {
                                    if (exist.SalesOrderStatusId == 2 || exist.IsInvoiced == null || exist.IsInvoiced == false)
                                    {
                                        exist.SalesOrderStatusId = 1;
                                        exist.IsInvoiced = null;
                                        exist.InvoiceDate = null;
                                        exist.InvoiceCode = null;
                                        exist.Update();

                                        orderLoggerService.Log(exist.SalesId.Value, OrderLogType.Reopen, UserId);
                                        //todo
                                        var res = salesOrderManager.UpdateOnhand(exist.SalesId.Value, true);

                                    }
                                }
                                

                            }
                        }
                        

                        responseModel.Data = model;
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
        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(SalesOrderModelWeb model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SalesOrderModelWeb> responseModel = new ResponseModel<SalesOrderModelWeb>();

                if (model == null)
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
                        var exist = new Criteria<BOSalesOrder>()
                                        .Add(Expression.Eq(nameof(BOSalesOrder.SalesId), model.SalesId))
                                        .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), false))
                                        .FirstOrDefault<BOSalesOrder>();


                        if (exist != null)
                        {
                            if (exist.SalesOrderStatusId == 2)
                            {
                                exist.SalesOrderStatusId = 3;
                                exist.Update();

                                orderLoggerService.Log(exist.SalesId.Value, OrderLogType.Transfer, UserId);


                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                                return responseModel;
                            }

                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                            return responseModel;
                        }

                        responseModel.Data = model;
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
