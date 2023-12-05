using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientServiceRequestModel
    {
        public string Id { get; set; }
        public bool? IsSynced { get; set; } = false;
        public DateTime? SyncDate { get; set; }

        public double RequestId { get; set; }
        public string RequestCode { get; set; }
        public int? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }

        public int? RepresentativeId { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }

        public int? ClientId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }

        public DateTime? RequestDate { get; set; }
        public DateTime? RequestTime { get; set; }
        public int? RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }

        public int? RequestTypeDetailId { get; set; }
        public string RequestTypeDetailName { get; set; }

        public string Phone { get; set; }
        public string PhoneAlternative { get; set; }
        public int? PriorityId { get; set; }
        public string PriorityName { get; set; }

        public int? RequestStatusId { get; set; }
        public string RequestStatusName { get; set; }

        public bool? IsClosed { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? Duration { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public bool? InZone { get; set; }
        public double? Distance { get; set; }

        public string Notes { get; set; }
        public string Replay { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<ClientServiceRequestTimlineListModel> TimeLine { get; set; } = new List<ClientServiceRequestTimlineListModel>();
        public List<ClientServiceRequestDocumentListModel> Documents { get; set; } = new List<ClientServiceRequestDocumentListModel>();
    }
}
