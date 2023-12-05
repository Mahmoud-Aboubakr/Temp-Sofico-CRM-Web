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
    public class PromtionCriteriaClientController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPromotionService promotionService;

        public PromtionCriteriaClientController(IHttpContextAccessor contextAccessor, 
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
        public async Task<IActionResult> save(PromtionCriteriaClientModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromtionCriteriaClientModel> responseModel = new ResponseModel<PromtionCriteriaClientModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaClient>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaClient.ClientCriteriaId), model.ClientCriteriaId))
                                        .FirstOrDefault<BOPromtionCriteriaClient>();


                        if (exist == null)
                        {
                            exist = new BOPromtionCriteriaClient();

                            exist.PromotionId = model.PromotionId;
                            exist.ClientAttributeId = model.ClientAttributeId;
                            exist.ValueFrom = model.ValueFrom;


                            exist.IsActive = true;
                            exist.Excluded = model.Excluded;



                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.ClientCriteriaId > 0)
                            {
                                model.ClientCriteriaId = exist.ClientCriteriaId.Value;
                            }


                        }
                        else
                        {




                            exist.PromotionId = model.PromotionId;
                            exist.ClientAttributeId = model.ClientAttributeId;
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


        [HttpPost("delete")]
        public async Task<IActionResult> delete(PromtionCriteriaClientModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromtionCriteriaClientModel> responseModel = new ResponseModel<PromtionCriteriaClientModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaClient>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaClient.ClientCriteriaId), model.ClientCriteriaId))
                                        .FirstOrDefault<BOPromtionCriteriaClient>();


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

        [HttpGet("getByPromotion")]
        public async Task<IActionResult> getByPromotion(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromtionCriteriaClientModel>> responseModel = new ResponseModel<List<PromtionCriteriaClientModel>>();

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
                        var res = new Criteria<BOPromtionCriteriaClientVw>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaClientVw.PromotionId), Id))
                                        .List<BOPromtionCriteriaClientVw>();
                        if (res != null)
                        {
                            // update current

                            responseModel.Data = res.Select(a => new PromtionCriteriaClientModel()
                            {
                                PromotionId = a.PromotionId,
                                ClientAttributeId = a.ClientAttributeId,
                                ClientAttributeCode = a.ClientAttributeCode,
                                ClientCriteriaId = a.ClientCriteriaId.Value,
                                Excluded = a.Excluded,
                                IsActive = a.IsActive,
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
