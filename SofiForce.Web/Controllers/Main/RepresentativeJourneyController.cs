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
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class RepresentativeJourneyController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IJourneyPlanManager _JourneyPlanManager;
        private readonly IMapper _mapper;

        public RepresentativeJourneyController(IJourneyPlanManager JourneyPlanManager, IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            this._env = env;
            this._configuration = configuration;
            this._JourneyPlanManager = JourneyPlanManager;
            this._mapper = mapper;

        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(RepresentativeJourneySearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<RepresentativeJourneyListModel>> responseModel = new ResponseModel<List<RepresentativeJourneyListModel>>();

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


                        var ctr = new Criteria<BORepresentativeJourneyVw>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.RepresentativeCode), model.Term));
                        }

                        // branch Permissions


                        // get by model

                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.BranchId), model.BranchId));
                        if (model.RepresentativeId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.RepresentativeId), model.RepresentativeId));
                        if (model.SupervisorId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.SupervisorId), model.SupervisorId));
                        if (model.RouteId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.RouteId), model.RouteId));
                        if (model.KindId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.KindId), model.KindId));
                        if (model.RouteTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.RouteTypeId), model.RouteTypeId));
                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                               
                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "kindName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("kindName{0}", Language)) : OrderBy.Desc(string.Format("kindName{0}", Language)));
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
                            ctr.Add(OrderBy.Asc(nameof(BORepresentativeJourneyVw.RepresentativeCode)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BORepresentativeJourneyVw>()
                                     .Select(a => new RepresentativeJourneyListModel()
                                     {

                                         BranchCode = a.BranchCode,
                                         BranchId = a.BranchId,
                                         IsActive = a.IsActive,
                                         IsTerminated = a.IsTerminated,
                                         JourneyId = a.JourneyId,
                                         KindId = a.KindId,
                                         Phone = a.Phone,
                                         RouteCode = a.RouteCode,
                                         RepresentativeCode = a.RepresentativeCode,
                                         RouteId = a.RouteId,
                                         SupervisorId = a.SupervisorId,
                                         RepresentativeId = a.RepresentativeId,
                                         ReprestitiveUserId = a.ReprestitiveUserId,
                                         RouteTypeCode = a.RouteTypeCode,
                                         RouteTypeId = a.RouteTypeId,

                                         RouteTypeName= Language == "ar" ? a.RouteTypeNameAr : a.RouteTypeNameEn,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         KindName = Language == "ar" ? a.KindNameAr : a.KindNameEn,
                                         RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                         RouteName = Language == "ar" ? a.RouteNameAr : a.RouteNameEn,

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


        [HttpPost("create")]
        public async Task<IActionResult> create(UploadModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<UploadModel> responseModel = new ResponseModel<UploadModel>();

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

                        var _root = _configuration["files"];
                        var filePath = Path.Combine("wwwroot", _root, model.FilePath);

                        using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    UseColumnDataType = true,
                                    FilterSheet = (tableReader, sheetIndex) => true,
                                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                    {
                                        EmptyColumnNamePrefix = "Column",
                                        UseHeaderRow = true,
                                    }
                                });

                                this._JourneyPlanManager.Upload(result.Tables[0],UserId);
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


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(RepresentativeJourneyModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeJourneyModel> responseModel = new ResponseModel<RepresentativeJourneyModel>();

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

                        var exit = new Criteria<BORepresentativeJourney>()
                                .Add(Expression.Eq(nameof(BORepresentativeJourney.RepresentativeId), model.RepresentativeId))
                                .Add(Expression.Eq(nameof(BORepresentativeJourney.RouteId), model.RouteId))
                                .FirstOrDefault<BORepresentativeJourney>();

                        if (exit != null)
                        {
                             exit.Delete();
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

        [HttpPost("Add")]
        public async Task<IActionResult> Add(RepresentativeJourneyModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeJourneyModel> responseModel = new ResponseModel<RepresentativeJourneyModel>();

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

                        var exit = new Criteria<BORepresentativeJourney>()
                        .Add(Expression.Eq(nameof(BORepresentativeJourney.RepresentativeId), model.RepresentativeId))
                        .Add(Expression.Eq(nameof(BORepresentativeJourney.RouteId), model.RouteId))
                        .FirstOrDefault<BORepresentativeJourney>();
                        if (exit == null)
                        {
                            var rep = new BORepresentative(model.RepresentativeId.Value);
                            var route = new BORouteSetup(model.RouteId.Value);

                            if (rep.BranchId == route.BranchId)
                            {
                                exit = new BORepresentativeJourney();
                                exit.RouteId = model.RouteId;
                                exit.RepresentativeId = model.RepresentativeId;
                                
                                exit.CBy = UserId;
                                exit.CDate = DateTime.Now;
                                exit.SaveNew();
                                if (exit.JourneyId > 0)
                                {
                                    model.JourneyId = exit.JourneyId.Value;
                                }
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 503;
                            }

 
                        }


                        responseModel.Data = model;

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

        [HttpPost("clear")]
        public async Task<IActionResult> clear(JourneyClearModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<JourneyClearModel> responseModel = new ResponseModel<JourneyClearModel>();

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

                        await this._JourneyPlanManager.clear();

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
            await task.Result;

            return Ok(task.Result);
        }

        [HttpPost("duplicate")]
        public async Task<IActionResult> duplicate(JourneyDuplicateModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<JourneyDuplicateModel> responseModel = new ResponseModel<JourneyDuplicateModel>();

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

                        await this._JourneyPlanManager.duplicate(UserId,DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month);

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
            await task.Result;

            return Ok(task.Result);
        }


        [HttpPost("download")]
        public async Task<IActionResult> download(RepresentativeJourneySearchModel model)
        {

            try
            {


                var ctr = new Criteria<BORepresentativeJourneyVw>();


                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.RepresentativeCode), model.Term));
                }

                // branch Permissions


                // get by model


                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.BranchId), model.BranchId));
                if (model.RepresentativeId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.RepresentativeId), model.RepresentativeId));
                if (model.SupervisorId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.SupervisorId), model.SupervisorId));
                if (model.RouteId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.RouteId), model.RouteId));
                if (model.KindId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.KindId), model.KindId));
                if (model.RouteTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.RouteTypeId), model.RouteTypeId));


                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {
                    switch (model.SortBy.Property)
                    {

                        case "branchName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                            break;
                        case "kindName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("kindName{0}", Language)) : OrderBy.Desc(string.Format("kindName{0}", Language)));
                            break;
                        case "representativeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
                            break;
                        case "clientTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientTypeName{0}", Language)) : OrderBy.Desc(string.Format("clientTypeName{0}", Language)));
                            break;
                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }
                }
                else
                {
                    ctr.Add(OrderBy.Asc(nameof(BORepresentativeJourneyVw.RepresentativeCode)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BORepresentativeJourneyVw>()
                             .Select(a => new RepresentativeJourneyListModel()
                             {
                                 BranchCode = a.BranchCode,
                                 BranchId = a.BranchId,
                                 IsActive = a.IsActive,
                                 IsTerminated = a.IsTerminated,
                                 JourneyId = a.JourneyId,
                                 KindId = a.KindId,
                                 Phone = a.Phone,
                                 RouteCode = a.RouteCode,
                                 RepresentativeCode = a.RepresentativeCode,
                                 RouteId = a.RouteId,
                                 SupervisorId = a.SupervisorId,
                                 RepresentativeId = a.RepresentativeId,
                                 ReprestitiveUserId = a.ReprestitiveUserId,


                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 KindName = Language == "ar" ? a.KindNameAr : a.KindNameEn,
                                 RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                 RouteName = Language == "ar" ? a.RouteNameAr : a.RouteNameEn,
                                 


                             }).ToList();




                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "BranchCode";
                        worksheet.Cell("B1").Value = "BranchName";
                        worksheet.Cell("C1").Value = "RouteCode";
                        worksheet.Cell("D1").Value = "RepresentativeCode";
                        worksheet.Cell("E1").Value = "RepresentativeName";


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



                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].RouteCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].RepresentativeCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].RepresentativeName;


                        }

                        workbook.SaveAs(stream);
                        stream.Seek(0, SeekOrigin.Begin);

                        return this.File(
                            fileContents: stream.ToArray(),
                            contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",

                            // By setting a file download name the framework will
                            // automatically add the attachment Content-Disposition header
                            fileDownloadName: "J_Data.xlsx"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("template")]
        public async Task<IActionResult> template()
        {

            try
            {


               

                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "RepresentativeCode";
                        worksheet.Cell("B1").Value = "RouteCode";


                        worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("A1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("B1").Style.Font.FontColor = XLColor.White;





                        workbook.SaveAs(stream);
                        stream.Seek(0, SeekOrigin.Begin);

                        return this.File(
                            fileContents: stream.ToArray(),
                            contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",

                            // By setting a file download name the framework will
                            // automatically add the attachment Content-Disposition header
                            fileDownloadName: "J_Template.xlsx"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet("getByRepresentative")]
        public async Task<IActionResult> getByRepresentative(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<RepresentativeJourneyListModel>> responseModel = new ResponseModel<List<RepresentativeJourneyListModel>>();

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

                        var ctr = new Criteria<BORepresentativeJourneyVw>();


                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BORepresentativeJourneyVw.BranchId), this.Branchs));

                        ctr.Add(Expression.Eq(nameof(BORepresentativeJourneyVw.RepresentativeId), Id));


                        // get paged
                        responseModel.Total = ctr.Count();
                        responseModel.Data = ctr.List<BORepresentativeJourneyVw>()
                                     .Select(a => new RepresentativeJourneyListModel()
                                     {
                                         BranchCode = a.BranchCode,
                                         BranchId = a.BranchId,
                                         IsActive = a.IsActive,
                                         IsTerminated = a.IsTerminated,
                                         JourneyId = a.JourneyId,
                                         KindId = a.KindId,
                                         Phone = a.Phone,
                                         RouteCode = a.RouteCode,
                                         RepresentativeCode = a.RepresentativeCode,
                                         RouteId = a.RouteId,
                                         SupervisorId = a.SupervisorId,
                                         RepresentativeId = a.RepresentativeId,
                                         ReprestitiveUserId = a.ReprestitiveUserId,
                                         RouteTypeCode = a.RouteTypeCode,
                                         RouteTypeId = a.RouteTypeId,

                                         RouteTypeName = Language == "ar" ? a.RouteTypeNameAr : a.RouteTypeNameEn,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         KindName = Language == "ar" ? a.KindNameAr : a.KindNameEn,
                                         RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                         RouteName = Language == "ar" ? a.RouteNameAr : a.RouteNameEn,


                                     }).ToList();


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
