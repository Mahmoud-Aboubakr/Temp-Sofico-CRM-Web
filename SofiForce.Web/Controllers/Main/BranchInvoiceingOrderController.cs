using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class BranchInvoiceingOrderController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public BranchInvoiceingOrderController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }


        [HttpPost("filter")]
        public async Task<IActionResult> filter(BranchInvoiceingOrderSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<BranchInvoiceingOrderListModel>> responseModel = new ResponseModel<List<BranchInvoiceingOrderListModel>>();

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


                        var ctr = new Criteria<BOBranchInvoiceingOrderVw>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {

                            ctr.Add(Expression.Gt(nameof(BOBranchInvoiceingOrderVw.BranchCode), model.Term));

                        }

                        // branch Permissions


                        // get by model
                        if (model.BranchId > 0)
                            ctr.Add(Expression.Gt(nameof(BOBranchInvoiceingOrderVw.BranchId), model.BranchId));
                     

                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                              
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOBranchInvoiceingOrderVw.BranchId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0 ?model.Take : 30)
                                     .List<BOBranchInvoiceingOrderVw>()
                                     .Select(a=> new BranchInvoiceingOrderListModel()
                                     {

                                         BranchCode = a.BranchCode,
                                         BranchId = a.BranchId,
                                         SortDirection = a.SortDirection,
                                         SortOrder = a.SortOrder,
                                         SortOrderId = a.SortOrderId.Value,
                                         SortProperty = a.SortProperty,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
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


        [HttpPost("save")]
        public async Task<IActionResult> save(BranchInvoiceingOrderModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchInvoiceingOrderModel> responseModel = new ResponseModel<BranchInvoiceingOrderModel>();

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
                        var exist = new Criteria<BOBranchInvoiceingOrder>()
                                        .Add(Expression.Eq(nameof(model.BranchId), model.BranchId))
                                        .FirstOrDefault<BOBranchInvoiceingOrder>();


                        if (exist == null)
                        {



                            // create new
                            exist = new BOBranchInvoiceingOrder();
                            exist.BranchId = model.BranchId;
                            exist.SortOrder = model.SortOrder;
                            exist.SortDirection = model.SortDirection;
                            exist.SortProperty = model.SortProperty;


                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;


                            exist.SaveNew();

                            if (exist.SortOrderId > 0)
                            {
                                model.SortOrderId = exist.SortOrderId.Value;


                            }



                        }
                        else
                        {

                            exist.SortOrder = model.SortOrder;
                            exist.SortDirection = model.SortDirection;
                            exist.SortProperty = model.SortProperty;

                            exist.EBy = UserId;
                            exist.EDate = DateTime.Now;


                            exist.Update();




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


        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchInvoiceingOrderModel> responseModel = new ResponseModel<BranchInvoiceingOrderModel>();

                try
                {
                    if (Id == 0)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = Messages.Invalid_Model;

                    }
                    else
                    {
                        var exist = new Criteria<BOBranchInvoiceingOrder>()
                                   .Add(Expression.Eq(nameof(BOBranchInvoiceingOrder.SortOrderId), Id))
                                   .FirstOrDefault<BOBranchInvoiceingOrder>();

                        if (exist != null)
                        {
                            // update current
                            responseModel.Data = _mapper.Map<BranchInvoiceingOrderModel>(exist);
                            responseModel.Total = 1;

                        }

                    }


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


        [HttpPost("delete")]
        public async Task<IActionResult> delete(BranchInvoiceingOrderModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchInvoiceingOrderModel> responseModel = new ResponseModel<BranchInvoiceingOrderModel>();

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
                        var exist = new Criteria<BOBranchInvoiceingOrder>()
                                        .Add(Expression.Eq(nameof(model.SortOrderId), model.SortOrderId))
                                        .FirstOrDefault<BOBranchInvoiceingOrder>();


                        if (exist != null)
                        {
                            exist.Delete();
                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.Message = Messages.Invalid_Model;
                            responseModel.StatusCode = 503;

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
