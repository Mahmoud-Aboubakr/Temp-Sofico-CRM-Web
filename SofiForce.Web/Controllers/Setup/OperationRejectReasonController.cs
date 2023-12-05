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
    public class OperationRejectReasonController : BaseController
    {
        public OperationRejectReasonController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOOperationRejectReason>();


                var res = ctr.List<BOOperationRejectReason>().Select(a => new LookupModel()
                {

                    Id = a.OperationRejectReasonId.Value,
                    Code = a.OperationRejectReasonCode,
                    Name = Language == "ar" ? a.OperationRejectReasonNameAr : a.OperationRejectReasonNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
