using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientSurveySearchModel : BaseSearchModel
    {
        public int? BranchId { get; set; }
        public int? ClientTypeId { get; set; }
        public int SurveyId { get; set; }
        public int? ServeyStatusId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? StartDate { get; set; }

        public int? ServeyGroupId { get; set; }
        public int? RepresentativeId { get; set; }
        public int? IsClosed { get; set; }


    }
}