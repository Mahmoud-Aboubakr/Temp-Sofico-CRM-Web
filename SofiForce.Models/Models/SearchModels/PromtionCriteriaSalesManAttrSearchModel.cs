using System;
using System.Collections.Generic;

namespace Models
{
    public class PromtionCriteriaSalesManAttrSearchModel : BaseSearchModel
    {
        public int? IsActive { get; set; }
        public int? IsCustom { get; set; }

    }
}