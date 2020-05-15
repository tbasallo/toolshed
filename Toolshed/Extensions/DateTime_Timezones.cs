using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        public static DateTime ToTimeZone(this DateTime date, string timeZone)
        {
            try
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
            catch (TimeZoneNotFoundException)
            {
                var timeZoneId = TimeZoneInfo.FindSystemTimeZoneById(DateHelper.GetTimeZoneName(timeZone));
                if (date.Kind == DateTimeKind.Unspecified)
                {
                    //we have to assume that this time is already in UTC
                    return TimeZoneInfo.ConvertTimeFromUtc(date, timeZoneId);
                }

                //otherwise, .net knows what to do - I HOPE :/ sorry Jon....
                var utc = date.ToUniversalTime();
                return TimeZoneInfo.ConvertTimeFromUtc(utc, timeZoneId);
            }
        }
        public static DateTime ToTimeZone(this DateTimeOffset date, string timeZone)
        {
            var timeZoneId = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeFromUtc(date.UtcDateTime, timeZoneId);
        }



        /// <summary>
        /// Returns the DateTime in the state's MAIN (majority) time zone.
        /// </summary>
        /// <param name="state">The 2 letter state that the time zone is for</param>
        /// <returns></returns>
        public static DateTime ToUsaStateTimeZone(this DateTime date, string state, bool throwExceptionForBadArgument = false)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                if (throwExceptionForBadArgument)
                {
                    throw new ArgumentException(nameof(state), "State must be provided and is must be two characters");
                }
                return date;
            }

            if (state.Length != 2)
            {
                if (throwExceptionForBadArgument)
                {
                    throw new ArgumentException(nameof(state), "State must be two characters");
                }
                return date;
            }

            var s = UnitedStates.Get50States().Where(d => d.Abbreviation.IsEqualTo(state)).FirstOrDefault();
            if (s == null)
            {
                if (throwExceptionForBadArgument)
                {
                    throw new ArgumentException(nameof(state), "Unknown state");
                }
                return date;
            }

            return date.ToTimeZone(DateHelper.GetTimeZoneName(s.TimeZone));
        }


        /// <summary>
        /// Returns the DateTime in the Eastern Standard time zone
        /// </summary>
        public static DateTime ToEasternStandardTimeZone(this DateTime date)
        {
            if (OsHelper.IsWindows)
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
        /// Returns the DateTime in the Mountain Standard time zone
        /// </summary>
        public static DateTime ToMountainStandardTimeZone(this DateTime date, bool isDst = true)
        {
            if (OsHelper.IsWindows)
            {
                if (isDst)
                {
                    return date.ToTimeZone(WindowsTimeZones.Mountain);
                }
                else
                {
                    return date.ToTimeZone(WindowsTimeZones.USMountain);
                }
            }
            if (OsHelper.IsLinux)
            {
                if (isDst)
                {
                    return date.ToTimeZone(LinuxTimeZones.Mountain);
                }
                else
                {
                    return date.ToTimeZone(LinuxTimeZones.USMountain);
                }
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
        /// <summary>
        /// Returns the DateTime in the Mountain Standard time zone
        /// </summary>
        public static DateTime ToMountainStandardTimeZone(this DateTimeOffset date, bool isDst = true)
        {
            if (OsHelper.IsWindows)
            {
                if (isDst)
                {
                    return date.ToTimeZone(WindowsTimeZones.Mountain);
                }
                else
                {
                    return date.ToTimeZone(WindowsTimeZones.USMountain);
                }
            }
            if (OsHelper.IsLinux)
            {
                if (isDst)
                {
                    return date.ToTimeZone(LinuxTimeZones.Mountain);
                }
                else
                {
                    return date.ToTimeZone(LinuxTimeZones.USMountain);
                }
            }

            return date.DateTime;
        }
    }


    //https://github.com/unicode-org/cldr/blob/master/common/bcp47/timezone.xml
    public static class LinuxTimeZones
    {
        public const string Eastern = "America/New_York";
        public const string Central = "America/Chicago";
        public const string Pacific = "America/Los_Angeles";
        public const string Mountain = "America/Denver";
        public const string USMountain = "America/Phoenix";
        public const string Alaska = "America/Anchorage";
        public const string Hawaii = "Pacific/Honolulu";
    }
    public static class WindowsTimeZones
    {
        public const string Eastern = "Eastern Standard Time";
        public const string Central = "Central Standard Time";
        public const string Pacific = "Pacific Standard Time";
        public const string Mountain = "Mountain Standard Time";
        public const string USMountain = "US Mountain Standard Time";
        public const string Alaska = "Alaska Daylight Time";
        public const string Hawaii = "Hawaii Standard Time";
    }
}