﻿using AutoMapper;
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
    //[ApiController]
    [AllowAnonymous]
    public class UsersController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        private INotificationManager _INotificationManager;
        public UsersController(IHttpContextAccessor contextAccessor,
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


        [HttpPost("auth")]
        public ActionResult auth([FromBody] AuthenticationModel login)
        {
            ResponseModel<UserModel> responseModel = new ResponseModel<UserModel>();

            if (login == null)
            {
                responseModel.Succeeded = false;
                responseModel.Message = "Invalid Username Or Password";
                return Ok(responseModel);   
            }

            try
            {
                if (login.UserName.EndsWith("@soficopharm.net") == false)
                    login.UserName = login.UserName + "@soficopharm.net";

                var exist = new Criteria<BOAppUser>()

                    .Add(Expression.Eq(nameof(BOAppUser.UserName), login.UserName))
                    .Add(Expression.Eq(nameof(BOAppUser.Password), Encryption.Encrypt(login.Password)))
                    .Add(Expression.Eq(nameof(BOAppUser.IsLocked), false))
                    .FirstOrDefault<BOAppUser>();

                if (exist == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Username Or Password";
                    return Ok(responseModel);
                }

                exist.LastLogin = DateTime.Now;
                exist.IsOnline=true;
                exist.Update();




                var role = new BOAppRole(exist.AppRoleId.Value);

                //string Branchs = "";
                var userBranchs = new Criteria<BOAppUserBranch>()
                      .Add(Expression.Eq(nameof(BOAppUserBranch.UserId), exist.UserId))
                      .List<BOAppUserBranch>();

                var userStores = new Criteria<BOAppUserStore>()
                     .Add(Expression.Eq(nameof(BOAppUserStore.UserId), exist.UserId))
                     .List<BOAppUserStore>();


                var userRep = new Criteria<BORepresentative>()
                     .Add(Expression.Eq(nameof(BORepresentative.UserId), exist.UserId))
                     .FirstOrDefault<BORepresentative>();

                Branchs = string.Join(',', userBranchs.Select(a => a.BranchId).ToList());
                Stores = string.Join(',', userStores.Select(a => a.StoreId).ToList());
                RepresentativeId= userRep!=null ? userRep.RepresentativeId.Value : 0;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AppSettings.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", exist.UserId.ToString()),
                        new Claim("AppRoleId", exist.AppRoleId.Value.ToString()),
                        new Claim("FullDataAccess", role.FullAccess!=null ? role.FullAccess.ToString() : "false"),
                        new Claim("Branchs", Branchs),
                        new Claim("Stores", Stores),
                        new Claim("RepresentativeId", RepresentativeId.ToString()),
                        new Claim("IsLocked", exist.IsLocked!=null?exist.IsLocked.ToString():"false")
                    }),
                    Expires = login.Client.ToLower() == "mobile" ? DateTime.UtcNow.AddYears(5) : DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                };


                var token = tokenHandler.CreateToken(tokenDescriptor);
                string newToken = tokenHandler.WriteToken(token);

                var response = new UserModel()
                {

                    UserId = exist.UserId.Value,
                    AppRoleId = exist.AppRoleId.Value,
                    Token = newToken,
                    DefualtUrl = exist.DefaultRoute,
                    Username = exist.UserName.Split('@')[0],
                    RealName = exist.RealName != null ? exist.RealName : "",
                    Phone = exist.Phone != null ? exist.Phone : "",
                    Bio = exist.UserBio != null ? exist.UserBio : "",
                    IsLocked = exist.IsLocked == true ? true : false,
                    Linkedin = exist.LinkedIn != null ? exist.LinkedIn : "",
                    WhatsApp = exist.WhatsApp != null ? exist.WhatsApp : "",
                    Zoom = exist.ZoomId != null ? exist.ZoomId : "",
                    Avatar = !String.IsNullOrEmpty(exist.Avatar) ? Configuration["filesUrl"] + exist.Avatar : "",
                    JobTitle = exist.JobTitle != null ? exist.JobTitle : "",
                    Internal = exist.Internal != null ? exist.Internal : "",
                    Email = exist.Email != null ? exist.Email : "",
                    Fax = exist.Fax != null ? exist.Fax : "",
                    Address = exist.Address != null ? exist.Address : "",
                    Mobile = exist.Mobile != null ? exist.Mobile : "",
                    MustChangeData = exist.MustChangeData != null ? exist.MustChangeData.Value :false,
                    MustChangePassword = exist.MustChangePassword != null ?exist.MustChangePassword.Value:false, 

                };


                //BranchId
                if (userBranchs.Count > 0)
                {
                    response.BranchId = userBranchs[0].BranchId.Value;
                }

                //BranchId
                if (userStores.Count >0)
                {
                    response.StoreId = userStores[0].StoreId.Value;
                }


                response.RepresentativeId = RepresentativeId;

                // select user Permissions
                response.UserFeatures= new Criteria<BOAppUserFeatureVs>()
                    .Add(Expression.Eq(nameof(BOAppUserFeatureVs.UserId),exist.UserId))
                    .Add(Expression.Eq(nameof(BOAppUserFeatureVs.IsActive), true))
                    .List< BOAppUserFeatureVs>()
                    .Select(a=> new UserFeature()
                    {
                        FeatureCode=a.FeatueCode,
                        FeatureName=Language=="ar" ?a.FeatueNameAr:a.FeatueNameEn,
                        IsNew=a.IsNew,
                        IsUpdated=a.IsUpdated,
                    }).ToList();
               


                responseModel.Data = response;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;;
                responseModel.Succeeded = false;
            }

        
            return Ok(responseModel);
        }


        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword([FromBody] ResetPasswordModel login)
        {
            ResponseModel<UserModel> responseModel = new ResponseModel<UserModel>();

            if (login == null)
            {
                responseModel.Succeeded = false;
                responseModel.Message = "Invalid Username Or Password";
                return Ok(responseModel);
            }

            if (login.Userid == 0 || login.Password=="")
            {
                responseModel.Succeeded = false;
                responseModel.Message = Messages.Invalid_Model;
                return Ok(responseModel);
            }

            try
            {
                if (login.UserName.EndsWith("@soficopharm.net") == false)
                    login.UserName = login.UserName + "@soficopharm.net";

                var exist = new Criteria<BOAppUser>()
                    .Add(Expression.Eq(nameof(BOAppUser.UserId), login.Userid))
                    .FirstOrDefault<BOAppUser>();

                if (exist == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Username Or Password";
                    return Ok(responseModel);
                }

                exist.Password = Encryption.Encrypt(login.Password);
                exist.MustChangePassword = false;
                exist.Update();
                var response = new UserModel()
                {

                    UserId = exist.UserId.Value,
               
                };

                responseModel.Data = response;
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
                responseModel.Succeeded = false;
            }


            return Ok(responseModel);
        }
        
        [CheckAuthorizedAttribute]
        [HttpPost("lockUser")]
        [Authorize]
        public async Task<IActionResult> lockUser(LockUserDto model)
        {


            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BooleanModel> responseModel = new ResponseModel<BooleanModel>();

                try
                {

                    var exist = new Criteria<BOAppUser>()

                   .Add(Expression.Eq(nameof(BOAppUser.UserId),model.UserId))
                   .FirstOrDefault<BOAppUser>();

                    if (exist == null)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = "Invalid Username Or Password";
                        responseModel.Data = new BooleanModel() { Status = false };

                        return responseModel;
                    }
                    else
                    {
                        exist.IsLocked = true;
                        exist.EBy = UserId;
                        exist.EDate = DateTime.Now;
                        exist.Update();

                        if (!string.IsNullOrEmpty(exist.SignalrId))
                        {
                           _hub.Clients.Client(exist.SignalrId).SendAsync("lock", new BooleanModel() { Status = true });
                        }
                    }
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message;;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpPost("lockAll")]
        [Authorize]
        public async Task<IActionResult> lockAll(LockUserDto model)
        {


            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BooleanModel> responseModel = new ResponseModel<BooleanModel>();

                try
                {

                    _hub.Clients.All.SendAsync("lock", new BooleanModel() { Status = true });

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

        [CheckAuthorizedAttribute]
        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> update(UserModel model)
        {


            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<UserModel> responseModel = new ResponseModel<UserModel>();

                try
                {

                    var exist = new Criteria<BOAppUser>()

                   .Add(Expression.Eq(nameof(BOAppUser.UserId), model.UserId))
                   .FirstOrDefault<BOAppUser>();

                    if (exist == null)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = "Invalid Username Or Password";
                        responseModel.Data = model;

                        return responseModel;
                    }
                    else
                    {

                        exist.Phone = model.Phone!=null?model.Phone:"";
                        exist.WhatsApp = model.WhatsApp!=null?model.WhatsApp:"";
                        exist.Email = model.Email!=null?model.Email:"";
                        exist.Internal = model.Internal!=null?model.Internal:"";
                        exist.JobTitle = model.JobTitle!=null?model.JobTitle:"";
                        exist.Address = model.Address!=null?model.Address:"";
                        exist.UserBio = model.Bio!=null?model.Bio:"";
                        exist.ZoomId = model.Zoom!=null?model.Zoom:"";
                        exist.LinkedIn = model.Linkedin!=null?model.Linkedin:"";
                        exist.Fax = model.Fax!=null?model.Fax:"";
                        exist.RealName = model.RealName!=null?model.RealName:"";
                        exist.Avatar = model.Avatar.Replace(Configuration["filesUrl"], "");


                        exist.EBy = UserId;
                        exist.EDate = DateTime.Now;
                        exist.Update();

                        responseModel.Data = model;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message;;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
        [CheckAuthorizedAttribute]
        [HttpPost("updateDefault")]
        [Authorize]
        public async Task<IActionResult> updateDefault(UserModel model)
        {


            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<UserModel> responseModel = new ResponseModel<UserModel>();

                try
                {

                    var exist = new Criteria<BOAppUser>()

                   .Add(Expression.Eq(nameof(BOAppUser.UserId), UserId))
                   .FirstOrDefault<BOAppUser>();

                    if (exist == null)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = "Invalid Username Or Password";
                        responseModel.Data = model;

                        return responseModel;
                    }
                    else
                    {

                        exist.DefaultRoute = model.DefualtUrl != null ? model.DefualtUrl : "";
                       


                        exist.EBy = UserId;
                        exist.EDate = DateTime.Now;
                        exist.Update();

                        responseModel.Data = model;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message;;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpGet("getById")]
        [Authorize]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserModel> responseModel = new ResponseModel<AppUserModel>();

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
                        var exist = new Criteria<BOAppUser>()
                                        .Add(Expression.Eq(nameof(BOAppUser.UserId), Id))
                                        .FirstOrDefault<BOAppUser>();
                        if (exist != null)
                        {


                            responseModel.Data = mapper.Map<AppUserModel>(exist);

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

        [CheckAuthorizedAttribute]
        [HttpPost("save")]
        [Authorize]
        public async Task<IActionResult> save(AppUserModel model)
        {


            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserModel> responseModel = new ResponseModel<AppUserModel>();

                try
                {

                    var exist = new Criteria<BOAppUser>()

                   .Add(Expression.Eq(nameof(BOAppUser.UserId), model.UserId))
                   .FirstOrDefault<BOAppUser>();

                    if (exist == null)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = "Invalid Username Or Password";
                        responseModel.Data = model;

                        return responseModel;
                    }
                    else
                    {
                       
                        exist.Phone = model.Phone != null ? model.Phone : "";
                        exist.WhatsApp = model.WhatsApp != null ? model.WhatsApp : "";
                        exist.Email = model.Email != null ? model.Email : "";
                        exist.Internal = model.Internal != null ? model.Internal : "";
                        exist.JobTitle = model.JobTitle != null ? model.JobTitle : "";
                        exist.Address = model.Address != null ? model.Address : "";
                        exist.UserBio = model.UserBio != null ? model.UserBio : "";
                        exist.ZoomId = model.Zoom != null ? model.Zoom : "";
                        exist.LinkedIn = model.LinkedIn != null ? model.LinkedIn : "";
                        exist.Fax = model.Fax != null ? model.Fax : "";
                        exist.RealName = model.RealName != null ? model.RealName : "";

                        exist.MustChangeData = model.MustChangeData;
                        exist.MustChangePassword = model.MustChangePassword;
                        if (exist.MustChangePassword == true)
                        {
                            exist.Password = Encryption.Encrypt("00000");
                        }

                        exist.IsLocked = model.IsLocked;

                        exist.EBy = UserId;
                        exist.EDate = DateTime.Now;
                        exist.Update();

                        responseModel.Data = model;
                    }
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

    }
}
