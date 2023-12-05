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
    public class GovernerateController : BaseController
    {
        public GovernerateController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }
        [CheckAuthorizedAttribute]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOGovernerate>();


                var res = ctr.List<BOGovernerate>().Select(a => new LookupModel()
                {

                    Id = a.GovernerateId.Value,
                    Code = a.GovernerateCode,
                    Name = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(GovernerateSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<GovernerateListModel>> responseModel = new ResponseModel<List<GovernerateListModel>>();

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


                        var ctr = new Criteria<BOGovernerate>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            IList<object> listObjs = new List<object>();
                            listObjs.Add(new Criteria<BOGovernerate>().Add(Expression.Like(nameof(BOGovernerate.GovernerateCode), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOGovernerate>().Add(Expression.Like(nameof(BOGovernerate.GovernerateNameEn), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOGovernerate>().Add(Expression.Like(nameof(BOGovernerate.GovernerateNameEn), model.Term.Trim())));

                            ctr = new Criteria<BOGovernerate>(Expression.Or(listObjs.ToArray()));
                        }


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {

                                case "GovernerateName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("GovernerateName{0}", Language)) : OrderBy.Desc(string.Format("GovernerateName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOGovernerate.GovernerateId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOGovernerate>()
                                     .Select(a => new GovernerateListModel()
                                     {

                                         Color = a.Color,
                                         DisplayOrder = a.DisplayOrder,
                                         Icon = a.Icon,
                                         IsActive = a.IsActive,
                                         GovernerateCode = a.GovernerateCode,
                                         GovernerateId = a.GovernerateId.Value,
                                         CanDelete = a.CanDelete,
                                         CanEdit = a.CanEdit,
                                         RegionId=a.RegionId,
                                       
                                         GovernerateName = Language == "ar" ? a.GovernerateNameAr : a.GovernerateNameEn,


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
