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
    public class TerminationReasonController : BaseController
    {
        public TerminationReasonController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOTerminationReason>();


                var res = ctr.List<BOTerminationReason>().Select(a => new LookupModel()
                {

                    Id = a.TerminationReasonId.Value,
                    Code = a.TerminationReasonCode,
                    Name = Language == "ar" ? a.TerminationReasonNameAr : a.TerminationReasonNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
