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
    public class ApplicationFeatureController : BaseController
    {
        public ApplicationFeatureController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }
        [CheckAuthorizedAttribute]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOApplicationFeature>();


                var res = ctr.List<BOApplicationFeature>().Select(a => new LookupModel()
                {

                    Id = a.FeatueId.Value,
                    Code = a.FeatuePath,
                    Name = Language == "ar" ? a.FeatuePath : a.FeatuePath

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpGet("getByRole")]
        public async Task<IActionResult> getByRoleId(int Id)
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOAppRoleFeatureVw>();

                ctr.Add(Expression.Eq(nameof(BOAppRoleFeatureVw.AppRoleId), Id));
                ctr.Add(Expression.StartWith(nameof(BOAppRoleFeatureVw.FeatuePath), "/"));

                var res = ctr.List<BOAppRoleFeatureVw>().Select(a => new LookupModel()
                {

                    Id = a.FeatueId.Value,
                    Code = a.FeatuePath,
                    Name = Language == "ar" ? a.FeatuePath : a.FeatuePath

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
