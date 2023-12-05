using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientSurveyModel
    {

        public string Id { get; set; }
        public bool? IsSynced { get; set; } = false;
        public DateTime? SyncDate { get; set; }

        public double? ClientServeyId { get; set; }
        public int SurveyId { get; set; }
        public int? ClientId { get; set; }
        public int? BranchId { get; set; }

        public int? RepresentativeId { get; set; }
        public int? ServeyStatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StartTime { get; set; }


        public bool? InZone { get; set; }
        public double? Distance { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string Notes { get; set; }
        public SurveyModel ServeyModel { get; set; } = new SurveyModel();
    }
}
