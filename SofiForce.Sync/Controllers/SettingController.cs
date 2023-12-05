using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
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
    }
}
