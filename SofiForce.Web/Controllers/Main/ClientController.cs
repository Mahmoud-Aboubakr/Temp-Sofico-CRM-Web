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
using SofiForce.Web.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class ClientController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IClientManager _clientManager;
        public ClientController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration, IClientManager clientManager) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
            _clientManager = clientManager;
        }


        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientSearchModel searchModel)
        {

            ////var task = Task.Factory.StartNew(() =>
            ////{
            ////    ResponseModel<List<ClientListModel>> responseModel = new ResponseModel<List<ClientListModel>>();

            ////    try
            ////    {
            ////        var ctr = new Criteria<BOClientVw>();

            ////        // get by term
            ////        if (!string.IsNullOrEmpty(searchModel.Term))
            ////        {

            ////            if (!string.IsNullOrEmpty(searchModel.TermBy))
            ////            {
            ////                switch (searchModel.TermBy)
            ////                {
            ////                    case "clientCode":
            ////                        ctr.Add(Expression.StartWith(nameof(BOClientVw.ClientCode), searchModel.Term));
            ////                        break;
            ////                    case "clientNameAr":
            ////                        ctr.Add(Expression.StartWith(nameof(BOClientVw.ClientNameAr), searchModel.Term));
            ////                        break;
            ////                    case "clientNameEn":
            ////                        ctr.Add(Expression.StartWith(nameof(BOClientVw.ClientNameEn), searchModel.Term));
            ////                        break;
            ////                    default:
            ////                        break;
            ////                }
            ////            }

            ////        }


            ////        if (this.FullDataAccess == true)
            ////        {
            ////            ctr.Add(Expression.In(nameof(BOClientVw.BranchId), this.Branchs));

            ////            if (this.AppRoleId == 6)
            ////            {
            ////                // get By Suppervisor
            ////                var clients = new Criteria<BORepresentativeClientVw>()
            ////                            .Add(Expression.Eq(nameof(BORepresentativeClientVw.SupervisorUserId), UserId))
            ////                            .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

            ////                ctr.Add(Expression.InSubQuery(nameof(BOClientVw.ClientId), clients));
            ////            }

            ////            if (this.AppRoleId == 7)
            ////            {
            ////                // get by Sales Rep

            ////                var clients = new Criteria<BORepresentativeClientVw>()
            ////                       .Add(Expression.Eq(nameof(BORepresentativeClientVw.RepresentativeUserId), UserId))
            ////                       .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

            ////                ctr.Add(Expression.InSubQuery(nameof(BOClientVw.ClientId), clients));

            ////            }
            ////        }

            ////        // get by ClientCode
            ////        if (!string.IsNullOrEmpty(searchModel.ClientCode))
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.ClientCode), searchModel.ClientCode));

            ////        // get by model
            ////        if (!string.IsNullOrEmpty(searchModel.Phone))
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.Phone), searchModel.Phone));
            ////        if (!string.IsNullOrEmpty(searchModel.WhatsApp))
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.WhatsApp), searchModel.WhatsApp));
            ////        if (!string.IsNullOrEmpty(searchModel.Mobile))
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.Mobile), searchModel.Mobile));

            ////        if (!string.IsNullOrEmpty(searchModel.TaxCode))
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.TaxCode), searchModel.TaxCode));


            ////        if (!string.IsNullOrEmpty(searchModel.CommercialCode))
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.CommercialCode), searchModel.CommercialCode));

            ////        if (searchModel.IsActive >0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.IsActive), searchModel.IsActive==1?true:false));

            ////        if (searchModel.IsTaxable > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.IsTaxable), searchModel.IsTaxable == 1 ? true : false));

            ////        if (searchModel.IsChain > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.IsChain), searchModel.IsChain == 1 ? true : false));

            ////        if (searchModel.LocationLevelId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.LocationLevelId), searchModel.LocationLevelId));

            ////        if (searchModel.ClientClassificationId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.ClientClassificationId), searchModel.ClientClassificationId));


            ////        if (searchModel.PaymentTermId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.PaymentTermId), searchModel.PaymentTermId));

            ////        if (searchModel.BranchId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.BranchId), searchModel.BranchId));

            ////        if (searchModel.ClientTypeId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.ClientTypeId), searchModel.ClientTypeId));

            ////        if (searchModel.RegionId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.RegionId), searchModel.RegionId));

            ////        if (searchModel.GovernerateId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.GovernerateId), searchModel.GovernerateId));

            ////        if (searchModel.CityId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.CityId), searchModel.CityId));

            ////        if (searchModel.ClientGroupId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.ClientGroupId), searchModel.ClientGroupId));

            ////        if (searchModel.BusinessUnitId > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.BusinessUnitId), searchModel.BusinessUnitId));

            ////        if (searchModel.InRoute > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.InRoute), searchModel.InRoute==1?true:false));

            ////        if (searchModel.NeedValidation > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.NeedValidation), searchModel.NeedValidation == 1 ? true : false));

            ////        if (searchModel.IsNew > 0)
            ////            ctr.Add(Expression.Eq(nameof(BOClientVw.IsNew), searchModel.IsNew == 1 ? true : false));

            ////        // sort by 
            ////        if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
            ////        {
            ////            switch (searchModel.SortBy.Property)
            ////            {
            ////                case "clientName":
            ////                    ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
            ////                    break;
            ////                case "branchName":
            ////                    ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
            ////                    break;
            ////                case "clientTypeName":
            ////                    ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientTypeName{0}", Language)) : OrderBy.Desc(string.Format("clientTypeName{0}", Language)));
            ////                    break;
            ////                case "governerateName":
            ////                    ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("governerateName{0}", Language)) : OrderBy.Desc(string.Format("governerateName{0}", Language)));
            ////                    break;
            ////                case "cityName":
            ////                    ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("cityName{0}", Language)) : OrderBy.Desc(string.Format("cityName{0}", Language)));
            ////                    break;
            ////                case "businessUnitName":
            ////                    ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("BusinessUnitName{0}", Language)) : OrderBy.Desc(string.Format("BusinessUnitName{0}", Language)));
            ////                    break;
            ////                case "clientGroupName":
            ////                    ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientGroupName{0}", Language)) : OrderBy.Desc(string.Format("clientGroupName{0}", Language)));
            ////                    break;
            ////                case "clientGroupSubName":
            ////                    ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientGroupSubName{0}", Language)) : OrderBy.Desc(string.Format("clientGroupSubName{0}", Language)));
            ////                    break;
            ////                default:
            ////                    ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
            ////                    break;
            ////            }
            ////        }
            ////        else
            ////        {
            ////            ctr.Add(OrderBy.Desc(nameof(BOClientVw.ClientId)));
            ////        }

            ////        // get count

            ////        var Total = ctr.Count();

            ////        // get paged

            ////        var res = ctr.Skip(searchModel.Skip)
            ////                     .Take(searchModel.Take)
            ////                     .List<BOClientVw>().Select(a => new ClientListModel()
            ////                     {
            ////                         BranchCode = a.BranchCode,

            ////                         ClientAccountId = a.ClientAccountId,
            ////                         ClientCode = a.ClientCode,
            ////                         ClientId = a.ClientId.Value,
            ////                         Latitude = a.Latitude,
            ////                         Longitude = a.Longitude,
            ////                         CreditBalance = a.CreditBalance,
            ////                         CreditLimit = a.CreditLimit,
            ////                         IsActive = a.IsActive,
            ////                         IsTaxable = a.IsTaxable,
            ////                         Mobile = a.Mobile,
            ////                         Phone = a.Phone,
            ////                         WhatsApp = a.WhatsApp,
            ////                         BranchId = a.BranchId,
            ////                         CityId = a.CityId,
            ////                         ClientClassificationId = a.ClientClassificationId,
            ////                         ClientGroupId = a.ClientGroupId,
            ////                         ClientGroupSubId = a.ClientGroupSubId,
            ////                         ClientTypeId = a.ClientTypeId,
            ////                         GovernerateId = a.GovernerateId,
            ////                         PaymentTermId = a.PaymentTermId,
            ////                         RegionId = a.RegionId,
            ////                         BusinessUnitCode = a.BusinessUnitCode,
            ////                         BusinessUnitId = a.BusinessUnitId,
            ////                         CashGroupId = a.CashGroupId,
            ////                         CityCode = a.CityCode,
            ////                         ClientGroupCode = a.ClientGroupCode,
            ////                         ClientGroupSubCode = a.ClientGroupSubCode,
            ////                         InRoute = a.InRoute,
            ////                         CommercialCode = a.CommercialCode,
            ////                         GovernerateCode = a.GovernerateCode,
            ////                         IsCashDiscount = a.IsCashDiscount,
            ////                         LocationLevelId = a.LocationLevelId,
            ////                         NeedValidation = a.NeedValidation,
            ////                         TaxCode = a.TaxCode,
            ////                         IsChain=a.IsChain,
            ////                         IsNew=a.IsNew,

            ////                         BusinessUnitName = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,
            ////                         ClientGroupName = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn,
            ////                         ClientGroupSubName = Language == "ar" ? a.ClientGroupSubNameAr : a.ClientGroupSubNameEn,
            ////                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
            ////                         ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
            ////                         ClientTypeName = Language == "ar" ? a.ClientTypeNameAr : a.ClientTypeNameEn,
            ////                         GovernerateName = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,
            ////                         CityName = Language == "ar" ? a.CityNameAr : a.CityNameEn,

            ////                     }).ToList();
            ////        responseModel.Data = res;
            ////        responseModel.Total = Total;

            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        responseModel.Succeeded = false;
            ////        responseModel.StatusCode = 500;
            ////        responseModel.Message = ex.Message;;
            ////    }

            ////    return responseModel;

            ////});
            ////await task;

            ////return Ok(task.Result);
            ///

                ResponseModel<List<ClientListModel>> responseModel = new ResponseModel<List<ClientListModel>>();

                try
                {


                var res = _clientManager.filter(searchModel,UserId,AppRoleId,this.Branchs);
                // get count
                var Total = res.Count()>0 ? res.FirstOrDefault().pageCount : 0;



                 res = res.Select(a => new ClientListModel()
                                     {
                                         BranchCode = a.BranchCode,

                                         ClientAccountId = a.ClientAccountId,
                                         ClientCode = a.ClientCode,
                                         ClientId = a.ClientId.Value,
                                         Latitude = a.Latitude,
                                         Longitude = a.Longitude,
                                         CreditBalance = a.CreditBalance,
                                         CreditLimit = a.CreditLimit,
                                         IsActive = a.IsActive,
                                         IsTaxable = a.IsTaxable,
                                         Mobile = a.Mobile,
                                         Phone = a.Phone,
                                         WhatsApp = a.WhatsApp,
                                         BranchId = a.BranchId,
                                         CityId = a.CityId,
                                         ClientClassificationId = a.ClientClassificationId,
                                         ClientGroupId = a.ClientGroupId,
                                         ClientGroupSubId = a.ClientGroupSubId,
                                         ClientTypeId = a.ClientTypeId,
                                         GovernerateId = a.GovernerateId,
                                         PaymentTermId = a.PaymentTermId,
                                         RegionId = a.RegionId,
                                         BusinessUnitCode = a.BusinessUnitCode,
                                         BusinessUnitId = a.BusinessUnitId,
                                         CashGroupId = a.CashGroupId,
                                         CityCode = a.CityCode,
                                         ClientGroupCode = a.ClientGroupCode,
                                         ClientGroupSubCode = a.ClientGroupSubCode,
                                         InRoute = a.InRoute,
                                         CommercialCode = a.CommercialCode,
                                         GovernerateCode = a.GovernerateCode,
                                         IsCashDiscount = a.IsCashDiscount,
                                         LocationLevelId = a.LocationLevelId,
                                         NeedValidation = a.NeedValidation,
                                         TaxCode = a.TaxCode,
                                         IsChain=a.IsChain,
                                         IsNew=a.IsNew,

                                         BusinessUnitName = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,
                                         ClientGroupName = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn,
                                         ClientGroupSubName = Language == "ar" ? a.ClientGroupSubNameAr : a.ClientGroupSubNameEn,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                         ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                         ClientTypeName = Language == "ar" ? a.ClientTypeNameAr : a.ClientTypeNameEn,
                                         GovernerateName = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,
                                         CityName = Language == "ar" ? a.CityNameAr : a.CityNameEn,

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

               
          

            return Ok(responseModel);
        }

        [CheckAuthorizedAttribute]
        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientModel> responseModel = new ResponseModel<ClientModel>();

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

                        var exist = new Criteria<BOClient>()
                                       .Add(Expression.Eq(nameof(BOClient.ClientId), Id))
                                       .FirstOrDefault<BOClient>();

                        if (exist != null)
                        {
                            // update current

                            responseModel.Data = _mapper.Map<ClientModel>(exist);


                            responseModel.Data.PreferredTimes = new Criteria<BOClientPreferredTimeVw>()
                                            .Add(Expression.Eq(nameof(BOClientPreferredTimeVw.ClientId), Id))
                                            .List<BOClientPreferredTimeVw>()
                                            .Select(a => new ClientPreferredTimeListModel()
                                            {

                                                ClientId = a.ClientId,
                                                FromTime = a.FromTime,
                                                PreferredId = a.PreferredId.Value,
                                                PreferredOperationId = a.PreferredOperationId,

                                                ToTime = a.ToTime,
                                                WeekDayId = a.WeekDayId,

                                                WeekDayName = Language == "ar" ? a.WeekDayNameAr : a.WeekDayNameEn,
                                                PreferredOperationName = Language == "ar" ? a.PreferredOperationNameAr : a.PreferredOperationNameEn,

                                            }).ToList();

                            responseModel.Data.Landmarks = new Criteria<BOClientLandmarkVw>()
                                           .Add(Expression.Eq(nameof(BOClientLandmarkVw.ClientId), Id))
                                           .List<BOClientLandmarkVw>()
                                           .Select(a => new ClientLandmarkListModel()
                                           {
                                               DetaillandId = a.DetaillandId.Value,
                                               ClientId = a.ClientId.Value,
                                               LandmarkId = a.LandmarkId.Value,
                                               LandmarkName = Language == "ar" ? a.LandmarkNameAr : a.LandmarkNameEn,

                                           }).ToList();

                            responseModel.Data.Documents = new Criteria<BOClientDocumentVw>()
                                       .Add(Expression.Eq(nameof(BOClientDocumentVw.ClientId), Id))
                                       .List<BOClientDocumentVw>()
                                       .Select(a => new ClientDocumentListModel()
                                       {
                                           ClientId = a.ClientId.Value,
                                           ClientDocumentId = a.ClientDocumentId.Value,
                                           DocumentExt = a.DocumentExt,
                                           DocumentPath = _configuration["filesUrl"] + a.DocumentPath,
                                           DocumentSize = a.DocumentSize,
                                           DocumentTypeId = a.DocumentTypeId,
                                           UploadDate = a.UploadDate,
                                           DocumentTypeName = Language == "ar" ? a.DocumentTypeNameAr : a.DocumentTypeNameEn,

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
        public async Task<IActionResult> save(ClientModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientModel> responseModel = new ResponseModel<ClientModel>();

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
                        var exist = new Criteria<BOClient>()
                                        .Add(Expression.Eq(nameof(model.ClientId), model.ClientId))
                                        .FirstOrDefault<BOClient>();


                        if (exist == null)
                        {



                            // create new
                            exist = new BOClient();
                            exist.BranchId=model.BranchId;
                            exist.ClientAccountId = null;
                            exist.ClientCode = model.ClientCode;
                            exist.ClientGroupId=model.ClientGroupId;
                            exist.ClientGroupSubId = model.ClientGroupSubId;
                            exist.ClientClassificationId = model.ClientClassificationId;
                            exist.CreditLimit = 0;
                            exist.CreditBalance = 0;
                            exist.PaymentTermId = model.PaymentTermId;
                            exist.IsTaxable=model.IsTaxable;
                            exist.IsActive = model.IsActive;

                            exist.ClientTypeId = model.ClientTypeId;
                            exist.ClientNameAr = model.ClientNameAr;
                            exist.ClientNameEn = model.ClientNameEn;

                            exist.RegionId = 1;
                            exist.GovernerateId = model.GovernerateId;
                            exist.CityId = model.CityId;
                            exist.LocationLevelId = model.LocationLevelId;
                            exist.IsChain = model.IsChain;
                            exist.ResponsibleNameEn = model.ResponsibleNameEn;
                            exist.ResponsibleNameAr = model.ResponsibleNameAr;
                            exist.Building = model.Building;
                            exist.Floor = model.Floor;
                            exist.Property = model.Property;
                            exist.Address = model.Address;
                            exist.Landmark = model.Landmark;
                            exist.Phone = model.Phone;
                            exist.Mobile = model.Mobile;
                            exist.WhatsApp = model.WhatsApp;
                            exist.Latitude = model.Latitude;
                            exist.Longitude = model.Longitude;
                            exist.TaxCode = model.TaxCode;
                            exist.CommercialCode = model.CommercialCode;

                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;


                            exist.SaveNew();

                            if (exist.ClientId > 0)
                            {
                                model.ClientId = exist.ClientId.Value;

                                // add landmark
                                foreach (var item in model.Landmarks)
                                {
                                    var bo = new BOClientLandmark();

                                    bo.ClientId = model.ClientId;
                                    bo.LandmarkId = item.LandmarkId;
                                    bo.SaveNew();

                                }


                                // add docments
                                foreach (var item in model.Documents)
                                {
                                    var bo = new BOClientDocument();

                                    bo.ClientId = model.ClientId;
                                    bo.DocumentTypeId = item.DocumentTypeId;
                                    bo.DocumentPath = item.DocumentPath.Replace(_configuration["filesUrl"], "");
                                    bo.UploadDate = DateTime.Now;
                                    bo.DocumentExt = System.IO.Path.GetExtension(bo.DocumentPath);
                                    bo.DocumentSize = item.DocumentSize;

                                    bo.SaveNew();

                                }

                                // add Preferred
                                foreach (var item in model.PreferredTimes)
                                {
                                    var bo = new BOClientPreferredTime();

                                    bo.ClientId = model.ClientId;
                                    bo.PreferredOperationId = item.PreferredOperationId;
                                    bo.WeekDayId = item.WeekDayId;
                                    bo.FromTime = item.FromTime;
                                    bo.ToTime = item.ToTime;

                                    bo.SaveNew();

                                }

                            }



                        }
                        else
                        {
                            exist.ClientAccountId = null;
                            exist.ClientGroupId = model.ClientGroupId;
                            exist.ClientGroupSubId = model.ClientGroupSubId;
                            exist.ClientClassificationId = model.ClientClassificationId;
                            exist.PaymentTermId = model.PaymentTermId;
                            exist.IsTaxable = model.IsTaxable;
                            exist.IsActive = model.IsActive;

                            exist.ClientTypeId = model.ClientTypeId;
                            exist.ClientNameAr = model.ClientNameAr;
                            exist.ClientNameEn = model.ClientNameEn;

                            exist.RegionId = 1;
                            exist.GovernerateId = model.GovernerateId;
                            exist.CityId = model.CityId;
                            exist.LocationLevelId = model.LocationLevelId;
                            exist.IsChain = model.IsChain;
                            exist.ResponsibleNameEn = model.ResponsibleNameEn;
                            exist.ResponsibleNameAr = model.ResponsibleNameAr;
                            exist.Building = model.Building;
                            exist.Floor = model.Floor;
                            exist.Property = model.Property;
                            exist.Address = model.Address;
                            exist.Landmark = model.Landmark;
                            exist.Phone = model.Phone;
                            exist.Mobile = model.Mobile;
                            exist.WhatsApp = model.WhatsApp;
                            exist.Latitude = model.Latitude;
                            exist.Longitude = model.Longitude;
                            exist.TaxCode = model.TaxCode;
                            exist.CommercialCode = model.CommercialCode;

                            exist.EBy = UserId;
                            exist.EDate = DateTime.Now;


                            exist.Update();

                            if (exist.ClientId > 0)
                            {
                                model.ClientId = exist.ClientId.Value;
                                // add landmark
                                exist.DeleteAllClientLandmark();
                                // add docments
                                exist.DeleteAllClientDocument();
                                // add Preferred
                                exist.DeleteAllClientPreferredTime();

                                foreach (var item in model.Landmarks)
                                {
                                    var bo = new BOClientLandmark();

                                    bo.ClientId = model.ClientId;
                                    bo.LandmarkId = item.LandmarkId;
                                    bo.SaveNew();

                                }


                                // add docments
                                foreach (var item in model.Documents)
                                {
                                    var bo = new BOClientDocument();

                                    bo.ClientId = model.ClientId;
                                    bo.DocumentTypeId = item.DocumentTypeId;
                                    bo.DocumentPath = item.DocumentPath.Replace(_configuration["filesUrl"], "");
                                    bo.UploadDate = DateTime.Now;
                                    bo.DocumentExt = System.IO.Path.GetExtension(bo.DocumentPath);
                                    bo.DocumentSize = item.DocumentSize;

                                    bo.SaveNew();

                                }

                                // add Preferred
                                foreach (var item in model.PreferredTimes)
                                {
                                    var bo = new BOClientPreferredTime();

                                    bo.ClientId = model.ClientId;
                                    bo.PreferredOperationId = item.PreferredOperationId;
                                    bo.WeekDayId = item.WeekDayId;
                                    bo.FromTime = item.FromTime;
                                    bo.ToTime = item.ToTime;

                                    bo.SaveNew();

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
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("SaveBasic")]
        public async Task<IActionResult> SaveBasic(ClientModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientModel> responseModel = new ResponseModel<ClientModel>();

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
                        var exist = new Criteria<BOClient>()
                                        .Add(Expression.Eq(nameof(model.ClientId), model.ClientId))
                                        .FirstOrDefault<BOClient>();


                        if (exist != null)
                        {
                            exist.BusinessUnitId = model.BusinessUnitId > 0 ? model.BusinessUnitId : null;
                            exist.ClientNameAr = model.ClientNameAr;
                            exist.ClientNameEn = model.ClientNameEn;
                            exist.ResponsibleNameEn = model.ResponsibleNameEn;
                            exist.ResponsibleNameAr = model.ResponsibleNameAr;
                            exist.ClientGroupId = model.ClientGroupId > 0 ? model.ClientGroupId : null;
                            exist.ClientGroupSubId = model.ClientGroupSubId > 0 ? model.ClientGroupSubId : null;
                            exist.ClientClassificationId = model.ClientClassificationId>0?model.ClientClassificationId : null;
                            exist.ClientTypeId = model.ClientTypeId > 0 ? model.ClientTypeId : null;
                            exist.IsActive = model.IsActive;
                            exist.IsChain = model.IsChain;
                            exist.TaxCode = model.TaxCode;
                            exist.CommercialCode = model.CommercialCode;
                            exist.IsNew = false;
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


        [CheckAuthorizedAttribute]
        [HttpPost("SaveContacts")]
        public async Task<IActionResult> SaveContacts(ClientModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientModel> responseModel = new ResponseModel<ClientModel>();

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
                        var exist = new Criteria<BOClient>()
                                        .Add(Expression.Eq(nameof(model.ClientId), model.ClientId))
                                        .FirstOrDefault<BOClient>();


                        if (exist != null)
                        {
                            exist.Phone = model.Phone;
                            exist.WhatsApp = model.WhatsApp;
                            exist.Mobile = model.Mobile;

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


        [CheckAuthorizedAttribute]
        [HttpPost("SaveAddress")]
        public async Task<IActionResult> SaveAddress(ClientModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientModel> responseModel = new ResponseModel<ClientModel>();

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
                        var exist = new Criteria<BOClient>()
                                        .Add(Expression.Eq(nameof(model.ClientId), model.ClientId))
                                        .FirstOrDefault<BOClient>();


                        if (exist != null)
                        {

                            exist.LocationLevelId = model.LocationLevelId>0?model.LocationLevelId:null;

                            exist.Address = model.Address;
                            exist.Landmark = model.Landmark;
                            exist.Building = model.Building;
                            exist.Floor = model.Floor;
                            exist.Property = model.Property;
                            exist.Latitude = model.Latitude;
                            exist.Longitude = model.Longitude;

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


        [CheckAuthorizedAttribute]
        [HttpPost("SaveLandMarks")]
        public async Task<IActionResult> SaveLandMarks(ClientModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientModel> responseModel = new ResponseModel<ClientModel>();

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
                        var exist = new Criteria<BOClient>()
                                        .Add(Expression.Eq(nameof(model.ClientId), model.ClientId))
                                        .FirstOrDefault<BOClient>();


                        if (exist != null)
                        {
                            exist.DeleteAllClientLandmark();   
                            // add landmark
                            foreach (var item in model.Landmarks)
                            {
                                var bo = new BOClientLandmark();

                                bo.ClientId = model.ClientId;
                                bo.LandmarkId = item.LandmarkId;
                                bo.SaveNew();

                            }

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

        [CheckAuthorizedAttribute]
        [HttpPost("SavePrefferds")]
        public async Task<IActionResult> SavePrefferds(ClientModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientModel> responseModel = new ResponseModel<ClientModel>();

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
                        var exist = new Criteria<BOClient>()
                                        .Add(Expression.Eq(nameof(model.ClientId), model.ClientId))
                                        .FirstOrDefault<BOClient>();


                        if (exist != null)
                        {
                            exist.DeleteAllClientPreferredTime();

                            // add Preferred
                            foreach (var item in model.PreferredTimes)
                            {
                                var bo = new BOClientPreferredTime();

                                bo.ClientId = model.ClientId;
                                bo.PreferredOperationId = item.PreferredOperationId;
                                bo.WeekDayId = item.WeekDayId;
                                bo.FromTime = item.FromTime;
                                bo.ToTime = item.ToTime;

                                bo.SaveNew();

                            }
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

        [CheckAuthorizedAttribute]
        [HttpPost("SaveDocuments")]
        public async Task<IActionResult> SaveDocuments(ClientModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientModel> responseModel = new ResponseModel<ClientModel>();

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
                        var exist = new Criteria<BOClient>()
                                        .Add(Expression.Eq(nameof(model.ClientId), model.ClientId))
                                        .FirstOrDefault<BOClient>();


                        if (exist != null)
                        {
                            exist.DeleteAllClientDocument();

                            // add docments
                            foreach (var item in model.Documents)
                            {
                                var bo = new BOClientDocument();

                                bo.ClientId = model.ClientId;
                                bo.DocumentTypeId = item.DocumentTypeId;
                                bo.DocumentPath = item.DocumentPath.Replace(_configuration["filesUrl"], "");
                                bo.UploadDate = DateTime.Now;
                                bo.DocumentExt = System.IO.Path.GetExtension(bo.DocumentPath);
                                bo.DocumentSize = item.DocumentSize;

                                bo.SaveNew();

                            }
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

        [CheckAuthorizedAttribute]
        [HttpPost("Status")]
        public async Task<IActionResult> Status(ClientModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientModel> responseModel = new ResponseModel<ClientModel>();

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
                        var exist = new Criteria<BOClient>()
                                        .Add(Expression.Eq(nameof(model.ClientId), model.ClientId))
                                        .FirstOrDefault<BOClient>();


                        if (exist != null)
                        {

                            exist.IsActive = model.IsActive;
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
        public async Task<IActionResult> export(ClientSearchModel searchModel)
        {
            try
            {


                var ctr = new Criteria<BOClientVw>();

                // get by term
                if (!string.IsNullOrEmpty(searchModel.Term))
                {

                    if (!string.IsNullOrEmpty(searchModel.TermBy))
                    {
                        switch (searchModel.TermBy)
                        {
                            case "clientCode":
                                ctr.Add(Expression.StartWith(nameof(BOClientVw.ClientCode), searchModel.Term));
                                break;
                            case "clientNameAr":
                                ctr.Add(Expression.StartWith(nameof(BOClientVw.ClientNameAr), searchModel.Term));
                                break;
                            case "clientNameEn":
                                ctr.Add(Expression.StartWith(nameof(BOClientVw.ClientNameEn), searchModel.Term));
                                break;
                            default:
                                break;
                        }
                    }

                }


                if (this.FullDataAccess == false)
                {
                    ctr.Add(Expression.In(nameof(BOClientVw.BranchId), this.Branchs));

                    //if (this.AppRoleId == 6)
                    //{
                    //    // get By Suppervisor
                    //    var clients = new Criteria<BORepresentativeJourneyVw>()
                    //                .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.SuppervisorUserId), UserId))
                    //                .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.JourneyYear), DateTime.Now.Year))
                    //                .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.JourneyMonth), DateTime.Now.Month))
                    //                .Add(new Projection(nameof(BORepresentativeJourneyVw.ClientId)));

                    //    ctr.Add(Expression.InSubQuery(nameof(BORepresentativeJourneyVw.ClientId), clients));
                    //}

                    //if (this.AppRoleId == 7)
                    //{
                    //    // get by Sales Rep

                    //    var clients = new Criteria<BORepresentativeJourneyVw>()
                    //            .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.ReprestitiveUserId), UserId))
                    //            .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.JourneyYear), DateTime.Now.Year))
                    //            .Add(Expression.Eq(nameof(BORepresentativeJourneyVw.JourneyMonth), DateTime.Now.Month))
                    //            .Add(new Projection(nameof(BORepresentativeJourneyVw.ClientId)));

                    //    ctr.Add(Expression.InSubQuery(nameof(BORepresentativeJourneyVw.ClientId), clients));

                    //}
                }

                // get by ClientCode
                if (!string.IsNullOrEmpty(searchModel.ClientCode))
                    ctr.Add(Expression.Eq(nameof(BOClientVw.ClientCode), searchModel.ClientCode));

                // get by model
                if (!string.IsNullOrEmpty(searchModel.Phone))
                    ctr.Add(Expression.Eq(nameof(BOClientVw.Phone), searchModel.Phone));
                if (!string.IsNullOrEmpty(searchModel.WhatsApp))
                    ctr.Add(Expression.Eq(nameof(BOClientVw.WhatsApp), searchModel.WhatsApp));
                if (!string.IsNullOrEmpty(searchModel.Mobile))
                    ctr.Add(Expression.Eq(nameof(BOClientVw.Mobile), searchModel.Mobile));

                if (!string.IsNullOrEmpty(searchModel.TaxCode))
                    ctr.Add(Expression.Eq(nameof(BOClientVw.TaxCode), searchModel.TaxCode));


                if (!string.IsNullOrEmpty(searchModel.CommercialCode))
                    ctr.Add(Expression.Eq(nameof(BOClientVw.CommercialCode), searchModel.CommercialCode));

                if (searchModel.IsActive > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.IsActive), searchModel.IsActive == 1 ? true : false));

                if (searchModel.IsTaxable > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.IsTaxable), searchModel.IsTaxable == 1 ? true : false));

                if (searchModel.IsChain > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.IsChain), searchModel.IsChain == 1 ? true : false));

                if (searchModel.LocationLevelId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.LocationLevelId), searchModel.LocationLevelId));

                if (searchModel.ClientClassificationId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.ClientClassificationId), searchModel.ClientClassificationId));


                if (searchModel.PaymentTermId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.PaymentTermId), searchModel.PaymentTermId));

                if (searchModel.BranchId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.BranchId), searchModel.BranchId));

                if (searchModel.ClientTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.ClientTypeId), searchModel.ClientTypeId));

                if (searchModel.RegionId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.RegionId), searchModel.RegionId));

                if (searchModel.GovernerateId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.GovernerateId), searchModel.GovernerateId));

                if (searchModel.CityId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.CityId), searchModel.CityId));

                if (searchModel.ClientGroupId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.ClientGroupId), searchModel.ClientGroupId));

                if (searchModel.BusinessUnitId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.BusinessUnitId), searchModel.BusinessUnitId));

                if (searchModel.InRoute > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.InRoute), searchModel.InRoute == 1 ? true : false));

                if (searchModel.NeedValidation > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.NeedValidation), searchModel.NeedValidation == 1 ? true : false));

                if (searchModel.IsNew > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientVw.IsNew), searchModel.IsNew == 1 ? true : false));

                // sort by 
                if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                {
                    switch (searchModel.SortBy.Property)
                    {
                        case "clientName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                            break;
                        case "branchName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                            break;
                        case "clientTypeName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientTypeName{0}", Language)) : OrderBy.Desc(string.Format("clientTypeName{0}", Language)));
                            break;
                        case "governerateName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("governerateName{0}", Language)) : OrderBy.Desc(string.Format("governerateName{0}", Language)));
                            break;
                        case "cityName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("cityName{0}", Language)) : OrderBy.Desc(string.Format("cityName{0}", Language)));
                            break;
                        case "businessUnitName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("BusinessUnitName{0}", Language)) : OrderBy.Desc(string.Format("BusinessUnitName{0}", Language)));
                            break;
                        case "clientGroupName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientGroupName{0}", Language)) : OrderBy.Desc(string.Format("clientGroupName{0}", Language)));
                            break;
                        case "clientGroupSubName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientGroupSubName{0}", Language)) : OrderBy.Desc(string.Format("clientGroupSubName{0}", Language)));
                            break;
                        default:
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                            break;
                    }
                }
                else
                {
                    ctr.Add(OrderBy.Desc(nameof(BOClientVw.ClientId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOClientVw>().Select(a => new ClientListModel()
                             {
                                 BranchCode = a.BranchCode,

                                 ClientAccountId = a.ClientAccountId,
                                 ClientCode = a.ClientCode,
                                 ClientId = a.ClientId.Value,
                                 Latitude = a.Latitude,
                                 Longitude = a.Longitude,
                                 CreditBalance = a.CreditBalance,
                                 CreditLimit = a.CreditLimit,
                                 IsActive = a.IsActive,
                                 IsTaxable = a.IsTaxable,
                                 Mobile = a.Mobile,
                                 Phone = a.Phone,
                                 WhatsApp = a.WhatsApp,
                                 BranchId = a.BranchId,
                                 CityId = a.CityId,
                                 ClientClassificationId = a.ClientClassificationId,
                                 ClientGroupId = a.ClientGroupId,
                                 ClientGroupSubId = a.ClientGroupSubId,
                                 ClientTypeId = a.ClientTypeId,
                                 GovernerateId = a.GovernerateId,
                                 PaymentTermId = a.PaymentTermId,
                                 RegionId = a.RegionId,
                                 BusinessUnitCode = a.BusinessUnitCode,
                                 BusinessUnitId = a.BusinessUnitId,
                                 CashGroupId = a.CashGroupId,
                                 CityCode = a.CityCode,
                                 ClientGroupCode = a.ClientGroupCode,
                                 ClientGroupSubCode = a.ClientGroupSubCode,
                                 InRoute = a.InRoute,
                                 CommercialCode = a.CommercialCode,
                                 GovernerateCode = a.GovernerateCode,
                                 IsCashDiscount = a.IsCashDiscount,
                                 LocationLevelId = a.LocationLevelId,
                                 NeedValidation = a.NeedValidation,
                                 TaxCode = a.TaxCode,
                                 IsChain = a.IsChain,
                                 IsNew = a.IsNew,

                                 BusinessUnitName = Language == "ar" ? a.BusinessUnitNameAr : a.BusinessUnitNameEn,
                                 ClientGroupName = Language == "ar" ? a.ClientGroupNameAr : a.ClientGroupNameEn,
                                 ClientGroupSubName = Language == "ar" ? a.ClientGroupSubNameAr : a.ClientGroupSubNameEn,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                                 ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                 ClientTypeName = Language == "ar" ? a.ClientTypeNameAr : a.ClientTypeNameEn,
                                 GovernerateName = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,
                                 CityName = Language == "ar" ? a.CityNameAr : a.CityNameEn,

                             }).ToList();

                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {






                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "BranchName";
                        worksheet.Cell("B1").Value = "GovernerateName";
                        worksheet.Cell("C1").Value = "CityName";
                        worksheet.Cell("D1").Value = "ClientCode";
                        worksheet.Cell("E1").Value = "ClientName";
                        worksheet.Cell("F1").Value = "ClientTypeName";
                        worksheet.Cell("G1").Value = "IsActive";
                        worksheet.Cell("H1").Value = "Phone";
                        worksheet.Cell("I1").Value = "Mobile";
                        worksheet.Cell("J1").Value = "WhatsApp";
                        worksheet.Cell("K1").Value = "Latitude";
                        worksheet.Cell("L1").Value = "Longitude";

                        worksheet.Cell("M1").Value = "BusinessUnitName";
                        worksheet.Cell("N1").Value = "ClientGroupName";
                        worksheet.Cell("O1").Value = "ClientGroupSubName";
                        worksheet.Cell("P1").Value = "IsNew";
                        worksheet.Cell("Q1").Value = "NeedValidation";
                        worksheet.Cell("R1").Value = "InRoute";
                        worksheet.Cell("S1").Value = "TaxCode";
                        worksheet.Cell("T1").Value = "CommercialCode";
                        worksheet.Cell("U1").Value = "IsCashDiscount";




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

                        worksheet.Cell("J1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("J1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("K1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("K1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("L1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("L1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("M1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("M1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("N1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("N1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("O1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("O1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("P1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("P1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("Q1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("Q1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("R1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("R1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("S1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("S1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("T1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("T1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("U1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("U1").Style.Font.FontColor = XLColor.White;



                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].GovernerateName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].CityName;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].ClientTypeName;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].IsActive;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].Phone;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].Mobile;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].WhatsApp;
                            worksheet.Cell(string.Format("K{0}", i + 2)).Value = res[i].Latitude;
                            worksheet.Cell(string.Format("L{0}", i + 2)).Value = res[i].Longitude;


                            worksheet.Cell(string.Format("M{0}", i + 2)).Value = res[i].BusinessUnitName;
                            worksheet.Cell(string.Format("N{0}", i + 2)).Value = res[i].ClientGroupName;
                            worksheet.Cell(string.Format("O{0}", i + 2)).Value = res[i].ClientGroupSubName;
                            worksheet.Cell(string.Format("P{0}", i + 2)).Value = res[i].IsNew;
                            worksheet.Cell(string.Format("Q{0}", i + 2)).Value = res[i].NeedValidation;
                            worksheet.Cell(string.Format("R{0}", i + 2)).Value = res[i].InRoute;
                            worksheet.Cell(string.Format("S{0}", i + 2)).Value = res[i].TaxCode;
                            worksheet.Cell(string.Format("T{0}", i + 2)).Value = res[i].CommercialCode;
                            worksheet.Cell(string.Format("U{0}", i + 2)).Value = res[i].IsCashDiscount;


                        }

                        workbook.SaveAs(stream);
                        stream.Seek(0, SeekOrigin.Begin);

                        return this.File(
                            fileContents: stream.ToArray(),
                            contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
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
