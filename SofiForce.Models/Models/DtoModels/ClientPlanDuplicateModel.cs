using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientPlanDuplicateModel
    {
        public int PlanYear { get; set; } =DateTime.Now.Year;
        public int PlanMonth { get; set; } = DateTime.Now.Year;

    }
}