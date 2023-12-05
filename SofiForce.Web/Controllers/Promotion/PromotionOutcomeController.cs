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
    public class PromotionOutcomeController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;


        public PromotionOutcomeController(IHttpContextAccessor contextAccessor, 
                         AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                        IHubContext<AppHub> hub,
                        IWebHostEnvironment _webHostEnvironment
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
            _hub = hub;
            webHostEnvironment = _webHostEnvironment;
        }

        [CheckAuthorizedAttribute]
        [HttpPost("save")]
        public async Task<IActionResult> save(PromotionOutcomeModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionOutcomeModel> responseModel = new ResponseModel<PromotionOutcomeModel>();

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
                        var exist = new Criteria<BOPromotionOutcome>()
                                        .Add(Expression.Eq(nameof(BOPromotionOutcome.OutcomeId), model.OutcomeId))
                                        .FirstOrDefault<BOPromotionOutcome>();


                        if (exist == null)
                        {
                            exist = new BOPromotionOutcome();

                            exist.PromotionId = model.PromotionId;
                            exist.IsActive=true;
                            exist.Count = model.Count;
                            exist.DisplayOrder = model.DisplayOrder;
                            exist.ItemCode = model.ItemCode;
                            exist.Slice = model.Slice;
                            exist.Value = model.Value;



                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.OutcomeId > 0)
                            {
                                model.OutcomeId = exist.OutcomeId.Value;
                            }


                        }
                        else
                        {



                            exist.IsActive = true;
                            exist.Count = model.Count;
                            exist.DisplayOrder = model.DisplayOrder;
                            exist.ItemCode = model.ItemCode;
                            exist.Slice = model.Slice;
                            exist.Value = model.Value;

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
                        responseModel.Message = ex.Message;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("delete")]
        public async Task<IActionResult> delete(PromotionOutcomeModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionOutcomeModel> responseModel = new ResponseModel<PromotionOutcomeModel>();

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
                        var exist = new Criteria<BOPromotionOutcome>()
                                        .Add(Expression.Eq(nameof(BOPromotionOutcome.OutcomeId), model.OutcomeId))
                                        .FirstOrDefault<BOPromotionOutcome>();


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
                        responseModel.Message = ex.Message;
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
                ResponseModel<List<PromotionOutcomeModel>> responseModel = new ResponseModel<List<PromotionOutcomeModel>>();

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
                        var res = new Criteria<BOPromotionOutcome>()
                                        .Add(Expression.Eq(nameof(BOPromotionOutcome.PromotionId), Id))
                                        .List<BOPromotionOutcome>();
                        if (res != null)
                        {
                            // update current

                            responseModel.Data = res.Select(a => new PromotionOutcomeModel()
                            {
                                OutcomeId = a.OutcomeId.Value,
                                Value = a.Value,
                                Slice = a.Slice,
                                ItemCode = a.ItemCode,
                                IsActive = a.IsActive,
                                PromotionId = a.PromotionId,
                                DisplayOrder = a.DisplayOrder,
                                Count = a.Count,
                                
                                
                                

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
