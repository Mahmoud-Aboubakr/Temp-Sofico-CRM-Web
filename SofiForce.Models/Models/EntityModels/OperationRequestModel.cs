using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestModel
    {
        public int OperationId { get; set; }
        public string OperationCode { get; set; }
        public int? AgentId { get; set; }
        public int? OperationTypeId { get; set; }
        public int? RepresentativeId { get; set; }
        public int? GovernerateId { get; set; }

        
        public DateTime? OperationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public int? TargetDays { get; set; }
        public int? ActualDays { get; set; }
        public int? TargetClients { get; set; }
        public int? ActualClients { get; set; }
        public decimal? DaysPerformance { get; set; }
        public decimal? ClientsPerformance { get; set; }
        public decimal? Accuracy { get; set; }
        public string MapPoints { get; set; }
        
        public bool? IsClosed { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? CBy { get; set; }
        public int? EBy { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? EDate { get; set; }

        public string Notes { get; set; }
    }
}
