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
    public class SupervisorController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public SupervisorController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }
        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(SupervisorSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SupervisorListModel>> responseModel = new ResponseModel<List<SupervisorListModel>>();

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


                        var ctr = new Criteria<BOSupervisorVw>();

                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BOSupervisorVw.BranchId), this.Branchs));

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Like(nameof(BOSupervisorVw.SupervisorCode), model.Term));
                        }

                        if (!string.IsNullOrEmpty(model.Phone))
                        {
                            ctr.Add(Expression.Eq(nameof(BOSupervisorVw.Phone), model.Phone));
                        }

                        if (!string.IsNullOrEmpty(model.SupervisorName))
                        {
                            if (Language == "ar")
                                ctr.Add(Expression.Like(nameof(BOSupervisorVw.SupervisorNameAr), model.SupervisorName));
                            else
                                ctr.Add(Expression.Like(nameof(BOSupervisorVw.SupervisorNameEn), model.SupervisorName));

                        }

                        if (!string.IsNullOrEmpty(model.SupervisorTypeIds))
                            ctr.Add(Expression.In(nameof(BOSupervisorVw.SupervisorTypeId), model.SupervisorTypeIds));


                        if (model.SupervisorTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorVw.SupervisorTypeId), model.SupervisorTypeId));

                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorVw.BranchId), model.BranchId));


                        if (model.TerminationReasonId > 0)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorVw.TerminationReasonId), model.TerminationReasonId));

                        if (!string.IsNullOrEmpty(model.CompanyCode))
                        {
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.CompanyCode), model.CompanyCode));
                        }


                        if (model.BusinessUnitId > 0)
                            ctr.Add(Expression.Eq(nameof(BORepresentativeVw.BusinessUnitId), model.BusinessUnitId));

                        if (model.IsActive > 0)
                        {
                            ctr.Add(Expression.Eq(nameof(BOSupervisorVw.IsActive), model.IsActive == 1 ? true : false));
                        }
                        if (model.IsTerminated > 0)
                        {
                            ctr.Add(Expression.Eq(nameof(BOSupervisorVw.IsTerminated), model.IsTerminated == 1 ? true : false));
                        }

                        if (model.TerminationDate != null && model.TerminationDate.Value.Year > 2000)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorVw.TerminationDate), model.TerminationDate, dateformatter));
                        if (model.JoinDate != null && model.JoinDate.Value.Year > 2000)
                            ctr.Add(Expression.Eq(nameof(BOSupervisorVw.JoinDate), model.JoinDate, dateformatter));

                        // branch Permissions


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
                                case "supervisorName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorName{0}", Language)) : OrderBy.Desc(string.Format("supervisorName{0}", Language)));
                                    break;
                                case "supervisorTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorTypeName{0}", Language)) : OrderBy.Desc(string.Format("supervisorTypeName{0}", Language)));
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
                            ctr.Add(OrderBy.Asc(nameof(BOSupervisorVw.SupervisorId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0?model.Take:30)
                                     .List<BOSupervisorVw>()
                                     .Select(a => new SupervisorListModel()
                                     {
                                         SupervisorId = a.SupervisorId.Value,
                                         SupervisorCode = a.SupervisorCode,
                                         BranchId = a.BranchId,
                                         BranchCode = a.BranchCode,
                                         CanDelete = a.CanDelete,
                                         Color = a.Color,
                                         DisplayOrder = a.DisplayOrder,
                                         Icon = a.Icon,
                                         CanEdit = a.CanEdit,
                                         IsActive = a.IsActive,
                                         UserId = a.UserId,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                         Representatives = a.Representatives,
                                         JoinDate = a.JoinDate,
                                         SupervisorTypeName = Language == "ar" ? a.SupervisorTypeNameAr : a.SupervisorTypeNameEn,
                                         IsTerminated = a.IsTerminated,
                                         Notes = a.Notes,
                                         Phone = a.Phone,
                                         PhoneAlternative = a.PhoneAlternative,
                                         TerminationDate = a.TerminationDate,
                                         TerminationReasonId = a.TerminationReasonId,
                                         BusinessUnitCode = a.BusinessUnitCode,
                                         BusinessUnitId = a.BusinessUnitId,
                                         CompanyCode = a.CompanyCode,
                                         BusinessUnitName= Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,


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
        public async Task<IActionResult> save(SupervisorModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SupervisorModel> responseModel = new ResponseModel<SupervisorModel>();

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
                        var exist=new Criteria<BOSupervisor>()
                                        .Add(Expression.Eq(nameof(model.SupervisorId), model.SupervisorId))
                                        .FirstOrDefault<BOSupervisor>();
                        if(exist != null)
                        {
                            // check if has representitive
                            if (exist.BranchId != model.BranchId)
                            {
                                var reps = new Criteria<BORepresentative>()
                                        .Add(Expression.Eq(nameof(BORepresentative.SupervisorId), model.SupervisorId))
                                        .List<BORepresentative>();

                                if (reps.Count> 0)
                                {
                                    responseModel.Succeeded = false;
                                    responseModel.StatusCode = 500;
                                    responseModel.Message =Messages.Invalid_Model;

                                    return  responseModel;
                                }

                            }


                            // update current
                            exist.SupervisorTypeId = model.SupervisorTypeId;
                            exist.CompanyCode = model.CompanyCode;

                            exist.SupervisorCode = string.Format(_configuration["settings:prefix:supervisor"], exist.SupervisorId.ToString().PadLeft(4, '0'));

                            exist.SupervisorNameEn = model.SupervisorNameEn;
                            exist.SupervisorNameAr = model.SupervisorNameAr;
                            exist.JoinDate = model.JoinDate != null ? model.JoinDate : DateTime.Now;
                            exist.BranchId = model.BranchId;
                            exist.IsActive = model.IsActive;
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

                            exist = new BOSupervisor();

                            exist.SupervisorTypeId=model.SupervisorTypeId;
                            exist.CompanyCode  = model.CompanyCode;
                            exist.SupervisorNameEn = model.SupervisorNameEn;
                            exist.SupervisorNameAr = model.SupervisorNameAr;
                            exist.JoinDate = model.JoinDate != null ? model.JoinDate : DateTime.Now;
                            exist.BranchId = model.BranchId;
                            exist.IsActive = model.IsActive;
                            exist.CanEdit = true;
                            exist.CanDelete = true;
                            exist.Notes = model.Notes;

                            exist.IsTerminated = model.IsTerminated;

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

                            if (exist.SupervisorId > 0)
                            {
                                exist.SupervisorCode = string.Format(_configuration["settings:prefix:supervisor"], exist.SupervisorId.ToString().PadLeft(4, '0'));
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
        public async Task<IActionResult> delete(SupervisorModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SupervisorModel> responseModel = new ResponseModel<SupervisorModel>();

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
                        var exist = new Criteria<BOSupervisor>()
                                        .Add(Expression.Eq(nameof(model.SupervisorId), model.SupervisorId))
                                        .FirstOrDefault<BOSupervisor>();


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
                ResponseModel<SupervisorModel> responseModel = new ResponseModel<SupervisorModel>();

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
                        var exist = new Criteria<BOSupervisor>()
                                        .Add(Expression.Eq(nameof(BOSupervisor.SupervisorId), Id))
                                        .FirstOrDefault<BOSupervisor>();
                        if (exist != null)
                        {

                            responseModel.Data = _mapper.Map<SupervisorModel>(exist);

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
        [HttpPost("Status")]
        public async Task<IActionResult> Status(SupervisorModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SupervisorModel> responseModel = new ResponseModel<SupervisorModel>();

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
                        var exist = new Criteria<BOSupervisor>()
                                        .Add(Expression.Eq(nameof(BOSupervisor.SupervisorId), model.SupervisorId))
                                        .FirstOrDefault<BOSupervisor>();


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
                                    if(user != null)
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
                                        user.Password=Encryption.Encrypt("00000");
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
        [CheckAuthorizedAttribute]
        [HttpGet("getReps")]
        public async Task<IActionResult> getReps(int Id)
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

                        var ctr = new Criteria<BORepresentativeVw>();


                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BORepresentativeVw.BranchId), this.Branchs));

                        ctr.Add(Expression.Eq(nameof(BORepresentativeVw.SupervisorId), Id));


                        // get paged
                        responseModel.Total= ctr.Count();
                        responseModel.Data = ctr.List<BORepresentativeVw>()
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
        [HttpGet("getByUser")]
        public async Task<IActionResult> getByUser(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SupervisorListModel>> responseModel = new ResponseModel<List<SupervisorListModel>>();
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



                        var res = new Criteria<BOSupervisorVw>()
                                .Add(Expression.Eq(nameof(BOSupervisorVw.UserId), Id))
                                .List<BOSupervisorVw>()
                                .Select(a => new SupervisorListModel()
                                {
                                    SupervisorId = a.SupervisorId.Value,
                                    SupervisorCode = a.SupervisorCode,
                                    BranchId = a.BranchId,
                                    BranchCode = a.BranchCode,
                                    CanDelete = a.CanDelete,
                                    Color = a.Color,
                                    DisplayOrder = a.DisplayOrder,
                                    Icon = a.Icon,
                                    CanEdit = a.CanEdit,
                                    IsActive = a.IsActive,
                                    UserId = a.UserId,
                                    BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                    SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                    Representatives = a.Representatives,
                                    JoinDate = a.JoinDate,
                                    SupervisorTypeName = Language == "ar" ? a.SupervisorTypeNameAr : a.SupervisorTypeNameEn,
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
        [CheckAuthorizedAttribute]
        [HttpPost("createAccess")]
        public async Task<IActionResult> createAccess(SupervisorModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SupervisorModel> responseModel = new ResponseModel<SupervisorModel>();

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
                            // check if exit code
                            var exist = new Criteria<BOSupervisor>()
                                        .Add(Expression.Eq(nameof(BOSupervisor.SupervisorId), model.SupervisorId))
                                        .Add(Expression.Eq(nameof(BOSupervisor.IsActive), true))
                                        .Add(Expression.NotNull(nameof(BOSupervisor.CompanyCode)))
                                        .Add(Expression.In(nameof(BOSupervisor.BranchId), string.Join(',', existBranch)))
                                        .FirstOrDefault<BOSupervisor>();

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
        [CheckAuthorizedAttribute]
        [HttpPost("deleteAccess")]
        public async Task<IActionResult> deleteAccess(SupervisorModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SupervisorModel> responseModel = new ResponseModel<SupervisorModel>();

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
                        var exist = new Criteria<BOSupervisor>()
                                        .Add(Expression.Eq(nameof(BOSupervisor.SupervisorId), model.SupervisorId))
                                        .FirstOrDefault<BOSupervisor>();

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

        [CheckAuthorizedAttribute]
        [HttpPost("addRep")]
        public async Task<IActionResult> addRep(RepresentativeModel model)
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

                        var exist = new Criteria<BORepresentative>().Add(Expression.Eq(nameof(BORepresentative.RepresentativeId), model.RepresentativeId)).FirstOrDefault<BORepresentative>();

                        if (exist != null)
                        {
                            if (model.SupervisorId > 0)
                            {
                                exist.SupervisorId = model.SupervisorId;
                                exist.Update();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 503;
                            }
                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.Message = Messages.Invalid_Model;
                            responseModel.StatusCode = 503;
                        }


                        return responseModel;

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
        [HttpPost("deleteRep")]
        public async Task<IActionResult> deleteRep(RepresentativeModel model)
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

                        var exist = new Criteria<BORepresentative>().Add(Expression.Eq(nameof(BORepresentative.RepresentativeId), model.RepresentativeId)).FirstOrDefault<BORepresentative>();

                        if (exist != null)
                        {
                            exist.SupervisorId = null;
                            exist.Update();
                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.Message = Messages.Invalid_Model;
                            responseModel.StatusCode = 503;
                        }


                        return responseModel;

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
        public async Task<IActionResult> export(SupervisorSearchModel model)
        {

            try
            {


                var ctr = new Criteria<BOSupervisorVw>();

                if (this.FullDataAccess == false)
                    ctr.Add(Expression.In(nameof(BOSupervisorVw.BranchId), this.Branchs));

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOSupervisorVw.SupervisorCode), model.Term));
                }

                if (!string.IsNullOrEmpty(model.Phone))
                {
                    ctr.Add(Expression.Eq(nameof(BOSupervisorVw.Phone), model.Phone));
                }

                if (!string.IsNullOrEmpty(model.SupervisorName))
                {
                    if (Language == "ar")
                        ctr.Add(Expression.Like(nameof(BOSupervisorVw.SupervisorNameAr), model.SupervisorName));
                    else
                        ctr.Add(Expression.Like(nameof(BOSupervisorVw.SupervisorNameEn), model.SupervisorName));

                }

                if (!string.IsNullOrEmpty(model.SupervisorTypeIds))
                    ctr.Add(Expression.In(nameof(BOSupervisorVw.SupervisorTypeId), model.SupervisorTypeIds));


                if (model.SupervisorTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorVw.SupervisorTypeId), model.SupervisorTypeId));

                if (model.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorVw.BranchId), model.BranchId));


                if (model.TerminationReasonId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorVw.TerminationReasonId), model.TerminationReasonId));

                if (!string.IsNullOrEmpty(model.CompanyCode))
                {
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.CompanyCode), model.CompanyCode));
                }


                if (model.BusinessUnitId > 0)
                    ctr.Add(Expression.Eq(nameof(BORepresentativeVw.BusinessUnitId), model.BusinessUnitId));

                if (model.IsActive > 0)
                {
                    ctr.Add(Expression.Eq(nameof(BOSupervisorVw.IsActive), model.IsActive == 1 ? true : false));
                }
                if (model.IsTerminated > 0)
                {
                    ctr.Add(Expression.Eq(nameof(BOSupervisorVw.IsTerminated), model.IsTerminated == 1 ? true : false));
                }

                if (model.TerminationDate != null && model.TerminationDate.Value.Year > 2000)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorVw.TerminationDate), model.TerminationDate, dateformatter));
                if (model.JoinDate != null && model.JoinDate.Value.Year > 2000)
                    ctr.Add(Expression.Eq(nameof(BOSupervisorVw.JoinDate), model.JoinDate, dateformatter));

                // branch Permissions


                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {

                    switch (model.SortBy.Property)
                    {
                        case "supervisorName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorName{0}", Language)) : OrderBy.Desc(string.Format("supervisorName{0}", Language)));
                            break;
                        case "supervisorTypeName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("supervisorTypeName{0}", Language)) : OrderBy.Desc(string.Format("supervisorTypeName{0}", Language)));
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
                    ctr.Add(OrderBy.Asc(nameof(BOSupervisorVw.SupervisorId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr
                             .List<BOSupervisorVw>()
                             .Select(a => new SupervisorListModel()
                             {
                                 SupervisorId = a.SupervisorId.Value,
                                 SupervisorCode = a.SupervisorCode,
                                 BranchId = a.BranchId,
                                 BranchCode = a.BranchCode,
                                 CanDelete = a.CanDelete,
                                 Color = a.Color,
                                 DisplayOrder = a.DisplayOrder,
                                 Icon = a.Icon,
                                 CanEdit = a.CanEdit,
                                 IsActive = a.IsActive,
                                 UserId = a.UserId,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 SupervisorName = Language == "ar" ? a.SupervisorNameAr : a.SupervisorNameEn,
                                 Representatives = a.Representatives,
                                 JoinDate = a.JoinDate,
                                 SupervisorTypeName = Language == "ar" ? a.SupervisorTypeNameAr : a.SupervisorTypeNameEn,
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

                        worksheet.Cell("A1").Value = "SupervisorCode";
                        worksheet.Cell("B1").Value = "BranchCode";
                        worksheet.Cell("C1").Value = "BranchName";
                        worksheet.Cell("D1").Value = "SupervisorName";
                        worksheet.Cell("E1").Value = "SupervisorTypeName";
                        worksheet.Cell("F1").Value = "JoinDate";
                        worksheet.Cell("G1").Value = "Representatives";
                        worksheet.Cell("H1").Value = "BusinessUnit";
                        worksheet.Cell("I1").Value = "HRCode";

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
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].SupervisorCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].SupervisorName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].SupervisorTypeName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].JoinDate;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].Representatives;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].BusinessUnitName;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].CompanyCode;
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
