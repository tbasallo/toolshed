using System;
using System.Collections.Generic;

namespace Toolshed
{
    public static partial class DateHelper
    {
        /// <summary>
        /// Returns a DateOnly representing Today (from DateTime.Today)
        /// </summary>
        /// <returns></returns>
        public static DateOnly Today()
        {
            return DateOnly.FromDateTime(DateTime.Today);
        }
        /// <summary>
        /// Returns a DateOnly representing Tomorrow (from DateTime.Today)
        /// </summary>
        /// <returns></returns>
        public static DateOnly Tomorrow()
        {
            return DateOnly.FromDateTime(DateTime.Today.Tomorrow());
        }
        /// <summary>
        /// Returns a DateOnly representing Yesterday (from DateTime.Today)
        /// </summary>
        /// <returns></returns>
        public static DateOnly Yesterday()
        {
            return DateOnly.FromDateTime(DateTime.Today.Yesterday());
        }


        /// <summary>
        /// Returns the first date of the specified year at 00:00:00:000
        /// </summary>
        public static DateTime GetStartOfYear(int year)
        {
            return new DateTime(year, 1, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Returns the last date of the year provided at 23:59:59
        /// </summary>
        public static DateTime GetEndOfYear(int year)
        {
            return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59);
        }

        /// <summary>
        /// Returns the start date of last year with a time of 00:00:00:000
        /// </summary>
        public static DateTime GetStartOfLastYear()
        {
            return GetStartOfYear(DateTime.Now.Year - 1);
        }

        /// <summary>
        /// Returns the last date of last year at 23:59:59:999
        /// </summary>
        public static DateTime GetEndOfLastYear()
        {
            return GetEndOfYear(DateTime.Now.Year - 1);
        }

        /// <summary>
        /// Returns the first date of the current year at 00:00:00:000
        /// </summary>
        public static DateTime GetStartOfCurrentYear()
        {
            return GetStartOfYear(DateTime.Now.Year);
        }

        /// <summary>
        /// Returns the last date of the current year at 23:59:59
        /// </summary>
        public static DateTime GetEndOfCurrentYear()
        {
            return GetEndOfYear(DateTime.Now.Year);
        }

        /// <summary>
        /// Returns the first date of next year at 00:00:00:000
        /// </summary>
        public static DateTime GetStartOfNextYear()
        {
            return GetStartOfYear(DateTime.Now.Year + 1);
        }

        /// <summary>
        /// Returns the last date of next year at 23:59:59:999
        /// </summary>
        public static DateTime GetEndOfNextYear()
        {
            return GetEndOfYear(DateTime.Now.Year + 1);
        }

        /// <summary>
        /// Returns the number of whole years between two dates
        /// <para>The subtracts two dates' years (i.e (2009 - 2007) = 2)</para>
        /// </summary>
        /// <param name="startDate">The later of the two dates</param>
        /// <param name="endDate">The earlier of the two dates</param>
        /// <returns>The number of years between the provided dates</returns>
        public static int GetYearsBetweenDates(DateTime startDate, DateTime endDate)
        {
            return (startDate.Year - endDate.Year);
        }

        /// <summary>
        /// Returns the first date of the month and year at 00:00:00:000
        /// </summary>
        public static DateTime GetStartOfMonth(int month, int year)
        {
            return new DateTime(year, month, 1, 0, 0, 0, 0);
        }
        

        /// <summary>
        /// Returns the last date of the month and year at 23:59:59
        /// </summary>
        public static DateTime GetEndOfMonth(int month, int year)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59);
        }

        /// <summary>
        /// Returns the first date of last month's month and year at 00:00:00:000
        /// </summary>
        public static DateTime GetStartOfLastMonth()
        {
            var date = DateTime.Today.AddMonths(-1);
            return GetStartOfMonth(date.Month, date.Year);
        }

        /// <summary>
        /// Returns the last date of last month's month and year at 23:59:59
        /// </summary>
        public static DateTime GetEndOfLastMonth()
        {
            var date = DateTime.Today.AddMonths(-1);
            return GetEndOfMonth(date.Month, date.Year);
        }

