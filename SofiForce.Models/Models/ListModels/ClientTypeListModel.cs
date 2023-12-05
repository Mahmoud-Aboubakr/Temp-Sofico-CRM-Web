using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientTypeListModel
    {

        public int ClientTypeId { get; set; }
        public string ClientTypeCode { get; set; }
        public string ClientTypeName { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }

        public bool? CanDelete { get; set; }
        public bool? CanEdit { get; set; }

    }
}
