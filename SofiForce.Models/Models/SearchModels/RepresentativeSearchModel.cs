using System;
using System.Collections.Generic;

namespace Models
{
    public class RepresentativeSearchModel : BaseSearchModel
    {

        public int SupervisorId { get; set; }
        public int BranchId { get; set; }

        public int KindId { get; set; }
        public string KindIds { get; set; }



        public string RepresentativeName { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public string Phone { get; set; }
        public int IsActive { get; set; }
        public int IsTerminated { get; set; }
        public int TerminationReasonId { get; set; }

        public int BusinessUnitId { get; set; }

        public string CompanyCode { get; set; }

    }
}