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
    public class ClientComplainController : BaseController
    {

        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ClientComplainController(IHttpContextAccessor contextAccessor, IOperationRequestManager operationRequestManager, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }



        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientComplainSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientComplainListModel>> responseModel = new ResponseModel<List<ClientComplainListModel>>();

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


                        var ctr = new Criteria<BOClientComplainVw>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainCode), model.Term));
                        }

                        // branch Permissions

                        // get by model

                        if (model.RepresentativeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.RepresentativeId), model.RepresentativeId));


                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.BranchId), model.BranchId));

                        if (model.ClientId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ClientId), model.ClientId));

                        if (model.ComplainStatusId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainStatusId), model.ComplainStatusId));

                        if (model.ComplainTypeDetailId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainTypeDetailId), model.ComplainTypeDetailId));


                        if (!string.IsNullOrEmpty(model.Phone))
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.Phone), model.Phone));

                        if (model.ComplainTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainTypeId), model.ComplainTypeId));

                        if (model.DepartmentId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.DepartmentId), model.DepartmentId));

                        if (model.PriorityId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.PriorityId), model.PriorityId));

                        if (model.IsClosed >0)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.IsClosed), model.IsClosed==1?true:false));


                        if (model.ComplainDate !=null && model.ComplainDate.Value.Year>1900)
                            ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainDate), model.ComplainDate, dateformatter));

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
                                case "complainStatusName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("complainStatusName{0}", Language)) : OrderBy.Desc(string.Format("complainStatusName{0}", Language)));
                                    break;
                                case "complainTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("complainTypeName{0}", Language)) : OrderBy.Desc(string.Format("complainTypeName{0}", Language)));
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
                            ctr.Add(OrderBy.Desc(nameof(BOClientComplainVw.ComplainId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOClientComplainVw>()
                                     .Select(a=> new ClientComplainListModel()
                                     {

                                         ComplainId = a.ComplainId.Value,
                                         PriorityId=a.PriorityId,
                                         Phone = a.Phone,
                                         ComplainTypeId = a.ComplainTypeId,
                                         DepartmentId = a.DepartmentId,
                                         ComplainStatusId = a.ComplainStatusId,
                                         BranchId = a.BranchId,
                                         ClientCode = a.ClientCode,
                                         ClientId = a.ClientId,
                                         ComplainTypeDetailId = a.ComplainTypeDetailId,
                                         Duration = a.Duration,
                                         IsClosed = a.IsClosed,
                                         BranchCode = a.BranchCode,
                                         CloseDate=a.CloseDate,
                                         ComplainCode = a.ComplainCode,
                                         ComplainDate = a.ComplainDate,
                                         RepresentativeCode = a.RepresentativeCode,
                                         RepresentativeId = a.RepresentativeId,
                                         ComplainTime=a.ComplainTime,
                                         PriorityColor=a.PriorityColor,
                                         BranchName =Language=="ar"?a.BranchNameAr:a.BranchNameEn,
                                         ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                         ComplainStatusName = Language == "ar" ? a.ComplainStatusNameAr : a.ComplainStatusNameEn,
                                         ComplainTypeName = Language == "ar" ? a.ComplainTypeNameAr : a.ComplainTypeNameEn,
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
        public async Task<IActionResult> save(ClientComplainModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientComplainModel> responseModel = new ResponseModel<ClientComplainModel>();

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
                        var exist = new Criteria<BOClientComplain>()
                                        .Add(Expression.Eq(nameof(model.ComplainId), model.ComplainId))
                                        .FirstOrDefault<BOClientComplain>();


                        if (exist == null)
                        {



                            // create new
                            exist = new BOClientComplain();

                            exist.RepresentativeId = model.RepresentativeId;
                            exist.ClientId= model.ClientId;
                            exist.BranchId=model.BranchId;
                            exist.ComplainDate=exist.ComplainDate!=null ? exist.ComplainDate : DateTime.Now;
                            exist.ComplainTime = exist.ComplainDate != null ? exist.ComplainDate : DateTime.Now;
                            exist.ComplainTypeId = model.ComplainTypeId;
                            exist.ComplainTypeDetailId = model.ComplainTypeDetailId;
                            exist.Phone = model.Phone;
                            exist.PhoneAlternative = model.PhoneAlternative;
                            exist.PriorityId = model.PriorityId;
                            exist.ComplainStatusId = model.ComplainStatusId;

                            if (model.ComplainStatusId != 3)
                            {
                                if (model.DepartmentId > 0)
                                {
                                    exist.ComplainStatusId = 2;
                                }
                            }

                            if (exist.ComplainStatusId == 3)
                            {
                                exist.IsClosed = true;
                                exist.CloseDate = DateTime.Now;
                                exist.Duration = (int)(DateTime.Now - exist.ComplainTime.Value).TotalHours;

                            }
                            else
                            {
                                exist.IsClosed = false;
                                exist.CloseDate = null;
                                exist.Duration= null;
                            }

                            exist.Latitude = model.Latitude;
                            exist.Longitude = model.Longitude;

                            if(exist.ComplainStatusId == 2)
                            {
                                exist.DepartmentId = model.DepartmentId;

                            }

                            exist.Notes = model.Notes;
                            exist.Replay = model.Replay;
                            exist.InZone = model.InZone;
                            exist.Distance = model.Distance;


                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;


                            exist.SaveNew();

                            if (exist.ComplainId > 0)
                            {
                                exist.ComplainCode = string.Format(_configuration["settings:prefix:complain"], exist.ComplainId.Value.ToString().PadLeft(7, '0'));
                                exist.Update();

                                model.ComplainId = exist.ComplainId.Value;
                                model.ComplainCode=exist.ComplainCode;

                                var bo = new BOClientComplainTimeline();
                                bo.ComplainId = exist.ComplainId;
                                bo.ComplainStatusId = 1;
                                bo.UserId = UserId;
                                bo.TimelineDate = DateTime.Now;
                                bo.SaveNew();

                                if (exist.ComplainStatusId == 2)
                                {
                                    bo = new BOClientComplainTimeline();
                                    bo.ComplainId = exist.ComplainId;
                                    bo.ComplainStatusId = 2;
                                    bo.UserId = UserId;
                                    bo.TimelineDate = DateTime.Now;
                                    bo.SaveNew();
                                }

                                if (exist.ComplainStatusId == 3)
                                {
                                    bo = new BOClientComplainTimeline();
                                    bo.ComplainId = exist.ComplainId;
                                    bo.ComplainStatusId = 3;
                                    bo.UserId = UserId;
                                    bo.TimelineDate = DateTime.Now;
                                    bo.SaveNew();
                                }

                                // add Documents
                                if (model.Documents != null)
                                {
                                    foreach (var item in model.Documents)
                                    {
                                        var boD = new BOClientComplainDocument();

                                        boD.ComplainId = exist.ComplainId;
                                        boD.DocumentPath = item.DocumentPath.Replace(_configuration["filesUrl"], "");
                                        boD.UploadDate = DateTime.Now;
                                        boD.DocumentExt = System.IO.Path.GetExtension(boD.DocumentPath);
                                        boD.DocumentSize = item.DocumentSize;

                                        boD.SaveNew();
                                    }
                                }


                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = "Error In Sync Data";
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
                                exist.ComplainTypeId = model.ComplainTypeId;
                                exist.ComplainTypeDetailId = model.ComplainTypeDetailId;
                                exist.Phone = model.Phone;
                                exist.PhoneAlternative = model.PhoneAlternative;
                                exist.PriorityId = model.PriorityId;
                                exist.ComplainStatusId = model.ComplainStatusId;

                                if (model.ComplainStatusId != 3)
                                {
                                    if (model.DepartmentId > 0)
                                    {
                                        exist.ComplainStatusId = 2;
                                    }
                                }


                                if (exist.ComplainStatusId == 3)
                                {
                                    exist.IsClosed = true;
                                    exist.CloseDate = DateTime.Now;
                                    exist.Duration = (int)(DateTime.Now - exist.ComplainTime.Value).TotalHours;

                                }
                                else
                                {
                                    exist.IsClosed = false;
                                    exist.CloseDate = null;
                                    exist.Duration = null;
                                }

                                exist.Latitude = model.Latitude;
                                exist.Longitude = model.Longitude;
                                if (exist.ComplainStatusId == 2)
                                {
                                    exist.DepartmentId = model.DepartmentId;

                                }

                                exist.InZone = model.InZone;
                                exist.Distance = model.Distance;
                                exist.Replay=model.Replay;
                                exist.Notes = model.Notes;

                                exist.Notes = model.Notes;
                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;


                                if (exist.ComplainStatusId == 2)
                                {

                                    var existStatus = new Criteria<BOClientComplainTimeline>()
                                                .Add(Expression.Eq(nameof(BOClientComplainTimeline.ComplainId), exist.ComplainId))
                                                .Add(Expression.Eq(nameof(BOClientComplainTimeline.ComplainStatusId), 2))
                                                .FirstOrDefault<BOClientComplainTimeline>();

                                    if (existStatus != null)
                                    {
                                        existStatus.UserId = UserId;
                                        existStatus.TimelineDate = DateTime.Now;
                                        existStatus.Update();
                                    }
                                    else
                                    {
                                        existStatus = new BOClientComplainTimeline();
                                        existStatus.ComplainId = exist.ComplainId;
                                        existStatus.ComplainStatusId = 2;
                                        existStatus.UserId = UserId;
                                        existStatus.TimelineDate = DateTime.Now;
                                        existStatus.SaveNew();
                                    }


                                }

                                if (exist.ComplainStatusId == 3)
                                {
                                    var existStatus = new Criteria<BOClientComplainTimeline>()
                                                .Add(Expression.Eq(nameof(BOClientComplainTimeline.ComplainId), exist.ComplainId))
                                                .Add(Expression.Eq(nameof(BOClientComplainTimeline.ComplainStatusId), 3))
                                                .FirstOrDefault<BOClientComplainTimeline>();

                                    if (existStatus != null)
                                    {


                                        existStatus.UserId = UserId;
                                        existStatus.TimelineDate = DateTime.Now;
                                        existStatus.Update();
                                    }
                                    else
                                    {
                                        existStatus = new BOClientComplainTimeline();
                                        existStatus.ComplainId = exist.ComplainId;
                                        existStatus.ComplainStatusId = 3;
                                        existStatus.UserId = UserId;
                                        existStatus.TimelineDate = DateTime.Now;
                                        existStatus.SaveNew();
                                    }
                                }

                                exist.Update();



                                // add Documents
                                exist.DeleteAllClientComplainDocument();
                                if (model.Documents != null)
                                {
                                    foreach (var item in model.Documents)
                                    {
                                        var boD = new BOClientComplainDocument();

                                        boD.ComplainId = exist.ComplainId;
                                        boD.DocumentPath = item.DocumentPath.Replace(_configuration["filesUrl"], "");
                                        boD.UploadDate = DateTime.Now;
                                        boD.DocumentExt = System.IO.Path.GetExtension(boD.DocumentPath);
                                        boD.DocumentSize = item.DocumentSize;

                                        boD.SaveNew();
                                    }
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
        public async Task<IActionResult> delete(ClientComplainModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientComplainModel> responseModel = new ResponseModel<ClientComplainModel>();

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
                        var exist = new Criteria<BOClientComplain>()
                                        .Add(Expression.Eq(nameof(model.ComplainId), model.ComplainId))
                                        .FirstOrDefault<BOClientComplain>();


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
                ResponseModel<ClientComplainModel> responseModel = new ResponseModel<ClientComplainModel>();

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

                        var exist = new Criteria<BOClientComplain>()
                                       .Add(Expression.Eq(nameof(BOClientComplain.ComplainId),Id))
                                       .FirstOrDefault<BOClientComplain>();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<ClientComplainModel>(exist);
                            responseModel.Data.Documents = new Criteria<BOClientComplainDocumentVw>()
                                                                .Add(Expression.Eq(nameof(BOClientComplainDocumentVw.ComplainId), Id))
                                                                .List<BOClientComplainDocumentVw>()
                                                                .Select(a => new ClientComplainDocumentListModel()
                                                                {
                                                                    ComplainId = a.ComplainId,
                                                                    ComplainDocumentId = a.ComplainDocumentId.Value,
                                                                    DocumentExt = a.DocumentExt,
                                                                    DocumentPath = _configuration["filesUrl"] + a.DocumentPath,
                                                                    DocumentSize = a.DocumentSize,
                                                                    UploadDate = a.UploadDate
                                                                }).ToList();

                            var Timlines = new Criteria<BOClientComplainTimelineVw>()
                                                               .Add(Expression.Eq(nameof(BOClientComplainTimelineVw.ComplainId), Id))
                                                               .List<BOClientComplainTimelineVw>()
                                                               .Select(a => new ClientComplainTimelineListModel()
                                                               {
                                                                   ComplainId = a.ComplainId,
                                                                   ComplainStatusId = a.ComplainStatusId,
                                                                   Notes = a.Notes,
                                                                   TimelineDate = a.TimelineDate,
                                                                   TimelineId = a.TimelineId.Value,
                                                                   UserId = a.UserId,
                                                                   UserName = new BOAppUser(a.UserId.Value).RealName,
                                                                   ComplainStatusName = Language == "ar" ? a.ComplainStatusNameAr : a.ComplainStatusNameEn,

                                                               }).ToList();


                            var allTime = BOComplainStatus.ComplainStatusCollection();

                            foreach (var item in allTime)
                            {
                                var found = Timlines.Where(a => a.ComplainStatusId == item.ComplainStatusId).FirstOrDefault();
                                if (found == null)
                                {
                                    responseModel.Data.TimeLine.Add(new ClientComplainTimelineListModel()
                                    {
                                        ComplainStatusId = item.ComplainStatusId,
                                        Notes = "",
                                        TimelineDate = null,
                                        TimelineId = 0,
                                        UserId = 0,
                                        UserName = "",
                                        ComplainStatusName = Language == "ar" ? item.ComplainStatusNameAr : item.ComplainStatusNameEn,
                                    });
                                }
                                else
                                {
                                    responseModel.Data.TimeLine.Add(found);
                                }

                            }

                            responseModel.Data.TimeLine=responseModel.Data.TimeLine.OrderBy(a => a.ComplainStatusId).ToList();


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
        public async Task<IActionResult> export(ClientComplainSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BOClientComplainVw>();


                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainCode), model.Term));
                }

                // branch Permissions

                // get by model

                if (model.RepresentativeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.RepresentativeId), model.RepresentativeId));


                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.BranchId), model.BranchId));

                if (model.ClientId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ClientId), model.ClientId));

                if (model.ComplainStatusId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainStatusId), model.ComplainStatusId));

                if (model.ComplainTypeDetailId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainTypeDetailId), model.ComplainTypeDetailId));


                if (!string.IsNullOrEmpty(model.Phone))
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.Phone), model.Phone));

                if (model.ComplainTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainTypeId), model.ComplainTypeId));

                if (model.DepartmentId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.DepartmentId), model.DepartmentId));

                if (model.PriorityId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.PriorityId), model.PriorityId));

                if (model.IsClosed > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.IsClosed), model.IsClosed == 1 ? true : false));


                if (model.ComplainDate != null && model.ComplainDate.Value.Year > 1900)
                    ctr.Add(Expression.Eq(nameof(BOClientComplainVw.ComplainDate), model.ComplainDate, dateformatter));

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
                        case "complainStatusName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("complainStatusName{0}", Language)) : OrderBy.Desc(string.Format("complainStatusName{0}", Language)));
                            break;
                        case "complainTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("complainTypeName{0}", Language)) : OrderBy.Desc(string.Format("complainTypeName{0}", Language)));
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
                    ctr.Add(OrderBy.Desc(nameof(BOClientComplainVw.ComplainId)));
                }
                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr
                             .List<BOClientComplainVw>()
                             .Select(a => new ClientComplainListModel()
                             {

                                 ComplainId = a.ComplainId.Value,
                                 PriorityId = a.PriorityId,
                                 Phone = a.Phone,
                                 ComplainTypeId = a.ComplainTypeId,
                                 DepartmentId = a.DepartmentId,
                                 ComplainStatusId = a.ComplainStatusId,
                                 BranchId = a.BranchId,
                                 ClientCode = a.ClientCode,
                                 ClientId = a.ClientId,
                                 ComplainTypeDetailId = a.ComplainTypeDetailId,
                                 Duration = a.Duration,
                                 IsClosed = a.IsClosed,
                                 BranchCode = a.BranchCode,
                                 CloseDate = a.CloseDate,
                                 ComplainCode = a.ComplainCode,
                                 ComplainDate = a.ComplainDate,
                                 RepresentativeCode = a.RepresentativeCode,
                                 RepresentativeId = a.RepresentativeId,
                                 ComplainTime = a.ComplainTime,

                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                 ComplainStatusName = Language == "ar" ? a.ComplainStatusNameAr : a.ComplainStatusNameEn,
                                 ComplainTypeName = Language == "ar" ? a.ComplainTypeNameAr : a.ComplainTypeNameEn,
                                 DepartmentName = Language == "ar" ? a.DepartmentNameAr : a.DepartmentNameEn,
                                 PriorityName = Language == "ar" ? a.PriorityNameAr : a.PriorityNameEn,
                                 RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,

                             }).ToList();


                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "ComplainCode";
                        worksheet.Cell("B1").Value = "ComplainDate";
                        worksheet.Cell("C1").Value = "RepresentativeCode";
                        worksheet.Cell("D1").Value = "RepresentativeName";
                        worksheet.Cell("E1").Value = "ClientCode";
                        worksheet.Cell("F1").Value = "ClientName";
                        worksheet.Cell("G1").Value = "Phone";
                        worksheet.Cell("H1").Value = "IsClosed";
                        worksheet.Cell("I1").Value = "CloseDate";
                        worksheet.Cell("J1").Value = "Duration";
                        worksheet.Cell("K1").Value = "DepartmentName";
                        worksheet.Cell("L1").Value = "ComplainTypeName";
                        worksheet.Cell("M1").Value = "ComplainStatusName";



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
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].ComplainCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ComplainDate;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].RepresentativeCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].RepresentativeName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].Phone;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].IsClosed;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].CloseDate;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].Duration;
                            worksheet.Cell(string.Format("K{0}", i + 2)).Value = res[i].DepartmentName;
                            worksheet.Cell(string.Format("L{0}", i + 2)).Value = res[i].ComplainTypeName;
                            worksheet.Cell(string.Format("M{0}", i + 2)).Value = res[i].ComplainStatusName;


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
