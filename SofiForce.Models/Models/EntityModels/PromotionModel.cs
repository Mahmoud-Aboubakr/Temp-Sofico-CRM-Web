using System;

namespace Models
{
    public class PromotionModel
    {
        public int PromotionId { get; set; }
        public string PromotionCode { get; set; }
        public string VendorCode { get; set; }
        public int CompanyId { get; set; }
        public int? PromotionCategoryId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public int? PromotionTypeId { get; set; }
        public string PromotionTypeName { get; set; }

        public int? Priority { get; set; }
        public int? RepeatTypeId { get; set; }
        public int? Repeats { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public string PromotionDesc { get; set; }
        public int? PromotionGroupId { get; set; }
        public string PromotionGroupName { get; set; }
        public string RepeatTypeName { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? EnableNotification { get; set; }
        public DateTime? NotificationDate { get; set; }
        public bool? NotificationDone { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }


        public List<PromotionMixGroupModel> Groups { get; set; } = new List<PromotionMixGroupModel>();
        public List<PromotionItemListModel> Items { get; set; } = new List<PromotionItemListModel>();
        public List<PromtionCriteriaClientModel> Clients { get; set; } = new List<PromtionCriteriaClientModel>();
        public List<PromtionCriteriaSalesManModel> SalesMans { get; set; } = new List<PromtionCriteriaSalesManModel>();
        public List<PromotionOutcomeModel> Outcomes { get; set; } = new List<PromotionOutcomeModel>();


    }
}
