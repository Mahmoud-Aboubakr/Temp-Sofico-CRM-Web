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
    public class AppUserStoreController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        private INotificationManager _INotificationManager;
        public AppUserStoreController(IHttpContextAccessor contextAccessor,
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
        public async Task<IActionResult> Save(AppUserStoreModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserStoreModel> responseModel = new ResponseModel<AppUserStoreModel>();
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
                        var bo = new Criteria<BOAppUserStore>()
                                        .Add(Expression.Eq(nameof(BOAppUserStore.AppUserStoreId), model.AppUserStoreId))
                                        .FirstOrDefault<BOAppUserStore>();

                        if (bo == null)
                        {
                            bo = new BOAppUserStore();
                        }

                        bo.StoreId = model.StoreId;
                        bo.UserId = model.UserId;

                        if (bo.AppUserStoreId > 0)
                        {
                            bo.Update();
                        }
                        else
                        {

                            var store = new BOStore(model.StoreId.Value);



                            var existBranch = new Criteria<BOAppUserBranch>()
                                      .Add(Expression.Eq(nameof(BOAppUserBranch.BranchId), store.BranchId))
                                      .Add(Expression.Eq(nameof(BOAppUserBranch.UserId), model.UserId))
                                      .FirstOrDefault<BOAppUserBranch>();

                            if (existBranch != null)
                            {
                                bo.SaveNew();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 503;
                            }

                        }
                        
                        if (bo.AppUserStoreId > 0)
                        {
                            model.AppUserStoreId = bo.AppUserStoreId.Value;
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


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(AppUserStoreModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserStoreModel> responseModel = new ResponseModel<AppUserStoreModel>();
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
                        var bo = new Criteria<BOAppUserStore>()
                                        .Add(Expression.Eq(nameof(BOAppUserStore.AppUserStoreId), model.AppUserStoreId))
                                        .FirstOrDefault<BOAppUserStore>();

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
                ResponseModel<List<AppUserStoreListModel>> responseModel = new ResponseModel<List<AppUserStoreListModel>>();
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



                        var res= new Criteria<BOAppUserStoreVw>()
                                .Add(Expression.Eq(nameof(BOAppUserStoreVw.UserId),Id))
                                .List<BOAppUserStoreVw>()
                                .Select(a=>new AppUserStoreListModel()
                                {
                                    UserId=a.UserId,
                                    StoreCode=a.StoreCode,
                                    StoreId=a.StoreId,
                                   
                                    AppUserStoreId=a.AppUserStoreId.Value,
                                    StoreName=Language=="ar"?a.StoreNameAr:a.StoreNameEn,
                                    


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
