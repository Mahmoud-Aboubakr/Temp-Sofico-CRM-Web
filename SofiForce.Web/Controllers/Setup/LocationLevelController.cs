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
    public class LocationLevelController : BaseController
    {
        public LocationLevelController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }
        [CheckAuthorizedAttribute]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOLocationLevel>();


                var res = ctr.List<BOLocationLevel>().Select(a => new LookupModel()
                {

                    Id = a.LocationLevelId.Value,
                    Code = a.LocationLevelCode,
                    Name = Language == "ar" ? a.LocationLevelNameAr : a.LocationLevelNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(LocationLevelSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LocationLevelListModel>> responseModel = new ResponseModel<List<LocationLevelListModel>>();

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


                        var ctr = new Criteria<BOLocationLevel>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            IList<object> listObjs = new List<object>();
                            listObjs.Add(new Criteria<BOLocationLevel>().Add(Expression.Like(nameof(BOLocationLevel.LocationLevelCode), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOLocationLevel>().Add(Expression.Like(nameof(BOLocationLevel.LocationLevelNameEn), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOLocationLevel>().Add(Expression.Like(nameof(BOLocationLevel.LocationLevelNameEn), model.Term.Trim())));

                            ctr = new Criteria<BOLocationLevel>(Expression.Or(listObjs.ToArray()));
                        }


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {

                                case "LocationLevelName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("LocationLevelName{0}", Language)) : OrderBy.Desc(string.Format("LocationLevelName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOLocationLevel.LocationLevelId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOLocationLevel>()
                                     .Select(a => new LocationLevelListModel()
                                     {

                                         Color = a.Color,
                                         DisplayOrder = a.DisplayOrder,
                                         Icon = a.Icon,
                                         IsActive = a.IsActive,
                                         LocationLevelCode = a.LocationLevelCode,
                                         LocationLevelId = a.LocationLevelId.Value,
                                         CanDelete = a.CanDelete,
                                         CanEdit = a.CanEdit,
                                         LocationLevelName = Language == "ar" ? a.LocationLevelNameAr : a.LocationLevelNameEn,


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
