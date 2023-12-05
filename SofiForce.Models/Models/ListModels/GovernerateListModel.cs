using System;
using System.Collections.Generic;

namespace Models
{
    public class GovernerateListModel
    {

        public int GovernerateId { get; set; }
        public int? RegionId { get; set; }
        public string GovernerateCode { get; set; }
        public string GovernerateName { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }


    }
}
