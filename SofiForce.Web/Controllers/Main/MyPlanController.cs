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
    public class MyPlanController : BaseController
    {
        private IMyPlanManager _IMyPlanManager;
        public MyPlanController(IHttpContextAccessor contextAccessor, IMyPlanManager IMyPlanManager) : base(contextAccessor)
        {
            _IMyPlanManager = IMyPlanManager;

        }


        [CheckAuthorizedAttribute]
        [HttpPost("getMyPlan")]
        public async Task<IActionResult> Myplan(MyPlanSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {

                ResponseModel<MyPlanModel> responseModel = new ResponseModel<MyPlanModel>();
                try
                {

                    if (model.FromDate == null || model.ToDate == null || model.FromDate.Value.Year != model.ToDate.Value.Year || model.FromDate.Value.Month != model.ToDate.Value.Month)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = Messages.Invalid_Model;
                        responseModel.Data = new MyPlanModel();
                        return responseModel;
                    }

                    var Agent = new Criteria<BORepresentative>()
                        .Add(Expression.Eq(nameof(BORepresentative.UserId), UserId))
                        .FirstOrDefault<BORepresentative>();

                    if (Agent != null)
                    {
                        responseModel.Data = _IMyPlanManager.getMyPlan(Agent.RepresentativeId.Value, Language, model.ClientId, model.FromDate.Value, model.ToDate.Value);
                        responseModel.Total = 1;
                    }



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


        [CheckAuthorizedAttribute]
        [HttpPost("export")]
        public async Task<IActionResult> export(MyPlanSearchModel model)
        {

            try
            {


                if (model.FromDate == null || model.ToDate == null || model.FromDate.Value.Year != model.ToDate.Value.Year || model.FromDate.Value.Month != model.ToDate.Value.Month)
                {
                    return BadRequest();
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {





                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "client Code";
                        worksheet.Cell("B1").Value = "client Name";

                        worksheet.Cell("C1").Value = "Orders";
                        worksheet.Cell("D1").Value = "SalesDate";

                        worksheet.Cell("E1").Value = "Target Value";
                        worksheet.Cell("F1").Value = "Sales Value";
                        worksheet.Cell("G1").Value = "Sales Percentage";

                        worksheet.Cell("H1").Value = "Target Call";
                        worksheet.Cell("I1").Value = "Calls";
                        worksheet.Cell("J1").Value = "Call Percentage";

                        worksheet.Cell("K1").Value = "Target Visit";
                        worksheet.Cell("L1").Value = "Visits";
                        worksheet.Cell("M1").Value = "Visit Percentage";


                        worksheet.Cell("N1").Value = "SalesDays";


                        worksheet.Cell("O1").Value = "Perormance Percentage";
                        worksheet.Cell("P1").Value = "Perormance Label";




                        worksheet.Cell("A1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("A1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("B1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("B1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("C1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("C1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("D1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("D1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("E1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("E1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("F1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("F1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("G1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("G1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("H1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("H1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("I1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("I1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("J1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("J1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("K1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("K1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("L1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("L1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("M1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("M1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("N1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("N1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("O1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("O1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("P1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("P1").Style.Font.FontColor = XLColor.White;




                        var res = _IMyPlanManager.getMyPlan(UserId, Language, model.ClientId, model.FromDate.Value, model.ToDate.Value).SalesControlDetails.ToList();
                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].Orders;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].SalesDate;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].TargetValue;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].SalesValue;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].SalesPercentage;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].TargetCall;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].callAll;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].CallPercentage;
                            worksheet.Cell(string.Format("K{0}", i + 2)).Value = res[i].TargetVisit;
                            worksheet.Cell(string.Format("L{0}", i + 2)).Value = res[i].VisitAll;
                            worksheet.Cell(string.Format("M{0}", i + 2)).Value = res[i].VisitPercentage;
                            worksheet.Cell(string.Format("N{0}", i + 2)).Value = res[i].SalesDays;
                            worksheet.Cell(string.Format("O{0}", i + 2)).Value = res[i].PerormancePercentage;
                            worksheet.Cell(string.Format("P{0}", i + 2)).Value = res[i].PerormanceLabel;

                        }

                        workbook.SaveAs(stream);
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

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
