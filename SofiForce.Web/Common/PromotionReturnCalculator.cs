using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using SofiForce.Promotion.Helpers;
using SofiForce.Web.Common.PromotionModels;
using System.Threading.Tasks;
using SofiForce.Web.Common;

namespace SofiForce.Promotion
{

    public interface IPromotionReturnCalculator
    {
        public Task<SalesOrderModelWeb> CaluclucateOrder(SalesOrderModelWeb model, string Lan);
        public Task<SalesOrderModelWeb> CaluclucateTotals(SalesOrderModelWeb model);
        public Task<SalesOrderModelWeb> ValidateValidOrder(SalesOrderModelWeb model, string lan);
    }
    public class PromotionReturnCalculator : IPromotionReturnCalculator
    {

        public PromotionReturnCalculator()
        {

        }

        public static string fmt = "yyyy-MM-dd";
        public static Func<object, string> dateformatter = (x => ((DateTime)x).ToString(fmt));





        public async Task<SalesOrderModelWeb> CaluclucateOrder(SalesOrderModelWeb model, string Lan)
        {

            model.SalesOrderDetails = model.SalesOrderDetails.Where(a => a.IsBouns == false).ToList();
            var FinalModel = model;




            try
            {


                #region Calculate Promotion



                #endregion



                FinalModel = await CaluclucateTotals(FinalModel);
                FinalModel.SalesOrderDetails = FinalModel.SalesOrderDetails.OrderBy(a => a.ItemCode).ToList();
            }
            catch
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_PROMOTION);
                return model;
            }


            return FinalModel;
        }
        public async Task<SalesOrderModelWeb> CaluclucateTotals(SalesOrderModelWeb model)
        {



            try
            {
                if (model.SalesOrderDetails != null)
                {
                    model.TaxTotal = -1 * Math.Round(model.SalesOrderDetails.Sum(a => a.TaxValue * a.Quantity).Value, 3);
                    if (model.TaxTotal == null) model.TaxTotal = 0;



                    model.ItemTotal = Math.Round(model.SalesOrderDetails.Sum(a => a.ClientPrice * a.Quantity).Value, 3);
                    if (model.ItemTotal == null) model.ItemTotal = 0;

                    model.ItemDiscountTotal = Math.Round(model.SalesOrderDetails.Sum(a => a.Discount * a.Quantity).Value, 3);
                    if (model.ItemDiscountTotal == null) model.ItemDiscountTotal = 0;


                    model.CustomDiscountTotal = Math.Round(model.SalesOrderDetails.Sum(a => a.CustomDiscount * a.Quantity).Value, 3);
                    if (model.CustomDiscountTotal == null) model.CustomDiscountTotal = 0;



                    model.NetTotal = Math.Round((model.ItemTotal + model.TaxTotal + model.DeliveryTotal - model.ItemDiscountTotal - model.CustomDiscountTotal).Value, 3);


                }
                else
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.ERROR_CALCULATION);
                    return model;
                }

            }
            catch
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_CALCULATION);
                return model;
            }


            return model;

        }
        public async Task<SalesOrderModelWeb> ValidateValidOrder(SalesOrderModelWeb model, string lan)
        {
            try
            {
                model.HasError = false;

                model = await CaluclucateOrder(model, lan);

                //Validate Model
                if (model == null)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }
                if (model.SalesOrderDetails == null || model.SalesOrderDetails.Count == 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_ITEMS);
                }

                // validate Client Is Active
                if (model.ClientId == null || model.ClientId == 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }


                var ClientModel = new Criteria<BOClient>()
                    .Add(Expression.Eq(nameof(BOClient.ClientId), model.ClientId))
                    .FirstOrDefault<BOClient>();

                if (ClientModel == null)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_CLIENT);
                }

                // validate Client Is Active
                if (ClientModel.IsActive != true)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INACTVE_CLIENT);
                }


                // validate SalesMan Is Active
                if (model.RepresentativeId == null || model.RepresentativeId == 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }



                var RepresentativeModel = new Criteria<BORepresentative>()
                    .Add(Expression.Eq(nameof(BORepresentative.RepresentativeId), model.RepresentativeId))
                    .FirstOrDefault<BORepresentative>();


                if (RepresentativeModel == null)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }

                if (RepresentativeModel.IsActive != true)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INACTVE_REP);
                }



                // validate Branch Is Active
                if (model.BranchId == null || model.BranchId == 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }



                var BranchModel = new Criteria<BOBranch>()
                    .Add(Expression.Eq(nameof(BOBranch.BranchId), model.BranchId))
                    .FirstOrDefault<BOBranch>();


                if (BranchModel == null)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }

                if (BranchModel.IsActive != true)
                {
                    model.HasError = true;
                    model.Errors.Add(String.Format(PromotionError.INACTVE_BRANCH, BranchModel.BranchCode));
                }


                // validate Warehouse Is Active
                if (model.StoreId == null || model.StoreId == 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }



                var StoreModel = new Criteria<BOStore>()
                    .Add(Expression.Eq(nameof(BOStore.StoreId), model.StoreId))
                    .FirstOrDefault<BOStore>();


                if (StoreModel == null)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }

                if (StoreModel.IsActive != true)
                {
                    model.HasError = true;
                    model.Errors.Add(String.Format(PromotionError.INACTVE_WAREHOUSE, StoreModel.StoreCode));
                }

                // Validate Expire Date Is Active

                var BatchIds = model.SalesOrderDetails.Where(a => a.Expiration <= DateTime.Now.Date).ToList();
                if (model.Errors.Count > 0)
                {
                    model.HasError = true;
                    model.Errors.Add(String.Format(PromotionError.ITEM_EXPIRED, StoreModel.StoreCode));

                }


            }
            catch (Exception ex)
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_VALIDATION);
            }



            return model;
        }

    }








}