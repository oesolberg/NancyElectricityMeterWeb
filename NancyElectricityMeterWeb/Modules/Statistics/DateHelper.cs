using System;
using System.Security.Policy;

namespace NancyElectricityMeterWeb.Modules.Statistics
{
    public static class DateHelper
    {
        public static DateTime GetStartOfWeek(this DateTime inputDateTime)
        {
            var dayOfWeek = (int) inputDateTime.DayOfWeek;
            if (dayOfWeek == 0) return inputDateTime.AddDays(-6).Date;
            if (dayOfWeek > 1) return inputDateTime.AddDays((-dayOfWeek)+1).Date;

            return inputDateTime.Date;
        }

        public static DateTime GetStartOfMonth(this DateTime inputDateTime)
        {
            return inputDateTime.AddDays((-inputDateTime.Day)+1);
        }
    }
}