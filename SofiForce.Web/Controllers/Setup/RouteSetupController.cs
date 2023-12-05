using AutoMapper;
using ClosedXML.Excel;
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
    public class RouteSetupController : BaseController
    {
        private readonly IMapper _mapper;
        public RouteSetupController(IHttpContextAccessor contextAccessor, IMapper mapper) : base(contextAccessor)
        {
            _mapper = mapper;
        }


        [HttpPost("filter")]
        public async Task<IActionResult> filter(RouteSetupSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<RouteSetupListModel>> responseModel = new ResponseModel<List<RouteSetupListModel>>();

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


                        var ctr = new Criteria<BORouteSetupVw>();

                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BORouteSetupVw.BranchId), this.Branchs));

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Like(nameof(BORouteSetupVw.RouteCode), model.Term));
                        }
                        
                        if(model.BranchId>0)
                            ctr.Add(Expression.Eq(nameof(BORouteSetupVw.BranchId), model.BranchId));
                        if (model.RouteTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BORouteSetupVw.RouteTypeId), model.RouteTypeId));
                        if (model.IsActive > 0)
                            ctr.Add(Expression.Eq(nameof(BORouteSetupVw.IsActive), model.IsActive == 1 ? true : false));

                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "routeTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("routeTypeName{0}", Language)) : OrderBy.Desc(string.Format("routeTypeName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }

                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BORouteSetupVw.BranchId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0?model.Take:30)
                                     .List<BORouteSetupVw>()
                                     .Select(a => new RouteSetupListModel()
                                     {
                                       RouteTypeId = a.RouteTypeId,
                                       RouteTypeCode = a.RouteTypeCode,
                                       BranchCode = a.BranchCode,
                                       BranchId = a.BranchId,
                                       CanDelete=a.CanDelete,
                                       CanEdit=a.CanEdit,
                                       Color = a.Color,
                                       Icon = a.Icon,
                                       IsActive = a.IsActive,
                                       RouteId = a.RouteId,
                                       RouteCode = a.RouteCode,
                                       
                                       BranchName=Language=="ar"?a.BranchNameAr:a.BranchNameEn,
                                       RouteName=Language=="ar"?a.RouteNameAr:a.RouteNameEn,
                                       RouteTypeName=Language=="ar"?a.RouteTypeNameAr:a.RouteTypeNameEn,

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



        [HttpPost("save")]
        public async Task<IActionResult> save(RouteSetupModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RouteSetupModel> responseModel = new ResponseModel<RouteSetupModel>();

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
                        var exist = new Criteria<BORouteSetup>()
                                        .Add(Expression.Eq(nameof(model.RouteId), model.RouteId))
                                        .FirstOrDefault<BORouteSetup>();


                        if (exist != null)
                        {



                            // update current

                            exist.RouteCode = model.RouteCode;
                            exist.RouteNameAr = model.RouteNameAr;
                            exist.RouteNameEn = model.RouteNameEn;
                            exist.IsActive = model.IsActive;
                            exist.RouteTypeId = model.RouteTypeId;
                            exist.BranchId = model.BranchId;

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

                            exist = new BORouteSetup();
                            exist.RouteCode = model.RouteCode;
                            exist.RouteNameAr = model.RouteNameAr;
                            exist.RouteNameEn = model.RouteNameEn;
                            exist.IsActive = model.IsActive;
                            exist.RouteTypeId = model.RouteTypeId;
                            exist.BranchId = model.BranchId;

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


        [HttpPost("delete")]
        public async Task<IActionResult> delete(RouteSetupModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RouteSetupModel> responseModel = new ResponseModel<RouteSetupModel>();

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
                        var exist = new Criteria<BORouteSetup>()
                                        .Add(Expression.Eq(nameof(model.RouteId), model.RouteId))
                                        .FirstOrDefault<BORouteSetup>();



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
                        responseModel.Message = ex.Message;;
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
                ResponseModel<RouteSetupModel> responseModel = new ResponseModel<RouteSetupModel>();

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
                        var exist = new Criteria<BORouteSetup>()
                                        .Add(Expression.Eq(nameof(BORouteSetup.RouteId), Id))
                                        .FirstOrDefault<BORouteSetup>();


                        if (exist != null)
                        {
                            responseModel.Data = _mapper.Map<RouteSetupModel>(exist);
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


        [HttpPost("export")]
        public async Task<IActionResult> export(RouteSetupSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BORouteSetupVw>();

                if (this.FullDataAccess == false)
                    ctr.Add(Expression.In(nameof(BORouteSetupVw.BranchId), this.Branchs));

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Like(nameof(BORouteSetupVw.RouteCode), model.Term));
                }

                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BORouteSetupVw.BranchId), model.BranchId));
                if (model.RouteTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BORouteSetupVw.RouteTypeId), model.RouteTypeId));
                if (model.IsActive > 0)
                    ctr.Add(Expression.Eq(nameof(BORouteSetupVw.IsActive), model.IsActive == 1 ? true : false));

                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {

                    switch (model.SortBy.Property)
                    {
                        case "branchName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                            break;
                        case "routeTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("routeTypeName{0}", Language)) : OrderBy.Desc(string.Format("routeTypeName{0}", Language)));
                            break;
                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }

                }
                else
                {
                    ctr.Add(OrderBy.Asc(nameof(BORouteSetupVw.BranchId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BORouteSetupVw>()
                             .Select(a => new RouteSetupListModel()
                             {
                                 RouteTypeId = a.RouteTypeId,
                                 RouteTypeCode = a.RouteTypeCode,
                                 BranchCode = a.BranchCode,
                                 BranchId = a.BranchId,
                                 CanDelete = a.CanDelete,
                                 CanEdit = a.CanEdit,
                                 Color = a.Color,
                                 Icon = a.Icon,
                                 IsActive = a.IsActive,
                                 RouteId = a.RouteId,
                                 RouteCode = a.RouteCode,

                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 RouteName = Language == "ar" ? a.RouteNameAr : a.RouteNameEn,
                                 RouteTypeName = Language == "ar" ? a.RouteTypeNameAr : a.RouteTypeNameEn,

                             }).ToList();




                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "BranchCode";
                        worksheet.Cell("B1").Value = "BranchName";
                        worksheet.Cell("C1").Value = "RouteTypeName";
                        worksheet.Cell("D1").Value = "RouteCode";
                        worksheet.Cell("E1").Value = "RouteName";
                        worksheet.Cell("F1").Value = "IsActive";


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
                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].RouteTypeName;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].RouteCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].RouteName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].IsActive;

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
