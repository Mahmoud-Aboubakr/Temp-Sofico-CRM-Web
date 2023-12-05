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
    public class ClientComplainController : BaseController
    {

        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ClientComplainController(IHttpContextAccessor contextAccessor,  IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }





        [HttpPost("save")]
        public async Task<IActionResult> save(ClientComplainModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientComplainModel> responseModel = new ResponseModel<ClientComplainModel>();

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


        

    }
}
