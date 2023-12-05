using System;

namespace Models
{
    public class TempRepresentativeModel
    {
        public int RepresentativeId { get; set; }
        public int? BranchId { get; set; }
        public int? UserId { get; set; }
        public int? SupervisorId { get; set; }
        public int? KindId { get; set; }
        public bool? IsPilot { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
    }
}
