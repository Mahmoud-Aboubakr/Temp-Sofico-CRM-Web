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
    public class PromtionCriteriaSalesManController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPromotionService promotionService;

        public PromtionCriteriaSalesManController(IHttpContextAccessor contextAccessor, 
                        AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                        IHubContext<AppHub> hub,
                        IWebHostEnvironment _webHostEnvironment,
                        IPromotionService promotionService
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
            _hub = hub;
            webHostEnvironment = _webHostEnvironment;
            this.promotionService = promotionService;
        }

        [CheckAuthorizedAttribute]
        [HttpPost("save")]
        public async Task<IActionResult> save(PromtionCriteriaSalesManModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromtionCriteriaSalesManModel> responseModel = new ResponseModel<PromtionCriteriaSalesManModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaSalesMan>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesMan.SalesManCriteriaId), model.SalesManCriteriaId))
                                        .FirstOrDefault<BOPromtionCriteriaSalesMan>();


                        if (exist == null)
                        {
                            exist = new BOPromtionCriteriaSalesMan();

                            exist.PromotionId = model.PromotionId;
                            exist.SalesManAttributeId = model.SalesManAttributeId;
                            exist.ValueFrom = model.ValueFrom;


                            exist.IsActive = true;
                            exist.Excluded = model.Excluded;



                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.SalesManCriteriaId > 0)
                            {
                                model.SalesManCriteriaId = exist.SalesManCriteriaId.Value;
                            }


                        }
                        else
                        {




                            exist.PromotionId = model.PromotionId;
                            exist.SalesManAttributeId = model.SalesManAttributeId;
                            exist.ValueFrom = model.ValueFrom;


                            exist.IsActive = true;
                            exist.Excluded = model.Excluded;


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
        public async Task<IActionResult> delete(PromtionCriteriaSalesManModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromtionCriteriaSalesManModel> responseModel = new ResponseModel<PromtionCriteriaSalesManModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaSalesMan>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesMan.SalesManCriteriaId), model.SalesManCriteriaId))
                                        .FirstOrDefault<BOPromtionCriteriaSalesMan>();


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

            return Ok(task.Result.Result);
        }
        [CheckAuthorizedAttribute]
        [HttpGet("getByPromotion")]
        public async Task<IActionResult> getByPromotion(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromtionCriteriaSalesManModel>> responseModel = new ResponseModel<List<PromtionCriteriaSalesManModel>>();

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
                        var res = new Criteria<BOPromtionCriteriaSalesManVw>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManVw.PromotionId), Id))
                                        .List<BOPromtionCriteriaSalesManVw>();

                        if (res != null)
                        {
                            // update current

                            responseModel.Data = res.Select(a => new PromtionCriteriaSalesManModel()
                            {
                                PromotionId = a.PromotionId,
                                SalesManAttributeId = a.SalesManAttributeId,
                                SalesManAttributeCode = a.SalesManAttributeCode,
                                SalesManCriteriaId = a.SalesManCriteriaId.Value,
                                Excluded = a.Excluded,
                                IsActive = true,
                                ValueFrom = a.ValueFrom,

                            }).ToList();


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
    }
}
