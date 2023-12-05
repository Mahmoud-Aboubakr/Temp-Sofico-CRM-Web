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
    public class CityController : BaseController
    {
        public CityController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

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


    }
}
