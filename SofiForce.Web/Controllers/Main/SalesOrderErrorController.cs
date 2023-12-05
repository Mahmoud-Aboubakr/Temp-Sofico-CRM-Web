using AutoMapper;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class SalesOrderErrorController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public SalesOrderErrorController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }

        [CheckAuthorizedAttribute]
        [HttpGet("getBySalesId")]
        public async Task<IActionResult> getBySalesId(double Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SalesOrderErrorListModel>> responseModel = new ResponseModel<List<SalesOrderErrorListModel>>();

                try
                {
                    var ctr = new Criteria<BOSalesOrderError>();

                   
                    ctr.Add(Expression.Eq(nameof(BOSalesOrderError.SalesId), Id));

                    // sort by 
                        ctr.Add(OrderBy.Desc(nameof(BOSalesOrderError.SalesId)));
                    

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.List<BOSalesOrderError>().Select(a => new SalesOrderErrorListModel()
                                 {
                                    Id=null,
                                    ErrorId = a.ErrorId,
                                    SalesId = a.SalesId,
                                    ErrorDate=a.ErrorDate,
                                    ErrorDetail=a.ErrorDetail,
                                 }).ToList();



                    responseModel.Data = res;
                    responseModel.Total = Total;
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
