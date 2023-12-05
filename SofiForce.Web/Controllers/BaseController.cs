using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers
{
    [Authorize]
    [ApiController]

    public class BaseController : ControllerBase
    {
        public int UserId { get; set; }
        public int AppRoleId { get; set; }
        public bool FullDataAccess { get; set; } = false;

        public string Branchs { get; set; } = "0";
        public string Stores { get; set; } = "0";
        public int RepresentativeId { get; set; }

        public string Language { get; set; }
        public bool IsLocked { get; set; } = false;


        public static string fmt = "yyyy-MM-dd";
        public static Func<object, string> dateformatter = (x => ((DateTime)x).ToString(fmt));




        public BaseController(IHttpContextAccessor contextAccessor)
        {

            try
            {
                this.UserId = contextAccessor.HttpContext.User.FindFirst("UserId") != null ? int.Parse(contextAccessor.HttpContext.User.FindFirst("UserId").Value) : 0;
                this.Branchs = contextAccessor.HttpContext.User.FindFirst("Branchs") != null ? contextAccessor.HttpContext.User.FindFirst("Branchs").Value : "0";
                this.Stores = contextAccessor.HttpContext.User.FindFirst("Stores") != null ? contextAccessor.HttpContext.User.FindFirst("Stores").Value : "0";
                this.RepresentativeId = contextAccessor.HttpContext.User.FindFirst("RepresentativeId") != null ? int.Parse(contextAccessor.HttpContext.User.FindFirst("RepresentativeId").Value) : 0;

                this.Language = contextAccessor.HttpContext.Request.Headers["lan"].ToString() != null ? contextAccessor.HttpContext.Request.Headers["lan"].ToString() : string.Empty;
                this.AppRoleId = contextAccessor.HttpContext.User.FindFirst("AppRoleId") != null ? int.Parse(contextAccessor.HttpContext.User.FindFirst("AppRoleId").Value) : 0;
                this.FullDataAccess = contextAccessor.HttpContext.User.FindFirst("FullDataAccess") != null ? bool.Parse(contextAccessor.HttpContext.User.FindFirst("FullDataAccess").Value) : false;
                this.IsLocked = contextAccessor.HttpContext.User.FindFirst("IsLocked") != null ? bool.Parse(contextAccessor.HttpContext.User.FindFirst("IsLocked").Value) : false;
                
            }
            catch { }
        }
    }
}
