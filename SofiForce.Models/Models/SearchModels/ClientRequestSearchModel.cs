using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientRequestSearchModel : BaseSearchModel
    {
        public string RequestCode { get; set; }
        public int? BranchId { get; set; }
        public int? RepresentativeId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? RequestTypeId { get; set; }
        public int? RequestTypeDetailId { get; set; }
        public string Phone { get; set; }
        public int? PriorityId { get; set; }
        public int? RequestStatusId { get; set; }
        public int? IsClosed { get; set; }
        public int? DepartmentId { get; set; }

    }
}