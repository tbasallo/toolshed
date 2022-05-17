using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Toolshed
{
    public static partial class DateHelper
    {
        /// <summary>
        /// Returns the name of the specified month using the Current Culture
        /// </summary>
        public static string GetMonthName(int month)
        {
            return DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
        }

        /// <summary>
        /// Returns the name of the specified DayOfWeek using the current culture
        /// </summary>
        public static string GetDayName(DayOfWeek dayOfWeek)
        {
            return DateTimeFormatInfo.CurrentInfo.GetDayName(dayOfWeek);
        }

        /// <summary>
        /// Returns a long string representation of the specified date and time using the ToLongDateString() and ToLongTimeString()
        /// <para>The string is formatted as "Date, Time"</para>
        /// </summary>
        public static string GetLongDateTimeString(DateTime date)
        {
            return string.Format("{0}, {1}", date.ToLongDateString(), date.ToLongTimeString());
        }

        /// <summary>
        /// Returns a short string representation of the specified date and time using the ToShortDateString() and ToShortTimeString()
        /// <para>The string is formatted as "Date, Time"</para>
        /// </summary>
        public static string GetShortDateTimeString(DateTime date)
        {
            return string.Format("{0}, {1}", date.ToShortDateString(), date.ToShortTimeString());
        }

        /// <summary>
        /// Returns a date in a URL address friendly format. The default delimiter is a dash (-) but can be changed.
        /// Using a date as part of teh address does not allows slashes
        /// </summary>
        /// <param name="date">The date to convert</param>
        /// <param name="delimiter">the delimiter between the month, day and year</param>
        /// <returns>a string that can be used in a URL</returns>
        public static string ToUrlFriendly(DateTime date, string delimiter = "-")
        {
            return string.Format("{1}{0}{2}{0}{3}", delimiter, date.Month, date.Day, date.Year);
        }

        //international
        public static string ToCustomFormat(DateTime date, string format, string cultureCode)
        {
            DateTimeFormatInfo formatInfo = (new CultureInfo(cultureCode)).DateTimeFormat;
            return date.ToString(format, formatInfo);
        }
        public static string ToShortDateInternationalString(DateTime date, string cultureCode)
        {
            DateTimeFormatInfo formatInfo = (new CultureInfo(cultureCode)).DateTimeFormat;
            return date.ToString("d", formatInfo);
        }

        public static string ToTitle(this DateTime date)
        {
            if (date.Date == DateTime.Today.Date)
            {
                return string.Format("Today, {0}", date.ToShortDateString());
            }

            if (date.Date == DateTime.Today.AddDays(-1).Date)
            {
                return string.Format("Yesterday, {0}", date.ToShortDateString());
            }

            if (date.Date == DateTime.Today.AddDays(1).Date)
            {
                return string.Format("Tomorrow, {0}", date.ToShortDateString());
            }

            return date.ToLongDateString();

        }
        /// <summary>
        /// Compares two dates to determine how to display them, excludes times
        /// </summary>
        /// <param name="date"></param>
        /// <param name="endOfDateRange"></param>
        /// <returns></returns>
        public static string ToTitle(DateTime date, DateTime? endOfDateRange = null)
        {
            if (!endOfDateRange.HasValue)
            {
                if (date.Date == DateTime.Today.Date)
                {
                    return string.Format("Today, {0}", date.ToShortDateString());
                }

                if (date.Date == DateTime.Today.AddDays(-1).Date)
                {
                    return string.Format("Yesterday, {0}", date.ToShortDateString());
                }

                if (date.Date == DateTime.Today.AddDays(1).Date)
                {
                    return string.Format("Tomorrow, {0}", date.ToShortDateString());
                }

                return date.ToLongDateString();
            }

            if (date.Date == endOfDateRange.Value.Date)
            {
                return date.ToLongDateString();
            }

            if (date.Day == 1 && date.Month == 1 && date.Year == endOfDateRange.Value.Year && endOfDateRange.Value.Month == 12 && endOfDateRange.Value.Day == 31)
            {
                return string.Format("YTD {0}", date.Year);
            }

            if (date.Day == 1 && date.Month == 1 && endOfDateRange.Value.Month == 12 && endOfDateRange.Value.Day == 31)
            {
                return string.Format("YTD {0}-{1}", date.Year, endOfDateRange.Value.Year);
            }

            if (date.Date.Day == 1 && endOfDateRange.Value.Day == DateTime.DaysInMonth(endOfDateRange.Value.Year, endOfDateRange.Value.Month))
            {
                return ToMonthTitle(date, endOfDateRange.Value);
            }

            return string.Format("{0:d} - {1:d}", date, endOfDateRange.Value);
        }

        /// <summary>
        /// Returns the specified date as Month Year (e.g., January 2017) using the current culture
        /// </summary>
        /// <param name="date">The date to convert</param>
        /// <returns>The date represented as Month Year</returns>
        public static string ToMonthTitle(DateTime date)
        {
            return string.Format("{0} {1}", DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month), date.Year);
        }

        public static string ToMonthTitle(DateTime date1, DateTime date2)
        {
            if(date1.IsMonthAndYearEqual(date2))
            {
                return string.Format("{0} {1}", DateTimeFormatInfo.CurrentInfo.GetMonthName(date1.Month), date1.Year);
            }
            else
            {
                return string.Format("{0} {1} - {2} {3}", DateTimeFormatInfo.CurrentInfo.GetMonthName(date1.Month), date1.Year, date2.Month, date2.Year);
            }
        }

        public const string ShortDateString = "d";
        public const string LongDateString = "D";
        public const string ShortTimeString = "t";
        public const string LongTimeString = "T";
        public const string FullDateShortTimeString = "f";
        public const string FullDateLongTimeSecondsStrong = "F";
        public const string GeneralDateShortTimeString = "g";
        public const string GeneralDateLongTimeString = "G";
        public const string RFC1123 = "r";
        public const string Sortable = "s";
        public const string UniversalFullDateTimeString = "U";
        public const string UniversalFullDateSortableString = "u";
        public const string MonthDay = "m";
        public const string YearMonth = "y";
        public const string Invariant = "o";

    }
}
