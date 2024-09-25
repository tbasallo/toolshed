using Microsoft.VisualBasic;
using System;
using System.Globalization;

namespace Toolshed
{
    public static partial class DateHelper
    {
        /// <summary>
        /// Returns the first day of the current week
        /// </summary>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the start of the current week.</returns>
        public static DateTime GetStartOfCurrentWeek(DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return  GetStartOfWeek(DateTime.Today, firstDayOfWeek);
        }

        /// <summary>
        /// Returns the last day of the current week
        /// </summary>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the end of the current week.</returns>
        public static DateTime GetEndOfCurrentWeek(DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return GetEndOfWeek(DateTime.Today, firstDayOfWeek);
        }

        /// <summary>
        /// Returns the first day of following week
        /// </summary>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the start of the following week.</returns>
        public static DateTime GetStartOfNextWeek(DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return GetStartOfWeek(DateTime.Today.AddDays(7), firstDayOfWeek);
        }

        /// <summary>
        /// Returns the last day of following week
        /// </summary>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the end of the following week.</returns>
        public static DateTime GetEndOfNextWeek(DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return GetEndOfWeek(DateTime.Today.AddDays(7), firstDayOfWeek);
        }

        /// <summary>
        /// Returns the first day of previous week
        /// </summary>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the start of the previous week.</returns>
        public static DateTime GetStartOfLastWeek(DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return GetStartOfWeek(DateTime.Today.AddDays(-7), firstDayOfWeek);
        }

        /// <summary>
        /// Returns the last day of the previous week
        /// </summary>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the end of the previous week.</returns>
        public static DateTime GetEndOfLastWeek(DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return GetEndOfWeek(DateTime.Today.AddDays(-7), firstDayOfWeek);
        }




        /// <summary>
        /// Returns the first day of the week that includes the date in the specified date
        /// </summary>
        /// <param name="date">The DateTime for the week we want the start of.</param>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the start of the week that the date in the parameter is in.</returns>
        public static DateTime GetStartOfWeek(DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            //it's in the previous week
            if (firstDayOfWeek > date.DayOfWeek)
            {
                //since the week start is in the previous week, let's go to that week and then do the normal stuff
                date = date.AddDays(-7-(date.DayOfWeek - firstDayOfWeek));
            }
            else
            {
                date = date.AddDays(-(date.DayOfWeek - firstDayOfWeek));
            }

            return GetStartOfDay(date);
        }
        /// <summary>
        /// Returns the first day of the week that includes the date in the specified date
        /// </summary>
        /// <param name="date">The DateTime for the week we want the start of.</param>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the start of the week that the date in the parameter is in.</returns>
        public static DateOnly GetStartOfWeek(DateOnly date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            //it's in the previous week
            if (firstDayOfWeek > date.DayOfWeek)
            {
                //since the week start is in the previous week, let's go to that week and then do the normal stuff
                date = date.AddDays(-7 - (date.DayOfWeek - firstDayOfWeek));
            }
            else
            {
                date = date.AddDays(-(date.DayOfWeek - firstDayOfWeek));
            }

            return date;
        }

        /// <summary>
        /// Returns the last day of the week that includes the date in the specified date
        /// </summary>
        /// <param name="date">The DateTime for the week we want the start of.</param>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the end of the week that the date in the parameter is in.</returns>
        public static DateTime GetEndOfWeek(DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            //TODO: refactored form the top of my head, needs testing
            var c1 = (int)date.DayOfWeek;
            var c2 = (int)firstDayOfWeek;
            var daysToSubtract = 6 - (c1 - c2);
            var date1 = date.AddDays(daysToSubtract);
            return GetEndOfDay(date1);
        }
        /// <summary>
        /// Returns the last day of the week that includes the date in the specified date
        /// </summary>
        /// <param name="date">The DateTime for the week we want the start of.</param>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week (i.e., Sunday, Monday, etc.).</param>
        /// <returns>A DateTime that represents the end of the week that the date in the parameter is in.</returns>
        public static DateOnly GetEndOfWeek(DateOnly date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            //TODO: refactored form the top of my head, needs testing
            var c1 = (int)date.DayOfWeek;
            var c2 = (int)firstDayOfWeek;
            var daysToSubtract = 6 - (c1 - c2);
            var date1 = date.AddDays(daysToSubtract);
            return date1;
        }

