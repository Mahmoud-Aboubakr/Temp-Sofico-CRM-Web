using Microsoft.AspNetCore.Authorization;
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
    public class SettingController : BaseController
    {
        public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }
        public SettingController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            Env = env;
            Configuration = configuration;
        }




        [HttpPost("getAll")]
        [AllowAnonymous]
        public async Task<IActionResult> getAll()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<AppSetting> responseModel = new ResponseModel<AppSetting>();

                try
                {

                    AppSetting setting  =new AppSetting();
                    setting.Ver = Configuration["settings:general:ver"];
                    setting.SupportPhone = Configuration["settings:general:support"];

                    responseModel.Data = setting;
                    responseModel.Succeeded = true;

                    
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


        [HttpGet("WebSetting")]
        [AllowAnonymous]
        public async Task<IActionResult> WebSetting()
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<WebSetting> responseModel = new ResponseModel<WebSetting>();

                try
                {

                    WebSetting setting = new WebSetting();
                    setting.Ver = "1.0.0";

                    responseModel.Data = setting;
                    responseModel.Succeeded = true;


                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message; ;
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

    }
}
