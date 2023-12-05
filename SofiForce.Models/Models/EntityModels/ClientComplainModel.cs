using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientComplainModel
    {
        public string Id { get; set; }
        public bool? IsSynced { get; set; } = false;
        public DateTime? SyncDate { get; set; }

        public double ComplainId { get; set; }
        public string ComplainCode { get; set; }
        public int? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }

        public int? RepresentativeId { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }

        public int? ClientId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }

        public DateTime? ComplainDate { get; set; }
        public DateTime? ComplainTime { get; set; }
        public int? ComplainTypeId { get; set; }
        public string ComplainTypeName { get; set; }

        public int? ComplainTypeDetailId { get; set; }
        public string ComplainTypeDetailName { get; set; }

        public string Phone { get; set; }
        public string PhoneAlternative { get; set; }
        public int? PriorityId { get; set; }
        public string PriorityName { get; set; }

        public int? ComplainStatusId { get; set; }
        public string ComplainStatusName { get; set; }

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


        public List<ClientComplainTimelineListModel> TimeLine { get; set; } = new List<ClientComplainTimelineListModel>();
        public List<ClientComplainDocumentListModel> Documents { get; set; } = new List<ClientComplainDocumentListModel>();

    }
}
