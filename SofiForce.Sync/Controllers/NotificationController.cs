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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;

        public NotificationController(IHttpContextAccessor contextAccessor, 
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

    }
}