        /// <summary>
        /// Returns the first date of current month and year at 00:00:00:000
        /// </summary>
        public static DateTime GetStartOfCurrentMonth()
        {
            return GetStartOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }

        /// <summary>
        /// Returns the last date of current month and year at 23:59:59
        /// </summary>
        public static DateTime GetEndOfCurrentMonth()
        {
            return GetEndOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }

        /// <summary>
        /// Returns the first date of next month's month and year at 00:00:00:000
        /// </summary>
        public static DateTime GetStartOfNextMonth()
        {
            var date = DateTime.Today.AddMonths(1);
            return GetStartOfMonth(date.Month, date.Year);
        }

        /// <summary>
        /// Returns the last date of next month's month and year at 23:59:59:999
        /// </summary>
        public static DateTime GetEndOfNextMonth()
        {
            var date = DateTime.Today.AddMonths(1);
            return GetEndOfMonth(date.Month, date.Year);
        }

        /// <summary>
        /// Returns the number of whole months between two dates
        /// <para>30 days per month is used to determine the number of months between the two dates provided.</para>
        /// </summary>
        /// <param name="startDate">The first, earlier of two dates</param>
        /// <param name="endDate">The second, later of two dates</param>
        /// <returns>The number of months (rounded) of month between the two dates</returns>
        public static int GetMonthsBetweenDates(DateTime startDate, DateTime endDate)
        {
            //TODO: need to blog about this particular conundrum
            int days = GetDaysBetweenDates(endDate, startDate);
            double months = days / 30;
            return (int)months;
        }

        /// <summary>
        /// Returns number of whole and fractional months between two dates
        /// <para>An average of 30 days per month is used to determine the number of months between the two dates provided.</para>
        /// </summary>
        public static double GetTotalMonthsBetweenDates(DateTime oldDate, DateTime newDate)
        {
            //TODO: need to blog about this particular conundrum
            int days = GetDaysBetweenDates(oldDate, newDate);
            return days / 30;
        }

