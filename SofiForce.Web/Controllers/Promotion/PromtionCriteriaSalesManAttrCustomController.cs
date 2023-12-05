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
    public class PromtionCriteriaSalesManAttrCustomController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;


        public PromtionCriteriaSalesManAttrCustomController(IHttpContextAccessor contextAccessor, 
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
        public async Task<IActionResult> save(PromtionCriteriaSalesManAttrCustomModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromtionCriteriaSalesManAttrCustomModel> responseModel = new ResponseModel<PromtionCriteriaSalesManAttrCustomModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaSalesManAttrCustom>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttrCustom.SalesManCustomId), model.SalesManCustomId))
                                        .FirstOrDefault<BOPromtionCriteriaSalesManAttrCustom>();


                        if (exist == null)
                        {
                            exist = new BOPromtionCriteriaSalesManAttrCustom();

                            exist.SalesManAttributeId = model.SalesManAttributeId;
                            exist.IsActive = true;
                            exist.ValueFrom = model.ValueFrom;
                           


                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.SalesManCustomId > 0)
                            {
                                model.SalesManCustomId = exist.SalesManCustomId.Value;
                            }


                        }
                        else
                        {



                            exist.SalesManAttributeId = model.SalesManAttributeId;
                            exist.IsActive = true;
                            exist.ValueFrom = model.ValueFrom;
                            
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


        [HttpPost("delete")]
        public async Task<IActionResult> delete(PromtionCriteriaSalesManAttrCustomModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromtionCriteriaSalesManAttrCustomModel> responseModel = new ResponseModel<PromtionCriteriaSalesManAttrCustomModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaSalesManAttrCustom>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttrCustom.SalesManCustomId), model.SalesManCustomId))
                                        .FirstOrDefault<BOPromtionCriteriaSalesManAttrCustom>();


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

        [HttpGet("getByAttribute")]
        public async Task<IActionResult> getByAttribute(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromtionCriteriaSalesManAttrCustomModel>> responseModel = new ResponseModel<List<PromtionCriteriaSalesManAttrCustomModel>>();

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
                        var res = new Criteria<BOPromtionCriteriaSalesManAttrCustom>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttrCustom.SalesManAttributeId), Id))
                                        .List<BOPromtionCriteriaSalesManAttrCustom>();
                        if (res != null)
                        {
                            // update current

                            responseModel.Data = res.Select(a => new PromtionCriteriaSalesManAttrCustomModel()
                            {
                                SalesManAttributeId = a.SalesManAttributeId,
                                SalesManCustomId = a.SalesManCustomId.Value,
                                ValueFrom = a.ValueFrom,
                                IsActive = a.IsActive,


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
