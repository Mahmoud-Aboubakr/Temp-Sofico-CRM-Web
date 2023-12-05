using AutoMapper;
using Helpers;
using Hubs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using SofiForce.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class ItemPromotionController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;

        private INotificationManager _INotificationManager;
        private readonly IMapper _mapper;
        private readonly IPromotionService promotionService;
        private readonly IPromotionManager promotionManager;

        public ItemPromotionController(IHttpContextAccessor contextAccessor,
                         AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                        IHubContext<AppHub> hub,
                        IWebHostEnvironment _webHostEnvironment,
                        INotificationManager notificationManager,
                        IMapper mapper,
                        IPromotionService promotionService,
                        IPromotionManager PromotionManager
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
            _hub = hub;
            _INotificationManager = notificationManager;
            _mapper = mapper;
            this.promotionService = promotionService;
            promotionManager = PromotionManager;
            webHostEnvironment = _webHostEnvironment;
        }





        [CheckAuthorizedAttribute]
        [HttpGet("getByItem")]
        public async Task<IActionResult> getByItem(string ItemCode)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromotionModel> responseModel = new ResponseModel<PromotionModel>();

                if (ItemCode == null)
                {

                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;

                }
                else
                {
                    try
                    {

                        var PromotionItems = new Criteria<BOPromotionItemVw>()
                                                .Add(Expression.Eq(nameof(BOPromotionItemVw.ItemCode), ItemCode))
                                                .Add(Expression.Eq(nameof(BOPromotionItemVw.PromotionCategoryId), 1))
                                                .Add(OrderBy.Desc(nameof(BOPromotionItemVw.PromotionCategoryId)))
                                                .Add(OrderBy.Desc(nameof(BOPromotionItemVw.ValidFrom)))
                                                .FirstOrDefault<BOPromotionItemVw>();


                        if (PromotionItems != null)
                        {
                            var exist = new Criteria<BOPromotion>()
                                       .Add(Expression.Eq(nameof(BOPromotion.PromotionId), PromotionItems.PromotionId))
                                       .FirstOrDefault<BOPromotion>();

                            if (exist != null)
                            {
                                // update current

                                responseModel.Data = _mapper.Map<PromotionModel>(exist);


                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.StatusCode = 500;
                                responseModel.Message = Messages.Not_Found;
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
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


    }
}
