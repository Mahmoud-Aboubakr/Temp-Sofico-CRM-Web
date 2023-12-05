using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientPlanUploadModel
    {
        public int PlanYear { get; set; } =DateTime.Now.Year;
        public int PlanMonth { get; set; } = DateTime.Now.Year;
        public string FilePath { get; set; }
        public DateTime? UploadDate { get; set; }
        public bool ClearCurrent { get; set; }

    }
}