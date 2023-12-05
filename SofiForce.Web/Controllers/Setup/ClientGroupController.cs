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
    public class ClientGroupController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ClientGroupController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOClientGroup>();


                var res = ctr.List<BOClientGroup>().Select(a => new LookupModel()
                {

                    Id = a.ClientGroupId.Value,
                    Code = a.ClientGroupCode,
                    Name = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientGroupSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientGroupListModel>> responseModel = new ResponseModel<List<ClientGroupListModel>>();

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


                        var ctr = new Criteria<BOClientGroup>();



                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOClientGroup.ClientGroupCode), model.Term));
                        }




                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
                                case "ClientGroupName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("ClientGroupName{0}", Language)) : OrderBy.Desc(string.Format("ClientGroupName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }

                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOClientGroup.ClientGroupId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOClientGroup>()
                                     .Select(a => new ClientGroupListModel()
                                     {
                                         ClientGroupId = a.ClientGroupId.Value,
                                         ClientGroupCode = a.ClientGroupCode,
                                         CanDelete = a.CanDelete,
                                         CanEdit = a.CanEdit,
                                         Color = a.Color,
                                         DisplayOrder = a.DisplayOrder,
                                         Icon = a.Icon,
                                         IsActive = a.IsActive,
                                         ClientGroupName = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn,



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
        public async Task<IActionResult> save(ClientGroupModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientGroupModel> responseModel = new ResponseModel<ClientGroupModel>();

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
                        var exist = new Criteria<BOClientGroup>()
                                        .Add(Expression.Eq(nameof(BOClientGroup.ClientGroupId), model.ClientGroupId))
                                        .FirstOrDefault<BOClientGroup>();
                        if (exist != null && exist.CanEdit == true)
                        {

                            // update current
                            exist.ClientGroupCode = model.ClientGroupCode;


                            exist.ClientGroupNameAr = model.ClientGroupNameAr;
                            exist.ClientGroupNameEn = model.ClientGroupNameEn;
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

                            exist = new BOClientGroup();
                            exist.ClientGroupCode = model.ClientGroupCode;
                            exist.ClientGroupNameAr = model.ClientGroupNameAr;
                            exist.ClientGroupNameEn = model.ClientGroupNameEn;
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
        public async Task<IActionResult> delete(ClientGroupModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientGroupModel> responseModel = new ResponseModel<ClientGroupModel>();

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
                        var exist = new Criteria<BOClientGroup>()
                                        .Add(Expression.Eq(nameof(model.ClientGroupId), model.ClientGroupId))
                                        .FirstOrDefault<BOClientGroup>();


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
                ResponseModel<ClientGroupModel> responseModel = new ResponseModel<ClientGroupModel>();

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
                        var exist = new Criteria<BOClientGroup>()
                                        .Add(Expression.Eq(nameof(BOClientGroup.ClientGroupId), Id))
                                        .FirstOrDefault<BOClientGroup>();
                        if (exist != null)
                        {

                            responseModel.Data = _mapper.Map<ClientGroupModel>(exist);

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





        [HttpPost("export")]
        public async Task<IActionResult> export(ClientGroupSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BOClientGroup>();


                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOClientGroup.ClientGroupCode), model.Term));
                }




                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {

                    switch (model.SortBy.Property)
                    {
                        case "ClientGroupName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("ClientGroupName{0}", Language)) : OrderBy.Desc(string.Format("ClientGroupName{0}", Language)));
                            break;
                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }

                }
                else
                {
                    ctr.Add(OrderBy.Asc(nameof(BOClientGroup.ClientGroupId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOClientGroup>()
                             .Select(a => new ClientGroupListModel()
                             {
                                 ClientGroupId = a.ClientGroupId.Value,
                                 ClientGroupCode = a.ClientGroupCode,
                                 CanDelete = a.CanDelete,
                                 CanEdit = a.CanEdit,
                                 Color = a.Color,
                                 DisplayOrder = a.DisplayOrder,
                                 Icon = a.Icon,
                                 IsActive = a.IsActive,
                                 ClientGroupName = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn,



                             }).ToList();



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "ClientGroupCode";
                        worksheet.Cell("B1").Value = "ClientGroupName";
                        worksheet.Cell("C1").Value = "IsActive";



                        worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("A1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("B1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("C1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("C1").Style.Font.FontColor = XLColor.White;



                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].ClientGroupCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ClientGroupName;
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
