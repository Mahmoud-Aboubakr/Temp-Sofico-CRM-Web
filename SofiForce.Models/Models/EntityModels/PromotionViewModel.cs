using System;

namespace Models
{
    public class PromotionViewModel
    {


        public string ConditionTypeID { get; set; }

        public int PromotionInput { get; set; }
        public int PromotionOutput { get; set; }

        public string PromotionInputName { get; set; }
        public string PromotionOutputName { get; set; }

        public string Description { get; set; }
        public int? PromotionCategoryId { get; set; }
        public string Prioritycode { get; set; }
        public Int32? Priorityvalue { get; set; }
        public string Promotionid { get; set; }
        public bool Promotionorderstatus { get; set; }
        public Int32? RepeatsNo { get; set; }
        public DateTime? Validfrom { get; set; }
        public DateTime? Validto { get; set; }


        public List<PromotionItemCritriaViewModel> PromotionItemCritria { get; set; } = new List<PromotionItemCritriaViewModel>();
        public List<PromotionMixAndMatchGroupViewModel> PromotionMixAndMatchGroup { get; set; } = new List<PromotionMixAndMatchGroupViewModel>();
        public List<PromotionOutcomeViewModel> PromotionOutcome { get; set; } = new List<PromotionOutcomeViewModel>();
        public List<PromotionClientViewModel> PromotionClient { get; set; } = new List<PromotionClientViewModel>();
        public List<PromotionHistoryViewModel> PromotionHistory { get; set; } = new List<PromotionHistoryViewModel>();

    }
    public class PromotionItemCritriaViewModel
    {
        public bool Exclude { get; set; }
        public Int32? GroupNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public string PromotionId { get; set; }
        public double? GroupSlice { get; set; }

    }
    public class PromotionMixAndMatchGroupViewModel
    {
        public string PromotionId { get; set; }
        public Int32? GroupNo { get; set; }
        public double? Slice { get; set; }
    }
    public class PromotionOutcomeViewModel
    {
        public string PromotionId { get; set; }
        public Int32? Count { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public Int32? Option { get; set; }  
        public double? Percentage { get; set; }
        public double? Quantity { get; set; }
        public double? Slice { get; set; }
        public double? Value { get; set; }
    }
    public class PromotionClientViewModel
    {
        public string PromotionId { set; get; }
        public string ClientCode { set; get; }
        public string ClientName { set; get; }

        public bool Exclude { set; get; }
    }
    public class PromotionHistoryViewModel
    {
        public string PromotionId { set; get; }
        public string SalesCode { set; get; }
        public string ClientCode { set; get; }
    }
}
