using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Promotion;
using SofiForce.Web.Common;
using SofiForce.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class SalesOrderLogController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public SalesOrderLogController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;

        }

        [HttpGet("getById")]
        public async Task<IActionResult> getById(double SalesId)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SalesOrderLogListModel>> responseModel = new ResponseModel<List<SalesOrderLogListModel>>();

                try
                {
                    var ctr = new Criteria<BOSalesOrderLogVw>();

                    ctr.Add(Expression.Eq(nameof(BOSalesOrderLogVw.SalesId), SalesId));
                    var res = ctr.List<BOSalesOrderLogVw>().Select(a => new SalesOrderLogListModel()
                                 {
                                    
                                    UserId = a.UserId,
                                    SalesId=a.SalesId,
                                    LogDate = a.LogDate,
                                    LogId = a.LogId,
                                    RealName = a.RealName,
                                    SalesOrderLogTypeId=a.SalesOrderLogTypeId,
                                    SalesOrderLogTypeName =Language=="ar"?a.SalesOrderLogTypeNameAr:a.SalesOrderLogTypeNameEn,

                                 }).ToList();



                    responseModel.Data = res;
                    responseModel.Total = res.Count;
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message;;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


    }
}
