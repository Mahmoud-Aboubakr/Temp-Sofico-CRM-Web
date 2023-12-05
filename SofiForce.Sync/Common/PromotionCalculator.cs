using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using SofiForce.Promotion.Helpers;
using SofiForce.Sync.Common.PromotionModels;
using System.Threading.Tasks;
using SofiForce.Sync.Common;

namespace SofiForce.Promotion
{

    public interface IPromotionCalculator
    {
        public Task<SalesOrderModelMobile> CaluclucateOrder(SalesOrderModelMobile model, string Lan);
        public Task<SalesOrderModelMobile> CaluclucateTotals(SalesOrderModelMobile model);
        public Task<SalesOrderModelMobile> ValidateOrder(SalesOrderModelMobile model, string lan);
    }
    public class PromotionCalculator:IPromotionCalculator
    {

        public PromotionCalculator()
        {

        }

        public static string fmt = "yyyy-MM-dd";
        public static Func<object, string> dateformatter = (x => ((DateTime)x).ToString(fmt));

      



        public async Task<SalesOrderModelMobile> CaluclucateOrder (SalesOrderModelMobile model,string Lan)
        {

            model.SalesOrderDetails = model.SalesOrderDetails.Where(a => a.IsBouns == false).ToList();
            var FinalModel = model;

            //reset discount
            foreach (var item in FinalModel.SalesOrderDetails)
            {

                item.Discount = 0;
                item.CashDiscount = 0;
                item.PromotionCode = "";
                

            }


            try
            {

                #region Recheck Prices
                // recheck Prices

                var ItemStr = model.SalesOrderDetails.Select(x => x.ItemId).ToList();

                var Items = new Criteria<BOItem>()
                        .Add(Expression.In(nameof(BOItem.ItemId), string.Join(',', ItemStr)))
                        .List<BOItem>();


                foreach (var item in Items)
                {
                    foreach (var ordertem in model.SalesOrderDetails)
                    {


                        if (item.ItemCode == ordertem.ItemCode)
                        {
                            if (ordertem.ItemStoreId == null) ordertem.ItemStoreId = 0;

                            ordertem.ClientPrice = (double?)item.ClientPrice;
                            ordertem.PublicPrice = (double?)item.PublicPrice;
                            ordertem.LineValue = Math.Round((double)ordertem.Quantity * (double)ordertem.ClientPrice, 3);

                            if (item.IsTaxable == true)
                            {
                                ordertem.TaxValue = Math.Round(0.14 * (double)(ordertem.ClientPrice), 3);
                            }

                        }
                    }
                }
                #endregion

                #region EnablePromotionTax
                bool EnablePromotionTax = false;
                var boTaxSetting = new Criteria<BOAppSetting>().Add(Expression.Eq(nameof(BOAppSetting.SettingCode), "ORDER.PROMOTION.TAX")).FirstOrDefault<BOAppSetting>();

                if (boTaxSetting != null)
                {
                    bool.TryParse(boTaxSetting.SettingValue, out EnablePromotionTax);
                }
                #endregion



                Items = null;
                ItemStr = null;

                FinalModel =await CaluclucateTotals(FinalModel);
                FinalModel.SalesOrderDetails = FinalModel.SalesOrderDetails.OrderBy(a => a.ItemCode).ToList();
            }
            catch
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_PROMOTION);
                return model;
            }
            

