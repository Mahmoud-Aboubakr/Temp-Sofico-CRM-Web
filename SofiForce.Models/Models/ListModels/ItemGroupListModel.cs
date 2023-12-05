using System;
using System.Collections.Generic;

namespace Models
{
    public class ItemGroupListModel
    {
        public int? ItemGroupId { get; set; }
        public string ItemGroupCode { get; set; }
        public string ItemGroupName { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? IsActive { get; set; }

    }
}
