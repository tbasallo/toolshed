using System.Globalization;

namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        /// <summary>
        /// Returns a long string representation using the ToLongDateString() and ToLongTimeString() methods
        /// <para>The string is formatted as "Date, Time"</para>
        /// </summary>
        public static string ToDateTimeLongString(this DateTime date)
        {
            return string.Format("{0}, {1}", date.ToLongDateString(), date.ToLongTimeString());
        }

        /// <summary>
        /// Returns a short date and time string representation using the ToShortDateString() and ToShortTimeString()
        /// <para>The string is formatted as "Date, Time"</para>
        /// </summary>
        public static string ToShortDateTimeString(this DateTime date)
        {
            return string.Format("{0}, {1}", date.ToShortDateString(), date.ToShortTimeString());
        }

        /// <summary>
        /// Returns the shortest time possible using only actual values. E.G, for a time of 6:00 6 PM is returned.
        /// </summary>
        public static string ToShortestTimeString(this DateTime date, bool? includeSpaceBetween = null)
        {
            includeSpaceBetween ??= DateTimeSettings.SpaceBetweenTimeOfDay;

            if (date.Second == 0)
            {
                if (date.Minute == 0)
                {
                    if (includeSpaceBetween.GetValueOrDefault())
                    {
                        return date.ToString("h tt");
                    }
                    else
                    {
                        return date.ToString("htt");
                    }
                }

                if (includeSpaceBetween.GetValueOrDefault())
                {
                    return date.ToString("h:mm tt");
                }
                else
                {
                    return date.ToString("h:mmtt");
                }
            }

            return date.ToShortTimeString();
        }

        /// <summary>
        /// Returns the shortest time possible using only actual values. E.G, for a time of 6:00 6 PM is returned.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="includeSpaceBetween">Determines whether to include a space between the time and time of day, i.e. 9AM vs 9 AM.
        /// You can set the default values using DateTimeSettings.SpaceBetweenTimeOfDay </param>
        /// <returns></returns>
        public static string ToShortestTimeString(this TimeOnly time, bool? includeSpaceBetween = null)
        {
            includeSpaceBetween ??= DateTimeSettings.SpaceBetweenTimeOfDay;

            if (time.Second == 0)
            {
                if (time.Minute == 0)
                {
                    if (includeSpaceBetween.GetValueOrDefault())
                    {
                        return time.ToString("h tt");
                    }
                    else
                    {
                        return time.ToString("htt");
                    }
                }

                if (includeSpaceBetween.GetValueOrDefault())
                {
                    return time.ToString("h:mm tt");
                }
                else
                {
                    return time.ToString("h:mmtt");
                }
            }

            return time.ToShortTimeString();
        }


        /// <summary>
        /// Returns the day name using the current culture
        /// </summary>
        public static string DayName(this DateTime date)
        {
            return DateTimeFormatInfo.CurrentInfo.GetDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Returns a URL friendly string of the date using the specified delimiter or default.
        /// </summary>
        /// <param name="delimiter">The string to use to delimit the date parts</param>
        /// <returns>A string like 12-31-1977</returns>
        public static string ToUrlFriendly(this DateTime date, string? delimiter = null)
        {
            return DateHelper.ToUrlFriendly(date, delimiter);
        }
        /// <summary>
        /// Returns a URL friendly string of the date using the specified delimiter or default.
        /// </summary>
        /// <param name="delimiter">The string to use to delimit the date parts</param>
        /// <returns>A string like 12-31-1977</returns>
        public static string ToUrlFriendly(this DateTime? date, string? delimiter = null)
        {
            if (date.HasValue)
            {
                return date.Value.ToUrlFriendly(delimiter);
            }

            return "";
        }
        /// <summary>
        /// Returns a URL friendly string of the date using the specified delimiter or default.
        /// </summary>
        /// <param name="delimiter">The string to use to delimit the date parts</param>
        /// <returns>A string like 12-31-1977</returns>
        public static string ToUrlFriendly(this DateOnly date, string? delimiter = null)
        {
            return DateHelper.ToUrlFriendly(date, delimiter);
        }
        /// <summary>
        /// Returns a URL friendly string of the date using the specified delimiter or default.
        /// </summary>
        /// <param name="delimiter">The string to use to delimit the date parts</param>
        /// <returns>A string like 12-31-1977</returns>
        public static string ToUrlFriendly(this DateOnly? date, string? delimiter = null)
        {
            if (date.HasValue)
            {
                return date.Value.ToUrlFriendly(delimiter);
            }

            return "";
        }


        /// <summary>
        /// Compares two dates to determine how to display them
        /// </summary>
        public static string ToTitle(this DateOnly date, DateOnly? endDate = null)
        {
            return DateHelper.ToTitle(date, endDate);
        }

        /// <summary>
        /// Compares two dates to determine how to display them
        /// </summary>
        public static string ToTitle(this DateTime date, DateTime? endDate = null)
        {
            return DateHelper.ToTitle(date, endDate);
        }


        /// <summary>
        /// Returns the specified date as Month Year (e.g., January 2017)
        /// </summary>
        /// <param name="date">The date to convert</param>
        /// <returns>The date represented as Month Year</returns>
        public static string ToMonthTitle(this DateOnly date)
        {
            return DateHelper.ToMonthTitle(date);
        }

        /// <summary>
        /// Returns the specified date as Month Year (e.g., January 2017)
        /// </summary>
        /// <param name="date">The date to convert</param>
        /// <returns>The date represented as Month Year</returns>
        public static string ToMonthTitle(this DateOnly date, DateOnly date2)
        {
            return DateHelper.ToMonthTitle(date, date2);
        }

        /// <summary>
        /// Returns the specified date as Month Year (e.g., January 2017)
        /// </summary>
        /// <param name="date">The date to convert</param>
        /// <returns>The date represented as Month Year</returns>
        public static string ToMonthTitle(this DateTime date)
        {
            return DateHelper.ToMonthTitle(date);
        }

        /// <summary>
        /// Returns the specified date as Month Year (e.g., January 2017)
        /// </summary>
        /// <param name="date">The date to convert</param>
        /// <returns>The date represented as Month Year</returns>
        public static string ToMonthTitle(this DateTime date, DateTime date2)
        {
            return DateHelper.ToMonthTitle(date, date2);
        }

        /// <summary>
        /// Returns the specified date in the format provided if the DateTime? has a value,
        /// otherwise returns the defaultValue provided or an empty string
        /// </summary>
        /// <param name="format">The format that the date should be returned in</param>
        public static string ToValue(this DateTime? date, string format, string defaultValue = "")
        {
            if (!date.HasValue) return defaultValue;

            return date.Value.ToString(format);
        }

        /// <summary>
        /// Returns the specified date in the format provided if the DateTime? has a value,
        /// otherwise returns the defaultValue provided or an empty string
        /// </summary>
        /// <param name="format">The format that the date should be returned in</param>
        public static string ToValue(this DateTimeOffset? date, string format, string defaultValue = "")
        {
            if (!date.HasValue) return defaultValue;

            return date.Value.ToString(format);
        }

        /// <summary>
        /// Returns the specified date in the format provided if the DateOnly? has a value,
        /// otherwise returns the defaultValue provided or an empty string
        /// </summary>
        /// <param name="format">The format that the date should be returned in</param>
        public static string ToValue(this DateOnly? date, string format, string defaultValue = "")
        {
            if (!date.HasValue) return defaultValue;

            return date.Value.ToString(format);
        }

        /// <summary>
        /// Returns the specified date using the format string provided.
        /// Any string can be used to make a complete string so the {0: [format]} should be used.
        /// If only optionally formatting a string is desired, use ToValue().
        /// If the data does not have a value, the defaultValue will be returned, if provided, otherwise, an empty string
        /// </summary>
        /// <param name="format">The complete format to use (i.e., The date is {0:d})</param>
        public static string ToFormat(this DateTime? date, string format, string defaultValue = "")
        {
            if (!date.HasValue) return defaultValue;

            return string.Format(format, date.Value);
        }

        /// <summary>
        /// Returns the specified date using the format string provided.
        /// Any string can be used to make a complete string so the {0: [format]} should be used.
        /// If only optionally formatting a string is desired, use ToValue().
        /// If the data does not have a value, the defaultValue will be returned, if provided, otherwise, an empty string
        /// </summary>
        /// <param name="format">The complete format to use (i.e., The date is {0:d})</param>
        public static string ToFormat(this DateTimeOffset? date, string format, string defaultValue = "")
        {
            if (!date.HasValue) return defaultValue;

            return string.Format(format, date.Value);
        }

        /// <summary>
        /// Returns the specified date using the format string provided.
        /// Any string can be used to make a complete string so the {0: [format]} should be used.
        /// If only optionally formatting a string is desired, use ToValue().
        /// If the data does not have a value, the defaultValue will be returned, if provided, otherwise, an empty string
        /// </summary>
        /// <param name="format">The complete format to use (i.e., The date is {0:d})</param>
        public static string ToFormat(this DateOnly? date, string format, string defaultValue = "")
        {
            if (!date.HasValue) return defaultValue;

            return string.Format(format, date.Value);
        }
    }
}
