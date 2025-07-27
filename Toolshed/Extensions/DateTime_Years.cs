namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        /// <summary>
        /// Returns the first date of the year with a time of 00:00:00:000
        /// </summary>
        public static DateTime StartOfYear(this DateTime date)
        {
            return DateHelper.GetStartOfYear(date.Year);
        }

        /// <summary>
        /// Returns the first date of next year with a time of 00:00:00:000
        /// </summary>
        public static DateTime StartOfNextYear(this DateTime date)
        {
            return DateHelper.GetStartOfYear(date.AddYears(1).Year);
        }

        /// <summary>
        /// Returns the first date of next year with a time of 00:00:00:000
        /// </summary>
        public static DateTime StartOfPreviousYear(this DateTime date)
        {
            return DateHelper.GetStartOfYear(date.AddYears(-1).Year);
        }

        /// <summary>
        /// Returns the last date of the year with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfYear(this DateTime date)
        {
            return DateHelper.GetEndOfYear(date.Year);
        }

        /// <summary>
        /// Returns the last date of next year with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfNextYear(this DateTime date)
        {
            return DateHelper.GetEndOfYear(date.AddYears(1).Year);
        }

        /// <summary>
        /// Returns the last date of the year with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfPreviousYear(this DateTime date)
        {
            return DateHelper.GetEndOfYear(date.AddYears(-1).Year);
        }

        /// <summary>
        /// Returns the number of whole years between the current and specified date
        /// <para>The current date will be subtracted from the current date and the difference returned</para>
        /// </summary>
        public static int TotalYearsToDate(this DateTime thisdate, DateTime date)
        {
            return DateHelper.GetYearsBetweenDates(thisdate, date);
        }

        /// <summary>
        /// Returns a list of the remaining dates of from this date
        /// </summary>
        public static List<DateTime> RemainingDatesOfYear(this DateTime date)
        {
            return DateHelper.GetDatesBetweenDates(date, date.EndOfYear());
        }

        /// <summary>
        /// Returns all dates remaining this year with the specified day of week
        /// </summary>
        public static List<DateTime> RemainingDatesOfYear(this DateTime date, DayOfWeek dayOfWeek)
        {
            return DateHelper.GetDatesBetweenDates(date, date.EndOfYear(), dayOfWeek);
        }
    }
}