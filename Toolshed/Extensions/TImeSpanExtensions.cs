using System;
using System.Collections.Generic;
using System.Text;

namespace Toolshed
{
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Returns a string that describes the TimeSpan in its biggest components
        /// <para>Example Return: 6 days, 5 hours, 1 minute and 3 seconds</para>
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static string ToLongDescriptionString(this TimeSpan timeSpan)
        {
            StringBuilder sb = new StringBuilder();
            bool preceded = false;
            string separator = ", ";

            if (timeSpan.Days > 0)
            {
                sb.AppendFormat("{0} {1}", timeSpan.Days, "day".MakePlural(timeSpan.Days));
                preceded = true;
            }

            if (timeSpan.Hours > 0)
            {
                sb.AppendFormat("{0}{1} {2}", preceded.ToString(separator, string.Empty), timeSpan.Hours, "hour".MakePlural(timeSpan.Hours));
                preceded = true;
            }

            if (timeSpan.Minutes > 0)
            {
                sb.AppendFormat("{0}{1} {2}", preceded.ToString(separator, string.Empty), timeSpan.Minutes, "minute".MakePlural(timeSpan.Minutes));
                preceded = true;
            }

            if (timeSpan.Seconds > 0)
            {
                sb.AppendFormat("{0}{1} {2}", preceded.ToString(separator, string.Empty), timeSpan.Seconds, "second".MakePlural(timeSpan.Seconds));
                preceded = true;
            }

            if (!preceded)
            {
                sb.AppendFormat("{0} {1}", timeSpan.Milliseconds, "millisecond".MakePlural(timeSpan.Milliseconds));
            }

            string description = sb.ToString();
            int lastComma = description.LastIndexOf(separator);
            if (lastComma > 0)
            {
                description = description.Remove(lastComma, 1);
                description = description.Insert(lastComma, " and ");
            }

            return description;
        }

        /// <summary>
        /// Returns a string that describes the TimeSpan in the specified part part
        /// </summary>
        /// <param name="part">The desired part to be described</param>
        /// <param name="round">The number of decimals to be returned for partial time spans</param>
        public static string ToShortDescriptionString(this TimeSpan timeSpan, TimeSpanPart part, int round = 2)
        {
            switch (part)
            {
                case TimeSpanPart.Years:
                    var y = Math.Round(timeSpan.TotalDays / 365, round);
                    return string.Format("{0} {1}", y, "year".MakePlural(y));
                case TimeSpanPart.Months:
                    var mo = Math.Round(timeSpan.TotalDays / 30, round);
                    return string.Format("{0} {1}", mo, "month".MakePlural(mo));
                case TimeSpanPart.Weeks:
                    var w = Math.Round(timeSpan.TotalDays / 7, round);
                    return string.Format("{0} {1}", w, "week".MakePlural(w));
                case TimeSpanPart.Days:
                    var d = Math.Round(timeSpan.TotalDays, round);
                    return string.Format("{0} {1}", d, "day".MakePlural(d));
                case TimeSpanPart.Hours:
                    var h = Math.Round(timeSpan.TotalHours, round);
                    return string.Format("{0} {1}", h, "hour".MakePlural(h));
                case TimeSpanPart.Minutes:
                    var m = Math.Round(timeSpan.TotalMinutes, round);
                    return string.Format("{0} {1}", m, "minute".MakePlural(m));
                case TimeSpanPart.Seconds:
                    var s = Math.Round(timeSpan.TotalSeconds, round);
                    return string.Format("{0} {1}", s, "second".MakePlural(s));
                case TimeSpanPart.Milliseconds:
                    var mm = Math.Round(timeSpan.TotalMilliseconds, round);
                    return string.Format("{0} {1}", mm, "millisecond".MakePlural(mm));
                default:
                    return timeSpan.ToLongDescriptionString();
            }
        }

        /// <summary>
        /// Returns the timespan in the largest time span part greater than zero (i.e., if days < 0, but hours > 0, the hours will be returned)
        /// </summary>
        /// <param name="round">The number of decimals to be returned for partial time spans</param>
        /// <returns></returns>
        public static string ToMinimumDescriptionString(this TimeSpan timeSpan, int round = 2, TimeSpanPartType part = TimeSpanPartType.All)
        {
            if (timeSpan.TotalDays > 1)
            {
                if (part == TimeSpanPartType.All)
                {
                    if (timeSpan.TotalDays > 364)
                    {
                        return timeSpan.ToShortDescriptionString(TimeSpanPart.Years, round);
                    }

                    if (timeSpan.TotalDays > 30)
                    {
                        return timeSpan.ToShortDescriptionString(TimeSpanPart.Months, round);
                    }

                    if (timeSpan.TotalDays > 7)
                    {
                        return timeSpan.ToShortDescriptionString(TimeSpanPart.Weeks, round);
                    }
                }

                return timeSpan.ToShortDescriptionString(TimeSpanPart.Days, round);
            }

            if (timeSpan.TotalHours > 1)
            {
                return timeSpan.ToShortDescriptionString(TimeSpanPart.Hours, round);
            }

            if (timeSpan.TotalMinutes > 1)
            {
                return timeSpan.ToShortDescriptionString(TimeSpanPart.Minutes, round);
            }

            if (timeSpan.TotalSeconds > 1)
            {
                return timeSpan.ToShortDescriptionString(TimeSpanPart.Seconds, round);
            }

            return timeSpan.ToShortDescriptionString(TimeSpanPart.Milliseconds, round);
        }
    }

}
