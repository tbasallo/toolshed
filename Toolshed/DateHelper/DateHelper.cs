using System;

namespace Toolshed
{
    /// <summary>
    /// Various static methods that perform routinely performed actions on dates and times
    /// </summary>
    public static partial class DateHelper
    {
        /// <summary>
        /// Returns the whole number of days between two dates
        /// <para>The oldDate is subtracted from the new date and the difference returned</para>
        /// </summary>
        public static int GetDaysBetweenDates(DateTime oldDate, DateTime newDate)
        {
            return (newDate - oldDate).Days;
        }

        /// <summary>
        /// Returns the whole and fractional number of days between two dates
        /// <para>The oldDate is subtracted from the new date and the difference returned</para>
        /// </summary>
        public static double GetTotalDaysBetweenDates(DateTime oldDate, DateTime newDate)
        {
            return (newDate - oldDate).TotalDays;
        }

    }
}
