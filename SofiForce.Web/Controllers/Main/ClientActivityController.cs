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
using Helpers;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class ClientActivityController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IClientPlanManager _IClientPlanManager;
        private readonly IMapper _mapper;

        public ClientActivityController(IClientPlanManager IClientPlanManager, IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            this._env = env;
            this._configuration = configuration;
            this._IClientPlanManager = IClientPlanManager;
            this._mapper = mapper;

        }


        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientActivitySearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientActivityListModel>> responseModel = new ResponseModel<List<ClientActivityListModel>>();

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


                        var ctr = new Criteria<BOClientActivityVw>();

                        if(FullDataAccess==false)
                            ctr.Add(Expression.In(nameof(BOClientActivityVw.BranchId), Branchs));

                        // get by model

                        if (model.RepresentativeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientActivityVw.RepresentativeId), model.RepresentativeId));


                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientActivityVw.BranchId), model.BranchId));

                        if (model.ClientId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientActivityVw.ClientId), model.ClientId));

                        if (model.InZone > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientActivityVw.InZone), model.InZone==1 ? true:false));

                        if (model.InJourney > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientActivityVw.InJourney), model.InJourney == 1 ? true : false));

                        if (model.IsPositive > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientActivityVw.IsPositive), model.IsPositive == 1 ? true : false));

                        if (model.ActivityTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientActivityVw.ActivityTypeId), model.ActivityTypeId));



                        if (model.ActivityTimeFrom != null && model.ActivityTimeFrom.Value.Year > 1900)
                            ctr.Add(Expression.Gte(nameof(BOClientActivityVw.ActivityDate), model.ActivityTimeFrom.Value.Date, dateformatter));

                        if (model.ActivityTimeTo != null && model.ActivityTimeTo.Value.Year > 1900)
                            ctr.Add(Expression.Lte(nameof(BOClientActivityVw.ActivityDate), model.ActivityTimeTo.Value.Date, dateformatter));



                        if (model.CallAgainFrom != null && model.CallAgainFrom.Value.Year > 1900)
                            ctr.Add(Expression.Gte(nameof(BOClientActivityVw.CallAgain), model.CallAgainFrom.Value.Date, dateformatter));

                        if (model.CallAgainTo != null && model.CallAgainTo.Value.Year > 1900)
                            ctr.Add(Expression.Lte(nameof(BOClientActivityVw.CallAgain), model.CallAgainTo.Value.Date, dateformatter));


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
                            ctr.Add(OrderBy.Desc(nameof(BOClientActivityVw.ActivityId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOClientActivityVw>()
                                     .Select(a => new ClientActivityListModel()
                                     {

                                         ActivityId = a.ActivityId.Value,
                                         ActivityDate = a.ActivityDate,
                                         ActivityTime = a.ActivityTime,
                                         ActivityTypeId = a.ActivityTypeId,
                                         BranchCode = a.BranchCode,
                                         BranchId = a.BranchId,
                                         ClientCode = a.ClientCode,
                                         ClientId = a.ClientId,
                                         Distance = a.Distance,
                                         Duration = a.Duration,
                                         InJourney = a.InJourney,
                                         IsPositive = a.IsPositive,
                                         Latitude = a.Latitude,
                                         Longitude = a.Longitude,
                                         RepresentativeCode = a.RepresentativeCode,
                                         RepresentativeId = a.RepresentativeId,
                                         SalesId = a.SalesId,
                                         CallAgain = a.CallAgain,
                                         InZone=a.InZone,

                                         BranchName=Language=="ar"?a.BranchNameAr:a.BranchNameEn,
                                         ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
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
        [HttpPost("Save")]
        public async Task<IActionResult> Save(ClientActivityModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientActivityModel> responseModel = new ResponseModel<ClientActivityModel>();

                if (model == null)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else if (model.Valid() == false)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
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


        [CheckAuthorizedAttribute]
        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientActivityModel> responseModel = new ResponseModel<ClientActivityModel>();

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

                        var exist = new Criteria<BOClientActivity>()
                                       .Add(Expression.Eq(nameof(BOClientActivity.ActivityId), Id))
                                       .FirstOrDefault<BOClientActivity>();

                        if (exist != null)
                        {
                            // update current
                            responseModel.Data = _mapper.Map<ClientActivityModel>(exist);
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
        public async Task<IActionResult> export(ClientActivitySearchModel model)
        {
            try
            {


                var ctr = new Criteria<BOClientActivityVw>();

                if (FullDataAccess == false)
                    ctr.Add(Expression.In(nameof(BOClientActivityVw.BranchId), Branchs));

                // get by model

                if (model.RepresentativeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientActivityVw.RepresentativeId), model.RepresentativeId));


                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientActivityVw.BranchId), model.BranchId));

                if (model.ClientId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientActivityVw.ClientId), model.ClientId));

                if (model.InZone > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientActivityVw.InZone), model.InZone == 1 ? true : false));

                if (model.InJourney > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientActivityVw.InJourney), model.InJourney == 1 ? true : false));

                if (model.IsPositive > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientActivityVw.IsPositive), model.IsPositive == 1 ? true : false));

                if (model.ActivityTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientActivityVw.ActivityTypeId), model.ActivityTypeId));



                if (model.ActivityTimeFrom != null && model.ActivityTimeFrom.Value.Year > 1900)
                    ctr.Add(Expression.Gte(nameof(BOClientActivityVw.ActivityDate), model.ActivityTimeFrom.Value.Date, dateformatter));

                if (model.ActivityTimeTo != null && model.ActivityTimeTo.Value.Year > 1900)
                    ctr.Add(Expression.Lte(nameof(BOClientActivityVw.ActivityDate), model.ActivityTimeTo.Value.Date, dateformatter));



                if (model.CallAgainFrom != null && model.CallAgainFrom.Value.Year > 1900)
                    ctr.Add(Expression.Gte(nameof(BOClientActivityVw.CallAgain), model.CallAgainFrom.Value.Date, dateformatter));

                if (model.CallAgainTo != null && model.CallAgainTo.Value.Year > 1900)
                    ctr.Add(Expression.Lte(nameof(BOClientActivityVw.CallAgain), model.CallAgainTo.Value.Date, dateformatter));


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
                    ctr.Add(OrderBy.Desc(nameof(BOClientActivityVw.ActivityId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOClientActivityVw>()
                             .Select(a => new ClientActivityListModel()
                             {

                                 ActivityId = a.ActivityId.Value,
                                 ActivityDate = a.ActivityDate,
                                 ActivityTime = a.ActivityTime,
                                 ActivityTypeId = a.ActivityTypeId,
                                 BranchCode = a.BranchCode,
                                 BranchId = a.BranchId,
                                 ClientCode = a.ClientCode,
                                 ClientId = a.ClientId,
                                 Distance = a.Distance,
                                 Duration = a.Duration,
                                 InJourney = a.InJourney,
                                 IsPositive = a.IsPositive,
                                 Latitude = a.Latitude,
                                 Longitude = a.Longitude,
                                 RepresentativeCode = a.RepresentativeCode,
                                 RepresentativeId = a.RepresentativeId,
                                 SalesId = a.SalesId,
                                 CallAgain = a.CallAgain,
                                 InZone = a.InZone,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                 RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,

                             }).ToList();

                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "BranchCode";
                        worksheet.Cell("B1").Value = "ClientCode";
                        worksheet.Cell("C1").Value = "RepresentativeCode";
                        worksheet.Cell("D1").Value = "BranchName";
                        worksheet.Cell("E1").Value = "ClientName";
                        worksheet.Cell("F1").Value = "RepresentativeName";
                        worksheet.Cell("G1").Value = "IsPositive";
                        worksheet.Cell("H1").Value = "InJourney";
                        worksheet.Cell("I1").Value = "ActivityTime";

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

                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].RepresentativeCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].RepresentativeName;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].IsPositive;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].InJourney;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].ActivityTime;

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
