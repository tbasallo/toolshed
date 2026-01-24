namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        /// <summary>
        /// Indicates whether this is in the previous month as it relates to today
        /// </summary>
        public static bool IsPreviousMonthAndYear(this DateTime date)
        {
            return DateHelper.IsPreviousMonthAndYear(date);
        }
        /// <summary>
        /// Indicates whether this is in the previous month as it relates to today
        /// </summary>
        public static bool IsPreviousMonthAndYear(this DateOnly date)
        {
            return DateHelper.IsPreviousMonthAndYear(date);
        }
        /// <summary>
        /// Indicates whether this is in the previous month as it relates to today
        /// </summary>
        public static bool IsNextMonthAndYear(this DateTime date)
        {
            return DateHelper.IsNextMonthAndYear(date);
        }
        /// <summary>
        /// Indicates whether this is in the previous month as it relates to today
        /// </summary>
        public static bool IsNextMonthAndYear(this DateOnly date)
        {
            return DateHelper.IsNextMonthAndYear(date);
        }

        /// <summary>
        /// Indicates whether this is the current month and year
        /// </summary>
        public static bool IsCurrentMonthAndYear(this DateTime date)
        {
            return DateHelper.IsCurrentMonthAndYear(date);
        }
        /// <summary>
        /// Indicates whether this is the current month and year
        /// </summary>
        public static bool IsCurrentMonthAndYear(this DateOnly date)
        {
            return DateHelper.IsCurrentMonthAndYear(date);
        }

        /// <summary>
        /// Indicates whether this is the current year
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsCurrentYear(this DateTime date)
        {
            return date.Year == DateTime.Now.Year;
        }
        /// <summary>
        /// Indicates whether this is the current year
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsCurrentYear(this DateOnly date)
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
        /// Indicates whether this date's month and year are equal to the specified date
        /// </summary>
        public static bool IsMonthAndYearEqual(this DateOnly thisDate, DateOnly date)
        {
            return DateHelper.IsMonthAndYearEqual(thisDate, date);
        }




        /// <summary>
        /// Indicates whether this is a Saturday or Sunday
        /// </summary>
        public static bool IsWeekend(this DateTime date)
        {
            return DateHelper.IsWeekend(date);
        }
        /// <summary>
        /// Indicates whether this is a Saturday or Sunday
        /// </summary>
        public static bool IsWeekend(this DateOnly date)
        {
            return DateHelper.IsWeekend(date);
        }
        /// <summary>
        /// Indicates whether the specified date is equal to DateTime.Today (no time component) (UTC)
        /// </summary>
        public static bool IsToday(this DateTime date)
        {
            return (date.Date == DateTime.Today.Date);
        }
        /// <summary>
        /// Indicates whether the specified date is equal to DateTime.Today (no time component) (UTC)
        /// </summary>
        public static bool IsToday(this DateOnly date)
        {
            return (date == DateOnly.FromDateTime(DateTime.Today));
        }

        /// <summary>
        /// Indicates whether the specified date is yesterday (.Date == DateTime.Today.AddDays(-1))
        /// </summary>
        public static bool IsYesterday(this DateTime date)
        {
            return (date.Date == DateTime.Today.AddDays(-1).Date);
        }
        /// <summary>
        /// Indicates whether the specified date is yesterday (.Date == DateTime.Today.AddDays(-1))
        /// </summary>
        public static bool IsYesterday(this DateOnly date)
        {
            return (date == DateOnly.FromDateTime(DateTime.Today).AddDays(-1));
        }

        /// <summary>
        /// Indicates whether the specified date is tomorrow (.Date == DateTime.Today.AddDays(1))
        /// </summary>
        public static bool IsTomorrow(this DateTime date)
        {
            return (date.Date == DateTime.Today.AddDays(1).Date);
        }
        /// <summary>
        /// Indicates whether the specified date is tomorrow (.Date == DateTime.Today.AddDays(1))
        /// </summary>
        public static bool IsTomorrow(this DateOnly date)
        {
            return (date == DateOnly.FromDateTime(DateTime.Today).AddDays(1));
        }

        /// <summary>
        /// Indicates whether the specified date is in the future
        /// </summary>
        /// <param name="date"></param>
        /// <param name="ignoreTime">Indicates that the time should be ignored or not</param>
        /// <returns></returns>
        public static bool IsFuture(this DateTime date, bool ignoreTime = true)
        {
            if (ignoreTime)
            {
                if (date.Kind != DateTimeKind.Local)
                {
                    return (date.Date > DateTime.UtcNow.Date);
                }
                else
                {
                    return (date.Date > DateTime.Today.Date);
                }
            }
            else
            {
                if (date.Kind != DateTimeKind.Local)
                {
                    return (date > DateTime.UtcNow);
                }
                else
                {
                    return (date > DateTime.Now);
                }
            }
        }
        /// <summary>
        /// Indicates whether the specified date is in the future
        /// </summary>
        public static bool IsFuture(this DateOnly date)
        {
            return (date > DateOnly.FromDateTime(DateTime.Today));
        }

        /// <summary>
        /// Indicates whether the specified date is in the past
        /// </summary>
        /// <param name="date"></param>
        /// <param name="ignoreTime">Indicates that the time should be ignored or not</param>
        /// <returns></returns>
        public static bool IsPast(this DateTime date, bool ignoreTime = true)
        {
            if (ignoreTime)
            {
                if (date.Kind != DateTimeKind.Local)
                {
                    return (date.Date < DateTime.UtcNow.Date);
                }
                else
                {
                    return (date.Date < DateTime.Today.Date);
                }
            }
            else
            {
                if (date.Kind != DateTimeKind.Local)
                {
                    return (date < DateTime.UtcNow);
                }
                else
                {
                    return (date < DateTime.Now);
                }
            }
        }
        /// <summary>
        /// Indicates whether the specified date is in the past
        /// </summary>
        public static bool IsPast(this DateOnly date)
        {
            return (date < DateOnly.FromDateTime(DateTime.Today));
        }

        /// <summary>
        /// Indicates whether the specified dates are equal (no time component) (UTC)
        /// </summary>
        public static bool IsDateEqualTo(this DateTime date, DateTime dateTwo)
        {
            return date.Date == dateTwo.Date;
        }
        /// <summary>
        /// Indicates whether the specified dates are equal
        /// </summary>
        public static bool IsDateEqualTo(this DateOnly date, DateOnly dateTwo)
        {
            return date == dateTwo;
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
        /// Indicates whether the specified date is an actual date, not null, not year 9999 and not less than year 0002
        /// </summary>
        public static bool IsRealDate(this DateOnly? date)
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
        /// <summary>
        /// Indicates whether the specified date is an actual date, not year 9999 and not less than year 0002 and not min or max date
        /// </summary>
        public static bool IsRealDate(this DateOnly date)
        {
            if (date.Year == 9999 || date == DateOnly.MaxValue || date == DateOnly.MinValue || date.Year < 0002)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Indicates whether this date is in range of the two specified dates, ONLY the date component (use IsInRange for complete date time) (>= Start, <= End). The Kind is not checked or converted
        /// </summary>
        /// <returns>Bool</returns>
        public static bool IsDateInRange(this DateTime date, DateTime startDate, DateTime endDate)
        {
            return date.Date >= startDate.Date && date.Date <= endDate.Date;
        }

        /// <summary>
        /// Indicates whether this date is in range of the two specified dates, ONLY the date component (use IsInRange for complete date time) (>= Start, <= End). The Kind is not checked or converted
        /// </summary>
        /// <returns>Bool</returns>
        public static bool IsDateInRange(this DateOnly date, DateOnly startDate, DateOnly endDate)
        {
            return date >= startDate && date <= endDate;
        }

        /// <summary>
        /// Indicates whether this date is in range of the two specified dates, ONLY the date component (use IsInRange for complete date time) (>= Start, <= End). The Kind is not checked or converted
        /// </summary>
        /// <returns>Bool</returns>
        public static bool IsInRange(this DateOnly date, DateOnly startDate, DateOnly endDate)
        {
            return date >= startDate && date <= endDate;
        }

        /// <summary>
        /// Indicates whether this date is in range of the two specified dates, ONLY the date component (use IsInRange for complete date time) (>= Start, <= End). The Kind is not checked or converted
        /// </summary>
        /// <returns>Bool</returns>
        public static bool IsInRange(this DateOnly date, DateTime startDate, DateTime endDate)
        {
            return date >= startDate.AsDateOnly() && date <= endDate.AsDateOnly();
        }

        /// <summary>
        /// Indicates whether this date is in range of the two specified dates, including the time (>= Start, <= End). The Kind is not checked or converted
        /// </summary>
        /// <returns>Bool</returns>
        public static bool IsInRange(this DateTime date, DateTime startDate, DateTime endDate)
        {
            return date >= startDate && date <= endDate;
        }

        /// <summary>
        /// Indicates whether the specified date is an acceptable SQL Server date, which is greater than the year 1753
        /// </summary>
        public static bool IsValidSqlDate(this DateTime date)
        {
            return date.Year >= 1753;
        }
        /// Indicates whether the specified date is an acceptable SQL Server date, which is greater than the year 1753
        /// Indicates whether the specified date is an actual date, not year 9999 and not less than year 0002 and not min or max date
        /// </summary>
        public static bool IsValidSqlDate(this DateOnly date)
        {
            return date.Year >= 1753;
        }
    }
}