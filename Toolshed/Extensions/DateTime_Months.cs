using System;
using System.Collections.Generic;
using System.Globalization;

namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        /// <summary>
        /// Returns the month name using the Current Culture
        /// </summary>
        public static string ToMonthName(this DateTime date)
        {
            return DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month);
        }

        /// <summary>
        /// Returns the abbreviated month name using the Current Culture
        /// </summary>
        public static string ToMonthNameAbbreviated(this DateTime date)
        {
            return DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(date.Month);
        }


        /// <summary>
        /// Returns the start of the moth with a time of 00:00:00:000
        /// </summary>
        public static DateTime StartOfMonth(this DateTime date)
        {
            return DateHelper.GetStartOfMonth(date.Month, date.Year);
        }

        /// <summary>
        /// Returns the start of the next month with a time of 00:00:00:000
        /// </summary>
        public static DateTime StartOfNextMonth(this DateTime date)
        {
            date = date.AddMonths(1);
            return date.StartOfMonth();
        }

        /// <summary>
        /// Returns the start of the previous month with a time of 00:00:00:000
        /// </summary>
        public static DateTime StartOfPreviousMonth(this DateTime date)
        {
            date = date.AddMonths(-1);
            return date.StartOfMonth();
        }

        /// <summary>
        /// returns the last date of teh month with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfMonth(this DateTime date)
        {
            return DateHelper.GetEndOfMonth(date.Month, date.Year);
        }

        /// <summary>
        /// returns the last date of next month with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfNextMonth(this DateTime date)
        {
            date = date.AddMonths(1);
            return date.EndOfMonth();
        }

        /// <summary>
        /// returns the last date of the previous month with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfPreviousMonth(this DateTime date)
        {
            date = date.AddMonths(-1);
            return date.EndOfMonth();
        }

        /// <summary>
        /// Returns total months between the current and specified date
        /// <para>The current date is subtracted form teh specified date and the difference returned</para>
        /// </summary>
        public static int GetMonthsBetweenDates(this DateTime thisdate, DateTime date)
        {
            if (thisdate > date)
            {
                return DateHelper.GetMonthsBetweenDates(date, thisdate);
            }
            else
            {
                return DateHelper.GetMonthsBetweenDates(thisdate, date);
            }
        }
    }
}