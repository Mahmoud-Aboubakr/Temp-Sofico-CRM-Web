using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class ClientQuotaController : BaseController
    {
        public ClientQuotaController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientQuotaSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientQuotaListModel>> responseModel = new ResponseModel<List<ClientQuotaListModel>>();

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


                        var ctr = new Criteria<BOClientQuotaVw>();


                        ctr.Add(Expression.Lte(nameof(BOClientQuotaVw.FromDate), DateTime.Now.Date, dateformatter));
                        ctr.Add(Expression.Gte(nameof(BOClientQuotaVw.ToDate), DateTime.Now.Date, dateformatter));

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOClientQuotaVw.ClientCode), model.Term));
                        }

                        // branch Permissions

                        if (model.ItemId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientQuotaVw.ItemId), model.ItemId));

                        if (model.ClientId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientQuotaVw.ClientId), model.ClientId));


                        if (ctr.ListDataCriteria() == null || ctr.ListDataCriteria().Count == 0)
                        {
                            return responseModel;
                        }


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "itemName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
                                    break;
                                case "clientName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOClientQuotaVw.ItemId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 20)
                                     .List<BOClientQuotaVw>()
                                     .Select(a => new ClientQuotaListModel()
                                     {
                                         
                                        Quantity = a.Quantity,
                                        PublicPrice = a.PublicPrice,
                                        Discount = a.Discount,
                                        ClientCode = a.ClientCode,
                                        ClientId = a.ClientId,
                                        ClientPrice = a.ClientPrice,
                                        ItemCode = a.ItemCode,
                                        ItemId = a.ItemId,
                                        Remain=a.Remain,
                                        FromDate=a.FromDate,
                                        ToDate=a.ToDate,
                                        ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                                        ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,


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
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpGet("getHistory")]
        public async Task<IActionResult> getHistory(int ClientId,int ItemId)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientQuotaHistoryListModel>> responseModel = new ResponseModel<List<ClientQuotaHistoryListModel>>();

                if (ClientId == 0 && ItemId == 0)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else
                {
                    try
                    {


                        var ctr = new Criteria<BOItemQuotaByClientVw>();
                        ctr.Add(Expression.Gte(nameof(BOItemQuotaByClientVw.SalesDate), DateTime.Now.FirstDayOfMonth()));

                        if (ClientId > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemQuotaByClientVw.ClientId), ClientId));
                        if (ItemId > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemQuotaByClientVw.ItemId), ItemId));

                        var res = ctr.List<BOItemQuotaByClientVw>()
                            .Select(a => new ClientQuotaHistoryListModel()
                            {
                                ItemId = a.ItemId,
                                ClientId = a.ClientId,
                                BranchId = a.BranchId,
                                ClientCode = a.ClientCode,
                                CreateDate = a.SalesDate,
                                Quantity = a.Quantity,
                                ItemCode = a.ItemCode,
                                VendorId = a.VendorId,
                                InvoiceCode=a.InvoiceCode,
                                ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn

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
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

    }
}
