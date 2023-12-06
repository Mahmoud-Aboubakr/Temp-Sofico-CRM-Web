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
    public class CustomDiscountTypeController : BaseController
    {
        public CustomDiscountTypeController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }
        [CheckAuthorizedAttribute]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOCustomDiscountType>();


                var res = ctr.List<BOCustomDiscountType>().Select(a => new LookupModel()
                {

                    Id = a.CustomDiscountTypeId.Value,
                    Code = a.CustomDiscountTypeCode,
                    Name = Language == "ar" ? a.CustomDiscountTypeNameAr : a.CustomDiscountTypeNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
