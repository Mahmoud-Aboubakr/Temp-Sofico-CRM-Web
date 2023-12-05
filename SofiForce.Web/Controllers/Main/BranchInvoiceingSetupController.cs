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
    public class BranchInvoiceingSetupController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public BranchInvoiceingSetupController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }


        [HttpPost("filter")]
        public async Task<IActionResult> filter(BranchInvoiceingSetupSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<BranchInvoiceingSetupListModel>> responseModel = new ResponseModel<List<BranchInvoiceingSetupListModel>>();

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


                        var ctr = new Criteria<BOBranchInvoiceingSetupVw>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {

                            ctr.Add(Expression.Gt(nameof(BOBranchInvoiceingSetupVw.BranchCode), model.Term));

                        }

                        // branch Permissions


                        // get by model
                        if (model.BranchId > 0)
                            ctr.Add(Expression.Gt(nameof(BOBranchInvoiceingSetupVw.BranchId), model.BranchId));

                        if (model.ServiceWorkerId > 0)
                            ctr.Add(Expression.Gt(nameof(BOBranchInvoiceingSetupVw.BranchId), model.ServiceWorkerId));

                        if (model.IsEnabled > 0)
                            ctr.Add(Expression.Gt(nameof(BOBranchInvoiceingSetupVw.BranchId), model.IsEnabled==1?true:false));


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {

                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "serviceWorkerName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("serviceWorkerName{0}", Language)) : OrderBy.Desc(string.Format("serviceWorkerName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;

                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOBranchInvoiceingSetupVw.BranchId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0 ? model.Take : 30)
                                     .List<BOBranchInvoiceingSetupVw>()
                                     .Select(a=> new BranchInvoiceingSetupListModel()
                                     {
                                         BranchCode = a.BranchCode,
                                         BranchId = a.BranchId,
                                         IsEnabled = a.IsEnabled,
                                         ServiceWorkerId = a.ServiceWorkerId,
                                         ServiceWorkerCode = a.ServiceWorkerCode,
                                         SetupId=a.SetupId.Value,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         ServiceWorkerName = Language == "ar" ? a.ServiceWorkerNameAr : a.ServiceWorkerNameEn,
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
        public async Task<IActionResult> save(BranchInvoiceingSetupModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchInvoiceingSetupModel> responseModel = new ResponseModel<BranchInvoiceingSetupModel>();

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
                        var exist = new Criteria<BOBranchInvoiceingSetup>()
                                        .Add(Expression.Eq(nameof(model.BranchId), model.BranchId))
                                        .FirstOrDefault<BOBranchInvoiceingSetup>();


                        if (exist == null)
                        {



                            // create new
                            exist = new BOBranchInvoiceingSetup();
                            exist.BranchId = model.BranchId;

                            if (model.ServiceWorkerId > 0)
                            {
                                if (model.IsEnabled == null)
                                {
                                    exist.IsEnabled = true;
                                }
                                else
                                {
                                    exist.IsEnabled = model.IsEnabled;
                                }
                            }
                            
                            
                            exist.ServiceWorkerId = model.ServiceWorkerId;


                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;


                            exist.SaveNew();

                            if (exist.SetupId > 0)
                            {
                                model.SetupId = exist.SetupId.Value;


                            }



                        }
                        else
                        {
                            if (model.ServiceWorkerId > 0)
                            {
                                if (model.IsEnabled == null)
                                {
                                    exist.IsEnabled = true;
                                }
                                else
                                {
                                    exist.IsEnabled = model.IsEnabled;
                                }
                            }

                            exist.ServiceWorkerId = model.ServiceWorkerId;

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
                ResponseModel<BranchInvoiceingSetupModel> responseModel = new ResponseModel<BranchInvoiceingSetupModel>();

                try
                {
                    if (Id == 0)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = Messages.Invalid_Model;

                    }
                    else
                    {
                        var exist = new Criteria<BOBranchInvoiceingSetup>()
                                   .Add(Expression.Eq(nameof(BOBranchInvoiceingSetup.SetupId), Id))
                                   .FirstOrDefault<BOBranchInvoiceingSetup>();

                        if (exist != null)
                        {
                            // update current
                            responseModel.Data = _mapper.Map<BranchInvoiceingSetupModel>(exist);
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


        [HttpGet("enableAll")]
        public async Task<IActionResult> EnableAll()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchInvoiceingSetupModel> responseModel = new ResponseModel<BranchInvoiceingSetupModel>();

                try
                {
                    
                    
                    var list = new Criteria<BOBranchInvoiceingSetup>()
                                   .List<BOBranchInvoiceingSetup>();



                    foreach (var item in list)
                    {
                        item.IsEnabled = true;
                        item.EBy = UserId;
                        item.EDate=DateTime.Now;
                        item.Update();
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


        [HttpGet("disableAll")]
        public async Task<IActionResult> DisableAll()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchInvoiceingSetupModel> responseModel = new ResponseModel<BranchInvoiceingSetupModel>();

                try
                {


                    var list = new Criteria<BOBranchInvoiceingSetup>()
                                   .List<BOBranchInvoiceingSetup>();



                    foreach (var item in list)
                    {
                        item.IsEnabled = false;
                        item.EBy = UserId;
                        item.EDate = DateTime.Now;
                        item.Update();
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
        public async Task<IActionResult> delete(BranchInvoiceingSetupModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchInvoiceingSetupModel> responseModel = new ResponseModel<BranchInvoiceingSetupModel>();

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
                        var exist = new Criteria<BOBranchInvoiceingSetup>()
                                        .Add(Expression.Eq(nameof(model.SetupId), model.SetupId))
                                        .FirstOrDefault<BOBranchInvoiceingSetup>();


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
