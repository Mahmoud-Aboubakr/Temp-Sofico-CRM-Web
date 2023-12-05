using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ItemController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }



        [HttpPost("BatchChecker")]
        public async Task<IActionResult> BatchChecker(BatchCheckerSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ItemBatchCheckerListModel>> responseModel = new ResponseModel<List<ItemBatchCheckerListModel>>();


                if (model == null)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";
                    responseModel.StatusCode = 503;

                }
                else
                {
                    try
                    {


                        var ctr = new Criteria<BOItemBatchCheckerVw>();

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {

                            if (!string.IsNullOrEmpty(model.TermBy))
                            {
                                switch (model.TermBy)
                                {
                                    case "itemCode":
                                        ctr.Add(Expression.StartWith(nameof(BOItemBatchCheckerVw.ItemCode), model.Term));
                                        break;
                                    case "BatchNo":
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.BatchNo), model.Term));
                                        break;
                                    case "itemNameAr":
                                        ctr.Add(Expression.StartWith(nameof(BOItemBatchCheckerVw.ItemNameAr), model.Term));
                                        break;
                                    case "itemNameEn":
                                        ctr.Add(Expression.StartWith(nameof(BOItemBatchCheckerVw.ItemNameEn), model.Term));
                                        break;

                                    case "clientPrice":
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.ClientPrice), model.Term));
                                        break;
                                    case "publicPrice":
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.PublicPrice), model.Term));
                                        break;
                                    case "discount":
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.Discount), model.Term));
                                        break;
                                    default:
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.BatchNo), model.Term));
                                        break;
                                }
                            }

                        }


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "itemName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
                                    break;
                                case "vendorName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("vendorName{0}", Language)) : OrderBy.Desc(string.Format("vendorName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOItemVw.ItemId)));
                        }



                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOItemBatchCheckerVw>()
                                     .Select(a => new ItemBatchCheckerListModel()
                                     {


                                         ClientPrice = a.ClientPrice,
                                         Discount = a.Discount,
                                         ItemCode = a.ItemCode,
                                         ItemId = a.ItemId,
                                         PublicPrice = a.PublicPrice,
                                         VendorId = a.VendorId,
                                         VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
                                         ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                                         BatchNo=a.BatchNo,
                                         Quota=a.Quota>0?a.Quota:0,
                                         VendorCode=a.VendorCode

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
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

    }
}
