using AutoMapper;
using ClosedXML.Excel;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
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
    public class ClientRouteController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IClientRouteManager _IClientRouteManager;
        private readonly IMapper _mapper;

        public ClientRouteController(IClientRouteManager clientRouteManager, IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            this._env = env;
            this._configuration = configuration;
            this._IClientRouteManager = clientRouteManager;
            this._mapper = mapper;

        }


        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientRouteSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientRouteListModel>> responseModel = new ResponseModel<List<ClientRouteListModel>>();

                try
                {
                    var ctr = new Criteria<BOClientRouteVw>();

                    // get by term
                    if (!string.IsNullOrEmpty(model.Term))
                    {

                        if (!string.IsNullOrEmpty(model.TermBy))
                        {
                            switch (model.TermBy)
                            {
                                case "clientCode":
                                    ctr.Add(Expression.Eq(nameof(BOClientRouteVw.ClientCode), model.Term));
                                    break;
                                case "clientName":
                                    ctr.Add(Expression.StartWith(Language == "ar" ? nameof(BOClientRouteVw.ClientNameAr) : nameof(BOClientRouteVw.ClientNameEn), model.Term));

                                    break;
                                case "routeCode":
                                    ctr.Add(Expression.Eq(nameof(BOClientRouteVw.RouteCode), model.Term));
                                    break;
                                case "routeName":
                                    ctr.Add(Expression.StartWith(Language=="ar"? nameof(BOClientRouteVw.RouteNameAr): nameof(BOClientRouteVw.RouteNameEn), model.Term));
                                    break;
                                case "branchCode":
                                    ctr.Add(Expression.Eq(nameof(BOClientRouteVw.BranchCode), model.Term));
                                    break;
                                case "branchName":
                                    ctr.Add(Expression.EndWith(Language == "ar" ? nameof(BOClientRouteVw.BranchNameAr) : nameof(BOClientRouteVw.BranchNameEn), model.Term));
                                    break;
                                default:
                                    break;
                            }
                        }

                    }

                    if (FullDataAccess == false)
                    {
                        ctr.Add(Expression.In(nameof(BOClientRouteVw.BranchId), Branchs));

                    }

                    if (model.RouteTypeId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientRouteVw.RouteTypeId), model.RouteTypeId));

                    if (model.ClientId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientRouteVw.ClientId), model.ClientId));

                    if (model.RouteId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientRouteVw.RouteId), model.RouteId));

                    if (model.BranchId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientRouteVw.BranchId), model.BranchId));

                   

                    // sort by 
                    if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                    {
                        switch (model.SortBy.Property)
                        {
                            case "routeName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("routeName{0}", Language)) : OrderBy.Desc(string.Format("routeName{0}", Language)));
                                break;
                            case "routeTypeName":
                                ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("routeTypeName{0}", Language)) : OrderBy.Desc(string.Format("routeTypeName{0}", Language)));
                                break;
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
                        ctr.Add(OrderBy.Desc(nameof(BOClientRouteVw.RouteId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(model.Skip)
                                 .Take(model.Take > 0 ? model.Take : 30)
                                 .List<BOClientRouteVw>().Select(a => new ClientRouteListModel()
                                 {
                                     ClientId = a.ClientId,
                                     ClientRouteId = a.ClientRouteId,
                                     RouteCode = a.RouteCode,
                                     RouteId = a.RouteId,
                                     RouteTypeId = a.RouteTypeId,
                                     RouteTypeCode = a.RouteTypeCode,

                                     BranchId=a.BranchId,
                                     BranchCode=a.BranchCode,
                                     ClientCode=a.ClientCode,
                                     IsActive=a.IsActive,

                                     Day1 = a.Day1 != null ? a.Day1.Value : false,
                                     Day2 = a.Day2 != null ? a.Day2.Value : false,
                                     Day3 = a.Day3 != null ? a.Day3.Value : false,
                                     Day4 = a.Day4 != null ? a.Day4.Value : false,
                                     Day5 = a.Day5 != null ? a.Day5.Value : false,
                                     Day6 = a.Day6 != null ? a.Day6.Value : false,
                                     Day7 = a.Day7 != null ? a.Day7.Value : false,

                                     RouteName = Language == "ar" ? a.RouteNameAr : a.RouteNameEn,
                                     RouteTypeName = Language == "ar" ? a.RouteTypeNameAr : a.RouteTypeNameEn,
                                     BranchName= Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                     ClientName= Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                     

                                 }).ToList();



                    responseModel.Data = res;
                    responseModel.Total = Total;
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


        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientRouteListModel>> responseModel = new ResponseModel<List<ClientRouteListModel>>();

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

                        responseModel.Data = new Criteria<BOClientRouteVw>()
                                       .Add(Expression.Eq(nameof(BOClientRouteVw.ClientId), Id))
                                       .List<BOClientRouteVw>()
                                       .Select(a=> new ClientRouteListModel()
                                       {
                                           ClientId = a.ClientId,
                                           ClientRouteId = a.ClientRouteId,
                                           RouteCode = a.RouteCode,
                                           RouteId = a.RouteId,
                                           RouteTypeId = a.RouteTypeId,
                                           RouteTypeCode = a.RouteTypeCode,

                                           BranchId = a.BranchId,
                                           BranchCode = a.BranchCode,
                                           ClientCode = a.ClientCode,
                                           IsActive = a.IsActive,

                                           Day1 = a.Day1 != null ? a.Day1.Value : false,
                                           Day2 = a.Day2 != null ? a.Day2.Value : false,
                                           Day3 = a.Day3 != null ? a.Day3.Value : false,
                                           Day4 = a.Day4 != null ? a.Day4.Value : false,
                                           Day5 = a.Day5 != null ? a.Day5.Value : false,
                                           Day6 = a.Day6 != null ? a.Day6.Value : false,
                                           Day7 = a.Day7 != null ? a.Day7.Value : false,

                                           RouteName = Language == "ar" ? a.RouteNameAr : a.RouteNameEn,
                                           RouteTypeName = Language == "ar" ? a.RouteTypeNameAr : a.RouteTypeNameEn,
                                           BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                           ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,

                                       } ).ToList();

                        

                        responseModel.Total = responseModel.Data.Count;
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



        [HttpPost("save")]
        public async Task<IActionResult> save(ClientRouteModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientRouteModel> responseModel = new ResponseModel<ClientRouteModel>();

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
                        var exist = new Criteria<BOClientRoute>()
                                        .Add(Expression.Eq(nameof(model.ClientRouteId), model.ClientRouteId))
                                        .FirstOrDefault<BOClientRoute>();


                        if (exist != null)
                        {



                            // update current

                            exist.RouteTypeId = model.RouteTypeId;
                            exist.RouteId = model.RouteId;
                            exist.ClientId = model.ClientId;
                            exist.Day1 = model.Day1;
                            exist.Day2 = model.Day2;
                            exist.Day3 = model.Day3;
                            exist.Day4 = model.Day4;
                            exist.Day5 = model.Day5;
                            exist.Day6 = model.Day6;
                            exist.Day7 = model.Day7;

                            exist.EBy = UserId;
                            exist.EDate = DateTime.Now;


                            exist.Update();

   

                        }
                        else
                        {
                            // create new

                            exist = new BOClientRoute();
                            exist.RouteTypeId = model.RouteTypeId;
                            exist.RouteId = model.RouteId;
                            exist.ClientId = model.ClientId;
                            exist.Day1 = model.Day1;
                            exist.Day2 = model.Day2;
                            exist.Day3 = model.Day3;
                            exist.Day4 = model.Day4;
                            exist.Day5 = model.Day5;
                            exist.Day6 = model.Day6;
                            exist.Day7 = model.Day7;
                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();


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


        [HttpPost("delete")]
        public async Task<IActionResult> delete(ClientRouteModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientRouteModel> responseModel = new ResponseModel<ClientRouteModel>();

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
                        var exist = new Criteria<BOClientRoute>()
                                        .Add(Expression.Eq(nameof(model.ClientRouteId), model.ClientRouteId))
                                        .FirstOrDefault<BOClientRoute>();



                        if (exist != null)
                        {
                            exist.Delete();
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
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpPost("clear")]
        public async Task<IActionResult> clear(ClientRouteModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<ClientRouteModel> responseModel = new ResponseModel<ClientRouteModel>();

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

                        await this._IClientRouteManager.ClearAll();

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
            await task.Result;

            return Ok(task.Result);
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

                        worksheet.Cell("A1").Value = "ClientCode";
                        worksheet.Cell("B1").Value = "RouteCode";
                        worksheet.Cell("C1").Value = "Day1";
                        worksheet.Cell("D1").Value = "Day2";
                        worksheet.Cell("E1").Value = "Day3";
                        worksheet.Cell("F1").Value = "Day4";
                        worksheet.Cell("G1").Value = "Day5";
                        worksheet.Cell("H1").Value = "Day6";
                        worksheet.Cell("I1").Value = "Day7";

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


        [HttpPost("upload")]
        public async Task<IActionResult> upload(FileModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<FileModel> responseModel = new ResponseModel<FileModel>();

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
                        var filePath = Path.Combine("wwwroot", _root, model.FileUrl);

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

                                if(result!=null && result.Tables.Count>0 && result.Tables[0].Rows.Count > 0)
                                {
                                    this._IClientRouteManager.Upload(result.Tables[0], UserId);

                                }
                                else
                                {
                                    responseModel.Succeeded = false;
                                    responseModel.StatusCode = 500;
                                    responseModel.Message = Messages.Invalid_Model;
                                }
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


        [HttpPost("export")]
        public async Task<IActionResult> export(ClientRouteSearchModel model)
        {
            try
            {


                var ctr = new Criteria<BOClientRouteVw>();

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {

                    if (!string.IsNullOrEmpty(model.TermBy))
                    {
                        switch (model.TermBy)
                        {
                            case "clientCode":
                                ctr.Add(Expression.Eq(nameof(BOClientRouteVw.ClientCode), model.Term));
                                break;
                            case "clientName":
                                ctr.Add(Expression.StartWith(Language == "ar" ? nameof(BOClientRouteVw.ClientNameAr) : nameof(BOClientRouteVw.ClientNameEn), model.Term));

                                break;
                            case "routeCode":
                                ctr.Add(Expression.Eq(nameof(BOClientRouteVw.RouteCode), model.Term));
                                break;
                            case "routeName":
                                ctr.Add(Expression.StartWith(Language == "ar" ? nameof(BOClientRouteVw.RouteNameAr) : nameof(BOClientRouteVw.RouteNameEn), model.Term));
                                break;
                            case "branchCode":
                                ctr.Add(Expression.Eq(nameof(BOClientRouteVw.BranchCode), model.Term));
                                break;
                            case "branchName":
                                ctr.Add(Expression.EndWith(Language == "ar" ? nameof(BOClientRouteVw.BranchNameAr) : nameof(BOClientRouteVw.BranchNameEn), model.Term));
                                break;
                            default:
                                break;
                        }
                    }

                }

                if (FullDataAccess == false)
                {
                    ctr.Add(Expression.In(nameof(BOClientRouteVw.BranchId), Branchs));

                }

                if (model.RouteTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientRouteVw.RouteTypeId), model.RouteTypeId));

                if (model.ClientId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientRouteVw.ClientId), model.ClientId));

                if (model.RouteId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientRouteVw.RouteId), model.RouteId));

                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientRouteVw.BranchId), model.BranchId));



                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {
                    switch (model.SortBy.Property)
                    {
                        case "routeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("routeName{0}", Language)) : OrderBy.Desc(string.Format("routeName{0}", Language)));
                            break;
                        case "routeTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("routeTypeName{0}", Language)) : OrderBy.Desc(string.Format("routeTypeName{0}", Language)));
                            break;
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
                    ctr.Add(OrderBy.Desc(nameof(BOClientRouteVw.RouteId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOClientRouteVw>().Select(a => new ClientRouteListModel()
                             {
                                 ClientId = a.ClientId,
                                 ClientRouteId = a.ClientRouteId,
                                 RouteCode = a.RouteCode,
                                 RouteId = a.RouteId,
                                 RouteTypeId = a.RouteTypeId,
                                 RouteTypeCode = a.RouteTypeCode,

                                 BranchId = a.BranchId,
                                 BranchCode = a.BranchCode,
                                 ClientCode = a.ClientCode,
                                 IsActive = a.IsActive,

                                 Day1 = a.Day1 != null ? a.Day1.Value : false,
                                 Day2 = a.Day2 != null ? a.Day2.Value : false,
                                 Day3 = a.Day3 != null ? a.Day3.Value : false,
                                 Day4 = a.Day4 != null ? a.Day4.Value : false,
                                 Day5 = a.Day5 != null ? a.Day5.Value : false,
                                 Day6 = a.Day6 != null ? a.Day6.Value : false,
                                 Day7 = a.Day7 != null ? a.Day7.Value : false,

                                 RouteName = Language == "ar" ? a.RouteNameAr : a.RouteNameEn,
                                 RouteTypeName = Language == "ar" ? a.RouteTypeNameAr : a.RouteTypeNameEn,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,


                             }).ToList();

                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");







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

                        worksheet.Cell("N1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("N1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("O1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("O1").Style.Font.FontColor = XLColor.White;



                        worksheet.Cell("A1").Value = "BranchCode";
                        worksheet.Cell("B1").Value = "BranchName";
                        worksheet.Cell("C1").Value = "ClientCode";
                        worksheet.Cell("D1").Value = "ClientName";
                        worksheet.Cell("E1").Value = "IsActive";
                        worksheet.Cell("F1").Value = "RouteCode";
                        worksheet.Cell("G1").Value = "RouteName";
                        worksheet.Cell("H1").Value = "RouteTypeName";

                        worksheet.Cell("I1").Value = "Day1";
                        worksheet.Cell("J1").Value = "Day2";
                        worksheet.Cell("K1").Value = "Day3";
                        worksheet.Cell("L1").Value = "Day4";
                        worksheet.Cell("M1").Value = "Day5";
                        worksheet.Cell("N1").Value = "Day6";
                        worksheet.Cell("O1").Value = "Day7";

                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].IsActive;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].RouteCode;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].RouteName;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].RouteTypeName;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].Day1;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].Day2;
                            worksheet.Cell(string.Format("K{0}", i + 2)).Value = res[i].Day3;

                            worksheet.Cell(string.Format("L{0}", i + 2)).Value = res[i].Day4;
                            worksheet.Cell(string.Format("M{0}", i + 2)).Value = res[i].Day5;
                            worksheet.Cell(string.Format("N{0}", i + 2)).Value = res[i].Day6;
                            worksheet.Cell(string.Format("O{0}", i + 2)).Value = res[i].Day7;


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
