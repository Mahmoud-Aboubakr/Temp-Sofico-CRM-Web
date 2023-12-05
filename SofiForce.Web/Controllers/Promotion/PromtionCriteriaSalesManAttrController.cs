using AutoMapper;
using Helpers;
using Hubs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class PromtionCriteriaSalesManAttrController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper _mapper;

        public PromtionCriteriaSalesManAttrController(IHttpContextAccessor contextAccessor, 
                         AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                       IHubContext<AppHub> hub,
                        IWebHostEnvironment _webHostEnvironment,
                         IMapper mapper
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
           _hub = hub;
            webHostEnvironment = _webHostEnvironment;
            _mapper = mapper;
        }

        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(PromtionCriteriaSalesManAttrSearchModel searchModel)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromtionCriteriaSalesManAttrModel>> responseModel = new ResponseModel<List<PromtionCriteriaSalesManAttrModel>>();

                try
                {
                    var ctr = new Criteria<BOPromtionCriteriaSalesManAttr>();

                    // get by term
                    if (!string.IsNullOrEmpty(searchModel.Term))
                    {

                        ctr.Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttr.SalesManAttributeCode), searchModel.Term));

                    }


                    if (searchModel.IsActive > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttr.IsActive), searchModel.IsActive == 1 ? true : false));

                    if (searchModel.IsCustom > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttr.IsCustom), searchModel.IsActive == 1 ? true : false));

                    // sort by 
                    if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                    {
                        switch (searchModel.SortBy.Property)
                        {


                            default:
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                                break;
                        }
                    }
                    else
                    {
                        ctr.Add(OrderBy.Desc(nameof(BOPromtionCriteriaSalesManAttr.SalesManAttributeId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(searchModel.Skip)
                                 .Take(searchModel.Take)
                                 .List<BOPromtionCriteriaSalesManAttr>().Select(a => new PromtionCriteriaSalesManAttrModel()
                                 {
                                    SalesManAttributeId = a.SalesManAttributeId.Value,
                                    SalesManAttributeCode = a.SalesManAttributeCode,
                                    IsCustom = a.IsCustom,
                                    IsActive = a.IsActive,
                                    DisplayOrder = a.DisplayOrder,
                                    CanEdit = a.CanEdit,
                                    CanDelete = a.CanDelete,
                                    SalesManAttributeNameAr=a.SalesManAttributeNameAr,
                                    SalesManAttributeNameEn=a.SalesManAttributeNameEn,
                                    

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
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOPromtionCriteriaSalesManAttr>();

                ctr.Add(OrderBy.Asc(nameof(BOPromtionCriteriaSalesManAttr.IsCustom)));
                ctr.Add(OrderBy.Asc(nameof(BOPromtionCriteriaSalesManAttr.DisplayOrder)));

                var res = ctr.List<BOPromtionCriteriaSalesManAttr>().Select(a => new LookupModel()
                {

                    Id = a.SalesManAttributeId.Value,
                    Code = a.SalesManAttributeCode,
                    Name = Language == "ar" ? a.SalesManAttributeNameAr : a.SalesManAttributeNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromtionCriteriaSalesManAttrModel> responseModel = new ResponseModel<PromtionCriteriaSalesManAttrModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaSalesManAttr>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttr.SalesManAttributeId), Id))
                                        .FirstOrDefault<BOPromtionCriteriaSalesManAttr>();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<PromtionCriteriaSalesManAttrModel>(exist);


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
        [HttpPost("save")]
        public async Task<IActionResult> save(PromtionCriteriaSalesManAttrModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromtionCriteriaSalesManAttrModel> responseModel = new ResponseModel<PromtionCriteriaSalesManAttrModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaSalesManAttr>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttr.SalesManAttributeId), model.SalesManAttributeId))
                                        .FirstOrDefault<BOPromtionCriteriaSalesManAttr>();


                        if (exist == null)
                        {
                            exist = new BOPromtionCriteriaSalesManAttr();

                            exist.SalesManAttributeCode = model.SalesManAttributeCode.ToUpper();
                            exist.SalesManAttributeNameAr = model.SalesManAttributeNameAr;
                            exist.SalesManAttributeNameEn = model.SalesManAttributeNameEn;
                            exist.SalesManAttributeDesc = model.SalesManAttributeDesc;
                            exist.IsActive = true;
                            exist.IsCustom = true;
                            exist.DisplayOrder = model.DisplayOrder;
                            exist.CanDelete = model.CanDelete;
                            exist.CanEdit = model.CanEdit;



                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.SalesManAttributeId > 0)
                            {
                                model.SalesManAttributeId = exist.SalesManAttributeId.Value;
                            }


                        }
                        else
                        {

                            exist.SalesManAttributeCode = model.SalesManAttributeCode.ToUpper();
                            exist.SalesManAttributeNameAr = model.SalesManAttributeNameAr;
                            exist.SalesManAttributeNameEn = model.SalesManAttributeNameEn;
                            exist.SalesManAttributeDesc = model.SalesManAttributeDesc;
                            exist.IsActive = true;
                            exist.IsCustom = true;
                            exist.DisplayOrder = model.DisplayOrder;
                            exist.CanDelete = model.CanDelete;
                            exist.CanEdit = model.CanEdit;


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

            return Ok(task.Result.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("delete")]
        public async Task<IActionResult> delete(PromtionCriteriaSalesManAttrModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromtionCriteriaSalesManAttrModel> responseModel = new ResponseModel<PromtionCriteriaSalesManAttrModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaSalesManAttr>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttr.SalesManAttributeId), model.SalesManAttributeId))
                                        .FirstOrDefault<BOPromtionCriteriaSalesManAttr>();


                        if (exist == null)
                        {
                            if (exist.CanDelete == true)
                            {
                                exist.Delete();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 503;
                            }


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

            return Ok(task.Result.Result);
        }
    }
}
