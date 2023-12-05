using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
{
    [Route("api/[controller]")]
    public class OperationRequestDetailController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public OperationRequestDetailController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {

            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }






        [HttpPost("filterAll")]
        public async Task<IActionResult> filterAll(OperationRequestDetailSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<OperationRequestDetailModel>> responseModel = new ResponseModel<List<OperationRequestDetailModel>>();

                if (model == null)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";
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



        [HttpPost("save")]
        public async Task<IActionResult> save(OperationRequestDetailModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<OperationRequestDetailModel> responseModel = new ResponseModel<OperationRequestDetailModel>();

                if (model == null )
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";
                    responseModel.StatusCode = 503;

                }
                else if (! model.IsValid())
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";
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


   
    }
}
