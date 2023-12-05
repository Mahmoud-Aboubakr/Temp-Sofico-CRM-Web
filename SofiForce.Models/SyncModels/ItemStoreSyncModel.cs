using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Models.SyncModels
{
    public class ItemStoreSyncModel
    {
        public int? ItemId { get; set; }


        public int? Quantity { get; set; }

        public int? OnHand { get; set; }

        public DateTime? ExpireDate { get; set; }

        public String? BatchNo { get; set; }

        public int? Available { get; set; } 

        public int? ItemStoreId { get; set; }
    }
}
