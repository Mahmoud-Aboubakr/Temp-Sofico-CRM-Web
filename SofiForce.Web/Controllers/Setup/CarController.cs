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
    public class CarController : BaseController
    {
        public CarController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }
        [CheckAuthorizedAttribute]
        [HttpPost("filter")]
        public async Task<IActionResult> filter(CarSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<CarListModel>> responseModel = new ResponseModel<List<CarListModel>>();

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


                        var ctr = new Criteria<BOCarVw>();

                        if (this.FullDataAccess == false)
                            ctr.Add(Expression.In(nameof(BOCarVw.BranchId), this.Branchs));

                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Like(nameof(BOCarVw.CarNo), model.Term));
                        }

                        // branch Permissions
                        if(model.BranchId>0)
                            ctr.Add(Expression.Eq(nameof(BOCarVw.BranchId), model.BranchId));
                        if (model.BranchId > 0)
                            ctr.Add(Expression.Eq(nameof(BOCarVw.BranchId), model.BranchId));
                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {


                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "manufacturerName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("manufacturerName{0}", Language)) : OrderBy.Desc(string.Format("manufacturerName{0}", Language)));
                                    break;
                                case "carTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("carTypeName{0}", Language)) : OrderBy.Desc(string.Format("carTypeName{0}", Language)));
                                    break;


                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }

                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOCarVw.BranchId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOCarVw>()
                                     .Select(a => new CarListModel()
                                     {
                                        CarNo = a.CarNo,
                                        BranchCode = a.BranchCode,
                                        BranchId = a.BranchId,
                                        CarCode = a.CarCode,
                                        CarId = a.CarId,
                                        CarTypeId = a.CarTypeId,
                                        CarTypeCode=a.CarTypeCode,
                                        IsActive = a.IsActive,
                                        ManufacturerCode = a.ManufacturerCode,
                                        ManufacturerId = a.ManufacturerId,
                                        Model = a.Model,
                                        YearManufactur=a.YearManufactur,
                                        BranchName=Language =="ar"?a.BranchNameAr:a.BranchNameEn,
                                        ManufacturerName=Language =="ar" ?a.ManufacturerNameAr:a.ManufacturerNameEn,
                                        CarTypeName=Language =="ar"?a.CarTypeNameAr:a.CarTypeNameEn


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
