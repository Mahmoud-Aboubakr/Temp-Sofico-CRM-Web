using System;
using System.Collections.Generic;

namespace SofiForce.Models.StatisticalModels
{
    public class KBISummeryModel
    {
        public int PerformanceValue { get; set; }
        public string PerformanceLabel { get; set; }

        public int SalesTotal { get; set; }
        public int SalesTarget { get; set; }
        public int SalesP { get; set; }

        public int VisitTotal { get; set; }
        public int VisitTarget { get; set; }
        public int VisitP { get; set; }

        public int CallTotal { get; set; }
        public int CallTarget { get; set; }
        public int CallP { get; set; }

        public int Days { get; set; }
        public int DaysTarget { get; set; }
        public int DaysP { get; set; }

        public int Orders { get; set; }
        public int Clients { get; set; }
        public int ClientsTarget { get; set; }
        public int ClientsP { get; set; }


        public int RepresentativeId { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }
        public string Phone { get; set; }
        public DateTime? LastTrackDate { get; set; }
        public int IdealFor { get; set; }


        public DateTime? FirstOrder { get; set; }
        public DateTime? LastOrder { get; set; }


    }

}
