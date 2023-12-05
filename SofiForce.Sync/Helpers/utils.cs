using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SoficoApplication.Api.Helpers
{
    public static class utils
    {

        public static int FindWorkingDays(this DateTime firstDay, DateTime lastDay)
        {
            int days = 0;
            while (firstDay <= lastDay)
            {
                if (firstDay.DayOfWeek != DayOfWeek.Friday)
                {
                    ++days;
                }
                firstDay = firstDay.AddDays(1);
            }
            return days;
        }
        public static int GetQuarter(this DateTime date)
        {
            if (date.Month >= 1 && date.Month <= 3)
                return 1;
            if (date.Month >= 4 && date.Month <= 6)
                return 2;
            else if (date.Month >= 7 && date.Month <= 9)
                return 3;
            else
                return 4;
        }

        public static string getMonth(Int64 month)
        {
            switch (month)
            {
                case 1:
                    return "Jan";

                case 2:
                    return "Fab";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                case 12:
                    return "Dec";
                default:
                    return "";
            }
        }
    }
}
