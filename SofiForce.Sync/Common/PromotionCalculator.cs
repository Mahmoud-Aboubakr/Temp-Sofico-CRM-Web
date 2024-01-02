using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using SofiForce.Promotion.Helpers;
using SofiForce.Sync.Common.PromotionModels;
using System.Threading.Tasks;
using SofiForce.Sync.Common;
using DocumentFormat.OpenXml.Drawing;

namespace SofiForce.Promotion
{

    public interface IPromotionCalculator
    {
        public Task<SalesOrderModelMobile> CaluclucateOrder(SalesOrderModelMobile model, string Lan);
        public Task<SalesOrderModelMobile> CaluclucateCashDiscount(SalesOrderModelMobile model); 
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

                #region Calculate Promotion

                // get All Promotions 





                // get All Promotion For Item
                var promos = await PromotionHelper.getOrderPromotions(model);

                if (promos != null)
                {



                    foreach (var p in promos)
                    {

                        bool IsApplied = false;

                        if (p.IsDone == true)
                        {
                            continue;
                        }

                        var promo = new BOPromotion(p.PromotionId);

                        if (promo.Repeats == 0) promo.Repeats = int.MaxValue;

                        // get Groups

                        var groups = new Criteria<BOPromotionMixGroup>()
                                    .Add(Expression.Eq(nameof(BOPromotionMixGroup.PromotionId), promo.PromotionId))
                                    .List<BOPromotionMixGroup>();

                        // get Outcomes

                        var outCome = new Criteria<BOPromotionOutcome>()
                                    .Add(Expression.Eq(nameof(BOPromotionOutcome.PromotionId), promo.PromotionId))
                                    .List<BOPromotionOutcome>();


                        //todo get promomtion Items
                        var itemCriteria = new Criteria<BOPromotionItem>()
                                         .Add(Expression.Eq(nameof(BOPromotionItem.PromotionId), promo.PromotionId))
                                        .List<BOPromotionItem>();




                        //get conditionType
                        var conditionType = new Criteria<BOPromotionType>()
                                            .Add(Expression.Eq(nameof(BOPromotionType.PromotionTypeId), promo.PromotionTypeId))
                                            .FirstOrDefault<BOPromotionType>();


                        if (conditionType != null)
                        {
                            // if Promotion PromotionCriteria (Quanity)
                            int PromotionCriteria = conditionType.PromotionInputId.Value;
                            int PromotionResultOutCome = conditionType.PromotionOutputId.Value;


                            #region Criteria_Quantity
                            if (PromotionCriteria == (int)PromotionCriteriaEnum.Quantity)
                            {
                                #region Outcome_Value
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.Value)
                                {



                                    foreach (var critriaCode in itemCriteria)
                                    {
                                        var QTY = FinalModel.SalesOrderDetails
                                                   .Where(a => a.IsBouns == false)
                                                   .Where(a => a.ItemCode == critriaCode.ItemCode)
                                                   .Sum(a => a.Quantity);

                                        var slices = outCome.OrderByDescending(a => a.Slice).ToList();

                                        foreach (var s in slices)
                                        {
                                            if (QTY >= (double?)s.Slice)
                                            {
                                                var Disount = Math.Round((double)s.Value / (double)s.Slice, 3);

                                                foreach (var item in FinalModel.SalesOrderDetails)
                                                {
                                                    if (item.IsBouns == false)
                                                    {
                                                        if (item.ItemCode == critriaCode.ItemCode)
                                                        {
                                                            item.Discount += Disount;

                                                            IsApplied = true;
                                                        }
                                                    }

                                                }

                                                break;
                                            }
                                        }

                                        slices = null;
                                    }


                                }
                                #endregion
                                #region Outcome_Percentage
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.Percentage)
                                {
                                    foreach (var critriaCode in itemCriteria)
                                    {
                                        var QTY = FinalModel.SalesOrderDetails
                                                           .Where(a => a.IsBouns == false)
                                                           .Where(a => a.ItemCode == critriaCode.ItemCode)
                                                           .Sum(a => a.Quantity);

                                        double? slice_percentage = 0;
                                        foreach (var c in outCome.OrderByDescending(a => a.Slice).ToList())
                                        {
                                            if (QTY >= (double?)c.Slice)
                                            {
                                                slice_percentage = (double?)c.Value / 100;
                                                break;
                                            }
                                        }

                                        if (slice_percentage != null && slice_percentage > 0)
                                        {

                                            foreach (var item in FinalModel.SalesOrderDetails)
                                            {
                                                if (item.IsBouns == false)
                                                {
                                                    if (item.ItemCode == critriaCode.ItemCode)
                                                    {

                                                        item.Discount += Math.Round((double)(slice_percentage * item.ClientPrice), 3);
                                                        IsApplied = true;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                                #endregion
                                #region Outcome_FreeGood
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.FreeGood)
                                {
                                    var critriaCode = itemCriteria.FirstOrDefault();
                                    var itemOutcomeCodes = outCome.GroupBy(a => a.ItemCode).ToList().FirstOrDefault();

                                    if (itemOutcomeCodes != null)
                                    {
                                        //check if valid 
                                        var ORDER_QTY = model.SalesOrderDetails
                                                            .Where(a => a.IsBouns == false)
                                                            .Where(a => a.ItemCode == critriaCode.ItemCode)
                                                            .Sum(a => a.Quantity);


                                        var slice = outCome.Where(a => a.ItemCode == itemOutcomeCodes.Key).OrderByDescending(a => a.Slice).ToList();
                                        int FINAL_QTY = 0;

                                        foreach (var option in slice)
                                        {


                                            while (ORDER_QTY >= option.Slice)
                                            {
                                                ORDER_QTY -= (int)option.Slice;
                                                FINAL_QTY += (int)option.Value;
                                            }

                                        }



                                        // Get Result

                                        if (FINAL_QTY > 0)
                                        {
                                            var PromotionItem = new Criteria<BOItemVw>().Add(Expression.Eq(nameof(BOItemVw.ItemCode), itemOutcomeCodes.Key)).FirstOrDefault<BOItemVw>();

                                            IList<BOItemStoreVw> Batchs = new List<BOItemStoreVw>();

                                            if (PromotionItem != null)
                                            {

                                                Batchs = new Criteria<BOItemStoreVw>()
                                                                        .Add(Expression.Eq(nameof(BOItemStoreVw.ItemCode), PromotionItem.ItemCode))
                                                                        .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), FinalModel.StoreId))
                                                                        .Add(Expression.Gt(nameof(BOItemStoreVw.Available), 0))
                                                                        .Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), DateTime.Now.Date))

                                                                        .Add(OrderBy.Asc(nameof(BOItemStoreVw.ExpireDate)))
                                                                        .List<BOItemStoreVw>();



                                                if (Batchs != null && Batchs.Count > 0)
                                                {
                                                    var ALL_BATCH_COUNT = Batchs.Sum(a => a.Available);

                                                    if (ALL_BATCH_COUNT >= FINAL_QTY)
                                                    {
                                                        foreach (var b in Batchs)
                                                        {
                                                            var ORDER_QTY_ALL = model.SalesOrderDetails
                                                                        .Where(a => a.ItemStoreId == b.ItemStoreId)
                                                                        .Sum(a => a.Quantity);
                                                            var Available = b.Available - ORDER_QTY_ALL;
                                                            if (Available <= FINAL_QTY)
                                                            {
                                                                if (Available > 0)
                                                                {
                                                                    FinalModel.SalesOrderDetails.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = Available,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                                    });

                                                                    FINAL_QTY -= Available.Value;

                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (FINAL_QTY > 0)
                                                                {
                                                                    FinalModel.SalesOrderDetails.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = FINAL_QTY,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,

                                                                    });
                                                                }


                                                                break;
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        //error

                                                        model.HasError = true;
                                                        //The the avaiable quantity for batch {0} in item {1} is {2} , please try again
                                                        model.Errors.Add(String.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem.ItemCode));
                                                    }
                                                }
                                                else
                                                {
                                                    //error

                                                    model.HasError = true;
                                                    //The the avaiable quantity for batch {0} in item {1} is {2} , please try again
                                                    model.Errors.Add(String.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem.ItemCode));
                                                }

                                            }

                                            IsApplied = true;

                                        }


