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
    public class AppUserBranchController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        private INotificationManager _INotificationManager;
        public AppUserBranchController(IHttpContextAccessor contextAccessor,
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
        [CheckAuthorizedAttribute]
        public async Task<IActionResult> Save(AppUserBranchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserBranchModel> responseModel = new ResponseModel<AppUserBranchModel>();
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
                        var bo = new Criteria<BOAppUserBranch>()
                                        .Add(Expression.Eq(nameof(BOAppUserBranch.UserBranchId), model.UserBranchId))
                                        .FirstOrDefault<BOAppUserBranch>();

                        if (bo == null)
                        {
                            bo = new BOAppUserBranch();
                        }

                        bo.BranchId = model.BranchId;
                        bo.UserId = model.UserId;

                        if (bo.UserBranchId > 0)
                        {
                            bo.Update();
                        }
                        else
                        {
                            bo.SaveNew();
                        }
                        
                        if (bo.UserBranchId > 0)
                        {
                            model.UserBranchId = bo.UserBranchId.Value;
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


        [CheckAuthorizedAttribute]
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(AppUserBranchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserBranchModel> responseModel = new ResponseModel<AppUserBranchModel>();
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
                        var bo = new Criteria<BOAppUserBranch>()
                                        .Add(Expression.Eq(nameof(BOAppUserBranch.UserBranchId), model.UserBranchId))
                                        .FirstOrDefault<BOAppUserBranch>();

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

        [CheckAuthorizedAttribute]
        [HttpGet("getByUser")]
        public async Task<IActionResult> getByUser(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<AppUserBranchListModel>> responseModel = new ResponseModel<List<AppUserBranchListModel>>();
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



                        var res= new Criteria<BOAppUserBranchVw>()
                                .Add(Expression.Eq(nameof(BOAppUserBranchVw.UserId),Id))
                                .List<BOAppUserBranchVw>()
                                .Select(a=>new AppUserBranchListModel()
                                {
                                    UserId=a.UserId,
                                    BranchCode=a.BranchCode,
                                    BranchId=a.BranchId,
                                    UserBranchId=a.UserBranchId.Value,
                                    BranchName=Language=="ar"?a.BranchNameAr:a.BranchNameEn,


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
