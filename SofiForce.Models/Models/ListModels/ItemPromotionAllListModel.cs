using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemPromotionAllListModel
    {
        public Int32? PromotionId { get; set; }
        public string PromotionCode { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool? IsActive { get; set; }
        public Int32? PromotionTypeId { get; set; }
        public string PromotionTypeName { get; set; }
        public Int32? Priority { get; set; }
        public Int32? Repeats { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

    }
}
