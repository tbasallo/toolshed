using System;
using System.Collections.Generic;
using System.Globalization;

namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        public static DateTime ToTimeZone(this DateTime date, string timeZone)
        {
            var timeZoneId = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            if (date.Kind == DateTimeKind.Unspecified)
            {
                //we have to assume that this time is already in UTC
                return TimeZoneInfo.ConvertTimeFromUtc(date, timeZoneId);
            }

            //otherwise, .net knows what to do - I HOPE :/ sorry Jon....
            var utc = date.ToUniversalTime();
            return TimeZoneInfo.ConvertTimeFromUtc(utc, timeZoneId);
        }


        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone
        /// </summary>
        public static DateTime ToEasternStandardTimeZone(this DateTime date)
        {
            return date.ToTimeZone("Eastern Standard Time");
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
        /// Returns the DateTime in the Eastern Standard time zone. If the date is null the optional the default value specified will be returned, otherwise null is returned
        /// </summary>
        public static DateTime? ToEasternStandardTimeZone(this DateTime? date, DateTime? defaultValue = null)
        {
            if (!date.HasValue)
            {
                return defaultValue;
            }

            return date.Value.ToEasternStandardTimeZone();
        }

        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone in the specified time zone. If the date is null the optional the default value specified will be returned, otherwise null is returned
        /// </summary>
        public static string ToEasternStandardTimeZone(this DateTime? date, string format, string defaultValue = null)
        {
            if (!date.HasValue)
            {
                return defaultValue;
            }

            return date.Value.ToEasternStandardTimeZone(format);
        }



        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone
        /// </summary>
        public static DateTime ToEasternStandardTimeZone(this DateTimeOffset date)
        {
            return date.DateTime.ToEasternStandardTimeZone();
        }

        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone in the specified format
        /// </summary>
        public static string ToEasternStandardTimeZone(this DateTimeOffset date, string format)
        {
            return date.DateTime.ToEasternStandardTimeZone(format);
        }

        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone. If the date is null the optional the default value specified will be returned, otherwise null is returned
        /// </summary>
        public static DateTime? ToEasternStandardTimeZone(this DateTimeOffset? date, DateTime? defaultValue = null)
        {
            if (!date.HasValue)
            {
                return defaultValue;
            }

            return date.Value.DateTime.ToEasternStandardTimeZone();
        }

        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone in the specified format. If the date is null the optional the default value specified will be returned, otherwise null is returned
        /// </summary>
        public static string ToEasternStandardTimeZone(this DateTimeOffset? date, string format, string defaultValue = null)
        {
            if (!date.HasValue)
            {
                return defaultValue;
            }

            return date.Value.DateTime.ToEasternStandardTimeZone(format);
        }
    }
}