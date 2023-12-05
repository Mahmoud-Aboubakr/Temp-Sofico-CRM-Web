using Dapper;
using SofiForce.BusinessObjects;
using SofiForce.Web.Common;
using SofiForce.Web.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SofiForce.Web.Services
{
    public interface IPromotionService
    {
        public void RebuildPromotionItem(int PromotionId);

    }

    public class PromotionService : IPromotionService
    {
        public DapperContext Context { get; }

        public PromotionService(DapperContext context)
        {
            Context = context;
        }


        public void RebuildPromotionItem(int PromotionId)
        {
            try
            {
                #region old

                //var promotion = new Criteria<BOPromotion>()
                //    .Add(Expression.Eq(nameof(BOPromotion.PromotionId), PromotionId))
                //    .FirstOrDefault<BOPromotion>();


                //promotion.DeleteAllPromotionItem();



                //// update promotion items

                //var items = new Criteria<BOPromotionCriteria>()
                //    .Add(Expression.Eq(nameof(BOPromotionCriteria.PromotionId), PromotionId))
                //    .List<BOPromotionCriteria>();

                //foreach (var item in items)
                //{

                //    List<string> ItemCodes = new List<string>();


                //    if (item.IsActive == true && item.Excluded==false)
                //    {

                //        var attr = new BOPromotionCriteriaAttr(item.AttributeId.Value);
                //        if (attr != null)
                //        {
                //            if (attr.IsCustom == false)
                //            {
                //                switch (attr.AttributeCode)
                //                {
                //                    case "VendorCode":

                //                        var lst1 = new Criteria<BOItemVw>()
                //                                    .Add(Expression.Eq(nameof(BOItemVw.VendorCode), item.ValueFrom))
                //                                    .List<BOItemVw>();

                //                        if (lst1 != null)
                //                        {
                //                            foreach (var code in lst1)
                //                            {
                //                                ItemCodes.Add(code.ItemCode);
                //                            }
                //                        }

                //                        break;
                //                    case "ItemCode":

                //                        ItemCodes.Add(item.ValueFrom);

                //                        break;
                //                    case "ItemGroup":
                //                        var lst3 = new Criteria<BOItemVw>()
                //                                  .Add(Expression.Eq(nameof(BOItemVw.ItemGroupCode), item.ValueFrom))
                //                                  .List<BOItemVw>();

                //                        if (lst3 != null)
                //                        {
                //                            foreach (var code in lst3)
                //                            {
                //                                ItemCodes.Add(code.ItemCode);
                //                            }
                //                        }
                //                        break;
                //                    case "TaxGroup":
                //                        var lst4 = new Criteria<BOItemVw>()
                //                                  .Add(Expression.Eq(nameof(BOItemVw.IsTaxable), true))
                //                                  .List<BOItemVw>();

                //                        if (lst4 != null)
                //                        {
                //                            foreach (var code in lst4)
                //                            {
                //                                ItemCodes.Add(code.ItemCode);
                //                            }
                //                        }
                //                        break;
                //                    default:
                //                        break;
                //                }
                //            }
                //            else
                //            {

                //                var customList = new Criteria<BOPromotionCriteriaAttrCustom>()
                //                    .Add(Expression.Eq(nameof(BOPromotionCriteriaAttrCustom.AttributeId), attr.AttributeId))
                //                    .List<BOPromotionCriteriaAttrCustom>();



                //                if (customList != null)
                //                {
                //                    foreach (var c in customList)
                //                    {
                //                        ItemCodes.Add(c.ValueFrom);
                //                    }
                //                }
                //            }
                //        }


                //    }

                //    if (ItemCodes.Count > 0)
                //    {
                //        using (var connection = Context.CreateConnection())
                //        {


                //            ItemCodes = ItemCodes
                //                    .GroupBy(word => word)
                //                    .Select(group => group.Key)
                //                    .ToList();

                //            var chunks = ItemCodes.ChunkBy(25);

                //            foreach (var chk in chunks)
                //            {
                //                // get target kbi
                //                var param = new
                //                {
                //                    @PromotionId = PromotionId,
                //                    @ItemCode = string.Join(',', chk),
                //                    @GroupId= item.GroupId>0?item.GroupId:null
                //                };

                //                connection.Execute("insert into PromotionItem(PromotionId,ItemCode,GroupId) select @PromotionId,tuple,@GroupId from dbo.splitString(@ItemCode)", param);
                //                connection.Execute("exec Batch_PromotionDuplicate");

                //            }

                //        }
                //    }


                //}
                #endregion


                using (var connection = Context.CreateConnection())
                {
                    var param = new
                    {
                        @PromotionId = PromotionId,

                    };
                    connection.Execute("Batch_Promotion_activate", param, commandType: System.Data.CommandType.StoredProcedure);


                }

            }
            catch
            {

            }
        }


    }

}
