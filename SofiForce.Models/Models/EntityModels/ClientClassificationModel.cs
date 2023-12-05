using System;

namespace Models
{
    public class ClientClassificationModel
    {
        public int ClientClassificationId { get; set; }
        public string ClientClassificationCode { get; set; }

        public string ClientClassificationNameEn { get; set; }
        public string ClientClassificationNameAr { get; set; }
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
