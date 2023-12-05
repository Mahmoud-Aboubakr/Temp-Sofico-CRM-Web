using System;
using System.Collections.Generic;

namespace Models
{
    public class PromotionTypeSearchModel : BaseSearchModel
    {

        public int? PromotionInputId { get; set; }
        public int? PromotionOutputId { get; set; }
        public int? IsActive { get; set; }


    }
}