using Models;
using System;

namespace SofiForce.Sync.Common
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
