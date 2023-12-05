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
    public class RepresentativeController : BaseController
    {
        private readonly IMapper _mapper;
        public RepresentativeController(IHttpContextAccessor contextAccessor, IMapper mapper) : base(contextAccessor)
        {
            _mapper = mapper;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(RepresentativeSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<RepresentativeListModel>> responseModel = new ResponseModel<List<RepresentativeListModel>>();

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


                        var ctr = new Criteria<BORepresentativeVw>();
                        

                        if (this.FullDataAccess == false)
                        {
                            ctr.Add(Expression.In(nameof(BORepresentativeVw.BranchId), this.Branchs));

                            if (this.AppRoleId == 6)
                            {
                                ctr.Add(Expression.In(nameof(BORepresentativeVw.SupervisorUserId), UserId));
                            }

                            if (this.AppRoleId == 7)
                            {
                                ctr.Add(Expression.In(nameof(BORepresentativeVw.UserId), UserId));
                            }
                        }

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Like(nameof(BORepresentativeVw.RepresentativeCode), model.Term));
                        }

                        if (!string.IsNullOrEmpty(model.Phone))
                        {
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.Phone), model.Phone));
                        }

                        if (!string.IsNullOrEmpty(model.RepresentativeName))
                        {
                            if (Language == "ar")
                                ctr.Add(Expression.Like(nameof(BORepresentativeVw.RepresentativeNameAr), model.RepresentativeName));
                            else
                                ctr.Add(Expression.Like(nameof(BORepresentativeVw.RepresentativeNameEn), model.RepresentativeName));

                        }


                        if (!string.IsNullOrEmpty(model.KindIds))
                            ctr.Add(Expression.In(nameof(BORepresentativeVw.KindId), model.KindIds));


                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.BranchId), model.BranchId));

                        if (model.KindId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.KindId), model.KindId));


                        if (model.SupervisorId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.SupervisorId), model.SupervisorId));

                        if (model.TerminationReasonId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.TerminationReasonId), model.TerminationReasonId));

                        if (model.BusinessUnitId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.BusinessUnitId), model.BusinessUnitId));

                        if (model.IsActive > 0)
                        {
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.IsActive), model.IsActive==1?true:false));
                        }
                        if (model.IsTerminated > 0)
                        {
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.IsTerminated), model.IsTerminated == 1 ? true : false));
                        }

                        if (!string.IsNullOrEmpty(model.CompanyCode))
                        {
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.CompanyCode), model.CompanyCode));
                        }

                        if (model.TerminationDate !=null && model.TerminationDate.Value.Year>2000)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.TerminationDate), model.TerminationDate,dateformatter));
                        if (model.JoinDate != null && model.JoinDate.Value.Year > 2000)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.JoinDate), model.JoinDate, dateformatter));

                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
                                case "representativeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
                                    break;
                                case "kindName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("kindName{0}", Language)) : OrderBy.Desc(string.Format("kindName{0}", Language)));
                                    break;
                                case "supervisorName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorName{0}", Language)) : OrderBy.Desc(string.Format("supervisorName{0}", Language)));
                                    break;
                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "businessUnitName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("businessUnitName{0}", Language)) : OrderBy.Desc(string.Format("businessUnitName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }

                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BORepresentativeVw.RepresentativeId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0?model.Take:30)
                                     .List<BORepresentativeVw>()
                                     .Select(a => new RepresentativeListModel()
                                     {
                                         SupervisorId = a.SupervisorId,
                                         KindId = a.KindId,
                                         BranchCode = a.BranchCode,
                                         BranchId = a.BranchId,
                                         CanDelete = a.CanDelete,
                                         CanEdit = a.CanEdit,
                                         Color = a.Color,
                                         DisplayOrder = a.DisplayOrder,
                                         Icon = a.Icon,
                                         IsActive = a.IsActive,
                                         RepresentativeCode = a.RepresentativeCode,
                                         RepresentativeId = a.RepresentativeId.Value,
                                         UserId = a.UserId,
                                         JoinDate = a.JoinDate,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         KindName = Language == "ar" ? a.KindNameAr : a.KindNameEn,
                                         RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                         SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                         IsTerminated = a.IsTerminated,
                                         Notes = a.Notes,
                                         Phone = a.Phone,
                                         PhoneAlternative = a.PhoneAlternative,
                                         TerminationDate = a.TerminationDate,
                                         TerminationReasonId = a.TerminationReasonId,
                                         BusinessUnitCode = a.BusinessUnitCode,
                                         BusinessUnitId = a.BusinessUnitId,
                                         CompanyCode = a.CompanyCode,
                                         BusinessUnitName = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,

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
        public async Task<IActionResult> save(RepresentativeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeModel> responseModel = new ResponseModel<RepresentativeModel>();

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
                        var exist=new Criteria<BORepresentative>()
                                        .Add(Expression.Eq(nameof(model.RepresentativeId), model.RepresentativeId))
                                        .FirstOrDefault<BORepresentative>();


                        if(exist != null)
                        {



                            // update current
                           
                            exist.SupervisorId= model.SupervisorId>0 ? model.SupervisorId :null;
                            exist.KindId = model.KindId;
                            exist.BranchId = model.BranchId;
                            exist.CompanyCode = model.CompanyCode;
                            exist.RepresentativeCode = model.RepresentativeCode;
                            exist.RepresentativeNameEn = model.RepresentativeNameEn;
                            exist.RepresentativeNameAr = model.RepresentativeNameAr;
                            exist.JoinDate = model.JoinDate!=null? model.JoinDate : DateTime.Now;
                            
                            exist.IsActive = model.IsActive;
                            exist.Notes = model.Notes;

                            if (model.IsTerminated == true)
                            {
                                exist.IsActive=false;
                                exist.IsTerminated = true;
                                exist.TerminationReasonId = model.TerminationReasonId;
                                exist.TerminationDate = model.TerminationDate!=null ? model.TerminationDate:DateTime.Now;
                            }
                            else
                            {
                                exist.IsTerminated = false;
                                exist.TerminationReasonId = null;
                                exist.TerminationDate = null;
                            }

                            exist.Phone = model.Phone;
                            exist.PhoneAlternative = model.PhoneAlternative;

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

                            exist = new BORepresentative();

                            exist.SupervisorId = model.SupervisorId > 0 ? model.SupervisorId : null;
                            exist.KindId = model.KindId;
                            exist.BranchId = model.BranchId;
                            exist.CompanyCode = model.CompanyCode;
                            exist.RepresentativeCode = model.RepresentativeCode;
                            exist.RepresentativeNameEn = model.RepresentativeNameEn;
                            exist.RepresentativeNameAr = model.RepresentativeNameAr;
                            exist.JoinDate = model.JoinDate != null ? model.JoinDate : DateTime.Now;
                            exist.BranchId = model.BranchId;
                            exist.IsActive = model.IsActive;
                            exist.CanEdit = true;
                            exist.CanDelete = true;
                            exist.Notes = model.Notes;

                            if (model.IsTerminated == true)
                            {
                                exist.IsActive = false;
                                exist.IsTerminated = true;

                                exist.TerminationReasonId = model.TerminationReasonId;
                                exist.TerminationDate = model.TerminationDate != null ? model.TerminationDate : DateTime.Now;
                            }
                            else
                            {
                                exist.IsTerminated = false;

                                exist.TerminationReasonId = null;
                                exist.TerminationDate = null;
                            }

                            exist.Phone = model.Phone;
                            exist.PhoneAlternative = model.PhoneAlternative;

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
        public async Task<IActionResult> delete(RepresentativeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeModel> responseModel = new ResponseModel<RepresentativeModel>();

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
                        var exist = new Criteria<BORepresentative>()
                                        .Add(Expression.Eq(nameof(model.RepresentativeId), model.RepresentativeId))
                                        .FirstOrDefault<BORepresentative>();


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

        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeModel> responseModel = new ResponseModel<RepresentativeModel>();

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
                        var exist = new Criteria<BORepresentative>()
                                        .Add(Expression.Eq(nameof(BORepresentative.RepresentativeId), Id))
                                        .FirstOrDefault<BORepresentative>();
                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<RepresentativeModel>(exist);


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


        [HttpPost("Status")]
        public async Task<IActionResult> Status(RepresentativeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeModel> responseModel = new ResponseModel<RepresentativeModel>();

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
                        var exist = new Criteria<BORepresentative>()
                                        .Add(Expression.Eq(nameof(BORepresentative.RepresentativeId), model.RepresentativeId))
                                        .FirstOrDefault<BORepresentative>();


                        if (exist != null)
                        {

                            exist.IsActive = model.IsActive;
                            exist.EBy = UserId;
                            exist.EDate = DateTime.Now;
                            exist.Update();

                            if (exist.IsActive == false)
                            {
                                if (exist.UserId > 0)
                                {
                                    var user = new Criteria<BOAppUser>().Add(Expression.Eq(nameof(BOAppUser.UserId), exist.UserId)).FirstOrDefault<BOAppUser>();
                                    if (user != null)
                                    {
                                        user.IsLocked = true;
                                        user.Update();
                                    }
                                }
                            }
                            else
                            {
                                if (exist.UserId > 0)
                                {
                                    var user = new Criteria<BOAppUser>().Add(Expression.Eq(nameof(BOAppUser.UserId), exist.UserId)).FirstOrDefault<BOAppUser>();
                                    if (user != null)
                                    {
                                        user.IsLocked = false;
                                        user.Password = Encryption.Encrypt("00000");
                                        user.MustChangeData = true;
                                        user.MustChangePassword = true;

                                        user.Update();
                                    }
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
        public async Task<IActionResult> export(RepresentativeSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BORepresentativeVw>();


                if (this.FullDataAccess == false)
                    ctr.Add(Expression.In(nameof(BORepresentativeVw.BranchId), this.Branchs));

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.RepresentativeCode), model.Term));
                }

                if (!string.IsNullOrEmpty(model.Phone))
                {
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.Phone), model.Phone));
                }

                if (!string.IsNullOrEmpty(model.RepresentativeName))
                {
                    if (Language == "ar")
                        ctr.Add(Expression.Like(nameof(BORepresentativeVw.RepresentativeNameAr), model.RepresentativeName));
                    else
                        ctr.Add(Expression.Like(nameof(BORepresentativeVw.RepresentativeNameEn), model.RepresentativeName));

                }

                if (!string.IsNullOrEmpty(model.KindIds))
                    ctr.Add(Expression.In(nameof(BORepresentativeVw.KindId), model.KindIds));


                if (model.KindId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.KindId), model.KindId));

                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.BranchId), model.BranchId));

                if (model.SupervisorId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.SupervisorId), model.SupervisorId));

                if (model.TerminationReasonId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.TerminationReasonId), model.TerminationReasonId));

                if (model.BusinessUnitId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.BusinessUnitId), model.BusinessUnitId));

                if (model.IsActive > 0)
                {
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.IsActive), model.IsActive == 1 ? true : false));
                }
                if (model.IsTerminated > 0)
                {
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.IsTerminated), model.IsTerminated == 1 ? true : false));
                }

                if (!string.IsNullOrEmpty(model.CompanyCode))
                {
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.CompanyCode), model.CompanyCode));
                }

                if (model.TerminationDate != null && model.TerminationDate.Value.Year > 2000)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.TerminationDate), model.TerminationDate, dateformatter));
                if (model.JoinDate != null && model.JoinDate.Value.Year > 2000)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.JoinDate), model.JoinDate, dateformatter));

                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {

                    switch (model.SortBy.Property)
                    {
                        case "representativeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
                            break;
                        case "kindName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("kindName{0}", Language)) : OrderBy.Desc(string.Format("kindName{0}", Language)));
                            break;
                        case "supervisorName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorName{0}", Language)) : OrderBy.Desc(string.Format("supervisorName{0}", Language)));
                            break;
                        case "branchName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                            break;
                        case "businessUnitName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("businessUnitName{0}", Language)) : OrderBy.Desc(string.Format("businessUnitName{0}", Language)));
                            break;
                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }

                }
                else
                {
                    ctr.Add(OrderBy.Asc(nameof(BORepresentativeVw.RepresentativeId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BORepresentativeVw>()
                             .Select(a => new RepresentativeListModel()
                             {
                                 SupervisorId = a.SupervisorId,
                                 KindId = a.KindId,
                                 BranchCode = a.BranchCode,
                                 BranchId = a.BranchId,
                                 CanDelete = a.CanDelete,
                                 CanEdit = a.CanEdit,
                                 Color = a.Color,
                                 DisplayOrder = a.DisplayOrder,
                                 Icon = a.Icon,
                                 IsActive = a.IsActive,
                                 RepresentativeCode = a.RepresentativeCode,
                                 RepresentativeId = a.RepresentativeId.Value,
                                 UserId = a.UserId,
                                 JoinDate = a.JoinDate,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 KindName = Language == "ar" ? a.KindNameAr : a.KindNameEn,
                                 RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                 SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                 IsTerminated = a.IsTerminated,
                                 Notes = a.Notes,
                                 Phone = a.Phone,
                                 PhoneAlternative = a.PhoneAlternative,
                                 TerminationDate = a.TerminationDate,
                                 TerminationReasonId = a.TerminationReasonId,
                                 BusinessUnitCode = a.BusinessUnitCode,
                                 BusinessUnitId = a.BusinessUnitId,
                                 CompanyCode = a.CompanyCode,
                                 BusinessUnitName = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,

                             }).ToList();


                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "RepresentativeCode";
                        worksheet.Cell("B1").Value = "RepresentativeName";
                        worksheet.Cell("C1").Value = "BranchCode";
                        worksheet.Cell("D1").Value = "SupervisorName";
                        worksheet.Cell("E1").Value = "KindName";
                        worksheet.Cell("F1").Value = "JoinDate";
                        worksheet.Cell("G1").Value = "BusinessUnit";
                        worksheet.Cell("H1").Value = "HRCode";

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


                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].RepresentativeCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].RepresentativeName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].SupervisorName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].KindName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].JoinDate;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].BusinessUnitName;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].CompanyCode;

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


        [HttpPost("createAccess")]
        public async Task<IActionResult> createAccess(RepresentativeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeModel> responseModel = new ResponseModel<RepresentativeModel>();

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

                        var existBranch = new Criteria<BOAppUserBranch>()
                                       .Add(Expression.Eq(nameof(BOAppUserBranch.UserId), model.UserId))
                                       .List<BOAppUserBranch>()
                                       .Select(a => a.BranchId)
                                       .ToList();



                        if (existBranch.Count > 0)
                        {
                            var exist = new Criteria<BORepresentative>()
                                       .Add(Expression.Eq(nameof(BORepresentative.RepresentativeId), model.RepresentativeId))
                                       .Add(Expression.Eq(nameof(BORepresentative.IsActive), true))
                                       .Add(Expression.NotNull(nameof(BORepresentative.CompanyCode)))
                                       .Add(Expression.In(nameof(BORepresentative.BranchId), string.Join(',', existBranch)))
                                       .FirstOrDefault<BORepresentative>();

                            if (exist != null)
                            {

                                exist.UserId = model.UserId;
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
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
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

        [HttpPost("deleteAccess")]
        public async Task<IActionResult> deleteAccess(RepresentativeModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<RepresentativeModel> responseModel = new ResponseModel<RepresentativeModel>();

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
                        var exist = new Criteria<BORepresentative>()
                                        .Add(Expression.Eq(nameof(BORepresentative.RepresentativeId), model.RepresentativeId))
                                        .FirstOrDefault<BORepresentative>();

                        if (exist != null)
                        {

                            exist.UserId = null;
                            exist.Update();



                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
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


        [HttpGet("getByUser")]
        public async Task<IActionResult> getByUser(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<RepresentativeListModel>> responseModel = new ResponseModel<List<RepresentativeListModel>>();
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



                        var res = new Criteria<BORepresentativeVw>()
                                .Add(Expression.Eq(nameof(BORepresentativeVw.UserId), Id))
                                .List<BORepresentativeVw>()
                                .Select(a => new RepresentativeListModel()
                                {
                                    SupervisorId = a.SupervisorId,
                                    KindId = a.KindId,
                                    BranchCode = a.BranchCode,
                                    BranchId = a.BranchId,
                                    CanDelete = a.CanDelete,
                                    CanEdit = a.CanEdit,
                                    Color = a.Color,
                                    DisplayOrder = a.DisplayOrder,
                                    Icon = a.Icon,
                                    IsActive = a.IsActive,
                                    RepresentativeCode = a.RepresentativeCode,
                                    RepresentativeId = a.RepresentativeId.Value,
                                    UserId = a.UserId,
                                    JoinDate = a.JoinDate,
                                    BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                    KindName = Language == "ar" ? a.KindNameAr : a.KindNameEn,
                                    RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                    SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                    IsTerminated = a.IsTerminated,
                                    Notes = a.Notes,
                                    Phone = a.Phone,
                                    PhoneAlternative = a.PhoneAlternative,
                                    TerminationDate = a.TerminationDate,
                                    TerminationReasonId = a.TerminationReasonId,
                                    BusinessUnitCode = a.BusinessUnitCode,
                                    BusinessUnitId = a.BusinessUnitId,
                                    CompanyCode = a.CompanyCode,
                                    BusinessUnitName = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,


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

    }
}
