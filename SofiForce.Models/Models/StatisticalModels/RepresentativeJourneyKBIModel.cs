using System;
using System.Collections.Generic;

namespace SofiForce.Models.StatisticalModels
{
    public class RepresentativeJourneyKBIModel
    {

        public int AllClients { get; set; }
        public int Clients { get; set; }
        public int AllRepresentatives { get; set; }
        public int Representatives { get; set; }
        public decimal ClientPerformance { get; set; }
        public decimal RepresentativePerformance { get; set; }
        public decimal PerormancePercentage { get; set; }

        public string PerormanceLabel { get; set; }


        public IEnumerable<RepresentativeJourneyKBIDetailModel> DetailModels { get; set; } = new List<RepresentativeJourneyKBIDetailModel>();

    }

    public class RepresentativeJourneyKBIDetailModel
    {

        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int AllClients { get; set; }
        public int Clients { get; set; }
        public int AllRepresentatives { get; set; }
        public int Representatives { get; set; }
        public decimal ClientPerformance { get; set; }
        public decimal RepresentativePerformance { get; set; }
        public decimal PerormancePercentage { get; set; }

        public string PerormanceLabel { get; set; }

    }
}
