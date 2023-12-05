using AutoMapper;
using Helpers;
using Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Controllers;
using SofiForce.Web.Dapper.Interface;
using SofiForce.Web.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Server.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppUserClientGroupController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        private INotificationManager _INotificationManager;
        public AppUserClientGroupController(IHttpContextAccessor contextAccessor,
                         AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                        IHubContext<AppHub> hub,
                         IMapper mapper,
                        IWebHostEnvironment _webHostEnvironment,
                        INotificationManager notificationManager
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
            _hub = hub;
            this.mapper = mapper;
            _INotificationManager = notificationManager;
            webHostEnvironment = _webHostEnvironment;
        }


        [HttpPost("Save")]
        public async Task<IActionResult> Save(AppUserClientGroupModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserClientGroupModel> responseModel = new ResponseModel<AppUserClientGroupModel>();
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
                        var bo = new Criteria<BOAppUserClientGroup>()
                                        .Add(Expression.Eq(nameof(BOAppUserClientGroup.AppUserGroupId), model.AppUserGroupId))
                                        .FirstOrDefault<BOAppUserClientGroup>();

                        if (bo == null)
                        {
                            bo = new BOAppUserClientGroup();
                        }

                        bo.ClientGroupId = model.ClientGroupId;
                        bo.UserId = model.UserId;

                        if (bo.AppUserGroupId > 0)
                        {
                            bo.Update();
                        }
                        else
                        {
                            bo.SaveNew();
                        }
                        if (bo.AppUserGroupId > 0)
                        {
                            model.AppUserGroupId = bo.AppUserGroupId.Value;
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


        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();
                var ctr = new Criteria<BOCity>();
                var res = ctr
                            .Add(Expression.Eq(nameof(BOAppUserClientGroupVw.UserId),UserId))
                            .List<BOAppUserClientGroupVw>()
                            .Select(a => new LookupModel()
                            {

                                Id = a.ClientGroupId.Value,
                                Code = a.ClientGroupCode,
                                ParentId = 0,
                                Name = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn

                            }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(AppUserClientGroupModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserClientGroupModel> responseModel = new ResponseModel<AppUserClientGroupModel>();
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
                        var bo = new Criteria<BOAppUserClientGroup>()
                                        .Add(Expression.Eq(nameof(BOAppUserClientGroup.AppUserGroupId), model.AppUserGroupId))
                                        .FirstOrDefault<BOAppUserClientGroup>();

                        if (bo != null)
                        {
                            bo.Delete();
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

        [HttpGet("getByUser")]
        public async Task<IActionResult> getByUser(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<AppUserClientGroupListModel>> responseModel = new ResponseModel<List<AppUserClientGroupListModel>>();
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



                        var res= new Criteria<BOAppUserClientGroupVw>()
                                .Add(Expression.Eq(nameof(BOAppUserClientGroupVw.UserId),Id))
                                .List<BOAppUserClientGroupVw>()
                                .Select(a=>new AppUserClientGroupListModel()
                                {
                                    UserId=a.UserId,
                                    ClientGroupCode=a.ClientGroupCode,
                                    ClientGroupId=a.ClientGroupId,
                                   
                                    AppUserGroupId=a.AppUserGroupId.Value,
                                    ClientGroupName=Language=="ar"?a.ClientGroupNameAr:a.ClientGroupNameAr,
                                    


                                }).ToList();


                        responseModel.Data = res;
                        responseModel.Total = res.Count;
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
