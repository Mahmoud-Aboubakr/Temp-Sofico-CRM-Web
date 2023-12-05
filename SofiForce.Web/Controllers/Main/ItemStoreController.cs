using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class ItemStoreController : BaseController
    {
        public ItemStoreController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(ItemStoreSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ItemStoreListModel>> responseModel = new ResponseModel<List<ItemStoreListModel>>();

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


                        var ctr = new Criteria<BOItemStoreVw>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Eq(nameof(BOItemStoreVw.BatchNo), model.Term));
                        }

                        // branch Permissions
                        if (FullDataAccess == false)
                        {
                            ctr.Add(Expression.In(nameof(BOItemStoreVw.BranchId), Branchs));
                        }

                        if (model.ItemId > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemStoreVw.ItemId), model.ItemId));

                        if (model.VendorId > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemStoreVw.VendorId), model.VendorId));

                        if (model.StoreId > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), model.StoreId));

                        if (model.ExpireDate !=null && model.ExpireDate.Value.Year>2000)
                            ctr.Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), model.ExpireDate,dateformatter));


                        if (model.IsActive > 0)
                            ctr.Add(Expression.Eq(nameof(BOItemStoreVw.IsActive), model.IsActive==1?true:false));


                        if (model.Available > 0)
                            ctr.Add(Expression.Gte(nameof(BOItemStoreVw.Available), model.Available));


                        if (ctr.ListDataCriteria() == null || ctr.ListDataCriteria().Count == 0)
                        {
                            return responseModel;
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
                                case "storeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("storeName{0}", Language)) : OrderBy.Desc(string.Format("storeName{0}", Language)));
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
                            ctr.Add(OrderBy.Asc(nameof(BOItemStoreVw.ExpireDate)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 20)
                                     .List<BOItemStoreVw>()
                                     .Select(a => new ItemStoreListModel()
                                     {
                                         
                                         ItemId = a.ItemId,
                                         StoreId = a.StoreId,
                                         VendorId = a.VendorId,
                                         BranchId = a.BranchId,
                                         AcceptDays = a.AcceptDays,
                                         BatchNo = a.BatchNo,
                                         Available = a.Available,
                                         ExpireDate = a.ExpireDate,
                                         ItemCode = a.ItemCode,
                                         ItemStoreId = a.ItemStoreId,
                                         OnHand = a.OnHand,
                                         Quantity = a.Quantity,
                                         StoreCode = a.StoreCode,
                                         BranchCode = a.BranchCode,
                                         IsActive=a.IsActive,
                                         UnitId=a.UnitId,
                                         Quota=a.Quota>0 ?a.Quota.Value:0,
                                         ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                                         VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
                                         StoreName = Language == "ar" ? a.StoreNameAr : a.StoreNameEn,
                                         BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,


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

    }
}
