using System;
using System.Collections.Generic;

namespace Models
{
    public class SupervisorSearchModel : BaseSearchModel
    {

        public int BranchId { get; set; }

        public int SupervisorTypeId { get; set; }
        public string SupervisorTypeIds { get; set; }



        public string SupervisorName { get; set; }
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