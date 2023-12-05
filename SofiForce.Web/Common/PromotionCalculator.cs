using Models;
using SofiForce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using SofiForce.Promotion.Helpers;
using SofiForce.Web.Common.PromotionModels;
using System.Threading.Tasks;
using SofiForce.Web.Common;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Reflection;

namespace SofiForce.Promotion
{

    public interface IPromotionCalculator
    {
        public Task<SalesOrderModelWeb> CaluclucateOrder(SalesOrderModelWeb model, string Lan);
        public Task<SalesOrderModelWeb> CaluclucateOrder1(SalesOrderModelWeb model, string Lan);
        public SalesOrderModelWeb CaluclucateTotals(SalesOrderModelWeb model);
        public Task<SalesOrderModelWeb> CaluclucateTotals1(SalesOrderModelWeb model);
        Task<SalesOrderModelWeb> CaluclucateCashDiscount(SalesOrderModelWeb model);
        public Task<SalesOrderModelWeb> ValidateOrder(SalesOrderModelWeb model, string lan);
        public Task<SalesOrderModelWeb> ValidateOrder1(SalesOrderModelWeb model, string lan);

    }
    public class PromotionCalculator : IPromotionCalculator
    {

        public PromotionCalculator()
        {

        }

        public static string fmt = "yyyy-MM-dd";
        public static Func<object, string> dateformatter = (x => ((DateTime)x).ToString(fmt));

