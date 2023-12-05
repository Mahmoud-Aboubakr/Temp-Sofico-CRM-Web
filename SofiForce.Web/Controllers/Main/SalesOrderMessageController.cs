using AutoMapper;
using Helpers;
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
    public class SalesOrderMessageController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IOrderLoggerService orderLoggerService;

        public SalesOrderMessageController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper, IOrderLoggerService orderLoggerService) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
            this.orderLoggerService = orderLoggerService;
        }

        [CheckAuthorizedAttribute]
        [HttpGet("getMessages")]
        public async Task<IActionResult> getMessages(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SalesOrderMessagesListModel>> responseModel = new ResponseModel<List<SalesOrderMessagesListModel>>();

                if (Id == 0)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else
                {
                    try
                    {
                        var lst = new Criteria<BOSalesOrderMessagesVw>()
                        .Add(Expression.Eq(nameof(BOSalesOrderMessagesVw.SalesId), Id))
                        .Add(OrderBy.Asc(nameof(BOSalesOrderMessagesVw.SalesMessageId)))
                        .List<BOSalesOrderMessagesVw>();

                        responseModel.Data = lst.Select(a=> new SalesOrderMessagesListModel()
                        {
                            SalesMessageId = a.SalesMessageId,
                            SalesId = a.SalesId,
                            RealName = a.RealName,
                            JobTitle = a.JobTitle,
                            Avatar=a.Avatar,
                            Message = a.Message,
                            MessageDate = a.MessageDate,
                            UserId = a.UserId,
                            UserName=a.UserName,

                        }).ToList();
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message; ;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [CheckAuthorizedAttribute]
        [HttpPost("Save")]
        public async Task<IActionResult> Save(List<SalesOrderMessagesListModel> model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SalesOrderMessagesListModel>> responseModel = new ResponseModel<List<SalesOrderMessagesListModel>>();

                if (model == null)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else
                {
                    try
                    {
                        foreach (var item in model)
                        {
                            if (item.SalesId > 0 && item.SalesMessageId == 0)
                            {
                                var bo = new BOSalesOrderMessages();
                                bo.SalesId = item.SalesId;
                                bo.UserId = UserId;
                                bo.Message = item.Message;
                                bo.MessageDate = DateTime.Now;

                                bo.SaveNew();

                                item.SalesMessageId = bo.SalesMessageId;
                            }
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message; ;
                    }
                }
                responseModel.Data = model;
                responseModel.Total = model.Count;
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

    }
}