        /// <summary>
        /// Returns the date with a time of 00:00:00:000
        /// </summary>
        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, date.Kind);
        }

        /// <summary>
        /// Returns the date with a time of 23:59:59
        /// </summary>
        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, date.Kind);
        }


        /// <summary>
        /// Returns a list of all the dates between two dates inclusive of the start date
        /// <para>The begin date must be before the end date</para>
        /// </summary>
        public static List<DateTime> GetDatesBetweenDates(DateTime startDate, DateTime endDate)
        {
            List<DateTime> list = [];
            if (endDate < startDate)
            {
                return list;
            }

            var date = startDate;
            while (date <= endDate)
            {
                list.Add(date);
                date = date.AddDays(1);
            }

            return list;
        }
        /// <summary>
        /// Returns a list of all the dates between two dates inclusive of the start date
        /// <para>The begin date must be before the end date</para>
        /// </summary>
        public static List<DateOnly> GetDatesBetweenDates(DateOnly startDate, DateOnly endDate)
        {
            var list = new List<DateOnly>();
            if (endDate < startDate)
            {
                return list;
            }

            var date = startDate;
            while (date <= endDate)
            {
                list.Add(date);
                date = date.AddDays(1);
            }

            return list;
        }


        /// <summary>
        /// Returns the number dates between two dates and of the specified day of the week
        /// <para>The begin date must be before the end date</para>
        /// </summary>
        public static List<DateTime> GetDatesBetweenDates(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek)
        {
            List<DateTime> list = new List<DateTime>();
            if (endDate < startDate)
            {
                return list;
            }

            var date = startDate;
            while (date <= endDate)
            {
                if (date.DayOfWeek == dayOfWeek)
                {
                    list.Add(date);
                }
                date = date.AddDays(1);
            }

            return list;
        }
        /// <summary>
        /// Returns the number dates between two dates and of the specified day of the week
        /// <para>The begin date must be before the end date</para>
        /// </summary>
        public static List<DateOnly> GetDatesBetweenDates(DateOnly startDate, DateOnly endDate, DayOfWeek dayOfWeek)
        {
            List<DateOnly> list = new List<DateOnly>();
            if (endDate < startDate)
            {
                return list;
            }

            var date = startDate;
            while (date <= endDate)
            {
                if (date.DayOfWeek == dayOfWeek)
                {
                    list.Add(date);
                }
                date = date.AddDays(1);
            }

            return list;
        }


        /// <summary>
        /// Returns a list of Saturdays between two dates
        /// <para>The begin date must be before the end date</para>
        /// </summary>
        public static List<DateTime> GetSaturdaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            return GetDatesBetweenDates(startDate, endDate, DayOfWeek.Saturday);
        }
        /// <summary>
        /// Returns a list of Saturdays between two dates
        /// <para>The begin date must be before the end date</para>
        /// </summary>
        public static List<DateOnly> GetSaturdaysBetweenDates(DateOnly startDate, DateOnly endDate)
        {
            return GetDatesBetweenDates(startDate, endDate, DayOfWeek.Saturday);
        }
        /// <summary>
        /// Returns a list of Sundays between two dates
        /// <para>The begin date must be before the end date</para>
        /// </summary>
        public static List<DateOnly> GetSundaysBetweenDates(DateOnly startDate, DateOnly endDate)
        {
            return GetDatesBetweenDates(startDate, endDate, DayOfWeek.Sunday);
        }
        /// <summary>
        /// Returns a list of Sundays between two dates
        /// <para>The begin date must be before the end date</para>
        /// </summary>
        public static List<DateTime> GetSundaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            return GetDatesBetweenDates(startDate, endDate, DayOfWeek.Sunday);
        }

        /// <summary>
        /// Returns a list of Saturdays remaining in the current year
        /// </summary>
        public static List<DateTime> GetSaturdaysInCurrentYear()
        {
            return GetDatesBetweenDates(GetStartOfCurrentYear(), GetEndOfCurrentYear(), DayOfWeek.Saturday);
        }

        /// <summary>
        /// Returns a list of Sundays remaining in the current year
        /// </summary>
        public static List<DateTime> GetSundaysInCurrentYear()
        {
            return GetDatesBetweenDates(GetStartOfCurrentYear(), GetEndOfCurrentYear(), DayOfWeek.Sunday);
        }

        /// <summary>
        /// Returns a list of Saturdays from the beginning of the year through today
        /// </summary>
        public static List<DateTime> GetSaturdaysThroughToday()
        {
            return GetDatesBetweenDates(GetStartOfCurrentYear(), DateTime.Today, DayOfWeek.Saturday);
        }

        /// <summary>
        /// Returns a list of Sundays from the beginning of the year through today
        /// </summary>
        public static List<DateTime> GetSundaysThroughToday()
        {
            return GetDatesBetweenDates(GetStartOfCurrentYear(), DateTime.Today, DayOfWeek.Sunday);
        }



        /// <summary>
        /// Returns a list of all the dates that overlap between two date ranges
        /// <param name="startDate1">The start date of the first range</param>
        /// <param name="endDate1">The end date of the first range</param>
        /// <param name="startDate2">The start date of the second range</param>
        /// <param name="endDate2">The end date of the second range</param>
        /// <param name="ignoreTime">Indicates whether the time component should be ignored</param>
        /// <returns></returns>
        public static List<DateTime> GetOverlappingDates(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2, bool ignoreTime)
        {
            if (ignoreTime)
            {
                startDate1 = startDate1.Date;
                endDate1 = endDate1.Date;
                startDate2 = startDate2.Date;
                endDate2 = endDate2.Date;
            }

            var overlapStart = startDate1 > startDate2 ? startDate1 : startDate2;
            var overlapEnd = endDate1 < endDate2 ? endDate1 : endDate2;

            List<DateTime> overlappingDates = new List<DateTime>();
            if (overlapStart <= overlapEnd)
            {
                for (var date = overlapStart; date <= overlapEnd; date = date.AddDays(1))
                {
                    overlappingDates.Add(date);
                }
            }

            return overlappingDates;
        }

    }
}
