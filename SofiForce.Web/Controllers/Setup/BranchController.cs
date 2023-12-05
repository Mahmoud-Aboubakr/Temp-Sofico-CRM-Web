using AutoMapper;
using ClosedXML.Excel;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class BranchController : BaseController
    {
        private readonly IMapper _mapper;
        public BranchController(IHttpContextAccessor contextAccessor, IMapper mapper) : base(contextAccessor)
        {
            _mapper = mapper;
        }

        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(BranchSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<BranchListModel>> responseModel = new ResponseModel<List<BranchListModel>>();

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


                        var ctr = new Criteria<BOBranchVw>();

                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BOBranchVw.BranchId), this.Branchs));

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOBranchVw.BranchCode), model.Term));
                        }

                        // branch Permissions

     
                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
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
                            ctr.Add(OrderBy.Asc(nameof(BOBranchVw.BranchId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0?model.Take:30)
                                     .List<BOBranchVw>()
                                     .Select(a => new BranchListModel()
                                     {
                                        BranchCode = a.BranchCode,
                                        BranchId = a.BranchId.Value,
                                        CanDelete=a.CanDelete,
                                        CanEdit=a.CanEdit,
                                        Color = a.Color,
                                        DisplayOrder = a.DisplayOrder,
                                        ExpenseRate=a.ExpenseRate,
                                        Icon=a.Icon,
                                        IsActive=a.IsActive,
                                        Latitude=a.Latitude,
                                        Longitude=a.Longitude,  
                                        BranchName=Language=="ar"?a.BranchNameAr:a.BranchNameEn


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
        public async Task<IActionResult> save(BranchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchModel> responseModel = new ResponseModel<BranchModel>();

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
                        var exist = new Criteria<BOBranch>()
                                        .Add(Expression.Eq(nameof(model.BranchId), model.BranchId))
                                        .FirstOrDefault<BOBranch>();


                        if (exist != null)
                        {



                            // update current


                            exist.BranchNameEn = model.BranchNameEn;
                            exist.BranchNameAr = model.BranchNameAr;
                            exist.Latitude=model.Latitude;
                            exist.Longitude=model.Longitude;
                            exist.IsActive = model.IsActive;
                            exist.ExpenseRate=model.ExpenseRate;
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

                            exist = new BOBranch();
                            exist.BranchCode = model.BranchCode;
                            exist.BranchNameEn = model.BranchNameEn;
                            exist.BranchNameAr = model.BranchNameAr;
                            exist.Latitude = model.Latitude;
                            exist.Longitude = model.Longitude;
                            exist.IsActive = model.IsActive;
                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.ExpenseRate = model.ExpenseRate;
                            exist.DisplayOrder = 1;
                            exist.CanEdit= true;
                            exist.CanDelete = true;

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
        public async Task<IActionResult> delete(BranchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchModel> responseModel = new ResponseModel<BranchModel>();

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
                        var exist = new Criteria<BOBranch>()
                                        .Add(Expression.Eq(nameof(model.BranchId), model.BranchId))
                                        .FirstOrDefault<BOBranch>();


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
        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<BranchModel> responseModel = new ResponseModel<BranchModel>();

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
                        var exist = new Criteria<BOBranch>()
                                        .Add(Expression.Eq(nameof(BOBranch.BranchId), Id))
                                        .FirstOrDefault<BOBranch>();
                        if (exist != null)
                        {
                            responseModel.Data = _mapper.Map<BranchModel>(exist);
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
        [HttpPost("export")]
        public async Task<IActionResult> export(BranchSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BOBranchVw>();

                if (this.FullDataAccess == false)
                    ctr.Add(Expression.In(nameof(BOBranchVw.BranchId), this.Branchs));

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOBranchVw.BranchCode), model.Term));
                }

                // branch Permissions


                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {

                    switch (model.SortBy.Property)
                    {
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
                    ctr.Add(OrderBy.Asc(nameof(BOBranchVw.BranchId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOBranchVw>()
                             .Select(a => new BranchListModel()
                             {
                                 BranchCode = a.BranchCode,
                                 BranchId = a.BranchId.Value,
                                 CanDelete = a.CanDelete,
                                 CanEdit = a.CanEdit,
                                 Color = a.Color,
                                 DisplayOrder = a.DisplayOrder,
                                 ExpenseRate = a.ExpenseRate,
                                 Icon = a.Icon,
                                 IsActive = a.IsActive,
                                 Latitude = a.Latitude,
                                 Longitude = a.Longitude,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn


                             }).ToList();



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "BranchCode";
                        worksheet.Cell("B1").Value = "BranchName";
                        worksheet.Cell("C1").Value = "IsActive";
                        worksheet.Cell("D1").Value = "ExpenseRate";


                        worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("A1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("B1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("C1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("C1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("D1").Style.Font.FontColor = XLColor.White;




                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].IsActive;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].ExpenseRate;

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
