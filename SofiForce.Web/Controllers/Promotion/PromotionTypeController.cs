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
    public class PromotionTypeController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper _mapper;

        public PromotionTypeController(IHttpContextAccessor contextAccessor, 
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
            this._mapper = mapper;
        }



        [HttpPost("filter")]
        public async Task<IActionResult> filter(PromotionTypeSearchModel searchModel)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromotionTypeModel>> responseModel = new ResponseModel<List<PromotionTypeModel>>();

                try
                {
                    var ctr = new Criteria<BOPromotionTypeVw>();

                    // get by term
                    if (!string.IsNullOrEmpty(searchModel.Term))
                    {

                        ctr.Add(Expression.Eq(nameof(BOPromotionTypeVw.PromotionTypeCode), searchModel.Term));

                    }



                    if (searchModel.PromotionInputId > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionTypeVw.PromotionInputId), searchModel.PromotionInputId));
                    if (searchModel.PromotionOutputId > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionTypeVw.PromotionOutputId), searchModel.PromotionOutputId));

                    if (searchModel.IsActive > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionTypeVw.IsActive), searchModel.IsActive == 1 ? true : false));



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
                        ctr.Add(OrderBy.Desc(nameof(BOPromotionTypeVw.PromotionTypeId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(searchModel.Skip)
                                 .Take(searchModel.Take)
                                 .List<BOPromotionTypeVw>().Select(a => new PromotionTypeModel()
                                 {
                                     PromotionInputId=a.PromotionInputId,
                                     PromotionTypeId=a.PromotionTypeId.Value,
                                     PromotionOutputId=a.PromotionOutputId,
                                     IsActive=a.IsActive,
                                     PromotionTypeCode=a.PromotionTypeCode,
                                     CanDelete=a.CanDelete,
                                     CanEdit=a.CanEdit,
                                     DisplayOrder=a.DisplayOrder,
                                     PromotionInputCode=a.PromotionInputCode,
                                     PromotionOutputCode=a.PromotionOutputCode,
                                     PromotionTypeNameAr=a.PromotionTypeNameAr,
                                     PromotionTypeNameEn=a.PromotionTypeNameEn
                                     
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

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOPromotionType>();

                ctr.Add(OrderBy.Desc(nameof(BOPromotionType.CDate)));

                var res = ctr.List<BOPromotionType>().Select(a => new LookupModel()
                {

                    Id = a.PromotionTypeId.Value,
                    Code = a.PromotionTypeCode,
                    Name = Language == "ar" ? a.PromotionTypeNameAr : a.PromotionTypeNameEn

                }).ToList();

                responseModel.Data = res;

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
                ResponseModel<PromotionTypeModel> responseModel = new ResponseModel<PromotionTypeModel>();

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
                        var exist = new Criteria<BOPromotionType>()
                                        .Add(Expression.Eq(nameof(BOPromotionType.PromotionTypeId), Id))
                                        .FirstOrDefault<BOPromotionType>();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<PromotionTypeModel>(exist);


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



        [HttpPost("save")]
        public async Task<IActionResult> save(PromotionTypeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromotionTypeModel> responseModel = new ResponseModel<PromotionTypeModel>();

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
                        var exist = new Criteria<BOPromotionType>()
                                        .Add(Expression.Eq(nameof(BOPromotionType.PromotionTypeId), model.PromotionTypeId))
                                        .FirstOrDefault<BOPromotionType>();


                        if (exist == null)
                        {
                            exist = new BOPromotionType();

                            exist.PromotionTypeCode = model.PromotionTypeCode.ToUpper();
                            exist.PromotionTypeNameAr = model.PromotionTypeNameAr;
                            exist.PromotionTypeNameEn = model.PromotionTypeNameEn;
                            exist.PromotionTypeDesc = model.PromotionTypeDesc;
                            exist.PromotionInputId = model.PromotionInputId;
                            exist.PromotionOutputId = model.PromotionOutputId;


                            exist.IsActive = true;

                           
                            exist.CanEdit = true;
                            exist.CanDelete = true;
                            exist.DisplayOrder = model.DisplayOrder != null ? model.DisplayOrder : 0;


                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.PromotionTypeId > 0)
                            {
                                model.PromotionTypeId = exist.PromotionTypeId.Value;
                            }


                        }
                        else
                        {



                            exist.PromotionTypeCode = model.PromotionTypeCode.ToUpper();
                            exist.PromotionTypeNameAr = model.PromotionTypeNameAr;
                            exist.PromotionTypeNameEn = model.PromotionTypeNameEn;
                            exist.PromotionTypeDesc = model.PromotionTypeDesc;
                            exist.PromotionInputId = model.PromotionInputId;
                            exist.PromotionOutputId = model.PromotionOutputId;


                            exist.IsActive = true;


                            exist.CanEdit = true;
                            exist.CanDelete = true;
                            exist.DisplayOrder = model.DisplayOrder != null ? model.DisplayOrder : 0;


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

    }
}
