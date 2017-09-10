using System;
using System.Collections.Generic;
using System.Globalization;

namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        /// <summary>
        /// Returns this date with a time of 00:00:00:000
        /// </summary>
        public static DateTime StartOfDay(this DateTime date)
        {
            return DateHelper.GetStartOfDay(date);
        }

        /// <summary>
        /// Returns this date with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfDay(this DateTime date)
        {
            return DateHelper.GetEndOfDay(date);
        }

        /// <summary>
        /// Returns the whole number of days between this date and the specified date
        /// <para>This date is subtracted from the specified date and the difference returned</para>
        /// </summary>
        public static int TotalDaysToDate(this DateTime thisDate, DateTime date)
        {
            return DateHelper.GetDaysBetweenDates(thisDate, date);
        }

        /// <summary>
        /// Returns a list of dates between this date and the specified date
        /// </summary>
        public static List<DateTime> DatesToDate(this DateTime thisDate, DateTime date)
        {
            return DateHelper.GetDatesBetweenDates(thisDate, date);
        }
    }
}