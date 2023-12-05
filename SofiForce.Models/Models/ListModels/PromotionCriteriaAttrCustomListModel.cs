using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PromotionCriteriaAttrCustomListModel
    {
        public Int32? CustomId { get; set; }
        public Int32? AttributeId { get; set; }
        public string ItemCode { get; set; }

        public string ItemName { get; set; }

    }
}
