using DocumentFormat.OpenXml.Spreadsheet;
using Models;
using SofiForce.Models.Models.DtoModels;
using System;

namespace SofiForce.Web.Common
{
    public class Utils
    {
        public static string getPerformanceLabel(decimal percentage)
        {
            string label = "Low";

            if (percentage >= 0 && percentage < 60)
                label = "Low";
            if (percentage >= 60 && percentage < 70)
                label = "Medium";
            if (percentage >= 80 && percentage < 90)
                label = "Normal";
            if (percentage >= 90 && percentage < 100)
                label = "High";
            if (percentage > 100)
                label = "Premium";

            return label;

        }

        public static TimeRangeDTO getTimeRange(int Period)
        {
            var res = new TimeRangeDTO()
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now,
            };


            switch (Period)
            {
                case 1:
                    res.FromDate = DateTime.Now.Date;
                    break;
                case 2:
                    res.FromDate = DateTime.Now.AddDays(-1);
                    break;
                case 3:
                    res.FromDate = DateTime.Now.FirstDayOfWeek();

                    break;
                case 4:
                    res.FromDate = DateTime.Now.FirstDayOfMonth();
                    break;
                case 5:
                    res.FromDate = DateTime.Now.FirstDayOfQuarter();
                    break;
                case 6:
                    res.FromDate = DateTime.Now.FirstDayOfYear();
                    break;

            }

            return res;

        }

        public static string getPromotionInputName(int value)
        {
            switch (value)
            {
                case 1:
                    return "Quantity";
                case 2:
                    return "Value";
                case 3:
                    return "MixMatch Quantity";
                case 4:
                    return "MixMatch Value";

                default:
                    return "";
            }
        }

        public static string getPromotionOutputName(int value)
        {
            switch (value)
            {
                case 1:
                    return "Percentage";
                case 2:
                    return "Value";
                case 3:
                    return "Free Goods";
                case 4:
                    return "Free Goods Optiona";

                default:
                    return "";
            }
        }

        public static int GetDistanceInMeters(GeoPoint location1, GeoPoint location2)
        {
            double lat1 = location1.lat * Math.PI / 180.0;
            double lon1 = location1.lng * Math.PI / 180.0;
            double lat2 = location2.lat * Math.PI / 180.0;
            double lon2 = location2.lng * Math.PI / 180.0;

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Sin(dLat / 2.0) * Math.Sin(dLat / 2.0) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(dLon / 2.0) * Math.Sin(dLon / 2.0);
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distanceInMeters = 6371000 * c;

            return (int)distanceInMeters;
        }
    }
}
