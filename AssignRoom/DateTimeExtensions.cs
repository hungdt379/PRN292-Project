using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssignRoom
{
    public static class DateTimeExtensions
    {
        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff +1).Date;
        }

        public static DateTime TuesdayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(1);
        }
        public static DateTime WednesdayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(2);
        }
        public static DateTime ThursdayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(3);
        }
        public static DateTime FridayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(4);
        }
        public static DateTime SaturdayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(5);
        }

        public static DateTime LastDayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(6);
        }
    }
}
