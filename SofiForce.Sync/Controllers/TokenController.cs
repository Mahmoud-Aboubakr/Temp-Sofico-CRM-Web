using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public TokenController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }

        [HttpPost("firebase")]
        public async Task<IActionResult> firebase(FirebaseTokenModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<FirebaseTokenModel> responseModel = new ResponseModel<FirebaseTokenModel>();

                try
                {
                    var current = new Criteria<BOAppUser>().Add(Expression.Eq(nameof(BOAppUser.UserId), UserId)).FirstOrDefault<BOAppUser>();
                    if (current != null)
                    {
                        current.FirebaseId = model.Token;
                        current.Update();
                    }
                    else
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = "Invalid Model";
                    }
                    responseModel.Data = model;
                    responseModel.Total = 1;

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
