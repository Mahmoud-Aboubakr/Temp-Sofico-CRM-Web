using System;
using System.Collections.Generic;

namespace Models
{
    public class BranchListModel
    {

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public bool? IsActive { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? DisplayOrder { get; set; }
        public decimal? ExpenseRate { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
