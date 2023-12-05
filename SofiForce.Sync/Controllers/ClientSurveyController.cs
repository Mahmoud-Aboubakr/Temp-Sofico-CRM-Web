using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Sync.Controllers
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



        [HttpPost("save")]
        public async Task<IActionResult> save(ClientSurveyModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<ClientSurveyModel> responseModel = new ResponseModel<ClientSurveyModel>();


                if (model == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";
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


     
    }
}
