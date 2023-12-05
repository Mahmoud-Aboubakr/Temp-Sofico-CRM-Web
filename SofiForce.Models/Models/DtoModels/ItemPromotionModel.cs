using System.Collections.Generic;

namespace Models
{
    public class ItemPromotionModel
    {
        public int ItemId { get; set; }
        public int VendorId { get; set; }
        public bool IsHot { get; set; }
        public bool IsPublic { get; set; }

        public string ItemCode { get; set; }=string.Empty;
        public string ItemName { get; set; }=string.Empty;
        public string VendorCode { get; set; }=string.Empty;
        public string VendorName { get; set; }=string.Empty;


        public double? ClientPrice { get; set; }
        public double? Discount { get; set; }
        public bool? IsActive { get; set; }
        public double? PublicPrice { get; set; }
        public bool? HasPromotion { get; set; }
        public bool? IsNewAdded { get; set; }
        public bool? IsNewStocked { get; set; }
        public bool? IsTaxable { get; set; }

        
                                                
                                                
                                                


        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public int? PromotionId { get; set; }
        public string PromotionCode { get; set; }

        public int InputId { get; set; }
        public int OutputId { get; set; }


        public List<ItemPromotionCritiraModel> Items { get; set; } = new List<ItemPromotionCritiraModel>();
        public List<ItemPromotionOutComeModel> Outcomes { get; set; } = new List<ItemPromotionOutComeModel>();
        public List<ItemPromotionClientModel> Clients { get; set; } = new List<ItemPromotionClientModel>();
        public List<ItemPromotionSalesManModel> SalesMans { get; set; } = new List<ItemPromotionSalesManModel>();

    }

    public class ItemPromotionCritiraModel
    {
        public long PromotionItemId { get; set; }
        public int PromotionId { get; set; }
        public string ItemCode { get; set; }
        public int ItemId { get; set; }

        public string ItemName { get; set; }
        public decimal? GroupValue { get; set; }
    }

    public class ItemPromotionOutComeModel
    {

        public int OutcomeId { get; set; }
        public int? PromotionId { get; set; }
        public int ItemId { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal? Slice { get; set; }
        public decimal? Value { get; set; }
    }

    public class ItemPromotionClientModel
    {

        public long PromotionClientId { get; set; }
        public int? PromotionId { get; set; }
        public string ClientCode { get; set; }
    }

    public class ItemPromotionSalesManModel
    {

        public long PromotionSalesManId { get; set; }
        public int? PromotionId { get; set; }
        public string SalesManCode { get; set; }
        public string SalesManName { get; set; }
    }

}