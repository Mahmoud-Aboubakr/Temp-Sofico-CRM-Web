using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Models.SyncModels
{
    public class InvoiceDetailSyncModel
    {
        public double? DetailId { get; set; }
        public double? SalesId { get; set; }
        public int? ItemId { get; set; }
        public double? PublicPrice { get; set; }
        public double? ClientPrice { get; set; }
        public int? Quantity { get; set; }
        public double? Discount { get; set; }
        public bool? IsBouns { get; set; }
        public String? ItemCode { get; set; }
        public String? ItemName { get; set; }
        public string? VendorCode { get; set; }
        public String? VendorName { get; set; }
        public String? BatchNo { get; set; }
        public DateTime? ExpireDate { get; set; }
        public double? LineValue { get; set; }
        public double? TaxValue { get; set; }
        public int? ItemStoreId { get; set; }
    }
}
