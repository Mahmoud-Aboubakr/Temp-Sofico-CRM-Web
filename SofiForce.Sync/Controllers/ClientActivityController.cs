using AutoMapper;
using ClosedXML.Excel;
using CSVFile;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;

using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
{
    [Route("api/[controller]")]
    public class ClientActivityController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        public ClientActivityController( IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            this._env = env;
            this._configuration = configuration;
            this._mapper = mapper;

        }



        [HttpPost("Save")]
        public async Task<IActionResult> Save(ClientActivityModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientActivityModel> responseModel = new ResponseModel<ClientActivityModel>();

                if (model == null)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";
                    responseModel.StatusCode = 503;

                }
                else if (model.Valid() == false)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";
                    responseModel.StatusCode = 503;
                }
                else
                {
                    try
                    {


                        var exit = new Criteria<BOClientActivity>()
                                    .Add(Expression.Eq(nameof(BOClientActivity.ActivityId), model.ActivityId))
                                    .FirstOrDefault<BOClientActivity>();


                        if (exit == null)
                        {
                            exit = new BOClientActivity();
                            exit.ClientId = model.ClientId;
                            exit.RepresentativeId = model.RepresentativeId;
                            exit.ActivityDate = model.ActivityDate;
                            exit.ActivityTime = model.ActivityTime;

                            if (exit.ActivityTypeId == 2)
                                exit.Duration = (int)(DateTime.Now - model.ActivityTime).Value.TotalSeconds;
                            else
                                exit.Duration = 0;


                            exit.InJourney = model.InJourney;
                            exit.IsPositive = model.IsPositive;
                            exit.InZone = model.InZone;
                            exit.ActivityTypeId = model.ActivityTypeId;
                            exit.Longitude = model.Longitude;
                            exit.Latitude = model.Latitude;
                            exit.Distance = model.Distance;
                            exit.SalesId = (long?)model.SalesId;
                            exit.Notes = model.Notes;
                            exit.CallAgain = model.CallAgain;
                            exit.CBy = UserId;
                            exit.CDate = DateTime.Now;
                            exit.SaveNew();


                            model.IsSynced = true;
                            model.SyncDate = DateTime.Now;

                        }


                        responseModel.Data = model;

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