                                        slice = null;
                                        critriaCode = null;
                                        itemOutcomeCodes = null;
                                    }

                                }
                                #endregion
                                #region Outcome_FreeGoodOption
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.FreeGoodOption)
                                {
                                    //input
                                    var critriaCode = itemCriteria.FirstOrDefault();



                                    var Options = outCome.GroupBy(a => a.ItemCode).Select(a => a.Key).ToList();

                                    //check if valid 
                                    foreach (var ot in Options)
                                    {

                                        var ORDER_QTY = model.SalesOrderDetails
                                                   .Where(a => a.IsBouns == false)
                                                   .Where(a => a.ItemCode == critriaCode.ItemCode)
                                                   .Sum(a => a.Quantity);

                                        var slice = outCome.Where(a => a.ItemCode == ot).OrderByDescending(a => a.Slice).ToList();
                                        int FINAL_QTY = 0;

                                        foreach (var option in slice)
                                        {

                                            while (ORDER_QTY >= option.Slice)
                                            {
                                                ORDER_QTY -= (int)option.Slice;
                                                FINAL_QTY += (int)option.Value;
                                            }

                                        }


                                        if (FINAL_QTY > 0)
                                        {


                                            var PromotionItem = new Criteria<BOItemVw>().Add(Expression.Eq(nameof(BOItemVw.ItemCode), ot)).FirstOrDefault<BOItemVw>();

                                            IList<BOItemStoreVw> Batchs = new List<BOItemStoreVw>();

                                            if (PromotionItem != null)
                                            {

                                                Batchs = new Criteria<BOItemStoreVw>()
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.ItemCode), PromotionItem.ItemCode))
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), FinalModel.StoreId))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.Available), 0))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), DateTime.Now.Date))
                                                                    .Add(OrderBy.Asc(nameof(BOItemStoreVw.ExpireDate)))
                                                                    .List<BOItemStoreVw>();

                                                if (Batchs != null && Batchs.Count > 0)
                                                {
                                                    var ALL_BATCH_COUNT = Batchs.Sum(a => a.Available);
                                                    if (ALL_BATCH_COUNT >= FINAL_QTY)
                                                    {

                                                        var OptionModel = new SalesOrderPromotionOptionModel();
                                                        OptionModel.RowId = FinalModel.PromotionOptions.Count + 1;
                                                        OptionModel.Selected = false;
                                                        OptionModel.PromotionId = promo.PromotionId.Value.ToString();
                                                        OptionModel.ItemName = Lan == "ar" ? PromotionItem.ItemNameAr : PromotionItem.ItemNameEn;
                                                        OptionModel.ItemCode = PromotionItem.ItemCode;
                                                        OptionModel.Quantity = FINAL_QTY;

                                                        foreach (var b in Batchs)
                                                        {
                                                            var ORDER_QTY_ALL = model.SalesOrderDetails
                                                                       .Where(a => a.ItemStoreId == b.ItemStoreId)
                                                                       .Sum(a => a.Quantity);
                                                            var Available = b.Available - ORDER_QTY_ALL;

                                                            if (Available <= FINAL_QTY)
                                                            {
                                                                if (Available > 0)
                                                                {
                                                                    OptionModel.Batchs.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = Available,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                                    });

                                                                    FINAL_QTY -= Available.Value;
                                                                }



                                                            }
                                                            else
                                                            {
                                                                if (FINAL_QTY > 0)
                                                                {
                                                                    OptionModel.Batchs.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = FINAL_QTY,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,

                                                                    });
                                                                }


                                                                break;
                                                            }

                                                        }


                                                        FinalModel.PromotionOptions.Add(OptionModel);


                                                    }
                                                }

                                            }

                                            IsApplied = true;

                                        }

                                        slice = null;
                                    }


                                    critriaCode = null;
                                    Options = null;

                                }
                                #endregion
                            }
                            #endregion

                            #region Criteria_Value
                            if (PromotionCriteria == (int)PromotionCriteriaEnum.Value)
                            {
                                #region Outcome_Value
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.Value)
                                {
                                    foreach (var critriaCode in itemCriteria)
                                    {
                                        var VALUE = FinalModel.SalesOrderDetails
                                                           .Where(a => a.IsBouns == false)
                                                           .Where(a => a.ItemCode == critriaCode.ItemCode)
                                                           .Sum(a => a.Quantity * a.ClientPrice);

                                        var QTY = FinalModel.SalesOrderDetails
                                                   .Where(a => a.IsBouns == false)
                                                   .Where(a => a.ItemCode == critriaCode.ItemCode)
                                                   .Sum(a => a.Quantity);

                                        double? slice = 0;
                                        double? slice_Value = 0;

                                        foreach (var c in outCome.OrderByDescending(a => a.Slice).ToList())
                                        {
                                            if (VALUE >= (double?)c.Slice)
                                            {
                                                slice = (double?)c.Slice;
                                                slice_Value = (double?)c.Value;
                                                break;
                                            }
                                        }

                                        if (slice != null && slice > 0 && slice_Value > 0)
                                        {

                                            var Disount = (VALUE / slice) * slice_Value;
                                            var Disount_Item = Disount / QTY;

                                            foreach (var item in FinalModel.SalesOrderDetails)
                                            {
                                                if (item.IsBouns == false)
                                                {
                                                    if (item.ItemCode == critriaCode.ItemCode)
                                                    {
                                                        item.Discount += Math.Round((double)Disount_Item, 3);
                                                        IsApplied = true;

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region Outcome_Percentage
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.Percentage)
                                {
                                    double VALUE = 0;
                                    foreach (var critriaCode in itemCriteria)
                                    {

                                        VALUE += FinalModel.SalesOrderDetails
                                                           .Where(a => a.IsBouns == false)
                                                           .Where(a => a.ItemCode == critriaCode.ItemCode)
                                                           .Sum(a => a.Quantity * a.ClientPrice).Value;


                                    }

                                    double? slice_percentage = 0;
                                    foreach (var c in outCome.OrderByDescending(a => a.Slice).ToList())
                                    {
                                        if (VALUE >= (double?)c.Slice)
                                        {
                                            slice_percentage = (double?)c.Value / 100;
                                            break;
                                        }
                                    }

                                    if (slice_percentage != null && slice_percentage > 0)
                                    {

                                        foreach (var item in FinalModel.SalesOrderDetails)
                                        {

                                            if (item.IsBouns == false)
                                            {

                                                foreach (var critriaCode in itemCriteria)
                                                {

                                                    if (item.ItemCode == critriaCode.ItemCode)
                                                    {

                                                        item.Discount += Math.Round((double)(slice_percentage * item.ClientPrice), 3);
                                                        IsApplied = true;

                                                    }

                                                }


                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region Outcome_FreeGood
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.FreeGood)
                                {

                                    var critriaCode = itemCriteria.FirstOrDefault();

                                    var itemOutcomeCodes = outCome.GroupBy(a => a.ItemCode).ToList().FirstOrDefault();
                                    if (itemOutcomeCodes != null)
                                    {

                                        var ORDER_VALUE = model.SalesOrderDetails
                                                            .Where(a => a.IsBouns == false)
                                                            .Where(a => a.ItemCode == critriaCode.ItemCode)
                                                            .Sum(a => a.Quantity * a.ClientPrice);


                                        var slice = outCome.Where(a => a.ItemCode == itemOutcomeCodes.Key).OrderByDescending(a => a.Slice).ToList();
                                        int FINAL_QTY = 0;

                                        foreach (var option in slice)
                                        {


                                            while (ORDER_VALUE >= (double?)option.Slice)
                                            {
                                                ORDER_VALUE -= (int)option.Slice;
                                                FINAL_QTY += (int)option.Value;
                                            }

                                        }

                                        if (FINAL_QTY > 0)
                                        {
                                            var PromotionItem = new Criteria<BOItemVw>().Add(Expression.Eq(nameof(BOItemVw.ItemCode), itemOutcomeCodes.Key)).FirstOrDefault<BOItemVw>();

                                            IList<BOItemStoreVw> Batchs = new List<BOItemStoreVw>();

                                            if (PromotionItem != null)
                                            {

                                                Batchs = new Criteria<BOItemStoreVw>()
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.ItemCode), PromotionItem.ItemCode))
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), FinalModel.StoreId))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.Available), 0))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), DateTime.Now.Date))
                                                                    .Add(OrderBy.Asc(nameof(BOItemStoreVw.ExpireDate)))
                                                                    .List<BOItemStoreVw>();

                                                if (Batchs != null && Batchs.Count > 0)
                                                {
                                                    var ALL_BATCH_COUNT = Batchs.Sum(a => a.Available);
                                                    if (ALL_BATCH_COUNT >= FINAL_QTY)
                                                    {
                                                        foreach (var b in Batchs)
                                                        {
                                                            var ORDER_QTY_ALL = model.SalesOrderDetails
                                                                          .Where(a => a.ItemStoreId == b.ItemStoreId)
                                                                          .Sum(a => a.Quantity);
                                                            var Available = b.Available - ORDER_QTY_ALL;

                                                            if (Available <= FINAL_QTY)
                                                            {
                                                                if (Available > 0)
                                                                {
                                                                    FinalModel.SalesOrderDetails.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = Available,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                                    });

                                                                    FINAL_QTY -= Available.Value;
                                                                }




                                                            }
                                                            else
                                                            {
                                                                if (FINAL_QTY > 0)
                                                                {
                                                                    FinalModel.SalesOrderDetails.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = FINAL_QTY,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,

                                                                    });
                                                                }


                                                                break;
                                                            }

                                                        }
                                                    }
                                                }

                                            }

                                            IsApplied = true;
                                        }
                                    }


                                }
                                #endregion
                                #region Outcome_FreeGoodOption
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.FreeGoodOption)
                                {
                                    //input
                                    var critriaCode = itemCriteria.FirstOrDefault();



                                    var Options = outCome.GroupBy(a => a.ItemCode).Select(a => a.Key).ToList();

                                    //check if valid 
                                    foreach (var ot in Options)
                                    {

                                        var ORDER_VALUE = model.SalesOrderDetails
                                                   .Where(a => a.IsBouns == false)
                                                   .Where(a => a.ItemCode == critriaCode.ItemCode)
                                                   .Sum(a => a.Quantity * a.ClientPrice);

                                        var slice = outCome.Where(a => a.ItemCode == ot).OrderByDescending(a => a.Slice).ToList();
                                        int FINAL_QTY = 0;

                                        foreach (var option in slice)
                                        {

                                            while (ORDER_VALUE >= (double?)option.Slice)
                                            {
                                                ORDER_VALUE -= (int)option.Slice;
                                                FINAL_QTY += (int)option.Value;
                                            }

                                        }



                                        // Get Result

                                        if (FINAL_QTY > 0)
                                        {


                                            var PromotionItem = new Criteria<BOItemVw>().Add(Expression.Eq(nameof(BOItemVw.ItemCode), ot)).FirstOrDefault<BOItemVw>();

                                            IList<BOItemStoreVw> Batchs = new List<BOItemStoreVw>();

                                            if (PromotionItem != null)
                                            {

                                                Batchs = new Criteria<BOItemStoreVw>()
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.ItemCode), PromotionItem.ItemCode))
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), FinalModel.StoreId))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.Available), 0))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), DateTime.Now.Date))
                                                                    .Add(OrderBy.Asc(nameof(BOItemStoreVw.ExpireDate)))
                                                                    .List<BOItemStoreVw>();

                                                if (Batchs != null && Batchs.Count > 0)
                                                {
                                                    var ALL_BATCH_COUNT = Batchs.Sum(a => a.Available);
                                                    if (ALL_BATCH_COUNT >= FINAL_QTY)
                                                    {

                                                        var OptionModel = new SalesOrderPromotionOptionModel();
                                                        OptionModel.RowId = FinalModel.PromotionOptions.Count + 1;
                                                        OptionModel.Selected = false;
                                                        OptionModel.PromotionId = promo.PromotionId.Value.ToString();
                                                        OptionModel.ItemName = Lan == "ar" ? PromotionItem.ItemNameAr : PromotionItem.ItemNameEn;
                                                        OptionModel.ItemCode = PromotionItem.ItemCode;
                                                        OptionModel.Quantity = FINAL_QTY;

                                                        foreach (var b in Batchs)
                                                        {
                                                            var ORDER_QTY_ALL = model.SalesOrderDetails
                                                                             .Where(a => a.ItemStoreId == b.ItemStoreId)
                                                                             .Sum(a => a.Quantity);
                                                            var Available = b.Available - ORDER_QTY_ALL;

                                                            if (Available <= FINAL_QTY)
                                                            {
                                                                if (Available > 0)
                                                                {
                                                                    OptionModel.Batchs.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = Available,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                                    });

                                                                    FINAL_QTY -= Available.Value;
                                                                }



                                                            }
                                                            else
                                                            {
                                                                if (FINAL_QTY > 0)
                                                                {
                                                                    OptionModel.Batchs.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = FINAL_QTY,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,

                                                                    });
                                                                }


                                                                break;
                                                            }

                                                        }


                                                        FinalModel.PromotionOptions.Add(OptionModel);


                                                    }
                                                }

                                            }

                                            IsApplied = true;

                                        }
                                    }

                                }
                                #endregion

                            }
                            #endregion

                            #region Criteria_MixAndMatchQuantity Done
                            if (PromotionCriteria == (int)PromotionCriteriaEnum.MixAndMatchQuantity)
                            {
                                #region Outcome_Percentage Done
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.Percentage)
                                {
                                    bool isMix_Allowed = true;
                                    int ORDER_QTY = 0;

                                    List<string> IDs = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (var group in groups)
                                        {
                                            double GroupQTY = (double)group.Slice;

                                            var GroupItems = itemCriteria.Where(a => a.GroupId == group.GroupId).ToList();
                                            var GroupItemIds = itemCriteria.Where(a => a.GroupId == group.GroupId).Select(a => a.ItemCode).ToList();
                                            var OrderItems = FinalModel.SalesOrderDetails.Where(a => string.IsNullOrEmpty(a.PromotionCode)).Where(a => a.IsBouns == false).ToList();

                                            //check that group Has Items
                                            if (GroupItemIds.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group items Found In Order
                                            var checkResult = OrderItems.Where(o => GroupItemIds.Contains(o.ItemCode)).ToList();
                                            if (checkResult.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group VALUE MATCHED
                                            var QTY = checkResult.Sum(a => a.Quantity).Value;
                                            if (QTY < GroupQTY)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }

                                            ORDER_QTY += QTY;

                                            // mark items as matched
                                            foreach (var line in checkResult)
                                            {
                                                IDs.Add(line.ItemCode);
                                            }

                                        }

                                        if (isMix_Allowed == true)
                                        {


                                            var GroupTotal = groups.Sum(a => a.Slice);
                                            var slices = outCome.OrderByDescending(a => a.Count).ToList();
                                            double? slice = 0;

                                            foreach (var option in slices)
                                            {
                                                var Total = option.Count * GroupTotal;
                                                if (Total > 0)
                                                {
                                                    if (ORDER_QTY >= (double?)Total)
                                                    {
                                                        slice = (double?)option.Value;
                                                        break;
                                                    }
                                                }

                                            }

                                            if (slice > 0)
                                            {

                                                var all = FinalModel.SalesOrderDetails.Where(o => IDs.Contains(o.ItemCode)).ToList();

                                                foreach (var item in all)
                                                {

                                                    var Item_Discount_Single = slice.Value / 100 * item.ClientPrice;

                                                    var index = FinalModel.SalesOrderDetails.IndexOf(item);

                                                    FinalModel.SalesOrderDetails[index].Discount += Math.Round((double)Item_Discount_Single, 3);

                                                    IsApplied = true;
                                                }
                                            }


                                            IsApplied = true;
                                        }
                                    }
                                }
                                #endregion

                                #region Outcome_Value DONE
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.Value)
                                {
                                    bool isMix_Allowed = true;
                                    int ORDER_QTY = 0;

                                    List<string> IDs = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (var group in groups)
                                        {
                                            double GroupQTY = (double)group.Slice;

                                            var GroupItems = itemCriteria.Where(a => a.GroupId == group.GroupId).ToList();
                                            var GroupItemIds = itemCriteria.Where(a => a.GroupId == group.GroupId).Select(a => a.ItemCode).ToList();
                                            var OrderItems = FinalModel.SalesOrderDetails.Where(a => string.IsNullOrEmpty(a.PromotionCode)).Where(a => a.IsBouns == false).ToList();

                                            //check that group Has Items
                                            if (GroupItemIds.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group items Found In Order
                                            var checkResult = OrderItems.Where(o => GroupItemIds.Contains(o.ItemCode)).ToList();
                                            if (checkResult.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group VALUE MATCHED
                                            var QTY = checkResult.Sum(a => a.Quantity).Value;
                                            if (QTY < GroupQTY)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }

                                            ORDER_QTY += QTY;

                                            // mark items as matched
                                            foreach (var line in checkResult)
                                            {
                                                IDs.Add(line.ItemCode);
                                            }

                                        }

                                        if (isMix_Allowed == true)
                                        {


                                            var GroupTotal = groups.Sum(a => a.Slice);
                                            var slices = outCome.OrderByDescending(a => a.Count).ToList();
                                            double? slice = 0;

                                            foreach (var option in slices)
                                            {
                                                var Total = option.Count * GroupTotal;
                                                if (Total > 0)
                                                {
                                                    if (ORDER_QTY >= (double?)Total)
                                                    {
                                                        slice = (double?)option.Value;
                                                        break;
                                                    }
                                                }

                                            }

                                            if (slice != null)
                                            {


                                                var all = FinalModel.SalesOrderDetails.Where(o => IDs.Contains(o.ItemCode)).ToList();

                                                var TotalPrice = all.Sum(a => a.ClientPrice);
                                                if (TotalPrice > 0)
                                                {
                                                    foreach (var item in all)
                                                    {
                                                        var wight = (item.ClientPrice / TotalPrice);
                                                        var Item_Dicount = (double?)slice.Value * wight;
                                                        var Item_Discount_Single = Item_Dicount / item.Quantity;

                                                        var index = FinalModel.SalesOrderDetails.IndexOf(item);

                                                        FinalModel.SalesOrderDetails[index].Discount += Math.Round((double)Item_Discount_Single, 3);


                                                    }
                                                }
                                            }

                                            IsApplied = true;
                                        }
                                    }
                                }
                                #endregion

                                #region Outcome_FreeGood Done
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.FreeGood)
                                {
                                    bool isMix_Allowed = true;
                                    int ORDER_QTY = 0;
                                    List<string> IDs = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (var group in groups)
                                        {
                                            double GroupQTY = (double)group.Slice;

                                            var GroupItems = itemCriteria.Where(a => a.GroupId == group.GroupId).ToList();
                                            var GroupItemIds = itemCriteria.Where(a => a.GroupId == group.GroupId).Select(a => a.ItemCode).ToList();
                                            var OrderItems = FinalModel.SalesOrderDetails.Where(a => string.IsNullOrEmpty(a.PromotionCode)).Where(a => a.IsBouns == false).ToList();

                                            //check that group Has Items
                                            if (GroupItemIds.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group items Found In Order
                                            var checkResult = OrderItems.Where(o => GroupItemIds.Contains(o.ItemCode)).ToList();
                                            if (checkResult.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group QTY MATCHED
                                            var QTY = checkResult.Sum(a => a.Quantity).Value;
                                            if (QTY < GroupQTY)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }

                                            ORDER_QTY += QTY;

                                            // mark items as matched
                                            foreach (var line in checkResult)
                                            {
                                                IDs.Add(line.ItemCode);
                                            }


                                            GroupItems = null;
                                            GroupItemIds = null;
                                            OrderItems = null;
                                            checkResult = null;

                                        }

                                        if (isMix_Allowed == true)
                                        {


                                            var GroupTotal = groups.Sum(a => a.Slice);
                                            var slices = outCome.OrderByDescending(a => a.Count).ToList();
                                            int FINAL_QTY = 0;

                                            foreach (var option in slices)
                                            {
                                                var Total = option.Count * GroupTotal;
                                                if (Total > 0)
                                                {
                                                    while (ORDER_QTY >= Total)
                                                    {
                                                        ORDER_QTY -= (int)Total;
                                                        FINAL_QTY += (int)option.Value;
                                                    }
                                                }

                                            }


                                            var itemOutcomeCode = outCome.FirstOrDefault();
                                            var PromotionItem = new Criteria<BOItemVw>().Add(Expression.Eq(nameof(BOItemVw.ItemCode), itemOutcomeCode.ItemCode)).FirstOrDefault<BOItemVw>();

                                            IList<BOItemStoreVw> Batchs = new List<BOItemStoreVw>();

                                            if (PromotionItem != null)
                                            {

                                                Batchs = new Criteria<BOItemStoreVw>()
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.ItemCode), PromotionItem.ItemCode))
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), FinalModel.StoreId))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.Available), 0))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), DateTime.Now.Date))
                                                                    .Add(OrderBy.Asc(nameof(BOItemStoreVw.ExpireDate)))
                                                                    .List<BOItemStoreVw>();

                                                if (Batchs != null && Batchs.Count > 0)
                                                {
                                                    var ALL_BATCH_COUNT = Batchs.Sum(a => a.Available);
                                                    if (ALL_BATCH_COUNT >= FINAL_QTY)
                                                    {
                                                        foreach (var b in Batchs)
                                                        {
                                                            var ORDER_QTY_ALL = model.SalesOrderDetails
                                                                           .Where(a => a.ItemStoreId == b.ItemStoreId)
                                                                           .Sum(a => a.Quantity);
                                                            var Available = b.Available - ORDER_QTY_ALL;

                                                            if (Available <= FINAL_QTY)
                                                            {
                                                                if (Available > 0)
                                                                {
                                                                    FinalModel.SalesOrderDetails.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = Available,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                                    });

                                                                    FINAL_QTY -= Available.Value;
                                                                }



                                                            }
                                                            else
                                                            {
                                                                if (FINAL_QTY > 0)
                                                                {
                                                                    FinalModel.SalesOrderDetails.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = FINAL_QTY,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,

                                                                    });
                                                                }


                                                                break;
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        model.HasError = true;
                                                        //The the avaiable quantity for batch {0} in item {1} is {2} , please try again
                                                        model.Errors.Add(String.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem.ItemCode));
                                                    }
                                                }
                                                else
                                                {
                                                    model.HasError = true;
                                                    model.Errors.Add(String.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem.ItemCode));

                                                }

                                            }

                                            IsApplied = true;


                                            Batchs = null;
                                            itemOutcomeCode = null;
                                            PromotionItem = null;


                                        }
                                    }

                                }
                                #endregion

                                #region Outcome_FreeGoodOption Done
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.FreeGoodOption)
                                {

                                    bool isMix_Allowed = true;
                                    int ORDER_QTY = 0;
                                    List<string> IDs = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (var group in groups)
                                        {
                                            double GroupQTY = (double)group.Slice;

                                            var GroupItems = itemCriteria.Where(a => a.GroupId == group.GroupId).ToList();
                                            var GroupItemIds = itemCriteria.Where(a => a.GroupId == group.GroupId).Select(a => a.ItemCode).ToList();
                                            var OrderItems = FinalModel.SalesOrderDetails.Where(a => string.IsNullOrEmpty(a.PromotionCode)).Where(a => a.IsBouns == false).ToList();

                                            //check that group Has Items
                                            if (GroupItemIds.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group items Found In Order
                                            var checkResult = OrderItems.Where(o => GroupItemIds.Contains(o.ItemCode)).ToList();
                                            if (checkResult.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group QTY MATCHED
                                            var QTY = checkResult.Sum(a => a.Quantity).Value;
                                            if (QTY < GroupQTY)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }

                                            ORDER_QTY += QTY;

                                            // mark items as matched
                                            foreach (var line in checkResult)
                                            {
                                                IDs.Add(line.ItemCode);
                                            }


                                            GroupItems = null;
                                            GroupItemIds = null;
                                            OrderItems = null;
                                            checkResult = null;


                                        }

                                        if (isMix_Allowed == true)
                                        {



                                            var GroupTotal = groups.Sum(a => a.Slice);
                                            var outCodes = outCome.GroupBy(a => a.ItemCode).Select(a => a.Key).ToList();

                                            foreach (var code in outCodes)
                                            {
                                                var Slice_QTY = ORDER_QTY;
                                                var slices = outCome.Where(a => a.ItemCode == code).OrderByDescending(a => a.Count).ToList();
                                                int FINAL_QTY = 0;

                                                foreach (var option in slices)
                                                {
                                                    var Total = option.Count * GroupTotal;
                                                    if (Total > 0)
                                                    {
                                                        while (Slice_QTY >= Total)
                                                        {
                                                            Slice_QTY -= (int)Total;
                                                            FINAL_QTY += (int)option.Value;
                                                        }
                                                    }

                                                }

                                                if (FINAL_QTY > 0)
                                                {
                                                    var PromotionItem = new Criteria<BOItemVw>().Add(Expression.Eq(nameof(BOItemVw.ItemCode), code)).FirstOrDefault<BOItemVw>();

                                                    IList<BOItemStoreVw> Batchs = new List<BOItemStoreVw>();

                                                    if (PromotionItem != null)
                                                    {

                                                        Batchs = new Criteria<BOItemStoreVw>()
                                                                            .Add(Expression.Eq(nameof(BOItemStoreVw.ItemCode), PromotionItem.ItemCode))
                                                                            .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), FinalModel.StoreId))
                                                                            .Add(Expression.Gt(nameof(BOItemStoreVw.Available), 0))
                                                                            .Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), DateTime.Now.Date))
                                                                            .Add(OrderBy.Asc(nameof(BOItemStoreVw.ExpireDate)))
                                                                            .List<BOItemStoreVw>();

                                                        if (Batchs != null && Batchs.Count > 0)
                                                        {
                                                            var ALL_BATCH_COUNT = Batchs.Sum(a => a.Available);
                                                            if (ALL_BATCH_COUNT >= FINAL_QTY)
                                                            {

                                                                var OptionModel = new SalesOrderPromotionOptionModel();
                                                                OptionModel.RowId = FinalModel.PromotionOptions.Count + 1;
                                                                OptionModel.Selected = false;
                                                                OptionModel.PromotionId = promo.PromotionId.Value.ToString();
                                                                OptionModel.ItemName = Lan == "ar" ? PromotionItem.ItemNameAr : PromotionItem.ItemNameEn;
                                                                OptionModel.ItemCode = PromotionItem.ItemCode;
                                                                OptionModel.Quantity = FINAL_QTY;

                                                                foreach (var b in Batchs)
                                                                {
                                                                    var ORDER_QTY_ALL = model.SalesOrderDetails
                                                                          .Where(a => a.ItemStoreId == b.ItemStoreId)
                                                                          .Sum(a => a.Quantity);
                                                                    var Available = b.Available - ORDER_QTY_ALL;

                                                                    if (Available <= FINAL_QTY)
                                                                    {
                                                                        if (Available > 0)
                                                                        {
                                                                            OptionModel.Batchs.Add(new SalesOrderDetailListModel()
                                                                            {
                                                                                Quantity = Available,
                                                                                Batch = b.BatchNo,
                                                                                ClientPrice = 0,
                                                                                DetailId = new Random().Next(1111111, 9999999),
                                                                                Discount = 0,
                                                                                Expiration = b.ExpireDate,
                                                                                Id = String.Empty,
                                                                                IsBouns = true,
                                                                                HasPromotion = false,
                                                                                ItemCode = b.ItemCode,
                                                                                ItemId = b.ItemId,
                                                                                ItemStoreId = b.ItemStoreId,
                                                                                parentId = null,
                                                                                SalesId = FinalModel.SalesId,
                                                                                VendorCode = b.VendorId.Value.ToString(),
                                                                                PromotionCode = promo.PromotionId.Value.ToString(),
                                                                                PublicPrice = (double?)b.PublicPrice,
                                                                                LineValue = 0,
                                                                                UnitId = PromotionItem.UnitId,
                                                                                CustomDiscount = 0,
                                                                                CashDiscount = 0,
                                                                                TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                                VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                                ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                                            });

                                                                            FINAL_QTY -= Available.Value;
                                                                        }



                                                                    }
                                                                    else
                                                                    {
                                                                        if (FINAL_QTY > 0)
                                                                        {
                                                                            OptionModel.Batchs.Add(new SalesOrderDetailListModel()
                                                                            {
                                                                                Quantity = FINAL_QTY,
                                                                                Batch = b.BatchNo,
                                                                                ClientPrice = 0,
                                                                                DetailId = new Random().Next(1111111, 9999999),
                                                                                Discount = 0,
                                                                                Expiration = b.ExpireDate,
                                                                                Id = null,
                                                                                IsBouns = true,
                                                                                HasPromotion = false,
                                                                                ItemCode = b.ItemCode,
                                                                                ItemId = b.ItemId,
                                                                                ItemStoreId = b.ItemStoreId,
                                                                                parentId = null,
                                                                                SalesId = FinalModel.SalesId,
                                                                                VendorCode = b.VendorId.Value.ToString(),
                                                                                PromotionCode = promo.PromotionId.Value.ToString(),
                                                                                PublicPrice = (double?)b.PublicPrice,
                                                                                LineValue = 0,
                                                                                CustomDiscount = 0,
                                                                                CashDiscount = 0,
                                                                                UnitId = PromotionItem.UnitId,
                                                                                TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                                VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                                ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,

                                                                            });
                                                                        }


                                                                        break;
                                                                    }

                                                                }


                                                                FinalModel.PromotionOptions.Add(OptionModel);


                                                            }
                                                        }

                                                    }



                                                    PromotionItem = null;
                                                    Batchs = null;
                                                }

                                            }

                                            IsApplied = true;

                                            outCodes = null;

                                        }
                                    }

                                }
                                #endregion
                            }
                            #endregion

                            #region Criteria_MixAndMatchValue
                            if (PromotionCriteria == (int)PromotionCriteriaEnum.MixAndMatchValue)
                            {
                                #region Outcome_Percentage Done
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.Percentage)
                                {
                                    bool isMix_Allowed = true;
                                    double ORDER_VALUE = 0;

                                    List<string> IDs = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (var group in groups)
                                        {
                                            double GroupVALUE = (double)group.Slice;

                                            var GroupItems = itemCriteria.Where(a => a.GroupId == group.GroupId).ToList();
                                            var GroupItemIds = itemCriteria.Where(a => a.GroupId == group.GroupId).Select(a => a.ItemCode).ToList();
                                            var OrderItems = FinalModel.SalesOrderDetails.Where(a => string.IsNullOrEmpty(a.PromotionCode)).Where(a => a.IsBouns == false).ToList();

                                            //check that group Has Items
                                            if (GroupItemIds.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group items Found In Order
                                            var checkResult = OrderItems.Where(o => GroupItemIds.Contains(o.ItemCode)).ToList();
                                            if (checkResult.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group VALUE MATCHED
                                            var VALUE = checkResult.Sum(a => a.Quantity * a.ClientPrice).Value;
                                            if (VALUE < GroupVALUE)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }

                                            ORDER_VALUE += VALUE;

                                            // mark items as matched
                                            foreach (var line in checkResult)
                                            {
                                                IDs.Add(line.ItemCode);
                                            }

                                            GroupItemIds = null;
                                            GroupItems = null;
                                            OrderItems = null;

                                        }

                                        if (isMix_Allowed == true)
                                        {


                                            var GroupTotal = groups.Sum(a => a.Slice);
                                            var slices = outCome.OrderByDescending(a => a.Count).ToList();
                                            double? slice = 0;

                                            foreach (var option in slices)
                                            {
                                                var Total = option.Count * GroupTotal;
                                                if (Total > 0)
                                                {
                                                    if (ORDER_VALUE >= (double?)Total)
                                                    {
                                                        slice = (double?)option.Value;
                                                        break;
                                                    }
                                                }


                                            }

                                            if (slice > 0)
                                            {

                                                var all = FinalModel.SalesOrderDetails.Where(o => IDs.Contains(o.ItemCode)).ToList();

                                                foreach (var item in all)
                                                {

                                                    var Item_Discount_Single = slice.Value / 100 * item.ClientPrice;
                                                    var index = FinalModel.SalesOrderDetails.IndexOf(item);

                                                    FinalModel.SalesOrderDetails[index].Discount += Math.Round((double)Item_Discount_Single, 3);

                                                }

                                                all = null;
                                            }

                                            slices = null;

                                            IsApplied = true;
                                        }
                                    }
                                }
                                #endregion


                                #region Outcome_Value DONE
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.Value)
                                {
                                    bool isMix_Allowed = true;
                                    double ORDER_VALUE = 0;

                                    List<string> IDs = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (var group in groups)
                                        {
                                            double GroupVALUE = (double)group.Slice;

                                            var GroupItems = itemCriteria.Where(a => a.GroupId == group.GroupId).ToList();
                                            var GroupItemIds = itemCriteria.Where(a => a.GroupId == group.GroupId).Select(a => a.ItemCode).ToList();
                                            var OrderItems = FinalModel.SalesOrderDetails.Where(a => string.IsNullOrEmpty(a.PromotionCode)).Where(a => a.IsBouns == false).ToList();

                                            //check that group Has Items
                                            if (GroupItemIds.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group items Found In Order
                                            var checkResult = OrderItems.Where(o => GroupItemIds.Contains(o.ItemCode)).ToList();
                                            if (checkResult.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group VALUE MATCHED
                                            var VALUE = checkResult.Sum(a => a.Quantity * a.ClientPrice).Value;
                                            if (VALUE < GroupVALUE)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }

                                            ORDER_VALUE += VALUE;

                                            // mark items as matched
                                            foreach (var line in checkResult)
                                            {
                                                IDs.Add(line.ItemCode);
                                            }

                                            GroupItems = null;
                                            GroupItemIds = null;
                                            OrderItems = null;
                                            checkResult = null;

                                        }

                                        if (isMix_Allowed == true)
                                        {


                                            var GroupTotal = groups.Sum(a => a.Slice);
                                            var slices = outCome.OrderByDescending(a => a.Count).ToList();
                                            double? slice = 0;

                                            foreach (var option in slices)
                                            {
                                                var Total = option.Count * GroupTotal;
                                                if (Total > 0)
                                                {
                                                    if (ORDER_VALUE >= (double?)Total)
                                                    {
                                                        slice = (double?)option.Value;
                                                        break;
                                                    }
                                                }

                                            }

                                            if (slice != null)
                                            {


                                                var all = FinalModel.SalesOrderDetails.Where(o => IDs.Contains(o.ItemCode)).ToList();

                                                var TotalPrice = all.Sum(a => a.ClientPrice);
                                                if (TotalPrice > 0)
                                                {
                                                    foreach (var item in all)
                                                    {
                                                        var wight = (item.ClientPrice / TotalPrice);
                                                        var Item_Dicount = (double?)slice.Value * wight;
                                                        var Item_Discount_Single = Item_Dicount / item.Quantity;

                                                        var index = FinalModel.SalesOrderDetails.IndexOf(item);

                                                        FinalModel.SalesOrderDetails[index].Discount += Math.Round((double)Item_Discount_Single, 3);

                                                    }
                                                }
                                                all = null;
                                            }

                                            slices = null;

                                            IsApplied = true;
                                        }
                                    }
                                }
                                #endregion

                                #region Outcome_FreeGood Done
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.FreeGood)
                                {
                                    bool isMix_Allowed = true;
                                    double ORDER_VALUE = 0;
                                    List<string> IDs = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (var group in groups)
                                        {
                                            double GroupVALUE = (double)group.Slice;

                                            var GroupItems = itemCriteria.Where(a => a.GroupId == group.GroupId).ToList();
                                            var GroupItemIds = itemCriteria.Where(a => a.GroupId == group.GroupId).Select(a => a.ItemCode).ToList();
                                            var OrderItems = FinalModel.SalesOrderDetails.Where(a => string.IsNullOrEmpty(a.PromotionCode)).Where(a => a.IsBouns == false).ToList();

                                            //check that group Has Items
                                            if (GroupItemIds.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group items Found In Order
                                            var checkResult = OrderItems.Where(o => GroupItemIds.Contains(o.ItemCode)).ToList();
                                            if (checkResult.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group QTY MATCHED
                                            var VALUE = checkResult.Sum(a => a.Quantity * a.ClientPrice).Value;
                                            if (VALUE < GroupVALUE)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }

                                            ORDER_VALUE += VALUE;

                                            // mark items as matched
                                            foreach (var line in checkResult)
                                            {
                                                IDs.Add(line.ItemCode);
                                            }

                                            checkResult = null;
                                            GroupItems = null;
                                            GroupItemIds = null;
                                            OrderItems = null;

                                        }

                                        if (isMix_Allowed == true)
                                        {



                                            var GroupTotal = groups.Sum(a => a.Slice);
                                            var slices = outCome.OrderByDescending(a => a.Count).ToList();
                                            int FINAL_QTY = 0;

                                            foreach (var option in slices)
                                            {
                                                var Total = option.Count * GroupTotal;
                                                if (Total > 0)
                                                {
                                                    while (ORDER_VALUE >= (double)Total)
                                                    {
                                                        ORDER_VALUE -= (int)Total;
                                                        FINAL_QTY += (int)option.Value;
                                                    }
                                                }

                                            }

                                            slices = null;
                                            var itemOutcomeCode = outCome.FirstOrDefault();
                                            var PromotionItem = new Criteria<BOItemVw>().Add(Expression.Eq(nameof(BOItemVw.ItemCode), itemOutcomeCode.ItemCode)).FirstOrDefault<BOItemVw>();

                                            IList<BOItemStoreVw> Batchs = new List<BOItemStoreVw>();

                                            if (PromotionItem != null)
                                            {

                                                Batchs = new Criteria<BOItemStoreVw>()
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.ItemCode), PromotionItem.ItemCode))
                                                                    .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), FinalModel.StoreId))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.Available), 0))
                                                                    .Add(OrderBy.Asc(nameof(BOItemStoreVw.ExpireDate)))
                                                                    .Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), DateTime.Now.Date))
                                                                    .List<BOItemStoreVw>();

                                                if (Batchs != null && Batchs.Count > 0)
                                                {
                                                    var ALL_BATCH_COUNT = Batchs.Sum(a => a.Available);
                                                    if (ALL_BATCH_COUNT >= FINAL_QTY)
                                                    {
                                                        foreach (var b in Batchs)
                                                        {
                                                            var ORDER_QTY_ALL = model.SalesOrderDetails
                                                                        .Where(a => a.ItemStoreId == b.ItemStoreId)
                                                                        .Sum(a => a.Quantity);
                                                            var Available = b.Available - ORDER_QTY_ALL;

                                                            if (Available <= FINAL_QTY)
                                                            {
                                                                if (Available > 0)
                                                                {
                                                                    FinalModel.SalesOrderDetails.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = Available,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                                    });

                                                                    FINAL_QTY -= Available.Value;
                                                                }



                                                            }
                                                            else
                                                            {
                                                                if (FINAL_QTY > 0)
                                                                {
                                                                    FinalModel.SalesOrderDetails.Add(new SalesOrderDetailListModel()
                                                                    {
                                                                        Quantity = FINAL_QTY,
                                                                        Batch = b.BatchNo,
                                                                        ClientPrice = 0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0,
                                                                        Expiration = b.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b.ItemCode,
                                                                        ItemId = b.ItemId,
                                                                        ItemStoreId = b.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel.SalesId,
                                                                        VendorCode = b.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b.PublicPrice,
                                                                        LineValue = 0,
                                                                        CustomDiscount = 0,
                                                                        CashDiscount = 0,
                                                                        UnitId = PromotionItem.UnitId,
                                                                        TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                        VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                        ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,

                                                                    });
                                                                }


                                                                break;
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        model.HasError = true;
                                                        //The the avaiable quantity for batch {0} in item {1} is {2} , please try again
                                                        model.Errors.Add(String.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem.ItemCode));
                                                    }
                                                }
                                                else
                                                {
                                                    model.HasError = true;
                                                    model.Errors.Add(String.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem.ItemCode));

                                                }

                                            }


                                            itemOutcomeCode = null;
                                            PromotionItem = null;
                                            Batchs = null;


                                            IsApplied = true;

                                        }
                                    }

                                }
                                #endregion
                                #region Outcome_FreeGoodOption Done
                                if (PromotionResultOutCome == (int)PromotionResultOutcomeEnum.FreeGoodOption)
                                {

                                    bool isMix_Allowed = true;
                                    double ORDER_VALUE = 0;
                                    List<string> IDs = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (var group in groups)
                                        {
                                            double GroupVALUE = (double)group.Slice;

                                            var GroupItems = itemCriteria.Where(a => a.GroupId == group.GroupId).ToList();
                                            var GroupItemIds = itemCriteria.Where(a => a.GroupId == group.GroupId).Select(a => a.ItemCode).ToList();
                                            var OrderItems = FinalModel.SalesOrderDetails.Where(a => string.IsNullOrEmpty(a.PromotionCode)).Where(a => a.IsBouns == false).ToList();

                                            //check that group Has Items
                                            if (GroupItemIds.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group items Found In Order
                                            var checkResult = OrderItems.Where(o => GroupItemIds.Contains(o.ItemCode)).ToList();
                                            if (checkResult.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }


                                            //check that group QTY MATCHED
                                            var VALUE = checkResult.Sum(a => a.Quantity * a.ClientPrice).Value;
                                            if (VALUE < GroupVALUE)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }

                                            ORDER_VALUE += VALUE;

                                            // mark items as matched
                                            foreach (var line in checkResult)
                                            {
                                                IDs.Add(line.ItemCode);
                                            }

                                            GroupItems = null;
                                            GroupItemIds = null;
                                            OrderItems = null;
                                            checkResult = null;
                                        }

                                        if (isMix_Allowed == true)
                                        {



                                            var GroupTotal = groups.Sum(a => a.Slice);
                                            var outCodes = outCome.GroupBy(a => a.ItemCode).Select(a => a.Key).ToList();

                                            foreach (var code in outCodes)
                                            {
                                                var Slice_VALUE = ORDER_VALUE;
                                                var slices = outCome.Where(a => a.ItemCode == code).OrderByDescending(a => a.Count).ToList();
                                                int FINAL_QTY = 0;

                                                foreach (var option in slices)
                                                {
                                                    var Total = option.Count * GroupTotal;
                                                    if (Total > 0)
                                                    {
                                                        while (Slice_VALUE >= (double)Total)
                                                        {
                                                            Slice_VALUE -= (int)Total;
                                                            FINAL_QTY += (int)option.Value;
                                                        }
                                                    }

                                                }

                                                if (FINAL_QTY > 0)
                                                {
                                                    var PromotionItem = new Criteria<BOItemVw>().Add(Expression.Eq(nameof(BOItemVw.ItemCode), code)).FirstOrDefault<BOItemVw>();

                                                    IList<BOItemStoreVw> Batchs = new List<BOItemStoreVw>();

                                                    if (PromotionItem != null)
                                                    {

                                                        Batchs = new Criteria<BOItemStoreVw>()
                                                                            .Add(Expression.Eq(nameof(BOItemStoreVw.ItemCode), PromotionItem.ItemCode))
                                                                            .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), FinalModel.StoreId))
                                                                            .Add(Expression.Gt(nameof(BOItemStoreVw.Available), 0))
                                                                            .Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), DateTime.Now.Date))
                                                                            .Add(OrderBy.Asc(nameof(BOItemStoreVw.ExpireDate)))
                                                                            .List<BOItemStoreVw>();

                                                        if (Batchs != null && Batchs.Count > 0)
                                                        {
                                                            var ALL_BATCH_COUNT = Batchs.Sum(a => a.Available);
                                                            if (ALL_BATCH_COUNT >= FINAL_QTY)
                                                            {

                                                                var OptionModel = new SalesOrderPromotionOptionModel();
                                                                OptionModel.RowId = FinalModel.PromotionOptions.Count + 1;
                                                                OptionModel.Selected = false;
                                                                OptionModel.PromotionId = promo.PromotionId.Value.ToString();
                                                                OptionModel.ItemName = Lan == "ar" ? PromotionItem.ItemNameAr : PromotionItem.ItemNameEn;
                                                                OptionModel.ItemCode = PromotionItem.ItemCode;
                                                                OptionModel.Quantity = FINAL_QTY;

                                                                foreach (var b in Batchs)
                                                                {
                                                                    var ORDER_QTY_ALL = model.SalesOrderDetails
                                                                       .Where(a => a.ItemStoreId == b.ItemStoreId)
                                                                       .Sum(a => a.Quantity);
                                                                    var Available = b.Available - ORDER_QTY_ALL;

                                                                    if (Available <= FINAL_QTY)
                                                                    {
                                                                        if (Available > 0)
                                                                        {
                                                                            OptionModel.Batchs.Add(new SalesOrderDetailListModel()
                                                                            {
                                                                                Quantity = Available,
                                                                                Batch = b.BatchNo,
                                                                                ClientPrice = 0,
                                                                                DetailId = new Random().Next(1111111, 9999999),
                                                                                Discount = 0,
                                                                                Expiration = b.ExpireDate,
                                                                                Id = String.Empty,
                                                                                IsBouns = true,
                                                                                HasPromotion = false,
                                                                                ItemCode = b.ItemCode,
                                                                                ItemId = b.ItemId,
                                                                                ItemStoreId = b.ItemStoreId,
                                                                                parentId = null,
                                                                                SalesId = FinalModel.SalesId,
                                                                                VendorCode = b.VendorId.Value.ToString(),
                                                                                PromotionCode = promo.PromotionId.Value.ToString(),
                                                                                PublicPrice = (double?)b.PublicPrice,
                                                                                LineValue = 0,
                                                                                UnitId = PromotionItem.UnitId,
                                                                                CustomDiscount = 0,
                                                                                CashDiscount = 0,
                                                                                TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                                VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                                ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                                            });

                                                                            FINAL_QTY -= Available.Value;
                                                                        }



                                                                    }
                                                                    else
                                                                    {
                                                                        if (FINAL_QTY > 0)
                                                                        {
                                                                            OptionModel.Batchs.Add(new SalesOrderDetailListModel()
                                                                            {
                                                                                Quantity = FINAL_QTY,
                                                                                Batch = b.BatchNo,
                                                                                ClientPrice = 0,
                                                                                DetailId = new Random().Next(1111111, 9999999),
                                                                                Discount = 0,
                                                                                Expiration = b.ExpireDate,
                                                                                Id = null,
                                                                                IsBouns = true,
                                                                                HasPromotion = false,
                                                                                ItemCode = b.ItemCode,
                                                                                ItemId = b.ItemId,
                                                                                ItemStoreId = b.ItemStoreId,
                                                                                parentId = null,
                                                                                SalesId = FinalModel.SalesId,
                                                                                VendorCode = b.VendorId.Value.ToString(),
                                                                                PromotionCode = promo.PromotionId.Value.ToString(),
                                                                                PublicPrice = (double?)b.PublicPrice,
                                                                                LineValue = 0,
                                                                                CustomDiscount = 0,
                                                                                CashDiscount = 0,
                                                                                UnitId = PromotionItem.UnitId,
                                                                                TaxValue = EnablePromotionTax == true ? Math.Round(((double)PromotionItem.ClientPrice * 0.14), 3) : 0,
                                                                                VendorName = Lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                                                ItemName = Lan == "ar" ? b.ItemNameAr : b.ItemNameEn,

                                                                            });
                                                                        }


                                                                        break;
                                                                    }

                                                                }


                                                                FinalModel.PromotionOptions.Add(OptionModel);


                                                            }
                                                        }

                                                    }


                                                    PromotionItem = null;
                                                    Batchs = null;
                                                }
                                                slices = null;

                                            }


                                            outCodes = null;

                                            IsApplied = true;

                                        }
                                    }

                                }
                                #endregion
                            }
                            #endregion


                        }





                        promo = null;
                        groups = null;
                        outCome = null;
                        itemCriteria = null;
                        conditionType = null;


                        //update Done List

                        if (IsApplied == true)
                        {
                            if (!string.IsNullOrEmpty(p.VendorCode))
                            {
                                var res = promos.Where(a => a.VendorCode == p.VendorCode).ToList();
                                foreach (var item in res)
                                {
                                    item.IsDone = true;
                                }
                            }

                        }



                    }
                }


                // calculate promotion for item



                #endregion

                promos = null;


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
        public async Task<SalesOrderModelMobile> CaluclucateCashDiscount(SalesOrderModelMobile model)
        {
            //model.SalesOrderDetails = model.SalesOrderDetails.Where(a => a.IsBouns == false).ToList();
            //var FinalModel = model;


            try
            {
                model.CashDiscountTotal = 0;


                var client = new BOClient(model.ClientId.Value);

                IList<BOPromotion> cashPromo = new List<BOPromotion>();

                // get all cashdiscount Promotion

                cashPromo = new Criteria<BOPromotion>()
                                              .Add(Expression.Eq(nameof(BOPromotion.PromotionCategoryId), 3))
                                              .Add(Expression.Lte(nameof(BOPromotion.ValidFrom), model.SalesDate))
                                              .Add(Expression.Gte(nameof(BOPromotion.ValidTo), model.SalesDate))
                                              .Add(Expression.Eq(nameof(BOPromotion.IsActive), true))
                                              .Add(Expression.Eq(nameof(BOPromotion.IsApproved), true))
                                              .Add(OrderBy.Desc(nameof(BOPromotion.PromotionCategoryId)))
                                              .Add(OrderBy.Asc(nameof(BOPromotion.Priority)))
                                              .List<BOPromotion>();

                List<string> vs = new List<string>();
                // loop on every promtion
                foreach (var promo in cashPromo)
                {
                    // validate isallowedclient
                    // validate is allowed salesman

                    var IsAllowedClient = await PromotionHelper.IsAllowedClient(model.ClientCode, promo.PromotionId.Value);
                    var IsAllowedSalesMan = await PromotionHelper.IsAllowedSalesMan(model.RepresentativeId, promo.PromotionId.Value);

                    if (IsAllowedClient == true && IsAllowedSalesMan == true)
                    {


                        // get all PromotionItems

                        double? OrderTotal = 0;
                        double? CashDiscount = 0;
                        foreach (var item in model.SalesOrderDetails)
                        {
                            var exist = vs.Where(a => a.Equals(item.ItemCode)).FirstOrDefault();
                            if (exist == null)
                            {

                                // if item in group
                                var IsItemAllowed = await PromotionHelper.IsAllowedCashItem(item.ItemCode, promo.PromotionId.Value);

                                // add to total
                                if (IsItemAllowed == true)
                                {
                                    var ItemTotal = model.SalesOrderDetails.Where(a => a.ItemCode == item.ItemCode).Sum(a => a.Quantity * a.ClientPrice);
                                    OrderTotal += ItemTotal;
                                    vs.Add(item.ItemCode);
                                }



                            }


                        }
                        // get outcome

                        var outCome = new Criteria<BOPromotionOutcome>()
                                    .Add(Expression.Eq(nameof(BOPromotionOutcome.PromotionId), promo.PromotionId))
                                    .List<BOPromotionOutcome>();


                        foreach (var ot in outCome.OrderByDescending(a => a.Slice).ToList())
                        {
                            if (OrderTotal >= (double?)ot.Slice)
                            {
                                CashDiscount = OrderTotal * ((double?)ot.Value / 100);
                                break;
                            }
                        }


                        model.CashDiscountTotal += Math.Round(CashDiscount.Value > 0 ? CashDiscount.Value : 0, 3);


                        outCome = null;

                    }
                }


                cashPromo = null;

            }
            catch
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_PROMOTION);
                return model;
            }


            return model;
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
                model = await CaluclucateCashDiscount(model);
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

                var ItemStr = model.SalesOrderDetails.Select(x => x.ItemId).ToList();

                var ClientHistoyQouta = new Criteria<BOItemQuotaByClientVw>()
                                    .Add(Expression.Eq(nameof(BOItemQuotaByClientVw.ClientId), model.ClientId))

                                    .Add(Expression.Gte(nameof(BOItemQuotaByClientVw.SalesDate), model.SalesTime.Value.FirstDayOfMonth()))
                                    .Add(Expression.In(nameof(BOItemQuotaByClientVw.ItemId), string.Join(',', ItemStr)))
                                    .List<BOItemQuotaByClientVw>();

                var ItemQouta = new Criteria<BOItemQuota>()
                    .Add(Expression.In(nameof(BOItemQuota.ItemId), string.Join(',', ItemStr)))
                    .List<BOItemQuota>();

                var ExceptionQouta = new Criteria<BOClientQuota>()
                  .Add(Expression.In(nameof(BOClientQuota.ItemId), string.Join(',', ItemStr)))
                  .Add(Expression.Eq(nameof(BOClientQuota.ClientId), model.ClientId))
                  .List<BOClientQuota>();

                var OrderItems = model.SalesOrderDetails.Where(a => a.IsBouns == false).ToList();

                if (ExceptionQouta == null) ExceptionQouta = new List<BOClientQuota>();
                if (ClientHistoyQouta == null) ClientHistoyQouta = new List<BOItemQuotaByClientVw>();
                if (ItemQouta == null) ItemQouta = new List<BOItemQuota>();

                var GroupedOrder = OrderItems.Where(a => a.IsBouns == false)
                    .GroupBy(a => new { a.ItemId, a.ItemCode })
                    .Select(a => new { OrderQty = a.Sum(a => a.Quantity), ItemId = a.Key.ItemId, ItemCode = a.Key.ItemCode })
                    .ToList();

                foreach (var item in GroupedOrder)
                {
                    var TotalQtyHistory = ClientHistoyQouta.Where(a => a.ItemId == item.ItemId).Sum(a => a.Quantity);

                    var existInItemQuota = ItemQouta.Where(a => a.ItemId == item.ItemId).FirstOrDefault();
                    if (existInItemQuota != null)
                    {
                        var existInExceptionQuota = ExceptionQouta.Where(a => a.ItemId == item.ItemId).FirstOrDefault();
                        if (existInExceptionQuota != null)
                        {
                            if (existInExceptionQuota.Quantity < item.OrderQty + TotalQtyHistory)
                            {
                                model.Errors.Add(String.Format(PromotionError.INVALID_QOUTA, item.ItemCode));

                            }
                        }
                        else
                        {
                            if (existInItemQuota.Quantity < item.OrderQty + TotalQtyHistory)
                            {
                                model.Errors.Add(String.Format(PromotionError.INVALID_QOUTA, item.ItemCode));

                            }
                        }
                    }
                }

                ClientHistoyQouta = null;
                ItemQouta = null;
                ExceptionQouta = null;
                GroupedOrder = null;

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



                // Validate Item Is Active
                var Items = new Criteria<BOItem>()
                    .Add(Expression.Eq(nameof(BOItem.IsActive), false))
                    .Add(Expression.In(nameof(BOItem.ItemId), string.Join(',', ItemStr)))
                    .List<BOItem>();

                if (Items != null)
                {
                    foreach (var item in Items)
                    {
                        model.Errors.Add(String.Format(PromotionError.INVALID_ITEM, item.ItemCode));

                    }
                }

                if (model.Errors.Count > 0)
                {
                    model.HasError = true;
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

                // validate Stock Availability

                List<SalesOrderDetailListModel> newDetails = new List<SalesOrderDetailListModel>();
                foreach (var item in model.SalesOrderDetails.ToList())
                {
                    if (item.IsBouns == false)
                    {
                        var batch = Batchs.Where(a => a.ItemStoreId > 0).Where(a => a.ItemStoreId == item.ItemStoreId).FirstOrDefault();
                        if (batch != null)
                        {
                            if (batch.Available < item.Quantity)
                            {
                                // model.Errors.Add(String.Format(INVALID_BATCH_QTY, batch.ItemCode));
                                var AllBatchs = new Criteria<BOItemStoreVw>()
                                    .Add(Expression.Eq(nameof(BOItemStoreVw.ItemId), item.ItemId))
                                    .Add(Expression.Eq(nameof(BOItemStoreVw.StoreId), model.StoreId))
                                    .Add(Expression.Eq(nameof(BOItemStoreVw.IsActive), true))

                                    .Add(Expression.Gt(nameof(BOItemStoreVw.ExpireDate), DateTime.Now.Date))

                                    .List<BOItemStoreVw>()
                                    .OrderBy(a => a.ExpireDate)
                                    .ToList();

                                var sumOfBatchs = AllBatchs.Sum(a => a.Available);
                                if (sumOfBatchs < item.Quantity)
                                {
                                    model.Errors.Add(String.Format(PromotionError.INVALID_BATCH_QTY, batch.ItemCode));
                                }
                                else
                                {
                                    //remove item


                                    // create New Lines

                                    foreach (var b in AllBatchs)
                                    {
                                        if (b.Available > 0)
                                        {
                                            if (b.Available <= item.Quantity)
                                            {

                                                var existInOrder = newDetails.Where(a => a.ItemStoreId == b.ItemStoreId).FirstOrDefault();

                                                if (existInOrder != null)
                                                {
                                                    int index = newDetails.IndexOf(existInOrder);
                                                    newDetails[index].Quantity += b.Available;
                                                    newDetails[index].LineValue += (double)Math.Round((decimal)b.Available * (decimal)b.ClientPrice.Value, 3);

                                                }
                                                else
                                                {
                                                    newDetails.Add(new SalesOrderDetailListModel()
                                                    {
                                                        Quantity = b.Available,
                                                        Batch = b.BatchNo,
                                                        ClientPrice = (double?)b.ClientPrice,
                                                        DetailId = new Random().Next(1111111, 9999999),
                                                        Discount = 0,
                                                        Expiration = b.ExpireDate,
                                                        Id = String.Empty,
                                                        IsBouns = false,
                                                        HasPromotion = b.HasPromotion,
                                                        ItemCode = b.ItemCode,
                                                        ItemId = b.ItemId,
                                                        ItemStoreId = b.ItemStoreId,
                                                        parentId = null,
                                                        SalesId = model.SalesId,
                                                        VendorCode = b.VendorId.Value.ToString(),
                                                        PromotionCode = "",
                                                        PublicPrice = (double?)b.PublicPrice,
                                                        LineValue = (double)Math.Round((decimal)b.Available * (decimal)b.ClientPrice.Value, 3),
                                                        UnitId = b.UnitId,
                                                        CustomDiscount = 0,
                                                        CashDiscount = 0,
                                                        TaxValue = b.IsTaxable == true ? Math.Round(((double)b.ClientPrice * 0.14), 3) : 0,
                                                        VendorName = lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                        ItemName = lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                    });

                                                }

                                                item.Quantity -= b.Available.Value;


                                            }
                                            else
                                            {
                                                var existInOrder = newDetails.Where(a => a.ItemStoreId == b.ItemStoreId).FirstOrDefault();

                                                if (existInOrder != null)
                                                {
                                                    int index = newDetails.IndexOf(existInOrder);
                                                    newDetails[index].Quantity += item.Quantity;
                                                    newDetails[index].LineValue += (double)Math.Round((decimal)item.Quantity * (decimal)b.ClientPrice.Value, 3);

                                                }
                                                else
                                                {

                                                    newDetails.Add(new SalesOrderDetailListModel()
                                                    {
                                                        Quantity = item.Quantity,
                                                        Batch = b.BatchNo,
                                                        ClientPrice = (double?)b.ClientPrice,
                                                        DetailId = new Random().Next(1111111, 9999999),
                                                        Discount = 0,
                                                        Expiration = b.ExpireDate,
                                                        Id = String.Empty,
                                                        IsBouns = false,
                                                        HasPromotion = b.HasPromotion,
                                                        ItemCode = b.ItemCode,
                                                        ItemId = b.ItemId,
                                                        ItemStoreId = b.ItemStoreId,
                                                        parentId = null,
                                                        SalesId = model.SalesId,
                                                        VendorCode = b.VendorId.Value.ToString(),
                                                        PromotionCode = "",
                                                        PublicPrice = (double?)b.PublicPrice,
                                                        LineValue = (double)Math.Round((decimal)item.Quantity * (decimal)b.ClientPrice.Value, 3),
                                                        UnitId = b.UnitId,
                                                        CustomDiscount = 0,
                                                        CashDiscount = 0,
                                                        TaxValue = b.IsTaxable == true ? Math.Round(((double)b.ClientPrice * 0.14), 3) : 0,
                                                        VendorName = lan == "ar" ? b.VendorNameAr : b.VendorNameEn,
                                                        ItemName = lan == "ar" ? b.ItemNameAr : b.ItemNameEn,



                                                    });
                                                }

                                                item.Quantity = 0;
                                                break;
                                            }
                                        }


                                    }



                                }
                            }
                        }
                    }
                }

                model.SalesOrderDetails = model.SalesOrderDetails.Where(a => a.Quantity > 0).ToList();
                model.SalesOrderDetails.AddRange(newDetails);
                model.SalesOrderDetails = model.SalesOrderDetails.OrderByDescending(a => a.ItemId).ToList();
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
