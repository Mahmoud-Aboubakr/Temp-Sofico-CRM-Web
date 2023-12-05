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
    public class PromotionCriteriaController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPromotionService promotionService;

        public PromotionCriteriaController(IHttpContextAccessor contextAccessor, 
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



        [HttpPost("save")]
        public async Task<IActionResult> save(PromotionCriteriaModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionCriteriaModel> responseModel = new ResponseModel<PromotionCriteriaModel>();

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
                        var exist = new Criteria<BOPromotionCriteria>()
                                        .Add(Expression.Eq(nameof(BOPromotionCriteria.CriteriaId), model.CriteriaId))
                                        .FirstOrDefault<BOPromotionCriteria>();


                        if (exist == null)
                        {
                            exist = new BOPromotionCriteria();

                            exist.PromotionId = model.PromotionId;
                            exist.GroupId = model.GroupId>0?model.GroupId:null;
                            exist.AttributeId = model.AttributeId;
                            exist.ValueFrom = model.ValueFrom;

                           

                            exist.IsActive = true;
                            exist.Excluded = model.Excluded;



                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.CriteriaId > 0)
                            {
                                model.CriteriaId = exist.CriteriaId.Value;
                            }


                        }
                        else
                        {



                            exist.PromotionId = model.PromotionId;
                            exist.GroupId = model.GroupId > 0 ? model.GroupId : null;
                            exist.AttributeId = model.AttributeId;
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


        [HttpGet("getByPromotion")]
        public async Task<IActionResult> getByPromotion(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromotionCriteriaModel>> responseModel = new ResponseModel<List<PromotionCriteriaModel>>();

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
                        var res = new Criteria<BOPromotionCriteriaVw>()
                                        .Add(Expression.Eq(nameof(BOPromotionCriteriaVw.PromotionId), Id))
                                        .List<BOPromotionCriteriaVw>();
                        if (res != null)
                        {
                            // update current

                            responseModel.Data = res.Select(a=> new PromotionCriteriaModel()
                            {
                                PromotionId = a.PromotionId,
                                AttributeId = a.AttributeId,
                                AttributeCode = a.AttributeCode,
                                CriteriaId = a.CriteriaId.Value,
                                Excluded = a.Excluded,
                                GroupId = a.GroupId,
                                IsActive = a.IsActive,
                                ValueFrom = a.ValueFrom,

                                GroupNo=a.GroupNo,
                                Slice=(double?)a.Slice,

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


        [HttpPost("delete")]
        public async Task<IActionResult> delete(PromotionCriteriaModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionCriteriaModel> responseModel = new ResponseModel<PromotionCriteriaModel>();

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
                        var exist = new Criteria<BOPromotionCriteria>()
                                        .Add(Expression.Eq(nameof(BOPromotionCriteria.CriteriaId), model.CriteriaId))
                                        .FirstOrDefault<BOPromotionCriteria>();


                        if (exist != null)
                        {
                            exist.Delete();

                            promotionService.RebuildPromotionItem(exist.PromotionId.Value);

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
