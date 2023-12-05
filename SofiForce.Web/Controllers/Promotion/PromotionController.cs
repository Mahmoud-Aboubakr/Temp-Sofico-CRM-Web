using AutoMapper;
using ClosedXML.Excel;
using ExcelDataReader;
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
using SofiForce.Web.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class PromotionController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;

        private INotificationManager _INotificationManager;
        private readonly IMapper _mapper;
        private readonly IPromotionService promotionService;
        private readonly IPromotionManager promotionManager;

        public PromotionController(IHttpContextAccessor contextAccessor, 
                        AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                       IHubContext<AppHub> hub,
                        IWebHostEnvironment _webHostEnvironment,
                        INotificationManager notificationManager,
                        IMapper mapper,
                        IPromotionService promotionService,
                        IPromotionManager PromotionManager
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
            _hub = hub;
            _INotificationManager= notificationManager;
            _mapper = mapper;
            this.promotionService = promotionService;
            promotionManager = PromotionManager;
            webHostEnvironment = _webHostEnvironment;
        }

        [CheckAuthorizedAttribute]
        [HttpPost("save")]
        public async Task<IActionResult> save(PromotionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromotionModel> responseModel = new ResponseModel<PromotionModel>();

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
                        var exist = new Criteria<BOPromotion>()
                                        .Add(Expression.Eq(nameof(BOPromotion.PromotionId), model.PromotionId))
                                        .FirstOrDefault<BOPromotion>();


                        if (exist == null)
                        {
                            exist = new BOPromotion();

                            exist.PromotionCode = model.PromotionCode.ToUpper();
                            exist.CompanyId = model.CompanyId;
                            exist.PromotionCategoryId = model.PromotionCategoryId > 0 ? model.PromotionCategoryId.Value : null;
                            exist.ValidFrom=model.ValidFrom!=null?model.ValidFrom.Value:DateTime.Now;
                            exist.ValidTo=model.ValidTo!=null?model.ValidTo.Value:DateTime.Now;
                            if (exist.ValidTo < exist.ValidFrom)
                                exist.ValidTo = exist.ValidFrom;


                            exist.IsActive = false;
                            exist.IsApproved = false;
                            exist.VendorCode = model.VendorCode;

                            exist.PromotionTypeId= model.PromotionTypeId > 0 ? model.PromotionTypeId.Value : null;
                            exist.Priority=model.Priority !=null ? model.Priority.Value:0;
                            exist.Repeats = model.Repeats!=null ? model.Repeats.Value:0;
                            exist.Icon=model.Icon;
                            exist.Color = model.Color;
                            exist.PromotionGroupId = model.PromotionGroupId>0 ?model.PromotionGroupId.Value:null;
                            exist.DisplayOrder=model.DisplayOrder!=null?model.DisplayOrder:0;
                            exist.EnableNotification = model.EnableNotification!=null?model.EnableNotification.Value:false;
                            exist.NotificationDate=DateTime.Now.AddMinutes(5);
                            exist.NotificationDone = true;
                            exist.RepeatTypeId= model.RepeatTypeId > 0 ? model.RepeatTypeId.Value : null;

                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.PromotionId > 0)
                            {
                                model.PromotionId = exist.PromotionId.Value;
                            }


                        }
                        else
                        {

                            if (exist.IsApproved != true)
                            {
                                exist.PromotionCode = model.PromotionCode.ToUpper();
                                exist.ValidFrom = model.ValidFrom != null ? model.ValidFrom.Value : DateTime.Now;
                                exist.ValidTo = model.ValidTo != null ? model.ValidTo.Value : DateTime.Now;
                                
                                if (exist.ValidTo < exist.ValidFrom)
                                    exist.ValidTo = exist.ValidFrom;


                                exist.IsActive = false;
                                exist.IsApproved = false;


                                exist.Priority = model.Priority != null ? model.Priority.Value : 0;
                                exist.Repeats = model.Repeats != null ? model.Repeats.Value : 0;
                                exist.Icon = model.Icon;
                                exist.Color = model.Color;
                                exist.PromotionGroupId = model.PromotionGroupId > 0 ? model.PromotionGroupId.Value : null;
                                exist.DisplayOrder = model.DisplayOrder != null ? model.DisplayOrder : 0;
                                exist.RepeatTypeId = model.RepeatTypeId > 0 ? model.RepeatTypeId.Value : null;


                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;
                                exist.Update();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 503;
                            }
                            

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
        [HttpPost("activate")]
        public async Task<IActionResult> activate(PromotionModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionModel> responseModel = new ResponseModel<PromotionModel>();

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
                        var exist = new Criteria<BOPromotion>()
                                        .Add(Expression.Eq(nameof(BOPromotion.PromotionId), model.PromotionId))
                                        .FirstOrDefault<BOPromotion>();


                        if (exist != null)
                        {

                            if (exist.IsActive == false)
                            {
                                exist.IsActive = true;
                                exist.IsApproved = true;


                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;
                                exist.Update();

                                // Rebuild Promotion
                                if (exist.PromotionCategoryId < 3)
                                {
                                    promotionService.RebuildPromotionItem(exist.PromotionId.Value);

                                }

                               
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 503;
                            }


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
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result.Result);
        }
        [CheckAuthorizedAttribute]
        [HttpPost("deActivate")]
        public async Task<IActionResult> deActivate(PromotionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromotionModel> responseModel = new ResponseModel<PromotionModel>();

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
                        var exist = new Criteria<BOPromotion>()
                                        .Add(Expression.Eq(nameof(BOPromotion.PromotionId), model.PromotionId))
                                        .FirstOrDefault<BOPromotion>();


                        if (exist != null)
                        {

                            if (exist.IsActive == true)
                            {
                                exist.IsActive = false;
                                exist.IsApproved = true;

                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;
                                exist.Update();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 503;
                            }


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
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("extend")]
        public async Task<IActionResult> extend(PromotionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromotionModel> responseModel = new ResponseModel<PromotionModel>();

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
                        var exist = new Criteria<BOPromotion>()
                                        .Add(Expression.Eq(nameof(BOPromotion.PromotionId), model.PromotionId))
                                        .FirstOrDefault<BOPromotion>();


                        if (exist != null)
                        {

                            exist.ValidFrom = model.ValidFrom.Value.Date < DateTime.Now.Date ? DateTime.Now : model.ValidFrom.Value.Date;
                            exist.ValidTo = model.ValidTo.Value.Date<DateTime.Now.Date?DateTime.Now: model.ValidTo.Value.Date;
                            exist.EBy = UserId;
                            exist.EDate = DateTime.Now;
                            exist.IsActive = true;
                            exist.IsApproved = true;

                            exist.Update();


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
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("copy")]
        public async Task<IActionResult> copy(PromotionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromotionModel> responseModel = new ResponseModel<PromotionModel>();

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
                        var exist = new Criteria<BOPromotion>()
                                        .Add(Expression.Eq(nameof(BOPromotion.PromotionId), model.PromotionId))
                                        .FirstOrDefault<BOPromotion>();


                        if (exist != null)
                        {
                            var newPromo = new BOPromotion();
                            newPromo = exist;
                            newPromo.PromotionCode = exist.PromotionCode + "_COPY";
                            newPromo.IsActive = false;
                            newPromo.IsApproved = false;

                            newPromo.ValidFrom = exist.ValidFrom.Value.Date < DateTime.Now.Date ? DateTime.Now : exist.ValidFrom.Value.Date;
                            newPromo.ValidTo = exist.ValidTo.Value.Date < DateTime.Now.Date ? DateTime.Now : exist.ValidTo.Value.Date;

                            newPromo.SaveNew();

                            if(newPromo.PromotionId>0)
                            {

                                var type = new BOPromotionType(exist.PromotionTypeId.Value);

                                if(type.PromotionInputId==3 || type.PromotionInputId==4)
                                {
                                    // MIX AND MATCH

                                    //add item Criteria
                                    var GroupCriteria = new Criteria<BOPromotionMixGroup>().Add(Expression.Eq(nameof(BOPromotionMixGroup.PromotionId), model.PromotionId)).List<BOPromotionMixGroup>();
                                    if (GroupCriteria != null)
                                    {
                                        foreach (var item in GroupCriteria)
                                        {
                                            int OldGroupId = item.GroupId.Value;

                                            item.PromotionId = newPromo.PromotionId;
                                            item.SaveNew();


                                            var ItemCriteria = new Criteria<BOPromotionCriteria>()
                                                    .Add(Expression.Eq(nameof(BOPromotionCriteria.PromotionId), model.PromotionId))
                                                    .Add(Expression.Eq(nameof(BOPromotionCriteria.GroupId), OldGroupId))
                                                    .List<BOPromotionCriteria>();

                                            if (ItemCriteria != null)
                                            {
                                                foreach (var row in ItemCriteria)
                                                {
                                                    row.GroupId= item.GroupId.Value;
                                                    row.PromotionId = newPromo.PromotionId;
                                                    row.SaveNew();
                                                }
                                            }

                                        }
                                    }


                                }
                                else
                                {
                                    //add item Criteria
                                    var ItemCriteria = new Criteria<BOPromotionCriteria>().Add(Expression.Eq(nameof(BOPromotionCriteria.PromotionId), model.PromotionId)).List<BOPromotionCriteria>();
                                    if (ItemCriteria != null)
                                    {
                                        foreach (var item in ItemCriteria)
                                        {
                                            item.PromotionId = newPromo.PromotionId;
                                            item.SaveNew();
                                        }
                                    }
                                }




                                //Add Client Criteria
                                var ClientCriteria = new Criteria<BOPromtionCriteriaClient>().Add(Expression.Eq(nameof(BOPromtionCriteriaClient.PromotionId), model.PromotionId)).List<BOPromtionCriteriaClient>();
                                if (ClientCriteria != null)
                                {
                                    foreach (var item in ClientCriteria)
                                    {
                                        item.PromotionId = newPromo.PromotionId;
                                        item.SaveNew();
                                    }
                                }

                                //Add Sales Man Criteria
                                var SalesManCriteria = new Criteria<BOPromtionCriteriaSalesMan>().Add(Expression.Eq(nameof(BOPromtionCriteriaSalesMan.PromotionId), model.PromotionId)).List<BOPromtionCriteriaSalesMan>();
                                if (SalesManCriteria != null)
                                {
                                    foreach (var item in SalesManCriteria)
                                    {
                                        item.PromotionId = newPromo.PromotionId;
                                        item.SaveNew();
                                    }
                                }
                                //Add Outcome
                                var Outcomes = new Criteria<BOPromotionOutcome>().Add(Expression.Eq(nameof(BOPromotionOutcome.PromotionId), model.PromotionId)).List<BOPromotionOutcome>();
                                if (SalesManCriteria != null)
                                {
                                    foreach (var item in Outcomes)
                                    {
                                        item.PromotionId = newPromo.PromotionId;
                                        item.SaveNew();
                                    }
                                }

                                
                            }

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
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(PromotionSearchModel searchModel)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromotionModel>> responseModel = new ResponseModel<List<PromotionModel>>();

                try
                {
                    var ctr = new Criteria<BOPromotionVw>();

                    // get by term
                    if (!string.IsNullOrEmpty(searchModel.Term))
                        ctr.Add(Expression.Like(nameof(BOPromotionVw.PromotionCode), searchModel.Term));

                    if (!string.IsNullOrEmpty(searchModel.VendorCode))
                        ctr.Add(Expression.Eq(nameof(BOPromotionVw.VendorCode), searchModel.VendorCode));

                    if (searchModel.PromotionTypeId>0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionVw.PromotionTypeId), searchModel.PromotionTypeId));

                    if (searchModel.PromotionGroupId > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionVw.PromotionGroupId), searchModel.PromotionGroupId));

                    if (searchModel.RepeatTypeId > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionVw.RepeatTypeId), searchModel.RepeatTypeId));

                    if (searchModel.PromotionCategoryId > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionVw.PromotionCategoryId), searchModel.PromotionCategoryId));


                    if (searchModel.IsActive > 0)
                        ctr.Add(Expression.Eq(nameof(BOPromotionVw.IsActive), searchModel.IsActive == 1 ? true : false));



                    if (searchModel.ValidFrom !=null && searchModel.ValidFrom.Value.Year>1900)
                        ctr.Add(Expression.Gte(nameof(BOPromotionVw.ValidFrom), searchModel.ValidFrom.Value.Date,dateformatter));

                    if (searchModel.ValidTo != null && searchModel.ValidTo.Value.Year > 1900)
                        ctr.Add(Expression.Lte(nameof(BOPromotionVw.ValidTo), searchModel.ValidTo.Value.Date, dateformatter));

                    // sort by 
                    if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                    {
                        switch (searchModel.SortBy.Property)
                        {
                            case "promotionGroupName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("promotionGroupName{0}", Language)) : OrderBy.Desc(string.Format("promotionGroupName{0}", Language)));
                                break;
                            case "promotionTypeName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("promotionTypeName{0}", Language)) : OrderBy.Desc(string.Format("promotionTypeName{0}", Language)));
                                break;
                            case "repeatTypeName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("repeatTypeName{0}", Language)) : OrderBy.Desc(string.Format("repeatTypeName{0}", Language)));
                                break;

                            default:
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                                break;
                        }
                    }
                    else
                    {
                        ctr.Add(OrderBy.Desc(nameof(BOPromotionVw.PromotionId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(searchModel.Skip)
                                 .Take(searchModel.Take)
                                 .List<BOPromotionVw>().Select(a => new PromotionModel()
                                 {
                                     PromotionId = a.PromotionId.Value,
                                     PromotionCode = a.PromotionCode,
                                     VendorCode = a.VendorCode,
                                     Color = a.Color,
                                     DisplayOrder = a.DisplayOrder,
                                     EnableNotification = a.EnableNotification,
                                     IsActive = a.IsActive,
                                     PromotionCategoryId = a.PromotionCategoryId,
                                     NotificationDate = a.NotificationDate,
                                     NotificationDone = a.NotificationDone,
                                     PromotionGroupId = a.PromotionGroupId,
                                     PromotionTypeId = a.PromotionTypeId,
                                     Repeats = a.Repeats,
                                     Priority=a.Priority,
                                     ValidFrom = a.ValidFrom,
                                     ValidTo = a.ValidTo,
                                     Icon=a.Icon,
                                     IsApproved=a.IsApproved,

                                     PromotionGroupName = Language == "ar" ? a.PromotionGroupNameAr : a.PromotionGroupNameEn,
                                     RepeatTypeName = Language=="ar"?a.RepeatTypeNameAr:a.RepeatTypeNameEn,
                                     PromotionTypeName=Language=="ar"?a.PromotionTypeNameAr:a.PromotionTypeNameEn,
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

        [CheckAuthorizedAttribute]
        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromotionModel> responseModel = new ResponseModel<PromotionModel>();

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
                        var exist = new Criteria<BOPromotion>()
                                        .Add(Expression.Eq(nameof(BOPromotion.PromotionId), Id))
                                        .FirstOrDefault<BOPromotion>();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<PromotionModel>(exist);


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
        [HttpPost("exists")]
        public async Task<IActionResult> Exists(PromotionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromotionModel> responseModel = new ResponseModel<PromotionModel>();

                if (model == null ||string.IsNullOrEmpty(model.PromotionCode))
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
                        var exist = new Criteria<BOPromotion>()
                                        .Add(Expression.Eq(nameof(BOPromotion.PromotionCode), model.PromotionCode))
                                        .FirstOrDefault<BOPromotion>();

                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<PromotionModel>(exist);


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
        [HttpPost("delete")]
        public async Task<IActionResult> delete(PromotionModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionModel> responseModel = new ResponseModel<PromotionModel>();

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
                        var exist = new Criteria<BOPromotion>()
                                        .Add(Expression.Eq(nameof(BOPromotion.PromotionId), model.PromotionId))
                                        .FirstOrDefault<BOPromotion>();

                        if (exist != null)
                        {
                            if (exist.IsApproved != true)
                            {
                                exist.Delete();

                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 503;
                            }
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
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result.Result);
        }



        [CheckAuthorizedAttribute]
        [HttpPost("OrderPromotion")]
        public async Task<IActionResult> OrderPromotion(SalesOrderPromotionAllSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SalesOrderPromotionAllListModel>> responseModel = new ResponseModel<List<SalesOrderPromotionAllListModel>>();


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


                        var ctr = new Criteria<BOSalesOrderPromotionAllVw>();

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {

                            if (!string.IsNullOrEmpty(model.TermBy))
                            {
                                switch (model.TermBy)
                                {
                                   
                                    case "promotionCode":
                                        ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.PromotionCode), model.Term));
                                        break;
                                    case "invoiceCode":
                                        ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.InvoiceCode), model.Term));
                                        break;
                                    case "clientCode":
                                        ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.ClientCode), model.Term));
                                        break;
                                    default:
                                        break;
                                }
                            }

                        }

                        // branch Permissions


                        // get by model

                        if (model.SalesId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSalesOrderPromotionAllVw.SalesId), model.SalesId));

                        if (model.PromotionId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSalesOrderPromotionAllVw.PromotionId), model.PromotionId));

                        if (model.ClientId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSalesOrderPromotionAllVw.ClientId), model.SalesId));

                        if (!string.IsNullOrEmpty(model.PromotionCode))
                            ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.PromotionCode), model.PromotionCode));

                        if (!string.IsNullOrEmpty(model.ClientCode))
                            ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.ClientCode), model.ClientCode));


                        if (!string.IsNullOrEmpty(model.InvoiceCode))
                            ctr.Add(Expression.Eq(nameof(BOSalesOrderPromotionAllVw.InvoiceCode), model.InvoiceCode));


                        if (model.InvoiceDateFrom!=null && model.InvoiceDateFrom.Value.Year>1900 )
                            ctr.Add(Expression.Gte(nameof(BOSalesOrderPromotionAllVw.InvoiceDate), model.InvoiceCode,dateformatter));

                        if (model.InvoiceDateTo != null && model.InvoiceDateTo.Value.Year > 1900)
                            ctr.Add(Expression.Lte(nameof(BOSalesOrderPromotionAllVw.InvoiceDate), model.InvoiceCode, dateformatter));

                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "itemName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
                                    break;

                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOSalesOrderPromotionAllVw.SalesId)));
                        }



                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOSalesOrderPromotionAllVw>()
                                     .Select(a => new SalesOrderPromotionAllListModel()
                                     {

                                         IsActive = a.IsActive,
                                         Priority = a.Priority,
                                         PromotionCode = a.PromotionCode,
                                         PromotionId = a.PromotionId,
                                         Repeats = a.Repeats,
                                         ValidFrom = a.ValidFrom,
                                         ValidTo = a.ValidTo,
                                         SalesId = a.SalesId,
                                         InvoiceDate = a.InvoiceDate,
                                         CashDiscountTotal = a.CashDiscountTotal,
                                         ClientCode = a.ClientCode,
                                         ClientId = a.ClientId,
                                         CustomDiscountTotal = a.CustomDiscountTotal,
                                         CustomDiscountTypeId = a.CustomDiscountTypeId,
                                         CustomDiscountValue = a.CustomDiscountValue,
                                         DeliveryTotal = a.DeliveryTotal,
                                         ItemDiscountTotal = a.ItemDiscountTotal,
                                         NetTotal = a.NetTotal,
                                         InvoiceCode = a.InvoiceCode,
                                         SalesCode = a.SalesCode,
                                         TaxTotal = a.TaxTotal,
                                         ItemTotal = a.ItemTotal,

                                         ClientName= Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                         ClientGroupName = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn,
                                         PromotionTypeName = Language == "ar" ? a.PromotionTypeNameAr : a.PromotionTypeNameEn,
                                         

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
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpPost("OrderPromotionDownload")]
        public async Task<IActionResult> OrderPromotionDownload(SalesOrderPromotionAllSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BOSalesOrderPromotionAllVw>();

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {

                    if (!string.IsNullOrEmpty(model.TermBy))
                    {
                        switch (model.TermBy)
                        {

                            case "promotionCode":
                                ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.PromotionCode), model.Term));
                                break;
                            case "invoiceCode":
                                ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.InvoiceCode), model.Term));
                                break;
                            case "clientCode":
                                ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.ClientCode), model.Term));
                                break;
                            default:
                                break;
                        }
                    }

                }

                // branch Permissions


                // get by model

                if (model.SalesId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSalesOrderPromotionAllVw.SalesId), model.SalesId));

                if (model.PromotionId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSalesOrderPromotionAllVw.PromotionId), model.PromotionId));

                if (model.ClientId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSalesOrderPromotionAllVw.ClientId), model.SalesId));

                if (!string.IsNullOrEmpty(model.PromotionCode))
                    ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.PromotionCode), model.PromotionCode));

                if (!string.IsNullOrEmpty(model.ClientCode))
                    ctr.Add(Expression.StartWith(nameof(BOSalesOrderPromotionAllVw.ClientCode), model.ClientCode));


                if (!string.IsNullOrEmpty(model.InvoiceCode))
                    ctr.Add(Expression.Eq(nameof(BOSalesOrderPromotionAllVw.InvoiceCode), model.InvoiceCode));


                if (model.InvoiceDateFrom != null && model.InvoiceDateFrom.Value.Year > 1900)
                    ctr.Add(Expression.Gte(nameof(BOSalesOrderPromotionAllVw.InvoiceDate), model.InvoiceCode, dateformatter));

                if (model.InvoiceDateTo != null && model.InvoiceDateTo.Value.Year > 1900)
                    ctr.Add(Expression.Lte(nameof(BOSalesOrderPromotionAllVw.InvoiceDate), model.InvoiceCode, dateformatter));

                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {
                    switch (model.SortBy.Property)
                    {
                        case "itemName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
                            break;

                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }
                }
                else
                {
                    ctr.Add(OrderBy.Desc(nameof(BOSalesOrderPromotionAllVw.SalesId)));
                }



                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOSalesOrderPromotionAllVw>()
                             .Select(a => new SalesOrderPromotionAllListModel()
                             {

                                 IsActive = a.IsActive,
                                 Priority = a.Priority,
                                 PromotionCode = a.PromotionCode,
                                 PromotionId = a.PromotionId,
                                 Repeats = a.Repeats,
                                 ValidFrom = a.ValidFrom,
                                 ValidTo = a.ValidTo,
                                 SalesId = a.SalesId,
                                 InvoiceDate = a.InvoiceDate,
                                 CashDiscountTotal = a.CashDiscountTotal,
                                 ClientCode = a.ClientCode,
                                 ClientId = a.ClientId,
                                 CustomDiscountTotal = a.CustomDiscountTotal,
                                 CustomDiscountTypeId = a.CustomDiscountTypeId,
                                 CustomDiscountValue = a.CustomDiscountValue,
                                 DeliveryTotal = a.DeliveryTotal,
                                 ItemDiscountTotal = a.ItemDiscountTotal,
                                 NetTotal = a.NetTotal,
                                 InvoiceCode = a.InvoiceCode,
                                 SalesCode = a.SalesCode,
                                 TaxTotal = a.TaxTotal,
                                 ItemTotal = a.ItemTotal,

                                 ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                 ClientGroupName = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn,
                                 PromotionTypeName = Language == "ar" ? a.PromotionTypeNameAr : a.PromotionTypeNameEn,


                             }).ToList();



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "Client Code";
                        worksheet.Cell("B1").Value = "Client Name";
                        worksheet.Cell("C1").Value = "Client Group Name";
                        worksheet.Cell("D1").Value = "Invoice Code";
                        worksheet.Cell("E1").Value = "Invoice Date";
                        worksheet.Cell("F1").Value = "Item Total";
                        worksheet.Cell("G1").Value = "Item Discount Total";
                        worksheet.Cell("H1").Value = "Tax Total";
                        worksheet.Cell("I1").Value = "Net Total";
                        worksheet.Cell("J1").Value = "Cash Disount";

                        worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("A1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("B1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("C1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("C1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("D1").Style.Font.FontColor = XLColor.White;


                        worksheet.Cell("E1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("E1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("F1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("F1").Style.Font.FontColor = XLColor.White;


                        worksheet.Cell("G1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("G1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("H1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("H1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("I1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("I1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("J1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("J1").Style.Font.FontColor = XLColor.White;

                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].ClientGroupName;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].InvoiceCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].InvoiceDate;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].ItemTotal;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].ItemDiscountTotal;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].TaxTotal;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].NetTotal;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].CashDiscountTotal;


                        }

                        workbook.SaveAs(stream);
                        stream.Seek(0, SeekOrigin.Begin);

                        return this.File(
                            fileContents: stream.ToArray(),
                            contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",

                            // By setting a file download name the framework will
                            // automatically add the attachment Content-Disposition header
                            fileDownloadName: "export.xlsx"
                        );
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [CheckAuthorizedAttribute]
        [HttpPost("upload")]
        public async Task<IActionResult> upload(supplementaryUploadDtoModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<supplementaryUploadDtoModel> responseModel = new ResponseModel<supplementaryUploadDtoModel>();

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

                        var _root = Configuration["files"];
                        var filePath = Path.Combine("wwwroot", _root, model.FilePath);

                        using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    UseColumnDataType = true,
                                    FilterSheet = (tableReader, sheetIndex) => true,
                                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                    {
                                        EmptyColumnNamePrefix = "Column",
                                        UseHeaderRow = true,
                                    }
                                });

                                // check file
                                if(result == null || result.Tables.Count != 1)
                                {
                                    
                                    model.Errors.Add("Invalid File Schema");
                                    responseModel.Data = model;

                                    responseModel.Succeeded = false;
                                    responseModel.Message = Messages.Invalid_Model;
                                    responseModel.StatusCode = 503;

                                    return responseModel;
                                }

                                if (result.Tables[0].Columns.Count!=8)
                                {

                                    model.Errors.Add("Invalid Column Schema");
                                    responseModel.Data = model;

                                    responseModel.Succeeded = false;
                                    responseModel.Message = Messages.Invalid_Model;
                                    responseModel.StatusCode = 503;

                                    return responseModel;
                                }

                                if (result.Tables[0].Columns.Count == 8)
                                {
                                    if (result.Tables[0].Columns[0].ColumnName != "FromDate")
                                        model.Errors.Add("Invalid Column 1 Schema");
                                    if (result.Tables[0].Columns[1].ColumnName != "ToDate")
                                        model.Errors.Add("Invalid Column 2 Schema");
                                    if (result.Tables[0].Columns[2].ColumnName != "InputCode")
                                        model.Errors.Add("Invalid Column 3 Schema");
                                    if (result.Tables[0].Columns[3].ColumnName != "Slice")
                                        model.Errors.Add("Invalid Column 4 Schema");
                                    if (result.Tables[0].Columns[4].ColumnName != "Quantity")
                                        model.Errors.Add("Invalid Column 5 Schema");
                                    if (result.Tables[0].Columns[5].ColumnName != "Bouns")
                                        model.Errors.Add("Invalid Column 6 Schema");
                                    if (result.Tables[0].Columns[6].ColumnName != "OutputCode")
                                        model.Errors.Add("Invalid Column 7 Schema");
                                    if (result.Tables[0].Columns[7].ColumnName != "Activate")
                                        model.Errors.Add("Invalid Column 8 Schema");

                                    if (model.Errors.Count > 0)
                                    {
                                        responseModel.Data = model;
                                        responseModel.Succeeded = false;
                                        responseModel.Message = Messages.Invalid_Model;
                                        responseModel.StatusCode = 503;

                                        return responseModel;
                                    }

                                }

                                if (result.Tables[0].Rows.Count == 0)
                                {

                                    model.Errors.Add("Empty file ,");
                                    responseModel.Data = model;

                                    responseModel.Succeeded = false;
                                    responseModel.Message = Messages.Invalid_Model;
                                    responseModel.StatusCode = 503;

                                    return responseModel;
                                }


                                foreach (DataRow row in result.Tables[0].Rows)
                                {

                                    string InputCode= row["InputCode"].ToString();
                                    string OutputCode = row["OutputCode"].ToString();

                                    DateTime FromDate=DateTime.Now;
                                    DateTime ToDate = DateTime.Now;
                                    int Slice=0;
                                    int Quantity=0;
                                    int Bouns=0;
                                    bool Activate=false;




                                    if (row["FromDate"] != null )
                                        DateTime.TryParse(row["FromDate"].ToString(), out FromDate);
                                    if (row["ToDate"] != null)
                                        DateTime.TryParse(row["ToDate"].ToString(), out ToDate);
                                    if (row["Slice"] != null)
                                        int.TryParse(row["Slice"].ToString(), out Slice);
                                    if (row["Quantity"] != null)
                                        int.TryParse(row["Quantity"].ToString(), out Quantity);
                                    if (row["Bouns"] != null)
                                        int.TryParse(row["Bouns"].ToString(), out Bouns);

                                    if (row["Activate"] != null && row["Activate"].ToString() == "1")
                                        Activate = true;



                                    if (string.IsNullOrEmpty(InputCode) || string.IsNullOrEmpty(InputCode) || FromDate.Year<1900 || ToDate.Year<1900 || Slice==0 || Quantity==0 || Bouns==0) 
                                        model.Errors.Add(string.Format("Invalid data in row {0} Schema", result.Tables[0].Rows.IndexOf(row)+2));

                                   
                                }

                                if(model.Errors.Count > 0)
                                {
                                    responseModel.Data = model;

                                    responseModel.Succeeded = false;
                                    responseModel.Message = Messages.Invalid_Model;
                                    responseModel.StatusCode = 503;
                                }

                                // batch processing


                                this.promotionManager.Upload(result.Tables[0], UserId);
                            }
                        }





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
        [HttpGet("template1")]
        public async Task<IActionResult> template1()
        {

            try
            {

                using (MemoryStream stream = new MemoryStream())
                {

                    using (var workbook = new XLWorkbook())
                    {






                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "FromDate";
                        worksheet.Cell("B1").Value = "ToDate";
                        worksheet.Cell("C1").Value = "InputCode";
                        worksheet.Cell("D1").Value = "Slice";
                        worksheet.Cell("E1").Value = "Quantity";
                        worksheet.Cell("F1").Value = "Bouns";
                        worksheet.Cell("G1").Value = "OutputCode";
                        worksheet.Cell("H1").Value = "Activate";





                        worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("A1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("B1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("C1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("C1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("D1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("E1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("E1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("F1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("F1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("G1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("G1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("H1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("H1").Style.Font.FontColor = XLColor.White;







                        workbook.SaveAs(stream);
                        stream.Seek(0, SeekOrigin.Begin);

                        return this.File(
                            fileContents: stream.ToArray(),
                            contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",

                            // By setting a file download name the framework will
                            // automatically add the attachment Content-Disposition header
                            fileDownloadName: "export.xlsx"
                        );
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
