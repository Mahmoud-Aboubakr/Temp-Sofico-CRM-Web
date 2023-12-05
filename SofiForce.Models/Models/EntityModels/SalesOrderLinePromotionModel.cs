using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesOrderLinePromotionModel
    {
        public Int64? LineId { get; set; }
        public double? SalesId { get; set; }
        public int? ItemId { get; set; }
        public int? ItemStoreId { get; set; }
        public int? PromotionId { get; set; }
        public double? Outcome { get; set; }
        public int? OutcomeType { get; set; }
    }
}
