using System;
using System.Collections.Generic;

namespace Models
{
    public class LocationLevelListModel
    {
        public int LocationLevelId { get; set; }
        public string LocationLevelCode { get; set; }
        public string LocationLevelName { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
    }
}
