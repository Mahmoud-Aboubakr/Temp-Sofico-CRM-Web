// SofiForce.Web, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// SofiForce.Promotion.PromotionReturnCalculator
using System;
using System.Linq;
using System.Threading.Tasks;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.Promotion;
using SofiForce.Web.Common.PromotionModels;

public interface IPromotionReturnCalculator
{
    Task<SalesOrderModelWeb> CaluclucateOrder(SalesOrderModelWeb model, string Lan);

    Task<SalesOrderModelWeb> CaluclucateTotals(SalesOrderModelWeb model);

    Task<SalesOrderModelWeb> ValidateValidOrder(SalesOrderModelWeb model, string lan);
}
public class PromotionReturnCalculator : IPromotionReturnCalculator
{
    public static string fmt = "yyyy-MM-dd";

    public static Func<object, string> dateformatter = (object x) => ((DateTime)x).ToString(fmt);

    public async Task<SalesOrderModelWeb> CaluclucateOrder(SalesOrderModelWeb model, string Lan)
    {
        model.SalesOrderDetails = model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.IsBouns == false).ToList();
        SalesOrderModelWeb FinalModel = model;
        try
        {
            FinalModel = await CaluclucateTotals(FinalModel);
            FinalModel.SalesOrderDetails = FinalModel.SalesOrderDetails.OrderBy((SalesOrderDetailListModel a) => a.ItemCode).ToList();
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
            if (model.SalesOrderDetails == null)
            {
                model.HasError = true;
                model.Errors.Add(PromotionError.ERROR_CALCULATION);
                return model;
            }
            model.TaxTotal = -1.0 * Math.Round(model.SalesOrderDetails.Sum((SalesOrderDetailListModel a) => a.TaxValue * (double?)a.Quantity).Value, 3);
            if (!model.TaxTotal.HasValue)
            {
                model.TaxTotal = 0.0;
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
            model.SalesOrderDetails.Where((SalesOrderDetailListModel a) => a.Expiration <= DateTime.Now.Date).ToList();
            if (model.Errors.Count > 0)
            {
                model.HasError = true;
                model.Errors.Add(string.Format(PromotionError.ITEM_EXPIRED, StoreModel.StoreCode));
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
