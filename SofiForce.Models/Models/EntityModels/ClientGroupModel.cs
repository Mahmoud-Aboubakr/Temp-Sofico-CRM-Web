using System;

namespace Models
{
    public class ClientGroupModel
    {
        public int ClientGroupId { get; set; }
        public string ClientGroupCode { get; set; }
        public string ClientGroupNameEn { get; set; }
        public string ClientGroupNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }

        public string Notes { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
