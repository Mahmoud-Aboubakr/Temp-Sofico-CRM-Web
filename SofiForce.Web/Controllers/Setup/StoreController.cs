using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Controllers.CRM.Setup
{
    [Route("api/[controller]")]
    public class StoreController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public StoreController(IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            _mapper = mapper;
            this._env = env;
            this._configuration = configuration;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> filter(StoreSearchModel model)
        {

            var task = Task.Factory.StartNew(() =>
            {
                ResponseModel<List<StoreListModel>> responseModel = new ResponseModel<List<StoreListModel>>();

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


                        var ctr = new Criteria<BOStoreVw>();

                        if (this.FullDataAccess == false)
                        {
                            ctr.Add(Expression.In(nameof(BOStoreVw.StoreId), this.Stores));

                        }


                        // get by term
                        if (!string.IsNullOrEmpty(model.Term))
                        {
                            ctr.Add(Expression.Like(nameof(BOStoreVw.StoreCode), model.Term));
                        }

                        
                        if (model.StoreTypeId > 0)
                            ctr.Add(Expression.Eq(nameof(BOStoreVw.StoreTypeId), model.StoreTypeId));



                        if (model.IsOrder > 0)
                            ctr.Add(Expression.Eq(nameof(BOStoreVw.IsOrder), model.IsOrder==1?true:false));


                        if (model.IsActive > 0)
                            ctr.Add(Expression.Eq(nameof(BOStoreVw.IsActive), model.IsActive == 1 ? true : false));


                        // sort by 
                        if (model.SortBy != null && !string.IsNullOrEmpty(model.SortBy.Property) && !string.IsNullOrEmpty(model.SortBy.Order))
                        {

                            switch (model.SortBy.Property)
                            {
                                case "storeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("storeName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "branchName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("branchName{0}", Language)) : OrderBy.Desc(string.Format("branchName{0}", Language)));
                                    break;
                                case "storeTypeName":
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(string.Format("storeTypeName{0}", Language)) : OrderBy.Desc(string.Format("storeTypeName{0}", Language)));
                                    break;
                                default:
                                    ctr.Add(model.SortBy.Order == "asc" ? OrderBy.Asc(model.SortBy.Property) : OrderBy.Desc(model.SortBy.Property));
                                    break;
                            }

                        }
                        else
                        {
                            ctr.Add(OrderBy.Asc(nameof(BOStoreVw.StoreId)));
                        }

                        // get count

                        var Total = ctr.Count();

                        // get paged

                        var res = ctr.Skip(model.Skip)
                                     .Take(model.Take>0?model.Take:30)
                                     .List<BOStoreVw>()
                                     .Select(a => new StoreListModel()
                                     {
                                         StoreId = a.StoreId,
                                         StoreCode = a.StoreCode,
                                         BranchCode = a.BranchCode,
                                         BranchId = a.BranchId,
                                         CanDelete = a.CanDelete,
                                         CanEdit = a.CanEdit,
                                         Color = a.Color,
                                         Icon = a.Icon,
                                         IsActive = a.IsActive,
                                         IsOrder=a.IsOrder,
                                         StoreTypeId = a.StoreTypeId,
                                         DisplayOrder = a.DisplayOrder,
                                         BranchName=Language=="ar"? a.BranchNameAr:a.BranchNameEn,
                                         StoreName = Language=="ar"?a.StoreNameAr:a.StoreNameEn,
                                         StoreTypeName=Language=="ar"?a.StoreTypeNameAr:a.StoreTypeNameEn,


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
                ResponseModel<StoreModel> responseModel = new ResponseModel<StoreModel>();

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
                        var exist = new Criteria<BOStore>()
                                        .Add(Expression.Eq(nameof(BOStore.StoreId), Id))
                                        .FirstOrDefault<BOStore>();
                        if (exist != null)
                        {
                            responseModel.Data = _mapper.Map<StoreModel>(exist);
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
                        responseModel.Message = ex.Message;;
                    }
                }
                return responseModel;

            });
            await task;

            return Ok(task.Result);
        }
    }
}
