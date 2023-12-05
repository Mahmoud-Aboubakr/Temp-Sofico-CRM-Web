using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientComplainSearchModel : BaseSearchModel
    {
        public string ComplainCode { get; set; }
        public int? BranchId { get; set; }
        public int? RepresentativeId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? ComplainDate { get; set; }
        public int? ComplainTypeId { get; set; }
        public int? ComplainTypeDetailId { get; set; }
        public string Phone { get; set; }
        public int? PriorityId { get; set; }
        public int? ComplainStatusId { get; set; }
        public int? IsClosed { get; set; }
        public int? DepartmentId { get; set; }

    }
}