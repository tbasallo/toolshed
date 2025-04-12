using System;
using System.Collections.Generic;
using System.Globalization;

using static System.Net.Mime.MediaTypeNames;

namespace Toolshed;

public static partial class DateHelperExtensions
{
    /// <summary>
    /// Returns the month name using the Current Culture
    /// </summary>
    public static string ToMonthName(this DateOnly date)
    {
        return DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month);
    }

    /// <summary>
    /// Returns the abbreviated month name using the Current Culture
    /// </summary>
    public static string ToMonthNameAbbreviated(this DateOnly date)
    {
        return DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(date.Month);
    }


    /// <summary>
    /// Returns the start of the moth with a time of 00:00:00:000
    /// </summary>
    public static DateOnly StartOfMonth(this DateOnly date)
    {
        return new DateOnly(date.Month, date.Year, 1);
    }

    /// <summary>
    /// Returns the start of the next month with a time of 00:00:00:000
    /// </summary>
    public static DateOnly StartOfNextMonth(this DateOnly date)
    {
        date = date.AddMonths(1);
        return date.StartOfMonth();
    }

    /// <summary>
    /// Returns the start of the previous month with a time of 00:00:00:000
    /// </summary>
    public static DateOnly StartOfPreviousMonth(this DateOnly date)
    {
        date = date.AddMonths(-1);
        return date.StartOfMonth();
    }

    /// <summary>
    /// returns the last date of teh month with a time of 23:59:59:999
    /// </summary>
    public static DateOnly EndOfMonth(this DateOnly date)
    {
        return new DateOnly(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));            
    }

    /// <summary>
    /// returns the last date of next month with a time of 23:59:59:999
    /// </summary>
    public static DateOnly EndOfNextMonth(this DateOnly date)
    {
        date = date.AddMonths(1);
        return date.EndOfMonth();
    }

    /// <summary>
    /// returns the last date of the previous month with a time of 23:59:59:999
    /// </summary>
    public static DateOnly EndOfPreviousMonth(this DateOnly date)
    {
        date = date.AddMonths(-1);
        return date.EndOfMonth();
    }

    /// <summary>
    /// Returns total months between the current and specified date
    /// <para>The current date is subtracted form teh specified date and the difference returned</para>
    /// </summary>
    public static int GetMonthsBetweenDates(this DateOnly date, DateOnly endDate)
    {
        var many = 0;
        var currDate = date.StartOfMonth();
        endDate = endDate.EndOfMonth();
        while (currDate < endDate)
        {
            many++;                
        }

        return many;
    }
}