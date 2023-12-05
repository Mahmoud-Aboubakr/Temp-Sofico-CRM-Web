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
    public class PromotionMixGroupController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;


        public PromotionMixGroupController(IHttpContextAccessor contextAccessor, 
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


        [HttpPost("save")]
        public async Task<IActionResult> save(PromotionMixGroupModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionMixGroupModel> responseModel = new ResponseModel<PromotionMixGroupModel>();

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
                        var exist = new Criteria<BOPromotionMixGroup>()
                                        .Add(Expression.Eq(nameof(BOPromotionMixGroup.GroupId), model.GroupId))
                                        .FirstOrDefault<BOPromotionMixGroup>();


                        if (exist == null)
                        {
                            exist = new BOPromotionMixGroup();

                            exist.PromotionId = model.PromotionId;
                            exist.IsActive = true;
                            exist.GroupNo = model.GroupNo;
                            exist.Slice = model.Slice;



                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.GroupId > 0)
                            {
                                model.GroupId = exist.GroupId.Value;
                            }


                        }
                        else
                        {




                            exist.PromotionId = model.PromotionId;
                            exist.IsActive = true;
                            exist.GroupNo = model.GroupNo;
                            exist.Slice = model.Slice;

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


        [HttpGet("getByPromotion")]
        public async Task<IActionResult> getByPromotion(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromotionMixGroupModel>> responseModel = new ResponseModel<List<PromotionMixGroupModel>>();

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
                        var res = new Criteria<BOPromotionMixGroup>()
                                        .Add(Expression.Eq(nameof(BOPromotionMixGroup.PromotionId), Id))
                                        .List<BOPromotionMixGroup>();
                        if (res != null)
                        {
                            // update current

                            responseModel.Data = res.Select(a => new PromotionMixGroupModel()
                            {
                               GroupId=a.GroupId.Value,
                               GroupNo=a.GroupNo,
                               IsActive=a.IsActive,
                               PromotionId=a.PromotionId,
                               Slice=a.Slice

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
        public async Task<IActionResult> delete(PromotionMixGroupModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionMixGroupModel> responseModel = new ResponseModel<PromotionMixGroupModel>();

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
                        var exist = new Criteria<BOPromotionMixGroup>()
                                        .Add(Expression.Eq(nameof(BOPromotionMixGroup.GroupId), model.GroupId))
                                        .FirstOrDefault<BOPromotionMixGroup>();


                        if (exist != null)
                        {
                            //exist.DeleteAllPromotionCriteria();
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
    }
}
