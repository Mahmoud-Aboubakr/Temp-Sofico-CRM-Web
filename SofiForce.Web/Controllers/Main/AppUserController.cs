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
    public class AppUserController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        private INotificationManager _INotificationManager;
        public AppUserController(IHttpContextAccessor contextAccessor,
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



        [HttpPost("filter")]
        public async Task<IActionResult> filter(AppUserSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<AppUserListModel>> responseModel = new ResponseModel<List<AppUserListModel>>();

                try
                {
                    var ctr = new Criteria<BOAppUserVw>();

                    // get by term
                    if (!string.IsNullOrEmpty(model.Term))
                    {

                        if (!string.IsNullOrEmpty(model.TermBy))
                        {
                            switch (model.TermBy)
                            {
                                
                                case "realName":
                                    ctr.Add(Expression.StartWith(nameof(BOAppUserVw.RealName), model.Term));
                                    break;
                                case "userName":
                                    ctr.Add(Expression.StartWith(nameof(BOAppUserVw.UserName), model.Term));
                                    break;
                               
                                default:
                                    break;
                            }
                        }

                    }

                   
                    if (model.AppRoleId > 0)
                        ctr.Add(Expression.Eq(nameof(BOAppUserVw.AppRoleId), model.AppRoleId));

                    if (model.UserGroupId > 0)
                        ctr.Add(Expression.Eq(nameof(BOAppUserVw.UserGroupId), model.UserGroupId));

                    if (model.IsOnline > 0)
                        ctr.Add(Expression.Eq(nameof(BOAppUserVw.IsOnline), model.IsOnline==1 ? true : false));

                    if (model.IsLocked > 0)
                        ctr.Add(Expression.Eq(nameof(BOAppUserVw.IsLocked), model.IsLocked == 1 ? true : false));

                    if (model.LastLogin !=null && model.LastLogin.Value.Year > 1900)
                    {
                        ctr.Add(Expression.Gt(nameof(BOAppUserVw.LastLogin), model.LastLogin.Value.Date.AddDays(1),dateformatter));
                        ctr.Add(Expression.Lte(nameof(BOAppUserVw.LastLogin), model.LastLogin.Value, dateformatter));

                    }

                    // sort by 
                    if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                    {
                        switch (model.SortBy.Property)
                        {
                            default:
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                break;
                        }
                    }
                    else
                    {
                        ctr.Add(OrderBy.Desc(nameof(BOAppUserVw.UserId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(model.Skip)
                                 .Take(model.Take > 0 ? model.Take : 30)
                                 .List<BOAppUserVw>().Select(a => new AppUserListModel()
                                 {
                                     UserId=a.UserId,
                                     IsOnline=a.IsOnline,
                                     AppRoleCode=a.AppRoleCode,
                                     AppRoleId=a.AppRoleId,
                                     DefaultRoute=a.DefaultRoute,
                                     EmailVerified=a.EmailVerified,
                                     IsLocked=a.IsLocked,
                                     LastLogin=a.LastLogin,
                                     MustChangeData=a.MustChangeData,
                                     MustChangePassword=a.MustChangePassword,
                                     Phone=a.Phone,
                                     RealName=a.RealName,
                                     UserGroupCode=a.UserGroupCode,
                                     UserGroupId=a.UserGroupId,
                                     UserName=a.UserName.Split("@")[0],
                                     WhatsApp=a.WhatsApp,
                                     UserGroupName= Language == "ar" ? a.UserGroupNameAr : a.UserGroupNameEn,
                                     AppRoleName =Language=="ar"?a.AppRoleNameAr:a.AppRoleNameEn,


                                 }).ToList();



                    responseModel.Data = res;
                    responseModel.Total = Total;
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


        [HttpPost("Save")]
        public async Task<IActionResult> Save(AppUserModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserModel> responseModel = new ResponseModel<AppUserModel>();
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
                        var bo = new Criteria<BOAppUser>()
                                        .Add(Expression.Eq(nameof(BOAppUser.UserId), model.UserId))
                                        .FirstOrDefault<BOAppUser>();

                        if (bo == null)
                        {
                            bo = new BOAppUser();
                        }
                        // create access

                        bo.DefaultRoute = model.DefaultRoute;
                        bo.IsLocked = model.IsLocked!=null?model.IsLocked.Value:false;
                        bo.MustChangeData = model.MustChangeData != null ? model.MustChangeData.Value : true;
                        bo.MustChangePassword = model.MustChangePassword != null ? model.MustChangePassword.Value : true;
                        bo.AppRoleId = model.AppRoleId;
                        bo.UserGroupId = model.UserGroupId;
                        bo.EmailVerified = true;
                        bo.Email=model.Email;
                        bo.WhatsApp = model.WhatsApp;
                        bo.Phone=model.Phone;
                        bo.Mobile = model.Mobile;
                        bo.ZoomId = model.ZoomId;
                        bo.LinkedIn = model.LinkedIn;
                        bo.JobTitle = model.JobTitle;
                        bo.UserBio = model.UserBio;
                        bo.Address = model.Address;
                        bo.Internal = model.Internal;
                        bo.Fax = model.Fax;

                        if (bo.UserId > 0)
                        {
                            bo.EBy = UserId;
                            bo.EDate = DateTime.Now;
                            bo.Update();

                        }
                        else
                        {
                            bo.RealName = model.RealName;
                            bo.UserName ="SFF"+ model.UserName+ "@soficopharm.net";
                            bo.Password = Encryption.Encrypt(model.Password);
                            bo.CBy = UserId;
                            bo.CDate = DateTime.Now;
                            bo.SaveNew();
                        }

                        


                        if (bo.UserId > 0)
                        {
                            model.UserId = bo.UserId.Value;
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


        [HttpGet("getById")]
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
                        var res = new Criteria<BOAppUser>()
                                        .Add(Expression.Eq(nameof(BOAppUser.UserId), Id))
                                        .FirstOrDefault<BOAppUser>();

                        
                        var user= mapper.Map<AppUserModel>(res);

                        if(user != null && user.UserName!=null)
                        {
                            user.UserName = user.UserName.Replace("@soficopharm.net", "").Replace("SFF", "");
                        }

                        user.Branchs=new Criteria<BOAppUserBranchVw>()
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

                        user.Stores = new Criteria<BOAppUserStoreVw>()
                               .Add(Expression.Eq(nameof(BOAppUserStoreVw.UserId), Id))
                               .List<BOAppUserStoreVw>()
                               .Select(a => new AppUserStoreListModel()
                               {
                                   UserId = a.UserId,
                                   StoreCode = a.StoreCode,
                                   StoreId = a.StoreId,
                                   AppUserStoreId = a.AppUserStoreId.Value,
                                   StoreName = Language == "ar" ? a.StoreNameAr : a.StoreNameEn,


                               }).ToList();

                        user.Representatives = new Criteria<BORepresentativeVw>()
                              .Add(Expression.Eq(nameof(BORepresentativeVw.UserId), Id))
                              .List<BORepresentativeVw>()
                              .Select(a => new RepresentativeListModel()
                              {
                                  SupervisorId = a.SupervisorId,
                                  KindId = a.KindId,
                                  BranchCode = a.BranchCode,
                                  BranchId = a.BranchId,
                                  CanDelete = a.CanDelete,
                                  CanEdit = a.CanEdit,
                                  Color = a.Color,
                                  DisplayOrder = a.DisplayOrder,
                                  Icon = a.Icon,
                                  IsActive = a.IsActive,
                                  RepresentativeCode = a.RepresentativeCode,
                                  RepresentativeId = a.RepresentativeId.Value,
                                  UserId = a.UserId,
                                  JoinDate = a.JoinDate,
                                  BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                  KindName = Language == "ar" ? a.KindNameAr : a.KindNameEn,
                                  RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                  SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                  IsTerminated = a.IsTerminated,
                                  Notes = a.Notes,
                                  Phone = a.Phone,
                                  PhoneAlternative = a.PhoneAlternative,
                                  TerminationDate = a.TerminationDate,
                                  TerminationReasonId = a.TerminationReasonId,
                                  BusinessUnitCode = a.BusinessUnitCode,
                                  BusinessUnitId = a.BusinessUnitId,
                                  CompanyCode = a.CompanyCode,
                                  BusinessUnitName = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,


                              }).ToList();

                        user.Supervisors = new Criteria<BOSupervisorVw>()
                              .Add(Expression.Eq(nameof(BOSupervisorVw.UserId), Id))
                              .List<BOSupervisorVw>()
                              .Select(a => new SupervisorListModel()
                              {
                                  SupervisorId = a.SupervisorId.Value,
                                  SupervisorCode = a.SupervisorCode,
                                  BranchId = a.BranchId,
                                  BranchCode = a.BranchCode,
                                  CanDelete = a.CanDelete,
                                  Color = a.Color,
                                  DisplayOrder = a.DisplayOrder,
                                  Icon = a.Icon,
                                  CanEdit = a.CanEdit,
                                  IsActive = a.IsActive,
                                  UserId = a.UserId,
                                  BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                  SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                  Representatives = a.Representatives,
                                  JoinDate = a.JoinDate,
                                  SupervisorTypeName = Language == "ar" ? a.SupervisorTypeNameAr : a.SupervisorTypeNameEn,
                                  IsTerminated = a.IsTerminated,
                                  Notes = a.Notes,
                                  Phone = a.Phone,
                                  PhoneAlternative = a.PhoneAlternative,
                                  TerminationDate = a.TerminationDate,
                                  TerminationReasonId = a.TerminationReasonId,
                                  BusinessUnitCode = a.BusinessUnitCode,
                                  BusinessUnitId = a.BusinessUnitId,
                                  CompanyCode = a.CompanyCode,
                                  BusinessUnitName = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,




                              }).ToList();

                        user.ClientGroups = new Criteria<BOAppUserClientGroupVw>()
                             .Add(Expression.Eq(nameof(BOAppUserClientGroupVw.UserId), Id))
                             .List<BOAppUserClientGroupVw>()
                             .Select(a => new AppUserClientGroupListModel()
                             {
                                UserId = a.UserId.Value,
                                AppUserGroupId = a.AppUserGroupId.Value,
                                ClientGroupCode = a.ClientGroupCode,
                                ClientGroupId = a.ClientGroupId.Value,
                                ClientGroupName=Language=="ar"?a.ClientGroupNameAr : a.ClientGroupNameEn,



                             }).ToList();

                        responseModel.Data = user;
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
        public async Task<IActionResult> delete(AppUserModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserModel> responseModel = new ResponseModel<AppUserModel>();
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
                        var bo = new Criteria<BOAppUser>()
                                        .Add(Expression.Eq(nameof(BOAppUser.UserId), model.UserId))
                                        .FirstOrDefault<BOAppUser>();

                        if (bo != null)
                        {
                            bo.DeleteAllAppUserBranch();
                            bo.DeleteAllAppUserClientGroup();
                            bo.DeleteAllAppUserLocation();
                            bo.DeleteAllAppUserNotification();
                            bo.DeleteAllAppUserStore();
                           

                            var reps=new Criteria<BORepresentative>()
                                        .Add(Expression.Eq(nameof(BORepresentative.UserId), model.UserId))
                                        .List<BORepresentative>();

                            foreach (var item in reps)
                            {
                                item.UserId = null;
                                item.EBy = UserId;
                                item.EDate = DateTime.Now;
                                item.Update();
                            }
                            var supervisors = new Criteria<BOSupervisor>()
                                       .Add(Expression.Eq(nameof(BOSupervisor.UserId), model.UserId))
                                       .List<BOSupervisor>();

                            foreach (var item in supervisors)
                            {
                                item.UserId = null;
                                item.EBy = UserId;
                                item.EDate = DateTime.Now;
                                item.Update();
                            }

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

        [HttpPost("activate")]
        public async Task<IActionResult> activate(AppUserModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserModel> responseModel = new ResponseModel<AppUserModel>();
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
                        var bo = new Criteria<BOAppUser>()
                                        .Add(Expression.Eq(nameof(BOAppUser.UserId), model.UserId))
                                        .FirstOrDefault<BOAppUser>();

                        if (bo != null)
                        {

                            bo.IsLocked = false;
                            bo.EBy = UserId;
                            bo.EDate = DateTime.Now;
                            bo.Update();

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

        [HttpPost("deactivate")]
        public async Task<IActionResult> deactivate(AppUserModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserModel> responseModel = new ResponseModel<AppUserModel>();
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
                        var bo = new Criteria<BOAppUser>()
                                        .Add(Expression.Eq(nameof(BOAppUser.UserId), model.UserId))
                                        .FirstOrDefault<BOAppUser>();

                        if (bo != null)
                        {

                            bo.IsLocked = true;
                            bo.EBy = UserId;
                            bo.EDate = DateTime.Now;
                            bo.Update();

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

        [HttpPost("resetPassword")]
        public async Task<IActionResult> resetPassword(AppUserModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserModel> responseModel = new ResponseModel<AppUserModel>();
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
                        var bo = new Criteria<BOAppUser>()
                                        .Add(Expression.Eq(nameof(BOAppUser.UserId), model.UserId))
                                        .FirstOrDefault<BOAppUser>();

                        if (bo != null)
                        {

                            bo.Password = Encryption.Encrypt(model.Password);
                            bo.EBy = UserId;
                            bo.EDate = DateTime.Now;
                            bo.Update();

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

        [HttpPost("logout")]
        public async Task<IActionResult> logout(AppUserModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppUserModel> responseModel = new ResponseModel<AppUserModel>();
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
                        var bo = new Criteria<BOAppUser>()
                                        .Add(Expression.Eq(nameof(BOAppUser.UserId), model.UserId))
                                        .FirstOrDefault<BOAppUser>();

                        if (bo != null)
                        {

                           // to do 

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

    }
}
