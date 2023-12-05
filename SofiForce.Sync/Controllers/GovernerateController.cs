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
    public class GovernerateController : BaseController
    {
        public GovernerateController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

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

    }
}
