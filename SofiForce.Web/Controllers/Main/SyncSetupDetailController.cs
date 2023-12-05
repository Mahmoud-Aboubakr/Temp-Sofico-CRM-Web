using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class SyncSetupDetailController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public SyncSetupDetailController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(SyncSetupDetailSearchModel searchModel)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SyncSetupDetailModel>> responseModel = new ResponseModel<List<SyncSetupDetailModel>>();

                try
                {
                    var ctr = new Criteria<BOSyncSetupDetail>();

                    ctr.Add(Expression.Eq(nameof(BOSyncSetupDetail.UserId), UserId));
                    ctr.Add(Expression.Eq(nameof(BOSyncSetupDetail.SetupId), searchModel.SetupId));


                    // sort by 
                    if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                    {
                        switch (searchModel.SortBy.Property)
                        {

                            default:
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                                break;
                        }
                    }
                    else
                    {
                        ctr.Add(OrderBy.Desc(nameof(BOSyncSetupDetail.DetailId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.List<BOSyncSetupDetail>().Select(a => new SyncSetupDetailModel()
                                 {
                                     DetailId = a.DetailId, 
                                     SetupId = a.SetupId,
                                     UserId = a.UserId,
                                     IsDone = a.IsDone,
                                     Message = a.Message,
                                     Payload1 = a.Payload1,
                                     Payload2 = a.Payload2,
                                     Payload3 = a.Payload3,
                                     Payload4 = a.Payload4,
                                     SyncDate=a.SyncDate,

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

        [HttpPost("save")]
        public async Task<IActionResult> save(SyncSetupDetailModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SyncSetupDetailModel> responseModel = new ResponseModel<SyncSetupDetailModel>();

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
                        var exist = new Criteria<BOSyncSetupDetail>()
                                        .Add(Expression.Eq(nameof(model.DetailId), model.DetailId))
                                        .FirstOrDefault<BOSyncSetupDetail>();


                        if (exist == null)
                        {



                            // create new
                            exist = new BOSyncSetupDetail();
                            exist.SetupId=model.SetupId;
                            exist.UserId = UserId;
                            exist.SyncDate = null;
                            exist.Payload1=model.Payload1;
                            exist.Payload2 = model.Payload2;
                            exist.Payload3 = model.Payload3;
                            exist.Payload4 = model.Payload4;
                            exist.IsDone = false;
                            exist.Message = String.Empty;
                            

                            

                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;


                            exist.SaveNew();

                            if (exist.DetailId > 0)
                            {
                                model.DetailId = exist.DetailId.Value;
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                            }

                        }
                        else
                        {
                            exist.Payload1 = model.Payload1;
                            exist.Payload2 = model.Payload2;
                            exist.Payload3 = model.Payload3;
                            exist.Payload4 = model.Payload4;
                            exist.EBy = UserId;
                            exist.EDate = DateTime.Now;

                            if (exist.IsDone ==false)
                            {
                                exist.Update();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
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

        [HttpPost("delete")]
        public async Task<IActionResult> delete(SyncSetupDetailModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SyncSetupDetailModel> responseModel = new ResponseModel<SyncSetupDetailModel>();

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
                        var exist = new Criteria<BOSyncSetupDetail>()
                                        .Add(Expression.Eq(nameof(model.DetailId), model.DetailId))
                                        .FirstOrDefault<BOSyncSetupDetail>();


                        if (exist != null)
                        {

                            if (exist.IsDone == false)
                            {
                                exist.Delete();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                            }


                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
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
    }
}
