using AutoMapper;
using ClosedXML.Excel;
using CSVFile;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
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
    public class OperationRequestController : BaseController
    {
        private readonly IOperationRequestManager operationRequestManager;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public OperationRequestController(IHttpContextAccessor contextAccessor, IOperationRequestManager operationRequestManager, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            this.operationRequestManager = operationRequestManager;
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }



        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(OperationRequestSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<OperationRequestListModel>> responseModel = new ResponseModel<List<OperationRequestListModel>>();

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


        [CheckAuthorizedAttribute]
        [HttpPost("save")]
        public async Task<IActionResult> save(OperationRequestModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<OperationRequestModel> responseModel = new ResponseModel<OperationRequestModel>();

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
                        var exist = new Criteria<BOOperationRequest>()
                                        .Add(Expression.Eq(nameof(model.OperationId), model.OperationId))
                                        .FirstOrDefault<BOOperationRequest>();


                        if (exist == null)
                        {



                            // create new
                            exist = new BOOperationRequest();

                            exist.AgentId = UserId;
                            exist.OperationTypeId = model.OperationTypeId;
                            exist.GovernerateId = model.GovernerateId;

                            exist.RepresentativeId = model.RepresentativeId;
                            exist.OperationDate = DateTime.Now;
                            exist.TargetDays = model.TargetDays;
                            exist.ActualDays = 0;

                            exist.TargetClients = 0;
                            exist.ActualClients = 0;
                            exist.DaysPerformance = 0;
                            exist.ClientsPerformance = 0;
                            exist.Accuracy = 0;

                            exist.MapPoints = model.MapPoints;
                            exist.IsClosed = false;
                            exist.CloseDate = null;

                            exist.Notes = model.Notes;

                            

                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;


                            exist.SaveNew();

                            if (exist.OperationId > 0)
                            {
                                if (model.OperationTypeId == 1)
                                {
                                    //scan
                                    exist.OperationCode = string.Format(_configuration["settings:prefix:scan"], exist.OperationId.Value.ToString().PadLeft(7, '0'));
                                }
                                else
                                {
                                    //validation
                                    exist.OperationCode = string.Format(_configuration["settings:prefix:validation"], exist.OperationId.Value.ToString().PadLeft(7, '0'));

                                    var codes= JsonConvert.DeserializeObject<List<GeoPoint>>(model.MapPoints).Select(a=>a.Label).ToList();
                                    operationRequestManager.CreateValidationClients(UserId, exist.OperationId.Value, codes);
                                    // seed clients
                                }

                                exist.TargetClients = exist.OperationRequestDetailCollection().Count;
                                exist.ActualClients = exist.OperationRequestDetailCollection().Where(a=>a.OperationStatusId>0).ToList().Count;

                                exist.Update();
                            }

                        }
                        else
                        {
                            // update current
                            if (exist.IsClosed != true)
                            {
                                exist.GovernerateId = model.GovernerateId;
                                exist.RepresentativeId = model.RepresentativeId;
                                exist.TargetDays = model.TargetDays;

                                if (exist.StartDate == null)
                                    exist.MapPoints = model.MapPoints;

                                if (model.IsClosed == true)
                                {
                                    exist.IsClosed = true;

                                    exist.CloseDate = DateTime.Now;
                                    
                                    if (exist.StartDate == null)
                                    {
                                        exist.StartDate = exist.OperationDate;
                                    }

                                    exist.ActualDays = (int?)(exist.CloseDate - exist.StartDate).Value.TotalDays;

                                    if (exist.TargetDays > 0)
                                    {
                                        if (exist.ActualDays < exist.TargetDays)
                                        {
                                            exist.DaysPerformance = 100;
                                        }
                                        else
                                        {
                                            exist.DaysPerformance = Math.Round((decimal)exist.ActualDays / (decimal)exist.TargetDays * 100, 2);
                                        }
                                    }
                                    else
                                    {
                                        exist.DaysPerformance = 100;
                                    }

                                    if (exist.OperationTypeId == 2)
                                    {
                                        if (exist.TargetClients > 0)
                                        {
                                            if (exist.ActualClients < exist.TargetDays)
                                            {
                                                exist.DaysPerformance = 100;
                                            }
                                            else
                                            {
                                                exist.ClientsPerformance = Math.Round((decimal)exist.ActualClients / (decimal)exist.TargetClients * 100, 2);
                                            }
                                        }
                                        else
                                        {
                                            exist.ClientsPerformance = 100;
                                        }




                                    }
                                }
                                else
                                {
                                    if (exist.OperationTypeId == 2)
                                    {
                                        var codes = JsonConvert.DeserializeObject<List<GeoPoint>>(model.MapPoints).Select(a => a.Label).ToList();
                                        operationRequestManager.CreateValidationClients(UserId, exist.OperationId.Value, codes);

                                        
                                    }
                                }
                                exist.Notes = model.Notes;
                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;

                                exist.TargetClients = exist.OperationRequestDetailCollection().Count;
                                exist.ActualClients = exist.OperationRequestDetailCollection().Where(a => a.OperationStatusId > 0).ToList().Count;

                                exist.Update();
                            }

                        }



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
        [HttpPost("delete")]
        public async Task<IActionResult> delete(OperationRequestModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<OperationRequestModel> responseModel = new ResponseModel<OperationRequestModel>();

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
                        var exist = new Criteria<BOOperationRequest>()
                                        .Add(Expression.Eq(nameof(model.OperationId), model.OperationId))
                                        .FirstOrDefault<BOOperationRequest>();


                        if (exist != null)
                        {
                            // check if has representitive
                            if (exist.IsClosed == false)
                            {
                                exist.Delete();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Cannot_delete;
                                return responseModel;
                            }
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
                ResponseModel<OperationRequestModel> responseModel = new ResponseModel<OperationRequestModel>();

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

                        var exist = new Criteria<BOOperationRequest>()
                                       .Add(Expression.Eq(nameof(BOOperationRequest.OperationId),Id))
                                       .FirstOrDefault<BOOperationRequest>();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<OperationRequestModel>(exist);


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
        [HttpPost("parse")]
        [AllowAnonymous]
        public async Task<IActionResult> parseAsync()
        {


            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<GeoPoint>> responseModel = new ResponseModel<List<GeoPoint>>();


                IFormFile file = Request.Form.Files[0];
                if (file == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;
                }

                else
                {
                    try
                    {

                        string webRootPath = _env.WebRootPath;

                        var settings = new CSVSettings()
                        {
                            FieldDelimiter = '|',
                            TextQualifier = '\'',
                            ForceQualifiers = true
                        };

                        var _root = _configuration["files"];
                        var _url = _configuration["filesUrl"];
                        var _dir = DateTime.Now.ToString("yyyyMMdd") + "/";

                        var _pathToSave = Path.Combine(webRootPath, _root, _dir);

                        if (!Directory.Exists(_pathToSave))
                        {
                            Directory.CreateDirectory(_pathToSave);
                        }

                        var UUID = Guid.NewGuid().ToString();
                        var fileName = UUID + Path.GetExtension(file.FileName);

                        if (file.Length > 0)
                        {
                            var fullPath = Path.Combine(_pathToSave, fileName);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);

                            }


                            responseModel.Data = new List<GeoPoint>();


                            using (CSVReader cr = new CSVReader(new StreamReader(System.IO.File.OpenRead(fullPath)), settings))
                            {
                                foreach (string[] line in cr)
                                {
                                    var point = new GeoPoint();

                                    if (line != null && line.Length > 0)
                                    {
                                        point.lat = double.Parse(line[0].Split(',')[0]);
                                        point.lng = double.Parse(line[0].Split(',')[1]);
                                        if (point.lat > 0 && point.lng > 0)
                                        {
                                            responseModel.Data.Add(point);
                                        }

                                    }
                                }
                            }


                            System.IO.File.Delete(fullPath);
                        }
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
        [HttpPost("parseClients")]
        [AllowAnonymous]
        public async Task<IActionResult> parseClients()
        {


            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<GeoPoint>> responseModel = new ResponseModel<List<GeoPoint>>();


                IFormFile file = Request.Form.Files[0];
                if (file == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;
                }

                else
                {
                    try
                    {

                        string webRootPath = _env.WebRootPath;

                        var settings = new CSVSettings()
                        {
                            FieldDelimiter = '|',
                            TextQualifier = '\'',
                            ForceQualifiers = true
                        };

                        var _root = _configuration["files"];
                        var _url = _configuration["filesUrl"];
                        var _dir = DateTime.Now.ToString("yyyyMMdd") + "/";

                        var _pathToSave = Path.Combine(webRootPath, _root, _dir);

                        if (!Directory.Exists(_pathToSave))
                        {
                            Directory.CreateDirectory(_pathToSave);
                        }

                        var UUID = Guid.NewGuid().ToString();
                        var fileName = UUID + Path.GetExtension(file.FileName);

                        if (file.Length > 0)
                        {
                            var fullPath = Path.Combine(_pathToSave, fileName);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);

                            }


                            responseModel.Data = new List<GeoPoint>();


                            using (CSVReader cr = new CSVReader(new StreamReader(System.IO.File.OpenRead(fullPath)), settings))
                            {
                                foreach (string[] line in cr)
                                {
                                    var point = new GeoPoint();

                                    if (line != null && line.Length > 0)
                                    {
                                        point.Label = line[0].Split(',')[0];
                                        point.lat = double.Parse(line[0].Split(',')[1]);
                                        point.lng = double.Parse(line[0].Split(',')[2]);
                                        if (point.lat > 0 && point.lng > 0)
                                        {
                                            responseModel.Data.Add(point);
                                        }

                                    }
                                }
                            }


                            System.IO.File.Delete(fullPath);
                        }
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
        public async Task<IActionResult> export(OperationRequestSearchModel model)
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

                if (model.IsClosed > 0)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestVw.IsClosed), model.IsClosed == 1 ? true : false));


                if (model.OperationDate != null && model.OperationDate.Value.Year > 1900)
                    ctr.Add(Expression.Eq(nameof(BOOperationRequestVw.OperationDate), model.OperationDate, dateformatter));

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
                             .Select(a => new OperationRequestListModel()
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
                                 TargetDays = a.TargetDays,

                                 Accuracy = a.Accuracy,
                                 ActualClients = a.ActualClients,
                                 ActualDays = a.ActualDays,
                                 ClientsPerformance = a.ClientsPerformance,
                                 DaysPerformance = a.DaysPerformance,
                                 OperationDate = a.OperationDate,
                                 TargetClients = a.TargetClients,
                                 GovernerateId = a.GovernerateId,
                                 MapPoints=a.MapPoints,
                                 GovernerateName = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,
                                 RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                 OperationTypeName = Language == "ar" ? a.OperationTypeNameAr : a.OperationTypeNameEn,

                             }).ToList();


                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "OperationCode";
                        worksheet.Cell("B1").Value = "RepresentativeName";
                        worksheet.Cell("C1").Value = "OperationDate";
                        worksheet.Cell("D1").Value = "TargetDays";
                        worksheet.Cell("E1").Value = "StartDate";
                        worksheet.Cell("F1").Value = "IsClosed";
                        worksheet.Cell("G1").Value = "CloseDate";
                        worksheet.Cell("H1").Value = "ActualDays";
                        worksheet.Cell("I1").Value = "Performance";
                        worksheet.Cell("J1").Value = "Accuracy";



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



                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].OperationCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].RepresentativeName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].OperationDate;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].TargetDays;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].StartDate;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].IsClosed;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].CloseDate;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].ActualDays;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].DaysPerformance;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].Accuracy;

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
