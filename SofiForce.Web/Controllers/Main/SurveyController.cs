using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM
{
    [Route("api/[controller]")]
    public class SurveyController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public SurveyController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<LookupModel>> responseModel = new ResponseModel<List<LookupModel>>();

                var ctr = new Criteria<BOSurvey>();


                var res = ctr.List<BOSurvey>().Select(a => new LookupModel()
                {

                    Id = a.SurveyId.Value,
                    Code = a.SurveyCode,
                    Name = Language == "ar" ? a.SurveyNameAr : a.SurveyNameEn

                }).ToList();

                responseModel.Data = res;

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(SurveySearchModel searchModel)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<SurveyListModel>> responseModel = new ResponseModel<List<SurveyListModel>>();

                try
                {
                    var ctr = new Criteria<BOSurveyVw>();

                    // get by term
                    if (!string.IsNullOrEmpty(searchModel.Term))
                    {
                        ctr.Add(Expression.Eq(nameof(BOSurveyVw.SurveyCode), searchModel.Term));
                    }

                    





                    if (searchModel.IsActive >0)
                        ctr.Add(Expression.Eq(nameof(BOSurveyVw.IsActive), searchModel.IsActive==1?true:false));



                    if (searchModel.ServeyGroupId > 0)
                        ctr.Add(Expression.Eq(nameof(BOSurveyVw.ServeyGroupId), searchModel.ServeyGroupId));

                   

                    // sort by 
                    if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                    {
                        switch (searchModel.SortBy.Property)
                        {
                            case "serveyGroupName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("serveyGroupName{0}", Language)) : OrderBy.Desc(string.Format("serveyGroupName{0}", Language)));
                                break;
                            case "surveyName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("surveyName{0}", Language)) : OrderBy.Desc(string.Format("surveyName{0}", Language)));
                                break;
    
                            default:
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                                break;
                        }
                    }
                    else
                    {
                        ctr.Add(OrderBy.Desc(nameof(BOSurveyVw.SurveyId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(searchModel.Skip)
                                 .Take(searchModel.Take)
                                 .List<BOSurveyVw>().Select(a => new SurveyListModel()
                                 {
                                    SurveyId = a.SurveyId.Value,
                                    ServeyGroupId = a.ServeyGroupId,
                                    SurveyCode=a.SurveyCode,
                                    CreateDate = a.CreateDate,
                                    IsActive = a.IsActive,
                                    ServeyGroupName=Language =="ar"?a.ServeyGroupNameAr:a.ServeyGroupNameEn,
                                    SurveyName=Language ==  "ar"?a.SurveyNameAr:a.SurveyNameEn

                                 }).ToList();
                    responseModel.Data = res;
                    responseModel.Total = Total;

                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message;;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpGet("getById")]
        public async Task<IActionResult> getById(int Id)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SurveyModel> responseModel = new ResponseModel<SurveyModel>();

                try
                {
                    if (Id == 0)
                    {
                        responseModel.Succeeded = false;
                        responseModel.Message = Messages.Invalid_Model;

                    }
                    else
                    {
                        SurveyModel res = new SurveyModel();

                        var surveyDetail = new Criteria<BOSurveyDetail>()
                                                     .Add(Expression.Eq(nameof(BOSurveyDetail.SurveyId), Id))
                                                     .List<BOSurveyDetail>();

                        var surveyAnswers = new Criteria<BOSurveyDetailAnswer>()
                             .Add(Expression.Eq(nameof(BOSurveyDetailAnswer.SurveyId), Id))
                             .List<BOSurveyDetailAnswer>();



                        foreach (var question in surveyDetail)
                        {
                            res.Details.Add(new SurveyDetailListModel()
                            {
                                IsMuliSelect = question.IsMuliSelect,
                                SurveyDetailId = question.SurveyDetailId.Value,
                                SurveyQuestion = Language == "ar" ? question.SurveyQuestionAr : question.SurveyQuestionEn,
                                Answers = surveyAnswers.Where(a => a.SurveyDetailId == question.SurveyDetailId)
                                            .ToList()
                                            .Select(a => new SurveyDetailAnswerListModel()
                                            {
                                                IsSelected = false,
                                                Answer = Language == "ar" ? a.AnswerAr : a.AnswerEn,
                                                DetailAnswerId = a.DetailAnswerId.Value,

                                            }).ToList()

                            });
                        }


                        responseModel.Data = res;
                        responseModel.Total = 1;
                    }


                }
                catch (Exception ex)
                {
                    responseModel.Succeeded = false;
                    responseModel.StatusCode = 500;
                    responseModel.Message = ex.Message;;
                }

                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpPost("save")]
        public async Task<IActionResult> save(SurveyModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<SurveyModel> responseModel = new ResponseModel<SurveyModel>();

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
                        var exist = new Criteria<BOSurvey>()
                                        .Add(Expression.Eq(nameof(model.SurveyId), model.SurveyId))
                                        .FirstOrDefault<BOSurvey>();


                        if (exist == null)
                        {



                            // create new
                            exist = new BOSurvey();
                            

                            exist.CBy = UserId;
                            exist.CDate = DateTime.Now;


                            exist.SaveNew();

                            if (exist.SurveyId > 0)
                            {
                                model.SurveyCode = "";





                            }



                        }
                        else
                        {
                           

                            exist.EBy = UserId;
                            exist.EDate = DateTime.Now;


                            exist.Update();

                           
                        }


                        responseModel.Data = model;
                        responseModel.Total = 1;
                    }
                    catch (Exception ex)
                    {
                        responseModel.Succeeded = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }


        [HttpPost("export")]
        public async Task<IActionResult> export(SurveySearchModel searchModel)
        {
            try
            {


                var ctr = new Criteria<BOSurveyVw>();

                // get by term
                if (!string.IsNullOrEmpty(searchModel.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOSurveyVw.SurveyCode), searchModel.Term));
                }







                if (searchModel.IsActive > 0)
                    ctr.Add(Expression.Eq(nameof(BOSurveyVw.IsActive), searchModel.IsActive == 1 ? true : false));



                if (searchModel.ServeyGroupId > 0)
                    ctr.Add(Expression.Eq(nameof(BOSurveyVw.ServeyGroupId), searchModel.ServeyGroupId));



                // sort by 
                if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                {
                    switch (searchModel.SortBy.Property)
                    {
                        case "serveyGroupName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("serveyGroupName{0}", Language)) : OrderBy.Desc(string.Format("serveyGroupName{0}", Language)));
                            break;
                        case "surveyName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("surveyName{0}", Language)) : OrderBy.Desc(string.Format("surveyName{0}", Language)));
                            break;

                        default:
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                            break;
                    }
                }
                else
                {
                    ctr.Add(OrderBy.Desc(nameof(BOSurveyVw.SurveyId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.Skip(searchModel.Skip)
                             .Take(searchModel.Take)
                             .List<BOSurveyVw>().Select(a => new SurveyListModel()
                             {
                                 SurveyId = a.SurveyId.Value,
                                 ServeyGroupId = a.ServeyGroupId,
                                 SurveyCode = a.SurveyCode,
                                 CreateDate = a.CreateDate,
                                 IsActive = a.IsActive,
                                 ServeyGroupName = Language == "ar" ? a.ServeyGroupNameAr : a.ServeyGroupNameEn,
                                 SurveyName = Language == "ar" ? a.SurveyNameAr : a.SurveyNameEn

                             }).ToList();

                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {





                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "SurveyCode";
                        worksheet.Cell("B1").Value = "CreateDate";
                        worksheet.Cell("C1").Value = "IsActive";
                        worksheet.Cell("D1").Value = "ServeyGroupName";
                        worksheet.Cell("E1").Value = "SurveyName";






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




                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].SurveyCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].CreateDate;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].IsActive;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].ServeyGroupName;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].SurveyName;


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
