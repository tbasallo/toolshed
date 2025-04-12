// <copyright file="DateHelper_Booleans.cs" company="WebChanix">
//  This source is subject to the Microsoft Permissive License. 
//  See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.  
//  All other rights reserved.
// </copyright>
// WebChanix, Webchanix.com
// Original Author: Tony Basallo
// This is a partial class for the DateHelper class - broken down into date components to make it easier to work with
//This file deals with functions that return true/false

namespace Toolshed
{
    using System;

    public partial class DateHelper
    {
        /// <summary>
        /// Returns whether the specified date is a Saturday or Sunday.
        /// </summary>
        /// <param name="date">A System.DateTime </param>
        /// <returns>A boolen indicating whether the date in the parameter was on a Sunday or Saturday.</returns>
        public static bool IsWeekend(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
        }

        /// <summary>
        /// Returns whether the specified date is the the current month and year.
        /// </summary>
        /// <param name="date">A System.DateTime </param>
        /// <returns>A boolen indicating whether the date in the paramter is the the current month and year.</returns>
        public static bool IsCurrentMonthAndYear(DateTime date)
        {
            return IsMonthAndYearEqual(DateTime.Now, date);
        }

        /// <summary>
        /// Returns a boolean indicating whether the specified month and year are the same as the current date's month and year
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <returns>A boolean indicating whether the specified month and year are the same as the current date's month and year</returns>
        public static bool IsCurrentMonthAndYear(int year, int month)
        {
            return IsCurrentMonthAndYear(new DateTime(year, month, 1));
        }

        /// <summary>
        /// Returns a boolean indicating whether the specified date is the following month and year.
        /// </summary>
        /// <param name="date">A System.DateTime</param>
        /// <returns>A boolean indicating whether the specified date is the following month and year.</returns>
        public static bool IsNextMonthAndYear(DateTime date)
        {
            return IsMonthAndYearEqual(DateTime.Now.AddMonths(1), date);
        }

        /// <summary>
        /// Returns a boolean indicating whether the specified month and year is the following month and year.
        /// </summary>
        /// <param name="date">A System.DateTime</param>
        /// <returns>A boolean indicating whether the specified month and year is the following month and year.</returns>
        public static bool IsNextMonthAndYear(int year, int month)
        {
            return IsNextMonthAndYear(new DateTime(year, month, 1));
        }

        /// <summary>
        /// Returns a boolean indicating whether the specified date is the previous month and year.
        /// </summary>
        /// <param name="date">A System.DateTime</param>
        /// <returns>A boolean indicating whether the specified date is the previous month and year.</returns>
        public static bool IsPreviousMonthAndYear(DateTime date)
        {
            return IsMonthAndYearEqual(DateTime.Now.AddMonths(-1), date);
        }

        /// <summary>
        /// Returns a boolean indicating whether the specified month and year is the previous month and year.
        /// </summary>
        /// <param name="date">A System.DateTime</param>
        /// <returns>A boolean indicating whether the specified month and year is the previous month and year.</returns>
        public static bool IsPreviousMonthAndYear(int year, int month)
        {
            return IsPreviousMonthAndYear(new DateTime(year, month, 1));
        }

        /// <summary>
        /// Returns a boolean indicating whether the specified dates are in the same year and the same month.
        /// </summary>
        /// <param name="date">A System.DateTime</param>
        /// <returns>A boolean indicating whether the specified dates are in the same year and the same month.</returns>
        public static bool IsMonthAndYearEqual(DateTime dateOne, DateTime dateTwo)
        {
            if (dateOne.Year == dateTwo.Year)
            {
                if (dateOne.Month == dateTwo.Month)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Returns a boolean indicating whether the specified dates are in the same year and the same month.
        /// </summary>
        /// <param name="date">A System.DateTime</param>
        /// <returns>A boolean indicating whether the specified dates are in the same year and the same month.</returns>
        public static bool IsMonthAndYearEqual(DateOnly dateOne, DateOnly dateTwo)
        {
            if (dateOne.Year == dateTwo.Year)
            {
                if (dateOne.Month == dateTwo.Month)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Indicates whether the specified date is equal to DateTime.Today (no time component) (UTC)
        /// </summary>
        public static bool IsDateEqualToToday(DateTime date)
        {
            return DateHelper.GetStartOfDay(date) == DateTime.Today;
        }

        /// <summary>
        /// Indicates whether the dates provided for 1 and 2 overlap, the times are considered.
        /// <param name="startDate1">The start date of the first range</param>
        /// <param name="endDate1">The end date of the first range</param>
        /// <param name="startDate2">The start date of the second range</param>
        /// <param name="endDate2">The end date of the second range</param>
        /// <param name="ignoreTime">Indicates whether the time component should be ignored</param>
        /// <returns></returns>
        public static bool IsOverlappingDates(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2, bool ignoreTime)
        {
            if (ignoreTime)
            {
                return startDate1.Date <= endDate2.Date && endDate1.Date >= startDate2.Date;
            }

            return startDate1 <= endDate2 && endDate1 >= startDate2;
        }

        /// <summary>
        /// Indicates whether the dates provided for 1 and 2 overlap        
        /// <param name="startDate1">The start date of the first range</param>
        /// <param name="endDate1">The end date of the first range</param>
        /// <param name="startDate2">The start date of the second range</param>
        /// <param name="endDate2">The end date of the second range</param>
        /// <returns></returns>
        public static bool IsOverlappingDates(DateOnly startDate1, DateOnly endDate1, DateOnly startDate2, DateOnly endDate2)
        {
            return startDate1 <= endDate2 && endDate1 >= startDate2;
        }
    }
}
