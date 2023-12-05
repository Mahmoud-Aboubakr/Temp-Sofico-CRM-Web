using System;

namespace Models
{
    public class SalesOrderWorkflowModel
    {
        public long WorkflowId { get; set; }
        public long? SalesId { get; set; }
        public int? SalesOrderStatusId { get; set; }
        public int? AgentId { get; set; }
        public DateTime? WorkflowDate { get; set; }
    }
}
