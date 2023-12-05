using System;
using System.Collections.Generic;
using System.Linq;

namespace SofiForce.Sync.Common
{
    public  class TargetUtils
    {
        public static Int64 getTarget(Int64 Targetvalue,int Mode,DateTime From, DateTime To)
        {
            Int64 resTarget = 0;

            if (From <= To)
            {
                if (Mode == 1)
                {
                    int WorkingDays = From.FirstDayOfMonth().BusinessDaysUntil(To.LastDayOfMonth());
                    resTarget = Targetvalue / WorkingDays;
                }

                if (Mode == 2)
                {
                    int WorkingDays = From.FirstDayOfMonth().BusinessDaysUntil(To.LastDayOfMonth());
                    int WorkingWeeksDays = From.FirstDayOfWeek().BusinessDaysUntil(To);
                    resTarget = Targetvalue / WorkingDays * WorkingWeeksDays;
                }

                if (Mode == 3)
                {
                    int WorkingDays = From.FirstDayOfMonth().BusinessDaysUntil(To.LastDayOfMonth());
                    int WorkingMonthDays = From.FirstDayOfMonth().BusinessDaysUntil(To);
                    resTarget = Targetvalue / WorkingDays * WorkingMonthDays;
                }

                if (Mode == 4)
                {
                    resTarget = Targetvalue;
                }
                if (Mode == 5)
                {
                    resTarget = Targetvalue;
                }
            }


            return resTarget;
        }

    }

    internal class TargetObject
    {
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public Int64 TargetValue { get; set; }
    }
}