        /// <summary>
        /// Returns the whole number (rounded) of weeks between two dates
        /// </summary>
        /// <param name="startDate">The first, earlier, of two dates</param>
        /// <param name="endDate">The second, later, of two dates</param>
        /// <returns>An integer that represents the number of weeks between the dates in the parameters</returns>
        public static int GetWeeksBetweenDates(DateTime startDate, DateTime endDate)
        {
            return (int)GetTotalWeeksBetweenDates(startDate, endDate);
        }

        /// <summary>
        /// Returns the fractional number of weeks between two dates
        /// </summary>
        /// <param name="startDate">The first, earlier, of two dates</param>
        /// <param name="endDate">The second, later, of two dates</param>
        /// <returns>A double that represents the number of weeks between the dates in the parameters</returns>
        public static double GetTotalWeeksBetweenDates(DateTime startDate, DateTime endDate)
        {
            int days = GetDaysBetweenDates(startDate, endDate);
            return days / 7;
        }

        /// <summary>
        /// Returns the week of the year using the current date and culture.
        /// </summary>
        /// <param name="calendarWeekRule">A System.Globalization.CalendarWeekRule value that defines a calendar week, default to CalendarWeekRule.FirstFourDayWeek.</param>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week, defaults to DayOfWeek.Sunday</param>
        /// <returns>A positive integer that represents the week of the year that includes the current date and culture.</returns>
        public static int GetCurrentWeek(CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstFourDayWeek, DayOfWeek dayOfWeek = DayOfWeek.Sunday)
        {
            return GetWeekOfYear(DateTime.Today, calendarWeekRule, dayOfWeek);
        }

        /// <summary>
        /// Returns the week of the year that includes the date in the specified System.DateTime.
        /// </summary>
        /// <param name="date">The System.DateTime to read.</param>
        /// <param name="calendarWeekRule">A System.Globalization.CalendarWeekRule value that defines a calendar week, default to CalendarWeekRule.FirstFourDayWeek.</param>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week, defaults to DayOfWeek.Sunday</param>
        /// <param name="cultureInfo">The culture for the calendar used</param>
        /// <returns>A positive integer that represents the week of the year that includes the date in the time parameter.</returns>
        public static int GetWeekOfYear(DateTime date, CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstFourDayWeek, DayOfWeek dayOfWeek = DayOfWeek.Sunday)
        {
            return GetWeekOfYear(date, calendarWeekRule, dayOfWeek, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns the week of the year that includes the date in the specified System.DateTime.
        /// </summary>
        /// <param name="date">The System.DateTime to read.</param>
        /// <param name="calendarWeekRule">A System.Globalization.CalendarWeekRule value that defines a calendar week.</param>
        /// <param name="firstDayOfWeek">A System.DayOfWeek value that represents the first day of the week</param>
        /// <param name="cultureInfo">The culture for the calendar used</param>
        /// <returns>A positive integer that represents the week of the year that includes the date in the time parameter.</returns>
        public static int GetWeekOfYear(DateTime date, CalendarWeekRule calendarWeekRule, DayOfWeek firstDayOfWeek, CultureInfo cultureInfo)
        {
            Calendar calendar = cultureInfo.Calendar;
            return calendar.GetWeekOfYear(date, calendarWeekRule, firstDayOfWeek);
        }

        //read the SO post to see some of the logic used here
        //http://stackoverflow.com/questions/16553878/how-to-do-i-invert-the-week-returned-from-calendar-getweekofyear-back-to-a-datet/16553879#16553879
        /// <summary>
        /// Returns the first date of the specified week and year
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime FirstDateOfWeek(int year, int weekOfYear, CultureInfo cultureInfo)
        {

            DateTime midYear = new DateTime(year, 7, 1);
            while (midYear.DayOfWeek != cultureInfo.DateTimeFormat.FirstDayOfWeek)
            {
                midYear = midYear.AddDays(1);
            }

            int refWeek = cultureInfo.Calendar.GetWeekOfYear(midYear, cultureInfo.DateTimeFormat.CalendarWeekRule, cultureInfo.DateTimeFormat.FirstDayOfWeek);

            int weekOffset = weekOfYear - refWeek;

            return midYear.AddDays(7 * weekOffset);
        }
    }
}
