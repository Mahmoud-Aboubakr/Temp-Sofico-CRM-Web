using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Promotion;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using SofiForce.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class SalesOrderControlController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IOrderLoggerService orderLoggerService;
        private readonly ISalesOrderControlManager salesOrderControlManager;

        public SalesOrderControlController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper, IOrderLoggerService orderLoggerService, ISalesOrderControlManager salesOrderControlManager) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
            this.orderLoggerService = orderLoggerService;
            this.salesOrderControlManager = salesOrderControlManager;
        }


        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(SalesOrderControlSearchModel model)
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SalesOrderListModel>> responseModel = new ResponseModel<List<SalesOrderListModel>>();

                try
                {

                    if (AppRoleId > 6)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = Messages.Invalid_Model;
                        return responseModel;
                    }


                    var ctr = new Criteria<BOSalesOrderVw>();

                    ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.IsDeleted), false));

                    ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderStatusId), model.SalesOrderStatusId));

                    if (FullDataAccess == false)
                    {
                        ctr.Add(Expression.In(nameof(BOSalesOrderVw.BranchId), Branchs));

                        if (AppRoleId == 6)
                        {
                            ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SupervisorUserId), UserId));
                        }
                    }


                    if (model.ClientId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.ClientId), model.ClientId));

                    if (model.SalesOrderTypeId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderTypeId), model.SalesOrderTypeId));

                    if (model.BranchId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.BranchId), model.BranchId));

                    if (model.RepresentativeId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.RepresentativeId), model.RepresentativeId));

                    if (model.StoreId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.StoreId), model.StoreId));



                    if (model.PriorityTypeId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.PriorityTypeId), model.PriorityTypeId));



                    if (model.RejectedOnly > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.HasError), model.RejectedOnly == 1 ? true : false));

                    if (model.SalesOrderStatusId < 4)
                    {
                        if (model.SalesDateFrom != null && model.SalesDateFrom.Value.Year > 1900)
                            ctr.Add(Expression.Gte(nameof(BOSalesOrderVw.SalesDate), model.SalesDateFrom, dateformatter));

                        if (model.SalesDateTo != null && model.SalesDateTo.Value.Year > 1900)
                            ctr.Add(Expression.Lte(nameof(BOSalesOrderVw.SalesDate), model.SalesDateTo, dateformatter));
                    }
                    else
                    {
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.InvoiceDate), DateTime.Now.Date, dateformatter));
                    }

                    // sort by 
                    if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                    {
                        switch (model.SortBy.Property)
                        {
                            case "storeName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("storeName{0}", Language)) : OrderBy.Desc(string.Format("storeName{0}", Language)));
                                break;
                            case "branchName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                break;
                            case "clientName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                                break;
                            case "paymentTermName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("paymentTermName{0}", Language)) : OrderBy.Desc(string.Format("paymentTermName{0}", Language)));
                                break;
                            case "representativeName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
                                break;
                            case "salesOrderSourceName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("salesOrderSourceName{0}", Language)) : OrderBy.Desc(string.Format("salesOrderSourceName{0}", Language)));
                                break;
                            case "salesOrderStatusName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("salesOrderStatusName{0}", Language)) : OrderBy.Desc(string.Format("salesOrderStatusName{0}", Language)));
                                break;
                            case "salesOrderTypeName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("salesOrderTypeName{0}", Language)) : OrderBy.Desc(string.Format("salesOrderTypeName{0}", Language)));
                                break;
                            case "priorityName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("priorityName{0}", Language)) : OrderBy.Desc(string.Format("priorityName{0}", Language)));
                                break;
                            default:
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                break;
                        }
                    }
                    else
                    {
                        ctr.Add(OrderBy.Desc(nameof(BOSalesOrderVw.SalesId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(model.Skip)
                                 .Take(model.Take > 0 ? model.Take : 30)
                                 .List<BOSalesOrderVw>().Select(a => new SalesOrderListModel()
                                 {
                                     SalesCode = a.SalesCode,
                                     BranchCode = a.BranchCode,
                                     ClientCode = a.ClientCode,
                                     ClientId = a.ClientId,
                                     InvoiceCode = a.InvoiceCode,
                                     InvoiceDate = a.InvoiceDate,
                                     NetTotal = a.NetTotal,
                                     RepresentativeCode = a.RepresentativeCode,
                                     SalesDate = a.SalesTime,
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
                                     Inprogress = a.Inprogress

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

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("markTransfer")]
        public async Task<IActionResult> markTransfer(ListNumberDto model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ListNumberDto> responseModel = new ResponseModel<ListNumberDto>();

                try
                {
                    if (model != null && model.Ids.Count > 0)
                    {
                        salesOrderControlManager.markTransfer(String.Join(',', model.Ids), UserId);
                    }
                    responseModel.Data = model;
                    responseModel.Total = model.Ids.Count;
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
    }
}
