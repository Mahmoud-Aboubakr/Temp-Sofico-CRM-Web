using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientQuotaListModel
    {

        public int? ItemId { get; set; }
        public int? ClientId { get; set; }
        public int? Quantity { get; set; }
        public int? Remain { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public int? VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }

        public decimal? PublicPrice { get; set; }
        public decimal? ClientPrice { get; set; }
        public decimal? Discount { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public bool? IsTaxable { get; set; }
        public bool? IsNewStocked { get; set; }
        public bool? IsNewAdded { get; set; }
        public bool? HasPromotion { get; set; }

    }
}
