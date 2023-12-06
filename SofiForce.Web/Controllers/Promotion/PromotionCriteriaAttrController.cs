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
using SofiForce.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class PromotionCriteriaAttrController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly IPromotionService promotionService;

        public PromotionCriteriaAttrController(IHttpContextAccessor contextAccessor, 
                         AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                        IHubContext<AppHub> hub,
                        IWebHostEnvironment _webHostEnvironment,
                        IMapper mapper,
                        IPromotionService promotionService
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
            _hub = hub;
            webHostEnvironment = _webHostEnvironment;
            _mapper = mapper;
            this.promotionService = promotionService;
        }

        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(PromotionCriteriaAttrSearchModel searchModel)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromotionCriteriaAttrModel>> responseModel = new ResponseModel<List<PromotionCriteriaAttrModel>>();

                try
                {
                    var ctr = new Criteria<BOPromotionCriteriaAttr>();

                    // get by term
                    if (!string.IsNullOrEmpty(searchModel.Term))
                    {

                        ctr.Add(Expression.Eq(nameof(BOPromotionCriteriaAttr.AttributeCode), searchModel.Term));

                    }


                    if (searchModel.IsActive > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionCriteriaAttr.IsActive), searchModel.IsActive == 1 ? true : false));

                    if (searchModel.IsCustom > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionCriteriaAttr.IsCustom), searchModel.IsCustom == 1 ? true : false));

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
                        ctr.Add(OrderBy.Desc(nameof(BOPromotionCriteriaAttr.AttributeId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(searchModel.Skip)
                                 .Take(searchModel.Take)
                                 .List<BOPromotionCriteriaAttr>().Select(a => new PromotionCriteriaAttrModel()
                                 {
                                     AttributeId = a.AttributeId.Value,
                                     AttributeCode = a.AttributeCode,
                                     AttributeNameAr=a.AttributeNameAr,
                                     AttributeNameEn=a.AttributeNameEn,
                                     CanDelete=a.CanDelete,
                                     AttributeNameDesc=a.AttributeNameDesc,
                                     CanEdit=a.CanEdit,
                                     DisplayOrder=a.DisplayOrder,
                                     IsActive=a.IsActive,
                                     IsCustom=a.IsCustom,

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

                var ctr = new Criteria<BOPromotionCriteriaAttr>();

                ctr.Add(OrderBy.Asc(nameof(BOPromotionCriteriaAttr.IsCustom)));
                ctr.Add(OrderBy.Asc(nameof(BOPromotionCriteriaAttr.DisplayOrder)));

                var res = ctr.List<BOPromotionCriteriaAttr>().Select(a => new LookupModel()
                {

                    Id = a.AttributeId.Value,
                    Code = a.AttributeCode,
                    Name = Language == "ar" ? a.AttributeNameAr : a.AttributeNameEn

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
                ResponseModel<PromotionCriteriaAttrModel> responseModel = new ResponseModel<PromotionCriteriaAttrModel>();

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
                        var exist = new Criteria<BOPromotionCriteriaAttr>()
                                        .Add(Expression.Eq(nameof(BOPromotionCriteriaAttr.AttributeId), Id))
                                        .FirstOrDefault<BOPromotionCriteriaAttr>();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<PromotionCriteriaAttrModel>(exist);


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
        public async Task<IActionResult> save(PromotionCriteriaAttrModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionCriteriaAttrModel> responseModel = new ResponseModel<PromotionCriteriaAttrModel>();

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
                        var exist = new Criteria<BOPromotionCriteriaAttr>()
                                        .Add(Expression.Eq(nameof(BOPromotionCriteriaAttr.AttributeId), model.AttributeId))
                                        .FirstOrDefault<BOPromotionCriteriaAttr>();


                        if (exist == null)
                        {
                            exist = new BOPromotionCriteriaAttr();

                            exist.AttributeCode = model.AttributeCode.ToUpper();
                            exist.AttributeNameAr=model.AttributeNameAr;
                            exist.AttributeNameEn=model.AttributeNameEn;
                            exist.AttributeNameDesc=model.AttributeNameDesc;
                            exist.IsActive=true;
                            exist.IsCustom = true;
                            exist.DisplayOrder=model.DisplayOrder;
                            exist.CanDelete=model.CanDelete;
                            exist.CanEdit=model.CanEdit;



                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.AttributeId > 0)
                            {
                                model.AttributeId = exist.AttributeId.Value;
                            }


                        }
                        else
                        {


                            exist.AttributeCode = model.AttributeCode.ToUpper();
                            exist.AttributeNameAr = model.AttributeNameAr;
                            exist.AttributeNameEn = model.AttributeNameEn;
                            exist.AttributeNameDesc = model.AttributeNameDesc;
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
        public async Task<IActionResult> delete(PromotionCriteriaAttrModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionCriteriaAttrModel> responseModel = new ResponseModel<PromotionCriteriaAttrModel>();

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
                        var exist = new Criteria<BOPromotionCriteriaAttr>()
                              .Add(Expression.Eq(nameof(BOPromotionCriteriaAttr.AttributeId), model.AttributeId))
                              .FirstOrDefault<BOPromotionCriteriaAttr>();


                        if (exist != null)
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
