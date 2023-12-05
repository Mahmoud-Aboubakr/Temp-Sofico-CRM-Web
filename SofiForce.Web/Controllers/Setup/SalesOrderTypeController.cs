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
    public class SalesOrderTypeController : BaseController
    {
        public SalesOrderTypeController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOSalesOrderType>();


                var res = ctr.List<BOSalesOrderType>().Select(a => new LookupModel()
                {

                    Id = a.SalesOrderTypeId.Value,
                    Code = a.SalesOrderTypeCode,
                    Name = Language == "ar" ? a.SalesOrderTypeNameAr : a.SalesOrderTypeNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
