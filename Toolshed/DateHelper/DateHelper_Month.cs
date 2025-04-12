using System;
using System.Collections.Generic;

namespace Toolshed
{
    public static partial class DateHelper
    {
        public static List<DateTime> GetMonthYearsBetweenDates(DateTime beginDate, DateTime endDate)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime currDate = beginDate.StartOfMonth();
            endDate = endDate.EndOfMonth();
            while (currDate < endDate)
            {
                dates.Add(currDate);
                currDate = currDate.AddMonths(1);
            }

            return dates;
        }

    }
}
