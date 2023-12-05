using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Models.SyncModels
{
    public class ItemSyncModel
    {
        public int? ItemId { get; set; }

        public int? VendorId { get; set; }

        public bool? IsTaxable { get; set; }

        public String? ItemCode { get; set; }

        public String? ItemName { get; set; }

        public double? PublicPrice { get; set; }

        public double? ClientPrice { get; set; }

        public double? Discount { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsNewAdded { get; set; }

        public bool? HasPromotion { get; set; }

        public bool? IsNewStocked { get; set; }

        public String? VendorName { get; set; }

        public int? Quantity { get; set; }

        public int? UnitId { get; set; }

        public int? Quota { get; set; }

        public DateTime? LastStockDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? HasQuota { get; set; }

        public String? VendorCode { get; set; }
    }
}
