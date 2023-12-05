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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class PromotionItemBundleController : BaseController
    {
        private readonly AppSettings AppSettings;
        private readonly IConfiguration Configuration;
        private readonly IHubContext<AppHub> _hub;
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IMapper _mapper;
        public PromotionItemBundleController(IHttpContextAccessor contextAccessor, 
                         AppHub appHub,
                         IOptions<AppSettings> appSettings,
                         IConfiguration configuration,
                        IHubContext<AppHub> hub,
                        IWebHostEnvironment _webHostEnvironment,
                        IMapper mapper
            ) : base(contextAccessor)
        {
            AppSettings = appSettings.Value;
            Configuration = configuration;
            _hub = hub;
            webHostEnvironment = _webHostEnvironment;
        }


        [HttpPost("save")]
        public async Task<IActionResult> save(PromotionItemBundleModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<PromotionItemBundleModel> responseModel = new ResponseModel<PromotionItemBundleModel>();

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

                        // check if exit code
                        var exist = new Criteria<BOPromotionItemBundle>()
                                        .Add(Expression.Eq(nameof(BOPromotionItemBundle.BundleId), model.BundleId))
                                        .FirstOrDefault<BOPromotionItemBundle>();


                        if (exist == null)
                        {
                            exist = new BOPromotionItemBundle();

                            exist.PromotionId = model.PromotionId;
                            exist.ItemId = model.ItemId;
                            exist.IsMandatory = model.IsMandatory;
                            exist.Quantity = model.Quantity;



                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;
                            exist.SaveNew();

                           


                        }
                        else
                        {


                            var Promo = new BOPromotion(exist.PromotionId.Value);
                            if (Promo.IsApproved != true)
                            {
                                exist.PromotionId = model.PromotionId;
                                exist.ItemId = model.ItemId;
                                exist.IsMandatory = model.IsMandatory;
                                exist.Quantity = model.Quantity;

                                exist.EBy = UserId;
                                exist.EDate = DateTime.Now;
                                exist.Update();
                            }
                            else
                            {
                                responseModel.Succeeded = false;
                                responseModel.Message = Messages.Invalid_Model;
                                responseModel.StatusCode = 503;
                            }


                        }







                        responseModel.Data = model;
                        responseModel.Total = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpGet("getByPromotion")]
        public async Task<IActionResult> getByPromotion(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<PromotionItemBundleListModel>> responseModel = new ResponseModel<List<PromotionItemBundleListModel>>();

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

                        // check if exit code
                        var res = new Criteria<BOPromotionItemBundleVw>()
                                        .Add(Expression.Eq(nameof(BOPromotionItemBundleVw.PromotionId), Id))
                                        .List<BOPromotionItemBundleVw>();
                        if (res != null)
                        {
                            // update current

                            responseModel.Data = res.Select(a => new PromotionItemBundleListModel()
                            {
                               PromotionId = a.PromotionId,
                               BundleId = a.BundleId,
                               IsMandatory=a.IsMandatory,
                               ItemCode=a.ItemCode,
                               Quantity=a.Quantity,
                               ItemId=a.ItemId.Value,
                               ItemName=Language=="ar"?a.ItemNameAr:a.ItemNameEn
                               

                            }).ToList();


                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Not_Found;
                        }

                        responseModel.Total = 1;
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


        [HttpPost("delete")]
        public async Task<IActionResult> delete(PromotionItemBundleModel model)
        {

            var task = Task.Factory.StartNew(async () =>
            {
                ResponseModel<PromotionItemBundleModel> responseModel = new ResponseModel<PromotionItemBundleModel>();

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

                        // check if exit code
                        var exist = new Criteria<BOPromotionItemBundle>()
                                        .Add(Expression.Eq(nameof(BOPromotionItemBundle.BundleId), model.BundleId))
                                        .FirstOrDefault<BOPromotionItemBundle>();


                        if (exist != null)
                        {
                            var Promo = new BOPromotion(exist.PromotionId.Value);

                            if (Promo.IsApproved != true)
                            {
                                //exist.DeleteAllPromotionCriteria();
                                exist.Delete();
                            }


                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.Message = Messages.Invalid_Model;
                            responseModel.StatusCode = 503;
                        }

                        responseModel.Data = model;
                        responseModel.Total = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result.Result);
        }

    }
}
