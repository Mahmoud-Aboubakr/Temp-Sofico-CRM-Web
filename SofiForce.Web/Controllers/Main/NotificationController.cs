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
    public class NotificationController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;

        private INotificationManager _INotificationManager;
        public NotificationController(IHttpContextAccessor contextAccessor, 
                         AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                        IHubContext<AppHub> hub,
                        IWebHostEnvironment _webHostEnvironment,
                        INotificationManager notificationManager
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
            _hub = hub;
            _INotificationManager= notificationManager;
            webHostEnvironment = _webHostEnvironment;
        }



        [HttpPost("filter")]
        public async Task<IActionResult> filter(NotificationSearchModel searchModel)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<NotificationListModel>> responseModel = new ResponseModel<List<NotificationListModel>>();

                try
                {
                    var ctr = new Criteria<BONotificationVw>();

                    if(searchModel.NotificationTypeId>0)
                        ctr.Add(Expression.Gt(nameof(BONotificationVw.NotificationTypeId), searchModel.NotificationTypeId));

                    if (searchModel.PriorityId > 0)
                        ctr.Add(Expression.Eq(nameof(BONotificationVw.PriorityId), searchModel.PriorityId));

                    if (searchModel.UserGroupId > 0)
                        ctr.Add(Expression.Eq(nameof(BONotificationVw.UserGroupId), searchModel.UserGroupId));


                    if (searchModel.NotificationDate != null && searchModel.NotificationDate.Value.Year > 2000)
                        ctr.Add(Expression.Eq(nameof(BONotificationVw.NotificationDate), searchModel.NotificationDate, dateformatter));


                    // sort by 
                    if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                    {
                        switch (searchModel.SortBy.Property)
                        {
                            case "userGroupName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("userGroupName{0}", Language)) : OrderBy.Desc(string.Format("userGroupName{0}", Language)));
                                break;
                            case "notificationTypeName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("notificationTypeName{0}", Language)) : OrderBy.Desc(string.Format("notificationTypeName{0}", Language)));
                                break;
                            case "priorityName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("priorityName{0}", Language)) : OrderBy.Desc(string.Format("priorityName{0}", Language)));
                                break;
                            default:
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                                break;
                        }
                    }
                    else
                    {
                        ctr.Add(OrderBy.Desc(nameof(BONotificationVw.NotificationId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(searchModel.Skip)
                                 .Take(searchModel.Take>0?searchModel.Take:30)
                                 .List<BONotificationVw>().Select(a => new NotificationListModel()
                                 {
                                    
                                     NotificationId = a.NotificationId.Value,
                                     NotificationDate = a.NotificationDate,
                                     NotificationDateTime = a.NotificationDateTime,
                                     NotificationTypeId = a.NotificationTypeId,
                                     PriorityId = a.PriorityId,
                                     ScheduleTime = a.ScheduleTime,
                                     NotReaded=a.NotReaded,
                                     Readed=a.Readed,   
                                     UserCount=a.UserCount,
                                     UserGroupId=a.UserGroupId,
                                     PriorityColor=a.PriorityColor,
                                     Performance=a.UserCount>0 ? Math.Round(((decimal)a.Readed/ (decimal)a.UserCount *100),2) :0,
                                     NotificationTypeName = Language == "ar" ? a.NotificationTypeNameAr : a.NotificationTypeNameEn,
                                     PriorityName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                                     UserGroupName = Language == "ar" ? a.UserGroupNameAr : a.UserGroupNameEn,


                                 }).ToList();
                    responseModel.Data = res;
                    responseModel.Total = Total;

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

        [HttpPost("my")]
        public async Task<IActionResult> my(NotificationSearchModel searchModel)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<UserNotificationListModel>> responseModel = new ResponseModel<List<UserNotificationListModel>>();

                try
                {
                    var ctr = new Criteria<BOAppUserNotificationVw>();

                    ctr.Add(Expression.Eq(nameof(BOAppUserNotificationVw.UserId), UserId));

                    if (searchModel.NotificationTypeId > 0)
                        ctr.Add(Expression.Gt(nameof(BOAppUserNotificationVw.NotificationTypeId), searchModel.NotificationTypeId));

                    if (searchModel.PriorityId > 0)
                        ctr.Add(Expression.Eq(nameof(BOAppUserNotificationVw.PriorityId), searchModel.PriorityId));

                    if (searchModel.UserGroupId > 0)
                        ctr.Add(Expression.Eq(nameof(BOAppUserNotificationVw.UserGroupId), searchModel.UserGroupId));

                    if (searchModel.IsReaded > 0)
                        ctr.Add(Expression.Eq(nameof(BOAppUserNotificationVw.IsReaded), searchModel.IsReaded==1?true:0));

                    if (searchModel.NotificationDate != null && searchModel.NotificationDate.Value.Year > 2000)
                        ctr.Add(Expression.Eq(nameof(BOAppUserNotificationVw.NotificationDate), searchModel.NotificationDate, dateformatter));


                    // sort by 
                    if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                    {
                        switch (searchModel.SortBy.Property)
                        {
                            case "userGroupName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("userGroupName{0}", Language)) : OrderBy.Desc(string.Format("userGroupName{0}", Language)));
                                break;
                            case "notificationTypeName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("notificationTypeName{0}", Language)) : OrderBy.Desc(string.Format("notificationTypeName{0}", Language)));
                                break;
                            case "priorityName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("priorityName{0}", Language)) : OrderBy.Desc(string.Format("priorityName{0}", Language)));
                                break;
                            default:
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                                break;
                        }
                    }
                    else
                    {
                        ctr.Add(OrderBy.Desc(nameof(BONotificationVw.NotificationId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(searchModel.Skip)
                                 .Take(searchModel.Take > 0 ? searchModel.Take : 30)
                                 .List<BOAppUserNotificationVw>().Select(a => new UserNotificationListModel()
                                 {

                                     NotificationId = a.NotificationId.Value,
                                     NotificationDate = a.NotificationDate,
                                     Message = a.Message,    
                                     IsReaded = a.IsReaded,
                                     ReadDate=a.ReadDate,
                                     PriorityColor = a.PriorityColor,
                                     NotificationTypeName = Language == "ar" ? a.NotificationTypeNameAr : a.NotificationTypeNameEn,
                                     PriorityName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                                     UserGroupName = Language == "ar" ? a.UserGroupNameAr : a.UserGroupNameEn,


                                 }).ToList();
                    responseModel.Data = res;
                    responseModel.Total = Total;

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

        [HttpPost("save")]
        public async Task<IActionResult> save(NotificationModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<NotificationModel> responseModel = new ResponseModel<NotificationModel>();

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
                        var exist = new Criteria<BONotification>()
                                        .Add(Expression.Eq(nameof(model.NotificationId), model.NotificationId))
                                        .FirstOrDefault<BONotification>();


                        if (exist == null)
                        {
                            exist = new BONotification();

                            exist.NotificationDate = model.NotificationDate;
                            exist.ScheduleTime = model.ScheduleTime;
                            exist.NotificationDateTime = model.NotificationDateTime;
                            exist.PriorityId = model.PriorityId;
                            exist.Message = model.Message;
                            exist.NotificationTypeId = model.NotificationTypeId;

                            
                            exist.UserGroupId=model.UserGroupId;
                            exist.UserId=model.UserId;

                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.NotificationId > 0)
                            {
                                model.NotificationId = exist.NotificationId.Value;
                            }



                            // Notifiy db users 

                            if (model.NotificationId > 0)
                            {

                                await _INotificationManager.InsertNotification_Users(UserId, model.NotificationId, model.UserGroupId, model.UserId);


                                // notify Selected Users

                                var dto = new NotificationDtoModel()
                                {
                                    Message = model.Message,
                                    NotificationDateTime = exist.NotificationDateTime,
                                    NotificationId = model.NotificationId,
                                };



                                var users = new Criteria<BOAppUserNotificationVw>();
                                    users.Add(Expression.Eq(nameof(BOAppUserNotificationVw.NotificationId), model.NotificationId));

                                var Connections = users.List<BOAppUserNotificationVw>().Where(a => !string.IsNullOrEmpty(a.SignalrId)).Select(a => a.SignalrId).ToList();

                                await _hub.Clients.Clients(Connections).SendAsync("notify", dto);

                            }


                        }
                        else
                        {

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
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result.Result);
        }

        [HttpPost("markAsRead")]
        public async Task<IActionResult> markAsRead(NotificationModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<NotificationModel> responseModel = new ResponseModel<NotificationModel>();

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
                        var exist = new Criteria<BOAppUserNotification>()
                                        .Add(Expression.Eq(nameof(BOAppUserNotification.NotificationId), model.NotificationId))
                                         .Add(Expression.Eq(nameof(BOAppUserNotification.UserId), UserId))
                                        .FirstOrDefault<BOAppUserNotification>();


                        if (exist != null)
                        {

                            if (exist.IsReaded == false)
                            {
                                exist.IsReaded = true;
                                exist.ReadDate = DateTime.Now;
                                exist.Update();
                            }

                        }

                        responseModel.Data = model;
                        responseModel.Total = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
