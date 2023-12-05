using System;
using System.Collections.Generic;

namespace Models
{
    public class PromotionSearchModel : BaseSearchModel
    {

        public int CompanyId { get; set; }
        public int? PromotionCategoryId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int? IsActive { get; set; }
        public int? PromotionTypeId { get; set; }
        public int? Priority { get; set; }
        public int? Repeats { get; set; }

        public int? PromotionGroupId { get; set; }
        public int? RepeatTypeId { get; set; }

        public int? DisplayOrder { get; set; }
        public int? EnableNotification { get; set; }
        public DateTime? NotificationDate { get; set; }
        public int? NotificationDone { get; set; }

        public string VendorCode { get; set; }


    }
}