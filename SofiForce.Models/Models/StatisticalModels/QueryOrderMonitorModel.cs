using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderMonitorModel
    {
        public int? Confirmed { get; set; }
        public int? Opened { get; set; }
        public int? Transfered { get; set; }
        public int? Invoiced { get; set; }

        public int? Rejected { get; set; }
        public int? All { get; set; }

        public decimal Perormance { get; set; } = 0;

        public IEnumerable<OrderMonitorDetailModel> Details { get; set; } = new List<OrderMonitorDetailModel>();
    }
    public class OrderMonitorDetailModel
    {
        public int? BranchId { get; set; }
        public string BranchCode { get; set; }=String.Empty;
        public string BranchName { get; set; } = String.Empty;
        public int? Confirmed { get; set; }
        public int? Opened { get; set; }
        public int? Transfered { get; set; }
        public int? Rejected { get; set; }
        public int? All { get; set; }

        public int? Invoiced { get; set; }
        public int? SetupId { get; set; }
        public string ServiceWorkerCode { get; set; } = String.Empty;
        public bool? IsEnabled { get; set; }
        public string ServiceWorkerName { get; set; } = String.Empty;

        public int? ServiceWorkerId { get; set; }   
        public decimal Perormance { get; set; } = 0;
    }
}
