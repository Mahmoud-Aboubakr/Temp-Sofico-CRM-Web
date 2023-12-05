using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Models.Models.SearchModels;
using SofiForce.Web.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class SalesOrderLinePromotionController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public SalesOrderLinePromotionController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            _env = env;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpPost("filter")]
        public async Task<IActionResult> filter(SalesOrderPromotionSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SalesOrderLinePromotionListModel>> responseModel = new ResponseModel<List<SalesOrderLinePromotionListModel>>();

                try
                {

                    int Total = 0;
                    responseModel.Data = GetData(model,out Total);
                    responseModel.Total= Total;
                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message; ;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
        [HttpPost("download")]
        public async Task<IActionResult> download(SalesOrderPromotionSearchModel model)
        {


            try
            {

                int Total = 0;
                model.Skip = 0;
                model.Take=int.MaxValue;

                var res= GetData(model, out Total);
     
                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "clientCode";
                        worksheet.Cell("B1").Value = "clientName";
                        worksheet.Cell("C1").Value = "vendorCode";
                        worksheet.Cell("D1").Value = "itemCode";
                        worksheet.Cell("E1").Value = "itemName";
                        worksheet.Cell("F1").Value = "batchNo";
                        worksheet.Cell("G1").Value = "invoiceDate";
                        worksheet.Cell("H1").Value = "invoiceCode";
                        worksheet.Cell("I1").Value = model.OutcomeType==1?"Free Item": "Discount";
                        worksheet.Cell("J1").Value = "promotionCode";
                       


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



                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].VendorCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].ItemCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].ItemName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].BatchNo;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].InvoiceDate.Value.ToString("yyyy-MM-dd");
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].InvoiceCode;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].Outcome;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].PromotionCode;



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


        protected List<SalesOrderLinePromotionListModel>  GetData(SalesOrderPromotionSearchModel model,out int Total)
        {
            var ctr = new Criteria<BOSalesOrderLinePromotionVw>();
            ctr.Add(Expression.Eq(nameof(BOSalesOrderLinePromotionVw.IsInvoiced), true));
            ctr.Add(Expression.NotEq(nameof(BOSalesOrderLinePromotionVw.IsDeleted), true));

            // get by term
            if (!string.IsNullOrEmpty(model.Term))
            {
                ctr.Add(Expression.StartWith(nameof(BOSalesOrderLinePromotionVw.PromotionCode), model.Term));

            }

            if (FullDataAccess == false)
            {
                ctr.Add(Expression.In(nameof(BOSalesOrderLinePromotionVw.BranchId), Branchs));


                if (this.AppRoleId == 6)
                {
                    // get By Suppervisor
                    var clients = new Criteria<BORepresentativeClientVw>()
                                .Add(Expression.Eq(nameof(BORepresentativeClientVw.SupervisorUserId), UserId))
                                .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

                    ctr.Add(Expression.InSubQuery(nameof(BOSalesOrderLinePromotionVw.ClientId), clients));
                }

                if (this.AppRoleId == 7)
                {
                    // get by Sales Rep

                    var clients = new Criteria<BORepresentativeClientVw>()
                           .Add(Expression.Eq(nameof(BORepresentativeClientVw.RepresentativeUserId), UserId))
                           .Add(new Projection(nameof(BORepresentativeClientVw.ClientId)));

                    ctr.Add(Expression.InSubQuery(nameof(BOSalesOrderLinePromotionVw.ClientId), clients));

                }

            }


            if (model.ClientId > 0)
                ctr.Add(Expression.Eq(nameof(BOSalesOrderLinePromotionVw.ClientId), model.ClientId));

            if (model.BranchId > 0)
                ctr.Add(Expression.Eq(nameof(BOSalesOrderLinePromotionVw.BranchId), model.BranchId));

            if (model.VendorId > 0)
                ctr.Add(Expression.Eq(nameof(BOSalesOrderLinePromotionVw.VendorId), model.VendorId));

            if (model.ItemId > 0)
                ctr.Add(Expression.Eq(nameof(BOSalesOrderLinePromotionVw.ItemId), model.ItemId));

            if (model.PromotionId > 0)
                ctr.Add(Expression.Eq(nameof(BOSalesOrderLinePromotionVw.PromotionId), model.PromotionId));

            if (model.OutcomeType > 0)
                ctr.Add(Expression.Eq(nameof(BOSalesOrderLinePromotionVw.OutcomeType), model.OutcomeType));

            if (model.SalesId > 0)
                ctr.Add(Expression.Eq(nameof(BOSalesOrderLinePromotionVw.SalesId), model.SalesId));

            if (!string.IsNullOrEmpty(model.BatchNo))
                ctr.Add(Expression.Eq(nameof(BOSalesOrderLinePromotionVw.BatchNo), model.BatchNo));

            if (!string.IsNullOrEmpty(model.PromotionCode))
                ctr.Add(Expression.StartWith(nameof(BOSalesOrderLinePromotionVw.PromotionCode), model.PromotionCode));

            if (!string.IsNullOrEmpty(model.InvoiceCode))
                ctr.Add(Expression.EndWith(nameof(BOSalesOrderLinePromotionVw.InvoiceCode), model.InvoiceCode));

            if (model.From != null && model.From.Value.Year > 1900)
                ctr.Add(Expression.Gte(nameof(BOSalesOrderLinePromotionVw.InvoiceDate), model.From, dateformatter));

            if (model.To != null && model.To.Value.Year > 1900)
                ctr.Add(Expression.Lte(nameof(BOSalesOrderLinePromotionVw.InvoiceDate), model.To, dateformatter));


            // sort by 
            if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
            {
                switch (model.SortBy.Property)
                {
                    case "branchName":
                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                        break;

                    default:
                        ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                        break;
                }
            }
            else
            {
                ctr.Add(OrderBy.Asc(nameof(BOSalesOrderLinePromotionVw.SalesOrderStatusId)));
            }

            // get count

            Total = ctr.Count();

            // get paged

            return  ctr.Skip(model.Skip)
                         .Take(model.Take > 0 ? model.Take : 30)
                         .List<BOSalesOrderLinePromotionVw>().Select(a => new SalesOrderLinePromotionListModel()
                         {
                             IsDeleted = a.IsDeleted,
                             IsInvoiced = a.IsInvoiced,
                             BatchNo = a.BatchNo,
                             BranchCode = a.BranchCode,
                             BranchId = a.BranchId,
                             ClientCode = a.ClientCode,
                             ClientId = a.ClientId,
                             IsActive = a.IsActive,
                             InvoiceCode = a.InvoiceCode,
                             InvoiceDate = a.InvoiceDate,
                             ItemId = a.ItemId,
                             LineId = a.LineId,
                             Outcome = a.Outcome,
                             SalesOrderStatusId = a.SalesOrderStatusId,
                             PromotionId = a.PromotionId,
                             SalesId = a.SalesId,
                             ItemStoreId = a.ItemStoreId,
                             PromotionCode = a.PromotionCode,
                             ValidFrom = a.ValidFrom,
                             ValidTo = a.ValidTo,
                             ItemCode = a.ItemCode,
                             ItemGroupId = a.ItemGroupId,
                             OutcomeType = a.OutcomeType,
                             VendorCode = a.VendorCode,
                             VendorId = a.VendorId,

                             VendorName = Language == "ar" ? a.VendorNameAr : a.VendorNameEn,
                             ItemName = Language == "ar" ? a.ItemNameAr : a.ItemNameEn,
                             BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,
                             ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,


                         }).ToList();


        }
    }
}
