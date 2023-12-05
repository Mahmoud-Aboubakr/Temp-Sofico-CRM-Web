using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemPromotionAllSearchModel : BaseSearchModel
    {
        public int ItemId { get; set; }
        public int PromotionId { get; set; }
        public int IsActive { get; set; }

        public string PromotionCode { get; set; }
        public string ItemCode { get; set; }

    }
}
