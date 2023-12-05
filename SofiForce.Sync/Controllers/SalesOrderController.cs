using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
{
    [Route("api/[controller]")]
    public class SalesOrderController : BaseController
    {
        private readonly IPromotionCalculator promotionCalculator;

        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public SalesOrderController(
            IPromotionCalculator promotionCalculator,

            IHttpContextAccessor contextAccessor, 
            IWebHostEnvironment env, 
            IConfiguration configuration, 
            IMapper mapper ) : base(contextAccessor)
        {
            this.promotionCalculator = promotionCalculator;
           
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
  
        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(SalesOrderSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SalesOrderListModel>> responseModel = new ResponseModel<List<SalesOrderListModel>>();

                try
                {
                    var ctr = new Criteria<BOSalesOrderVw>();
                    ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.IsDeleted), false));
                    ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderTypeId), 1));
                    // get by term
                    if (!string.IsNullOrEmpty(model.Term))
                    {

                        if (!string.IsNullOrEmpty(model.TermBy))
                        {
                            switch (model.TermBy)
                            {
                                case "representativeCode":
                                    ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.RepresentativeCode), model.Term));
                                    break;
                                case "clientCode":
                                    ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.ClientCode), model.Term));
                                    break;
                                case "branchCode":
                                    ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.BranchCode), model.Term));
                                    break;
                                case "storeCode":
                                    ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.StoreCode), model.Term));
                                    break;
                                case "invoiceCode":
                                    ctr.Add(Expression.EndWith(nameof(BOSalesOrderVw.InvoiceCode), model.Term));
                                    break;
                                case "salesCode":
                                    ctr.Add(Expression.EndWith(nameof(BOSalesOrderVw.SalesCode), model.Term));
                                    break;
                                
                                default:
                                    break;
                            }
                        }

                    }

                    if (FullDataAccess == false)
                    {
                        ctr.Add(Expression.In(nameof(BOSalesOrderVw.BranchId), Branchs));


                        if (this.AppRoleId == 6)
                        {
                            // get By Suppervisor
                            var clients = new Criteria<BORepresentativeClientVw>()
                                        .Add(Expression.Eq(nameof(BORepresentativeClientVw.SupervisorUserId), UserId))
                                        .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

                            ctr.Add(Expression.InSubQuery(nameof(BOSalesOrderVw.ClientId), clients));
                        }

                        if (this.AppRoleId == 7)
                        {
                            // get by Sales Rep

                            var clients = new Criteria<BORepresentativeClientVw>()
                                   .Add(Expression.Eq(nameof(BORepresentativeClientVw.RepresentativeUserId), UserId))
                                   .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

                            ctr.Add(Expression.InSubQuery(nameof(BOSalesOrderVw.ClientId), clients));

                        }

                    }

                    if (model.SalesOrderSourceId.Contains(1) || model.SalesOrderSourceId.Contains(2))
                    {
                        var origin = string.Join(",", model.SalesOrderSourceId);
                        string[] splitElements = origin.Split(',');
                        string convertedString = string.Join(",", Array.ConvertAll(splitElements, element => $"'{element}'"));
                        ctr.Add(Expression.In(nameof(BOSalesOrderVw.SalesOrderSourceId), convertedString));
                    }


                    if (model.ClientId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.ClientId), model.ClientId));



                    if (model.BranchId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.BranchId), model.BranchId));

                    if (model.RepresentativeId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.RepresentativeId), model.RepresentativeId));

                    if (model.StoreId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.StoreId), model.StoreId));

                    if (model.SalesOrderStatusId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesOrderStatusId), model.SalesOrderStatusId));

                    if (model.PriorityTypeId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.PriorityTypeId), model.PriorityTypeId));
                        

                    if (model.IsInvoiced > 0)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.IsInvoiced), model.IsInvoiced==1?true:false));

                    if (model.SalesDate !=null && model.SalesDate.Value.Year>1900)
                        ctr.Add(Expression.Eq(nameof(BOSalesOrderVw.SalesDate), model.SalesDate,dateformatter));

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
                        ctr.Add(OrderBy.Asc(nameof(BOSalesOrderVw.SalesOrderStatusId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(model.Skip)
                                 .Take(model.Take>0?model.Take:30)
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
                                     SalesDate = a.SalesDate,
                                     SalesId = a.SalesId.Value,
                                     IsInvoiced = a.IsInvoiced,
                                     StoreCode = a.StoreCode,
                                     SalesOrderStatusId = a.SalesOrderStatusId,
                                     salesOrderTypeId=a.SalesOrderTypeId,
                                     salesOrderSourceId=a.SalesOrderSourceId,
                                     StoreName =Language=="ar"?a.StoreNameAr:a.StoreNameEn,
                                     BranchName=Language=="ar"?a.BranchNameAr:a.BranchNameEn,
                                     ClientName=Language=="ar"?a.ClientNameAr:a.ClientNameEn,
                                     PaymentTermName=Language=="ar"?a.PaymentTermNameAr:a.PaymentTermNameEn,
                                     RepresentativeName=Language=="ar"?a.RepresentativeNameAr:a.RepresentativeNameEn,
                                     SalesOrderSourceName=Language=="ar"?a.SalesOrderSourceNameAr:a.SalesOrderSourceNameEn,
                                     SalesOrderStatusName=Language=="ar"?a.SalesOrderStatusNameAr:a.SalesOrderStatusNameEn,
                                     SalesOrderTypeName=Language=="ar"?a.SalesOrderTypeNameAr:a.SalesOrderTypeNameEn,
                                     PriorityName=Language=="ar"?a.PriorityNameAr:a.PriorityNameEn,
                                     HasError=a.HasError,
                                     IsBackoffice=a.IsBackoffice,
                                     Inprogress=a.Inprogress,

                                 }).ToList();



                    responseModel.Data = res;
                    responseModel.Total = Total;
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message;;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

       
    }
}
