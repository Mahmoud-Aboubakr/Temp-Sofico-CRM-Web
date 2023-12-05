using System;

namespace Models
{
    public class ClientGroupSubListModel
    {
        public int ClientGroupSubId { get; set; }
        public int ClientGroupId { get; set; }

        public string ClientGroupSubCode { get; set; }
        public string ClientGroupSubName { get; set; }
        public string ClientGroupName { get; set; }

        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
