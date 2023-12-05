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
    public class RequestTypeDetailController : BaseController
    {
        public RequestTypeDetailController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BORequestTypeDetail>();


                var res = ctr.List<BORequestTypeDetail>().Select(a => new LookupModel()
                {

                    Id = a.RequestTypeDetailId.Value,
                    ParentId=a.RequestTypeId.Value,
                    Code = a.RequestTypeDetailCode,
                    Name = Language == "ar" ? a.RequestTypeDetailNameAr : a.RequestTypeDetailNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        
    }
}
