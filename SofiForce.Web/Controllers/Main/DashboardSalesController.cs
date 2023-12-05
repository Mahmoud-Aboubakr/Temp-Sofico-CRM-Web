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

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class DashboardSalesController : BaseController
    {
        private ISalesManager _ISalesManager;
        public DashboardSalesController(IHttpContextAccessor contextAccessor, ISalesManager ISalesManager) : base(contextAccessor)
        {
            _ISalesManager = ISalesManager;

        }



        [HttpPost("all")]
        public async Task<IActionResult> all(DashboardSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<DashboardSalesModel> responseModel = new ResponseModel<DashboardSalesModel>();

                if (model == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";

                    return responseModel;

                }
                try
                {
                    string BranchIds = "";
                    string GroupIds = "";

                    if (model.Branchs==null || model.Branchs.Count == 0)
                    {
                        if (FullDataAccess == true)
                        {
                            BranchIds = null;
                        }
                        else
                        {
                            var branchs = new Criteria<BOAppUserBranch>()
                                .Add(Expression.Eq(nameof(BOAppUserBranch.UserId), UserId))
                                .List<BOAppUserBranch>()
                                .Select(a => a.BranchId)
                                .ToList();

                            if (branchs.Count == 0)
                                branchs.Add(0);

                            BranchIds =string.Join(",", branchs);
                        }
                    }
                    else
                    {
                        BranchIds = string.Join(",", model.Branchs);

                    }


                    if (model.Channels == null || model.Channels.Count == 0)
                    {
                        if (FullDataAccess == true)
                        {
                            GroupIds = null;
                        }
                        else
                        {
                            var channels = new Criteria<BOAppUserClientGroup>()
                                .Add(Expression.Eq(nameof(BOAppUserClientGroup.UserId), UserId))
                                .List<BOAppUserClientGroup>()
                                .Select(a => a.ClientGroupId)
                                .ToList();
                            if (channels.Count == 0)
                                channels.Add(0);


                            GroupIds = string.Join(",", channels);
                        }
                    }
                    else
                    {
                        GroupIds = string.Join(",", model.Channels);
                    }



                    if(model.TimePeriod != 7)
                    {
                        var res = Utils.getTimeRange(model.TimePeriod);
                        model.FromDate = res.FromDate;
                        model.ToDate = res.ToDate;
                    }


                    if (model.FromDate == null) model.FromDate = DateTime.Now;
                    if (model.ToDate == null) model.ToDate = DateTime.Now;



                    var kBI = _ISalesManager.getKBI(model.FromDate.Value.FirstDayOfMonth(), model.ToDate.Value, BranchIds, GroupIds);

                    var Sales = _ISalesManager.getSalesTimeline(model.FromDate.Value, model.ToDate.Value, model.LineChartMode, BranchIds, GroupIds, 0);

                    var PerfromanceModel = _ISalesManager.getPerformance(model.FromDate.Value, model.ToDate.Value, BranchIds, GroupIds, 0);
                    var OrderKBIModel = _ISalesManager.getOrderKBI(model.FromDate.Value, model.ToDate.Value, BranchIds, GroupIds,model.orderKBIMode);
                    var Channels = _ISalesManager.getSalesChannel(model.FromDate.Value, model.ToDate.Value, BranchIds, GroupIds, Language);
                    var Hours = _ISalesManager.getSalesByHour(model.FromDate.Value, model.ToDate.Value, BranchIds, GroupIds);
                    var VendorSales = _ISalesManager.getVendorSales(model.FromDate.Value, model.ToDate.Value, BranchIds, GroupIds, Language);
                    var ItemSales = _ISalesManager.getItemSales(model.FromDate.Value, model.ToDate.Value, BranchIds, GroupIds, Language);
                    var VendorHotSales = _ISalesManager.getVendorHotSales(model.FromDate.Value, model.ToDate.Value, BranchIds, GroupIds, Language);


                    responseModel.Data = new DashboardSalesModel()
                    {
                        KbiModel = kBI,
                        Timelines = Sales,
                        PerfromanceModel= PerfromanceModel,
                        OrderKBIModel= OrderKBIModel,
                        Channels= Channels,
                        Hours= Hours,
                        VendorSales = VendorSales,
                        ItemSales= ItemSales,
                        VendorHotSales = VendorHotSales


                    };

                    responseModel.Total = 1;

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                }


                return responseModel;
            });


            await task;
            return Ok(task.Result);
        }


        [HttpPost("ChartLine")]
        public async Task<IActionResult> ChartLine(DashboardSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<DashboardSalesModel> responseModel = new ResponseModel<DashboardSalesModel>();

                if (model == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";

                    return responseModel;

                }
                try
                {
                    string BranchIds = "";
                    string GroupIds = "";

                    if (model.Branchs == null || model.Branchs.Count == 0)
                    {
                        if (FullDataAccess == true)
                        {
                            BranchIds = null;
                        }
                        else
                        {
                            var branchs = new Criteria<BOAppUserBranch>()
                                .Add(Expression.Eq(nameof(BOAppUserBranch.UserId), UserId))
                                .List<BOAppUserBranch>()
                                .Select(a => a.BranchId)
                                .ToList();

                            if (branchs.Count == 0)
                                branchs.Add(0);

                            BranchIds = string.Join(",", branchs);
                        }
                    }
                    else
                    {
                        BranchIds = string.Join(",", model.Branchs);

                    }


                    if (model.Channels == null || model.Channels.Count == 0)
                    {
                        if (FullDataAccess == true)
                        {
                            GroupIds = null;
                        }
                        else
                        {
                            var channels = new Criteria<BOAppUserClientGroup>()
                                .Add(Expression.Eq(nameof(BOAppUserClientGroup.UserId), UserId))
                                .List<BOAppUserClientGroup>()
                                .Select(a => a.ClientGroupId)
                                .ToList();
                            if (channels.Count == 0)
                                channels.Add(0);


                            GroupIds = string.Join(",", channels);
                        }
                    }
                    else
                    {
                        GroupIds = string.Join(",", model.Channels);
                    }



                    if (model.TimePeriod != 7)
                    {
                        var res = Utils.getTimeRange(model.TimePeriod);
                        model.FromDate = res.FromDate;
                        model.ToDate = res.ToDate;
                    }


                    if (model.FromDate == null) model.FromDate = DateTime.Now;
                    if (model.ToDate == null) model.ToDate = DateTime.Now;



 

                    var Sales = _ISalesManager.getSalesTimeline(model.FromDate.Value, model.ToDate.Value, model.LineChartMode, BranchIds, GroupIds, 0);




                    responseModel.Data = new DashboardSalesModel()
                    {
                        Timelines = Sales,
                    };

                    responseModel.Total = 1;

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                }


                return responseModel;
            });


            await task;
            return Ok(task.Result);
        }

        [HttpPost("salesKBI")]
        public async Task<IActionResult> salesKBI(DashboardSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<DashboardSalesModel> responseModel = new ResponseModel<DashboardSalesModel>();

                if (model == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";

                    return responseModel;

                }
                try
                {
                    string BranchIds = "";
                    string GroupIds = "";

                    if (model.Branchs == null || model.Branchs.Count == 0)
                    {
                        if (FullDataAccess == true)
                        {
                            BranchIds = null;
                        }
                        else
                        {
                            var branchs = new Criteria<BOAppUserBranch>()
                                .Add(Expression.Eq(nameof(BOAppUserBranch.UserId), UserId))
                                .List<BOAppUserBranch>()
                                .Select(a => a.BranchId)
                                .ToList();

                            if (branchs.Count == 0)
                                branchs.Add(0);

                            BranchIds = string.Join(",", branchs);
                        }
                    }
                    else
                    {
                        BranchIds = string.Join(",", model.Branchs);

                    }


                    if (model.Channels == null || model.Channels.Count == 0)
                    {
                        if (FullDataAccess == true)
                        {
                            GroupIds = null;
                        }
                        else
                        {
                            var channels = new Criteria<BOAppUserClientGroup>()
                                .Add(Expression.Eq(nameof(BOAppUserClientGroup.UserId), UserId))
                                .List<BOAppUserClientGroup>()
                                .Select(a => a.ClientGroupId)
                                .ToList();
                            if (channels.Count == 0)
                                channels.Add(0);


                            GroupIds = string.Join(",", channels);
                        }
                    }
                    else
                    {
                        GroupIds = string.Join(",", model.Channels);
                    }



                    if (model.TimePeriod != 7)
                    {
                        var res = Utils.getTimeRange(model.TimePeriod);
                        model.FromDate = res.FromDate;
                        model.ToDate = res.ToDate;
                    }


                    if (model.FromDate == null) model.FromDate = DateTime.Now;
                    if (model.ToDate == null) model.ToDate = DateTime.Now;



                    var kBI = _ISalesManager.getKBI(model.FromDate.Value.FirstDayOfMonth(), model.ToDate.Value, BranchIds, GroupIds);






                    responseModel.Data = new DashboardSalesModel()
                    {
                        KbiModel = kBI,
                    };

                    responseModel.Total = 1;

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = ex.Message;
                }


                return responseModel;
            });


            await task;
            return Ok(task.Result);
        }

    }
}
