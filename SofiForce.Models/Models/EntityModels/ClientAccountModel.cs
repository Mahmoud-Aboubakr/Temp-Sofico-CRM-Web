using System;

namespace Models
{
    public class ClientAccountModel
    {
        public int ClientAccountId { get; set; }
        public string ClientAccountCode { get; set; }
        public string ClientAccountNameAr { get; set; }
        public string ClientAccountNameEn { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
