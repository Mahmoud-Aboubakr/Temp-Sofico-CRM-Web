using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Drawing;
using SofiForce.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Models;
using Microsoft.AspNetCore.Authorization;
using SofiForce.Web.Common;
using ClosedXML.Excel;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/[controller]")]
    public class DownloaderController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
      
        public DownloaderController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            this._env = env;
            this._configuration = configuration;
        }



        [HttpGet("Excel")]
        public  IActionResult Excel(string file)
        {

            try
            {


                
                using (MemoryStream stream = new MemoryStream(System.IO.File.ReadAllBytes(file)))
                {
                    

                    stream.Seek(0, SeekOrigin.Begin);

                    return this.File(
                        fileContents: stream.ToArray(),
                        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",

                        // By setting a file download name the framework will
                        // automatically add the attachment Content-Disposition header
                        fileDownloadName: "export.xlsx"
                    );
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }


}