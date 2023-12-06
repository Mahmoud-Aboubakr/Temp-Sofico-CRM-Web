using AutoMapper;
using ClosedXML.Excel;
using CSVFile;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class ClientRequestController : BaseController
    {

        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ClientRequestController(IHttpContextAccessor contextAccessor, IOperationRequestManager operationRequestManager, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }



        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientRequestSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientServiceRequestListModel>> responseModel = new ResponseModel<List<ClientServiceRequestListModel>>();

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


                        var ctr = new Criteria<BOClientServiceRequestVw>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestCode), model.Term));
                        }

                        // branch Permissions

                        // get by model

                        if (model.RepresentativeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RepresentativeId), model.RepresentativeId));


                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.BranchId), model.BranchId));

                        if (model.ClientId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.ClientId), model.ClientId));

                        if (model.RequestStatusId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestStatusId), model.RequestStatusId));

                        if (model.RequestTypeDetailId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestTypeDetailId), model.RequestTypeDetailId));


                        if (!string.IsNullOrEmpty(model.Phone))
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.Phone), model.Phone));

                        if (model.RequestTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestTypeId), model.RequestTypeId));

                        if (model.DepartmentId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.DepartmentId), model.DepartmentId));

                        if (model.PriorityId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.PriorityId), model.PriorityId));

                        if (model.IsClosed >0)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.IsClosed), model.IsClosed==1?true:false));


                        if (model.RequestDate !=null && model.RequestDate.Value.Year>1900)
                            ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestDate), model.RequestDate, dateformatter));

                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "clientName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                                    break;
                                case "RequestStatusName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("RequestStatusName{0}", Language)) : OrderBy.Desc(string.Format("RequestStatusName{0}", Language)));
                                    break;
                                case "RequestTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("RequestTypeName{0}", Language)) : OrderBy.Desc(string.Format("RequestTypeName{0}", Language)));
                                    break;
                                case "departmentName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("departmentName{0}", Language)) : OrderBy.Desc(string.Format("departmentName{0}", Language)));
                                    break;
                                case "priorityName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("priorityName{0}", Language)) : OrderBy.Desc(string.Format("priorityName{0}", Language)));
                                    break;
                                case "representativeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOClientServiceRequestVw.RequestId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOClientServiceRequestVw>()
                                     .Select(a=> new ClientServiceRequestListModel()
                                     {

                                         RequestId = a.RequestId.Value,
                                         PriorityId=a.PriorityId,
                                         Phone = a.Phone,
                                         RequestTypeId = a.RequestTypeId,
                                         DepartmentId = a.DepartmentId,
                                         RequestStatusId = a.RequestStatusId,
                                         BranchId = a.BranchId,
                                         ClientCode = a.ClientCode,
                                         ClientId = a.ClientId,
                                         RequestTypeDetailId = a.RequestTypeDetailId,
                                         Duration = a.Duration,
                                         IsClosed = a.IsClosed,
                                         BranchCode = a.BranchCode,
                                         CloseDate=a.CloseDate,
                                         RequestCode = a.RequestCode,
                                         RequestDate = a.RequestDate,
                                         RepresentativeCode = a.RepresentativeCode,
                                         RepresentativeId = a.RepresentativeId,
                                         RequestTime=a.RequestTime,
                                         PriorityColor=a.PriorityColor,
                                         BranchName =Language=="ar"?a.BranchNameAr:a.BranchNameEn,
                                         ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                         RequestStatusName = Language == "ar" ? a.RequestStatusNameAr : a.RequestStatusNameEn,
                                         RequestTypeName = Language == "ar" ? a.RequestTypeNameAr : a.RequestTypeNameEn,
                                         DepartmentName = Language == "ar" ? a.DepartmentNameAr : a.DepartmentNameEn,
                                         PriorityName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                                         RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,

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
        [HttpPost("save")]
        public async Task<IActionResult> save(ClientServiceRequestModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientServiceRequestModel> responseModel = new ResponseModel<ClientServiceRequestModel>();

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
                        var exist = new Criteria<BOClientServiceRequest>()

                                        .Add(Expression.Eq(nameof(model.RequestId), model.RequestId))


                                        .FirstOrDefault<BOClientServiceRequest>();


                        if (exist == null)
                        {



                            // create new
                            exist = new BOClientServiceRequest();

                            exist.RepresentativeId = model.RepresentativeId;
                            exist.ClientId= model.ClientId;
                            exist.BranchId=model.BranchId;
                            exist.RequestDate=exist.RequestDate!=null ? exist.RequestDate : DateTime.Now;
                            exist.RequestTime = exist.RequestDate != null ? exist.RequestDate : DateTime.Now;
                            exist.RequestTypeId = model.RequestTypeId;
                            exist.RequestTypeDetailId = model.RequestTypeDetailId;
                            exist.Phone = model.Phone;
                            exist.PhoneAlternative = model.PhoneAlternative;
                            exist.PriorityId = model.PriorityId;
                            exist.RequestStatusId = model.RequestStatusId;

                            if (model.RequestStatusId != 3)
                            {
                                if (model.DepartmentId > 0)
                                {
                                    exist.RequestStatusId = 2;
                                }
                            }

                            if (exist.RequestStatusId == 3)
                            {
                                exist.IsClosed = true;
                                exist.CloseDate = DateTime.Now;
                                exist.Duration = (int)(DateTime.Now - exist.RequestTime.Value).TotalHours;

                            }
                            else
                            {
                                exist.IsClosed = false;
                                exist.CloseDate = null;
                                exist.Duration= null;
                            }

                            exist.Latitude = model.Latitude;
                            exist.Longitude = model.Longitude;
                            
                            exist.InZone = model.InZone;
                            exist.Distance = model.Distance;

                            if (exist.RequestStatusId == 2)
                            {
                                exist.DepartmentId = model.DepartmentId;

                            }

                            exist.Notes = model.Notes;
                            exist.Replay = model.Replay;


                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;


                            exist.SaveNew();

                            if (exist.RequestId > 0)
                            {
                                exist.RequestCode = string.Format(_configuration["settings:prefix:request"], exist.RequestId.Value.ToString().PadLeft(7, '0'));
                                exist.Update();

                                model.RequestId = exist.RequestId.Value;
                                model.RequestCode=exist.RequestCode;

                                model.IsSynced = true;
                                model.SyncDate = DateTime.Now;

                                var bo = new BOClientServiceRequestTimline();
                                bo.RequestId = exist.RequestId;
                                bo.RequestStatusId = 1;
                                bo.UserId = UserId;
                                bo.TimelineDate = DateTime.Now;
                                bo.SaveNew();

                                if (exist.RequestStatusId == 2)
                                {
                                    bo = new BOClientServiceRequestTimline();
                                    bo.RequestId = exist.RequestId;
                                    bo.RequestStatusId = 2;
                                    bo.UserId = UserId;
                                    bo.TimelineDate = DateTime.Now;
                                    bo.SaveNew();
                                }

                                if (exist.RequestStatusId == 3)
                                {
                                    bo = new BOClientServiceRequestTimline();
                                    bo.RequestId = exist.RequestId;
                                    bo.RequestStatusId = 3;
                                    bo.UserId = UserId;
                                    bo.TimelineDate = DateTime.Now;
                                    bo.SaveNew();
                                }

                                // add Documents

                                foreach (var item in model.Documents)
                                {
                                    var boD = new BOClientServiceRequestDocument();

                                    boD.RequestId = exist.RequestId;
                                    boD.DocumentPath = item.DocumentPath.Replace(_configuration["filesUrl"], "");
                                    boD.UploadDate = DateTime.Now;
                                    boD.DocumentExt = System.IO.Path.GetExtension(boD.DocumentPath);
                                    boD.DocumentSize = item.DocumentSize;

                                    boD.SaveNew();
                                }

                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = "Error In Sync Data" ;
                            }

                        }
                        else
                        {
                            // update current
                            if (exist.IsClosed != true)
                            {

                                exist.RepresentativeId = model.RepresentativeId;
                                exist.ClientId = model.ClientId;
                                exist.BranchId = model.BranchId;
                                exist.RequestTypeId = model.RequestTypeId;
                                exist.RequestTypeDetailId = model.RequestTypeDetailId;
                                exist.Phone = model.Phone;
                                exist.PhoneAlternative = model.PhoneAlternative;
                                exist.PriorityId = model.PriorityId;
                                exist.RequestStatusId = model.RequestStatusId;

                                if (model.RequestStatusId != 3)
                                {
                                    if (model.DepartmentId > 0)
                                    {
                                        exist.RequestStatusId = 2;
                                    }
                                }


                                if (exist.RequestStatusId == 3)
                                {
                                    exist.IsClosed = true;
                                    exist.CloseDate = DateTime.Now;
                                    exist.Duration = (int)(DateTime.Now - exist.RequestTime.Value).TotalHours;

                                }
                                else
                                {
                                    exist.IsClosed = false;
                                    exist.CloseDate = null;
                                    exist.Duration = null;
                                }

                                exist.Latitude = model.Latitude;
                                exist.Longitude = model.Longitude;

                                exist.InZone = model.InZone;
                                exist.Distance = model.Distance;

                                if (exist.RequestStatusId == 2)
                                {
                                    exist.DepartmentId = model.DepartmentId;
                                }

                                exist.Notes = model.Notes;

                                exist.Notes = model.Notes;
                                exist.Replay = model.Replay;
                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;


                                if (exist.RequestStatusId == 2)
                                {

                                    var existStatus = new Criteria<BOClientServiceRequestTimline>()
                                                .Add(Expression.Eq(nameof(BOClientServiceRequestTimline.RequestId), exist.RequestId))
                                                .Add(Expression.Eq(nameof(BOClientServiceRequestTimline.RequestStatusId), 2))
                                                .FirstOrDefault<BOClientServiceRequestTimline>();

                                    if (existStatus != null)
                                    {
                                        existStatus.UserId = UserId;
                                        existStatus.TimelineDate = DateTime.Now;
                                        existStatus.Update();
                                    }
                                    else
                                    {
                                        existStatus = new BOClientServiceRequestTimline();
                                        existStatus.RequestId = exist.RequestId;
                                        existStatus.RequestStatusId = 2;
                                        existStatus.UserId = UserId;
                                        existStatus.TimelineDate = DateTime.Now;
                                        existStatus.SaveNew();
                                    }


                                }

                                if (exist.RequestStatusId == 3)
                                {
                                    var existStatus = new Criteria<BOClientServiceRequestTimline>()
                                                .Add(Expression.Eq(nameof(BOClientServiceRequestTimline.RequestId), exist.RequestId))
                                                .Add(Expression.Eq(nameof(BOClientServiceRequestTimline.RequestStatusId), 3))
                                                .FirstOrDefault<BOClientServiceRequestTimline>();

                                    if (existStatus != null)
                                    {


                                        existStatus.UserId = UserId;
                                        existStatus.TimelineDate = DateTime.Now;
                                        existStatus.Update();
                                    }
                                    else
                                    {
                                        existStatus = new BOClientServiceRequestTimline();
                                        existStatus.RequestId = exist.RequestId;
                                        existStatus.RequestStatusId = 3;
                                        existStatus.UserId = UserId;
                                        existStatus.TimelineDate = DateTime.Now;
                                        existStatus.SaveNew();
                                    }
                                }

                                exist.Update();

                                model.IsSynced = true;
                                model.SyncDate = DateTime.Now;

                                // add Documents
                                exist.DeleteAllClientServiceRequestDocument();

                                foreach (var item in model.Documents)
                                {
                                    var boD = new BOClientServiceRequestDocument();

                                    boD.RequestId = exist.RequestId;
                                    boD.DocumentPath = item.DocumentPath.Replace(_configuration["filesUrl"], "");
                                    boD.UploadDate = DateTime.Now;
                                    boD.DocumentExt = System.IO.Path.GetExtension(boD.DocumentPath);
                                    boD.DocumentSize = item.DocumentSize;

                                    boD.SaveNew();
                                }


                                model.CloseDate=exist.CloseDate;
                                model.Duration=exist.Duration;
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = "Error In Sync Data";
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
        public async Task<IActionResult> delete(ClientServiceRequestModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientServiceRequestModel> responseModel = new ResponseModel<ClientServiceRequestModel>();

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
                        var exist = new Criteria<BOClientServiceRequest>()
                                        .Add(Expression.Eq(nameof(model.RequestId), model.RequestId))
                                        .FirstOrDefault<BOClientServiceRequest>();


                        if (exist != null)
                        {
                            // check if has representitive
                            if (exist.IsClosed == false)
                            {
                                exist.Delete();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Cannot_delete;
                                return responseModel;
                            }
                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                            return responseModel;
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
        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientServiceRequestModel> responseModel = new ResponseModel<ClientServiceRequestModel>();

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

                        var exist = new Criteria<BOClientServiceRequest>()
                                       .Add(Expression.Eq(nameof(BOClientServiceRequest.RequestId),Id))
                                       .FirstOrDefault<BOClientServiceRequest>();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<ClientServiceRequestModel>(exist);
                            responseModel.Data.Documents = new Criteria<BOClientServiceRequestDocumentVw>()
                                                                .Add(Expression.Eq(nameof(BOClientServiceRequestDocumentVw.RequestId), Id))
                                                                .List<BOClientServiceRequestDocumentVw>()
                                                                .Select(a => new ClientServiceRequestDocumentListModel()
                                                                {
                                                                    RequestId = a.RequestId,
                                                                    RequestDocumentId = a.RequestDocumentId.Value,
                                                                    DocumentExt = a.DocumentExt,
                                                                    DocumentPath = _configuration["filesUrl"] + a.DocumentPath,
                                                                    DocumentSize = a.DocumentSize,
                                                                    UploadDate = a.UploadDate
                                                                }).ToList();

                            var Timlines = new Criteria<BOClientServiceRequestTimlineVw>()
                                                               .Add(Expression.Eq(nameof(BOClientServiceRequestTimlineVw.RequestId), Id))
                                                               .List<BOClientServiceRequestTimlineVw>()
                                                               .Select(a => new ClientServiceRequestTimlineListModel()
                                                               {
                                                                   RequestId = a.RequestId,
                                                                   RequestStatusId = a.RequestStatusId,
                                                                   Notes = a.Notes,
                                                                   TimelineDate = a.TimelineDate,
                                                                   TimelineId = a.TimelineId.Value,
                                                                   UserId = a.UserId,
                                                                   RealName = a.RealName,
                                                                   RequestStatusName = Language == "ar" ? a.RequestStatusNameAr : a.RequestStatusNameEn,

                                                               }).ToList();


                            var allTime = BORequestStatus.RequestStatusCollection();

                            foreach (var item in allTime)
                            {
                                var found = Timlines.Where(a => a.RequestStatusId == item.RequestStatusId).FirstOrDefault();
                                if (found == null)
                                {
                                    responseModel.Data.TimeLine.Add(new ClientServiceRequestTimlineListModel()
                                    {
                                        RequestStatusId = item.RequestStatusId,
                                        Notes = "",
                                        TimelineDate = null,
                                        TimelineId = 0,
                                        UserId = 0,
                                        RealName = "",
                                        RequestStatusName = Language == "ar" ? item.RequestStatusNameAr : item.RequestStatusNameEn,
                                    });
                                }
                                else
                                {
                                    responseModel.Data.TimeLine.Add(found);
                                }

                            }

                            responseModel.Data.TimeLine=responseModel.Data.TimeLine.OrderBy(a => a.RequestStatusId).ToList();


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
        [HttpPost("export")]
        public async Task<IActionResult> export(ClientRequestSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BOClientServiceRequestVw>();


                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestCode), model.Term));
                }

                // branch Permissions

                // get by model

                if (model.RepresentativeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RepresentativeId), model.RepresentativeId));


                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.BranchId), model.BranchId));

                if (model.ClientId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.ClientId), model.ClientId));

                if (model.RequestStatusId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestStatusId), model.RequestStatusId));

                if (model.RequestTypeDetailId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestTypeDetailId), model.RequestTypeDetailId));


                if (!string.IsNullOrEmpty(model.Phone))
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.Phone), model.Phone));

                if (model.RequestTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestTypeId), model.RequestTypeId));

                if (model.DepartmentId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.DepartmentId), model.DepartmentId));

                if (model.PriorityId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.PriorityId), model.PriorityId));

                if (model.IsClosed > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.IsClosed), model.IsClosed == 1 ? true : false));


                if (model.RequestDate != null && model.RequestDate.Value.Year > 1900)
                    ctr.Add(Expression.Eq(nameof(BOClientServiceRequestVw.RequestDate), model.RequestDate, dateformatter));

                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {
                    switch (model.SortBy.Property)
                    {
                        case "branchName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                            break;
                        case "clientName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                            break;
                        case "RequestStatusName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("RequestStatusName{0}", Language)) : OrderBy.Desc(string.Format("RequestStatusName{0}", Language)));
                            break;
                        case "RequestTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("RequestTypeName{0}", Language)) : OrderBy.Desc(string.Format("RequestTypeName{0}", Language)));
                            break;
                        case "departmentName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("departmentName{0}", Language)) : OrderBy.Desc(string.Format("departmentName{0}", Language)));
                            break;
                        case "priorityName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("priorityName{0}", Language)) : OrderBy.Desc(string.Format("priorityName{0}", Language)));
                            break;
                        case "representativeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
                            break;
                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }
                }
                else
                {
                    ctr.Add(OrderBy.Desc(nameof(BOClientServiceRequestVw.RequestId)));
                }
                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr
                             .List<BOClientServiceRequestVw>()
                             .Select(a => new ClientServiceRequestListModel()
                             {

                                 RequestId = a.RequestId.Value,
                                 PriorityId = a.PriorityId,
                                 Phone = a.Phone,
                                 RequestTypeId = a.RequestTypeId,
                                 DepartmentId = a.DepartmentId,
                                 RequestStatusId = a.RequestStatusId,
                                 BranchId = a.BranchId,
                                 ClientCode = a.ClientCode,
                                 ClientId = a.ClientId,
                                 RequestTypeDetailId = a.RequestTypeDetailId,
                                 Duration = a.Duration,
                                 IsClosed = a.IsClosed,
                                 BranchCode = a.BranchCode,
                                 CloseDate = a.CloseDate,
                                 RequestCode = a.RequestCode,
                                 RequestDate = a.RequestDate,
                                 RepresentativeCode = a.RepresentativeCode,
                                 RepresentativeId = a.RepresentativeId,
                                 RequestTime = a.RequestTime,

                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                 RequestStatusName = Language == "ar" ? a.RequestStatusNameAr : a.RequestStatusNameEn,
                                 RequestTypeName = Language == "ar" ? a.RequestTypeNameAr : a.RequestTypeNameEn,
                                 DepartmentName = Language == "ar" ? a.DepartmentNameAr : a.DepartmentNameEn,
                                 PriorityName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                                 RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,

                             }).ToList();


                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "RequestCode";
                        worksheet.Cell("B1").Value = "RequestDate";
                        worksheet.Cell("C1").Value = "RepresentativeCode";
                        worksheet.Cell("D1").Value = "RepresentativeName";
                        worksheet.Cell("E1").Value = "ClientCode";
                        worksheet.Cell("F1").Value = "ClientName";
                        worksheet.Cell("G1").Value = "Phone";
                        worksheet.Cell("H1").Value = "IsClosed";
                        worksheet.Cell("I1").Value = "CloseDate";
                        worksheet.Cell("J1").Value = "Duration";
                        worksheet.Cell("K1").Value = "DepartmentName";
                        worksheet.Cell("L1").Value = "RequestTypeName";
                        worksheet.Cell("M1").Value = "RequestStatusName";



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

                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].RequestCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].RequestDate;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].RepresentativeCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].RepresentativeName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].Phone;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].IsClosed;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].CloseDate;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].Duration;
                            worksheet.Cell(string.Format("K{0}", i + 2)).Value = res[i].DepartmentName;
                            worksheet.Cell(string.Format("L{0}", i + 2)).Value = res[i].RequestTypeName;
                            worksheet.Cell(string.Format("M{0}", i + 2)).Value = res[i].RequestStatusName;


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
