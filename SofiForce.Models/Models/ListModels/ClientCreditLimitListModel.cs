using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClientCreditLimitListModel
    {
        public Int64? LimitId { get; set; }
        public Int32? ClientId { get; set; }
        public Int32? LimitYear { get; set; }
        public Int32? LimitMonth { get; set; }
        public decimal? LimitValue { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public Int32? BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
    }
}
