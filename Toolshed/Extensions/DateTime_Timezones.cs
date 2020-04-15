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
        public static DateTime ToTimeZone(this DateTimeOffset date, string timeZone)
        {
            var timeZoneId = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeFromUtc(date.UtcDateTime, timeZoneId);
        }


        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone
        /// </summary>
        public static DateTime ToEasternStandardTimeZone(this DateTime date)
        {
            if(OsHelper.IsWindows)
            {
                return date.ToTimeZone(WindowsTimeZones.Eastern);
            }
            if (OsHelper.IsLinux)
            {
                return date.ToTimeZone(LinuxTimeZones.Eastern);
            }

            return date;
        }
        /// <summary>
        /// Returns the DateTime in the Central Standard time zone
        /// </summary>
        public static DateTime ToCentralStandardTimeZone(this DateTime date)
        {
            if (OsHelper.IsWindows)
            {
                return date.ToTimeZone(WindowsTimeZones.Central);
            }
            if (OsHelper.IsLinux)
            {
                return date.ToTimeZone(LinuxTimeZones.Central);
            }

            return date;
        }
        /// <summary>
        /// Returns the DateTime in the Pacific Standard time zone
        /// </summary>
        public static DateTime ToPacificStandardTimeZone(this DateTime date)
        {
            if (OsHelper.IsWindows)
            {
                return date.ToTimeZone(WindowsTimeZones.Pacific);
            }
            if (OsHelper.IsLinux)
            {
                return date.ToTimeZone(LinuxTimeZones.Pacific);
            }

            return date;
        }


        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone
        /// </summary>
        public static DateTime ToEasternStandardTimeZone(this DateTimeOffset date)
        {
            if (OsHelper.IsWindows)
            {
                return date.ToTimeZone(WindowsTimeZones.Eastern);
            }
            if (OsHelper.IsLinux)
            {
                return date.ToTimeZone(LinuxTimeZones.Eastern);
            }

            return date.DateTime;
        }
        /// <summary>
        /// Returns the DateTime in the Central Standard time zone
        /// </summary>
        public static DateTime ToCentralStandardTimeZone(this DateTimeOffset date)
        {
            if (OsHelper.IsWindows)
            {
                return date.ToTimeZone(WindowsTimeZones.Central);
            }
            if (OsHelper.IsLinux)
            {
                return date.ToTimeZone(LinuxTimeZones.Central);
            }

            return date.DateTime;
        }
        /// <summary>
        /// Returns the DateTime in the Pacific Standard time zone
        /// </summary>
        public static DateTime ToPacificStandardTimeZone(this DateTimeOffset date)
        {
            if (OsHelper.IsWindows)
            {
                return date.ToTimeZone(WindowsTimeZones.Pacific);
            }
            if (OsHelper.IsLinux)
            {
                return date.ToTimeZone(LinuxTimeZones.Pacific);
            }

            return date.DateTime;
        }
    }


    //https://github.com/unicode-org/cldr/blob/master/common/bcp47/timezone.xml
    public static class LinuxTimeZones
    {
        public const string Eastern = "US/Eastern";
        public const string Central = "US/Central";
        public const string Pacific = "US/Pacific";
    }
    public static class WindowsTimeZones
    {
        public const string Eastern = "Eastern Standard Time";
        public const string Central = "Central Standard Time";
        public const string Pacific = "Pacific Standard Time";
    }
}