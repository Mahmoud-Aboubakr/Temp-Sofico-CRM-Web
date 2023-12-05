using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class UtilsController : BaseController
    {
        public UtilsController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {

        }

        [HttpGet("getDateMode")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<List<DateTypeModel>> responseModel = new ResponseModel<List<DateTypeModel>>();

                responseModel.Data = new List<DateTypeModel>();
                responseModel.Data.Add(new DateTypeModel() { Id = 1, IsCustom=false, From=DateTime.Now.Today(),To=DateTime.Now.Today(), Code = "1", Name = Language == "ar" ? "اليوم" : "Today" });
                responseModel.Data.Add(new DateTypeModel() { Id = 2, IsCustom = false, From = DateTime.Now.FirstDayOfWeek(), To = DateTime.Now.Today(), Code = "2", Name = Language == "ar" ? "هذا الاسبوع" : "Current Week" });
                responseModel.Data.Add(new DateTypeModel() { Id = 3, IsCustom = false, From = DateTime.Now.FirstDayOfMonth(), To = DateTime.Now.Today(), Code = "3", Name = Language == "ar" ? "هذا الشهر" : "Current Month" });
                responseModel.Data.Add(new DateTypeModel() { Id = 4, IsCustom = false, From = DateTime.Now.FirstDayOfQuarter(), To = DateTime.Now.Today(), Code = "4", Name = Language == "ar" ? "هذا الربع" : "Current Quarter" });
                responseModel.Data.Add(new DateTypeModel() { Id = 5, IsCustom = false, From = DateTime.Now.FirstDayOfYear(), To = DateTime.Now.Today(), Code = "5", Name = Language == "ar" ? "هذا العام" : "Current Year" });
                responseModel.Data.Add(new DateTypeModel() { Id = 6, IsCustom = true, From = DateTime.Now.Today(), To = DateTime.Now.Today(), Code = "6", Name = Language == "ar" ? "اخرى" : "Custom" });

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


    }
}
