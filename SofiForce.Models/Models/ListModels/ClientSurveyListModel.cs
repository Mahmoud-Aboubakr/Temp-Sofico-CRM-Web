using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientSurveyListModel
    {

        public int? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }

        public int? ClientTypeId { get; set; }
        public long? ClientServeyId { get; set; }
        public int SurveyId { get; set; }
        public int? ServeyStatusId { get; set; }
        public int? ClientId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StartTime { get; set; }
        public string SurveyName { get; set; }
        public string ServeyStatusName { get; set; }
        public int? ServeyGroupId { get; set; }
        public string ServeyGroupName { get; set; }
        public int? RepresentativeId { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }
        public string ServeyStatusColor { get; set; }
        public bool? IsClosed { get; set; }

    }
}
