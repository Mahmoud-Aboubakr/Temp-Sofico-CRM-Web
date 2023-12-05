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
    public class OperationRequestController : BaseController
    {

        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public OperationRequestController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {

            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }



        [HttpPost("filter")]
        public async Task<IActionResult> filter(OperationRequestSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<OperationRequestListModel>> responseModel = new ResponseModel<List<OperationRequestListModel>>();

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


                        var ctr = new Criteria<BOOperationRequestVw>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestVw.OperationCode), model.Term));
                        }

                        // branch Permissions

                        // get by model

                        if (model.RepresentativeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestVw.RepresentativeId), model.RepresentativeId));


                        if (model.OperationTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestVw.OperationTypeId), model.OperationTypeId));

                        if (model.GovernerateId > 0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestVw.GovernerateId), model.GovernerateId));

                        if (model.IsClosed >0)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestVw.IsClosed), model.IsClosed==1?true:false));


                        if (model.OperationDate !=null && model.OperationDate.Value.Year>1900)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestVw.OperationDate), model.OperationDate,dateformatter));

                        if (model.StartDate != null && model.StartDate.Value.Year > 1900)
                            ctr.Add(Expression.Eq(nameof(BOOperationRequestVw.StartDate), model.StartDate, dateformatter));
                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "representativeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
                                    break;
                                case "operationTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("operationTypeName{0}", Language)) : OrderBy.Desc(string.Format("operationTypeName{0}", Language)));
                                    break;
                                case "governerateName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("governerateName{0}", Language)) : OrderBy.Desc(string.Format("governerateName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOOperationRequestVw.OperationId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOOperationRequestVw>()
                                     .Select(a=> new OperationRequestListModel()
                                     {


                                        OperationId = a.OperationId,
                                        AgentId = a.AgentId,
                                        IsClosed = a.IsClosed,
                                        CloseDate = a.CloseDate,
                                        OperationCode = a.OperationCode,
                                        OperationTypeId = a.OperationTypeId,
                                        Phone = a.Phone,
                                        RepresentativeCode = a.RepresentativeCode,
                                        RepresentativeId = a.RepresentativeId,
                                        StartDate = a.StartDate,
                                        TargetDays=a.TargetDays,
                                        MapPoints=a.MapPoints,
                                        MapPointList=JsonConvert.DeserializeObject<List<GeoPoint>>(a.MapPoints),
                                        Accuracy = a.Accuracy,
                                        ActualClients = a.ActualClients,
                                        ActualDays = a.ActualDays,
                                        ClientsPerformance = a.ClientsPerformance,
                                        DaysPerformance = a.DaysPerformance,
                                        OperationDate = a.OperationDate,
                                        TargetClients=a.TargetClients,
                                        GovernerateId=a.GovernerateId,

                                        GovernerateName= Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,
                                        RepresentativeName =Language=="ar" ?a.RepresentativeNameAr:a.RepresentativeNameEn,
                                        OperationTypeName=Language=="ar"?a.OperationTypeNameAr:a.OperationTypeNameEn,


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





    }
}
