using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SofiForce.Web.Dapper.Implementation;
using DocumentFormat.OpenXml.EMMA;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class TrackingController : BaseController
    {
        private ITrackingManager _ITrackingManager;

        public TrackingController(IHttpContextAccessor contextAccessor, ITrackingManager TrackingManager ) : base(contextAccessor)
        {
            _ITrackingManager = TrackingManager;

        }

        [HttpPost("trackMe")]
        public async Task<IActionResult> trackMe(TrackMeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<TrackMeModel> responseModel = new ResponseModel<TrackMeModel>();
                try
                {
                    BOAppUserLocation bo = new BOAppUserLocation();
                    bo.UserId = UserId;
                    bo.TrackingDate = DateTime.Now;
                    bo.TrackingTime = DateTime.Now;
                    bo.Latitude = model.Latitude;
                    bo.Longitude = model.Longitude;

                    if (model.ClientId > 0)
                    {
                        bo.TrackingTypeId = 2;
                        bo.IsPositive = model.IsPositive != null ? model.IsPositive : false;
                        bo.ClientId = model.ClientId;
                    }
                    else
                    {
                        bo.TrackingTypeId = 1;
                    }


                    if(model.ClientId > 0)
                    {
                        // get distance
                        var client = new BOClient(model.ClientId.Value);
                        if (client.Latitude > 0)
                        {
                            var dist = Utils.GetDistanceInMeters(new GeoPoint() { lat = client.Latitude.Value, lng = client.Longitude.Value }, new GeoPoint() { lat = model.Latitude.Value, lng = model.Longitude.Value });
                            bo.Distance = dist;
                            if (dist <= 100)
                            {
                                bo.InZone = true;
                            }
                            else
                            {
                                bo.InZone = false;
                            }
                        }
                        else
                        {
                            bo.InZone = true;
                            bo.Distance = 0;
                        }
                    }

                    bo.SaveNew();


                    var user = new BOAppUser(UserId);
                    user.Latitude = model.Latitude;
                    user.Longitude = model.Longitude;
                    user.EDate = DateTime.Now;
                    user.EBy = UserId;
                    user.Update();

                }
                catch (Exception ex)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message; ;
                }


                return responseModel;
            });

            await task;
            return Ok(task.Result);
        }

        [HttpPost("representative")]
        public async Task<IActionResult> representative(TrackingSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<List<TrakingRepresentativeModel>> responseModel = new ResponseModel<List<TrakingRepresentativeModel>>();
                try
                {

                    var ctr = new Criteria<BORepresentativeTrackingVw>();

                    if (model.BranchId > 0)
                        ctr.Add(Expression.Eq(nameof(BORepresentativeTrackingVw.BranchId), model.BranchId));
                    if (model.RepresentativeId > 0)
                        ctr.Add(Expression.Eq(nameof(BORepresentativeTrackingVw.RepresentativeId), model.RepresentativeId));
                    if (model.SupervisorId > 0)
                        ctr.Add(Expression.Eq(nameof(BORepresentativeTrackingVw.SupervisorId), model.SupervisorId));
                    if (model.RepresentativeKindId > 0)
                        ctr.Add(Expression.Eq(nameof(BORepresentativeTrackingVw.KindId), model.RepresentativeKindId));

                    if(model.StatusId > 0)
                        ctr.Add(Expression.Eq(nameof(BORepresentativeTrackingVw.IsOnline), model.StatusId==1?true:false));

                    var res = ctr.List<BORepresentativeTrackingVw>().Select(a => new TrakingRepresentativeModel()
                    {
                        KindId = a.KindId,
                        SupervisorId = a.SupervisorId,
                        RepresentativeId = a.RepresentativeId,
                        BranchCode = a.BranchCode,
                        BranchId = a.BranchId,
                        BusinessUnitId = a.BusinessUnitId,
                        CompanyCode = a.CompanyCode,
                        LastTraking = a.LastSyncDate,
                        Latitude = a.Latitude,
                        Longitude = a.Longitude,
                        Phone = a.Phone,
                        RepresentativeCode = a.RepresentativeCode,
                        UserId=a.UserId,
                        IsOnline= a.LastSyncDate!=null && a.LastSyncDate >=DateTime.Now.AddMinutes(-30)  ?true:false,
                        RepresentativeName=Language=="ar"?a.RepresentativeNameAr:a.RepresentativeNameEn,
                        BranchName=Language=="ar"?a.BranchNameAr:a.BranchNameEn,

                    }).ToList();

                    responseModel.Data = res;
                    responseModel.Total = res.Count;

                }
                catch (Exception ex)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message; ;
                }


                return responseModel;
            });

            await task;
            return Ok(task.Result);
        }


        [HttpGet("summery")]
        public async Task<IActionResult> summery(int Id,int mode)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<KBISummeryModel> responseModel = new ResponseModel<KBISummeryModel>();
                try
                {

                    var res = Utils.getTimeRange(mode);
                    var FromDate = res.FromDate;
                    var ToDate = res.ToDate;

                    responseModel.Data = _ITrackingManager.getKBISummeryRepresentative(Id, FromDate, ToDate, Language);

                    

                }
                catch (Exception ex)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message; ;
                }


                return responseModel;
            });

            await task;
            return Ok(task.Result);
        }

        [HttpPost("details")]
        public async Task<IActionResult> Details(TrackingDetailSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<List<TrakingRepresentativeDetailModel>> responseModel = new ResponseModel<List<TrakingRepresentativeDetailModel>>();
                try
                {
                    if(model==null || model.RepresentativeId==null || model.RepresentativeId==0 || model.TrackingDate == null)
                    {

                        responseModel.Succeeded=false;
                        responseModel.Message = Messages.Invalid_Model;

                        return responseModel;
                    }

                    var rep = new BORepresentative(model.RepresentativeId.Value);
                    if(rep!=null && rep.UserId > 0)
                    {

                        var ctr = new Criteria<BOAppUserLocationVw>()
                                    .Add(Expression.Eq(nameof(BOAppUserLocationVw.UserId), rep.UserId))
                                    .Add(Expression.Eq(nameof(BOAppUserLocationVw.TrackingDate), model.TrackingDate != null ? model.TrackingDate : DateTime.Now, dateformatter))
                                    .Add(OrderBy.Asc(nameof(BOAppUserLocationVw.TrackingTime)));

                       var Total = ctr.Count();
                        
                        
                       var res= ctr.List<BOAppUserLocationVw>()
                        .Select(a=> new TrakingRepresentativeDetailModel()
                        {
                            IsPositive = a.ClientId > 0 || a.SalesId > 0 ? a.IsPositive!=null?a.IsPositive.Value:false : null,
                            Latitude = a.Latitude,
                            Longitude = a.Longitude,
                            TrackingId = a.TrackingId.Value,
                            ClientCode = a.ClientCode,
                            SalesId = a.SalesId,
                            ClientId = a.ClientId,
                            TrackTypeId = a.ClientId > 0 || a.SalesId > 0 ? 1 :2,
                            TrackTypeName = a.ClientId > 0 || a.SalesId > 0 ? "Visit" : "Walking",
                            TrackTime=a.TrackingTime,
                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                            InZone=a.InZone,
                            Distance=a.Distance>0?a.Distance.Value:0

                        }).ToList();


                        responseModel.Data = res;
                        responseModel.Total = Total;

                    }
                    else
                    {

                        responseModel.Succeeded = false;
                        responseModel.Message = Messages.Invalid_Model;

                        return responseModel;
                    }

                }
                catch (Exception ex)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;;
                }


                return responseModel;
            });

            await task;
            return Ok(task.Result);
        }
    }
    
}
