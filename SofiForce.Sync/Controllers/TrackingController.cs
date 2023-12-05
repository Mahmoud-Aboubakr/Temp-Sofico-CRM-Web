using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Models.StatisticalModels;
using SofiForce.Sync.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace SofiForce.Sync.Controllers
{
    [Route("api/[controller]")]
    public class TrackingController : BaseController
    {

        public TrackingController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpPost("trackMe")]
        public async Task<IActionResult> trackMe(TrackMeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<TrackMeModel> responseModel = new ResponseModel<TrackMeModel>();
                try
                {

                    var exist = new Criteria<BOAppUserLocation>()
                            .Add(Expression.Eq(nameof(BOAppUserLocation.UserId), UserId))
                            .Add(Expression.Eq(nameof(BOAppUserLocation.TrackingTypeId), model.ClientId>0?2:1))
                            .Add(OrderBy.Desc(nameof(BOAppUserLocation.TrackingId)))
                            .FirstOrDefault<BOAppUserLocation>();

                    if (exist != null)
                    {
                        var dist = Utils.GetDistanceInMeters(new GeoPoint() { lat = exist.Latitude.Value, lng = exist.Longitude.Value }, new GeoPoint() { lat = model.Latitude.Value, lng = model.Longitude.Value });

                        if (dist < 5)
                        {

                            responseModel.Succeeded=true;
                            return responseModel;
                        }


                    }

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


                    if (model.ClientId > 0)
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

                        var representative = new Criteria<BORepresentative>().Add(Expression.Eq(nameof(BORepresentative.UserId), UserId)).FirstOrDefault<BORepresentative>();

                        var activity = new BOClientActivity();

                        activity.ClientId= model.ClientId;

                        activity.RepresentativeId= representative!=null? representative.RepresentativeId: null;
                        activity.ActivityDate=DateTime.Now;
                        activity.ActivityTime= DateTime.Now;
                        activity.Duration = 0;
                        activity.InJourney = true;
                        activity.IsPositive = false;
                        activity.InZone = bo.InZone;
                        activity.ActivityTypeId = 1;
                        activity.Latitude = model.Latitude;
                        activity.Longitude = model.Longitude;
                        activity.Distance = bo.Distance;
                        activity.SalesId= null;
                        activity.SaveNew();
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

    }
    
}
