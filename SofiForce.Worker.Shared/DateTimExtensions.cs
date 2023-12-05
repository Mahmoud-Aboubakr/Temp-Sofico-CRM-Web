using System;
using System.Linq;

namespace SofiForce.Worker.Shared
{
    public static class DateTimExtensions
    {

        public static DateTime Today(this DateTime value)
        {
            return value;
        }

        public static DateTime FirstDayOfWeek(this DateTime value)
        {

            int diff = (7 + (value.DayOfWeek - DayOfWeek.Saturday)) % 7;
            return value.AddDays(-1 * diff);

        }

        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
        }

        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public static DateTime LastDayOfYear(this DateTime value)
        {
            return new DateTime(value.Year, 12, 31, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }
        public static DateTime FirstDayOfQuarter(this DateTime value)
        {
            int quarterNumber = (value.Month - 1) / 3 + 1;
            DateTime firstDayOfQuarter = new DateTime(value.Year, (quarterNumber - 1) * 3 + 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            return firstDayOfQuarter;
        }

        public static DateTime FirstDayOfYear(this DateTime value)
        {
            return new DateTime(value.Year, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public static int BusinessDaysUntil(this DateTime firstDay, DateTime lastDay)
        {
            firstDay = firstDay.Date;
            lastDay = lastDay.Date;

            int businessDays = 0;

            if (firstDay <= lastDay)
            {

                int Count = 0;
                for (var dt = firstDay; dt <= lastDay; dt = dt.AddDays(1))
                {
                    if (dt.DayOfWeek == DayOfWeek.Friday)
                    {
                        Count++;
                    }
                }

                int days = (lastDay - firstDay).Days + 1;
                businessDays = days - Count;
            }

            return businessDays;
        }

        public static string[] GetMonthsBetweenDates(this DateTime deltaDate, int TotalMonths)
        {
            var monthsBetweenDates = Enumerable.Range(0, TotalMonths)
                                               .Select(i => deltaDate.AddMonths(i))
                                               .OrderBy(e => e)
                                               .AsEnumerable();

            return monthsBetweenDates.Select(e => e.ToString("MM")).ToArray();
        }
    }
}
