using AutoMapper;
using ClosedXML.Excel;
using CSVFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using SofiForce.BusinessObjects;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
{
    [Route("api/[controller]")]
    public class ClientRequestController : BaseController
    {

        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ClientRequestController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }





        [HttpPost("save")]
        public async Task<IActionResult> save(ClientServiceRequestModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientServiceRequestModel> responseModel = new ResponseModel<ClientServiceRequestModel>();

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


    }
}
