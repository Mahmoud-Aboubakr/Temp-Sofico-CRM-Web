using System;

namespace Models
{
    public class TrakingRepresentativeModel
    {
        public Int32? RepresentativeId { get; set; }
        public Int32? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public Int32? UserId { get; set; }
        public Int32? SupervisorId { get; set; }
        public Int32? KindId { get; set; }
        public Int32? BusinessUnitId { get; set; }
        public string CompanyCode { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }

        public string Phone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? LastTraking { get; set; }

        public bool? IsOnline { get; set; }
    }
}
