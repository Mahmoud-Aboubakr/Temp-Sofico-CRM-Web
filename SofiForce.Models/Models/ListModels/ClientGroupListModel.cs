using System;

namespace Models
{
    public class ClientGroupListModel
    {
        public int ClientGroupId { get; set; }
        public string ClientGroupCode { get; set; }
        public string ClientGroupName { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
