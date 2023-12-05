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

namespace SofiForce.Web.Controllers.CRM.Setup
{
    [Route("api/[controller]")]
    public class ClientTypeController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ClientTypeController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientTypeSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientTypeListModel>> responseModel = new ResponseModel<List<ClientTypeListModel>>();

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


                        var ctr = new Criteria<BOClientType>();



                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOClientType.ClientTypeCode), model.Term));
                        }




                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
                                case "ClientTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("ClientTypeName{0}", Language)) : OrderBy.Desc(string.Format("ClientTypeName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }

                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOClientType.ClientTypeId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOClientType>()
                                     .Select(a => new ClientTypeListModel()
                                     {
                                         ClientTypeId = a.ClientTypeId.Value,
                                         ClientTypeCode = a.ClientTypeCode,
                                         CanDelete = a.CanDelete,
                                         CanEdit = a.CanEdit,
                                         Color = a.Color,
                                         DisplayOrder = a.DisplayOrder,
                                         Icon = a.Icon,
                                         IsActive = a.IsActive,
                                         ClientTypeName = Language == "ar" ? a.ClientTypeNameAr : a.ClientTypeNameEn,



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
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> save(ClientTypeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientTypeModel> responseModel = new ResponseModel<ClientTypeModel>();

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
                        var exist = new Criteria<BOClientType>()
                                        .Add(Expression.Eq(nameof(BOClientType.ClientTypeId), model.ClientTypeId))
                                        .FirstOrDefault<BOClientType>();
                        if (exist != null && exist.CanEdit == true)
                        {

                            // update current
                            exist.ClientTypeCode = model.ClientTypeCode;


                            exist.ClientTypeNameAr = model.ClientTypeNameAr;
                            exist.ClientTypeNameEn = model.ClientTypeNameEn;
                            exist.IsActive = model.IsActive;
                            exist.Notes = model.Notes;



                            exist.EBy = UserId;
                            exist.EDate = DateTime.Now;

                            if (exist.CanEdit == true)
                            {
                                exist.Update();

                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.cannot_edit;

                                return responseModel;
                            }

                        }
                        else
                        {
                            // create new

                            exist = new BOClientType();
                            exist.ClientTypeCode = model.ClientTypeCode;
                            exist.ClientTypeNameAr = model.ClientTypeNameAr;
                            exist.ClientTypeNameEn = model.ClientTypeNameEn;
                            exist.IsActive = model.IsActive;
                            exist.Notes = model.Notes;

                            exist.CanDelete = true;
                            exist.CanEdit = true;



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
        public async Task<IActionResult> delete(ClientTypeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientTypeModel> responseModel = new ResponseModel<ClientTypeModel>();

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
                        var exist = new Criteria<BOClientType>()
                                        .Add(Expression.Eq(nameof(model.ClientTypeId), model.ClientTypeId))
                                        .FirstOrDefault<BOClientType>();


                        if (exist != null)
                        {
                            // check if has representitive
                            if (exist.CanDelete == true)
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
                        responseModel.Message = ex.Message; ;
                    }
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
                ResponseModel<ClientTypeModel> responseModel = new ResponseModel<ClientTypeModel>();

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
                        var exist = new Criteria<BOClientType>()
                                        .Add(Expression.Eq(nameof(BOClientType.ClientTypeId), Id))
                                        .FirstOrDefault<BOClientType>();
                        if (exist != null)
                        {

                            responseModel.Data = _mapper.Map<ClientTypeModel>(exist);

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



        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOClientType>();


                var res = ctr.List<BOClientType>().Select(a => new LookupModel()
                {

                    Id = a.ClientTypeId.Value,
                    Code = a.ClientTypeCode,
                    Name = Language == "ar" ? a.ClientTypeNameAr : a.ClientTypeNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpPost("export")]
        public async Task<IActionResult> export(ClientTypeSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BOClientType>();


                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOClientType.ClientTypeCode), model.Term));
                }




                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {

                    switch (model.SortBy.Property)
                    {
                        case "ClientTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("ClientTypeName{0}", Language)) : OrderBy.Desc(string.Format("ClientTypeName{0}", Language)));
                            break;
                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }

                }
                else
                {
                    ctr.Add(OrderBy.Asc(nameof(BOClientType.ClientTypeId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOClientType>()
                             .Select(a => new ClientTypeListModel()
                             {
                                 ClientTypeId = a.ClientTypeId.Value,
                                 ClientTypeCode = a.ClientTypeCode,
                                 CanDelete = a.CanDelete,
                                 CanEdit = a.CanEdit,
                                 Color = a.Color,
                                 DisplayOrder = a.DisplayOrder,
                                 Icon = a.Icon,
                                 IsActive = a.IsActive,
                                 ClientTypeName = Language == "ar" ? a.ClientTypeNameAr : a.ClientTypeNameEn,



                             }).ToList();



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "ClientTypeCode";
                        worksheet.Cell("B1").Value = "ClientTypeName";
                        worksheet.Cell("C1").Value = "IsActive";



                        worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("A1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("B1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("C1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("C1").Style.Font.FontColor = XLColor.White;



                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].ClientTypeCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ClientTypeName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].IsActive;


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
