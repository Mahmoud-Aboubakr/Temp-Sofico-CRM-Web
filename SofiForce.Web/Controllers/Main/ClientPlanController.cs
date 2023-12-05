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
    public class ClientPlanController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IClientPlanManager _IClientPlanManager;
        private readonly IMapper _mapper;

        public ClientPlanController(IClientPlanManager IClientPlanManager, IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            this._env = env;
            this._configuration = configuration;
            this._IClientPlanManager = IClientPlanManager;
            this._mapper = mapper;

        }

        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientPlanSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientPlanListModel>> responseModel = new ResponseModel<List<ClientPlanListModel>>();

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

                        if (model.Take == 0) model.Take = 30;

                        var ctr = new Criteria<BOClientPlanVw>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOClientPlanVw.ClientCode), model.Term));
                        }

                        // branch Permissions


                        // get by model

                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientPlanVw.BranchId), model.BranchId));
                        if (model.ClientId > 0)
                            ctr.Add(Expression.Eq(nameof(BOClientPlanVw.ClientId), model.ClientId));

                        if (model.FromDate!=null && model.ToDate != null)
                        {
                            if (model.FromDate.Value.Year == model.ToDate.Value.Year)
                            {
                                if (model.FromDate.Value.Month == model.ToDate.Value.Month)
                                {
                                    ctr.Add(Expression.Gte(nameof(BOClientPlanVw.TargetDate), model.FromDate,dateformatter));
                                    ctr.Add(Expression.Lte(nameof(BOClientPlanVw.TargetDate), model.ToDate,dateformatter));

                                }
                                else
                                {
                                    ctr.Add(Expression.Eq(nameof(BOClientPlanVw.ClientId), 0));
                                }
                            }
                            else
                            {
                                ctr.Add(Expression.Eq(nameof(BOClientPlanVw.ClientId), 0));
                            }
                        }
                        else
                        {
                            ctr.Add(Expression.Eq(nameof(BOClientPlanVw.ClientId), 0));
                        }
                        

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
                            ctr.Add(OrderBy.Asc(nameof(BOClientPlanVw.ClientId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0?model.Take:30)
                                     .List<BOClientPlanVw>()
                                     .Select(a => new ClientPlanListModel()
                                     {
                                         CreditLimit = a.CreditLimit,
                                         CreditBalance = a.CreditBalance,
                                         ClientCode = a.ClientCode,
                                         BranchId = a.BranchId,
                                         BranchCode = a.BranchCode,
                                         ClientId = a.ClientId,
                                         TargetDate=a.TargetDate,
                                         ClientGroupId = a.ClientGroupId,
                                         ClientGroupCode = a.ClientGroupCode,
                                         PlanId = a.PlanId,
                                         TargetCall = a.TargetCall,
                                         TargetValue = a.TargetValue,
                                         TargetVisit = a.TargetVisit,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                         ClientGroupName = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn,


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
        [HttpPost("create")]
        public async Task<IActionResult> create(ClientPlanUploadModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientPlanUploadModel> responseModel = new ResponseModel<ClientPlanUploadModel>();

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

                                this._IClientPlanManager.Upload(result.Tables[0],UserId);
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
        [HttpPost("clear")]
        public async Task<IActionResult> clear(ClientPlanClearModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<ClientPlanClearModel> responseModel = new ResponseModel<ClientPlanClearModel>();

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

                        await this._IClientPlanManager.clear();

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


        [CheckAuthorizedAttribute]
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

                        worksheet.Cell("A1").Value = "ClientCode";
                        worksheet.Cell("B1").Value = "TargetValue";

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


    }
}
