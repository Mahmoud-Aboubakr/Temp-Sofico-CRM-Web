using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM.Setup
{
    [Route("api/[controller]")]
    public class SalesExportController : BaseController
    {
        private readonly IExportManager exportManager;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public SalesExportController(IExportManager exportManager, IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration, IMapper mapper) : base(contextAccessor)
        {
            this.exportManager = exportManager;
            this._env = env;
            this._configuration = configuration;
            this._mapper = mapper;

        }


        [HttpPost("invoiceHeader")]
        public async Task<IActionResult> invoiceHeader(ExportSearchModel model)
        {

            ResponseModel<ExportModel> responseModel = new ResponseModel<ExportModel>();

            try
            {

                var res = exportManager.getInvoiceHeaders(model);



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");




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

                        worksheet.Cell("Q1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("Q1").Style.Font.FontColor = XLColor.White;


                        worksheet.Cell("R1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("R1").Style.Font.FontColor = XLColor.White;


                        worksheet.Cell("S1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("S1").Style.Font.FontColor = XLColor.White;


                        worksheet.Cell("T1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("T1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("U1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("U1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("V1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("V1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("W1").Style.Fill.BackgroundColor = XLColor.Black;
                        worksheet.Cell("W1").Style.Font.FontColor = XLColor.White;

                        worksheet.Cell("A1").Value = "SalesCode";
                        worksheet.Cell("B1").Value = "InvoiceCode";
                        worksheet.Cell("C1").Value = "InvoiceDate";
                        worksheet.Cell("D1").Value = "InvoiceType";
                        worksheet.Cell("E1").Value = "ClientCode";
                        worksheet.Cell("F1").Value = "ClientName";
                        worksheet.Cell("G1").Value = "BranchCode";
                        worksheet.Cell("H1").Value = "BranchName";
                        worksheet.Cell("I1").Value = "StoreCode";
                        worksheet.Cell("J1").Value = "StoreName";
                        worksheet.Cell("K1").Value = "SalesManCode";
                        worksheet.Cell("L1").Value = "SalesManName";
                        worksheet.Cell("M1").Value = "PaymentTerm";
                        worksheet.Cell("N1").Value = "SalesTime";
                        worksheet.Cell("O1").Value = "SalesPool";
                        worksheet.Cell("P1").Value = "ItemTotal";
                        worksheet.Cell("Q1").Value = "OfferDiscount";
                        worksheet.Cell("R1").Value = "TaxTotal";
                        worksheet.Cell("S1").Value = "CashDiscount";
                        worksheet.Cell("T1").Value = "CashPercentage";
                        worksheet.Cell("U1").Value = "NetTotal";
                        worksheet.Cell("V1").Value = "OpenValue";
                        worksheet.Cell("W1").Value = "ClaimNo";

                        for (int i = 0; i < res.Count; i++)
                        {

                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].SalesCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].InvoiceCode;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].InvoiceDate;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].InvoiceType;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].StoreCode;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].StoreName;
                            worksheet.Cell(string.Format("K{0}", i + 2)).Value = res[i].SalesManCode;
                            worksheet.Cell(string.Format("L{0}", i + 2)).Value = res[i].SalesManName;
                            worksheet.Cell(string.Format("M{0}", i + 2)).Value = res[i].PaymentTerm;
                            worksheet.Cell(string.Format("N{0}", i + 2)).Value = res[i].SalesTime;
                            worksheet.Cell(string.Format("O{0}", i + 2)).Value = res[i].SalesPool;
                            worksheet.Cell(string.Format("P{0}", i + 2)).Value = res[i].ItemTotal;
                            worksheet.Cell(string.Format("Q{0}", i + 2)).Value = res[i].OfferDiscount;
                            worksheet.Cell(string.Format("R{0}", i + 2)).Value = res[i].TaxTotal;
                            worksheet.Cell(string.Format("S{0}", i + 2)).Value = res[i].CashDiscount;
                            worksheet.Cell(string.Format("T{0}", i + 2)).Value = res[i].CashPercentage;

                            worksheet.Cell(string.Format("U{0}", i + 2)).Value = res[i].NetTotal;
                            worksheet.Cell(string.Format("V{0}", i + 2)).Value = res[i].OpenValue;
                            worksheet.Cell(string.Format("W{0}", i + 2)).Value = res[i].ClaimNo;


                        }

                        var _root = _configuration["files"];
                        var _dir = "/_temp/";

                        if (!Directory.Exists(Path.Combine(_root, _dir)))
                        {
                            Directory.CreateDirectory(Path.Combine(_root, _dir));
                        }

                        var _fileName = Guid.NewGuid().ToString() + ".xlsx";
                        var fullPath = Path.Combine(_root, _dir, _fileName);
                        workbook.SaveAs(fullPath);


                        //var FileUrl = _configuration["filesUrl"]+ _fileName;


                        responseModel.Data = new ExportModel()
                        {
                            Total = res.Count,
                            FileUrl = fullPath
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(responseModel);
        }


        [HttpPost("invoiceDetail")]
        public async Task<IActionResult> invoiceDetail(ExportSearchModel model)
        {

            ResponseModel<ExportModel> responseModel = new ResponseModel<ExportModel>();

            try
            {

                var res = exportManager.getInvoiceDetails(model);



                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");




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


                        worksheet.Cell("A1").Value = "SalesCode";
                        worksheet.Cell("B1").Value = "InvoiceCode";
                        worksheet.Cell("C1").Value = "InvoiceDate";
                        worksheet.Cell("D1").Value = "VendorCode";
                        worksheet.Cell("E1").Value = "VendorName";
                        worksheet.Cell("F1").Value = "ItemCode";
                        worksheet.Cell("G1").Value = "ItemName";
                        worksheet.Cell("H1").Value = "Batch";
                        worksheet.Cell("I1").Value = "Expiration";
                        worksheet.Cell("J1").Value = "PublicPrice";
                        worksheet.Cell("K1").Value = "ClientPrice";
                        worksheet.Cell("L1").Value = "Quantity";
                        worksheet.Cell("M1").Value = "Discount";
                        worksheet.Cell("N1").Value = "TaxValue";
                        worksheet.Cell("O1").Value = "ItemValue";
                        worksheet.Cell("P1").Value = "NetValue";


                        for (int i = 0; i < res.Count; i++)
                        {

                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].SalesCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].InvoiceCode;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].InvoiceDate;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].VendorCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].VendorName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].ItemCode;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].ItemName;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].Batch;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].Expiration;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].PublicPrice;
                            worksheet.Cell(string.Format("K{0}", i + 2)).Value = res[i].ClientPrice;
                            worksheet.Cell(string.Format("L{0}", i + 2)).Value = res[i].Quantity;
                            worksheet.Cell(string.Format("M{0}", i + 2)).Value = res[i].Discount;
                            worksheet.Cell(string.Format("N{0}", i + 2)).Value = res[i].TaxValue;
                            worksheet.Cell(string.Format("O{0}", i + 2)).Value = res[i].ItemValue;
                            worksheet.Cell(string.Format("P{0}", i + 2)).Value = res[i].NetValue;



                        }

                        var _root = _configuration["files"];
                        var _dir = "/_temp/";

                        if (!Directory.Exists(Path.Combine(_root, _dir)))
                        {
                            Directory.CreateDirectory(Path.Combine(_root, _dir));
                        }

                        var _fileName = Guid.NewGuid().ToString() + ".xlsx";
                        var fullPath = Path.Combine(_root, _dir, _fileName);
                        workbook.SaveAs(fullPath);


                        responseModel.Data = new ExportModel()
                        {
                            Total = res.Count,
                            FileUrl = fullPath
                        };
                    }

                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(responseModel);
        }
    }
}
