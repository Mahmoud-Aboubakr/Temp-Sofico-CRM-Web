using AutoMapper;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;
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
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class ItemController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IItemManager _itemManager;
        public ItemController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration, IItemManager itemManager) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
            _itemManager = itemManager;
        }


        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(ItemSearchModel searchModel)
        {
            #region old code 
            //var task = Task.Factory.StartNew(() =>
            //{
            //    ResponseModel<List<ItemListModel>> responseModel = new ResponseModel<List<ItemListModel>>();


            //    if (model == null || model.StoreId == null || model.StoreId == 0)
            //    {

            //        responseModel.Succeeded = false;
            //        responseModel.Message = Messages.Invalid_Model;
            //        responseModel.StatusCode = 503;

            //    }
            //    else
            //    {
            //        try
            //        {


            //            var ctr = new Criteria<BOItemAvailablityVw>();

            //            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.StoreId), model.StoreId));

            //            // get by term
            //            if (!string.IsNullOrEmpty(model.Term))
            //            {

            //                if (!string.IsNullOrEmpty(model.TermBy))
            //                {
            //                    switch (model.TermBy)
            //                    {
            //                        case "itemCode":
            //                            ctr.Add(Expression.StartWith(nameof(BOItemAvailablityVw.ItemCode), model.Term));
            //                            break;
            //                        case "itemNameAr":
            //                            ctr.Add(Expression.StartWith(nameof(BOItemAvailablityVw.ItemNameAr), model.Term));
            //                            break;
            //                        case "itemNameEn":
            //                            ctr.Add(Expression.StartWith(nameof(BOItemAvailablityVw.ItemNameEn), model.Term));
            //                            break;
            //                        case "quantity":
            //                            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.Quantity), model.Term));
            //                            break;
            //                        case "clientPrice":
            //                            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.ClientPrice), model.Term));
            //                            break;
            //                        case "publicPrice":
            //                            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.PublicPrice), model.Term));
            //                            break;
            //                        case "discount":
            //                            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.Discount), model.Term));
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                }

            //            }

            //            // branch Permissions


            //            // get by model
            //            if (model.PublicPrice > 0)
            //                ctr.Add(Expression.Gt(nameof(BOItemAvailablityVw.PublicPrice), 0));
            //            if (model.ClientPrice > 0)
            //                ctr.Add(Expression.Gt(nameof(BOItemAvailablityVw.ClientPrice), 0));

            //            if (model.VendorId > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.VendorId), model.VendorId));

            //            if (model.IsNewStocked > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.IsNewStocked), model.IsNewStocked == 1 ? true : false));
            //            if (model.IsNewAdded > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.IsNewAdded), model.IsNewAdded == 1 ? true : false));
            //            if (model.HasPromotion > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.HasPromotion), model.HasPromotion == 1 ? true : false));


            //            // sort by 
            //            if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
            //            {
            //                switch (model.SortBy.Property)
            //                {
            //                    case "itemName":
            //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
            //                        break;
            //                    case "vendorName":
            //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("vendorName{0}", Language)) : OrderBy.Desc(string.Format("vendorName{0}", Language)));
            //                        break;
            //                    default:
            //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
            //                        break;
            //                }
            //            }
            //            else
            //            {
            //                ctr.Add(OrderBy.Desc(nameof(BOItemVw.ItemId)));
            //            }



            //            // get count

            //            var Total = ctr.Count();

            //            // get paged

            //            var res = ctr.Skip(model.Skip)
            //                         .Take(model.Take > 0 ? model.Take : 30)
            //                         .List<BOItemAvailablityVw>()
            //                         .Select(a => new ItemListModel()
            //                         {


            //                             ClientPrice = a.ClientPrice,
            //                             Discount = a.Discount,
            //                             HasPromotion = a.HasPromotion,
            //                             IsActive = a.IsActive,
            //                             IsLocal = a.IsLocal,
            //                             IsNewAdded = a.IsNewAdded,
            //                             IsNewStocked = a.IsNewStocked,
            //                             IsTaxable = a.IsTaxable,
            //                             ItemCode = a.ItemCode,
            //                             ItemGroupId = a.ItemGroupId,
            //                             ItemId = a.ItemId,
            //                             PublicPrice = a.PublicPrice,
            //                             VendorGroupId = a.VendorGroupId,
            //                             VendorId = a.VendorId,
            //                             UnitId = a.UnitId,
            //                             VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
            //                             ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
            //                             Quantity = a.Quantity>0?a.Quantity.Value:0,
            //                             Quota=a.Quota>0?a.Quota.Value:0,
            //                             VendorCode=a.VendorCode,


            //                         }).ToList();

            //            responseModel.Data = res;
            //            responseModel.Total = Total;


            //        }
            //        catch (Exception ex)
            //        {
            //            responseModel.Succeeded = false;
            //            responseModel.StatusCode = 500;
            //            responseModel.Message = ex.Message; ;
            //        }
            //    }

            //    return responseModel;

            //});
            //await task;

            //return Ok(task.Result);
            #endregion
            ResponseModel<List<ItemListModel>> responseModel = new ResponseModel<List<ItemListModel>>();
            try
            {
                string sortTermBy = string.Empty;
                if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                {
                    switch (searchModel.SortBy.Property)
                    {
                        case "itemName":
                            sortTermBy = string.Format("itemName{0}", Language);
                            break;
                        case "vendorName":
                            sortTermBy = string.Format("vendorName{0}", Language);
                            break;
                        default:
                            sortTermBy = searchModel.SortBy.Property;
                            break;
                    }
                }
                var res = _itemManager.filter(searchModel, sortTermBy);

                var Total = res.Count() > 0 ? res.FirstOrDefault().pageCount : 0;

                res = res.Select(a => new ItemListModel()
                {
                    AcceptDays = a.AcceptDays,
                    CanDelete = a.CanDelete,
                    CanEdit = a.CanEdit,
                    ClientPrice = a.ClientPrice,
                    Color = a.Color,
                    CreateDate = a.CreateDate,
                    Discount = a.Discount,
                    DisplayOrder = a.DisplayOrder,
                    HasPromotion = a.HasPromotion,
                    HasQuota = a.HasQuota,
                    Icon = a.Icon,
                    IsActive = a.IsActive,
                    IsLocal = a.IsLocal,
                    IsNewAdded = a.IsNewAdded,
                    IsNewStocked = a.IsNewStocked,
                    IsTaxable = a.IsTaxable,
                    ItemCode = a.ItemCode,
                    ItemGroupId = a.ItemGroupId,
                    ItemGroupName = a.ItemGroupName,
                    ItemId = a.ItemId,
                    ItemName = Language == "ar"? a.ItemNameAr : a.ItemNameEn,
                    LastStockDate = a.LastStockDate,
                    PublicPrice = a.PublicPrice,
                    Quantity = a.Quantity,
                    Quota = a.Quota,
                    UnitId = a.UnitId,
                    VendorCode = a.VendorCode,
                    VendorGroupId = a.VendorGroupId,
                    VendorId = a.VendorId,
                    VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn ,

                }).ToList();

                responseModel.Data = res;
                responseModel.Total = Total;

            }
            catch (Exception ex)
            {
                responseModel.Succeeded = false;
                responseModel.StatusCode = 500;
                responseModel.Message = ex.Message;
            }

            return Ok(await Task.FromResult(responseModel));



        }
        [CheckAuthorizedAttribute]
        [HttpPost("filterItem")]
        public async Task<IActionResult> filterItem(ItemSearchModel searchModel)
        {
            #region old code 
            //var task = Task.Factory.StartNew(() =>
            //{
            //    ResponseModel<List<ItemListModel>> responseModel = new ResponseModel<List<ItemListModel>>();


            //    if (model == null || model.StoreId == null || model.StoreId == 0)
            //    {

            //        responseModel.Succeeded = false;
            //        responseModel.Message = Messages.Invalid_Model;
            //        responseModel.StatusCode = 503;

            //    }
            //    else
            //    {
            //        try
            //        {


            //            var ctr = new Criteria<BOItemAvailablityVw>();

            //            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.StoreId), model.StoreId));

            //            // get by term
            //            if (!string.IsNullOrEmpty(model.Term))
            //            {

            //                if (!string.IsNullOrEmpty(model.TermBy))
            //                {
            //                    switch (model.TermBy)
            //                    {
            //                        case "itemCode":
            //                            ctr.Add(Expression.StartWith(nameof(BOItemAvailablityVw.ItemCode), model.Term));
            //                            break;
            //                        case "itemNameAr":
            //                            ctr.Add(Expression.StartWith(nameof(BOItemAvailablityVw.ItemNameAr), model.Term));
            //                            break;
            //                        case "itemNameEn":
            //                            ctr.Add(Expression.StartWith(nameof(BOItemAvailablityVw.ItemNameEn), model.Term));
            //                            break;
            //                        case "quantity":
            //                            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.Quantity), model.Term));
            //                            break;
            //                        case "clientPrice":
            //                            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.ClientPrice), model.Term));
            //                            break;
            //                        case "publicPrice":
            //                            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.PublicPrice), model.Term));
            //                            break;
            //                        case "discount":
            //                            ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.Discount), model.Term));
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                }

            //            }

            //            // branch Permissions


            //            // get by model
            //            if (model.PublicPrice > 0)
            //                ctr.Add(Expression.Gt(nameof(BOItemAvailablityVw.PublicPrice), 0));
            //            if (model.ClientPrice > 0)
            //                ctr.Add(Expression.Gt(nameof(BOItemAvailablityVw.ClientPrice), 0));

            //            if (model.VendorId > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.VendorId), model.VendorId));

            //            if (model.IsNewStocked > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.IsNewStocked), model.IsNewStocked == 1 ? true : false));
            //            if (model.IsNewAdded > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.IsNewAdded), model.IsNewAdded == 1 ? true : false));
            //            if (model.HasPromotion > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemAvailablityVw.HasPromotion), model.HasPromotion == 1 ? true : false));


            //            // sort by 
            //            if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
            //            {
            //                switch (model.SortBy.Property)
            //                {
            //                    case "itemName":
            //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
            //                        break;
            //                    case "vendorName":
            //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("vendorName{0}", Language)) : OrderBy.Desc(string.Format("vendorName{0}", Language)));
            //                        break;
            //                    default:
            //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
            //                        break;
            //                }
            //            }
            //            else
            //            {
            //                ctr.Add(OrderBy.Desc(nameof(BOItemVw.ItemId)));
            //            }



            //            // get count

            //            var Total = ctr.Count();

            //            // get paged

            //            var res = ctr.Skip(model.Skip)
            //                         .Take(model.Take > 0 ? model.Take : 30)
            //                         .List<BOItemAvailablityVw>()
            //                         .Select(a => new ItemListModel()
            //                         {


            //                             ClientPrice = a.ClientPrice,
            //                             Discount = a.Discount,
            //                             HasPromotion = a.HasPromotion,
            //                             IsActive = a.IsActive,
            //                             IsLocal = a.IsLocal,
            //                             IsNewAdded = a.IsNewAdded,
            //                             IsNewStocked = a.IsNewStocked,
            //                             IsTaxable = a.IsTaxable,
            //                             ItemCode = a.ItemCode,
            //                             ItemGroupId = a.ItemGroupId,
            //                             ItemId = a.ItemId,
            //                             PublicPrice = a.PublicPrice,
            //                             VendorGroupId = a.VendorGroupId,
            //                             VendorId = a.VendorId,
            //                             UnitId = a.UnitId,
            //                             VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
            //                             ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
            //                             Quantity = a.Quantity>0?a.Quantity.Value:0,
            //                             Quota=a.Quota>0?a.Quota.Value:0,
            //                             VendorCode=a.VendorCode,


            //                         }).ToList();

            //            responseModel.Data = res;
            //            responseModel.Total = Total;


            //        }
            //        catch (Exception ex)
            //        {
            //            responseModel.Succeeded = false;
            //            responseModel.StatusCode = 500;
            //            responseModel.Message = ex.Message; ;
            //        }
            //    }

            //    return responseModel;

            //});
            //await task;

            //return Ok(task.Result);
            #endregion
            ResponseModel<List<ItemListModel>> responseModel = new ResponseModel<List<ItemListModel>>();
            try
            {
                string sortTermBy = string.Empty;
                if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                {
                    switch (searchModel.SortBy.Property)
                    {
                        case "itemName":
                            sortTermBy = string.Format("itemName{0}", Language);
                            break;
                        case "vendorName":
                            sortTermBy = string.Format("vendorName{0}", Language);
                            break;
                        default:
                            sortTermBy = searchModel.SortBy.Property;
                            break;
                    }
                }
                var res = _itemManager.filterItem(searchModel, sortTermBy);

                var Total = res.Count() > 0 ? res.FirstOrDefault().pageCount : 0;

                res = res.Select(a => new ItemListModel()
                {
                    AcceptDays = a.AcceptDays,
                    CanDelete = a.CanDelete,
                    CanEdit = a.CanEdit,
                    ClientPrice = a.ClientPrice,
                    Color = a.Color,
                    CreateDate = a.CreateDate,
                    Discount = a.Discount,
                    DisplayOrder = a.DisplayOrder,
                    HasPromotion = a.HasPromotion,
                    HasQuota = a.HasQuota,
                    Icon = a.Icon,
                    IsActive = a.IsActive,
                    IsLocal = a.IsLocal,
                    IsNewAdded = a.IsNewAdded,
                    IsNewStocked = a.IsNewStocked,
                    IsTaxable = a.IsTaxable,
                    ItemCode = a.ItemCode,
                    ItemGroupId = a.ItemGroupId,
                    ItemGroupName = a.ItemGroupName,
                    ItemId = a.ItemId,
                    ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                    LastStockDate = a.LastStockDate,
                    PublicPrice = a.PublicPrice,
                    Quantity = a.Quantity,
                    Quota = a.Quota,
                    UnitId = a.UnitId,
                    VendorCode = a.VendorCode,
                    VendorGroupId = a.VendorGroupId,
                    VendorId = a.VendorId,
                    VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,

                }).ToList();

                responseModel.Data = res;
                responseModel.Total = Total;

            }
            catch (Exception ex)
            {
                responseModel.Succeeded = false;
                responseModel.StatusCode = 500;
                responseModel.Message = ex.Message;
            }

            return Ok(await Task.FromResult(responseModel));
        }

        [CheckAuthorizedAttribute]
        [HttpPost("filterAll")]
        public async Task<IActionResult> filterAll(ItemSearchModel searchModel)
        {
            #region old code
            //var task = Task.Factory.StartNew(() =>
            //{
            //    ResponseModel<List<ItemListModel>> responseModel = new ResponseModel<List<ItemListModel>>();


            //    if (model == null)
            //    {

            //        responseModel.Succeeded = false;
            //        responseModel.Message = Messages.Invalid_Model;
            //        responseModel.StatusCode = 503;

            //    }
            //    else
            //    {
            //        try
            //        {


            //            var ctr = new Criteria<BOItemVw>();

            //            // get by term
            //            if (!string.IsNullOrEmpty(model.Term))
            //            {

            //                if (!string.IsNullOrEmpty(model.TermBy))
            //                {
            //                    switch (model.TermBy)
            //                    {
            //                        case "itemCode":
            //                            ctr.Add(Expression.StartWith(nameof(BOItemVw.ItemCode), model.Term));
            //                            break;
            //                        case "itemNameAr":
            //                            ctr.Add(Expression.StartWith(nameof(BOItemVw.ItemNameAr), model.Term));
            //                            break;
            //                        case "itemNameEn":
            //                            ctr.Add(Expression.StartWith(nameof(BOItemVw.ItemNameEn), model.Term));
            //                            break;

            //                        case "clientPrice":
            //                            ctr.Add(Expression.Eq(nameof(BOItemVw.ClientPrice), model.Term));
            //                            break;
            //                        case "publicPrice":
            //                            ctr.Add(Expression.Eq(nameof(BOItemVw.PublicPrice), model.Term));
            //                            break;
            //                        case "discount":
            //                            ctr.Add(Expression.Eq(nameof(BOItemVw.Discount), model.Term));
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                }

            //            }

            //            // branch Permissions


            //            // get by model
            //            if (model.PublicPrice > 0)
            //                ctr.Add(Expression.Gt(nameof(BOItemVw.PublicPrice), 0));
            //            if (model.ClientPrice > 0)
            //                ctr.Add(Expression.Gt(nameof(BOItemVw.ClientPrice), 0));

            //            if (model.VendorId > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemVw.VendorId), model.VendorId));

            //            if (model.IsNewStocked > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemVw.IsNewStocked), model.IsNewStocked == 1 ? true : false));
            //            if (model.IsNewAdded > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemVw.IsNewAdded), model.IsNewAdded == 1 ? true : false));
            //            if (model.HasPromotion > 0)
            //                ctr.Add(Expression.Eq(nameof(BOItemVw.HasPromotion), model.HasPromotion == 1 ? true : false));


            //            // sort by 
            //            if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
            //            {
            //                switch (model.SortBy.Property)
            //                {
            //                    case "itemName":
            //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
            //                        break;
            //                    case "vendorName":
            //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("vendorName{0}", Language)) : OrderBy.Desc(string.Format("vendorName{0}", Language)));
            //                        break;
            //                    default:
            //                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
            //                        break;
            //                }
            //            }
            //            else
            //            {
            //                ctr.Add(OrderBy.Desc(nameof(BOItemVw.ItemId)));
            //            }



            //            // get count

            //            var Total = ctr.Count();

            //            // get paged

            //            var res = ctr.Skip(model.Skip)
            //                         .Take(model.Take > 0 ? model.Take : 30)
            //                         .List<BOItemVw>()
            //                         .Select(a => new ItemListModel()
            //                         {


            //                             ClientPrice = a.ClientPrice,
            //                             Discount = a.Discount,
            //                             HasPromotion = a.HasPromotion,
            //                             IsActive = a.IsActive,
            //                             IsLocal = a.IsLocal,
            //                             IsNewAdded = a.IsNewAdded,
            //                             IsNewStocked = a.IsNewStocked,
            //                             IsTaxable = a.IsTaxable,
            //                             ItemCode = a.ItemCode,
            //                             ItemGroupId = a.ItemGroupId,
            //                             ItemId = a.ItemId,
            //                             PublicPrice = a.PublicPrice,
            //                             VendorGroupId = a.VendorGroupId,
            //                             VendorId = a.VendorId,
            //                             UnitId = a.UnitId,
            //                             VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
            //                             ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,

            //                         }).ToList();

            //            responseModel.Data = res;
            //            responseModel.Total = Total;


            //        }
            //        catch (Exception ex)
            //        {
            //            responseModel.Succeeded = false;
            //            responseModel.StatusCode = 500;
            //            responseModel.Message = ex.Message; ;
            //        }
            //    }

            //    return responseModel;

            //});
            //await task;

            //return Ok(task.Result);
            #endregion
            ResponseModel<List<ItemListModel>> responseModel = new ResponseModel<List<ItemListModel>>();
            try
            {
                string sortTermBy = string.Empty;
                if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                {
                    switch (searchModel.SortBy.Property)
                    {
                        case "itemName":
                            sortTermBy = string.Format("itemName{0}", Language);
                            break;
                        case "vendorName":
                            sortTermBy = string.Format("vendorName{0}", Language);
                            break;
                        default:
                            sortTermBy = searchModel.SortBy.Property;
                            break;
                    }
                }
               var res = _itemManager.filterAllItem(searchModel, sortTermBy);

                var Total = res.Count() > 0 ? res.FirstOrDefault().pageCount : 0;

                res = res.Select(a => new ItemListModel()
                {

                    AcceptDays = a.AcceptDays,
                    CanDelete = a.CanDelete,
                    CanEdit = a.CanEdit,
                    ClientPrice = a.ClientPrice,
                    Color = a.Color,
                    CreateDate = a.CreateDate,
                    Discount = a.Discount,
                    DisplayOrder = a.DisplayOrder,
                    HasPromotion = a.HasPromotion,
                    HasQuota = a.HasQuota,
                    Icon = a.Icon,
                    IsActive = a.IsActive,
                    IsLocal = a.IsLocal,
                    IsNewAdded = a.IsNewAdded,
                    IsNewStocked = a.IsNewStocked,
                    IsTaxable = a.IsTaxable,
                    ItemCode = a.ItemCode,
                    ItemGroupId = a.ItemGroupId,
                    ItemGroupName = a.ItemGroupName,
                    ItemId = a.ItemId,
                    ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                    LastStockDate = a.LastStockDate,
                    PublicPrice = a.PublicPrice,
                    Quantity = a.Quantity,
                    Quota = a.Quota,
                    UnitId = a.UnitId,
                    VendorCode = a.VendorCode,
                    VendorGroupId = a.VendorGroupId,
                    VendorId = a.VendorId,
                    VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,

                }).ToList();

                responseModel.Data = res;
                responseModel.Total = Total;

            }
            catch (Exception ex)
            {
                responseModel.Succeeded = false;
                responseModel.StatusCode = 500;
                responseModel.Message = ex.Message;
            }

            return Ok(await Task.FromResult(responseModel));
        }


        [CheckAuthorizedAttribute]
        [HttpPost("BatchChecker")]
        public async Task<IActionResult> BatchChecker(BatchCheckerSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ItemBatchCheckerListModel>> responseModel = new ResponseModel<List<ItemBatchCheckerListModel>>();


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


                        var ctr = new Criteria<BOItemBatchCheckerVw>();

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {

                            if (!string.IsNullOrEmpty(model.TermBy))
                            {
                                switch (model.TermBy)
                                {
                                    case "itemCode":
                                        ctr.Add(Expression.StartWith(nameof(BOItemBatchCheckerVw.ItemCode), model.Term));
                                        break;
                                    case "BatchNo":
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.BatchNo), model.Term));
                                        break;
                                    case "itemNameAr":
                                        ctr.Add(Expression.StartWith(nameof(BOItemBatchCheckerVw.ItemNameAr), model.Term));
                                        break;
                                    case "itemNameEn":
                                        ctr.Add(Expression.StartWith(nameof(BOItemBatchCheckerVw.ItemNameEn), model.Term));
                                        break;

                                    case "clientPrice":
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.ClientPrice), model.Term));
                                        break;
                                    case "publicPrice":
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.PublicPrice), model.Term));
                                        break;
                                    case "discount":
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.Discount), model.Term));
                                        break;
                                    default:
                                        ctr.Add(Expression.Eq(nameof(BOItemBatchCheckerVw.BatchNo), model.Term));
                                        break;
                                }
                            }

                        }


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "itemName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
                                    break;
                                case "vendorName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("vendorName{0}", Language)) : OrderBy.Desc(string.Format("vendorName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOItemVw.ItemId)));
                        }



                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOItemBatchCheckerVw>()
                                     .Select(a => new ItemBatchCheckerListModel()
                                     {


                                         ClientPrice = a.ClientPrice,
                                         Discount = a.Discount,
                                         ItemCode = a.ItemCode,
                                         ItemId = a.ItemId,
                                         PublicPrice = a.PublicPrice,
                                         VendorId = a.VendorId,
                                         VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
                                         ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                                         BatchNo=a.BatchNo,
                                         Quota=a.Quota,
                                         VendorCode=a.VendorCode

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
        [HttpPost("itemPromotion")]
        public async Task<IActionResult> ItemPromotion(ItemPromotionAllSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ItemPromotionAllListModel>> responseModel = new ResponseModel<List<ItemPromotionAllListModel>>();


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


                        var ctr = new Criteria<BOItemPromotionAllVw>();

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {

                            if (!string.IsNullOrEmpty(model.TermBy))
                            {
                                switch (model.TermBy)
                                {
                                    case "itemCode":
                                        ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.ItemCode), model.Term));
                                        break;
                                    case "promotionCode":
                                        ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.PromotionCode), model.Term));
                                        break;
                                    case "itemNameAr":
                                        ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.ItemNameAr), model.Term));
                                        break;
                                    case "itemNameEn":
                                        ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.ItemNameEn), model.Term));
                                        break;
                                    default:
                                        break;
                                }
                            }

                        }

                        // branch Permissions


                        // get by model
                        if (model.ItemId > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemPromotionAllVw.ItemId), model.ItemId));

                        if (model.PromotionId > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemPromotionAllVw.PromotionId), model.PromotionId));
                        
                        if (!string.IsNullOrEmpty(model.PromotionCode) )
                            ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.PromotionCode), model.PromotionCode));

                        if (!string.IsNullOrEmpty(model.ItemCode))
                            ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.ItemCode), model.ItemCode));


                        if (model.IsActive > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemPromotionAllVw.IsActive), model.IsActive == 1 ? true : false));


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {
                                case "itemName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
                                    break;
                               
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOItemPromotionAllVw.ItemId)));
                        }



                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOItemPromotionAllVw>()
                                     .Select(a => new ItemPromotionAllListModel()
                                     {


                                        IsActive = a.IsActive,
                                        ItemCode = a.ItemCode,
                                        Priority = a.Priority,
                                        PromotionCode = a.PromotionCode,
                                        PromotionId = a.PromotionId,
                                        PromotionTypeId = a.PromotionTypeId,
                                        Repeats = a.Repeats,
                                        ValidFrom = a.ValidFrom,
                                        ValidTo = a.ValidTo,
                                        PromotionTypeName = Language == "ar" ? a.PromotionTypeNameAr : a.PromotionTypeNameEn,
                                        ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,

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
        [HttpPost("itemPromotionDownload")]
        public async Task<IActionResult> itemPromotionDownload(ItemPromotionAllSearchModel model)
        {

            try
            {



                var ctr = new Criteria<BOItemPromotionAllVw>();

                // get by term
                if (!string.IsNullOrEmpty(model.Term))
                {

                    if (!string.IsNullOrEmpty(model.TermBy))
                    {
                        switch (model.TermBy)
                        {
                            case "itemCode":
                                ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.ItemCode), model.Term));
                                break;
                            case "promotionCode":
                                ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.PromotionCode), model.Term));
                                break;
                            case "itemNameAr":
                                ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.ItemNameAr), model.Term));
                                break;
                            case "itemNameEn":
                                ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.ItemNameEn), model.Term));
                                break;
                            default:
                                break;
                        }
                    }

                }

                // branch Permissions


                // get by model
                if (model.ItemId > 0)
                    ctr.Add(Expression.Eq(nameof(BOItemPromotionAllVw.ItemId), model.ItemId));

                if (model.PromotionId > 0)
                    ctr.Add(Expression.Eq(nameof(BOItemPromotionAllVw.PromotionId), model.PromotionId));

                if (!string.IsNullOrEmpty(model.PromotionCode))
                    ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.PromotionCode), model.PromotionCode));

                if (!string.IsNullOrEmpty(model.ItemCode))
                    ctr.Add(Expression.StartWith(nameof(BOItemPromotionAllVw.ItemCode), model.ItemCode));


                if (model.IsActive > 0)
                    ctr.Add(Expression.Eq(nameof(BOItemPromotionAllVw.IsActive), model.IsActive == 1 ? true : false));


                // sort by 
                if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                {
                    switch (model.SortBy.Property)
                    {
                        case "itemName":
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("itemName{0}", Language)) : OrderBy.Desc(string.Format("itemName{0}", Language)));
                            break;

                        default:
                            ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                            break;
                    }
                }
                else
                {
                    ctr.Add(OrderBy.Desc(nameof(BOItemPromotionAllVw.ItemId)));
                }



                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.Skip(model.Skip)
                             .Take(model.Take > 0 ? model.Take : 30)
                             .List<BOItemPromotionAllVw>()
                             .Select(a => new ItemPromotionAllListModel()
                             {


                                 IsActive = a.IsActive,
                                 ItemCode = a.ItemCode,
                                 Priority = a.Priority,
                                 PromotionCode = a.PromotionCode,
                                 PromotionId = a.PromotionId,
                                 PromotionTypeId = a.PromotionTypeId,
                                 Repeats = a.Repeats,
                                 ValidFrom = a.ValidFrom,
                                 ValidTo = a.ValidTo,
                                 PromotionTypeName = Language == "ar" ? a.PromotionTypeNameAr : a.PromotionTypeNameEn,
                                 ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,

                             }).ToList();

                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "Promotion Code";
                        worksheet.Cell("B1").Value = "Item Code";
                        worksheet.Cell("C1").Value = "Item Name";
                        worksheet.Cell("D1").Value = "Promotion Type Name";
                        worksheet.Cell("E1").Value = "Valid From";
                        worksheet.Cell("F1").Value = "Valid To";
                        worksheet.Cell("G1").Value = "Is Active";


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



                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].PromotionCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ItemCode;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].ItemName;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].PromotionTypeName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].ValidFrom.Value.ToString("yyyy-MM-dd");
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].ValidTo.Value.ToString("yyyy-MM-dd");
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].IsActive==true?"Yes":"No";



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
