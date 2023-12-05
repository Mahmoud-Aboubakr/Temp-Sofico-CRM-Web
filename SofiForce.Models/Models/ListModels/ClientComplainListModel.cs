using System;

namespace Models
{
    public class ClientComplainListModel
    {
        public long ComplainId { get; set; }
        public string ComplainCode { get; set; }
        public int? BranchId { get; set; }
        public int? RepresentativeId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? ComplainDate { get; set; }
        public DateTime? ComplainTime { get; set; }
        public int? ComplainTypeId { get; set; }
        public string Phone { get; set; }
        public int? PriorityId { get; set; }
        public int? ComplainStatusId { get; set; }
        public bool? IsClosed { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? Duration { get; set; }

        public int? DepartmentId { get; set; }
        public string PriorityName { get; set; }
        public string ComplainTypeName { get; set; }
        public string BranchName { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string BranchCode { get; set; }
        public string DepartmentName { get; set; }
        public string ComplainStatusName { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentativeCode { get; set; }
        public int? ComplainTypeDetailId { get; set; }

        public string PriorityColor { get; set; }
    }
}
