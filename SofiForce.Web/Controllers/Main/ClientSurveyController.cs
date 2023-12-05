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
    public class ClientSurveyController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ClientSurveyController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(ClientSurveySearchModel searchModel)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<ClientSurveyListModel>> responseModel = new ResponseModel<List<ClientSurveyListModel>>();

                try
                {
                    var ctr = new Criteria<BOClientSurveyVw>();

                    // get by term
                    if (!string.IsNullOrEmpty(searchModel.Term))
                    {
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ClientCode), searchModel.Term));
                    }

                    if(FullDataAccess==false)
                        ctr.Add(Expression.In(nameof(BOClientSurveyVw.BranchId), Branchs));

                    if (searchModel.ClientTypeId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ClientTypeId), searchModel.ClientTypeId));

                    if (searchModel.SurveyId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.SurveyId), searchModel.SurveyId));

                    if (searchModel.ServeyStatusId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ServeyStatusId), searchModel.ServeyStatusId));

                    if (searchModel.ClientId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ClientId), searchModel.ClientId));

                    if (searchModel.CreateDate !=null && searchModel.CreateDate.Value.Year>2000)
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.CreateDate), searchModel.CreateDate,dateformatter));

                    if (searchModel.StartDate != null && searchModel.StartDate.Value.Year > 2000)
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.StartDate), searchModel.StartDate, dateformatter));
                    
                    if (searchModel.ServeyGroupId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ServeyGroupId), searchModel.ServeyGroupId));

                    if (searchModel.RepresentativeId > 0)
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.RepresentativeId), searchModel.RepresentativeId));

                    if (searchModel.IsClosed >0)
                        ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.IsClosed), searchModel.IsClosed == 1?true:false));



                    // sort by 
                    if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                    {
                        switch (searchModel.SortBy.Property)
                        {

                            case "clientName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                                break;
                            case "representativeName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
                                break;
                            case "serveyGroupName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("serveyGroupName{0}", Language)) : OrderBy.Desc(string.Format("serveyGroupName{0}", Language)));
                                break;
                            case "serveyStatusName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("serveyStatusName{0}", Language)) : OrderBy.Desc(string.Format("serveyStatusName{0}", Language)));
                                break;
                            case "surveyName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("surveyName{0}", Language)) : OrderBy.Desc(string.Format("surveyName{0}", Language)));
                                break;
                            case "branchName":
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                break;

                            default:
                                ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                                break;
                        }
                    }
                    else
                    {
                        ctr.Add(OrderBy.Desc(nameof(BOClientSurveyVw.SurveyId)));
                    }

                    // get count

                    var Total = ctr.Count();

                    // get paged

                    var res = ctr.Skip(searchModel.Skip)
                                 .Take(searchModel.Take)
                                 .List<BOClientSurveyVw>().Select(a => new ClientSurveyListModel()
                                 {
                                     RepresentativeId = a.RepresentativeId,
                                     CreateDate = a.CreateDate,
                                     ClientTypeId = a.ClientTypeId,
                                     BranchId = a.BranchId,
                                     ClientCode = a.ClientCode,
                                     ClientId = a.ClientId,
                                     ClientServeyId = a.ClientServeyId,
                                     CreateTime = a.CreateTime,
                                     IsClosed = a.IsClosed,
                                     RepresentativeCode = a.RepresentativeCode,
                                     ServeyGroupId = a.ServeyGroupId,
                                     ServeyStatusId = a.ServeyStatusId,
                                     StartDate = a.StartDate,
                                     SurveyId = a.SurveyId.Value,
                                     StartTime = a.StartTime,
                                     BranchCode=a.BranchCode,
                                     ServeyStatusColor=a.ServeyStatusColor,
                                     BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,

                                     ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                     RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                     ServeyGroupName = Language == "ar" ? a.ServeyGroupNameAr : a.ServeyGroupNameEn,
                                     ServeyStatusName = Language == "ar" ? a.ServeyStatusNameAr : a.ServeyStatusNameEn,
                                     SurveyName = Language == "ar" ? a.SurveyNameAr : a.SurveyNameEn,

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


        [HttpPost("save")]
        public async Task<IActionResult> save(ClientSurveyModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientSurveyModel> responseModel = new ResponseModel<ClientSurveyModel>();


                if (model == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = Messages.Invalid_Model;
                    responseModel.StatusCode = 503;
                }
                else
                {
                    if (model.ClientServeyId == 0)
                    {
                        var bo = new BOClientSurvey();
                        bo.BranchId = model.BranchId;
                        bo.SurveyId = model.SurveyId;
                        bo.ClientId = model.ClientId;
                        bo.RepresentativeId = model.RepresentativeId;
                        bo.ServeyStatusId = model.ServeyStatusId;
                        bo.CreateDate = model.CreateTime;
                        bo.CreateTime = model.CreateTime;
                        bo.StartDate = model.CreateTime;
                        bo.StartTime = model.CreateTime;

                        if (model.ServeyStatusId == 2 || model.ServeyStatusId == 3)
                            bo.IsClosed = true;
                        else
                            bo.IsClosed = false;

                        bo.Notes = model.Notes;
                        bo.CanDelete = true;

                        bo.InZone=model.InZone;
                        bo.Distance = model.Distance;


                        bo.CBy = UserId;
                        bo.CDate = DateTime.Now;

                        bo.SaveNew();
                        if (bo.ClientServeyId > 0)
                        {
                            model.ClientServeyId = bo.ClientServeyId.Value;
                            model.IsSynced = true;
                            model.SyncDate = DateTime.Now;

                            foreach (var Question in model.ServeyModel.Details)
                            {
                                var boQuestion = new BOClientSurveyDetail();
                                boQuestion.ClientServeyId = bo.ClientServeyId;
                                boQuestion.SurveyDetailId = Question.SurveyDetailId;
                                boQuestion.SaveNew();
                                foreach (var answer in Question.Answers)
                                {
                                    var boAnswer = new BOClientSurveyDetailAnswer();
                                    boAnswer.ClientDetailId = boQuestion.ClientDetailId;
                                    boAnswer.DetailAnswerId = answer.DetailAnswerId;
                                    boAnswer.ClientServeyId=bo.ClientServeyId;
                                    boAnswer.SurveyDetailId = boQuestion.SurveyDetailId;

                                    boAnswer.IsSelected = false;

                                    if (Question.IsMuliSelect == true)
                                    {
                                        var exist = Question.SelectedAnswerMulti.Where(a => a == answer.DetailAnswerId).FirstOrDefault();
                                        
                                        if (exist > 0)
                                        {
                                            boAnswer.IsSelected = true;

                                        }
                                    }
                                    else
                                    {
                                        if (answer.DetailAnswerId == Question.SelectedAnswerSingle)
                                        {
                                            boAnswer.IsSelected = true;
                                        }
                                    }

                                    boAnswer.SaveNew();
                                }
                            }
                        }
                    }
                    else
                    {
                        var bo = new Criteria<BOClientSurvey>()
                                      .Add(Expression.Eq(nameof(BOClientSurvey.ClientServeyId), model.ClientServeyId))
                                      .FirstOrDefault<BOClientSurvey>();

                        bo.BranchId = model.BranchId;
                        bo.SurveyId = model.SurveyId;
                        bo.ClientId = model.ClientId;
                        bo.RepresentativeId = model.RepresentativeId;
                        bo.ServeyStatusId = model.ServeyStatusId;
                        bo.CreateDate = model.CreateTime;
                        bo.CreateTime = model.CreateTime;
                        bo.StartDate = model.CreateTime==null ? DateTime.Now: model.CreateTime;
                        bo.StartTime = model.CreateTime == null ? DateTime.Now : model.CreateTime;

                        if (model.ServeyStatusId == 2 || model.ServeyStatusId == 3)
                            bo.IsClosed = true;
                        else
                            bo.IsClosed = false;

                        bo.Notes = model.Notes;
                        bo.CanDelete = true;


                        bo.InZone = model.InZone;
                        bo.Distance = model.Distance;

                        bo.EBy = UserId;
                        bo.EDate = DateTime.Now;

                        bo.Update();


                        model.IsSynced = true;
                        model.SyncDate = DateTime.Now;

                        bo.DeleteAllClientSurveyDetail();
                        bo.DeleteAllClientSurveyDetailAnswer();

                        foreach (var Question in model.ServeyModel.Details)
                        {
                            var boQuestion = new BOClientSurveyDetail();
                            boQuestion.ClientServeyId = bo.ClientServeyId;
                            boQuestion.SurveyDetailId = Question.SurveyDetailId;
                            boQuestion.SaveNew();
                            foreach (var answer in Question.Answers)
                            {
                                var boAnswer = new BOClientSurveyDetailAnswer();
                                boAnswer.ClientDetailId = boQuestion.ClientDetailId;
                                boAnswer.DetailAnswerId = answer.DetailAnswerId;
                                boAnswer.ClientServeyId = bo.ClientServeyId;
                                boAnswer.SurveyDetailId = boQuestion.SurveyDetailId;

                                boAnswer.IsSelected = false;

                                if (Question.IsMuliSelect == true)
                                {
                                    var exist = Question.SelectedAnswerMulti.Where(a => a == answer.DetailAnswerId).FirstOrDefault();

                                    if (exist > 0)
                                    {
                                        boAnswer.IsSelected = true;

                                    }
                                }
                                else
                                {
                                    if (answer.DetailAnswerId == Question.SelectedAnswerSingle)
                                    {
                                        boAnswer.IsSelected = true;
                                    }
                                }

                                boAnswer.SaveNew();
                            }
                        }
                    }
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
                ResponseModel<ClientSurveyModel> responseModel = new ResponseModel<ClientSurveyModel>();

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
                        

                        var exist = new Criteria<BOClientSurvey>()
                                       .Add(Expression.Eq(nameof(BOClientSurvey.ClientServeyId), Id))
                                       .FirstOrDefault<BOClientSurvey>();


                        var res = _mapper.Map<ClientSurveyModel>(exist);


                        if (res != null)
                        {
                            // get empty survey
                            SurveyModel surveyModel = new SurveyModel();
                            var surveyDetail = new Criteria<BOSurveyDetail>()
                                                         .Add(Expression.Eq(nameof(BOSurveyDetail.SurveyId), exist.SurveyId))
                                                         .List<BOSurveyDetail>();

                            var surveyAnswers = new Criteria<BOSurveyDetailAnswer>()
                                 .Add(Expression.Eq(nameof(BOSurveyDetailAnswer.SurveyId), exist.SurveyId))
                                 .List<BOSurveyDetailAnswer>();

                            foreach (var question in surveyDetail)
                            {
                                surveyModel.Details.Add(new SurveyDetailListModel()
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

                            // fill survey

                            var clientAnswers = new Criteria<BOClientSurveyDetailAnswer>()
                                         .Add(Expression.Eq(nameof(BOClientSurveyDetailAnswer.ClientServeyId), exist.ClientServeyId))
                                         .Add(Expression.Eq(nameof(BOClientSurveyDetailAnswer.IsSelected), true))
                                         .List<BOClientSurveyDetailAnswer>();


                            foreach (var item in surveyModel.Details)
                            {
                                if (item.IsMuliSelect == true)
                                {
                                    item.SelectedAnswerMulti = clientAnswers.Where(a => a.SurveyDetailId == item.SurveyDetailId).Select(a => a.DetailAnswerId.Value).ToList();
                                }
                                else
                                {
                                    item.SelectedAnswerSingle= clientAnswers.Where(a=>a.SurveyDetailId==item.SurveyDetailId).Select(a=> a.DetailAnswerId.Value).FirstOrDefault();

                                   
                                }
                            }


                            res.ServeyModel=surveyModel;
                        }


                        responseModel.Data = res;
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

        [HttpPost("delete")]
        public async Task<IActionResult> delete(ClientSurveyModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientSurveyModel> responseModel = new ResponseModel<ClientSurveyModel>();

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
                        var exist = new Criteria<BOClientSurvey>()
                                        .Add(Expression.Eq(nameof(model.ClientServeyId), model.ClientServeyId))
                                        .FirstOrDefault<BOClientSurvey>();


                        if (exist != null)
                        {
                            if (exist.IsClosed == false)
                            {
                                exist.Delete();
                            }

                        }
                        else
                        {
                            responseModel.Succeeded = false;
                            responseModel.StatusCode = 500;
                            responseModel.Message = Messages.Invalid_Model;
                            return responseModel;
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
        public async Task<IActionResult> export(ClientSurveySearchModel searchModel)
        {
            try
            {


                var ctr = new Criteria<BOClientSurveyVw>();

                // get by term
                if (!string.IsNullOrEmpty(searchModel.Term))
                {
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ClientCode), searchModel.Term));
                }

                if (FullDataAccess == false)
                    ctr.Add(Expression.In(nameof(BOClientSurveyVw.BranchId), Branchs));

                if (searchModel.ClientTypeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ClientTypeId), searchModel.ClientTypeId));

                if (searchModel.SurveyId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.SurveyId), searchModel.SurveyId));

                if (searchModel.ServeyStatusId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ServeyStatusId), searchModel.ServeyStatusId));

                if (searchModel.ClientId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ClientId), searchModel.ClientId));

                if (searchModel.CreateDate != null && searchModel.CreateDate.Value.Year > 2000)
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.CreateDate), searchModel.CreateDate, dateformatter));

                if (searchModel.StartDate != null && searchModel.StartDate.Value.Year > 2000)
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.StartDate), searchModel.StartDate, dateformatter));

                if (searchModel.ServeyGroupId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.ServeyGroupId), searchModel.ServeyGroupId));

                if (searchModel.RepresentativeId > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.RepresentativeId), searchModel.RepresentativeId));

                if (searchModel.IsClosed > 0)
                    ctr.Add(Expression.Eq(nameof(BOClientSurveyVw.IsClosed), searchModel.IsClosed == 1 ? true : false));



                // sort by 
                if (searchModel.SortBy != null && !string.IsNullOrEmpty(searchModel.SortBy.Property) && !string.IsNullOrEmpty(searchModel.SortBy.Order))
                {
                    switch (searchModel.SortBy.Property)
                    {

                        case "clientName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("clientName{0}", Language)) : OrderBy.Desc(string.Format("clientName{0}", Language)));
                            break;
                        case "representativeName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("representativeName{0}", Language)) : OrderBy.Desc(string.Format("representativeName{0}", Language)));
                            break;
                        case "serveyGroupName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("serveyGroupName{0}", Language)) : OrderBy.Desc(string.Format("serveyGroupName{0}", Language)));
                            break;
                        case "serveyStatusName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("serveyStatusName{0}", Language)) : OrderBy.Desc(string.Format("serveyStatusName{0}", Language)));
                            break;
                        case "surveyName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("surveyName{0}", Language)) : OrderBy.Desc(string.Format("surveyName{0}", Language)));
                            break;
                        case "branchName":
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                            break;

                        default:
                            ctr.Add(searchModel.SortBy.Order == "asc" ? OrderBy.Asc(searchModel.SortBy.Property) : OrderBy.Desc(searchModel.SortBy.Property));
                            break;
                    }
                }
                else
                {
                    ctr.Add(OrderBy.Desc(nameof(BOClientSurveyVw.SurveyId)));
                }

                // get count

                var Total = ctr.Count();

                // get paged

                var res = ctr.List<BOClientSurveyVw>().Select(a => new ClientSurveyListModel()
                             {
                                 RepresentativeId = a.RepresentativeId,
                                 CreateDate = a.CreateDate,
                                 ClientTypeId = a.ClientTypeId,
                                 BranchId = a.BranchId,
                                 ClientCode = a.ClientCode,
                                 ClientId = a.ClientId,
                                 ClientServeyId = a.ClientServeyId,
                                 CreateTime = a.CreateTime,
                                 IsClosed = a.IsClosed,
                                 RepresentativeCode = a.RepresentativeCode,
                                 ServeyGroupId = a.ServeyGroupId,
                                 ServeyStatusId = a.ServeyStatusId,
                                 StartDate = a.StartDate,
                                 SurveyId = a.SurveyId.Value,
                                 StartTime = a.StartTime,
                                 BranchCode = a.BranchCode,
                                 ServeyStatusColor = a.ServeyStatusColor,
                                 BranchName = Language == "ar" ? a.BranchNameAr : a.BranchNameEn,

                                 ClientName = Language == "ar" ? a.ClientNameAr : a.ClientNameEn,
                                 RepresentativeName = Language == "ar" ? a.RepresentativeNameAr : a.RepresentativeNameEn,
                                 ServeyGroupName = Language == "ar" ? a.ServeyGroupNameAr : a.ServeyGroupNameEn,
                                 ServeyStatusName = Language == "ar" ? a.ServeyStatusNameAr : a.ServeyStatusNameEn,
                                 SurveyName = Language == "ar" ? a.SurveyNameAr : a.SurveyNameEn,

                             }).ToList();

                using (MemoryStream stream = new MemoryStream())
                {
                    using (var workbook = new XLWorkbook())
                    {


                        var worksheet = workbook.Worksheets.Add("data");

                        worksheet.Cell("A1").Value = "ClientCode";
                        worksheet.Cell("B1").Value = "ClientName";
                        worksheet.Cell("C1").Value = "RepresentativeCode";
                        worksheet.Cell("D1").Value = "BranchCode";
                        worksheet.Cell("E1").Value = "BranchName";
                        worksheet.Cell("F1").Value = "SurveyName";
                        worksheet.Cell("G1").Value = "ServeyStatusName";
                        worksheet.Cell("H1").Value = "ServeyGroupName";
                        worksheet.Cell("I1").Value = "CreateTime";
                        worksheet.Cell("J1").Value = "StartTime";
                        worksheet.Cell("K1").Value = "IsClosed";





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



                        for (int i = 0; i < res.Count; i++)
                        {
                            worksheet.Cell(string.Format("A{0}", i + 2)).Value = res[i].ClientCode;
                            worksheet.Cell(string.Format("B{0}", i + 2)).Value = res[i].ClientName;
                            worksheet.Cell(string.Format("C{0}", i + 2)).Value = res[i].RepresentativeCode;
                            worksheet.Cell(string.Format("D{0}", i + 2)).Value = res[i].BranchCode;
                            worksheet.Cell(string.Format("E{0}", i + 2)).Value = res[i].BranchName;
                            worksheet.Cell(string.Format("F{0}", i + 2)).Value = res[i].SurveyName;
                            worksheet.Cell(string.Format("G{0}", i + 2)).Value = res[i].ServeyStatusName;
                            worksheet.Cell(string.Format("H{0}", i + 2)).Value = res[i].ServeyGroupName;
                            worksheet.Cell(string.Format("I{0}", i + 2)).Value = res[i].CreateTime;
                            worksheet.Cell(string.Format("J{0}", i + 2)).Value = res[i].StartTime;
                            worksheet.Cell(string.Format("K{0}", i + 2)).Value = res[i].IsClosed;

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
