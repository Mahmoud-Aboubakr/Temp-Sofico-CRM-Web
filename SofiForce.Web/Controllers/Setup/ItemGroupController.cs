using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM.Setup
{
    [Route("api/[controller]")]
    public class ItemGroupController : BaseController
    {
        public ItemGroupController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }
        [CheckAuthorizedAttribute]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOComplainType>();


                var res = ctr.List<BOComplainType>().Select(a => new LookupModel()
                {

                    Id = a.ComplainTypeId.Value,
                    Code = a.ComplainTypeCode,
                    Name = Language == "ar" ? a.ComplainTypeNameAr : a.ComplainTypeNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(ItemGroupSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ItemGroupListModel>> responseModel = new ResponseModel<List<ItemGroupListModel>>();

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


                        var ctr = new Criteria<BOItemGroup>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            IList<object> listObjs = new List<object>();
                            listObjs.Add(new Criteria<BOItemGroup>().Add(Expression.Like(nameof(BOItemGroup.ItemGroupCode), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOItemGroup>().Add(Expression.Like(nameof(BOItemGroup.ItemGroupNameAr), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOItemGroup>().Add(Expression.Like(nameof(BOItemGroup.ItemGroupNameEn), model.Term.Trim())));

                            ctr = new Criteria<BOItemGroup>(Expression.Or(listObjs.ToArray()));
                        }


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {

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
                            ctr.Add(OrderBy.Desc(nameof(BOItemGroup.ItemGroupId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0?model.Take:20)
                                     .List<BOItemGroup>()
                                     .Select(a => new ItemGroupListModel()
                                     {
                                        
                                         ItemGroupCode=a.ItemGroupCode,
                                         ItemGroupId=a.ItemGroupId,
                                         CanDelete=a.CanDelete,
                                         CanEdit=a.CanEdit,
                                         Color=a.Color,
                                         DisplayOrder=a.DisplayOrder,
                                         Icon=a.Icon,
                                         IsActive=a.IsActive,
                                         ItemGroupName=Language=="ar"?a.ItemGroupNameAr:a.ItemGroupNameEn

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
    }
}
