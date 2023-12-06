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

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class RepresentativeComissionController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public RepresentativeComissionController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }


        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(RepresentativeComissionSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<RepresentativeComissionListModel>> responseModel = new ResponseModel<List<RepresentativeComissionListModel>>();

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


                        var ctr = new Criteria<BORepresentativeComissionVw>();

                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BORepresentativeComissionVw.BranchId), this.Branchs));

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.RepresentativeCode), model.Term));
                        }

                       


                        if (model.kindId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.KindId), model.kindId));

                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.BranchId), model.BranchId));

                        if (model.BusinessUnitId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.BusinessUnitId), model.BusinessUnitId));


                        if (model.IsApproved > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.IsApproved), model.IsApproved==1?true:false));

                        if (model.ComissionTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.ComissionTypeId), model.ComissionTypeId));

                        if (model.ComissionDateFrom != null && model.ComissionDateFrom.Value.Year > 2000)
                            ctr.Add(Expression.Gte(nameof(BORepresentativeComissionVw.ComissionDate), model.ComissionDateFrom, dateformatter));

                        if (model.ComissionDateTo != null && model.ComissionDateTo.Value.Year > 2000)
                            ctr.Add(Expression.Lte(nameof(BORepresentativeComissionVw.ComissionDate), model.ComissionDateTo, dateformatter));

                        // branch Permissions


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
                                case "RepresentativeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("RepresentativeName{0}", Language)) : OrderBy.Desc(string.Format("RepresentativeName{0}", Language)));
                                    break;
                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "kindName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("kindName{0}", Language)) : OrderBy.Desc(string.Format("RepresentativeTypeName{0}", Language)));
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
                            ctr.Add(OrderBy.Asc(nameof(BORepresentativeComissionVw.RepresentativeId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BORepresentativeComissionVw>()
                                     .Select(a => new RepresentativeComissionListModel()
                                     {
                                         IsApproved = a.IsApproved,
                                         ComissionDate=a.ComissionDate,
                                         BranchCode=a.BranchCode,
                                          BranchId=a.BranchId,
                                          BusinessUnitId=a.BusinessUnitId,
                                          ComissionId=a.ComissionId,
                                          RepresentativeId=a.RepresentativeId.Value,
                                          ComissionValue=a.ComissionValue,
                                          kindCode=a.KindCode,
                                          kindId=a.KindId,
                                          CompanyCode=a.CompanyCode,
                                          RepresentativeCode=a.RepresentativeCode,
                                          ComissionTypeId=a.ComissionTypeId,
                                          SupervisorCode=a.RepresentativeCode,
                                          SupervisorId=a.SupervisorId,  
                                          SupervisorName= Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                         ComissionTypeName = Language == "ar" ? a.ComissionTypeNameAr : a.ComissionTypeNameAr,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                         kindName =Language=="ar"?a.KindNameAr:a.KindNameAr,


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

        [CheckAuthorizedAttribute]
        [HttpPost("save")]
        public async Task<IActionResult> save(RepresentativeComissionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeComissionModel> responseModel = new ResponseModel<RepresentativeComissionModel>();

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
                        var exist = new Criteria<BORepresentativeComission>()
                                        .Add(Expression.Eq(nameof(BORepresentativeComission.ComissionId), model.ComissionId))
                                        .FirstOrDefault<BORepresentativeComission>();

                        if (exist != null)
                        {
                            // check if has representitive
                            if (exist.IsApproved != true)
                            {
                                exist.RepresentativeId = model.RepresentativeId;
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

                            exist = new BORepresentativeComission();

                            exist.RepresentativeId = model.RepresentativeId;
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


        [CheckAuthorizedAttribute]
        [HttpPost("delete")]
        public async Task<IActionResult> delete(RepresentativeComissionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeComissionModel> responseModel = new ResponseModel<RepresentativeComissionModel>();

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
                        var exist = new Criteria<BORepresentativeComission>()
                                        .Add(Expression.Eq(nameof(BORepresentativeComission.ComissionId), model.ComissionId))
                                        .FirstOrDefault<BORepresentativeComission>();


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

        [CheckAuthorizedAttribute]
        [HttpPost("approve")]
        public async Task<IActionResult> approve(RepresentativeComissionModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeComissionModel> responseModel = new ResponseModel<RepresentativeComissionModel>();

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
                        var exist = new Criteria<BORepresentativeComission>()
                                        .Add(Expression.Eq(nameof(BORepresentativeComission.ComissionId), model.ComissionId))
                                        .FirstOrDefault<BORepresentativeComission>();


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


        [CheckAuthorizedAttribute]
        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeComissionModel> responseModel = new ResponseModel<RepresentativeComissionModel>();

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
                        var exist = new Criteria<BORepresentativeComission>()
                                        .Add(Expression.Eq(nameof(BORepresentativeComission.ComissionId), Id))
                                        .FirstOrDefault<BORepresentativeComission>();
                        if (exist != null)
                        {
                            responseModel.Data = _mapper.Map<RepresentativeComissionModel>(exist);
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


        [CheckAuthorizedAttribute]
        [HttpGet("getByRepresentative")]
        public async Task<IActionResult> getByRepresentative(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<RepresentativeComissionListModel>> responseModel = new ResponseModel<List<RepresentativeComissionListModel>>();

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

                        var ctr = new Criteria<BORepresentativeComissionVw>();


                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BORepresentativeComissionVw.BranchId), this.Branchs));

                        ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.RepresentativeId), Id));
                        ctr.Add(OrderBy.Desc(nameof(BORepresentativeComissionVw.ComissionDate)));


                        // get paged
                        responseModel.Total = ctr.Count();
                        responseModel.Data = ctr.List<BORepresentativeComissionVw>()
                                     .Select(a => new RepresentativeComissionListModel()
                                     {
                                         IsApproved = a.IsApproved,
                                         ComissionDate = a.ComissionDate,
                                         BranchCode = a.BranchCode,
                                         BranchId = a.BranchId,
                                         BusinessUnitId = a.BusinessUnitId,
                                         ComissionId = a.ComissionId,
                                         RepresentativeId = a.RepresentativeId.Value,
                                         ComissionValue = a.ComissionValue,
                                         kindCode = a.KindCode,
                                         kindId = a.KindId,
                                         CompanyCode = a.CompanyCode,
                                         RepresentativeCode = a.RepresentativeCode,
                                         ComissionTypeId = a.ComissionTypeId,
                                         SupervisorCode = a.RepresentativeCode,
                                         SupervisorId = a.SupervisorId,
                                         SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                         ComissionTypeName = Language == "ar" ? a.ComissionTypeNameAr : a.ComissionTypeNameAr,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                         kindName = Language == "ar" ? a.KindNameAr : a.KindNameAr,


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



        [CheckAuthorizedAttribute]
        [HttpPost("export")]
        public async Task<IActionResult> export(RepresentativeComissionSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BORepresentativeComissionVw>();

                if (this.FullDataAccess == false)
                    ctr.Add(Expression.In(nameof(BORepresentativeComissionVw.BranchId), this.Branchs));

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.RepresentativeCode), model.Term));
                }




                if (model.kindId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.KindId), model.kindId));

                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.BranchId), model.BranchId));

                if (model.BusinessUnitId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.BusinessUnitId), model.BusinessUnitId));


                if (model.IsApproved > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.IsApproved), model.IsApproved == 1 ? true : false));

                if (model.ComissionTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeComissionVw.ComissionTypeId), model.ComissionTypeId));

                if (model.ComissionDateFrom != null && model.ComissionDateFrom.Value.Year > 2000)
                    ctr.Add(Expression.Gte(nameof(BORepresentativeComissionVw.ComissionDate), model.ComissionDateFrom, dateformatter));

                if (model.ComissionDateTo != null && model.ComissionDateTo.Value.Year > 2000)
                    ctr.Add(Expression.Lte(nameof(BORepresentativeComissionVw.ComissionDate), model.ComissionDateTo, dateformatter));

                // branch Permissions


                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {

                    switch (model.SortBy.Property)
                    {
                        case "RepresentativeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("RepresentativeName{0}", Language)) : OrderBy.Desc(string.Format("RepresentativeName{0}", Language)));
                            break;
                        case "branchName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                            break;
                        case "kindName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("kindName{0}", Language)) : OrderBy.Desc(string.Format("RepresentativeTypeName{0}", Language)));
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
                    ctr.Add(OrderBy.Asc(nameof(BORepresentativeComissionVw.RepresentativeId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.Skip(model.Skip)
                             .Take(model.Take > 0 ? model.Take : 30)
                             .List<BORepresentativeComissionVw>()
                             .Select(a => new RepresentativeComissionListModel()
                             {
                                 IsApproved = a.IsApproved,
                                 ComissionDate = a.ComissionDate,
                                 BranchCode = a.BranchCode,
                                 BranchId = a.BranchId,
                                 BusinessUnitId = a.BusinessUnitId,
                                 ComissionId = a.ComissionId,
                                 RepresentativeId = a.RepresentativeId.Value,
                                 ComissionValue = a.ComissionValue,
                                 kindCode = a.KindCode,
                                 kindId = a.KindId,
                                 CompanyCode = a.CompanyCode,
                                 RepresentativeCode = a.RepresentativeCode,
                                 ComissionTypeId = a.ComissionTypeId,
                                 SupervisorCode = a.RepresentativeCode,
                                 SupervisorId = a.SupervisorId,
                                 SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                 ComissionTypeName = Language == "ar" ? a.ComissionTypeNameAr : a.ComissionTypeNameAr,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                 kindName = Language == "ar" ? a.KindNameAr : a.KindNameAr,


                             }).ToList();

                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "BranchCode";
                        worksheet.Cell("B1").Value = "BranchName";
                        worksheet.Cell("C1").Value = "RepresentativeCode";
                        worksheet.Cell("D1").Value = "CompanyCode";
                        worksheet.Cell("E1").Value = "RepresentativeName";
                        worksheet.Cell("F1").Value = "KindName";
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
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].RepresentativeCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].CompanyCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].RepresentativeName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].kindName;
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
