using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Helpers;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class OrderMonitorController : BaseController
    {
        private IOrderMonitorManager _IOrderMonitorManager;
        public OrderMonitorController(IHttpContextAccessor contextAccessor, IOrderMonitorManager IOrderMonitorManager) : base(contextAccessor)
        {
            _IOrderMonitorManager = IOrderMonitorManager;

        }

        [CheckAuthorizedAttribute]
        [HttpPost("getMonitor")]
        public async Task<IActionResult> getMonitor(SalesMonitorSearchModel model )
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<OrderMonitorModel> responseModel = new ResponseModel<OrderMonitorModel>();
                try
                {

                    responseModel.Data= _IOrderMonitorManager.getMonitor(model.BranchId, Language);

                }
                catch (Exception ex)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;;
                }

                
                return responseModel;
            });

            await task;
            return Ok(task.Result);
        }

    }
    
}
