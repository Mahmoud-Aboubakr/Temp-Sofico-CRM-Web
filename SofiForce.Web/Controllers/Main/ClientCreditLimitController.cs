using AutoMapper;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using ExcelDataReader;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Models.Models.SearchModels;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class ClientCreditLimitController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ISalesLimitManager SalesLimitManager { get; }

        public ClientCreditLimitController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper, ISalesLimitManager salesLimitManager) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
            SalesLimitManager = salesLimitManager;
        }


        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientCreditLimitSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientCreditLimitListModel>> responseModel = new ResponseModel<List<ClientCreditLimitListModel>>();

                try
                {

                    int Total = 0;
                    responseModel.Data = GetData(model,out Total);
                    responseModel.Total= Total;
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message; ;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
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


                                // check file
                                if (result == null || result.Tables.Count > 2)
                                {

                                    responseModel.Succeeded = false;
                                    responseModel.Message = "Invalid file format";
                                    return responseModel;
                                }
                                if (result.Tables[0].Columns.Count > 4)
                                {

                                    responseModel.Succeeded = false;
                                    responseModel.Message = "Invalid file format";
                                    return responseModel;
                                }

                                if (result.Tables[0].Columns[0].ColumnName.ToLower() != "clientcode")
                                {

                                    responseModel.Succeeded = false;
                                    responseModel.Message = "Invalid file format";
                                    return responseModel;
                                }
                                if (result.Tables[0].Columns[1].ColumnName.ToLower() != "limityear")
                                {

                                    responseModel.Succeeded = false;
                                    responseModel.Message = "Invalid file format";
                                    return responseModel;
                                }
                                if (result.Tables[0].Columns[2].ColumnName.ToLower() != "limitmonth")
                                {

                                    responseModel.Succeeded = false;
                                    responseModel.Message = "Invalid file format";
                                    return responseModel;
                                }
                                if (result.Tables[0].Columns[3].ColumnName.ToLower() != "limitvalue")
                                {

                                    responseModel.Succeeded = false;
                                    responseModel.Message = "Invalid file format";
                                    return responseModel;
                                }


                                if (result.Tables[0].Rows.Count == 0)
                                {

                                    responseModel.Succeeded = false;
                                    responseModel.Message = "Empty file";
                                    return responseModel;
                                }


                                this.SalesLimitManager.Upload(result.Tables[0], UserId);
                            }
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


        [CheckAuthorizedAttribute]
        [HttpPost("download")]
        public async Task<IActionResult> download(ClientCreditLimitSearchModel model)
        {


            try
            {

                int Total = 0;
                model.Skip = 0;
                model.Take=int.MaxValue;

                var res= GetData(model, out Total);
     
                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "clientCode";
                        worksheet.Cell("B1").Value = "clientName";
                        worksheet.Cell("C1").Value = "BranchCode";
                        worksheet.Cell("D1").Value = "BranchName";
                        worksheet.Cell("E1").Value = "LimitYear";
                        worksheet.Cell("F1").Value = "LimitMonth";
                        worksheet.Cell("G1").Value = "LimitValue";

                       


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






                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].LimitYear;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].LimitMonth;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].LimitValue;
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


        [CheckAuthorizedAttribute]
        [HttpPost("deleteAll")]
        public async Task<IActionResult> deleteAll(ClientCreditLimitSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientCreditLimitSearchModel> responseModel = new ResponseModel<ClientCreditLimitSearchModel>();

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


                        this.SalesLimitManager.ClearMonth();

                        responseModel.Data = model;
                        responseModel.Total = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(ClientCreditLimitModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientCreditLimitModel> responseModel = new ResponseModel<ClientCreditLimitModel>();

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

                        var exit = new Criteria<BOClientCreditLimit>()
                                .Add(Expression.Eq(nameof(BOClientCreditLimit.LimitId), model.LimitId))
                                .FirstOrDefault<BOClientCreditLimit>();

                        if (exit != null)
                        {
                            if(exit.LimitMonth==DateTime.Now.Month && exit.LimitYear == DateTime.Now.Year)
                            {
                                exit.Delete();

                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Cannot_delete;
                            }
                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Cannot_delete;
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
                        worksheet.Cell("B1").Value = "LimitYear";
                        worksheet.Cell("C1").Value = "LimitMonth";
                        worksheet.Cell("D1").Value = "LimitValue";




                        worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("A1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("B1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("C1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("C1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("D1").Style.Font.FontColor = XLColor.White;


                      

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
        
        protected List<ClientCreditLimitListModel>  GetData(ClientCreditLimitSearchModel model,out int Total)
        {
            var ctr = new Criteria<BOClientCreditLimitVw>();



            // get by term
            if (!string.IsNullOrEmpty(model.Term))
            {
                ctr.Add(Expression.StartWith(nameof(BOClientCreditLimitVw.ClientCode), model.Term));

            }

            if (FullDataAccess == false)
            {
                ctr.Add(Expression.In(nameof(BOClientCreditLimitVw.BranchId), Branchs));


                if (this.AppRoleId == 6)
                {
                    // get By Suppervisor
                    var clients = new Criteria<BORepresentativeClientVw>()
                                .Add(Expression.Eq(nameof(BORepresentativeClientVw.SupervisorUserId), UserId))
                                .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

                    ctr.Add(Expression.InSubQuery(nameof(BOClientCreditLimitVw.ClientId), clients));
                }

                if (this.AppRoleId == 7)
                {
                    // get by Sales Rep

                    var clients = new Criteria<BORepresentativeClientVw>()
                           .Add(Expression.Eq(nameof(BORepresentativeClientVw.RepresentativeUserId), UserId))
                           .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

                    ctr.Add(Expression.InSubQuery(nameof(BOClientCreditLimitVw.ClientId), clients));

                }

            }


            if (model.ClientId > 0)
                ctr.Add(Expression.Eq(nameof(BOClientCreditLimitVw.ClientId), model.ClientId));

            if (model.BranchId > 0)
                ctr.Add(Expression.Eq(nameof(BOClientCreditLimitVw.BranchId), model.BranchId));

            
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

                    default:
                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                        break;
                }
            }
            else
            {
                ctr.Add(OrderBy.Asc(nameof(BOClientCreditLimitVw.LimitId)));
            }

            // get count

            Total = ctr.Count();

            // get paged

            return  ctr.Skip(model.Skip)
                         .Take(model.Take > 0 ? model.Take : 30)
                         .List<BOClientCreditLimitVw>().Select(a => new ClientCreditLimitListModel()
                         {
                             LimitId = a.LimitId,
                             ClientCode = a.ClientCode,
                             BranchCode = a.BranchCode,
                             BranchId = a.BranchId,
                             ClientId = a.ClientId,
                             LimitMonth = a.LimitMonth,
                             LimitValue = a.LimitValue,
                             LimitYear=a.LimitYear,
                             BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                             ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,


                         }).ToList();


        }
    }
}
