using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
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
    }
}
