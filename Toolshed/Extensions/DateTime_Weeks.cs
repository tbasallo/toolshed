using System;
using System.Collections.Generic;
using System.Globalization;

namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        /// <summary>
        /// Returns the start of the week with a time of 00:00:00:000
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime StartOfWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetStartOfWeek(date, firstDayOfWeek);
        }
        /// <summary>
        /// Returns the start of the week
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly StartOfWeek(this DateOnly date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetStartOfWeek(date, firstDayOfWeek);
        }

        /// <summary>
        /// Returns the end of the week
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly EndOfWeek(this DateOnly date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetEndOfWeek(date, firstDayOfWeek);
        }
        /// <summary>
        /// Returns the end of the week with a time of 23:59:59:999
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime EndOfWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetEndOfWeek(date, firstDayOfWeek);
        }
        
        /// <summary>
        /// Returns the start of the previous week with a time of 00:00:00:000
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime StartOfPreviousWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetStartOfWeek(date.AddDays(-7), firstDayOfWeek);
        }
        /// <summary>
        /// Returns the start of the previous week
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly StartOfPreviousWeek(this DateOnly date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetStartOfWeek(date.AddDays(-7), firstDayOfWeek);
        }

        /// <summary>
        /// Returns the start of the previous week with a time of 00:00:00:000
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime EndOfPreviousWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetEndOfWeek(date.AddDays(-7), firstDayOfWeek);
        }
        /// <summary>
        /// Returns the start of the previous week with a time of 00:00:00:000
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly EndOfPreviousWeek(this DateOnly date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetEndOfWeek(date.AddDays(-7), firstDayOfWeek);
        }
        
        /// <summary>
        /// Returns the start of the previous week with a time of 00:00:00:000
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly StartOfNextWeek(this DateOnly date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetStartOfWeek(date.AddDays(7), firstDayOfWeek);
        }
        /// <summary>
        /// Returns the start of the previous week with a time of 00:00:00:000
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime StartOfNextWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetStartOfWeek(date.AddDays(7), firstDayOfWeek);
        }
        
        /// <summary>
        /// Returns the start of the previous week with a time of 00:00:00:000
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime EndOfNextWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetEndOfWeek(date.AddDays(7), firstDayOfWeek);
        }
        /// <summary>
        /// Returns the start of the previous week with a time of 00:00:00:000
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly EndOfNextWeek(this DateOnly date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetEndOfWeek(date.AddDays(7), firstDayOfWeek);
        }

        /// <summary>
        /// Returns the current week of the year using Sunday as the first day of the week and the FirstFourDayWeek as the calendar week rule
        /// </summary>
        public static int GetWeek(this DateTime date)
        {
            return DateHelper.GetWeekOfYear(date);
        }

        /// <summary>
        /// Returns the current week of the year using the specified first day of the week and the FirstFourDayWeek as the calendar week rule
        /// </summary>
        public static int GetWeek(this DateTime date, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            return DateHelper.GetWeekOfYear(date, dayOfWeek: firstDayOfWeek);
        }

        /// <summary>
        /// Returns the current week of the year using the specified first day of the week and the specified CalendarWeekRule
        /// </summary>
        public static int GetWeek(this DateTime date, DayOfWeek firstDayOfWeek, CalendarWeekRule calendarWeekRule)
        {
            return DateHelper.GetWeekOfYear(date, calendarWeekRule, firstDayOfWeek);
        }

        /// <summary>
        /// Returns the date of the specified day in the current week
        /// </summary>
        /// <param name="date">The date of the week</param>
        /// <param name="dayOfWeek">The day of the week that the date is desired for</param>
        /// <returns></returns>
        public static DateTime GetDayOfWeek(this DateTime date, DayOfWeek dayOfWeek)
        {
            return date.StartOfWeek().AddDays((int)dayOfWeek);
        }
    }
}