using AutoMapper;
using ClosedXML.Excel;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class OperationRequestDetailController : BaseController
    {
        private readonly IOperationRequestManager operationRequestManager;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public OperationRequestDetailController(IHttpContextAccessor contextAccessor, IOperationRequestManager operationRequestManager, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            this.operationRequestManager = operationRequestManager;
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }



        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(OperationRequestDetailSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<OperationRequestDetailListModel>> responseModel = new ResponseModel<List<OperationRequestDetailListModel>>();

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


                        var ctr = new Criteria<BOOperationRequestDetailVw>();


                        // get by term
                        if(model.OperationId>0)
                        ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationId), model.OperationId));

                        // branch Permissions
                           
                        // get by model


                        if (model.ClientId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.ClientId), model.ClientId));


                        if (model.RepresentativeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.RepresentativeId), model.RepresentativeId));
                        if (model.OperationTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationTypeId), model.OperationTypeId));

                        if (model.ClientTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.ClientTypeId), model.ClientTypeId));

                        if (model.RegionId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.RegionId), model.RegionId));

                        if (model.GovernerateId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.GovernerateId), model.GovernerateId));

                        if (model.CityId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.CityId), model.CityId));

                        if (model.LocationLevelId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.LocationLevelId), model.LocationLevelId));


                        if (model.OperationStatusId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationStatusId), model.OperationStatusId));

                        if (model.OperationRejectReasonId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationRejectReasonId), model.OperationRejectReasonId));

                        if (model.OperationDate != null && model.OperationDate.Value.Year > 1900)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationDate), model.OperationDate, dateformatter));

                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "cityName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("cityName{0}", Language)) : OrderBy.Desc(string.Format("cityName{0}", Language)));
                                    break;
                                case "clientTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientTypeName{0}", Language)) : OrderBy.Desc(string.Format("clientTypeName{0}", Language)));
                                    break;
                                case "clientName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                                    break;
                                case "governerateName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("governerateName{0}", Language)) : OrderBy.Desc(string.Format("governerateName{0}", Language)));
                                    break;
                                case "locationLevelName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("locationLevelName{0}", Language)) : OrderBy.Desc(string.Format("locationLevelName{0}", Language)));
                                    break;
                                case "operationStatusName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("operationStatusName{0}", Language)) : OrderBy.Desc(string.Format("operationStatusName{0}", Language)));
                                    break;
                                case "responsibleName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("responsibleName{0}", Language)) : OrderBy.Desc(string.Format("responsibleName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOOperationRequestDetailVw.OperationId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0?model.Take:30)
                                     .List<BOOperationRequestDetailVw>()
                                     .Select(a => new OperationRequestDetailListModel()
                                     {

                                         OperationId = a.OperationId,
                                         OperationStatusId = a.OperationStatusId,
                                         OperationTypeId=a.OperationTypeId,
                                         LocationLevelId = a.LocationLevelId,
                                         CityId = a.CityId,
                                         OperationDate = a.OperationDate,
                                         RegionId = a.RegionId,
                                         ClientId = a.ClientId,
                                         ClientTypeId = a.ClientTypeId,
                                         GovernerateId = a.GovernerateId,
                                         DetailId = a.DetailId,
                                         Floor = a.Floor,
                                         Latitude = a.Latitude,
                                         Property = a.Property,
                                         IsChain = a.IsChain,
                                         Phone = a.Phone,
                                         Mobile = a.Mobile,
                                         Landmark = a.Landmark,
                                         Longitude = a.Longitude,
                                         WhatsApp = a.WhatsApp,
                                         Address = a.Address,
                                         Building = a.Building,
                                         ClientCode = a.ClientId>0? a.ClientCode:"",
                                         Accuracy=a.Accuracy,

                                         ResponsibleName = Language == "ar" ? a.ResponsibleNameAr : a.ResponsibleNameEn,
                                         ClientTypeName= Language == "ar" ? a.ClientTypeNameAr : a.ClientTypeNameEn,
                                         CityName = Language == "ar" ? a.CityNameAr : a.CityNameEn,
                                         ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                         GovernerateName = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,
                                         LocationLevelName = Language == "ar" ? a.LocationLevelNameAr : a.LocationLevelNameEn,
                                         OperationStatusName = Language == "ar" ? a.OperationStatusNameAr : a.OperationStatusNameEn,



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
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpGet("getPoints")]
        public async Task<IActionResult> getPoints(double Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<GeoPoint>> responseModel = new ResponseModel<List<GeoPoint>>();

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


                        var ctr = new Criteria<BOOperationRequestDetail>();
                        ctr.Add(Expression.Eq(nameof(BOOperationRequestDetail.OperationId), Id));



                        var res = ctr.List<BOOperationRequestDetail>()
                                     .Select(a => new GeoPoint()
                                     {

                                         Label=Language=="ar"?a.ClientNameAr:a.ClientNameEn,
                                         lat= a.Latitude>0?a.Latitude.Value:0,
                                         lng= a.Longitude>0?a.Longitude.Value:0,
                                         Id=a.DetailId.Value,

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

        [CheckAuthorizedAttribute]
        [HttpPost("filterAll")]
        public async Task<IActionResult> filterAll(OperationRequestDetailSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<OperationRequestDetailModel>> responseModel = new ResponseModel<List<OperationRequestDetailModel>>();

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


                        var ctr = new Criteria<BOOperationRequestDetailVw>();


                        // get by term
                        if (model.OperationId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationId), model.OperationId));

                        // branch Permissions

                        // get by model


                        if (model.ClientId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.ClientId), model.ClientId));


                        if (model.RepresentativeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.RepresentativeId), model.RepresentativeId));
                        if (model.OperationTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationTypeId), model.OperationTypeId));

                        if (model.ClientTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.ClientTypeId), model.ClientTypeId));

                        if (model.RegionId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.RegionId), model.RegionId));

                        if (model.GovernerateId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.GovernerateId), model.GovernerateId));

                        if (model.CityId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.CityId), model.CityId));

                        if (model.LocationLevelId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.LocationLevelId), model.LocationLevelId));


                        if (model.OperationStatusId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationStatusId), model.OperationStatusId));
                        else
                            ctr.Add(Expression.Null(nameof(BOOperationRequestDetailVw.OperationStatusId)));



                        if (model.OperationRejectReasonId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationRejectReasonId), model.OperationRejectReasonId));

                        if (model.OperationDate != null && model.OperationDate.Value.Year > 1900)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationDate), model.OperationDate, dateformatter));

                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "cityName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("cityName{0}", Language)) : OrderBy.Desc(string.Format("cityName{0}", Language)));
                                    break;
                                case "clientTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientTypeName{0}", Language)) : OrderBy.Desc(string.Format("clientTypeName{0}", Language)));
                                    break;
                                case "clientName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                                    break;
                                case "governerateName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("governerateName{0}", Language)) : OrderBy.Desc(string.Format("governerateName{0}", Language)));
                                    break;
                                case "locationLevelName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("locationLevelName{0}", Language)) : OrderBy.Desc(string.Format("locationLevelName{0}", Language)));
                                    break;
                                case "operationStatusName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("operationStatusName{0}", Language)) : OrderBy.Desc(string.Format("operationStatusName{0}", Language)));
                                    break;
                                case "responsibleName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("responsibleName{0}", Language)) : OrderBy.Desc(string.Format("responsibleName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOOperationRequestDetailVw.OperationId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOOperationRequestDetailVw>()
                                     .Select(a => new OperationRequestDetailModel()
                                     {

                                         OperationId = a.OperationId,
                                         OperationStatusId = a.OperationStatusId,
                                         LocationLevelId = a.LocationLevelId,
                                         OperationTypeId=a.OperationTypeId,
                                         CityId = a.CityId,
                                         OperationDate = a.OperationDate,
                                         RegionId = a.RegionId,
                                         ClientId = a.ClientId,
                                         ClientTypeId = a.ClientTypeId,
                                         GovernerateId = a.GovernerateId,
                                         DetailId = (int)a.DetailId.Value,
                                         Floor = a.Floor,
                                         Latitude = a.Latitude,
                                         Property = a.Property,
                                         IsChain = a.IsChain,
                                         Phone = a.Phone,
                                         Mobile = a.Mobile,
                                         Landmark = a.Landmark,
                                         Longitude = a.Longitude,
                                         WhatsApp = a.WhatsApp,
                                         Address = a.Address,
                                         Building = a.Building,
                                         ClientCode = a.ClientCode,
                                         Accuracy = a.Accuracy,

                                         ResponsibleNameAr = a.ResponsibleNameAr,
                                         ClientNameAr = a.ClientNameAr,
                                         ClientNameEn = a.ClientNameEn,
                                         CommercialCode = a.CommercialCode,
                                         Documents=new List<OperationRequestDetailDocumentListModel>(),
                                         IsSynced=false,
                                         Id=null,
                                         InZone=false,
                                         Landmarks=new List<OperationRequestDetailLandmarkListModel>(),
                                         OperationRejectReasonId=null,
                                         OperationRejectReasonName=String.Empty,
                                         PreferredTimes=new List<OperationRequestDetailPreferredTimeListModel>(),
                                         RegionName=String.Empty,
                                         ResponsibleNameEn=a.ResponsibleNameEn,
                                         SyncDate=null,
                                         TaxCode=a.TaxCode,
                                        

                                         ClientTypeName = a.ClientTypeNameEn,
                                         CityName = Language == "ar" ? a.CityNameAr : a.CityNameEn,
                                         GovernerateName = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,
                                         LocationLevelName = Language == "ar" ? a.LocationLevelNameAr : a.LocationLevelNameEn,
                                         OperationStatusName = Language == "ar" ? a.OperationStatusNameAr : a.OperationStatusNameEn,



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
                ResponseModel<OperationRequestDetailModel> responseModel = new ResponseModel<OperationRequestDetailModel>();

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

                        var exist = new Criteria<BOOperationRequestDetail>()
                                       .Add(Expression.Eq(nameof(BOOperationRequestDetail.DetailId), Id))
                                       .FirstOrDefault<BOOperationRequestDetail>();

                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<OperationRequestDetailModel>(exist);


                            responseModel.Data.PreferredTimes=new Criteria<BOOperationRequestDetailPreferredTimeVw>()
                                            .Add(Expression.Eq(nameof(BOOperationRequestDetailPreferredTimeVw.DetailId),Id))
                                            .List<BOOperationRequestDetailPreferredTimeVw>()
                                            .Select(a=> new OperationRequestDetailPreferredTimeListModel()
                                            {

                                                DetailId = a.DetailId,
                                                FromTime = a.FromTime.ToString(),
                                                PreferredId = a.PreferredId.Value,
                                                PreferredOperationId = a.PreferredOperationId,
                                
                                                ToTime = a.ToTime.ToString(),
                                                WeekDayId = a.WeekDayId,

                                                WeekDayName=Language=="ar"?a.WeekDayNameAr:a.WeekDayNameEn,
                                                PreferredOperationName=Language=="ar"?a.PreferredOperationNameAr:a.PreferredOperationNameEn,

                                            }).ToList();

                            responseModel.Data.Landmarks = new Criteria<BOOperationRequestDetailLandmarkVw>()
                                           .Add(Expression.Eq(nameof(BOOperationRequestDetailLandmarkVw.DetailId), Id))
                                           .List<BOOperationRequestDetailLandmarkVw>()
                                           .Select(a => new OperationRequestDetailLandmarkListModel()
                                           {
                                              DetaillandId=a.DetaillandId.Value,
                                              DetailId=a.DetailId.Value,
                                              LandmarkId = a.LandmarkId.Value,
                                              LandmarkName=Language=="ar"?a.LandmarkNameAr:a.LandmarkNameEn,   

                                           }).ToList();

                            responseModel.Data.Documents = new Criteria<BOOperationRequestDetailDocumentVw>()
                                       .Add(Expression.Eq(nameof(BOOperationRequestDetailDocumentVw.DetailId), Id))
                                       .List<BOOperationRequestDetailDocumentVw>()
                                       .Select(a => new OperationRequestDetailDocumentListModel()
                                       {
                                           DetailId = a.DetailId.Value,
                                           DetailDocumentId = a.DetailDocumentId.Value,
                                           DocumentExt=a.DocumentExt,
                                           DocumentPath= _configuration["filesUrl"] + a.DocumentPath,
                                           DocumentSize=a.DocumentSize,
                                           DocumentTypeId=a.DocumentTypeId,
                                           UploadDate=a.UploadDate,
                                           DocumentTypeName=Language=="ar"?a.DocumentTypeNameAr:a.DocumentTypeNameEn,

                                       }).ToList();

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
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpPost("save")]
        public async Task<IActionResult> save(OperationRequestDetailModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<OperationRequestDetailModel> responseModel = new ResponseModel<OperationRequestDetailModel>();

                if (model == null )
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else if (! model.IsValid())
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
                        var exist = new Criteria<BOOperationRequestDetail>()
                                        .Add(Expression.Eq(nameof(model.DetailId), model.DetailId))
                                        .FirstOrDefault<BOOperationRequestDetail>();


                        if (exist == null)
                        {



                            // create new
                            exist = new BOOperationRequestDetail();
                            exist.OperationId = model.OperationId;
                            exist.OperationDate = model.OperationDate;
                            exist.ClientId = model.ClientId>0 ? model.ClientId:null;
                            exist.ClientTypeId = model.ClientTypeId;
                            exist.ClientNameAr = model.ClientNameAr;
                            exist.ClientNameEn = model.ClientNameEn;
                            exist.RegionId = 1;
                            exist.GovernerateId = model.GovernerateId;
                            exist.CityId = model.CityId;
                            exist.LocationLevelId = model.LocationLevelId;
                            exist.IsChain = model.IsChain;
                            exist.ResponsibleNameEn = model.ResponsibleNameEn;
                            exist.ResponsibleNameAr = model.ResponsibleNameAr;
                            exist.Building = model.Building;
                            exist.Floor = model.Floor;
                            exist.Property = model.Property;
                            exist.Address = model.Address;
                            exist.Landmark = model.Landmark;
                            exist.Phone = model.Phone;
                            exist.Mobile = model.Mobile;
                            exist.WhatsApp = model.WhatsApp;
                            exist.Latitude = model.Latitude;
                            exist.Longitude = model.Longitude;
                            exist.Accuracy = model.Accuracy;
                            exist.InZone = model.InZone;
                            exist.OperationStatusId = 1;
                            exist.TaxCode = model.TaxCode;
                            exist.CommercialCode = model.CommercialCode;

                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;


                            exist.SaveNew();

                            if (exist.DetailId > 0)
                            {
                                model.DetailId=(int)exist.DetailId.Value;
                                model.IsSynced = true;
                                model.SyncDate = DateTime.Now;

                                // add landmark
                                if (model.Landmarks != null)
                                {
                                    foreach (var item in model.Landmarks)
                                    {
                                        var bo = new BOOperationRequestDetailLandmark();

                                        bo.DetailId = model.DetailId;
                                        bo.LandmarkId = item.LandmarkId;
                                        bo.SaveNew();

                                    }
                                }



                                // add docments
                                if (model.Documents != null)
                                {
                                    foreach (var item in model.Documents)
                                    {
                                        var bo = new BOOperationRequestDetailDocument();

                                        bo.DetailId = model.DetailId;
                                        bo.DocumentTypeId = item.DocumentTypeId;
                                        bo.DocumentPath = item.DocumentPath.Replace(_configuration["filesUrl"], "");
                                        bo.UploadDate = DateTime.Now;
                                        bo.DocumentExt = System.IO.Path.GetExtension(bo.DocumentPath);
                                        bo.DocumentSize = item.DocumentSize;

                                        bo.SaveNew();

                                    }
                                }


                                // add Preferred
                                if (model.PreferredTimes != null)
                                {
                                    foreach (var item in model.PreferredTimes)
                                    {
                                        var bo = new BOOperationRequestDetailPreferredTime();

                                        bo.DetailId = model.DetailId;
                                        bo.PreferredOperationId = item.PreferredOperationId;
                                        bo.WeekDayId = item.WeekDayId;

                                        TimeSpan from = DateTime.Now.TimeOfDay;
                                        TimeSpan to = DateTime.Now.TimeOfDay;

                                        try
                                        {
              

                                            TimeSpan.TryParse(item.FromTime, out from);
                                            TimeSpan.TryParse(item.ToTime, out to);
                                        }
                                        catch { }


                                        bo.FromTime = from;
                                        bo.ToTime = to;

                                        bo.SaveNew();

                                    }
                                }


                            }

                            

                        }
                        else
                        {
                            // update current
                            if (exist.OperationStatusId ==1 || exist.OperationStatusId == null)
                            {
                                exist.OperationId = model.OperationId;
                                exist.OperationDate = model.OperationDate;
                                exist.ClientId = model.ClientId > 0 ? model.ClientId : null;
                                exist.ClientTypeId = model.ClientTypeId;
                                exist.ClientNameAr = model.ClientNameAr;
                                exist.ClientNameEn = model.ClientNameEn;
                                exist.RegionId = 1;
                                exist.GovernerateId = model.GovernerateId;
                                exist.CityId = model.CityId;
                                exist.LocationLevelId = model.LocationLevelId;
                                exist.IsChain = model.IsChain;
                                exist.ResponsibleNameEn = model.ResponsibleNameEn;
                                exist.ResponsibleNameAr = model.ResponsibleNameAr;
                                exist.Building = model.Building;
                                exist.Floor = model.Floor;
                                exist.Property = model.Property;
                                exist.Address = model.Address;
                                exist.Landmark = model.Landmark;
                                exist.Phone = model.Phone;
                                exist.Mobile = model.Mobile;
                                exist.WhatsApp = model.WhatsApp;
                                exist.Latitude = model.Latitude;
                                exist.Longitude = model.Longitude;
                                exist.Accuracy = model.Accuracy;
                                exist.InZone = model.InZone;
                                exist.TaxCode = model.TaxCode;
                                exist.CommercialCode = model.CommercialCode;

                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;


                                exist.Update();

                                if (exist.DetailId > 0)
                                {
                                    model.DetailId = (int)exist.DetailId.Value;

                                    model.IsSynced = true;
                                    model.SyncDate = DateTime.Now;
                                    // add landmark
                                    exist.DeleteAllOperationRequestDetailLandmark();

                                    if (model.Landmarks != null)
                                    {
                                        foreach (var item in model.Landmarks)
                                        {
                                            var bo = new BOOperationRequestDetailLandmark();

                                            bo.DetailId = model.DetailId;
                                            bo.LandmarkId = item.LandmarkId;
                                            bo.SaveNew();

                                        }
                                    }



                                    // add docments
                                    exist.DeleteAllOperationRequestDetailDocument();

                                    if (model.Documents != null)
                                    {
                                        foreach (var item in model.Documents)
                                        {
                                            var bo = new BOOperationRequestDetailDocument();

                                            bo.DetailId = model.DetailId;
                                            bo.DocumentTypeId = item.DocumentTypeId;
                                            bo.DocumentPath = item.DocumentPath.Replace(_configuration["filesUrl"], "");
                                            bo.UploadDate = DateTime.Now;
                                            bo.DocumentExt = System.IO.Path.GetExtension(bo.DocumentPath);
                                            bo.DocumentSize = item.DocumentSize;

                                            bo.SaveNew();

                                        }
                                    }


                                    // add Preferred
                                    exist.DeleteAllOperationRequestDetailPreferredTime();

                                    if (model.PreferredTimes != null)
                                    {
                                        foreach (var item in model.PreferredTimes)
                                        {
                                            var bo = new BOOperationRequestDetailPreferredTime();

                                            bo.DetailId = model.DetailId;
                                            bo.PreferredOperationId = item.PreferredOperationId;
                                            bo.WeekDayId = item.WeekDayId;
                                            TimeSpan from = DateTime.Now.TimeOfDay;
                                            TimeSpan to = DateTime.Now.TimeOfDay;

                                            try
                                            {


                                                TimeSpan.TryParse(item.FromTime, out from);
                                                TimeSpan.TryParse(item.ToTime, out to);
                                            }
                                            catch { }


                                            bo.FromTime = from;
                                            bo.ToTime = to;

                                            bo.SaveNew();

                                        }
                                    }


                                }
                            }

                        }



                        var operation = new Criteria<BOOperationRequest>()
                            .Add(Expression.Eq(nameof(BOOperationRequest.OperationId), exist.OperationId))
                            .FirstOrDefault<BOOperationRequest>();


                        if (operation != null)
                        {
                            operation.TargetClients = operation.OperationRequestDetailCollection().Count;
                            operation.ActualClients = operation.OperationRequestDetailCollection().Where(a => a.OperationStatusId > 0).ToList().Count;
                            operation.Update();
                        }

                        responseModel.Data = model;
                        responseModel.Total = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpPost("add")]
        public async Task<IActionResult> add(OperationRequestDetailAddModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<OperationRequestDetailAddModel> responseModel = new ResponseModel<OperationRequestDetailAddModel>();

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
                        if(model.OperationId>0 && model.ClientId>0)
                        {
                            operationRequestManager.CreateValidationClient(UserId, model.OperationId, model.ClientId);

                            var operation = new Criteria<BOOperationRequest>()
                                .Add(Expression.Eq(nameof(BOOperationRequest.OperationId), model.OperationId))
                                .FirstOrDefault<BOOperationRequest>();


                            if (operation != null)
                            {
                                operation.TargetClients = operation.OperationRequestDetailCollection().Count;
                                operation.ActualClients = operation.OperationRequestDetailCollection().Where(a => a.OperationStatusId > 0).ToList().Count;
                                operation.Update();
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

        [CheckAuthorizedAttribute]
        [HttpPost("delete")]
        public async Task<IActionResult> delete(OperationRequestDetailModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<OperationRequestDetailModel> responseModel = new ResponseModel<OperationRequestDetailModel>();

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
                        var exist = new Criteria<BOOperationRequestDetail>()
                                        .Add(Expression.Eq(nameof(model.DetailId), model.DetailId))
                                        .FirstOrDefault<BOOperationRequestDetail>();


                        if (exist != null)
                        {

                            if (exist.OperationStatusId == 1 || exist.OperationStatusId == null)
                            {
                                exist.DeleteAllOperationRequestDetailDocument();
                                exist.DeleteAllOperationRequestDetailLandmark();
                                exist.DeleteAllOperationRequestDetailPreferredTime();
                                exist.Delete();
                            }
                        }


                        var operation = new Criteria<BOOperationRequest>()
                            .Add(Expression.Eq(nameof(BOOperationRequest.OperationId), exist.OperationId))
                            .FirstOrDefault<BOOperationRequest>();

                        if (operation != null)
                        {
                            operation.TargetClients = operation.OperationRequestDetailCollection().Count;
                            operation.ActualClients = operation.OperationRequestDetailCollection().Where(a => a.OperationStatusId > 0).ToList().Count;

                            operation.Update();
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


        [CheckAuthorizedAttribute]
        [HttpPost("reject")]
        public async Task<IActionResult> reject(OperationRequestDetailRejectModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<OperationRequestDetailRejectModel> responseModel = new ResponseModel<OperationRequestDetailRejectModel>();

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
                        var exist = new Criteria<BOOperationRequestDetail>()
                                        .Add(Expression.Eq(nameof(model.DetailId), model.DetailId))
                                        .FirstOrDefault<BOOperationRequestDetail>();


                        if (exist != null)
                        {



                            if (exist.OperationStatusId == null)
                            {
                                exist.OperationStatusId = 3;
                                exist.Accuracy= model.Accuracy;
                                exist.OperationRejectReasonId=model.OperationRejectReasonId;
                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;
                                exist.Update();


                                var all = new Criteria<BOOperationRequestDetail>()
                                        .Add(Expression.Eq(nameof(BOOperationRequestDetail.OperationId), exist.OperationId))
                                        .Add(Expression.Gt(nameof(BOOperationRequestDetail.OperationStatusId), 1))
                                        .List<BOOperationRequestDetail>();

                                var Accuracy= all.Average(x => x.Accuracy);

                                var operation = new Criteria<BOOperationRequest>()
                                    .Add(Expression.Eq(nameof(BOOperationRequest.OperationId), exist.OperationId))
                                    .FirstOrDefault<BOOperationRequest>();

                                if (operation!=null)
                                {
                                    operation.Accuracy = Accuracy;
                                    operation.TargetClients = operation.OperationRequestDetailCollection().Count;
                                    operation.ActualClients = operation.OperationRequestDetailCollection().Where(a => a.OperationStatusId > 0).ToList().Count;
                                    operation.Update();
                                }

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


        [CheckAuthorizedAttribute]
        [HttpPost("approve")]
        public async Task<IActionResult> approve(OperationRequestDetailApproveModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<OperationRequestDetailApproveModel> responseModel = new ResponseModel<OperationRequestDetailApproveModel>();

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
                        var exist = new Criteria<BOOperationRequestDetail>()
                                        .Add(Expression.Eq(nameof(model.DetailId), model.DetailId))
                                        .FirstOrDefault<BOOperationRequestDetail>();

                        if (exist != null)
                        {
                            if (exist.OperationStatusId == null )
                            {
                                exist.OperationStatusId = 2;
                                exist.Accuracy=model.Accuracy;
                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;
                                exist.Update();


                                var all = new Criteria<BOOperationRequestDetail>()
                                                .Add(Expression.Eq(nameof(BOOperationRequestDetail.OperationId), exist.OperationId))
                                                .Add(Expression.Gt(nameof(BOOperationRequestDetail.OperationStatusId), 1))
                                                .List<BOOperationRequestDetail>();

                                var Accuracy = all.Average(x => x.Accuracy);

                                var operation = new Criteria<BOOperationRequest>()
                                    .Add(Expression.Eq(nameof(BOOperationRequest.OperationId), exist.OperationId))
                                    .FirstOrDefault<BOOperationRequest>();

                                if (operation != null)
                                {
                                    operation.TargetClients = operation.OperationRequestDetailCollection().Count;
                                    operation.ActualClients = operation.OperationRequestDetailCollection().Where(a => a.OperationStatusId > 0).ToList().Count;

                                    operation.Accuracy = Accuracy;
                                    operation.Update();
                                }

                                if (model.OperationTypeId == 2)
                                {
                                    //update client

                                    if (exist.ClientId > 0)
                                    {

                                        var client = new Criteria<BOClient>()
                                                    .Add(Expression.Eq(nameof(exist.ClientId), exist.ClientId))
                                                    .FirstOrDefault<BOClient>();

                                        client.ClientTypeId = exist.ClientTypeId;
                                        client.ClientNameAr = exist.ClientNameAr;
                                        client.ClientNameEn = exist.ClientNameEn;
                                        client.RegionId = exist.RegionId;
                                        client.GovernerateId = exist.GovernerateId;
                                        client.CityId = exist.CityId;
                                        client.LocationLevelId = exist.LocationLevelId;
                                        client.IsChain = exist.IsChain;
                                        client.ResponsibleNameEn = exist.ResponsibleNameEn;
                                        client.ResponsibleNameAr = exist.ResponsibleNameAr;
                                        client.Building = exist.Building;
                                        client.Floor = exist.Floor;
                                        client.Property = exist.Property;
                                        client.Address = exist.Address;
                                        client.Landmark = exist.Landmark;
                                        client.Phone = exist.Phone;
                                        client.Mobile = exist.Mobile;
                                        client.WhatsApp = exist.WhatsApp;
                                        client.Latitude = exist.Latitude;
                                        client.Longitude = exist.Longitude;
                                        client.TaxCode = exist.TaxCode;
                                        client.CommercialCode = exist.CommercialCode;
                                        client.EBy = UserId;
                                        client.EDate = DateTime.Now;
                                        client.Update();

                                        client.DeleteAllClientDocument();
                                        client.DeleteAllClientLandmark();
                                        client.DeleteAllClientPreferredTime();

                                        foreach (var item in exist.OperationRequestDetailLandmarkCollection())
                                        {
                                            var bo = new BOClientLandmark();

                                            bo.ClientId = exist.ClientId;
                                            bo.LandmarkId = item.LandmarkId;
                                            bo.SaveNew();

                                        }


                                        // add docments
                                        foreach (var item in exist.OperationRequestDetailDocumentCollection())
                                        {
                                            var bo = new BOClientDocument();

                                            bo.ClientId = exist.ClientId;
                                            bo.DocumentTypeId = item.DocumentTypeId;
                                            bo.DocumentPath = item.DocumentPath;
                                            bo.UploadDate = DateTime.Now;
                                            bo.DocumentExt = System.IO.Path.GetExtension(bo.DocumentPath);
                                            bo.DocumentSize = item.DocumentSize;

                                            bo.SaveNew();

                                        }

                                        // add Preferred
                                        foreach (var item in exist.OperationRequestDetailPreferredTimeCollection())
                                        {
                                            var bo = new BOClientPreferredTime();

                                            bo.ClientId = exist.ClientId;
                                            bo.PreferredOperationId = item.PreferredOperationId;
                                            bo.WeekDayId = item.WeekDayId;
                                            bo.FromTime = item.FromTime;
                                            bo.ToTime = item.ToTime;

                                            bo.SaveNew();

                                        }



                                    }



                                }

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

        [CheckAuthorizedAttribute]
        [HttpPost("coded")]
        public async Task<IActionResult> coded(OperationRequestDetailCodedModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<OperationRequestDetailCodedModel> responseModel = new ResponseModel<OperationRequestDetailCodedModel>();

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
                        var exist = new Criteria<BOOperationRequestDetail>()
                                        .Add(Expression.Eq(nameof(model.DetailId), model.DetailId))
                                        .FirstOrDefault<BOOperationRequestDetail>();

                        if (exist != null)
                        {
                            if (exist.OperationStatusId == null)
                            {

                                exist.OperationStatusId = 4;
                                exist.ClientId = model.ClientId;
                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;
                                exist.Update();

                                if (exist.ClientId > 0)
                                {

                                    var client = new Criteria<BOClient>()
                                                .Add(Expression.Eq(nameof(exist.ClientId), exist.ClientId))
                                                .FirstOrDefault<BOClient>();

                                    client.ClientTypeId = exist.ClientTypeId;
                                    client.ClientNameAr = exist.ClientNameAr;
                                    client.ClientNameEn = exist.ClientNameEn;
                                    client.RegionId = exist.RegionId;
                                    client.GovernerateId = exist.GovernerateId;
                                    client.CityId = exist.CityId;
                                    client.LocationLevelId = exist.LocationLevelId;
                                    client.IsChain = exist.IsChain;
                                    client.ResponsibleNameEn = exist.ResponsibleNameEn;
                                    client.ResponsibleNameAr = exist.ResponsibleNameAr;
                                    client.Building = exist.Building;
                                    client.Floor = exist.Floor;
                                    client.Property = exist.Property;
                                    client.Address = exist.Address;
                                    client.Landmark = exist.Landmark;
                                    client.Phone = exist.Phone;
                                    client.Mobile = exist.Mobile;
                                    client.WhatsApp = exist.WhatsApp;
                                    client.Latitude = exist.Latitude;
                                    client.Longitude = exist.Longitude;
                                    client.TaxCode = exist.TaxCode;
                                    client.CommercialCode = exist.CommercialCode;
                                    client.EBy = UserId;
                                    client.EDate = DateTime.Now;
                                    client.Update();

                                    client.DeleteAllClientDocument();
                                    client.DeleteAllClientLandmark();
                                    client.DeleteAllClientPreferredTime();

                                    foreach (var item in exist.OperationRequestDetailLandmarkCollection())
                                    {
                                        var bo = new BOClientLandmark();

                                        bo.ClientId = exist.ClientId;
                                        bo.LandmarkId = item.LandmarkId;
                                        bo.SaveNew();

                                    }


                                    // add docments
                                    foreach (var item in exist.OperationRequestDetailDocumentCollection())
                                    {
                                        var bo = new BOClientDocument();

                                        bo.ClientId = exist.ClientId;
                                        bo.DocumentTypeId = item.DocumentTypeId;
                                        bo.DocumentPath = item.DocumentPath;
                                        bo.UploadDate = DateTime.Now;
                                        bo.DocumentExt = System.IO.Path.GetExtension(bo.DocumentPath);
                                        bo.DocumentSize = item.DocumentSize;

                                        bo.SaveNew();

                                    }

                                    // add Preferred
                                    foreach (var item in exist.OperationRequestDetailPreferredTimeCollection())
                                    {
                                        var bo = new BOClientPreferredTime();

                                        bo.ClientId = exist.ClientId;
                                        bo.PreferredOperationId = item.PreferredOperationId;
                                        bo.WeekDayId = item.WeekDayId;
                                        bo.FromTime = item.FromTime;
                                        bo.ToTime = item.ToTime;

                                        bo.SaveNew();

                                    }



                                }
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


        [CheckAuthorizedAttribute]
        [HttpPost("export")]
        public async Task<IActionResult> export(OperationRequestDetailSearchModel model)
        {
            try
            {


                var ctr = new Criteria<BOOperationRequestDetailVw>();


                // get by term
                ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationId), model.OperationId));

                // branch Permissions

                // get by model

                if (model.ClientId > 0)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.ClientId), model.ClientId));

                if (model.ClientTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.ClientTypeId), model.ClientTypeId));

                if (model.RegionId > 0)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.RegionId), model.RegionId));

                if (model.GovernerateId > 0)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.GovernerateId), model.GovernerateId));

                if (model.CityId > 0)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.CityId), model.CityId));

                if (model.LocationLevelId > 0)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.LocationLevelId), model.LocationLevelId));

                if (model.OperationStatusId > 0)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationStatusId), model.OperationStatusId));


                if (model.OperationRejectReasonId > 0)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationRejectReasonId), model.OperationRejectReasonId));

                if (model.OperationDate != null && model.OperationDate.Value.Year > 1900)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestDetailVw.OperationDate), model.OperationDate, dateformatter));

                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {
                    switch (model.SortBy.Property)
                    {
                        case "cityName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("cityName{0}", Language)) : OrderBy.Desc(string.Format("cityName{0}", Language)));
                            break;
                        case "clientTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientTypeName{0}", Language)) : OrderBy.Desc(string.Format("clientTypeName{0}", Language)));
                            break;
                        case "clientName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                            break;
                        case "governerateName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("governerateName{0}", Language)) : OrderBy.Desc(string.Format("governerateName{0}", Language)));
                            break;
                        case "locationLevelName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("locationLevelName{0}", Language)) : OrderBy.Desc(string.Format("locationLevelName{0}", Language)));
                            break;
                        case "operationStatusName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("operationStatusName{0}", Language)) : OrderBy.Desc(string.Format("operationStatusName{0}", Language)));
                            break;
                        case "responsibleName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("responsibleName{0}", Language)) : OrderBy.Desc(string.Format("responsibleName{0}", Language)));
                            break;
                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }
                }
                else
                {
                    ctr.Add(OrderBy.Desc(nameof(BOOperationRequestDetailVw.OperationId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr
                             .List<BOOperationRequestDetailVw>()
                             .Select(a => new OperationRequestDetailListModel()
                             {

                                 OperationId = a.OperationId,
                                 OperationStatusId = a.OperationStatusId,
                                 LocationLevelId = a.LocationLevelId,
                                 CityId = a.CityId,
                                 OperationDate = a.OperationDate,
                                 RegionId = a.RegionId,
                                 ClientId = a.ClientId,
                                 ClientTypeId = a.ClientTypeId,
                                 GovernerateId = a.GovernerateId,
                                 DetailId = a.DetailId,
                                 Floor = a.Floor,
                                 Latitude = a.Latitude,
                                 Property = a.Property,
                                 IsChain = a.IsChain,
                                 Phone = a.Phone,
                                 Mobile = a.Mobile,
                                 Landmark = a.Landmark,
                                 Longitude = a.Longitude,
                                 WhatsApp = a.WhatsApp,
                                 Address = a.Address,
                                 Building = a.Building,
                                 ClientCode = a.ClientCode,
                                 Accuracy = a.Accuracy,
                                 ResponsibleName = Language == "ar" ? a.ResponsibleNameAr : a.ResponsibleNameEn,
                                 ClientTypeName = Language == "ar" ? a.ClientTypeNameAr : a.ClientTypeNameEn,
                                 CityName = Language == "ar" ? a.CityNameAr : a.CityNameEn,
                                 ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                 GovernerateName = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,
                                 LocationLevelName = Language == "ar" ? a.LocationLevelNameAr : a.LocationLevelNameEn,
                                 OperationStatusName = Language == "ar" ? a.OperationStatusNameAr : a.OperationStatusNameEn,



                             }).ToList();



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "OperationDate";
                        worksheet.Cell("B1").Value = "GovernerateName";
                        worksheet.Cell("C1").Value = "CityName";
                        worksheet.Cell("D1").Value = "ClientCode";
                        worksheet.Cell("E1").Value = "ClientName";
                        worksheet.Cell("F1").Value = "ClientTypeName";
                        worksheet.Cell("G1").Value = "IsChain";
                        worksheet.Cell("H1").Value = "ResponsibleName";
                        worksheet.Cell("I1").Value = "Phone";
                        worksheet.Cell("J1").Value = "Mobile";
                        worksheet.Cell("K1").Value = "WhatsApp";
                        worksheet.Cell("L1").Value = "LocationLevelName";
                        worksheet.Cell("M1").Value = "Address";
                        worksheet.Cell("N1").Value = "Landmark";
                        worksheet.Cell("O1").Value = "Building";
                        worksheet.Cell("P1").Value = "Floor";
                        worksheet.Cell("Q1").Value = "Property";
                        worksheet.Cell("R1").Value = "Latitude";
                        worksheet.Cell("S1").Value = "Longitude";
                        worksheet.Cell("T1").Value = "Accuracy";
                        worksheet.Cell("U1").Value = "OperationStatusName";




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

                        worksheet.Cell("K1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("K1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("L1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("L1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("M1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("M1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("N1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("N1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("O1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("O1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("P1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("P1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("Q1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("Q1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("R1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("P1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("S1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("S1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("T1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("T1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("U1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("U1").Style.Font.FontColor = XLColor.White;

                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].OperationDate;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].GovernerateName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].CityName;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].ClientTypeName;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].IsChain;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].ResponsibleName;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].Phone;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].Mobile;
                            worksheet.Cell(string.Format("K{0}", i + 2)).Value = res[i].WhatsApp;
                            worksheet.Cell(string.Format("L{0}", i + 2)).Value = res[i].LocationLevelName;
                            worksheet.Cell(string.Format("M{0}", i + 2)).Value = res[i].Address;
                            worksheet.Cell(string.Format("N{0}", i + 2)).Value = res[i].Landmark;
                            worksheet.Cell(string.Format("O{0}", i + 2)).Value = res[i].Building;
                            worksheet.Cell(string.Format("P{0}", i + 2)).Value = res[i].Floor;
                            worksheet.Cell(string.Format("Q{0}", i + 2)).Value = res[i].Property;
                            worksheet.Cell(string.Format("R{0}", i + 2)).Value = res[i].Latitude;
                            worksheet.Cell(string.Format("S{0}", i + 2)).Value = res[i].Longitude;
                            worksheet.Cell(string.Format("T{0}", i + 2)).Value = res[i].Accuracy;
                            worksheet.Cell(string.Format("U{0}", i + 2)).Value = res[i].OperationStatusName;

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
    }
}
