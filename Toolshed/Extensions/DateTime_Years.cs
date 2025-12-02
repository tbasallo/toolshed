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
        /// Returns the first date of the year
        /// </summary>
        public static DateOnly StartOfYear(this DateOnly date)
        {
            return DateHelper.GetStartDateOfYear(date.Year);
        }

        /// <summary>
        /// Returns the first date of next year with a time of 00:00:00:000
        /// </summary>
        public static DateTime StartOfNextYear(this DateTime date)
        {
            return DateHelper.GetStartOfYear(date.AddYears(1).Year);
        }

        /// <summary>
        /// Returns the first date of next year
        /// </summary>
        public static DateOnly StartOfNextYear(this DateOnly date)
        {
            return DateHelper.GetStartDateOfYear(date.AddYears(1).Year);
        }

        /// <summary>
        /// Returns the first date of next year with a time of 00:00:00:000
        /// </summary>
        public static DateTime StartOfPreviousYear(this DateTime date)
        {
            return DateHelper.GetStartOfYear(date.AddYears(-1).Year);
        }

        /// <summary>
        /// Returns the first date of next year with a time of 00:00:00:000
        /// </summary>
        public static DateOnly StartOfPreviousYear(this DateOnly date)
        {
            return DateHelper.GetStartDateOfYear(date.AddYears(-1).Year);
        }

        /// <summary>
        /// Returns the last date of the year with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfYear(this DateTime date)
        {
            return DateHelper.GetEndOfYear(date.Year);
        }

        /// <summary>
        /// Returns the last date of the year
        /// </summary>
        public static DateOnly EndOfYear(this DateOnly date)
        {
            return DateHelper.GetEndDateOfYear(date.Year);
        }

        /// <summary>
        /// Returns the last date of next year with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfNextYear(this DateTime date)
        {
            return DateHelper.GetEndOfYear(date.AddYears(1).Year);
        }

        /// <summary>
        /// Returns the last date of next year
        /// </summary>
        public static DateOnly EndOfNextYear(this DateOnly date)
        {
            return DateHelper.GetEndDateOfYear(date.AddYears(1).Year);
        }

        /// <summary>
        /// Returns the last date of the previous year with a time of 23:59:59:999
        /// </summary>
        public static DateTime EndOfPreviousYear(this DateTime date)
        {
            return DateHelper.GetEndOfYear(date.AddYears(-1).Year);
        }

        /// <summary>
        /// Returns the last date of the previous year
        /// </summary>
        public static DateOnly EndOfPreviousYear(this DateOnly date)
        {
            return DateHelper.GetEndDateOfYear(date.AddYears(-1).Year);
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
        /// Returns the number of whole years between the current and specified date
        /// <para>The current date will be subtracted from the current date and the difference returned</para>
        /// </summary>
        public static int TotalYearsToDate(this DateOnly thisdate, DateOnly date)
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
        /// Returns a list of the remaining dates of from this date
        /// </summary>
        public static List<DateOnly> RemainingDatesOfYear(this DateOnly date)
        {
            return DateHelper.GetDatesBetweenDates(date, date.EndOfYear());
        }        
    }
}