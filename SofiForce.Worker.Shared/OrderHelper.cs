using SofiForce.BusinessObjects;

namespace SofiForce.Worker.Shared
{
    public class OrderHelper
    {

        public static List<string> ValidateOrder(long SalesId)
        {

            List<string> Errors = new List<string>();

            try
            {



                //var model = new BOSalesOrder(SalesId);

                //// validate Order Detail
                //if (model == null)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_MODEL);

                //    return Errors;
                //}

                //// validate Order Detail
                //var modelDetail = new Criteria<BOSalesOrderDetailVw>()
                //        .Add(Expression.Eq(nameof(BOSalesOrderDetailVw.SalesId), model.SalesId))
                //        .List<BOSalesOrderDetailVw>();

                //if (modelDetail == null || modelDetail.Count == 0)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_ITEMS);

                //    return Errors;
                //}
                //if (modelDetail.Where(a => a.Quantity == 0).ToList().Count > 0)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_ITEMS);
                //    return Errors;

                //}
                //var expired = modelDetail.Where(x => x.Expiration < DateTime.Now.Date).ToList();
                //if (expired.Count > 0)
                //{
                //    foreach (var x in expired)
                //    {
                //        Errors.Add(String.Format(PromotionError.ITEM_EXPIRED, x.ItemCode));
                //    }
                //    return Errors;
                //}

                //// validate Client
                //if (model.ClientId == null || model.ClientId == 0)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_MODEL);

                //    return Errors;
                //}

                //var ClientModel = new Criteria<BOClient>()
                //        .Add(Expression.Eq(nameof(BOClient.ClientId), model.ClientId))
                //        .FirstOrDefault<BOClient>();

                //if (ClientModel == null)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_CLIENT);
                //    return Errors;
                //}

                //if (ClientModel.IsActive != true)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INACTVE_CLIENT);
                //    return Errors;
                //}




                //// validate SalesMan
                //if (model.RepresentativeId == null || model.RepresentativeId == 0)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_MODEL);

                //    return Errors;
                //}

                //var RepresentativeModel = new Criteria<BORepresentative>()
                //              .Add(Expression.Eq(nameof(BORepresentative.RepresentativeId), model.RepresentativeId))
                //              .FirstOrDefault<BORepresentative>();


                //if (RepresentativeModel == null)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_MODEL);

                //    return Errors;
                //}

                //if (RepresentativeModel.IsActive != true)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INACTVE_REP);

                //    return Errors;
                //}






                //// validate Branch
                //if (model.BranchId == null || model.BranchId == 0)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_MODEL);

                //    return Errors;
                //}

                //var BranchModel = new Criteria<BOBranch>()
                //   .Add(Expression.Eq(nameof(BOBranch.BranchId), model.BranchId))
                //   .FirstOrDefault<BOBranch>();


                //if (BranchModel == null)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_MODEL);

                //    return Errors;
                //}

                //if (BranchModel.IsActive != true)
                //{
                //    model.HasError = true;
                //    Errors.Add(String.Format(PromotionError.INACTVE_BRANCH, BranchModel.BranchCode));

                //    return Errors;
                //}






                //// validate Warehouse
                //if (model.StoreId == null || model.StoreId == 0)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_MODEL);
                //    return Errors;
                //}

                //var StoreModel = new Criteria<BOStore>()
                //    .Add(Expression.Eq(nameof(BOStore.StoreId), model.StoreId))
                //    .FirstOrDefault<BOStore>();


                //if (StoreModel == null)
                //{
                //    model.HasError = true;
                //    Errors.Add(PromotionError.INVALID_MODEL);
                //    return Errors;
                //}

                //if (StoreModel.IsActive != true)
                //{
                //    model.HasError = true;
                //    Errors.Add(String.Format(PromotionError.INACTVE_WAREHOUSE, StoreModel.StoreCode));
                //    return Errors;
                //}



                //// validate Client Item Quota

                //var ItemStr = modelDetail.Select(x => x.ItemId).ToList();

                //var ClientHistoyQouta = new Criteria<BOItemQuotaByClientVw>()
                //                    .Add(Expression.Eq(nameof(BOItemQuotaByClientVw.ClientId), model.ClientId))
                //                    .Add(Expression.Gte(nameof(BOItemQuotaByClientVw.SalesDate), model.SalesTime.Value.FirstDayOfMonth()))
                //                    .Add(Expression.In(nameof(BOItemQuotaByClientVw.ItemId), string.Join(',', ItemStr)))
                //                    .List<BOItemQuotaByClientVw>();

                //var ItemQouta = new Criteria<BOItemQuota>()
                //    .Add(Expression.In(nameof(BOItemQuota.ItemId), string.Join(',', ItemStr)))
                //    .List<BOItemQuota>();

                //var ExceptionQouta = new Criteria<BOClientQuota>()
                //  .Add(Expression.In(nameof(BOClientQuota.ItemId), string.Join(',', ItemStr)))
                //  .Add(Expression.Eq(nameof(BOClientQuota.ClientId), model.ClientId))
                //  .List<BOClientQuota>();

                //var OrderItems = modelDetail.Where(a => a.IsBouns == false).ToList();

                //if (ExceptionQouta == null) ExceptionQouta = new List<BOClientQuota>();
                //if (ClientHistoyQouta == null) ClientHistoyQouta = new List<BOItemQuotaByClientVw>();
                //if (ItemQouta == null) ItemQouta = new List<BOItemQuota>();

                //var GroupedOrder = OrderItems.Where(a => a.IsBouns == false)
                //    .GroupBy(a => new { a.ItemId, a.ItemCode })
                //    .Select(a => new { OrderQty = a.Sum(a => a.Quantity), ItemId = a.Key.ItemId, ItemCode = a.Key.ItemCode })
                //    .ToList();

                //foreach (var item in GroupedOrder)
                //{
                //    var TotalQtyHistory = ClientHistoyQouta.Where(a => a.ItemId == item.ItemId).Sum(a => a.Quantity);

                //    var existInItemQuota = ItemQouta.Where(a => a.ItemId == item.ItemId).FirstOrDefault();
                //    if (existInItemQuota != null)
                //    {
                //        var existInExceptionQuota = ExceptionQouta.Where(a => a.ItemId == item.ItemId).FirstOrDefault();
                //        if (existInExceptionQuota != null)
                //        {
                //            if (existInExceptionQuota.Quantity < item.OrderQty + TotalQtyHistory)
                //            {
                //                Errors.Add(String.Format(PromotionError.INVALID_QOUTA, item.ItemCode));
                //                return Errors;
                //            }
                //        }
                //        else
                //        {
                //            if (existInItemQuota.Quantity < item.OrderQty + TotalQtyHistory)
                //            {
                //                Errors.Add(String.Format(PromotionError.INVALID_QOUTA, item.ItemCode));
                //                return Errors;
                //            }
                //        }
                //    }
                //}


                //// validate Client Credit Limit

                //if (((ClientModel.CreditLimit - ClientModel.CreditBalance) - (decimal)model.NetTotal) < 0)
                //{
                //    Errors.Add(PromotionError.INVALID_CREDIT);
                //    return Errors;
                //}



                //// Validate Item Is Active
                //var Items = new Criteria<BOItem>()
                //    .Add(Expression.Eq(nameof(BOItem.IsActive), false))
                //    .Add(Expression.In(nameof(BOItem.ItemId), string.Join(',', ItemStr)))
                //    .List<BOItem>();

                //if (Items != null)
                //{
                //    foreach (var item in Items)
                //    {
                //        Errors.Add(String.Format(PromotionError.INVALID_ITEM, item.ItemCode));


                //    }
                //    return Errors;
                //}


                //// Validate Batch Is Active

                //var BatchIds = modelDetail.Where(a => a.ItemStoreId > 0).Select(x => x.ItemStoreId).ToList();

                //var Batchs = new Criteria<BOItemStoreVw>()
                //           .Add(Expression.In(nameof(BOItemStoreVw.ItemStoreId), string.Join(',', BatchIds)))
                //           .List<BOItemStoreVw>();

                //if (Batchs != null)
                //{
                //    var InactiveBatchs = Batchs.Where(a => a.IsActive == false).ToList();
                //    foreach (var batch in InactiveBatchs)
                //    {
                //        Errors.Add(String.Format(PromotionError.INVALID_BATCH, batch.ItemCode, batch.BatchNo));
                //    }
                //    return Errors;
                //}



               
                return Errors;
            }
            catch (Exception)
            {
                Errors.Add(String.Format(PromotionError.SYSTEM_ERROR));
                return Errors;
            }

        }
    }
}