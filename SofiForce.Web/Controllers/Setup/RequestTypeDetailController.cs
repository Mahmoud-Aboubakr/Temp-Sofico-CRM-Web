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
    public class RequestTypeDetailController : BaseController
    {
        public RequestTypeDetailController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }
        [CheckAuthorizedAttribute]
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
        [CheckAuthorizedAttribute]
        [HttpGet("GetByTypeId")]
        public async Task<IActionResult> GetByTypeId(int Id)
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BORequestTypeDetail>();

                ctr.Add(Expression.Eq(nameof(BORequestTypeDetail.RequestTypeId), Id));

                var res = ctr.List<BORequestTypeDetail>().Select(a => new LookupModel()
                {
                    Id = a.RequestTypeDetailId.Value,
                    ParentId = a.RequestTypeId.Value,
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
