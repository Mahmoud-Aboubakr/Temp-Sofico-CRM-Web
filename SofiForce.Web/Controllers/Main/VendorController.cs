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
    public class VendorController : BaseController
    {
        public VendorController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }


        [HttpPost("filter")]
        public async Task<IActionResult> filter(VendorSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<VendorListModel>> responseModel = new ResponseModel<List<VendorListModel>>();

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


                        var ctr = new Criteria<BOVendorVw>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            IList<object> listObjs = new List<object>();
                            listObjs.Add(new Criteria<BOVendorVw>().Add(Expression.Like(nameof(BOVendorVw.VendorCode), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOVendorVw>().Add(Expression.Like(nameof(BOVendorVw.VendorNameEn), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOVendorVw>().Add(Expression.Like(nameof(BOVendorVw.VendorNameEn), model.Term.Trim())));

                            ctr = new Criteria<BOVendorVw>(Expression.Or(listObjs.ToArray()));
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
                            ctr.Add(OrderBy.Desc(nameof(BOVendorVw.VendorId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take)
                                     .List<BOVendorVw>()
                                     .Select(a=> new VendorListModel()
                                     {
                                         CanDelete = a.CanDelete,
                                         CanEdit = a.CanEdit,
                                         Color = a.Color,
                                         DisplayOrder = a.DisplayOrder,
                                         Icon = a.Icon,
                                         IsActive = a.IsActive,
                                         IsLocal = a.IsLocal,
                                         VendorCode = a.VendorCode,
                                         VendorGroupId = a.VendorGroupId,
                                         VendorGroupName=Language=="ar"? a.VendorGroupNameAr :a.VendorGroupNameEn,
                                         VendorId = a.VendorId.Value,
                                         VendorName=Language=="ar" ? a.VendorNameAr :a.VendorNameEn,


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
