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

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class SupervisorComissionController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public SupervisorComissionController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }


        [HttpPost("filter")]
        public async Task<IActionResult> filter(SupervisorComissionSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SupervisorComissionListModel>> responseModel = new ResponseModel<List<SupervisorComissionListModel>>();

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


                        var ctr = new Criteria<BOSupervisorComissionVw>();

                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BOSupervisorComissionVw.BranchId), this.Branchs));

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.SupervisorCode), model.Term));
                        }

                       


                        if (model.SupervisorTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.SupervisorTypeId), model.SupervisorTypeId));

                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.BranchId), model.BranchId));

                        if (model.BusinessUnitId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.BusinessUnitId), model.BusinessUnitId));


                        if (model.IsApproved > 0)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.IsApproved), model.IsApproved==1?true:false));

                        if (model.ComissionTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.ComissionTypeId), model.ComissionTypeId));

                        if (model.ComissionDateFrom != null && model.ComissionDateFrom.Value.Year > 2000)
                            ctr.Add(Expression.Gte(nameof(BOSupervisorComissionVw.ComissionDate), model.ComissionDateFrom, dateformatter));

                        if (model.ComissionDateTo != null && model.ComissionDateTo.Value.Year > 2000)
                            ctr.Add(Expression.Lte(nameof(BOSupervisorComissionVw.ComissionDate), model.ComissionDateTo, dateformatter));

                        // branch Permissions


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
                                case "supervisorName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorName{0}", Language)) : OrderBy.Desc(string.Format("supervisorName{0}", Language)));
                                    break;
                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "supervisorTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorTypeName{0}", Language)) : OrderBy.Desc(string.Format("supervisorTypeName{0}", Language)));
                                    break;
                                case "comissionTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("comissionTypeName{0}", Language)) : OrderBy.Desc(string.Format("comissionTypeName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }

                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOSupervisorComissionVw.SupervisorId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOSupervisorComissionVw>()
                                     .Select(a => new SupervisorComissionListModel()
                                     {
                                         IsApproved = a.IsApproved,
                                         ComissionDate=a.ComissionDate,
                                         BranchCode=a.BranchCode,
                                          BranchId=a.BranchId,
                                          BusinessUnitId=a.BusinessUnitId,
                                          ComissionId=a.ComissionId,
                                          SupervisorId=a.SupervisorId,
                                          ComissionValue=a.ComissionValue,
                                          SupervisorTypeCode=a.SupervisorTypeCode,
                                          SupervisorTypeId=a.SupervisorTypeId,
                                          CompanyCode=a.CompanyCode,
                                          SupervisorCode=a.SupervisorCode,
                                          ComissionTypeId=a.ComissionTypeId,
                                          ComissionTypeName= Language == "ar" ? a.ComissionTypeNameAr : a.ComissionTypeNameAr,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                         SupervisorTypeName =Language=="ar"?a.SupervisorTypeNameAr:a.SupervisorTypeNameEn,


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
        public async Task<IActionResult> save(SupervisorComissionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SupervisorComissionModel> responseModel = new ResponseModel<SupervisorComissionModel>();

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
                        var exist = new Criteria<BOSupervisorComission>()
                                        .Add(Expression.Eq(nameof(BOSupervisorComission.ComissionId), model.ComissionId))
                                        .FirstOrDefault<BOSupervisorComission>();

                        if (exist != null)
                        {
                            // check if has representitive
                            if (exist.IsApproved != true)
                            {
                                exist.SupervisorId = model.SupervisorId;
                                exist.ComissionDate = model.ComissionDate;
                                exist.ComissionValue = model.ComissionValue;
                                exist.ComissionTypeId=model.ComissionTypeId;
                                exist.Notes = model.Notes;
                                exist.IsApproved=model.IsApproved;
                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;
                                exist.Update();

                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Invalid_Model;
                            }
                        }
                        else
                        {
                            // create new

                            exist = new BOSupervisorComission();

                            exist.SupervisorId = model.SupervisorId;
                            exist.ComissionDate = model.ComissionDate;
                            exist.ComissionValue = model.ComissionValue;
                            exist.ComissionTypeId = model.ComissionTypeId;
                            exist.Notes = model.Notes;
                            exist.IsApproved = model.IsApproved;

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
        public async Task<IActionResult> delete(SupervisorComissionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SupervisorComissionModel> responseModel = new ResponseModel<SupervisorComissionModel>();

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
                        // check if exit code
                        var exist = new Criteria<BOSupervisorComission>()
                                        .Add(Expression.Eq(nameof(BOSupervisorComission.ComissionId), model.ComissionId))
                                        .FirstOrDefault<BOSupervisorComission>();


                        if (exist != null)
                        {
                            // check if has representitive
                            if (exist.IsApproved != true)
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

        [HttpPost("approve")]
        public async Task<IActionResult> approve(SupervisorComissionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SupervisorComissionModel> responseModel = new ResponseModel<SupervisorComissionModel>();

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
                        // check if exit code
                        var exist = new Criteria<BOSupervisorComission>()
                                        .Add(Expression.Eq(nameof(BOSupervisorComission.ComissionId), model.ComissionId))
                                        .FirstOrDefault<BOSupervisorComission>();


                        if (exist != null)
                        {
                            // check if has representitive
                            if (exist.IsApproved != true)
                            {

                                exist.IsApproved = true;
                                exist.Update();
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
                ResponseModel<SupervisorComissionModel> responseModel = new ResponseModel<SupervisorComissionModel>();

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
                        var exist = new Criteria<BOSupervisorComission>()
                                        .Add(Expression.Eq(nameof(BOSupervisorComission.ComissionId), Id))
                                        .FirstOrDefault<BOSupervisorComission>();
                        if (exist != null)
                        {


                            responseModel.Data = _mapper.Map<SupervisorComissionModel>(exist);

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


        [HttpGet("getBySupervisor")]
        public async Task<IActionResult> getBySupervisor(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SupervisorComissionListModel>> responseModel = new ResponseModel<List<SupervisorComissionListModel>>();

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

                        var ctr = new Criteria<BOSupervisorComissionVw>();


                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BOSupervisorComissionVw.BranchId), this.Branchs));

                        ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.SupervisorId), Id));
                        ctr.Add(OrderBy.Desc(nameof(BOSupervisorComissionVw.ComissionDate)));


                        // get paged
                        responseModel.Total = ctr.Count();
                        responseModel.Data = ctr.List<BOSupervisorComissionVw>()
                                     .Select(a => new SupervisorComissionListModel()
                                     {
                                         IsApproved = a.IsApproved,
                                         ComissionDate = a.ComissionDate,
                                         BranchCode = a.BranchCode,
                                         BranchId = a.BranchId,
                                         BusinessUnitId = a.BusinessUnitId,
                                         ComissionId = a.ComissionId,
                                         SupervisorId = a.SupervisorId,
                                         ComissionValue = a.ComissionValue,
                                         SupervisorTypeCode = a.SupervisorTypeCode,
                                         SupervisorTypeId = a.SupervisorTypeId,
                                         CompanyCode = a.CompanyCode,
                                         SupervisorCode = a.SupervisorCode,
                                         ComissionTypeId = a.ComissionTypeId,
                                         ComissionTypeName = Language == "ar" ? a.ComissionTypeNameAr : a.ComissionTypeNameAr,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                         SupervisorTypeName = Language == "ar" ? a.SupervisorTypeNameAr : a.SupervisorTypeNameEn,

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



        [HttpPost("export")]
        public async Task<IActionResult> export(SupervisorComissionSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BOSupervisorComissionVw>();

                if (this.FullDataAccess == false)
                    ctr.Add(Expression.In(nameof(BOSupervisorComissionVw.BranchId), this.Branchs));

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.SupervisorCode), model.Term));
                }




                if (model.SupervisorTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.SupervisorTypeId), model.SupervisorTypeId));

                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.BranchId), model.BranchId));

                if (model.BusinessUnitId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.BusinessUnitId), model.BusinessUnitId));

                if (model.ComissionTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.ComissionTypeId), model.ComissionTypeId));

                if (model.IsApproved > 0)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorComissionVw.IsApproved), model.IsApproved == 1 ? true : false));



                if (model.ComissionDateFrom != null && model.ComissionDateFrom.Value.Year > 2000)
                    ctr.Add(Expression.Gte(nameof(BOSupervisorComissionVw.ComissionDate), model.ComissionDateFrom, dateformatter));

                if (model.ComissionDateTo != null && model.ComissionDateTo.Value.Year > 2000)
                    ctr.Add(Expression.Lte(nameof(BOSupervisorComissionVw.ComissionDate), model.ComissionDateTo, dateformatter));

                // branch Permissions


                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {

                    switch (model.SortBy.Property)
                    {
                        case "supervisorName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorName{0}", Language)) : OrderBy.Desc(string.Format("supervisorName{0}", Language)));
                            break;
                        case "branchName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                            break;
                        case "supervisorTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorTypeName{0}", Language)) : OrderBy.Desc(string.Format("supervisorTypeName{0}", Language)));
                            break;
                        case "comissionTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("comissionTypeName{0}", Language)) : OrderBy.Desc(string.Format("comissionTypeName{0}", Language)));
                            break;
                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }

                }
                else
                {
                    ctr.Add(OrderBy.Asc(nameof(BOSupervisorComissionVw.SupervisorId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOSupervisorComissionVw>()
                             .Select(a => new SupervisorComissionListModel()
                             {
                                 IsApproved = a.IsApproved,
                                 ComissionDate = a.ComissionDate,
                                 BranchCode = a.BranchCode,
                                 BranchId = a.BranchId,
                                 BusinessUnitId = a.BusinessUnitId,
                                 ComissionId = a.ComissionId,
                                 SupervisorId = a.SupervisorId,
                                 ComissionValue = a.ComissionValue,
                                 SupervisorTypeCode = a.SupervisorTypeCode,
                                 SupervisorTypeId = a.SupervisorTypeId,
                                 CompanyCode = a.CompanyCode,
                                 SupervisorCode = a.SupervisorCode,
                                 ComissionTypeId = a.ComissionTypeId,
                                 ComissionTypeName = Language == "ar" ? a.ComissionTypeNameAr : a.ComissionTypeNameAr,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                 SupervisorTypeName = Language == "ar" ? a.SupervisorTypeNameAr : a.SupervisorTypeNameEn,


                             }).ToList();



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "BranchCode";
                        worksheet.Cell("B1").Value = "BranchName";
                        worksheet.Cell("C1").Value = "SupervisorCode";
                        worksheet.Cell("D1").Value = "CompanyCode";
                        worksheet.Cell("E1").Value = "SupervisorName";
                        worksheet.Cell("F1").Value = "SupervisorTypeName";
                        worksheet.Cell("G1").Value = "ComissionDate";
                        worksheet.Cell("H1").Value = "ComissionValue";
                        worksheet.Cell("I1").Value = "IsApproved";

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
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].SupervisorCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].CompanyCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].SupervisorName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].SupervisorTypeName;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].ComissionDate;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].ComissionValue;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].IsApproved;
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
