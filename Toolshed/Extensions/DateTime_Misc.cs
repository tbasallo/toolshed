using System;
using System.Collections.Generic;
using System.Globalization;

namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone
        /// </summary>
        public static DateTime ToEasternStandardTimeZone(this DateTime date)
        {
            var timeZoneId = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            if (date.Kind == DateTimeKind.Unspecified)
            {
                //we have to assume that this time is already in UTC
                return TimeZoneInfo.ConvertTimeFromUtc(date, timeZoneId);
            }

            //otherwise, .net knows what to do
            var utc = date.ToUniversalTime();
            return TimeZoneInfo.ConvertTimeFromUtc(utc, timeZoneId);
        }

        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone as a stirng using the provided format
        /// </summary>
        /// <param name="format">The format to use when returning the date</param>
        public static string ToEasternStandardTimeZone(this DateTime date, string format)
        {
            return date.ToEasternStandardTimeZone().ToString(format);
        }

        /// <summary>
        /// Rounds the datetime based on the specified DateTimeRoundTo
        /// </summary>
        public static DateTime Round(this DateTime d, DateTimeRoundTo dateTimeRoundTo)
        {
            DateTime dtRounded = new DateTime();

            switch (dateTimeRoundTo)
            {
                case DateTimeRoundTo.Second:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                    if (d.Millisecond >= 500) dtRounded = dtRounded.AddSeconds(1);
                    break;
                case DateTimeRoundTo.Minute:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0);
                    if (d.Second >= 30) dtRounded = dtRounded.AddMinutes(1);
                    break;
                case DateTimeRoundTo.Hour:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0);
                    if (d.Minute >= 30) dtRounded = dtRounded.AddHours(1);
                    break;
                case DateTimeRoundTo.Day:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                    if (d.Hour >= 12) dtRounded = dtRounded.AddDays(1);
                    break;
            }

            return dtRounded;
        }
    }
}