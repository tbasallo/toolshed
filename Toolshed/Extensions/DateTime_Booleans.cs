using System;
using System.Collections.Generic;
using System.Globalization;

namespace Toolshed
{
    public static partial class DateHelperExtensions
    {

        /// <summary>
        /// Indicates whether this is a Saturday or Sunday
        /// </summary>
        public static bool IsWeekend(this DateTime date)
        {
            return DateHelper.IsWeekend(date);
        }

        /// <summary>
        /// Indicates whether this is the current month and year
        /// </summary>
        public static bool IsCurrentMonthAndYear(this DateTime date)
        {
            return DateHelper.IsCurrentMonthAndYear(date);
        }

        /// <summary>
        /// Indicates 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsCurrentYear(this DateTime date)
        {
            return date.Year == DateTime.Now.Year;
        }

        /// <summary>
        /// Indicates whether this date's month and year are equal to the specified date
        /// </summary>
        public static bool IsMonthAndYearEqual(this DateTime thisDate, DateTime date)
        {
            return DateHelper.IsMonthAndYearEqual(thisDate, date);
        }

        /// <summary>
        /// Indicates whether the specified date is equal to DateTime.Today (no time component) (UTC)
        /// </summary>
        public static bool IsToday(this DateTime date)
        {
            return (date.Date == DateTime.Today.Date);
        }
       
        /// <summary>
        /// Indicates whether the specified date is yesterday (.Date == DateTime.Today.AddDays(-1))
        /// </summary>
        public static bool IsYesterday(this DateTime date)
        {
            return (date.Date == DateTime.Today.AddDays(-1).Date);
        }
        
        /// <summary>
        /// Indicates whether the specified date is tomorrow (.Date == DateTime.Today.AddDays(1))
        /// </summary>
        public static bool IsTomorrow(this DateTime date)
        {
            return (date.Date == DateTime.Today.AddDays(1).Date);
        }

        /// <summary>
        /// Indicates whether the specified dates are equal (no time component) (UTC)
        /// </summary>
        private static bool IsDateEqualTo(this DateTime date, DateTime dateTwo)
        {
            return date.Date == dateTwo.Date;
        }
        
        /// <summary>
        /// Indicates whether the specified date is an actual date, not null, not year 9999 and not less than year 0002
        /// </summary>
        public static bool IsRealDate(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.IsRealDate();
            }

            return false;
        }
        
        /// <summary>
        /// Indicates whether the specified date is an actual date, not year 9999 and not less than year 0002 and not min or max date
        /// </summary>
        public static bool IsRealDate(this DateTime date)
        {
            if (date.Year == 9999 || date == DateTime.MaxValue || date == DateTime.MinValue || date.Year < 0002)
            {
                return false;
            }

            return true;
        }
    }
}