            return  FinalModel;
        }
        public async Task<SalesOrderModelMobile> CaluclucateTotals(SalesOrderModelMobile model)
        {



            try
            {
                if (model.SalesOrderDetails != null)
                {
                    //reclac tax value
                    foreach (var item in model.SalesOrderDetails)
                    {
                        if (item.TaxValue > 0)
                        {
                            item.TaxValue =Math.Round(((double)item.ClientPrice - (double)item.Discount) * 0.14,3);
                        }
                    }

                    model.TaxTotal = Math.Round(model.SalesOrderDetails.Sum(a => a.TaxValue *a.Quantity).Value, 3);
                    if (model.TaxTotal == null) model.TaxTotal = 0;

                    var Delivery_Fees = new Criteria<BOAppSetting>().Add(Expression.Eq(nameof(BOAppSetting.SettingCode), "ORDER.DELIVERY")).FirstOrDefault<BOAppSetting>();
                    if (Delivery_Fees != null)
                    {
                        model.DeliveryTotal = Math.Round(double.Parse(Delivery_Fees.SettingValue), 3);
                        if (model.DeliveryTotal == null) model.DeliveryTotal = 0;
                    }

                    model.ItemTotal = Math.Round(model.SalesOrderDetails.Sum(a => a.ClientPrice * a.Quantity).Value, 3);
                    if (model.ItemTotal == null) model.ItemTotal = 0;

                    model.ItemDiscountTotal = Math.Round(model.SalesOrderDetails.Sum(a => a.Discount * a.Quantity).Value, 3);
                    if (model.ItemDiscountTotal == null) model.ItemDiscountTotal = 0;


                    model.CustomDiscountTotal = Math.Round(model.SalesOrderDetails.Sum(a => a.CustomDiscount * a.Quantity).Value, 3);
                    if (model.CustomDiscountTotal == null) model.CustomDiscountTotal = 0;



                    model.NetTotal = Math.Round((model.ItemTotal + model.TaxTotal + model.DeliveryTotal - model.ItemDiscountTotal - model.CustomDiscountTotal).Value, 3);

                    if (model.NetTotal < 0)
                    {
                        model.HasError = true;
                        model.Errors.Add(PromotionError.INVALID_TOTAL);
                    }
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
        public async  Task<SalesOrderModelMobile> ValidateOrder(SalesOrderModelMobile model,string lan)
        {
            try
            {
                model.HasError = false;




                model = await CaluclucateOrder(model,lan);

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

                // chck expired
                var expired = model.SalesOrderDetails.Where(x => x.Expiration<DateTime.Now.Date).ToList();

                if (expired.Count>0)
                {
                    model.HasError = true;
                    foreach (var x in expired)
                    {
                        model.Errors.Add(String.Format(PromotionError.ITEM_EXPIRED, x.ItemCode));
                    }
                }

                if (model.Errors.Count > 0)
                {
                    model.HasError = true;
                }



                // validate Client Credit Limit

                if (((ClientModel.CreditLimit- ClientModel.CreditBalance) - (decimal)model.NetTotal) < 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_CREDIT);
                }





                // Validate Batch Is Active

                var BatchIds = model.SalesOrderDetails.Where(a => a.ItemStoreId > 0).Select(x => x.ItemStoreId).ToList();

                var Batchs = new Criteria<BOItemStoreVw>()
                           .Add(Expression.In(nameof(BOItemStoreVw.ItemStoreId), string.Join(',', BatchIds)))
                           .List<BOItemStoreVw>();

                if (Batchs != null)
                {
                    var InactiveBatchs = Batchs.Where(a => a.IsActive == false).ToList();
                    foreach (var batch in InactiveBatchs)
                    {
                        model.Errors.Add(String.Format(PromotionError.INVALID_BATCH, batch.ItemCode, batch.BatchNo));
                    }
                }


                if (model.Errors.Count > 0)
                {
                    model.HasError = true;
                }


                // validate Minimum Invoice Total (200 as Minimum)
                var min_Order = new Criteria<BOAppSetting>().Add(Expression.Eq(nameof(BOAppSetting.SettingCode), "ORDER.MIN")).FirstOrDefault<BOAppSetting>();




                if (min_Order != null)
                {
                    if (model.ItemTotal < double.Parse(min_Order.SettingValue))
                    {
                        model.HasError = true;
                        model.Errors.Add(String.Format(PromotionError.INVALID_ORDER_TOTAL, min_Order.SettingValue));
                    }
                }
            }
            catch(Exception ex)
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_VALIDATION);
            }

            

            return model;
        }

    }



  




}
