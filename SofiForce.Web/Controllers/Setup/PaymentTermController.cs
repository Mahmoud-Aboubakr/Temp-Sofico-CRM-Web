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
    public class PaymentTermController : BaseController
    {
        public PaymentTermController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOPaymentTerm>();


                var res = ctr.List<BOPaymentTerm>().Select(a => new LookupModel()
                {

                    Id = a.PaymentTermId.Value,
                    Code = a.PaymentTermCode,
                    Name = Language == "ar" ? a.PaymentTermNameAr : a.PaymentTermNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(PaymentTermSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PaymentTermListModel>> responseModel = new ResponseModel<List<PaymentTermListModel>>();

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


                        var ctr = new Criteria<BOPaymentTerm>();


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            IList<object> listObjs = new List<object>();
                            listObjs.Add(new Criteria<BOPaymentTerm>().Add(Expression.Like(nameof(BOPaymentTerm.PaymentTermCode), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOPaymentTerm>().Add(Expression.Like(nameof(BOPaymentTerm.PaymentTermNameEn), model.Term.Trim())));
                            listObjs.Add(new Criteria<BOPaymentTerm>().Add(Expression.Like(nameof(BOPaymentTerm.PaymentTermNameEn), model.Term.Trim())));

                            ctr = new Criteria<BOPaymentTerm>(Expression.Or(listObjs.ToArray()));
                        }


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {
                            switch (model.SortBy.Property)
                            {

                                case "PaymentTermName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("PaymentTermName{0}", Language)) : OrderBy.Desc(string.Format("PaymentTermName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }
                        }
                        else
                        {
                            ctr.Add(OrderBy.Desc(nameof(BOPaymentTerm.PaymentTermId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take > 0 ? model.Take : 30)
                                     .List<BOPaymentTerm>()
                                     .Select(a => new PaymentTermListModel()
                                     {

                                         Color = a.Color,
                                         DisplayOrder = a.DisplayOrder,
                                         Icon = a.Icon,
                                         IsActive = a.IsActive,
                                         PaymentTermCode = a.PaymentTermCode,
                                         PaymentTermId = a.PaymentTermId.Value,
                                         CanDelete = a.CanDelete,
                                         CanEdit=a.CanEdit,
                                         PaymentTermName = Language == "ar" ? a.PaymentTermNameAr : a.PaymentTermNameEn,


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
