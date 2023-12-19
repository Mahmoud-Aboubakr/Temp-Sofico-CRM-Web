using Models;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Common.PromotionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Promotion.Helpers
{
    public static class PromotionHelper
    {

        public static string fmt = "yyyy-MM-dd";
        public static Func<object, string> dateformatter = (x => ((DateTime)x).ToString(fmt));


        public static async Task<List<OrderPromotionFinal>> getOrderPromotions(SalesOrderModelWeb model)
        {
            var result = new List<OrderPromotion>();
            var Final = new List<OrderPromotionFinal>();
            try
            {
                var OrderCodes= model.SalesOrderDetails.Where(a=>a.ItemId>0).Where(a=>a.IsBouns==false).GroupBy(a=>a.ItemCode).Select(a=>a.Key).ToList();
                foreach (var ItemCode in OrderCodes)
                {
                    if (!string.IsNullOrEmpty(ItemCode))
                    {



                        var res = new Criteria<BOPromotionItemVw>()
                                                   .Add(Expression.Eq(nameof(BOPromotionItemVw.ItemCode), ItemCode))
                                                   .Add(Expression.In(nameof(BOPromotionItemVw.PromotionCategoryId), "1,2"))
                                                   .Add(Expression.Lte(nameof(BOPromotionItemVw.ValidFrom), model.SalesDate, dateformatter))
                                                   .Add(Expression.Gte(nameof(BOPromotionItemVw.ValidTo), model.SalesDate, dateformatter))
                                                   .Add(Expression.Eq(nameof(BOPromotionItemVw.IsActive), true))
                                                   .Add(Expression.Eq(nameof(BOPromotionItemVw.IsApproved), true))
                                                   .List<BOPromotionItemVw>()
                                                   .Select(a => new OrderPromotion()
                                                   {

                                                       Priority = a.Priority > 0 ? a.Priority.Value : 0,
                                                       PromotionId = a.PromotionId.Value,
                                                       PromotionTypeId = a.PromotionTypeId.Value,
                                                       PromotionCategoryId = a.PromotionCategoryId.Value,
                                                       ItemCode = a.ItemCode,
                                                       RepeatTypeId = a.RepeatTypeId != null ? a.RepeatTypeId.Value : 1,
                                                       Repeats = a.Repeats != null && a.Repeats > 0 ? a.Repeats.Value : int.MaxValue,
                                                       VendorCode = a.VendorCode,
                                                       FromDate = a.ValidFrom.Value

                                                   }).ToList();

                        var promotions = res.OrderByDescending(a => a.PromotionCategoryId);
                        foreach (var promotion in promotions)
                        {

                            var IsAllowedClient =await PromotionHelper.IsAllowedClient(model.ClientCode, promotion.PromotionId);
                            var IsAllowedSalesMan = await PromotionHelper.IsAllowedSalesMan(model.RepresentativeId, promotion.PromotionId);
                            var IsAllowedRepeats = await  PromotionHelper.IsAllowedRepeats(promotion.RepeatTypeId, model.ClientId, promotion.PromotionId, promotion.Repeats);

                            if (IsAllowedClient == true && IsAllowedSalesMan == true && IsAllowedRepeats == true)
                            {
                                var exist = result
                                    .Where(a => a.ItemCode == promotion.ItemCode)
                                    .ToList();
                                if (exist.Count == 0)
                                {
                                    result.Add(promotion);
                                }
                                else
                                {
                                    var existWithType = exist.OrderByDescending(a => a.FromDate).Where(a => a.PromotionTypeId == promotion.PromotionTypeId).FirstOrDefault();

                                    if (existWithType == null)
                                    {
                                        result.Add(promotion);
                                    }
                                    else
                                    {
                                        if (promotion.PromotionCategoryId == 2)
                                        {
                                            if (existWithType.Priority != promotion.Priority)
                                            {
                                                result.Add(promotion);
                                            }
                                        }

                                    }
                                    existWithType = null;

                                }

                                exist = null;
                            }

                        }

                        promotions = null;

                    }
                }


                Final = result.OrderByDescending(a => a.Priority).GroupBy(a => new { a.PromotionId, a.VendorCode, a.Priority }).Select(a => new OrderPromotionFinal() { PromotionId = a.Key.PromotionId, VendorCode = a.Key.VendorCode, Priority = a.Key.Priority }).ToList();

                if (model.SalesId > 0)
                {

                    if (result.Count > 0)
                    {
                        var order = new BOSalesOrder((long)model.SalesId.Value);
                        order.DeleteAllSalesOrderPromotion();
                        // save promotion to db

                        foreach (var Id in Final)
                        {
                            var bo = new BOSalesOrderPromotion();
                            bo.SalesId = order.SalesId;
                            bo.PromotionId = Id.PromotionId;

                            bo.SaveNew();
                        }
                    }


                }

                result = null;
                OrderCodes = null;

            }
            finally
            {
                

            }

            return Final;



        }




        public static Task<bool> IsAllowedClient(string ClientCode, int PromotionId)
        {
            bool isAllowed = false;


            try
            {


                List<ClientPromotionDTO> ClientCodes = new List<ClientPromotionDTO>();

                // update promotion items

                var clients = new Criteria<BOPromtionCriteriaClient>()
                    .Add(Expression.Eq(nameof(BOPromtionCriteriaClient.PromotionId), PromotionId))
                    .List<BOPromtionCriteriaClient>();



                foreach (var client in clients)
                {
                    if (client.IsActive == true)
                    {

                        var attr = new BOPromtionCriteriaClientAttr(client.ClientAttributeId.Value);
                        if (attr != null)
                        {
                            if (attr.IsCustom == false)
                            {
                                switch (attr.ClientAttributeCode)
                                {

                                    case "ClientCode":

                                        var c = new Criteria<BOClientVw>()
                                                    .Add(Expression.Eq(nameof(BOClientVw.ClientCode), client.ValueFrom))
                                                    .FirstOrDefault<BOClientVw>();

                                        if (c != null)
                                        {
                                            ClientCodes.Add(new ClientPromotionDTO() { ClientCode=c.ClientCode, IsIncluded = !client.Excluded.Value});
                                        }
                                        break;
                                    case "BranchCode":


                                        var lst1 = new Criteria<BOClientVw>()
                                                    .Add(Expression.Eq(nameof(BOClientVw.BranchCode), client.ValueFrom))
                                                    .Add(Expression.Eq(nameof(BOClientVw.ClientCode), ClientCode))
                                                    .List<BOClientVw>();

                                        if (lst1 != null)
                                        {
                                            foreach (var code in lst1)
                                            {

                                                ClientCodes.Add(new ClientPromotionDTO() { ClientCode = code.ClientCode, IsIncluded = !client.Excluded.Value });

                                            }
                                        }

                                        lst1 = null;

                                        break;

                                    case "ClientType":


                                        var lst2 = new Criteria<BOClientVw>()
                                                    .Add(Expression.Eq(nameof(BOClientVw.ClientTypeId), client.ValueFrom))
                                                    .Add(Expression.Eq(nameof(BOClientVw.ClientCode), ClientCode))
                                                    .List<BOClientVw>();

                                        if (lst2 != null)
                                        {
                                            foreach (var code in lst2)
                                            {
                                                ClientCodes.Add(new ClientPromotionDTO() { ClientCode = code.ClientCode, IsIncluded = !client.Excluded.Value });

                                            }
                                        }
                                        lst2 = null;
                                        break;
                                    case "PaymentTerm":


                                        var lst3 = new Criteria<BOClientVw>()
                                                    .Add(Expression.Eq(nameof(BOClientVw.PaymentTermId), client.ValueFrom))
                                                    .Add(Expression.Eq(nameof(BOClientVw.ClientCode), ClientCode))
                                                    .List<BOClientVw>();

                                        if (lst3 != null)
                                        {
                                            foreach (var code in lst3)
                                            {
                                                ClientCodes.Add(new ClientPromotionDTO() { ClientCode = code.ClientCode, IsIncluded = !client.Excluded.Value });
                                            }
                                        }
                                        lst3 = null;
                                        break;

                                    case "Governerate":


                                        double ValueFrom5 = 0;

                                        double.TryParse(client.ValueFrom, out ValueFrom5);


                                        var lst5 = new Criteria<BOClientVw>()
                                                    .Add(Expression.Eq(nameof(BOClientVw.GovernerateId), ValueFrom5))
                                                    .Add(Expression.Eq(nameof(BOClientVw.ClientCode), ClientCode))
                                                    .List<BOClientVw>();

                                        if (lst5 != null)
                                        {
                                            foreach (var code in lst5)
                                            {
                                                ClientCodes.Add(new ClientPromotionDTO() { ClientCode = code.ClientCode, IsIncluded = !client.Excluded.Value });
                                            }
                                        }
                                        lst5 = null;
                                        break;
                                    case "City":



                                        double ValueFrom6 = 0;

                                        double.TryParse(client.ValueFrom, out ValueFrom6);

                                        var lst6 = new Criteria<BOClientVw>()
                                                    .Add(Expression.Eq(nameof(BOClientVw.CityId), ValueFrom6))
                                                    .Add(Expression.Eq(nameof(BOClientVw.ClientCode), ClientCode))
                                                    .List<BOClientVw>();

                                        if (lst6 != null)
                                        {
                                            foreach (var code in lst6)
                                            {
                                                ClientCodes.Add(new ClientPromotionDTO() { ClientCode = code.ClientCode, IsIncluded = !client.Excluded.Value });
                                            }
                                        }
                                        lst6 = null;
                                        break;
                                    case "LocationLevel":

                                        double ValueFrom7 = 0;

                                        double.TryParse(client.ValueFrom, out ValueFrom7);

                                        var lst7 = new Criteria<BOClientVw>()
                                                    .Add(Expression.Eq(nameof(BOClientVw.LocationLevelId), ValueFrom7))
                                                    .Add(Expression.Eq(nameof(BOClientVw.ClientCode), ClientCode))
                                                    .List<BOClientVw>();

                                        if (lst7 != null)
                                        {
                                            foreach (var code in lst7)
                                            {
                                                ClientCodes.Add(new ClientPromotionDTO() { ClientCode = code.ClientCode, IsIncluded = !client.Excluded.Value });
                                            }
                                        }
                                        lst7 = null;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {

                                var customList = new Criteria<BOPromtionCriteriaClientAttrCustom>()
                                    .Add(Expression.Eq(nameof(BOPromtionCriteriaClientAttrCustom.ClientAttributeId), attr.ClientAttributeId))
                                    .List<BOPromtionCriteriaClientAttrCustom>();



                                if (customList != null)
                                {
                                    foreach (var c in customList)
                                    {
                                        ClientCodes.Add(new ClientPromotionDTO() { ClientCode = c.ValueFrom, IsIncluded = !client.Excluded.Value });

                                    }
                                }
                                customList = null;
                            }
                        }


                    }
                }

                if (ClientCodes.Count == 0)
                {
                    isAllowed = true;
                }
                else
                {
                    var AllowedCount = ClientCodes.Where(a => a.IsIncluded == true).ToList().Count();

                    if(AllowedCount > 0)
                    {
                        var exist = ClientCodes.Where(a => a.IsIncluded == true).Where(a => a.ClientCode == ClientCode).FirstOrDefault();
                        if (exist != null)
                        {
                            isAllowed = true;
                        }
                    }
                    else
                    {
                        var exist = ClientCodes.Where(a => a.ClientCode == ClientCode).FirstOrDefault();
                        if(exist != null)
                        {
                            isAllowed = exist.IsIncluded;
                        }
                        else
                        {
                            isAllowed = true;
                        }
                    }



                }

                clients = null;
                ClientCodes = null;


            }
            catch { }


            return Task.FromResult(isAllowed);


        }

        public static Task<bool> IsAllowedCashItem(string ItemCode, int PromotionId)
        {
            bool isAllowed = false;


            try
            {


                List<ItemPromotionDTO> ItemCodes = new List<ItemPromotionDTO>();

                // update promotion items

                var items = new Criteria<BOPromotionCriteria>()
                    .Add(Expression.Eq(nameof(BOPromotionCriteria.PromotionId), PromotionId))
                    .List<BOPromotionCriteria>();



                foreach (var item in items)
                {
                    if (item.IsActive == true)
                    {

                        var attr = new BOPromotionCriteriaAttr(item.AttributeId.Value);
                        if (attr != null)
                        {
                            if (attr.IsCustom == false)
                            {
                                switch (attr.AttributeCode)
                                {

                                    case "ItemCode":

                                        ItemCodes.Add(new ItemPromotionDTO() {ItemCode= item.ValueFrom,PromotionId=PromotionId,IsIncluded=!item.Excluded.Value });
                                        break;
                                    case "VendorCode":


                                        var lst1 = new Criteria<BOItemVw>()
                                                    .Add(Expression.Eq(nameof(BOItemVw.VendorCode), item.ValueFrom))
                                                    .List<BOItemVw>();

                                        if (lst1 != null)
                                        {
                                            foreach (var code in lst1)
                                            {

                                                ItemCodes.Add(new ItemPromotionDTO() { ItemCode = code.ItemCode, PromotionId = PromotionId, IsIncluded = !item.Excluded.Value });

                                            }
                                        }

                                        break;

                                    case "ItemGroup":


                                        var lst2 = new Criteria<BOItemVw>()
                                                    .Add(Expression.Eq(nameof(BOItemVw.ItemGroupCode), item.ValueFrom))
                                                    .List<BOItemVw>();

                                        if (lst2 != null)
                                        {
                                            foreach (var code in lst2)
                                            {
                                                ItemCodes.Add(new ItemPromotionDTO() { ItemCode = code.ItemCode, PromotionId = PromotionId, IsIncluded = !item.Excluded.Value });

                                            }
                                        }

                                        break;

                                    default:
                                        break;
                                }
                            }
                            else
                            {

                                var customList = new Criteria<BOPromotionCriteriaAttrCustom>()
                                    .Add(Expression.Eq(nameof(BOPromotionCriteriaAttrCustom.AttributeId), attr.AttributeId))
                                    .List<BOPromotionCriteriaAttrCustom>();



                                if (customList != null)
                                {
                                    foreach (var c in customList)
                                    {

                                        ItemCodes.Add(new ItemPromotionDTO() { ItemCode = c.ValueFrom, PromotionId = PromotionId, IsIncluded = !item.Excluded.Value });


                                    }
                                }
                            }
                        }


                    }
                }



                if (ItemCodes.Count == 0)
                {
                    isAllowed = true;
                }
                else
                {
                    var AllowedCount = ItemCodes.Where(a => a.IsIncluded == true).ToList().Count();

                    if (AllowedCount > 0)
                    {
                        var exist = ItemCodes.Where(a => a.IsIncluded == true).Where(a => a.ItemCode == ItemCode).FirstOrDefault();
                        if (exist != null)
                        {
                            isAllowed = true;
                        }
                    }
                    else
                    {
                        var exist = ItemCodes.Where(a => a.ItemCode == ItemCode).FirstOrDefault();
                        if (exist != null)
                        {
                            isAllowed = exist.IsIncluded;
                        }
                        else
                        {
                            isAllowed = true;
                        }
                    }

                }


                ItemCodes = null;
                items = null;

            }
            catch { }
            return Task.FromResult(isAllowed);



        }

        public static Task<bool> IsAllowedSalesMan(int? RepresentativeId, int PromotionId)
        {
            bool isAllowed = false;


            try
            {

                var rep = new BORepresentative(RepresentativeId.Value);

                Dictionary<string,bool> SalesManCodes = new Dictionary<string,bool>();

                // update promotion items

                var salesMans = new Criteria<BOPromtionCriteriaSalesMan>().Add(Expression.Eq(nameof(BOPromtionCriteriaSalesMan.PromotionId), PromotionId)).List<BOPromtionCriteriaSalesMan>();
                foreach (var salesMan in salesMans)
                {
                    if (salesMan.IsActive == true)
                    {

                        var attr = new BOPromtionCriteriaSalesManAttr(salesMan.SalesManAttributeId.Value);
                        if (attr != null)
                        {
                            if (attr.IsCustom == false)
                            {
                                switch (attr.SalesManAttributeCode)
                                {

                                    case "SalesManCode":

                                        var exit1 = SalesManCodes.Where(a => a.Key==salesMan.ValueFrom).FirstOrDefault();
                                        if (string.IsNullOrEmpty(exit1.Key))
                                        {
                                            SalesManCodes.Add(salesMan.ValueFrom,salesMan.Excluded!=null?salesMan.Excluded.Value:false);
                                        }
                                        

                                        break;
                                    case "BranchCode":


                                        var lst1 = new Criteria<BORepresentativeVw>()
                                                    .Add(Expression.Eq(nameof(BORepresentativeVw.BranchCode), salesMan.ValueFrom))
                                                    .Add(Expression.In(nameof(BORepresentativeVw.KindId), "1,2"))
                                                    .List<BORepresentativeVw>();

                                        if (lst1 != null)
                                        {
                                            foreach (var code in lst1)
                                            {
                                                var exit = SalesManCodes.Where(a => a.Equals(code.RepresentativeCode)).FirstOrDefault();
                                                if ((string.IsNullOrEmpty(exit.Key)))
                                                {
                                                    SalesManCodes.Add(code.RepresentativeCode, salesMan.Excluded != null ? salesMan.Excluded.Value : false);
                                                }
                                                
                                                
                                            }
                                        }

                                        lst1 = null;

                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {

                                var customList = new Criteria<BOPromtionCriteriaSalesManAttrCustom>()
                                    .Add(Expression.Eq(nameof(BOPromtionCriteriaSalesManAttrCustom.SalesManAttributeId), attr.SalesManAttributeId))
                                    .List<BOPromtionCriteriaSalesManAttrCustom>();



                                if (customList != null)
                                {
                                    foreach (var c in customList)
                                    {

                                        var exit = SalesManCodes.Where(a => a.Equals(c.ValueFrom)).FirstOrDefault();
                                        if ((string.IsNullOrEmpty(exit.Key)))
                                        {
                                            SalesManCodes.Add(c.ValueFrom, salesMan.Excluded != null ? salesMan.Excluded.Value : false);
                                        }

                                    }
                                }

                                customList = null;
                            }
                        }


                    }
                }


                if (SalesManCodes.Count == 0)
                {
                    isAllowed = true;
                }
                else
                {
                    var allAllowed = SalesManCodes.Where(a => a.Value == false).ToList();

                    if (allAllowed.Count > 0)
                    {
                        var ClientInList = allAllowed.Where(a => a.Key.ToLower() == rep.RepresentativeCode.ToLower()).FirstOrDefault();
                        if (!string.IsNullOrEmpty(ClientInList.Key))
                        {
                            isAllowed = true;
                        }
                        
                    }
                    else
                    {
                        var allExecluded = SalesManCodes.Where(a => a.Value == true).ToList();
                        var InList = allExecluded.Where(a => a.Key == rep.RepresentativeCode).FirstOrDefault();

                        if (!string.IsNullOrEmpty(InList.Key))
                        {
                            isAllowed = false;
                        }
                        else
                        {
                            isAllowed = false;
                        }
                        allExecluded = null;
                        
                    }

                    allAllowed = null;
                }

                SalesManCodes = null;
                salesMans = null;

            }
            catch
            {

            }
            finally
            {
                
            }

            return Task.FromResult(isAllowed);
        }

        public static Task<bool> IsAllowedRepeats(int? RepeatTypeId,int? ClientId, int? PromotionId,int? maxRepeats)
        {
            bool isAllowed = false;
            //xxxxx
            //var promo = new BOPromotion(PromotionId.Value);

            //if (promo.Repeats == 0)
            //{
            //    isAllowed = true;
            //    return Task.FromResult(isAllowed);
            //}


            int Repeats = 0;
            try
            {


                if (RepeatTypeId == 1)
                {
                    Repeats = new Criteria<BOSalesOrderDetailPromotionVw>()
                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailPromotionVw.PromotionCode), PromotionId))
                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailPromotionVw.ClientId), ClientId))
                                   .Count();
                }
                if (RepeatTypeId == 2)
                {
                    Repeats = new Criteria<BOSalesOrderDetailPromotionVw>()
                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailPromotionVw.PromotionCode), PromotionId))
                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailPromotionVw.ClientId), ClientId))
                                   .Add(Expression.Gt(nameof(BOSalesOrderDetailPromotionVw.SalesDate), DateTime.Now.FirstDayOfYear(), dateformatter))
                                   .Count();
                }
                if (RepeatTypeId == 3)
                {
                    Repeats = new Criteria<BOSalesOrderDetailPromotionVw>()
                               .Add(Expression.Eq(nameof(BOSalesOrderDetailPromotionVw.PromotionCode), PromotionId))
                               .Add(Expression.Eq(nameof(BOSalesOrderDetailPromotionVw.ClientId), ClientId))
                               .Add(Expression.Gt(nameof(BOSalesOrderDetailPromotionVw.SalesDate), DateTime.Now.FirstDayOfMonth(), dateformatter))
                               .Count();
                }
                if (RepeatTypeId == 4)
                {
                    Repeats = new Criteria<BOSalesOrderDetailPromotionVw>()
                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailPromotionVw.PromotionCode), PromotionId))
                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailPromotionVw.ClientId), ClientId))
                                   .Add(Expression.Eq(nameof(BOSalesOrderDetailPromotionVw.SalesDate), DateTime.Now.Date,dateformatter))
                                   .Count();
                }



                if (Repeats < maxRepeats)
                {
                    isAllowed = true;

                }

            }
            catch
            {

            }


            return Task.FromResult(isAllowed);
        }
    }


    class ClientPromotionDTO
    {
        public int PromotionId { get; set; }
        public string ClientCode { get; set; }
        public bool IsIncluded { get; set; }

    }
    class ItemPromotionDTO
    {
        public int PromotionId { get; set; }
        public string ItemCode { get; set; }
        public bool IsIncluded { get; set; }

    }
}
