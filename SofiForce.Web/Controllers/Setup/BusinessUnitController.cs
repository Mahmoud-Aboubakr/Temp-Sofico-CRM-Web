using AutoMapper;
using ClosedXML.Excel;
using Helpers;
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
    public class BusinessUnitController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public BusinessUnitController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }
        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(BusinessUnitSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<BusinessUnitListModel>> responseModel = new ResponseModel<List<BusinessUnitListModel>>();

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


                        var ctr = new Criteria<BOBusinessUnitVw>();

                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BOBusinessUnitVw.BranchId), this.Branchs));

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOBusinessUnitVw.BusinessUnitCode), model.Term));
                        }

                        

                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BOBusinessUnitVw.BranchId), model.BranchId));



                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
                                case "BusinessUnitName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("BusinessUnitName{0}", Language)) : OrderBy.Desc(string.Format("BusinessUnitName{0}", Language)));
                                    break;
                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }

                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOBusinessUnitVw.BusinessUnitId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0?model.Take:30)
                                     .List<BOBusinessUnitVw>()
                                     .Select(a => new BusinessUnitListModel()
                                     {
                                        BusinessUnitId = a.BusinessUnitId,
                                        BranchId = a.BranchId,
                                        BusinessUnitCode = a.BusinessUnitCode,
                                        BranchCode=a.BranchCode,
                                        CanDelete = a.CanDelete,
                                        CanEdit = a.CanEdit,
                                        Color=a.Color,
                                        DisplayOrder=a.DisplayOrder,
                                        Icon=a.Icon,
                                        IsActive=a.IsActive,
                                        BranchName=Language =="ar"?a.BranchNameAr:a.BranchNameEn,
                                        BusinessUnitName=Language =="ar"?a.BusinessUnitNameAr:a.BusinessUnitNameEn,
                                       


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
        public async Task<IActionResult> save(BusinessUnitModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BusinessUnitModel> responseModel = new ResponseModel<BusinessUnitModel>();

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
                        var exist=new Criteria<BOBusinessUnit>()
                                        .Add(Expression.Eq(nameof(BOBusinessUnit.BusinessUnitId), model.BusinessUnitId))
                                        .FirstOrDefault<BOBusinessUnit>();
                        if(exist != null && exist.CanEdit==true)
                        {

                            // update current
                            exist.BranchId = model.BranchId;
                            exist.BusinessUnitCode = model.BusinessUnitCode;


                            exist.BusinessUnitNameAr = model.BusinessUnitNameAr;
                            exist.BusinessUnitNameEn = model.BusinessUnitNameEn;
                            exist.BranchId = model.BranchId;
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

                            exist = new BOBusinessUnit();

                            exist.BranchId = model.BranchId;
                            exist.BusinessUnitCode = model.BusinessUnitCode;


                            exist.BusinessUnitNameAr = model.BusinessUnitNameAr;
                            exist.BusinessUnitNameEn = model.BusinessUnitNameEn;
                            exist.BranchId = model.BranchId;
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
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("delete")]
        public async Task<IActionResult> delete(BusinessUnitModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BusinessUnitModel> responseModel = new ResponseModel<BusinessUnitModel>();

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
                        var exist = new Criteria<BOBusinessUnit>()
                                        .Add(Expression.Eq(nameof(model.BusinessUnitId), model.BusinessUnitId))
                                        .FirstOrDefault<BOBusinessUnit>();


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
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
        [CheckAuthorizedAttribute]
        [HttpGet("getByBranch")]
        public async Task<IActionResult> getByBranch(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

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
                        var exist = new Criteria<BOBusinessUnit>()
                                        .Add(Expression.Eq(nameof(BOBusinessUnit.BranchId), Id))
                                        .List<BOBusinessUnit>()
                                        .Select(a => new LookupModel()
                                        {
                                            Code = a.BusinessUnitCode,
                                            Name = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,
                                            Id = a.BusinessUnitId.Value,
                                            ParentId = a.BranchId.Value

                                        }).ToList();

                        responseModel.Data = exist;
                        responseModel.Total = exist.Count;
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
        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BusinessUnitModel> responseModel = new ResponseModel<BusinessUnitModel>();

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
                        var exist = new Criteria<BOBusinessUnit>()
                                        .Add(Expression.Eq(nameof(BOBusinessUnit.BusinessUnitId), Id))
                                        .FirstOrDefault<BOBusinessUnit>();
                        if (exist != null)
                        {

                            responseModel.Data = _mapper.Map<BusinessUnitModel>(exist);

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
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOBusinessUnit>();


                var res = ctr.List<BOBusinessUnit>().Select(a => new LookupModel()
                {

                    Id = a.BusinessUnitId.Value,
                    Code = a.BusinessUnitCode,
                    ParentId = a.BranchId.Value,
                    Name = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
        [CheckAuthorizedAttribute]
        [HttpPost("export")]
        public async Task<IActionResult> export(BusinessUnitSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BOBusinessUnitVw>();

                if (this.FullDataAccess == false)
                    ctr.Add(Expression.In(nameof(BOBusinessUnitVw.BranchId), this.Branchs));

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOBusinessUnitVw.BusinessUnitCode), model.Term));
                }



                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BOBusinessUnitVw.BranchId), model.BranchId));



                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {

                    switch (model.SortBy.Property)
                    {
                        case "BusinessUnitName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("BusinessUnitName{0}", Language)) : OrderBy.Desc(string.Format("BusinessUnitName{0}", Language)));
                            break;
                        case "branchName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                            break;
                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }

                }
                else
                {
                    ctr.Add(OrderBy.Asc(nameof(BOBusinessUnitVw.BusinessUnitId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOBusinessUnitVw>()
                             .Select(a => new BusinessUnitListModel()
                             {
                                 BusinessUnitId = a.BusinessUnitId,
                                 BranchId = a.BranchId,
                                 BusinessUnitCode = a.BusinessUnitCode,
                                 BranchCode = a.BranchCode,
                                 CanDelete = a.CanDelete,
                                 CanEdit = a.CanEdit,
                                 Color = a.Color,
                                 DisplayOrder = a.DisplayOrder,
                                 Icon = a.Icon,
                                 IsActive = a.IsActive,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 BusinessUnitName = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,



                             }).ToList();



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "BranchCode";
                        worksheet.Cell("B1").Value = "BranchName";
                        worksheet.Cell("C1").Value = "BusinessUnitCode";
                        worksheet.Cell("D1").Value = "BusinessUnitName";
                        worksheet.Cell("E1").Value = "IsActive";



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
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].BusinessUnitCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].BusinessUnitName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].IsActive;


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
