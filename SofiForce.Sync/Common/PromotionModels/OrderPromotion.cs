using System;

namespace SofiForce.Sync.Common.PromotionModels
{
    public class OrderPromotion
    {
        public int PromotionId { get; set; }
        public int Priority { get; set; }
        public int PromotionTypeId { get; set; }
        public int PromotionCategoryId { get; set; }
        public string ItemCode { get; set; }
        public string VendorCode { get; set; }

        public int RepeatTypeId { get; set; }
        public int Repeats { get; set; }
        public int GroupId { get; set; }

        public DateTime FromDate { get; set; }

    }
}