        public async Task<SalesOrderModelWeb> CaluclucateOrder(SalesOrderModelWeb model, string Lan)
        {
            model.LineBouns.Clear();
            model.SalesOrderDetails = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
            SalesOrderModelWeb FinalModel2 = model;
            foreach (SalesOrderDetailListModel item2 in FinalModel2.SalesOrderDetails)
            {
                item2.Discount = 0.0;
                item2.CashDiscount = 0.0;
                item2.PromotionCode = "";
            }
            try
            {
                List<int?> ItemStr = model.SalesOrderDetails.Select((SalesOrderDetailListModel x) => x.ItemId).ToList();
                IList<BOItem> Items = new Criteria<BOItem>().Add(Expression.In("ItemId", string.Join(',', ItemStr))).List<BOItem>();
                foreach (BOItem item3 in Items)
                {
                    foreach (SalesOrderDetailListModel ordertem in model.SalesOrderDetails)
                    {
                        if (item3.ItemCode == ordertem.ItemCode)
                        {
                            if (!ordertem.ItemStoreId.HasValue)
                            {
                                ordertem.ItemStoreId = 0;
                            }
                            ordertem.ClientPrice = (double?)item3.ClientPrice;
                            ordertem.PublicPrice = (double?)item3.PublicPrice;
                            ordertem.LineValue = Math.Round((double)ordertem.Quantity.Value * ordertem.ClientPrice.Value, 3);
                            if (item3.IsTaxable == true)
                            {
                                ordertem.TaxValue = Math.Round(0.14 * ordertem.ClientPrice.Value, 3);
                            }
                        }
                    }
                }
                bool EnablePromotionTax = false;
                BOAppSetting boTaxSetting = new Criteria<BOAppSetting>().Add(Expression.Eq("SettingCode", "ORDER.PROMOTION.TAX")).FirstOrDefault<BOAppSetting>();
                if (boTaxSetting != null)
                {
                    bool.TryParse(boTaxSetting.SettingValue, out EnablePromotionTax);
                }
                List<OrderPromotionFinal> promos = await PromotionHelper.getOrderPromotions(model);
                if (promos != null)
                {
                    foreach (OrderPromotionFinal p in promos)
                    {
                        bool IsApplied = false;
                        if (p.IsDone)
                        {
                            continue;
                        }
                        BOPromotion promo = new BOPromotion(p.PromotionId);
                        if (promo.Repeats == 0)
                        {
                            promo.Repeats = int.MaxValue;
                        }
                        IList<BOPromotionMixGroup> groups = new Criteria<BOPromotionMixGroup>().Add(Expression.Eq("PromotionId", promo.PromotionId)).List<BOPromotionMixGroup>();
                        IList<BOPromotionOutcome> outCome = new Criteria<BOPromotionOutcome>().Add(Expression.Eq("PromotionId", promo.PromotionId)).List<BOPromotionOutcome>();
                        IList<BOPromotionItem> itemCriteria = new Criteria<BOPromotionItem>().Add(Expression.Eq("PromotionId", promo.PromotionId)).List<BOPromotionItem>();
                        BOPromotionType conditionType = new Criteria<BOPromotionType>().Add(Expression.Eq("PromotionTypeId", promo.PromotionTypeId)).FirstOrDefault<BOPromotionType>();
                        if (conditionType != null)
                        {
                            int PromotionCriteria = conditionType.PromotionInputId.Value;
                            int PromotionResultOutCome = conditionType.PromotionOutputId.Value;
                            if (PromotionCriteria == 1)
                            {
                                if (PromotionResultOutCome == 2)
                                {
                                    foreach (BOPromotionItem critriaCode8 in itemCriteria)
                                    {
                                        int? QTY = (from a in FinalModel2.SalesOrderDetails
                                                    where a.IsBouns == false
                                                    where a.ItemCode == critriaCode8.ItemCode
                                                    select a).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                        List<BOPromotionOutcome> slices2 = outCome.OrderByDescending((BOPromotionOutcome a) => a.Slice).ToList();
                                        foreach (BOPromotionOutcome s in slices2)
                                        {
                                            if (!((double?)QTY >= (double?)s.Slice))
                                            {
                                                continue;
                                            }
                                            double Disount = Math.Round((double)s.Value.Value / (double)s.Slice.Value, 3);
                                            foreach (SalesOrderDetailListModel item4 in FinalModel2.SalesOrderDetails)
                                            {
                                                if (item4.IsBouns == false && item4.ItemCode == critriaCode8.ItemCode)
                                                {
                                                    item4.Discount += Disount;
                                                    FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                    {
                                                        ItemId = item4.ItemId,
                                                        LineId = 0L,
                                                        SalesId = model.SalesId,
                                                        ItemStoreId = item4.ItemStoreId,
                                                        PromotionId = promo.PromotionId,
                                                        Outcome = (double?)item4.Quantity * Math.Round(Disount, 3),
                                                        OutcomeType = 1
                                                    });
                                                    item4.PromotionCode = promo.PromotionId.ToString();
                                                    IsApplied = true;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 1)
                                {
                                    foreach (BOPromotionItem critriaCode7 in itemCriteria)
                                    {
                                        int? QTY2 = (from a in FinalModel2.SalesOrderDetails
                                                     where a.IsBouns == false
                                                     where a.ItemCode == critriaCode7.ItemCode
                                                     select a).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                        double? slice_percentage = 0.0;
                                        foreach (BOPromotionOutcome c in outCome.OrderByDescending((BOPromotionOutcome a) => a.Slice).ToList())
                                        {
                                            if ((double?)QTY2 >= (double?)c.Slice)
                                            {
                                                slice_percentage = (double?)c.Value / 100.0;
                                                break;
                                            }
                                        }
                                        if (!slice_percentage.HasValue || !(slice_percentage > 0.0))
                                        {
                                            continue;
                                        }
                                        foreach (SalesOrderDetailListModel item5 in FinalModel2.SalesOrderDetails)
                                        {
                                            if (item5.IsBouns == false && item5.ItemCode == critriaCode7.ItemCode)
                                            {
                                                item5.Discount += Math.Round((slice_percentage * item5.ClientPrice).Value, 3);
                                                FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                {
                                                    ItemId = item5.ItemId,
                                                    LineId = 0L,
                                                    ItemStoreId = item5.ItemStoreId,
                                                    SalesId = model.SalesId,
                                                    PromotionId = promo.PromotionId,
                                                    Outcome = (double?)item5.Quantity * Math.Round((slice_percentage * item5.ClientPrice).Value, 3),
                                                    OutcomeType = 2
                                                });
                                                item5.PromotionCode = promo.PromotionId.ToString();
                                                IsApplied = true;
                                            }
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 3)
                                {
                                    BOPromotionItem critriaCode6 = itemCriteria.FirstOrDefault();
                                    IGrouping<string, BOPromotionOutcome> itemOutcomeCodes2 = (from a in outCome
                                                                                               group a by a.ItemCode).ToList().FirstOrDefault();
                                    if (itemOutcomeCodes2 != null)
                                    {
                                        int? ORDER_QTY = (from a in model.SalesOrderDetails
                                                          where a.IsBouns == false
                                                          where a.ItemCode == critriaCode6.ItemCode
                                                          select a).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                        List<BOPromotionOutcome> slice = (from a in outCome
                                                                          where a.ItemCode == itemOutcomeCodes2.Key
                                                                          orderby a.Slice descending
                                                                          select a).ToList();
                                        int FINAL_QTY2 = 0;
                                        foreach (BOPromotionOutcome option2 in slice)
                                        {
                                            while ((decimal?)ORDER_QTY >= option2.Slice)
                                            {
                                                ORDER_QTY -= (int)option2.Slice.Value;
                                                FINAL_QTY2 += (int)option2.Value.Value;
                                            }
                                        }
                                        if (FINAL_QTY2 > 0)
                                        {
                                            BOItemVw PromotionItem3 = new Criteria<BOItemVw>().Add(Expression.Eq("ItemCode", itemOutcomeCodes2.Key)).FirstOrDefault<BOItemVw>();
                                            new List<BOItemStoreVw>();
                                            if (PromotionItem3 != null)
                                            {
                                                IList<BOItemStoreVw> Batchs3 = new Criteria<BOItemStoreVw>().Add(Expression.Eq("ItemCode", PromotionItem3.ItemCode)).Add(Expression.Eq("StoreId", FinalModel2.StoreId)).Add(Expression.Gt("Available", 0))
                                                    .Add(Expression.Gt("ExpireDate", DateTime.Now.Date))
                                                    .Add(OrderBy.Asc("ExpireDate"))
                                                    .List<BOItemStoreVw>();
                                                if (Batchs3 != null && Batchs3.Count > 0)
                                                {
                                                    int? ALL_BATCH_COUNT2 = Batchs3.Sum((BOItemStoreVw a) => a.Available);
                                                    if (ALL_BATCH_COUNT2 >= FINAL_QTY2)
                                                    {
                                                        foreach (BOItemStoreVw b8 in Batchs3)
                                                        {
                                                            int? ORDER_QTY_ALL3 = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b8.ItemStoreId).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                                            int? Available3 = b8.Available - ORDER_QTY_ALL3;
                                                            if (Available3 <= FINAL_QTY2)
                                                            {
                                                                if (Available3 > 0)
                                                                {
                                                                    FinalModel2.SalesOrderDetails.Add(new SalesOrderDetailListModel
                                                                    {
                                                                        Quantity = Available3,
                                                                        Batch = b8.BatchNo,
                                                                        ClientPrice = 0.0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0.0,
                                                                        Expiration = b8.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b8.ItemCode,
                                                                        ItemId = b8.ItemId,
                                                                        ItemStoreId = b8.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel2.SalesId,
                                                                        VendorCode = b8.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b8.PublicPrice,
                                                                        LineValue = 0.0,
                                                                        UnitId = PromotionItem3.UnitId,
                                                                        CustomDiscount = 0.0,
                                                                        CashDiscount = 0.0,
                                                                        TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem3.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                        VendorName = ((Lan == "ar") ? b8.VendorNameAr : b8.VendorNameEn),
                                                                        ItemName = ((Lan == "ar") ? b8.ItemNameAr : b8.ItemNameEn)
                                                                    });
                                                                    FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                                    {
                                                                        ItemId = b8.ItemId,
                                                                        ItemStoreId = b8.ItemStoreId,
                                                                        SalesId = model.SalesId,
                                                                        LineId = 0L,
                                                                        PromotionId = promo.PromotionId,
                                                                        Outcome = Available3,
                                                                        OutcomeType = 1
                                                                    });
                                                                    FINAL_QTY2 -= Available3.Value;
                                                                }
                                                                continue;
                                                            }
                                                            if (FINAL_QTY2 > 0)
                                                            {
                                                                FinalModel2.SalesOrderDetails.Add(new SalesOrderDetailListModel
                                                                {
                                                                    Quantity = FINAL_QTY2,
                                                                    Batch = b8.BatchNo,
                                                                    ClientPrice = 0.0,
                                                                    DetailId = new Random().Next(1111111, 9999999),
                                                                    Discount = 0.0,
                                                                    Expiration = b8.ExpireDate,
                                                                    Id = null,
                                                                    IsBouns = true,
                                                                    HasPromotion = false,
                                                                    ItemCode = b8.ItemCode,
                                                                    ItemId = b8.ItemId,
                                                                    ItemStoreId = b8.ItemStoreId,
                                                                    parentId = null,
                                                                    SalesId = FinalModel2.SalesId,
                                                                    VendorCode = b8.VendorId.Value.ToString(),
                                                                    PromotionCode = promo.PromotionId.Value.ToString(),
                                                                    PublicPrice = (double?)b8.PublicPrice,
                                                                    LineValue = 0.0,
                                                                    CustomDiscount = 0.0,
                                                                    CashDiscount = 0.0,
                                                                    UnitId = PromotionItem3.UnitId,
                                                                    TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem3.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                    VendorName = ((Lan == "ar") ? b8.VendorNameAr : b8.VendorNameEn),
                                                                    ItemName = ((Lan == "ar") ? b8.ItemNameAr : b8.ItemNameEn)
                                                                });
                                                                FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                                {
                                                                    ItemId = b8.ItemId,
                                                                    ItemStoreId = b8.ItemStoreId,
                                                                    SalesId = model.SalesId,
                                                                    LineId = 0L,
                                                                    PromotionId = promo.PromotionId,
                                                                    Outcome = FINAL_QTY2,
                                                                    OutcomeType = 1
                                                                });
                                                            }
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        model.HasError = true;
                                                        model.Errors.Add(string.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem3.ItemCode, FINAL_QTY2, ALL_BATCH_COUNT2));
                                                    }
                                                }
                                                else
                                                {
                                                    model.HasError = true;
                                                    model.Errors.Add(string.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem3.ItemCode, FINAL_QTY2, 0));
                                                }
                                            }
                                            IsApplied = true;
                                        }
                                        critriaCode6 = null;
                                        itemOutcomeCodes2 = null;
                                    }
                                }
                                if (PromotionResultOutCome == 4)
                                {
                                    BOPromotionItem critriaCode5 = itemCriteria.FirstOrDefault();
                                    List<string> Options = (from a in outCome
                                                            group a by a.ItemCode into a
                                                            select a.Key).ToList();
                                    foreach (string ot2 in Options)
                                    {
                                        int? ORDER_QTY2 = (from a in model.SalesOrderDetails
                                                           where a.IsBouns == false
                                                           where a.ItemCode == critriaCode5.ItemCode
                                                           select a).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                        List<BOPromotionOutcome> slice2 = (from a in outCome
                                                                           where a.ItemCode == ot2
                                                                           orderby a.Slice descending
                                                                           select a).ToList();
                                        int FINAL_QTY4 = 0;
                                        foreach (BOPromotionOutcome option4 in slice2)
                                        {
                                            while ((decimal?)ORDER_QTY2 >= option4.Slice)
                                            {
                                                ORDER_QTY2 -= (int)option4.Slice.Value;
                                                FINAL_QTY4 += (int)option4.Value.Value;
                                            }
                                        }
                                        if (FINAL_QTY4 <= 0)
                                        {
                                            continue;
                                        }
                                        BOItemVw PromotionItem4 = new Criteria<BOItemVw>().Add(Expression.Eq("ItemCode", ot2)).FirstOrDefault<BOItemVw>();
                                        new List<BOItemStoreVw>();
                                        if (PromotionItem4 != null)
                                        {
                                            IList<BOItemStoreVw> Batchs4 = new Criteria<BOItemStoreVw>().Add(Expression.Eq("ItemCode", PromotionItem4.ItemCode)).Add(Expression.Eq("StoreId", FinalModel2.StoreId)).Add(Expression.Gt("Available", 0))
                                                .Add(Expression.Gt("ExpireDate", DateTime.Now.Date))
                                                .Add(OrderBy.Asc("ExpireDate"))
                                                .List<BOItemStoreVw>();
                                            if (Batchs4 != null && Batchs4.Count > 0 && Batchs4.Sum((BOItemStoreVw a) => a.Available) >= FINAL_QTY4)
                                            {
                                                SalesOrderPromotionOptionModel OptionModel2 = new SalesOrderPromotionOptionModel
                                                {
                                                    RowId = FinalModel2.PromotionOptions.Count + 1,
                                                    Selected = false,
                                                    PromotionId = promo.PromotionId.Value.ToString(),
                                                    ItemName = ((Lan == "ar") ? PromotionItem4.ItemNameAr : PromotionItem4.ItemNameEn),
                                                    ItemCode = PromotionItem4.ItemCode,
                                                    Quantity = FINAL_QTY4
                                                };
                                                foreach (BOItemStoreVw b7 in Batchs4)
                                                {
                                                    int? ORDER_QTY_ALL4 = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b7.ItemStoreId).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                                    int? Available4 = b7.Available - ORDER_QTY_ALL4;
                                                    if (Available4 <= FINAL_QTY4)
                                                    {
                                                        if (Available4 > 0)
                                                        {
                                                            OptionModel2.Batchs.Add(new SalesOrderDetailListModel
                                                            {
                                                                Quantity = Available4,
                                                                Batch = b7.BatchNo,
                                                                ClientPrice = 0.0,
                                                                DetailId = new Random().Next(1111111, 9999999),
                                                                Discount = 0.0,
                                                                Expiration = b7.ExpireDate,
                                                                Id = null,
                                                                IsBouns = true,
                                                                HasPromotion = false,
                                                                ItemCode = b7.ItemCode,
                                                                ItemId = b7.ItemId,
                                                                ItemStoreId = b7.ItemStoreId,
                                                                parentId = null,
                                                                SalesId = FinalModel2.SalesId,
                                                                VendorCode = b7.VendorId.Value.ToString(),
                                                                PromotionCode = promo.PromotionId.Value.ToString(),
                                                                PublicPrice = (double?)b7.PublicPrice,
                                                                LineValue = 0.0,
                                                                UnitId = PromotionItem4.UnitId,
                                                                CustomDiscount = 0.0,
                                                                CashDiscount = 0.0,
                                                                TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem4.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                VendorName = ((Lan == "ar") ? b7.VendorNameAr : b7.VendorNameEn),
                                                                ItemName = ((Lan == "ar") ? b7.ItemNameAr : b7.ItemNameEn)
                                                            });
                                                            FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                            {
                                                                ItemId = b7.ItemId,
                                                                ItemStoreId = b7.ItemStoreId,
                                                                SalesId = model.SalesId,
                                                                LineId = 0L,
                                                                PromotionId = promo.PromotionId,
                                                                Outcome = Available4,
                                                                OutcomeType = 1
                                                            });
                                                            FINAL_QTY4 -= Available4.Value;
                                                        }
                                                        continue;
                                                    }
                                                    if (FINAL_QTY4 > 0)
                                                    {
                                                        OptionModel2.Batchs.Add(new SalesOrderDetailListModel
                                                        {
                                                            Quantity = FINAL_QTY4,
                                                            Batch = b7.BatchNo,
                                                            ClientPrice = 0.0,
                                                            DetailId = new Random().Next(1111111, 9999999),
                                                            Discount = 0.0,
                                                            Expiration = b7.ExpireDate,
                                                            Id = null,
                                                            IsBouns = true,
                                                            HasPromotion = false,
                                                            ItemCode = b7.ItemCode,
                                                            ItemId = b7.ItemId,
                                                            ItemStoreId = b7.ItemStoreId,
                                                            parentId = null,
                                                            SalesId = FinalModel2.SalesId,
                                                            VendorCode = b7.VendorId.Value.ToString(),
                                                            PromotionCode = promo.PromotionId.Value.ToString(),
                                                            PublicPrice = (double?)b7.PublicPrice,
                                                            LineValue = 0.0,
                                                            CustomDiscount = 0.0,
                                                            CashDiscount = 0.0,
                                                            UnitId = PromotionItem4.UnitId,
                                                            TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem4.ClientPrice.Value * 0.14, 3) : 0.0),
                                                            VendorName = ((Lan == "ar") ? b7.VendorNameAr : b7.VendorNameEn),
                                                            ItemName = ((Lan == "ar") ? b7.ItemNameAr : b7.ItemNameEn)
                                                        });
                                                        FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                        {
                                                            ItemId = b7.ItemId,
                                                            ItemStoreId = b7.ItemStoreId,
                                                            SalesId = model.SalesId,
                                                            LineId = 0L,
                                                            PromotionId = promo.PromotionId,
                                                            Outcome = FINAL_QTY4,
                                                            OutcomeType = 1
                                                        });
                                                    }
                                                    break;
                                                }
                                                FinalModel2.PromotionOptions.Add(OptionModel2);
                                            }
                                        }
                                        IsApplied = true;
                                    }
                                    critriaCode5 = null;
                                }
                            }
                            if (PromotionCriteria == 2)
                            {
                                if (PromotionResultOutCome == 2)
                                {
                                    foreach (BOPromotionItem critriaCode4 in itemCriteria)
                                    {
                                        double? VALUE3 = (from a in FinalModel2.SalesOrderDetails
                                                          where a.IsBouns == false
                                                          where a.ItemCode == critriaCode4.ItemCode
                                                          select a).Sum((SalesOrderDetailListModel a) => (double?)a.Quantity * a.ClientPrice);
                                        int? QTY3 = (from a in FinalModel2.SalesOrderDetails
                                                     where a.IsBouns == false
                                                     where a.ItemCode == critriaCode4.ItemCode
                                                     select a).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                        double? slice3 = 0.0;
                                        double? slice_Value = 0.0;
                                        foreach (BOPromotionOutcome c2 in outCome.OrderByDescending((BOPromotionOutcome a) => a.Slice).ToList())
                                        {
                                            if (VALUE3 >= (double?)c2.Slice)
                                            {
                                                slice3 = (double?)c2.Slice;
                                                slice_Value = (double?)c2.Value;
                                                break;
                                            }
                                        }
                                        if (!slice3.HasValue || !(slice3 > 0.0) || !(slice_Value > 0.0))
                                        {
                                            continue;
                                        }
                                        double? Disount_Item = VALUE3 / slice3 * slice_Value / (double?)QTY3;
                                        foreach (SalesOrderDetailListModel item6 in FinalModel2.SalesOrderDetails)
                                        {
                                            if (item6.IsBouns == false && item6.ItemCode == critriaCode4.ItemCode)
                                            {
                                                item6.Discount += Math.Round(Disount_Item.Value, 3);
                                                FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                {
                                                    ItemId = item6.ItemId,
                                                    LineId = 0L,
                                                    ItemStoreId = item6.ItemStoreId,
                                                    SalesId = model.SalesId,
                                                    PromotionId = promo.PromotionId,
                                                    Outcome = (double?)item6.Quantity * Math.Round(Disount_Item.Value, 3),
                                                    OutcomeType = 2
                                                });
                                                item6.PromotionCode = promo.PromotionId.ToString();
                                                IsApplied = true;
                                            }
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 1)
                                {
                                    double VALUE4 = 0.0;
                                    foreach (BOPromotionItem critriaCode3 in itemCriteria)
                                    {
                                        VALUE4 += (from a in FinalModel2.SalesOrderDetails
                                                   where a.IsBouns == false
                                                   where a.ItemCode == critriaCode3.ItemCode
                                                   select a).Sum((SalesOrderDetailListModel a) => (double?)a.Quantity * a.ClientPrice).Value;
                                    }
                                    double? slice_percentage2 = 0.0;
                                    foreach (BOPromotionOutcome c3 in outCome.OrderByDescending((BOPromotionOutcome a) => a.Slice).ToList())
                                    {
                                        if (VALUE4 >= (double?)c3.Slice)
                                        {
                                            slice_percentage2 = (double?)c3.Value / 100.0;
                                            break;
                                        }
                                    }
                                    if (slice_percentage2.HasValue && slice_percentage2 > 0.0)
                                    {
                                        foreach (SalesOrderDetailListModel item7 in FinalModel2.SalesOrderDetails)
                                        {
                                            if (item7.IsBouns != false)
                                            {
                                                continue;
                                            }
                                            foreach (BOPromotionItem critriaCode9 in itemCriteria)
                                            {
                                                if (item7.ItemCode == critriaCode9.ItemCode)
                                                {
                                                    item7.Discount += Math.Round((slice_percentage2 * item7.ClientPrice).Value, 3);
                                                    FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                    {
                                                        ItemId = item7.ItemId,
                                                        LineId = 0L,
                                                        ItemStoreId = item7.ItemStoreId,
                                                        SalesId = model.SalesId,
                                                        PromotionId = promo.PromotionId,
                                                        Outcome = (double?)item7.Quantity * Math.Round((slice_percentage2 * item7.ClientPrice).Value, 3),
                                                        OutcomeType = 2
                                                    });
                                                    item7.PromotionCode = promo.PromotionId.ToString();
                                                    IsApplied = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 3)
                                {
                                    BOPromotionItem critriaCode2 = itemCriteria.FirstOrDefault();
                                    IGrouping<string, BOPromotionOutcome> itemOutcomeCodes = (from a in outCome
                                                                                              group a by a.ItemCode).ToList().FirstOrDefault();
                                    if (itemOutcomeCodes != null)
                                    {
                                        double? ORDER_VALUE3 = (from a in model.SalesOrderDetails
                                                                where a.IsBouns == false
                                                                where a.ItemCode == critriaCode2.ItemCode
                                                                select a).Sum((SalesOrderDetailListModel a) => (double?)a.Quantity * a.ClientPrice);
                                        List<BOPromotionOutcome> slice4 = (from a in outCome
                                                                           where a.ItemCode == itemOutcomeCodes.Key
                                                                           orderby a.Slice descending
                                                                           select a).ToList();
                                        int FINAL_QTY5 = 0;
                                        foreach (BOPromotionOutcome option5 in slice4)
                                        {
                                            while (ORDER_VALUE3 >= (double?)option5.Slice)
                                            {
                                                ORDER_VALUE3 -= (double)(int)option5.Slice.Value;
                                                FINAL_QTY5 += (int)option5.Value.Value;
                                            }
                                        }
                                        if (FINAL_QTY5 > 0)
                                        {
                                            BOItemVw PromotionItem5 = new Criteria<BOItemVw>().Add(Expression.Eq("ItemCode", itemOutcomeCodes.Key)).FirstOrDefault<BOItemVw>();
                                            new List<BOItemStoreVw>();
                                            if (PromotionItem5 != null)
                                            {
                                                IList<BOItemStoreVw> Batchs5 = new Criteria<BOItemStoreVw>().Add(Expression.Eq("ItemCode", PromotionItem5.ItemCode)).Add(Expression.Eq("StoreId", FinalModel2.StoreId)).Add(Expression.Gt("Available", 0))
                                                    .Add(Expression.Gt("ExpireDate", DateTime.Now.Date))
                                                    .Add(OrderBy.Asc("ExpireDate"))
                                                    .List<BOItemStoreVw>();
                                                if (Batchs5 != null && Batchs5.Count > 0 && Batchs5.Sum((BOItemStoreVw a) => a.Available) >= FINAL_QTY5)
                                                {
                                                    foreach (BOItemStoreVw b6 in Batchs5)
                                                    {
                                                        int? ORDER_QTY_ALL5 = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b6.ItemStoreId).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                                        int? Available5 = b6.Available - ORDER_QTY_ALL5;
                                                        if (Available5 <= FINAL_QTY5)
                                                        {
                                                            if (Available5 > 0)
                                                            {
                                                                FinalModel2.SalesOrderDetails.Add(new SalesOrderDetailListModel
                                                                {
                                                                    Quantity = Available5,
                                                                    Batch = b6.BatchNo,
                                                                    ClientPrice = 0.0,
                                                                    DetailId = new Random().Next(1111111, 9999999),
                                                                    Discount = 0.0,
                                                                    Expiration = b6.ExpireDate,
                                                                    Id = null,
                                                                    IsBouns = true,
                                                                    HasPromotion = false,
                                                                    ItemCode = b6.ItemCode,
                                                                    ItemId = b6.ItemId,
                                                                    ItemStoreId = b6.ItemStoreId,
                                                                    parentId = null,
                                                                    SalesId = FinalModel2.SalesId,
                                                                    VendorCode = b6.VendorId.Value.ToString(),
                                                                    PromotionCode = promo.PromotionId.Value.ToString(),
                                                                    PublicPrice = (double?)b6.PublicPrice,
                                                                    LineValue = 0.0,
                                                                    UnitId = PromotionItem5.UnitId,
                                                                    CustomDiscount = 0.0,
                                                                    CashDiscount = 0.0,
                                                                    TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem5.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                    VendorName = ((Lan == "ar") ? b6.VendorNameAr : b6.VendorNameEn),
                                                                    ItemName = ((Lan == "ar") ? b6.ItemNameAr : b6.ItemNameEn)
                                                                });
                                                                FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                                {
                                                                    ItemId = b6.ItemId,
                                                                    ItemStoreId = b6.ItemStoreId,
                                                                    SalesId = model.SalesId,
                                                                    LineId = 0L,
                                                                    PromotionId = promo.PromotionId,
                                                                    Outcome = Available5,
                                                                    OutcomeType = 1
                                                                });
                                                                FINAL_QTY5 -= Available5.Value;
                                                            }
                                                            continue;
                                                        }
                                                        if (FINAL_QTY5 > 0)
                                                        {
                                                            FinalModel2.SalesOrderDetails.Add(new SalesOrderDetailListModel
                                                            {
                                                                Quantity = FINAL_QTY5,
                                                                Batch = b6.BatchNo,
                                                                ClientPrice = 0.0,
                                                                DetailId = new Random().Next(1111111, 9999999),
                                                                Discount = 0.0,
                                                                Expiration = b6.ExpireDate,
                                                                Id = null,
                                                                IsBouns = true,
                                                                HasPromotion = false,
                                                                ItemCode = b6.ItemCode,
                                                                ItemId = b6.ItemId,
                                                                ItemStoreId = b6.ItemStoreId,
                                                                parentId = null,
                                                                SalesId = FinalModel2.SalesId,
                                                                VendorCode = b6.VendorId.Value.ToString(),
                                                                PromotionCode = promo.PromotionId.Value.ToString(),
                                                                PublicPrice = (double?)b6.PublicPrice,
                                                                LineValue = 0.0,
                                                                CustomDiscount = 0.0,
                                                                CashDiscount = 0.0,
                                                                UnitId = PromotionItem5.UnitId,
                                                                TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem5.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                VendorName = ((Lan == "ar") ? b6.VendorNameAr : b6.VendorNameEn),
                                                                ItemName = ((Lan == "ar") ? b6.ItemNameAr : b6.ItemNameEn)
                                                            });
                                                            FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                            {
                                                                ItemId = b6.ItemId,
                                                                ItemStoreId = b6.ItemStoreId,
                                                                SalesId = model.SalesId,
                                                                LineId = 0L,
                                                                PromotionId = promo.PromotionId,
                                                                Outcome = FINAL_QTY5,
                                                                OutcomeType = 1
                                                            });
                                                        }
                                                        break;
                                                    }
                                                }
                                            }
                                            IsApplied = true;
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 4)
                                {
                                    BOPromotionItem critriaCode = itemCriteria.FirstOrDefault();
                                    List<string> Options2 = (from a in outCome
                                                             group a by a.ItemCode into a
                                                             select a.Key).ToList();
                                    foreach (string ot in Options2)
                                    {
                                        double? ORDER_VALUE4 = (from a in model.SalesOrderDetails
                                                                where a.IsBouns == false
                                                                where a.ItemCode == critriaCode.ItemCode
                                                                select a).Sum((SalesOrderDetailListModel a) => (double?)a.Quantity * a.ClientPrice);
                                        List<BOPromotionOutcome> slice5 = (from a in outCome
                                                                           where a.ItemCode == ot
                                                                           orderby a.Slice descending
                                                                           select a).ToList();
                                        int FINAL_QTY6 = 0;
                                        foreach (BOPromotionOutcome option7 in slice5)
                                        {
                                            while (ORDER_VALUE4 >= (double?)option7.Slice)
                                            {
                                                ORDER_VALUE4 -= (double)(int)option7.Slice.Value;
                                                FINAL_QTY6 += (int)option7.Value.Value;
                                            }
                                        }
                                        if (FINAL_QTY6 <= 0)
                                        {
                                            continue;
                                        }
                                        BOItemVw PromotionItem6 = new Criteria<BOItemVw>().Add(Expression.Eq("ItemCode", ot)).FirstOrDefault<BOItemVw>();
                                        new List<BOItemStoreVw>();
                                        if (PromotionItem6 != null)
                                        {
                                            IList<BOItemStoreVw> Batchs6 = new Criteria<BOItemStoreVw>().Add(Expression.Eq("ItemCode", PromotionItem6.ItemCode)).Add(Expression.Eq("StoreId", FinalModel2.StoreId)).Add(Expression.Gt("Available", 0))
                                                .Add(Expression.Gt("ExpireDate", DateTime.Now.Date))
                                                .Add(OrderBy.Asc("ExpireDate"))
                                                .List<BOItemStoreVw>();
                                            if (Batchs6 != null && Batchs6.Count > 0 && Batchs6.Sum((BOItemStoreVw a) => a.Available) >= FINAL_QTY6)
                                            {
                                                SalesOrderPromotionOptionModel OptionModel3 = new SalesOrderPromotionOptionModel
                                                {
                                                    RowId = FinalModel2.PromotionOptions.Count + 1,
                                                    Selected = false,
                                                    PromotionId = promo.PromotionId.Value.ToString(),
                                                    ItemName = ((Lan == "ar") ? PromotionItem6.ItemNameAr : PromotionItem6.ItemNameEn),
                                                    ItemCode = PromotionItem6.ItemCode,
                                                    Quantity = FINAL_QTY6
                                                };
                                                foreach (BOItemStoreVw b5 in Batchs6)
                                                {
                                                    int? ORDER_QTY_ALL6 = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b5.ItemStoreId).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                                    int? Available6 = b5.Available - ORDER_QTY_ALL6;
                                                    if (Available6 <= FINAL_QTY6)
                                                    {
                                                        if (Available6 > 0)
                                                        {
                                                            OptionModel3.Batchs.Add(new SalesOrderDetailListModel
                                                            {
                                                                Quantity = Available6,
                                                                Batch = b5.BatchNo,
                                                                ClientPrice = 0.0,
                                                                DetailId = new Random().Next(1111111, 9999999),
                                                                Discount = 0.0,
                                                                Expiration = b5.ExpireDate,
                                                                Id = null,
                                                                IsBouns = true,
                                                                HasPromotion = false,
                                                                ItemCode = b5.ItemCode,
                                                                ItemId = b5.ItemId,
                                                                ItemStoreId = b5.ItemStoreId,
                                                                parentId = null,
                                                                SalesId = FinalModel2.SalesId,
                                                                VendorCode = b5.VendorId.Value.ToString(),
                                                                PromotionCode = promo.PromotionId.Value.ToString(),
                                                                PublicPrice = (double?)b5.PublicPrice,
                                                                LineValue = 0.0,
                                                                UnitId = PromotionItem6.UnitId,
                                                                CustomDiscount = 0.0,
                                                                CashDiscount = 0.0,
                                                                TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem6.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                VendorName = ((Lan == "ar") ? b5.VendorNameAr : b5.VendorNameEn),
                                                                ItemName = ((Lan == "ar") ? b5.ItemNameAr : b5.ItemNameEn)
                                                            });
                                                            FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                            {
                                                                ItemId = b5.ItemId,
                                                                ItemStoreId = b5.ItemStoreId,
                                                                SalesId = model.SalesId,
                                                                LineId = 0L,
                                                                PromotionId = promo.PromotionId,
                                                                Outcome = Available6,
                                                                OutcomeType = 1
                                                            });
                                                            FINAL_QTY6 -= Available6.Value;
                                                        }
                                                        continue;
                                                    }
                                                    if (FINAL_QTY6 > 0)
                                                    {
                                                        OptionModel3.Batchs.Add(new SalesOrderDetailListModel
                                                        {
                                                            Quantity = FINAL_QTY6,
                                                            Batch = b5.BatchNo,
                                                            ClientPrice = 0.0,
                                                            DetailId = new Random().Next(1111111, 9999999),
                                                            Discount = 0.0,
                                                            Expiration = b5.ExpireDate,
                                                            Id = null,
                                                            IsBouns = true,
                                                            HasPromotion = false,
                                                            ItemCode = b5.ItemCode,
                                                            ItemId = b5.ItemId,
                                                            ItemStoreId = b5.ItemStoreId,
                                                            parentId = null,
                                                            SalesId = FinalModel2.SalesId,
                                                            VendorCode = b5.VendorId.Value.ToString(),
                                                            PromotionCode = promo.PromotionId.Value.ToString(),
                                                            PublicPrice = (double?)b5.PublicPrice,
                                                            LineValue = 0.0,
                                                            CustomDiscount = 0.0,
                                                            CashDiscount = 0.0,
                                                            UnitId = PromotionItem6.UnitId,
                                                            TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem6.ClientPrice.Value * 0.14, 3) : 0.0),
                                                            VendorName = ((Lan == "ar") ? b5.VendorNameAr : b5.VendorNameEn),
                                                            ItemName = ((Lan == "ar") ? b5.ItemNameAr : b5.ItemNameEn)
                                                        });
                                                        FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                        {
                                                            ItemId = b5.ItemId,
                                                            ItemStoreId = b5.ItemStoreId,
                                                            SalesId = model.SalesId,
                                                            LineId = 0L,
                                                            PromotionId = promo.PromotionId,
                                                            Outcome = FINAL_QTY6,
                                                            OutcomeType = 1
                                                        });
                                                    }
                                                    break;
                                                }
                                                FinalModel2.PromotionOptions.Add(OptionModel3);
                                            }
                                        }
                                        IsApplied = true;
                                    }
                                }
                            }
                            if (PromotionCriteria == 3)
                            {
                                if (PromotionResultOutCome == 1)
                                {
                                    bool isMix_Allowed3 = true;
                                    int ORDER_QTY3 = 0;
                                    List<string> IDs4 = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (BOPromotionMixGroup group8 in groups)
                                        {
                                            double GroupQTY = (double)group8.Slice.Value;
                                            itemCriteria.Where((BOPromotionItem a) => a.GroupId == group8.GroupId).ToList();
                                            List<string> GroupItemIds8 = (from a in itemCriteria
                                                                          where a.GroupId == group8.GroupId
                                                                          select a.ItemCode).ToList();
                                            List<SalesOrderDetailListModel> OrderItems4 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
                                            if (GroupItemIds8.Count == 0)
                                            {
                                                isMix_Allowed3 = false;
                                                break;
                                            }
                                            List<SalesOrderDetailListModel> checkResult4 = OrderItems4.Where((SalesOrderDetailListModel o) => GroupItemIds8.Contains(o.ItemCode)).ToList();
                                            if (checkResult4.Count == 0)
                                            {
                                                isMix_Allowed3 = false;
                                                break;
                                            }
                                            int QTY4 = checkResult4.Sum((SalesOrderDetailListModel a) => a.Quantity).Value;
                                            if ((double)QTY4 < GroupQTY)
                                            {
                                                isMix_Allowed3 = false;
                                                break;
                                            }
                                            ORDER_QTY3 += QTY4;
                                            foreach (SalesOrderDetailListModel line4 in checkResult4)
                                            {
                                                IDs4.Add(line4.ItemCode);
                                            }
                                        }
                                        if (isMix_Allowed3)
                                        {
                                            decimal? GroupTotal4 = groups.Sum((BOPromotionMixGroup a) => a.Slice);
                                            List<BOPromotionOutcome> slices5 = outCome.OrderByDescending((BOPromotionOutcome a) => a.Count).ToList();
                                            double? slice7 = 0.0;
                                            foreach (BOPromotionOutcome option8 in slices5)
                                            {
                                                decimal? Total4 = (decimal?)option8.Count * GroupTotal4;
                                                decimal? num = Total4;
                                                if (((num.GetValueOrDefault() > default(decimal)) & num.HasValue) && (double)ORDER_QTY3 >= (double?)Total4)
                                                {
                                                    slice7 = (double?)option8.Value;
                                                    break;
                                                }
                                            }
                                            if (slice7 > 0.0)
                                            {
                                                List<SalesOrderDetailListModel> all2 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel o) => IDs4.Contains(o.ItemCode)).ToList();
                                                foreach (SalesOrderDetailListModel item9 in all2)
                                                {
                                                    double? Item_Discount_Single3 = slice7.Value / 100.0 * item9.ClientPrice;
                                                    int index3 = FinalModel2.SalesOrderDetails.IndexOf(item9);
                                                    FinalModel2.SalesOrderDetails[index3].Discount += Math.Round(Item_Discount_Single3.Value, 3);
                                                    FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                    {
                                                        ItemId = item9.ItemId,
                                                        LineId = 0L,
                                                        ItemStoreId = item9.ItemStoreId,
                                                        SalesId = model.SalesId,
                                                        PromotionId = promo.PromotionId,
                                                        Outcome = (double?)item9.Quantity * Math.Round(Item_Discount_Single3.Value, 3),
                                                        OutcomeType = 2
                                                    });
                                                    FinalModel2.SalesOrderDetails[index3].PromotionCode = promo.PromotionId.ToString();
                                                }
                                            }
                                            IsApplied = true;
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 2)
                                {
                                    bool isMix_Allowed5 = true;
                                    int ORDER_QTY4 = 0;
                                    List<string> IDs3 = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (BOPromotionMixGroup group7 in groups)
                                        {
                                            double GroupQTY2 = (double)group7.Slice.Value;
                                            itemCriteria.Where((BOPromotionItem a) => a.GroupId == group7.GroupId).ToList();
                                            List<string> GroupItemIds7 = (from a in itemCriteria
                                                                          where a.GroupId == group7.GroupId
                                                                          select a.ItemCode).ToList();
                                            List<SalesOrderDetailListModel> OrderItems5 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
                                            if (GroupItemIds7.Count == 0)
                                            {
                                                isMix_Allowed5 = false;
                                                break;
                                            }
                                            List<SalesOrderDetailListModel> checkResult5 = OrderItems5.Where((SalesOrderDetailListModel o) => GroupItemIds7.Contains(o.ItemCode)).ToList();
                                            if (checkResult5.Count == 0)
                                            {
                                                isMix_Allowed5 = false;
                                                break;
                                            }
                                            int QTY5 = checkResult5.Sum((SalesOrderDetailListModel a) => a.Quantity).Value;
                                            if ((double)QTY5 < GroupQTY2)
                                            {
                                                isMix_Allowed5 = false;
                                                break;
                                            }
                                            ORDER_QTY4 += QTY5;
                                            foreach (SalesOrderDetailListModel line5 in checkResult5)
                                            {
                                                IDs3.Add(line5.ItemCode);
                                            }
                                        }
                                        if (isMix_Allowed5)
                                        {
                                            decimal? GroupTotal5 = groups.Sum((BOPromotionMixGroup a) => a.Slice);
                                            List<BOPromotionOutcome> slices7 = outCome.OrderByDescending((BOPromotionOutcome a) => a.Count).ToList();
                                            double? slice9 = 0.0;
                                            foreach (BOPromotionOutcome option10 in slices7)
                                            {
                                                decimal? Total6 = (decimal?)option10.Count * GroupTotal5;
                                                decimal? num2 = Total6;
                                                if (((num2.GetValueOrDefault() > default(decimal)) & num2.HasValue) && (double)ORDER_QTY4 >= (double?)Total6)
                                                {
                                                    slice9 = (double?)option10.Value;
                                                    break;
                                                }
                                            }
                                            if (slice9.HasValue)
                                            {
                                                List<SalesOrderDetailListModel> all4 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel o) => IDs3.Contains(o.ItemCode)).ToList();
                                                double? TotalPrice2 = all4.Sum((SalesOrderDetailListModel a) => a.ClientPrice);
                                                if (TotalPrice2 > 0.0)
                                                {
                                                    foreach (SalesOrderDetailListModel item11 in all4)
                                                    {
                                                        double? obj = item11.ClientPrice / TotalPrice2;
                                                        double? Item_Discount_Single4 = slice9.Value * obj / (double?)item11.Quantity;
                                                        int index4 = FinalModel2.SalesOrderDetails.IndexOf(item11);
                                                        FinalModel2.SalesOrderDetails[index4].Discount += Math.Round(Item_Discount_Single4.Value, 3);
                                                        FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                        {
                                                            ItemId = item11.ItemId,
                                                            LineId = 0L,
                                                            ItemStoreId = item11.ItemStoreId,
                                                            SalesId = model.SalesId,
                                                            PromotionId = promo.PromotionId,
                                                            Outcome = (double?)item11.Quantity * Math.Round(Item_Discount_Single4.Value, 3),
                                                            OutcomeType = 2
                                                        });
                                                    }
                                                }
                                            }
                                            IsApplied = true;
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 3)
                                {
                                    bool isMix_Allowed7 = true;
                                    int ORDER_QTY5 = 0;
                                    List<string> IDs7 = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (BOPromotionMixGroup group6 in groups)
                                        {
                                            double GroupQTY3 = (double)group6.Slice.Value;
                                            itemCriteria.Where((BOPromotionItem a) => a.GroupId == group6.GroupId).ToList();
                                            List<string> GroupItemIds6 = (from a in itemCriteria
                                                                          where a.GroupId == group6.GroupId
                                                                          select a.ItemCode).ToList();
                                            List<SalesOrderDetailListModel> OrderItems7 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
                                            if (GroupItemIds6.Count == 0)
                                            {
                                                isMix_Allowed7 = false;
                                                break;
                                            }
                                            List<SalesOrderDetailListModel> checkResult7 = OrderItems7.Where((SalesOrderDetailListModel o) => GroupItemIds6.Contains(o.ItemCode)).ToList();
                                            if (checkResult7.Count == 0)
                                            {
                                                isMix_Allowed7 = false;
                                                break;
                                            }
                                            int QTY6 = checkResult7.Sum((SalesOrderDetailListModel a) => a.Quantity).Value;
                                            if ((double)QTY6 < GroupQTY3)
                                            {
                                                isMix_Allowed7 = false;
                                                break;
                                            }
                                            ORDER_QTY5 += QTY6;
                                            foreach (SalesOrderDetailListModel line7 in checkResult7)
                                            {
                                                IDs7.Add(line7.ItemCode);
                                            }
                                            GroupItemIds6 = null;
                                        }
                                        if (isMix_Allowed7)
                                        {
                                            decimal? GroupTotal7 = groups.Sum((BOPromotionMixGroup a) => a.Slice);
                                            List<BOPromotionOutcome> slices8 = outCome.OrderByDescending((BOPromotionOutcome a) => a.Count).ToList();
                                            int FINAL_QTY7 = 0;
                                            foreach (BOPromotionOutcome option11 in slices8)
                                            {
                                                decimal? Total7 = (decimal?)option11.Count * GroupTotal7;
                                                decimal? num = Total7;
                                                if (!((num.GetValueOrDefault() > default(decimal)) & num.HasValue))
                                                {
                                                    continue;
                                                }
                                                while (true)
                                                {
                                                    decimal num3 = ORDER_QTY5;
                                                    num = Total7;
                                                    if (!((num3 >= num.GetValueOrDefault()) & num.HasValue))
                                                    {
                                                        break;
                                                    }
                                                    ORDER_QTY5 -= (int)Total7.Value;
                                                    FINAL_QTY7 += (int)option11.Value.Value;
                                                }
                                            }
                                            BOPromotionOutcome itemOutcomeCode2 = outCome.FirstOrDefault();
                                            BOItemVw PromotionItem7 = new Criteria<BOItemVw>().Add(Expression.Eq("ItemCode", itemOutcomeCode2.ItemCode)).FirstOrDefault<BOItemVw>();
                                            new List<BOItemStoreVw>();
                                            if (PromotionItem7 != null)
                                            {
                                                IList<BOItemStoreVw> Batchs7 = new Criteria<BOItemStoreVw>().Add(Expression.Eq("ItemCode", PromotionItem7.ItemCode)).Add(Expression.Eq("StoreId", FinalModel2.StoreId)).Add(Expression.Gt("Available", 0))
                                                    .Add(Expression.Gt("ExpireDate", DateTime.Now.Date))
                                                    .Add(OrderBy.Asc("ExpireDate"))
                                                    .List<BOItemStoreVw>();
                                                if (Batchs7 != null && Batchs7.Count > 0)
                                                {
                                                    int? ALL_BATCH_COUNT3 = Batchs7.Sum((BOItemStoreVw a) => a.Available);
                                                    if (ALL_BATCH_COUNT3 >= FINAL_QTY7)
                                                    {
                                                        foreach (BOItemStoreVw b4 in Batchs7)
                                                        {
                                                            int? ORDER_QTY_ALL7 = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b4.ItemStoreId).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                                            int? Available7 = b4.Available - ORDER_QTY_ALL7;
                                                            if (Available7 <= FINAL_QTY7)
                                                            {
                                                                if (Available7 > 0)
                                                                {
                                                                    FinalModel2.SalesOrderDetails.Add(new SalesOrderDetailListModel
                                                                    {
                                                                        Quantity = Available7,
                                                                        Batch = b4.BatchNo,
                                                                        ClientPrice = 0.0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0.0,
                                                                        Expiration = b4.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b4.ItemCode,
                                                                        ItemId = b4.ItemId,
                                                                        ItemStoreId = b4.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel2.SalesId,
                                                                        VendorCode = b4.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b4.PublicPrice,
                                                                        LineValue = 0.0,
                                                                        UnitId = PromotionItem7.UnitId,
                                                                        CustomDiscount = 0.0,
                                                                        CashDiscount = 0.0,
                                                                        TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem7.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                        VendorName = ((Lan == "ar") ? b4.VendorNameAr : b4.VendorNameEn),
                                                                        ItemName = ((Lan == "ar") ? b4.ItemNameAr : b4.ItemNameEn)
                                                                    });
                                                                    FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                                    {
                                                                        ItemId = b4.ItemId,
                                                                        ItemStoreId = b4.ItemStoreId,
                                                                        SalesId = model.SalesId,
                                                                        LineId = 0L,
                                                                        PromotionId = promo.PromotionId,
                                                                        Outcome = Available7,
                                                                        OutcomeType = 1
                                                                    });
                                                                    FINAL_QTY7 -= Available7.Value;
                                                                }
                                                                continue;
                                                            }
                                                            if (FINAL_QTY7 > 0)
                                                            {
                                                                FinalModel2.SalesOrderDetails.Add(new SalesOrderDetailListModel
                                                                {
                                                                    Quantity = FINAL_QTY7,
                                                                    Batch = b4.BatchNo,
                                                                    ClientPrice = 0.0,
                                                                    DetailId = new Random().Next(1111111, 9999999),
                                                                    Discount = 0.0,
                                                                    Expiration = b4.ExpireDate,
                                                                    Id = null,
                                                                    IsBouns = true,
                                                                    HasPromotion = false,
                                                                    ItemCode = b4.ItemCode,
                                                                    ItemId = b4.ItemId,
                                                                    ItemStoreId = b4.ItemStoreId,
                                                                    parentId = null,
                                                                    SalesId = FinalModel2.SalesId,
                                                                    VendorCode = b4.VendorId.Value.ToString(),
                                                                    PromotionCode = promo.PromotionId.Value.ToString(),
                                                                    PublicPrice = (double?)b4.PublicPrice,
                                                                    LineValue = 0.0,
                                                                    CustomDiscount = 0.0,
                                                                    CashDiscount = 0.0,
                                                                    UnitId = PromotionItem7.UnitId,
                                                                    TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem7.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                    VendorName = ((Lan == "ar") ? b4.VendorNameAr : b4.VendorNameEn),
                                                                    ItemName = ((Lan == "ar") ? b4.ItemNameAr : b4.ItemNameEn)
                                                                });
                                                                FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                                {
                                                                    ItemId = b4.ItemId,
                                                                    ItemStoreId = b4.ItemStoreId,
                                                                    SalesId = model.SalesId,
                                                                    LineId = 0L,
                                                                    PromotionId = promo.PromotionId,
                                                                    Outcome = FINAL_QTY7,
                                                                    OutcomeType = 1
                                                                });
                                                            }
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        model.HasError = true;
                                                        model.Errors.Add(string.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem7.ItemCode, FINAL_QTY7, ALL_BATCH_COUNT3));
                                                    }
                                                }
                                                else
                                                {
                                                    model.HasError = true;
                                                    model.Errors.Add(string.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem7.ItemCode, FINAL_QTY7, 0));
                                                }
                                            }
                                            IsApplied = true;
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 4)
                                {
                                    bool isMix_Allowed8 = true;
                                    int ORDER_QTY6 = 0;
                                    List<string> IDs8 = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (BOPromotionMixGroup group5 in groups)
                                        {
                                            double GroupQTY4 = (double)group5.Slice.Value;
                                            itemCriteria.Where((BOPromotionItem a) => a.GroupId == group5.GroupId).ToList();
                                            List<string> GroupItemIds5 = (from a in itemCriteria
                                                                          where a.GroupId == group5.GroupId
                                                                          select a.ItemCode).ToList();
                                            List<SalesOrderDetailListModel> OrderItems8 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
                                            if (GroupItemIds5.Count == 0)
                                            {
                                                isMix_Allowed8 = false;
                                                break;
                                            }
                                            List<SalesOrderDetailListModel> checkResult8 = OrderItems8.Where((SalesOrderDetailListModel o) => GroupItemIds5.Contains(o.ItemCode)).ToList();
                                            if (checkResult8.Count == 0)
                                            {
                                                isMix_Allowed8 = false;
                                                break;
                                            }
                                            int QTY7 = checkResult8.Sum((SalesOrderDetailListModel a) => a.Quantity).Value;
                                            if ((double)QTY7 < GroupQTY4)
                                            {
                                                isMix_Allowed8 = false;
                                                break;
                                            }
                                            ORDER_QTY6 += QTY7;
                                            foreach (SalesOrderDetailListModel line8 in checkResult8)
                                            {
                                                IDs8.Add(line8.ItemCode);
                                            }
                                            GroupItemIds5 = null;
                                        }
                                        if (isMix_Allowed8)
                                        {
                                            decimal? GroupTotal8 = groups.Sum((BOPromotionMixGroup a) => a.Slice);
                                            List<string> outCodes2 = (from a in outCome
                                                                      group a by a.ItemCode into a
                                                                      select a.Key).ToList();
                                            foreach (string code2 in outCodes2)
                                            {
                                                int Slice_QTY = ORDER_QTY6;
                                                List<BOPromotionOutcome> slices9 = (from a in outCome
                                                                                    where a.ItemCode == code2
                                                                                    orderby a.Count descending
                                                                                    select a).ToList();
                                                int FINAL_QTY8 = 0;
                                                foreach (BOPromotionOutcome option12 in slices9)
                                                {
                                                    decimal? Total8 = (decimal?)option12.Count * GroupTotal8;
                                                    decimal? num2 = Total8;
                                                    if (!((num2.GetValueOrDefault() > default(decimal)) & num2.HasValue))
                                                    {
                                                        continue;
                                                    }
                                                    while (true)
                                                    {
                                                        decimal num3 = Slice_QTY;
                                                        num2 = Total8;
                                                        if (!((num3 >= num2.GetValueOrDefault()) & num2.HasValue))
                                                        {
                                                            break;
                                                        }
                                                        Slice_QTY -= (int)Total8.Value;
                                                        FINAL_QTY8 += (int)option12.Value.Value;
                                                    }
                                                }
                                                if (FINAL_QTY8 <= 0)
                                                {
                                                    continue;
                                                }
                                                BOItemVw PromotionItem8 = new Criteria<BOItemVw>().Add(Expression.Eq("ItemCode", code2)).FirstOrDefault<BOItemVw>();
                                                new List<BOItemStoreVw>();
                                                if (PromotionItem8 == null)
                                                {
                                                    continue;
                                                }
                                                IList<BOItemStoreVw> Batchs8 = new Criteria<BOItemStoreVw>().Add(Expression.Eq("ItemCode", PromotionItem8.ItemCode)).Add(Expression.Eq("StoreId", FinalModel2.StoreId)).Add(Expression.Gt("Available", 0))
                                                    .Add(Expression.Gt("ExpireDate", DateTime.Now.Date))
                                                    .Add(OrderBy.Asc("ExpireDate"))
                                                    .List<BOItemStoreVw>();
                                                if (Batchs8 == null || Batchs8.Count <= 0 || !(Batchs8.Sum((BOItemStoreVw a) => a.Available) >= FINAL_QTY8))
                                                {
                                                    continue;
                                                }
                                                SalesOrderPromotionOptionModel OptionModel4 = new SalesOrderPromotionOptionModel
                                                {
                                                    RowId = FinalModel2.PromotionOptions.Count + 1,
                                                    Selected = false,
                                                    PromotionId = promo.PromotionId.Value.ToString(),
                                                    ItemName = ((Lan == "ar") ? PromotionItem8.ItemNameAr : PromotionItem8.ItemNameEn),
                                                    ItemCode = PromotionItem8.ItemCode,
                                                    Quantity = FINAL_QTY8
                                                };
                                                foreach (BOItemStoreVw b3 in Batchs8)
                                                {
                                                    int? ORDER_QTY_ALL8 = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b3.ItemStoreId).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                                    int? Available8 = b3.Available - ORDER_QTY_ALL8;
                                                    if (Available8 <= FINAL_QTY8)
                                                    {
                                                        if (Available8 > 0)
                                                        {
                                                            OptionModel4.Batchs.Add(new SalesOrderDetailListModel
                                                            {
                                                                Quantity = Available8,
                                                                Batch = b3.BatchNo,
                                                                ClientPrice = 0.0,
                                                                DetailId = new Random().Next(1111111, 9999999),
                                                                Discount = 0.0,
                                                                Expiration = b3.ExpireDate,
                                                                Id = string.Empty,
                                                                IsBouns = true,
                                                                HasPromotion = false,
                                                                ItemCode = b3.ItemCode,
                                                                ItemId = b3.ItemId,
                                                                ItemStoreId = b3.ItemStoreId,
                                                                parentId = null,
                                                                SalesId = FinalModel2.SalesId,
                                                                VendorCode = b3.VendorId.Value.ToString(),
                                                                PromotionCode = promo.PromotionId.Value.ToString(),
                                                                PublicPrice = (double?)b3.PublicPrice,
                                                                LineValue = 0.0,
                                                                UnitId = PromotionItem8.UnitId,
                                                                CustomDiscount = 0.0,
                                                                CashDiscount = 0.0,
                                                                TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem8.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                VendorName = ((Lan == "ar") ? b3.VendorNameAr : b3.VendorNameEn),
                                                                ItemName = ((Lan == "ar") ? b3.ItemNameAr : b3.ItemNameEn)
                                                            });
                                                            FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                            {
                                                                ItemId = b3.ItemId,
                                                                ItemStoreId = b3.ItemStoreId,
                                                                SalesId = model.SalesId,
                                                                LineId = 0L,
                                                                PromotionId = promo.PromotionId,
                                                                Outcome = Available8,
                                                                OutcomeType = 1
                                                            });
                                                            FINAL_QTY8 -= Available8.Value;
                                                        }
                                                        continue;
                                                    }
                                                    if (FINAL_QTY8 > 0)
                                                    {
                                                        OptionModel4.Batchs.Add(new SalesOrderDetailListModel
                                                        {
                                                            Quantity = FINAL_QTY8,
                                                            Batch = b3.BatchNo,
                                                            ClientPrice = 0.0,
                                                            DetailId = new Random().Next(1111111, 9999999),
                                                            Discount = 0.0,
                                                            Expiration = b3.ExpireDate,
                                                            Id = null,
                                                            IsBouns = true,
                                                            HasPromotion = false,
                                                            ItemCode = b3.ItemCode,
                                                            ItemId = b3.ItemId,
                                                            ItemStoreId = b3.ItemStoreId,
                                                            parentId = null,
                                                            SalesId = FinalModel2.SalesId,
                                                            VendorCode = b3.VendorId.Value.ToString(),
                                                            PromotionCode = promo.PromotionId.Value.ToString(),
                                                            PublicPrice = (double?)b3.PublicPrice,
                                                            LineValue = 0.0,
                                                            CustomDiscount = 0.0,
                                                            CashDiscount = 0.0,
                                                            UnitId = PromotionItem8.UnitId,
                                                            TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem8.ClientPrice.Value * 0.14, 3) : 0.0),
                                                            VendorName = ((Lan == "ar") ? b3.VendorNameAr : b3.VendorNameEn),
                                                            ItemName = ((Lan == "ar") ? b3.ItemNameAr : b3.ItemNameEn)
                                                        });
                                                        FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                        {
                                                            ItemId = b3.ItemId,
                                                            ItemStoreId = b3.ItemStoreId,
                                                            SalesId = model.SalesId,
                                                            LineId = 0L,
                                                            PromotionId = promo.PromotionId,
                                                            Outcome = FINAL_QTY8,
                                                            OutcomeType = 1
                                                        });
                                                    }
                                                    break;
                                                }
                                                FinalModel2.PromotionOptions.Add(OptionModel4);
                                            }
                                            IsApplied = true;
                                        }
                                    }
                                }
                            }
                            if (PromotionCriteria == 4)
                            {
                                if (PromotionResultOutCome == 1)
                                {
                                    bool isMix_Allowed6 = true;
                                    double ORDER_VALUE6 = 0.0;
                                    List<string> IDs2 = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (BOPromotionMixGroup group4 in groups)
                                        {
                                            double GroupVALUE4 = (double)group4.Slice.Value;
                                            itemCriteria.Where((BOPromotionItem a) => a.GroupId == group4.GroupId).ToList();
                                            List<string> GroupItemIds4 = (from a in itemCriteria
                                                                          where a.GroupId == group4.GroupId
                                                                          select a.ItemCode).ToList();
                                            List<SalesOrderDetailListModel> OrderItems6 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
                                            if (GroupItemIds4.Count == 0)
                                            {
                                                isMix_Allowed6 = false;
                                                break;
                                            }
                                            List<SalesOrderDetailListModel> checkResult6 = OrderItems6.Where((SalesOrderDetailListModel o) => GroupItemIds4.Contains(o.ItemCode)).ToList();
                                            if (checkResult6.Count == 0)
                                            {
                                                isMix_Allowed6 = false;
                                                break;
                                            }
                                            double VALUE6 = checkResult6.Sum((SalesOrderDetailListModel a) => (double?)a.Quantity * a.ClientPrice).Value;
                                            if (VALUE6 < GroupVALUE4)
                                            {
                                                isMix_Allowed6 = false;
                                                break;
                                            }
                                            ORDER_VALUE6 += VALUE6;
                                            foreach (SalesOrderDetailListModel line6 in checkResult6)
                                            {
                                                IDs2.Add(line6.ItemCode);
                                            }
                                            GroupItemIds4 = null;
                                        }
                                        if (isMix_Allowed6)
                                        {
                                            decimal? GroupTotal6 = groups.Sum((BOPromotionMixGroup a) => a.Slice);
                                            List<BOPromotionOutcome> slices6 = outCome.OrderByDescending((BOPromotionOutcome a) => a.Count).ToList();
                                            double? slice8 = 0.0;
                                            foreach (BOPromotionOutcome option9 in slices6)
                                            {
                                                decimal? Total5 = (decimal?)option9.Count * GroupTotal6;
                                                decimal? num = Total5;
                                                if (((num.GetValueOrDefault() > default(decimal)) & num.HasValue) && ORDER_VALUE6 >= (double?)Total5)
                                                {
                                                    slice8 = (double?)option9.Value;
                                                    break;
                                                }
                                            }
                                            if (slice8 > 0.0)
                                            {
                                                List<SalesOrderDetailListModel> all3 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel o) => IDs2.Contains(o.ItemCode)).ToList();
                                                foreach (SalesOrderDetailListModel item10 in all3)
                                                {
                                                    double? Item_Discount_Single2 = slice8.Value / 100.0 * item10.ClientPrice;
                                                    int index2 = FinalModel2.SalesOrderDetails.IndexOf(item10);
                                                    FinalModel2.SalesOrderDetails[index2].Discount += Math.Round(Item_Discount_Single2.Value, 3);
                                                    FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                    {
                                                        ItemId = item10.ItemId,
                                                        LineId = 0L,
                                                        ItemStoreId = item10.ItemStoreId,
                                                        SalesId = model.SalesId,
                                                        PromotionId = promo.PromotionId,
                                                        Outcome = (double?)item10.Quantity * Math.Round(Item_Discount_Single2.Value, 3),
                                                        OutcomeType = 2
                                                    });
                                                    FinalModel2.SalesOrderDetails[index2].PromotionCode = promo.PromotionId.ToString();
                                                }
                                            }
                                            IsApplied = true;
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 2)
                                {
                                    bool isMix_Allowed4 = true;
                                    double ORDER_VALUE5 = 0.0;
                                    List<string> IDs = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (BOPromotionMixGroup group3 in groups)
                                        {
                                            double GroupVALUE3 = (double)group3.Slice.Value;
                                            itemCriteria.Where((BOPromotionItem a) => a.GroupId == group3.GroupId).ToList();
                                            List<string> GroupItemIds3 = (from a in itemCriteria
                                                                          where a.GroupId == group3.GroupId
                                                                          select a.ItemCode).ToList();
                                            List<SalesOrderDetailListModel> OrderItems3 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
                                            if (GroupItemIds3.Count == 0)
                                            {
                                                isMix_Allowed4 = false;
                                                break;
                                            }
                                            List<SalesOrderDetailListModel> checkResult3 = OrderItems3.Where((SalesOrderDetailListModel o) => GroupItemIds3.Contains(o.ItemCode)).ToList();
                                            if (checkResult3.Count == 0)
                                            {
                                                isMix_Allowed4 = false;
                                                break;
                                            }
                                            double VALUE5 = checkResult3.Sum((SalesOrderDetailListModel a) => (double?)a.Quantity * a.ClientPrice).Value;
                                            if (VALUE5 < GroupVALUE3)
                                            {
                                                isMix_Allowed4 = false;
                                                break;
                                            }
                                            ORDER_VALUE5 += VALUE5;
                                            foreach (SalesOrderDetailListModel line3 in checkResult3)
                                            {
                                                IDs.Add(line3.ItemCode);
                                            }
                                            GroupItemIds3 = null;
                                        }
                                        if (isMix_Allowed4)
                                        {
                                            decimal? GroupTotal3 = groups.Sum((BOPromotionMixGroup a) => a.Slice);
                                            List<BOPromotionOutcome> slices4 = outCome.OrderByDescending((BOPromotionOutcome a) => a.Count).ToList();
                                            double? slice6 = 0.0;
                                            foreach (BOPromotionOutcome option6 in slices4)
                                            {
                                                decimal? Total3 = (decimal?)option6.Count * GroupTotal3;
                                                decimal? num2 = Total3;
                                                if (((num2.GetValueOrDefault() > default(decimal)) & num2.HasValue) && ORDER_VALUE5 >= (double?)Total3)
                                                {
                                                    slice6 = (double?)option6.Value;
                                                    break;
                                                }
                                            }
                                            if (slice6.HasValue)
                                            {
                                                List<SalesOrderDetailListModel> all = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel o) => IDs.Contains(o.ItemCode)).ToList();
                                                double? TotalPrice = all.Sum((SalesOrderDetailListModel a) => a.ClientPrice);
                                                if (TotalPrice > 0.0)
                                                {
                                                    foreach (SalesOrderDetailListModel item8 in all)
                                                    {
                                                        double? obj2 = item8.ClientPrice / TotalPrice;
                                                        double? Item_Discount_Single = slice6.Value * obj2 / (double?)item8.Quantity;
                                                        int index = FinalModel2.SalesOrderDetails.IndexOf(item8);
                                                        FinalModel2.SalesOrderDetails[index].Discount += Math.Round(Item_Discount_Single.Value, 3);
                                                        FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                        {
                                                            ItemId = item8.ItemId,
                                                            LineId = 0L,
                                                            ItemStoreId = item8.ItemStoreId,
                                                            SalesId = model.SalesId,
                                                            PromotionId = promo.PromotionId,
                                                            Outcome = (double?)item8.Quantity * Math.Round(Item_Discount_Single.Value, 3),
                                                            OutcomeType = 2
                                                        });
                                                        FinalModel2.SalesOrderDetails[index].PromotionCode = promo.PromotionId.ToString();
                                                    }
                                                }
                                            }
                                            IsApplied = true;
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 3)
                                {
                                    bool isMix_Allowed2 = true;
                                    double ORDER_VALUE2 = 0.0;
                                    List<string> IDs6 = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (BOPromotionMixGroup group2 in groups)
                                        {
                                            double GroupVALUE2 = (double)group2.Slice.Value;
                                            itemCriteria.Where((BOPromotionItem a) => a.GroupId == group2.GroupId).ToList();
                                            List<string> GroupItemIds2 = (from a in itemCriteria
                                                                          where a.GroupId == group2.GroupId
                                                                          select a.ItemCode).ToList();
                                            List<SalesOrderDetailListModel> OrderItems2 = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
                                            if (GroupItemIds2.Count == 0)
                                            {
                                                isMix_Allowed2 = false;
                                                break;
                                            }
                                            List<SalesOrderDetailListModel> checkResult2 = OrderItems2.Where((SalesOrderDetailListModel o) => GroupItemIds2.Contains(o.ItemCode)).ToList();
                                            if (checkResult2.Count == 0)
                                            {
                                                isMix_Allowed2 = false;
                                                break;
                                            }
                                            double VALUE2 = checkResult2.Sum((SalesOrderDetailListModel a) => (double?)a.Quantity * a.ClientPrice).Value;
                                            if (VALUE2 < GroupVALUE2)
                                            {
                                                isMix_Allowed2 = false;
                                                break;
                                            }
                                            ORDER_VALUE2 += VALUE2;
                                            foreach (SalesOrderDetailListModel line2 in checkResult2)
                                            {
                                                IDs6.Add(line2.ItemCode);
                                            }
                                            GroupItemIds2 = null;
                                        }
                                        if (isMix_Allowed2)
                                        {
                                            decimal? GroupTotal2 = groups.Sum((BOPromotionMixGroup a) => a.Slice);
                                            List<BOPromotionOutcome> slices3 = outCome.OrderByDescending((BOPromotionOutcome a) => a.Count).ToList();
                                            int FINAL_QTY3 = 0;
                                            foreach (BOPromotionOutcome option3 in slices3)
                                            {
                                                decimal? Total2 = (decimal?)option3.Count * GroupTotal2;
                                                decimal? num = Total2;
                                                if ((num.GetValueOrDefault() > default(decimal)) & num.HasValue)
                                                {
                                                    while (ORDER_VALUE2 >= (double)Total2.Value)
                                                    {
                                                        ORDER_VALUE2 -= (double)(int)Total2.Value;
                                                        FINAL_QTY3 += (int)option3.Value.Value;
                                                    }
                                                }
                                            }
                                            BOPromotionOutcome itemOutcomeCode = outCome.FirstOrDefault();
                                            BOItemVw PromotionItem2 = new Criteria<BOItemVw>().Add(Expression.Eq("ItemCode", itemOutcomeCode.ItemCode)).FirstOrDefault<BOItemVw>();
                                            new List<BOItemStoreVw>();
                                            if (PromotionItem2 != null)
                                            {
                                                IList<BOItemStoreVw> Batchs2 = new Criteria<BOItemStoreVw>().Add(Expression.Eq("ItemCode", PromotionItem2.ItemCode)).Add(Expression.Eq("StoreId", FinalModel2.StoreId)).Add(Expression.Gt("Available", 0))
                                                    .Add(OrderBy.Asc("ExpireDate"))
                                                    .Add(Expression.Gt("ExpireDate", DateTime.Now.Date))
                                                    .List<BOItemStoreVw>();
                                                if (Batchs2 != null && Batchs2.Count > 0)
                                                {
                                                    int? ALL_BATCH_COUNT = Batchs2.Sum((BOItemStoreVw a) => a.Available);
                                                    if (ALL_BATCH_COUNT >= FINAL_QTY3)
                                                    {
                                                        foreach (BOItemStoreVw b2 in Batchs2)
                                                        {
                                                            int? ORDER_QTY_ALL2 = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b2.ItemStoreId).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                                            int? Available2 = b2.Available - ORDER_QTY_ALL2;
                                                            if (Available2 <= FINAL_QTY3)
                                                            {
                                                                if (Available2 > 0)
                                                                {
                                                                    FinalModel2.SalesOrderDetails.Add(new SalesOrderDetailListModel
                                                                    {
                                                                        Quantity = Available2,
                                                                        Batch = b2.BatchNo,
                                                                        ClientPrice = 0.0,
                                                                        DetailId = new Random().Next(1111111, 9999999),
                                                                        Discount = 0.0,
                                                                        Expiration = b2.ExpireDate,
                                                                        Id = null,
                                                                        IsBouns = true,
                                                                        HasPromotion = false,
                                                                        ItemCode = b2.ItemCode,
                                                                        ItemId = b2.ItemId,
                                                                        ItemStoreId = b2.ItemStoreId,
                                                                        parentId = null,
                                                                        SalesId = FinalModel2.SalesId,
                                                                        VendorCode = b2.VendorId.Value.ToString(),
                                                                        PromotionCode = promo.PromotionId.Value.ToString(),
                                                                        PublicPrice = (double?)b2.PublicPrice,
                                                                        LineValue = 0.0,
                                                                        UnitId = PromotionItem2.UnitId,
                                                                        CustomDiscount = 0.0,
                                                                        CashDiscount = 0.0,
                                                                        TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem2.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                        VendorName = ((Lan == "ar") ? b2.VendorNameAr : b2.VendorNameEn),
                                                                        ItemName = ((Lan == "ar") ? b2.ItemNameAr : b2.ItemNameEn)
                                                                    });
                                                                    FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                                    {
                                                                        ItemId = b2.ItemId,
                                                                        ItemStoreId = b2.ItemStoreId,
                                                                        SalesId = model.SalesId,
                                                                        LineId = 0L,
                                                                        PromotionId = promo.PromotionId,
                                                                        Outcome = Available2,
                                                                        OutcomeType = 1
                                                                    });
                                                                    FINAL_QTY3 -= Available2.Value;
                                                                }
                                                                continue;
                                                            }
                                                            if (FINAL_QTY3 > 0)
                                                            {
                                                                FinalModel2.SalesOrderDetails.Add(new SalesOrderDetailListModel
                                                                {
                                                                    Quantity = FINAL_QTY3,
                                                                    Batch = b2.BatchNo,
                                                                    ClientPrice = 0.0,
                                                                    DetailId = new Random().Next(1111111, 9999999),
                                                                    Discount = 0.0,
                                                                    Expiration = b2.ExpireDate,
                                                                    Id = null,
                                                                    IsBouns = true,
                                                                    HasPromotion = false,
                                                                    ItemCode = b2.ItemCode,
                                                                    ItemId = b2.ItemId,
                                                                    ItemStoreId = b2.ItemStoreId,
                                                                    parentId = null,
                                                                    SalesId = FinalModel2.SalesId,
                                                                    VendorCode = b2.VendorId.Value.ToString(),
                                                                    PromotionCode = promo.PromotionId.Value.ToString(),
                                                                    PublicPrice = (double?)b2.PublicPrice,
                                                                    LineValue = 0.0,
                                                                    CustomDiscount = 0.0,
                                                                    CashDiscount = 0.0,
                                                                    UnitId = PromotionItem2.UnitId,
                                                                    TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem2.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                    VendorName = ((Lan == "ar") ? b2.VendorNameAr : b2.VendorNameEn),
                                                                    ItemName = ((Lan == "ar") ? b2.ItemNameAr : b2.ItemNameEn)
                                                                });
                                                                FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                                {
                                                                    ItemId = b2.ItemId,
                                                                    ItemStoreId = b2.ItemStoreId,
                                                                    SalesId = model.SalesId,
                                                                    LineId = 0L,
                                                                    PromotionId = promo.PromotionId,
                                                                    Outcome = FINAL_QTY3,
                                                                    OutcomeType = 1
                                                                });
                                                            }
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        model.HasError = true;
                                                        model.Errors.Add(string.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem2.ItemCode, FINAL_QTY3, ALL_BATCH_COUNT));
                                                    }
                                                }
                                                else
                                                {
                                                    model.HasError = true;
                                                    model.Errors.Add(string.Format(PromotionError.INVALID_BOUNS_QTY, PromotionItem2.ItemCode, FINAL_QTY3, 0));
                                                }
                                            }
                                            IsApplied = true;
                                        }
                                    }
                                }
                                if (PromotionResultOutCome == 4)
                                {
                                    bool isMix_Allowed = true;
                                    double ORDER_VALUE = 0.0;
                                    List<string> IDs5 = new List<string>();
                                    if (groups != null)
                                    {
                                        foreach (BOPromotionMixGroup group in groups)
                                        {
                                            double GroupVALUE = (double)group.Slice.Value;
                                            itemCriteria.Where((BOPromotionItem a) => a.GroupId == group.GroupId).ToList();
                                            List<string> GroupItemIds = (from a in itemCriteria
                                                                         where a.GroupId == @group.GroupId
                                                                         select a.ItemCode).ToList();
                                            List<SalesOrderDetailListModel> OrderItems = FinalModel2.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
                                            if (GroupItemIds.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }
                                            List<SalesOrderDetailListModel> checkResult = OrderItems.Where((SalesOrderDetailListModel o) => GroupItemIds.Contains(o.ItemCode)).ToList();
                                            if (checkResult.Count == 0)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }
                                            double VALUE = checkResult.Sum((SalesOrderDetailListModel a) => (double?)a.Quantity * a.ClientPrice).Value;
                                            if (VALUE < GroupVALUE)
                                            {
                                                isMix_Allowed = false;
                                                break;
                                            }
                                            ORDER_VALUE += VALUE;
                                            foreach (SalesOrderDetailListModel line in checkResult)
                                            {
                                                IDs5.Add(line.ItemCode);
                                            }
                                            GroupItemIds = null;
                                        }
                                        if (isMix_Allowed)
                                        {
                                            decimal? GroupTotal = groups.Sum((BOPromotionMixGroup a) => a.Slice);
                                            List<string> outCodes = (from a in outCome
                                                                     group a by a.ItemCode into a
                                                                     select a.Key).ToList();
                                            foreach (string code in outCodes)
                                            {
                                                double Slice_VALUE = ORDER_VALUE;
                                                List<BOPromotionOutcome> slices = (from a in outCome
                                                                                   where a.ItemCode == code
                                                                                   orderby a.Count descending
                                                                                   select a).ToList();
                                                int FINAL_QTY = 0;
                                                foreach (BOPromotionOutcome option in slices)
                                                {
                                                    decimal? Total = (decimal?)option.Count * GroupTotal;
                                                    decimal? num2 = Total;
                                                    if ((num2.GetValueOrDefault() > default(decimal)) & num2.HasValue)
                                                    {
                                                        while (Slice_VALUE >= (double)Total.Value)
                                                        {
                                                            Slice_VALUE -= (double)(int)Total.Value;
                                                            FINAL_QTY += (int)option.Value.Value;
                                                        }
                                                    }
                                                }
                                                if (FINAL_QTY <= 0)
                                                {
                                                    continue;
                                                }
                                                BOItemVw PromotionItem = new Criteria<BOItemVw>().Add(Expression.Eq("ItemCode", code)).FirstOrDefault<BOItemVw>();
                                                new List<BOItemStoreVw>();
                                                if (PromotionItem == null)
                                                {
                                                    continue;
                                                }
                                                IList<BOItemStoreVw> Batchs = new Criteria<BOItemStoreVw>().Add(Expression.Eq("ItemCode", PromotionItem.ItemCode)).Add(Expression.Eq("StoreId", FinalModel2.StoreId)).Add(Expression.Gt("Available", 0))
                                                    .Add(Expression.Gt("ExpireDate", DateTime.Now.Date))
                                                    .Add(OrderBy.Asc("ExpireDate"))
                                                    .List<BOItemStoreVw>();
                                                if (Batchs == null || Batchs.Count <= 0 || !(Batchs.Sum((BOItemStoreVw a) => a.Available) >= FINAL_QTY))
                                                {
                                                    continue;
                                                }
                                                SalesOrderPromotionOptionModel OptionModel = new SalesOrderPromotionOptionModel
                                                {
                                                    RowId = FinalModel2.PromotionOptions.Count + 1,
                                                    Selected = false,
                                                    PromotionId = promo.PromotionId.Value.ToString(),
                                                    ItemName = ((Lan == "ar") ? PromotionItem.ItemNameAr : PromotionItem.ItemNameEn),
                                                    ItemCode = PromotionItem.ItemCode,
                                                    Quantity = FINAL_QTY
                                                };
                                                foreach (BOItemStoreVw b in Batchs)
                                                {
                                                    int? ORDER_QTY_ALL = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b.ItemStoreId).Sum((SalesOrderDetailListModel a) => a.Quantity);
                                                    int? Available = b.Available - ORDER_QTY_ALL;
                                                    if (Available <= FINAL_QTY)
                                                    {
                                                        if (Available > 0)
                                                        {
                                                            OptionModel.Batchs.Add(new SalesOrderDetailListModel
                                                            {
                                                                Quantity = Available,
                                                                Batch = b.BatchNo,
                                                                ClientPrice = 0.0,
                                                                DetailId = new Random().Next(1111111, 9999999),
                                                                Discount = 0.0,
                                                                Expiration = b.ExpireDate,
                                                                Id = string.Empty,
                                                                IsBouns = true,
                                                                HasPromotion = false,
                                                                ItemCode = b.ItemCode,
                                                                ItemId = b.ItemId,
                                                                ItemStoreId = b.ItemStoreId,
                                                                parentId = null,
                                                                SalesId = FinalModel2.SalesId,
                                                                VendorCode = b.VendorId.Value.ToString(),
                                                                PromotionCode = promo.PromotionId.Value.ToString(),
                                                                PublicPrice = (double?)b.PublicPrice,
                                                                LineValue = 0.0,
                                                                UnitId = PromotionItem.UnitId,
                                                                CustomDiscount = 0.0,
                                                                CashDiscount = 0.0,
                                                                TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem.ClientPrice.Value * 0.14, 3) : 0.0),
                                                                VendorName = ((Lan == "ar") ? b.VendorNameAr : b.VendorNameEn),
                                                                ItemName = ((Lan == "ar") ? b.ItemNameAr : b.ItemNameEn)
                                                            });
                                                            FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                            {
                                                                ItemId = b.ItemId,
                                                                ItemStoreId = b.ItemStoreId,
                                                                SalesId = model.SalesId,
                                                                LineId = 0L,
                                                                PromotionId = promo.PromotionId,
                                                                Outcome = Available,
                                                                OutcomeType = 1
                                                            });
                                                            FINAL_QTY -= Available.Value;
                                                        }
                                                        continue;
                                                    }
                                                    if (FINAL_QTY > 0)
                                                    {
                                                        OptionModel.Batchs.Add(new SalesOrderDetailListModel
                                                        {
                                                            Quantity = FINAL_QTY,
                                                            Batch = b.BatchNo,
                                                            ClientPrice = 0.0,
                                                            DetailId = new Random().Next(1111111, 9999999),
                                                            Discount = 0.0,
                                                            Expiration = b.ExpireDate,
                                                            Id = null,
                                                            IsBouns = true,
                                                            HasPromotion = false,
                                                            ItemCode = b.ItemCode,
                                                            ItemId = b.ItemId,
                                                            ItemStoreId = b.ItemStoreId,
                                                            parentId = null,
                                                            SalesId = FinalModel2.SalesId,
                                                            VendorCode = b.VendorId.Value.ToString(),
                                                            PromotionCode = promo.PromotionId.Value.ToString(),
                                                            PublicPrice = (double?)b.PublicPrice,
                                                            LineValue = 0.0,
                                                            CustomDiscount = 0.0,
                                                            CashDiscount = 0.0,
                                                            UnitId = PromotionItem.UnitId,
                                                            TaxValue = (EnablePromotionTax ? Math.Round((double)PromotionItem.ClientPrice.Value * 0.14, 3) : 0.0),
                                                            VendorName = ((Lan == "ar") ? b.VendorNameAr : b.VendorNameEn),
                                                            ItemName = ((Lan == "ar") ? b.ItemNameAr : b.ItemNameEn)
                                                        });
                                                        FinalModel2.LineBouns.Add(new SalesOrderLinePromotionModel
                                                        {
                                                            ItemId = b.ItemId,
                                                            ItemStoreId = b.ItemStoreId,
                                                            SalesId = model.SalesId,
                                                            LineId = 0L,
                                                            PromotionId = promo.PromotionId,
                                                            Outcome = FINAL_QTY,
                                                            OutcomeType = 1
                                                        });
                                                    }
                                                    break;
                                                }
                                                FinalModel2.PromotionOptions.Add(OptionModel);
                                            }
                                            IsApplied = true;
                                        }
                                    }
                                }
                            }
                        }
                        if (!IsApplied || string.IsNullOrEmpty(p.VendorCode))
                        {
                            continue;
                        }
                        List<OrderPromotionFinal> res = promos.Where((OrderPromotionFinal a) => a.VendorCode == p.VendorCode).ToList();
                        foreach (OrderPromotionFinal item in res)
                        {
                            item.IsDone = true;
                        }
                    }
                }
                FinalModel2 = CaluclucateTotals(FinalModel2);
                FinalModel2.SalesOrderDetails = FinalModel2.SalesOrderDetails.OrderBy((SalesOrderDetailListModel a) => a.ItemCode).ToList();
            }
            catch
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_PROMOTION);
                return model;
            }
            return FinalModel2;
        }
        public async Task<SalesOrderModelWeb> CaluclucateOrder1 (SalesOrderModelWeb model,string Lan)
        {
            model.LineBouns.Clear();
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

                FinalModel = CaluclucateTotals(FinalModel);
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
        public async Task<SalesOrderModelWeb> CaluclucateTotals1(SalesOrderModelWeb model)
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
            

            return  model;

        }
        public SalesOrderModelWeb CaluclucateTotals(SalesOrderModelWeb model)
        {
            try
            {
                if (model.SalesOrderDetails == null)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.ERROR_CALCULATION);
                    return model;
                }
                foreach (SalesOrderDetailListModel item in model.SalesOrderDetails)
                {
                    if (item.TaxValue > 0.0)
                    {
                        item.TaxValue = Math.Round((item.ClientPrice.Value - item.Discount.Value) * 0.14, 3);
                    }
                }
                model.TaxTotal = Math.Round(model.SalesOrderDetails.Sum((SalesOrderDetailListModel a) => a.TaxValue * (double?)a.Quantity).Value, 3);
                if (!model.TaxTotal.HasValue)
                {
                    model.TaxTotal = 0.0;
                }
                BOAppSetting Delivery_Fees = new Criteria<BOAppSetting>().Add(Expression.Eq("SettingCode", "ORDER.DELIVERY")).FirstOrDefault<BOAppSetting>();
                if (Delivery_Fees != null)
                {
                    model.DeliveryTotal = Math.Round(double.Parse(Delivery_Fees.SettingValue), 3);
                    if (!model.DeliveryTotal.HasValue)
                    {
                        model.DeliveryTotal = 0.0;
                    }
                }
                model.ItemTotal = Math.Round(model.SalesOrderDetails.Sum((SalesOrderDetailListModel a) => a.ClientPrice * (double?)a.Quantity).Value, 3);
                if (!model.ItemTotal.HasValue)
                {
                    model.ItemTotal = 0.0;
                }
                model.ItemDiscountTotal = Math.Round(model.SalesOrderDetails.Sum((SalesOrderDetailListModel a) => a.Discount * (double?)a.Quantity).Value, 3);
                if (!model.ItemDiscountTotal.HasValue)
                {
                    model.ItemDiscountTotal = 0.0;
                }
                model.CustomDiscountTotal = Math.Round(model.SalesOrderDetails.Sum((SalesOrderDetailListModel a) => a.CustomDiscount * (double?)a.Quantity).Value, 3);
                if (!model.CustomDiscountTotal.HasValue)
                {
                    model.CustomDiscountTotal = 0.0;
                }
                model.NetTotal = Math.Round((model.ItemTotal + model.TaxTotal + model.DeliveryTotal - model.ItemDiscountTotal - model.CustomDiscountTotal).Value, 3);
                if (model.NetTotal < 0.0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_TOTAL);
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
        public async  Task<SalesOrderModelWeb> ValidateOrder1(SalesOrderModelWeb model,string lan)
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
        public async Task<SalesOrderModelWeb> CaluclucateCashDiscount(SalesOrderModelWeb model)
        {
            try
            {
                model.CashDiscountTotal = 0.0;
                new BOClient(model.ClientId.Value);
                new List<BOPromotion>();
                IList<BOPromotion> cashPromo = new Criteria<BOPromotion>().Add(Expression.Eq("PromotionCategoryId", 3)).Add(Expression.Lte("ValidFrom", model.SalesDate)).Add(Expression.Gte("ValidTo", model.SalesDate))
                    .Add(Expression.Eq("IsActive", true))
                    .Add(Expression.Eq("IsApproved", true))
                    .Add(OrderBy.Desc("PromotionCategoryId"))
                    .Add(OrderBy.Asc("Priority"))
                    .List<BOPromotion>();
                List<string> vs = new List<string>();
                foreach (BOPromotion promo in cashPromo)
                {
                    bool IsAllowedClient = await PromotionHelper.IsAllowedClient(model.ClientCode, promo.PromotionId.Value);
                    bool IsAllowedSalesMan = await PromotionHelper.IsAllowedSalesMan(model.RepresentativeId, promo.PromotionId.Value);
                    if (!IsAllowedClient || !IsAllowedSalesMan)
                    {
                        continue;
                    }
                    double? OrderTotal = 0.0;
                    double? CashDiscount = 0.0;
                    foreach (SalesOrderDetailListModel item in model.SalesOrderDetails)
                    {
                        string exist = vs.Where((string a) => a.Equals(item.ItemCode)).FirstOrDefault();
                        if (exist == null && await PromotionHelper.IsAllowedCashItem(item.ItemCode, promo.PromotionId.Value))
                        {
                            OrderTotal += model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.ItemCode == item.ItemCode).Sum((SalesOrderDetailListModel a) => (double?)a.Quantity * a.ClientPrice);
                            vs.Add(item.ItemCode);
                        }
                    }
                    IList<BOPromotionOutcome> outCome = new Criteria<BOPromotionOutcome>().Add(Expression.Eq("PromotionId", promo.PromotionId)).List<BOPromotionOutcome>();
                    foreach (BOPromotionOutcome ot in outCome.OrderByDescending((BOPromotionOutcome a) => a.Slice).ToList())
                    {
                        if (OrderTotal >= (double?)ot.Slice)
                        {
                            CashDiscount = OrderTotal * ((double?)ot.Value / 100.0);
                            break;
                        }
                    }
                    model.CashDiscountTotal += Math.Round((CashDiscount.Value > 0.0) ? CashDiscount.Value : 0.0, 3);
                }
            }
            catch
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_PROMOTION);
                return model;
            }
            return model;
        }
        public async Task<SalesOrderModelWeb> ValidateOrder(SalesOrderModelWeb model, string lan)
        {
            try
            {
                model.HasError = false;
                model = await CaluclucateOrder(model, lan);
                model = await CaluclucateCashDiscount(model);
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
                if (!model.ClientId.HasValue || model.ClientId == 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }
                BOClient ClientModel = new Criteria<BOClient>().Add(Expression.Eq("ClientId", model.ClientId)).FirstOrDefault<BOClient>();
                if (ClientModel == null)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_CLIENT);
                }
                if (ClientModel.IsActive != true)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INACTVE_CLIENT);
                }
                if (!model.RepresentativeId.HasValue || model.RepresentativeId == 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }
                BORepresentative RepresentativeModel = new Criteria<BORepresentative>().Add(Expression.Eq("RepresentativeId", model.RepresentativeId)).FirstOrDefault<BORepresentative>();
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
                if (!model.BranchId.HasValue || model.BranchId == 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }
                BOBranch BranchModel = new Criteria<BOBranch>().Add(Expression.Eq("BranchId", model.BranchId)).FirstOrDefault<BOBranch>();
                if (BranchModel == null)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }
                if (BranchModel.IsActive != true)
                {
                    model.HasError = true;
                    model.Errors.Add(string.Format(PromotionError.INACTVE_BRANCH, BranchModel.BranchCode));
                }
                if (!model.StoreId.HasValue || model.StoreId == 0)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }
                BOStore StoreModel = new Criteria<BOStore>().Add(Expression.Eq("StoreId", model.StoreId)).FirstOrDefault<BOStore>();
                if (StoreModel == null)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_MODEL);
                }
                if (StoreModel.IsActive != true)
                {
                    model.HasError = true;
                    model.Errors.Add(string.Format(PromotionError.INACTVE_WAREHOUSE, StoreModel.StoreCode));
                }
                List<SalesOrderDetailListModel> expired = model.SalesOrderDetails.Where((SalesOrderDetailListModel x) => x.Expiration < DateTime.Now.Date).ToList();
                if (expired.Count > 0)
                {
                    model.HasError = true;
                    foreach (SalesOrderDetailListModel x2 in expired)
                    {
                        model.Errors.Add(string.Format(PromotionError.ITEM_EXPIRED, x2.ItemCode));
                    }
                }
                List<int?> ItemStr = model.SalesOrderDetails.Select((SalesOrderDetailListModel x) => x.ItemId).ToList();
                IList<BOItemQuotaByClientVw> ClientHistoyQouta = new Criteria<BOItemQuotaByClientVw>().Add(Expression.Eq("ClientId", model.ClientId)).Add(Expression.Gte("SalesDate", model.SalesTime.Value.FirstDayOfMonth())).Add(Expression.In("ItemId", string.Join(',', ItemStr)))
                    .List<BOItemQuotaByClientVw>();
                IList<BOItemQuota> ItemQouta = new Criteria<BOItemQuota>().Add(Expression.In("ItemId", string.Join(',', ItemStr))).List<BOItemQuota>();
                IList<BOClientQuota> ExceptionQouta = new Criteria<BOClientQuota>().Add(Expression.In("ItemId", string.Join(',', ItemStr))).Add(Expression.Eq("ClientId", model.ClientId)).List<BOClientQuota>();
                List<SalesOrderDetailListModel> OrderItems = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
                if (ExceptionQouta == null)
                {
                    ExceptionQouta = new List<BOClientQuota>();
                }
                if (ClientHistoyQouta == null)
                {
                    ClientHistoyQouta = new List<BOItemQuotaByClientVw>();
                }
                if (ItemQouta == null)
                {
                    ItemQouta = new List<BOItemQuota>();
                }
                var GroupedOrder = (from a in OrderItems
                                    where a.IsBouns == false
                                    group a by new { a.ItemId, a.ItemCode } into a
                                    select new
                                    {
                                        OrderQty = a.Sum((SalesOrderDetailListModel a) => a.Quantity),
                                        ItemId = a.Key.ItemId,
                                        ItemCode = a.Key.ItemCode
                                    }).ToList();
                foreach (var item2 in GroupedOrder)
                {
                    int? TotalQtyHistory = ClientHistoyQouta.Where((BOItemQuotaByClientVw a) => a.ItemId == item2.ItemId).Sum((BOItemQuotaByClientVw a) => a.Quantity);
                    BOItemQuota existInItemQuota = ItemQouta.Where((BOItemQuota a) => a.ItemId == item2.ItemId).FirstOrDefault();
                    if (existInItemQuota == null)
                    {
                        continue;
                    }
                    BOClientQuota existInExceptionQuota = ExceptionQouta.Where((BOClientQuota a) => a.ItemId == item2.ItemId).FirstOrDefault();
                    if (existInExceptionQuota != null)
                    {
                        if (existInExceptionQuota.Quantity < item2.OrderQty + TotalQtyHistory)
                        {
                            model.Errors.Add(string.Format(PromotionError.INVALID_QOUTA, item2.ItemCode));
                        }
                    }
                    else if (existInItemQuota.Quantity < item2.OrderQty + TotalQtyHistory)
                    {
                        model.Errors.Add(string.Format(PromotionError.INVALID_QOUTA, item2.ItemCode));
                    }
                }
                if (model.Errors.Count > 0)
                {
                    model.HasError = true;
                }
                decimal? num = ClientModel.CreditLimit - ClientModel.CreditBalance - (decimal?)(decimal)model.NetTotal.Value;
                if ((num.GetValueOrDefault() < default(decimal)) & num.HasValue)
                {
                    model.HasError = true;
                    model.Errors.Add(PromotionError.INVALID_CREDIT);
                }
                IList<BOItem> Items = new Criteria<BOItem>().Add(Expression.Eq("IsActive", false)).Add(Expression.In("ItemId", string.Join(',', ItemStr))).List<BOItem>();
                if (Items != null)
                {
                    foreach (BOItem item3 in Items)
                    {
                        model.Errors.Add(string.Format(PromotionError.INVALID_ITEM, item3.ItemCode));
                    }
                }
                if (model.Errors.Count > 0)
                {
                    model.HasError = true;
                }
                List<int?> BatchIds = (from a in model.SalesOrderDetails
                                       where a.ItemStoreId > 0
                                       select a into x
                                       select x.ItemStoreId).ToList();
                IList<BOItemStoreVw> Batchs = new Criteria<BOItemStoreVw>().Add(Expression.In("ItemStoreId", string.Join(',', BatchIds))).List<BOItemStoreVw>();
                if (Batchs != null)
                {
                    List<BOItemStoreVw> InactiveBatchs = Batchs.Where((BOItemStoreVw a) => a.IsActive == false).ToList();
                    foreach (BOItemStoreVw batch in InactiveBatchs)
                    {
                        model.Errors.Add(string.Format(PromotionError.INVALID_BATCH, batch.ItemCode, batch.BatchNo));
                    }
                }
                if (model.Errors.Count > 0)
                {
                    model.HasError = true;
                }
                List<SalesOrderDetailListModel> newDetails = new List<SalesOrderDetailListModel>();
                foreach (SalesOrderDetailListModel item in model.SalesOrderDetails.ToList())
                {
                    if (item.IsBouns != false)
                    {
                        continue;
                    }
                    BOItemStoreVw batch2 = (from a in Batchs
                                            where a.ItemStoreId > 0
                                            where a.ItemStoreId == item.ItemStoreId
                                            select a).FirstOrDefault();
                    if (batch2 == null || !(batch2.Available < item.Quantity))
                    {
                        continue;
                    }
                    List<BOItemStoreVw> AllBatchs = (from a in new Criteria<BOItemStoreVw>().Add(Expression.Eq("ItemId", item.ItemId)).Add(Expression.Eq("StoreId", model.StoreId)).Add(Expression.Eq("IsActive", true))
                            .Add(Expression.Gt("ExpireDate", DateTime.Now.Date))
                            .List<BOItemStoreVw>()
                                                     orderby a.ExpireDate
                                                     select a).ToList();
                    int? sumOfBatchs = AllBatchs.Sum((BOItemStoreVw a) => a.Available);
                    if (sumOfBatchs < item.Quantity)
                    {
                        model.Errors.Add(string.Format(PromotionError.INVALID_BATCH_QTY, batch2.ItemCode, item.Quantity, sumOfBatchs));
                        continue;
                    }
                    foreach (BOItemStoreVw b in AllBatchs)
                    {
                        if (!(b.Available > 0))
                        {
                            continue;
                        }
                        if (b.Available <= item.Quantity)
                        {
                            SalesOrderDetailListModel existInOrder = newDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b.ItemStoreId).FirstOrDefault();
                            if (existInOrder != null)
                            {
                                int index = newDetails.IndexOf(existInOrder);
                                newDetails[index].Quantity += b.Available;
                                newDetails[index].LineValue += (double)Math.Round((decimal)b.Available.Value * b.ClientPrice.Value, 3);
                            }
                            else
                            {
                                newDetails.Add(new SalesOrderDetailListModel
                                {
                                    Quantity = b.Available,
                                    Batch = b.BatchNo,
                                    ClientPrice = (double?)b.ClientPrice,
                                    DetailId = new Random().Next(1111111, 9999999),
                                    Discount = 0.0,
                                    Expiration = b.ExpireDate,
                                    Id = string.Empty,
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
                                    LineValue = (double)Math.Round((decimal)b.Available.Value * b.ClientPrice.Value, 3),
                                    UnitId = b.UnitId,
                                    CustomDiscount = 0.0,
                                    CashDiscount = 0.0,
                                    TaxValue = ((b.IsTaxable == true) ? Math.Round((double)b.ClientPrice.Value * 0.14, 3) : 0.0),
                                    VendorName = ((lan == "ar") ? b.VendorNameAr : b.VendorNameEn),
                                    ItemName = ((lan == "ar") ? b.ItemNameAr : b.ItemNameEn)
                                });
                            }
                            item.Quantity -= b.Available.Value;
                            continue;
                        }
                        SalesOrderDetailListModel existInOrder2 = newDetails.Where((SalesOrderDetailListModel a) => a.ItemStoreId == b.ItemStoreId).FirstOrDefault();
                        if (existInOrder2 != null)
                        {
                            int index2 = newDetails.IndexOf(existInOrder2);
                            newDetails[index2].Quantity += item.Quantity;
                            newDetails[index2].LineValue += (double)Math.Round((decimal)item.Quantity.Value * b.ClientPrice.Value, 3);
                        }
                        else
                        {
                            newDetails.Add(new SalesOrderDetailListModel
                            {
                                Quantity = item.Quantity,
                                Batch = b.BatchNo,
                                ClientPrice = (double?)b.ClientPrice,
                                DetailId = new Random().Next(1111111, 9999999),
                                Discount = 0.0,
                                Expiration = b.ExpireDate,
                                Id = string.Empty,
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
                                LineValue = (double)Math.Round((decimal)item.Quantity.Value * b.ClientPrice.Value, 3),
                                UnitId = b.UnitId,
                                CustomDiscount = 0.0,
                                CashDiscount = 0.0,
                                TaxValue = ((b.IsTaxable == true) ? Math.Round((double)b.ClientPrice.Value * 0.14, 3) : 0.0),
                                VendorName = ((lan == "ar") ? b.VendorNameAr : b.VendorNameEn),
                                ItemName = ((lan == "ar") ? b.ItemNameAr : b.ItemNameEn)
                            });
                        }
                        item.Quantity = 0;
                        break;
                    }
                }
                model.SalesOrderDetails = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.Quantity > 0).ToList();
                model.SalesOrderDetails.AddRange(newDetails);
                model.SalesOrderDetails = model.SalesOrderDetails.OrderByDescending((SalesOrderDetailListModel a) => a.ItemId).ToList();
                if (model.Errors.Count > 0)
                {
                    model.HasError = true;
                }
                BOAppSetting min_Order = new Criteria<BOAppSetting>().Add(Expression.Eq("SettingCode", "ORDER.MIN")).FirstOrDefault<BOAppSetting>();
                if (min_Order != null && model.ItemTotal < double.Parse(min_Order.SettingValue))
                {
                    model.HasError = true;
                    model.Errors.Add(string.Format(PromotionError.INVALID_ORDER_TOTAL, min_Order.SettingValue));
                }
            }
            catch (Exception)
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_VALIDATION);
            }
            return model;
        }

    }



  




}
