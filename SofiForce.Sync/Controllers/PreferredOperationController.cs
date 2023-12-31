﻿using Microsoft.AspNetCore.Http;
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
    public class PreferredOperationController : BaseController
    {
        public PreferredOperationController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOPreferredOperation>();


                var res = ctr.List<BOPreferredOperation>().Select(a => new LookupModel()
                {

                    Id = a.PreferredOperationId.Value,
                    Code = a.PreferredOperationCode,
                    Name = Language == "ar" ? a.PreferredOperationNameAr : a.PreferredOperationNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
