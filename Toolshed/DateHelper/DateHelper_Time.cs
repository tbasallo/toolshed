using System;

namespace Toolshed
{
    public static partial class DateHelper
    {
        /// <summary>
        /// Returns a new DateTime instance with the specified time
        /// </summary>
        /// <param name="hour">The hour portion of the time. 0 - 23</param>
        /// <param name="minute">The minute portion, defaults to 0</param>
        /// <param name="second">The second portion, defaults to 0</param>
        /// <returns>A new DateTime instance with the specified time set</returns>
        public static DateTime SetTime(this DateTime date, int hour, int minute = 0, int second = 0)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
        }
        /// <summary>
        /// Returns a new DateTime instance with the specified time
        /// </summary>
        /// <param name="time">A string representation of the time. This can be anything normally accepted by DateTime.Parse. This includes 6:00 PM, 18:00, 13:34:00, etc.</param>
        /// <returns>A new DateTime instance with the specified time set</returns>
        public static DateTime SetTime(this DateTime date, string time)
        {
            return DateTime.Parse(date.ToShortDateString() + " " + time);
        }
    }
}
