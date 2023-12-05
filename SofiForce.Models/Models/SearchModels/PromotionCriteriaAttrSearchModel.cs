using System;
using System.Collections.Generic;

namespace Models
{
    public class PromotionCriteriaAttrSearchModel : BaseSearchModel
    {
        public int? IsActive { get; set; }
        public int? IsCustom { get; set; }

    }
}