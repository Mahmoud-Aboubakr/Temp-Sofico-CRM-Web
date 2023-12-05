using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using ExcelDataReader;
using Helpers;
using Hubs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models;
using SofiForce.BusinessObjects;
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
    public class PromtionCriteriaClientAttrCustomController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment _env;
        private readonly IPromotionManager promotionManager;

        public PromtionCriteriaClientAttrCustomController(IHttpContextAccessor contextAccessor, 
                         AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                        IHubContext<AppHub> hub,
                        IWebHostEnvironment _webHostEnvironment,
                        IPromotionManager _promotionManager
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
           _hub = hub;
            _env = _webHostEnvironment;
            promotionManager = _promotionManager;
        }

        [HttpPost("save")]
        public async Task<IActionResult> save(PromtionCriteriaClientAttrCustomModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromtionCriteriaClientAttrCustomModel> responseModel = new ResponseModel<PromtionCriteriaClientAttrCustomModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaClientAttrCustom>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaClientAttrCustom.ClientAttributeId), model.ClientAttributeId))
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaClientAttrCustom.ValueFrom), model.ValueFrom))
                                        .FirstOrDefault<BOPromtionCriteriaClientAttrCustom>();


                        if (exist == null)
                        {
                            exist = new BOPromtionCriteriaClientAttrCustom();

                            exist.ClientAttributeId = model.ClientAttributeId;
                            exist.IsActive =true;
                            exist.ValueFrom = model.ValueFrom;
                           

                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                            if (exist.ClientCustomId > 0)
                            {
                                model.ClientCustomId = exist.ClientCustomId.Value;
                            }


                        }
                        else
                        {



                            exist.ClientAttributeId = model.ClientAttributeId;
                            exist.IsActive = true;
                            exist.ValueFrom = model.ValueFrom;
                            
                            exist.EBy = UserId;
                            exist.EDate = DateTime.Now;
                            exist.Update();
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


        [HttpPost("delete")]
        public async Task<IActionResult> delete(PromtionCriteriaClientAttrCustomModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromtionCriteriaClientAttrCustomModel> responseModel = new ResponseModel<PromtionCriteriaClientAttrCustomModel>();

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
                        var exist = new Criteria<BOPromtionCriteriaClientAttrCustom>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaClientAttrCustom.ClientCustomId), model.ClientCustomId))
                                        .FirstOrDefault<BOPromtionCriteriaClientAttrCustom>();


                        if (exist != null)
                        {
                            exist.Delete();


                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.Message = Messages.Invalid_Model;
                            responseModel.StatusCode = 503;
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

            return Ok(task.Result.Result);
        }

     

        [HttpGet("getByAttribute")]
        public async Task<IActionResult> getByAttribute(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromtionCriteriaClientAttrCustomListModel>> responseModel = new ResponseModel<List<PromtionCriteriaClientAttrCustomListModel>>();

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

                        // check if exit code
                        var res = new Criteria<BOPromtionCriteriaClientAttrCustomVw>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaClientAttrCustomVw.ClientAttributeId), Id))
                                        .List<BOPromtionCriteriaClientAttrCustomVw>();
                        if (res != null)
                        {
                            // update current

                            responseModel.Data = res.Select(a => new PromtionCriteriaClientAttrCustomListModel()
                            {

                                ClientAttributeId = a.ClientAttributeId,
                                ClientCustomId = a.ClientCustomId.Value,
                                ClientCode = a.ValueFrom,
                                ClientName = Language=="ar"? a.ClientNameAr:a.ClientNameEn,


                            }).ToList();


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
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpGet("getByClient")]
        public async Task<IActionResult> getByClient(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromtionCriteriaClientAttrCustomListModel>> responseModel = new ResponseModel<List<PromtionCriteriaClientAttrCustomListModel>>();

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

                        // check if exit code
                        var res = new Criteria<BOPromtionCriteriaClientAttrVw>()
                                        .Add(Expression.Eq(nameof(BOPromtionCriteriaClientAttrVw.ClientId), Id))
                                        .List<BOPromtionCriteriaClientAttrVw>()
                                        .Select(a => new PromtionCriteriaClientAttrCustomListModel()
                                        {
                                            ClientId = a.ClientId,
                                            ClientAttributeCode = a.ClientAttributeCode,
                                            ClientAttributeId = a.ClientAttributeId,
                                            ClientCode = a.ClientCode,
                                            ClientCustomId = a.ClientCustomId,
                                            IsCustom = a.IsCustom,
                                            ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                            ClientAttributeName = Language == "ar" ? a.ClientAttributeNameAr : a.ClientAttributeNameEn,
                                        }).ToList();



                        responseModel.Data = res;

                        responseModel.Total = res.Count;
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


        [HttpPost("deleteAll")]
        public async Task<IActionResult> deleteAll(PromtionCriteriaClientAttrModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromtionCriteriaClientAttrModel> responseModel = new ResponseModel<PromtionCriteriaClientAttrModel>();

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


                        this.promotionManager.ClearCustomClient(model.ClientAttributeId);

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

        [HttpPost("upload")]
        public async Task<IActionResult> upload()
        {


            var task = Task.Factory.StartNew(() =>
            {
                string webRootPath = _env.WebRootPath;

                ResponseModel<List<PromtionCriteriaClientAttrCustomModel>> responseModel = new ResponseModel<List<PromtionCriteriaClientAttrCustomModel>>();

                try
                {

                    var _root = Configuration["files"];
                    var _url = Configuration["filesUrl"];
                    var _dir = DateTime.Now.ToString("yyyyMMdd") + "/";

                    var _pathToSave = Path.Combine(webRootPath, _root, _dir);

                    if (!Directory.Exists(_pathToSave))
                    {
                        Directory.CreateDirectory(_pathToSave);
                    }


                    IFormFile file = Request.Form.Files[0];

                    if (file == null)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = Messages.Invalid_Model;

                        return responseModel;
                    }
                    if (Request.Form.Keys.Count == 0)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = Messages.Invalid_Model;
                        return responseModel;
                    }



                    int Id = int.Parse(Request.Form["id"].ToString());

                    var UUID = Guid.NewGuid().ToString();
                    var fileName = UUID + Path.GetExtension(file.FileName);

                    if (file.Length > 0)
                    {
                        var fullPath = Path.Combine(_pathToSave, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }


                        using (var stream = System.IO.File.Open(fullPath, FileMode.Open, FileAccess.Read))
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
                                if (result.Tables[0].Columns.Count > 2)
                                {

                                    responseModel.Succeeded = false;
                                    responseModel.Message = "Invalid file format";
                                    return responseModel;
                                }

                                if (result.Tables[0].Columns[0].ColumnName.ToLower()!="clientcode")
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


                                result.Tables[0].Columns.Add(new DataColumn("clientAttributeId", typeof(int)));
                                foreach (DataRow row in result.Tables[0].Rows)
                                {
                                    row["clientAttributeId"] = Id;
                                }

                                this.promotionManager.UploadClients(result.Tables[0],Id, UserId);
                            }
                        }
                    }
                    else
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = Messages.Invalid_Model;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message; ;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);


        }

        [HttpPost("download")]
        public async Task<IActionResult> download(PromtionCriteriaClientAttrModel model)
        {

            try
            {


                var res = new Criteria<BOPromtionCriteriaClientAttrCustomVw>()
                                      .Add(Expression.Eq(nameof(BOPromtionCriteriaClientAttrCustomVw.ClientAttributeId), model.ClientAttributeId))
                                      .List<BOPromtionCriteriaClientAttrCustomVw>()
                                      .Select(a=> new PromtionCriteriaClientAttrCustomListModel()
                                      {

                                          ClientAttributeId = a.ClientAttributeId,
                                          ClientCustomId = a.ClientCustomId.Value,
                                          ClientCode = a.ValueFrom,
                                          ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,


                                      }).ToList();



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "ClientCode";
                        worksheet.Cell("B1").Value = "ClientName";

                        worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("A1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("B1").Style.Font.FontColor = XLColor.White;

                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ClientName;
                          


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
