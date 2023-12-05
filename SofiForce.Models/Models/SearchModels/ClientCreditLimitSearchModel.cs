using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClientCreditLimitSearchModel :BaseSearchModel
    {
        public int LimitYear { get; set; }
        public int LimitMonth { get; set; }
        public int ClientId { get; set; }
        public int BranchId { get; set; }
    }
}
