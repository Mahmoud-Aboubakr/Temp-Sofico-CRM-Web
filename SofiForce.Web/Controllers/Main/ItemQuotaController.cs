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
    public class ItemQuotaController : BaseController
    {
        public ItemQuotaController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(ItemQuotaSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ItemQuotaListModel>> responseModel = new ResponseModel<List<ItemQuotaListModel>>();

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


                        var ctr = new Criteria<BOItemQuotaVw>();

                        ctr.Add(Expression.Lte(nameof(BOItemQuotaVw.FromDate), DateTime.Now.Date,dateformatter));
                        ctr.Add(Expression.Gte(nameof(BOItemQuotaVw.ToDate), DateTime.Now.Date, dateformatter));

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOItemQuotaVw.ItemCode), model.Term));
                        }

                        // branch Permissions

                        if (model.ItemId > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemQuotaVw.ItemId), model.ItemId));


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
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOItemQuotaVw.ItemId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 20)
                                     .List<BOItemQuotaVw>()
                                     .Select(a => new ItemQuotaListModel()
                                     {
                                         
                                         ItemId = a.ItemId,
                                         ItemCode = a.ItemCode,
                                         ClientPrice = a.ClientPrice,
                                         Discount = a.Discount,
                                         IsActive = a.IsActive,
                                         PublicPrice = a.PublicPrice,
                                         Quantity=a.Quantity,
                                         ToDate = a.ToDate,
                                         FromDate=a.FromDate,
                                         ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,


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

    }
}
