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
    public class ComplainTypeDetailController : BaseController
    {
        public ComplainTypeDetailController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOComplainTypeDetail>();


                var res = ctr.List<BOComplainTypeDetail>().Select(a => new LookupModel()
                {

                    Id = a.ComplainTypeDetailId.Value,
                    ParentId=a.ComplainTypeId.Value,
                    Code = a.ComplainTypeDetailCode,
                    Name = Language == "ar" ? a.ComplainTypeDetailNameAr : a.ComplainTypeDetailNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpGet("GetByTypeId")]
        public async Task<IActionResult> GetByTypeId(int Id)
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOComplainTypeDetail>();

                ctr.Add(Expression.Eq(nameof(BOComplainTypeDetail.ComplainTypeId), Id));

                var res = ctr.List<BOComplainTypeDetail>().Select(a => new LookupModel()
                {

                    Id = a.ComplainTypeDetailId.Value,
                    ParentId = a.ComplainTypeId.Value,
                    Code = a.ComplainTypeDetailCode,
                    Name = Language == "ar" ? a.ComplainTypeDetailNameAr : a.ComplainTypeDetailNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
