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
    public class CityController : BaseController
    {
        public CityController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }
        [CheckAuthorizedAttribute]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOCity>();


                var res = ctr.List<BOCity>().Select(a => new LookupModel()
                {

                    Id = a.CityId.Value,
                    Code = a.CityCode,
                    ParentId=a.GovernerateId.Value,
                    Name = Language == "ar" ? a.CityNameAr : a.CityNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
        [CheckAuthorizedAttribute]
        [HttpGet("getByGovernerate")]
        public async Task<IActionResult> GetByGovernerate(int Id)
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOCity>();

                ctr.Add(Expression.Eq(nameof(BOCity.GovernerateId), Id));

                var res = ctr.List<BOCity>().Select(a => new LookupModel()
                {

                    Id = a.CityId.Value,
                    Code = a.CityCode,
                    ParentId = a.GovernerateId.Value,
                    Name = Language == "ar" ? a.CityNameAr : a.CityNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(CitySearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<CityListModel>> responseModel = new ResponseModel<List<CityListModel>>();

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


                        var ctr = new Criteria<BOCity>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            IList<object> listObjs = new List<object>();
                            listObjs.Add(new Criteria<BOCity>().Add(Expression.Like(nameof(BOCity.CityCode), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOCity>().Add(Expression.Like(nameof(BOCity.CityNameEn), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOCity>().Add(Expression.Like(nameof(BOCity.CityNameEn), model.Term.Trim())));

                            ctr = new Criteria<BOCity>(Expression.Or(listObjs.ToArray()));
                        }


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {

                                case "CityName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("CityName{0}", Language)) : OrderBy.Desc(string.Format("CityName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOCity.CityId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOCity>()
                                     .Select(a => new CityListModel()
                                     {

                                         Color = a.Color,
                                         DisplayOrder = a.DisplayOrder,
                                         Icon = a.Icon,
                                         IsActive = a.IsActive,
                                         CityCode = a.CityCode,
                                         CityId = a.CityId.Value,
                                         CanDelete = a.CanDelete,
                                         CanEdit = a.CanEdit,
                                         GovernerateId=a.GovernerateId,
                                        

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
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
