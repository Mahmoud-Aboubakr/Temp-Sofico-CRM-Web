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
    public class ServeyStatusController : BaseController
    {
        public ServeyStatusController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOServeyStatus>();


                var res = ctr.List<BOServeyStatus>().Select(a => new LookupModel()
                {

                    Id = a.ServeyStatusId.Value,
                    Code = a.ServeyStatusCode,
                    Name = Language == "ar" ? a.ServeyStatusNameAr : a.ServeyStatusNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
