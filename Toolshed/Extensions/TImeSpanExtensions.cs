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
        public static string ToShortDescriptionString(this TimeSpan timeSpan, TimeSpanPart part, int round = 2, bool abbreviate = false)
        {
            if (abbreviate)
            {
                return part switch
                {
                    TimeSpanPart.Years => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays / 365, round), "yr".MakePlural(Math.Round(timeSpan.TotalDays / 365, round))),
                    TimeSpanPart.Months => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays / 30, round), "mn".MakePlural(Math.Round(timeSpan.TotalDays / 30, round))),
                    TimeSpanPart.Weeks => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays / 7, round), "wk".MakePlural(Math.Round(timeSpan.TotalDays / 7, round))),
                    TimeSpanPart.Days => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays, round), "day".MakePlural(Math.Round(timeSpan.TotalDays, round))),
                    TimeSpanPart.Hours => string.Format("{0} {1}", Math.Round(timeSpan.TotalHours, round), "hr".MakePlural(Math.Round(timeSpan.TotalHours, round))),
                    TimeSpanPart.Minutes => string.Format("{0} {1}", Math.Round(timeSpan.TotalMinutes, round), "min".MakePlural(Math.Round(timeSpan.TotalMinutes, round))),
                    TimeSpanPart.Seconds => string.Format("{0} {1}", Math.Round(timeSpan.TotalSeconds, round), "sec".MakePlural(Math.Round(timeSpan.TotalSeconds, round))),
                    TimeSpanPart.Milliseconds => string.Format("{0} {1}", Math.Round(timeSpan.TotalMilliseconds, round), "milli".MakePlural(Math.Round(timeSpan.TotalMilliseconds, round))),

                    //THIS NEVER HAPPENS
                    _ => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays, round), "day".MakePlural(Math.Round(timeSpan.TotalDays, round)))
                };
            }

            return part switch
            {
                TimeSpanPart.Years => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays / 365, round), "year".MakePlural(Math.Round(timeSpan.TotalDays / 365, round))),
                TimeSpanPart.Months => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays / 30, round), "month".MakePlural(Math.Round(timeSpan.TotalDays / 30, round))),
                TimeSpanPart.Weeks => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays / 7, round), "week".MakePlural(Math.Round(timeSpan.TotalDays / 7, round))),
                TimeSpanPart.Days => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays, round), "day".MakePlural(Math.Round(timeSpan.TotalDays, round))),
                TimeSpanPart.Hours => string.Format("{0} {1}", Math.Round(timeSpan.TotalHours, round), "hour".MakePlural(Math.Round(timeSpan.TotalHours, round))),
                TimeSpanPart.Minutes => string.Format("{0} {1}", Math.Round(timeSpan.TotalMinutes, round), "minute".MakePlural(Math.Round(timeSpan.TotalMinutes, round))),
                TimeSpanPart.Seconds => string.Format("{0} {1}", Math.Round(timeSpan.TotalSeconds, round), "second".MakePlural(Math.Round(timeSpan.TotalSeconds, round))),
                TimeSpanPart.Milliseconds => string.Format("{0} {1}", Math.Round(timeSpan.TotalMilliseconds, round), "milli".MakePlural(Math.Round(timeSpan.TotalMilliseconds, round))),

                //THIS NEVER HAPPENS
                _ => string.Format("{0} {1}", Math.Round(timeSpan.TotalDays, round), "day".MakePlural(Math.Round(timeSpan.TotalDays, round)))
            };
        }

        /// <summary>
        /// Returns the timespan in the largest time span part greater than zero (i.e., if days < 0, but hours > 0, the hours will be returned)
        /// </summary>
        /// <param name="round">The number of decimals to be returned for partial time spans</param>
        /// <returns></returns>
        public static string ToMinimumDescriptionString(this TimeSpan timeSpan, int round = 2, TimeSpanPartType part = TimeSpanPartType.All, bool abbreviate = false, bool show0SecondsWhenLessThan0 = true)
        {
            if (timeSpan.TotalDays > 1)
            {
                if (part == TimeSpanPartType.All)
                {
                    if (timeSpan.TotalDays > 364)
                    {
                        return timeSpan.ToShortDescriptionString(TimeSpanPart.Years, round, abbreviate);
                    }

                    if (timeSpan.TotalDays > 30)
                    {
                        return timeSpan.ToShortDescriptionString(TimeSpanPart.Months, round, abbreviate);
                    }

                    if (timeSpan.TotalDays > 7)
                    {
                        return timeSpan.ToShortDescriptionString(TimeSpanPart.Weeks, round, abbreviate);
                    }
                }

                return timeSpan.ToShortDescriptionString(TimeSpanPart.Days, round, abbreviate);
            }

            if (timeSpan.TotalHours > 1)
            {
                return timeSpan.ToShortDescriptionString(TimeSpanPart.Hours, round, abbreviate);
            }

            if (timeSpan.TotalMinutes > 1)
            {
                return timeSpan.ToShortDescriptionString(TimeSpanPart.Minutes, round, abbreviate);
            }

            if (timeSpan.TotalSeconds > 1)
            {
                return timeSpan.ToShortDescriptionString(TimeSpanPart.Seconds, round, abbreviate);
            }

            if (show0SecondsWhenLessThan0)
            {
                return timeSpan.ToShortDescriptionString(TimeSpanPart.Seconds, round, abbreviate);
            }
            else
            {
                return timeSpan.ToShortDescriptionString(TimeSpanPart.Milliseconds, round, abbreviate);
            }
        }
    }

}
