using System;

namespace Models
{
    public class ClientGroupSubModel
    {
        public int ClientGroupSubId { get; set; }
        public int? ClientGroupId { get; set; }
        public string ClientGroupSubCode { get; set; }
        public string ClientGroupSubNameEn { get; set; }
        public string ClientGroupSubNameAr { get; set; }
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


        public string Notes { get; set; }
    }
}
