using System;

namespace Models
{
    public class ClientServiceRequestListModel
    {
        public long RequestId { get; set; }
        public string RequestCode { get; set; }
        public int? BranchId { get; set; }
        public int? RepresentativeId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? RequestTime { get; set; }
        public int? RequestTypeId { get; set; }
        public int? RequestTypeDetailId { get; set; }
        public string Phone { get; set; }
        public string PhoneAlternative { get; set; }
        public int? PriorityId { get; set; }
        public int? RequestStatusId { get; set; }
        public string RequestStatusName { get; set; }

        public bool? IsClosed { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? Duration { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string RequestTypeName { get; set; }
        public string RequestTypeDetailName { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string PriorityName { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }

        public string PriorityColor { get; set; }
    }
}
