using System;

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
        public static DateTime ToUsaStateTimeZone(this DateTime date, string? state, bool throwExceptionForBadArgument = false)
        {
            return DateHelper.ToUsaStateTimeZone(date, state, throwExceptionForBadArgument);
        }

        /// <summary>
        /// Converts the current DateTime into UTC based on the state's time zone
        /// </summary>
        /// <param name="state">The USA state  for the DateTime</param>
        /// <returns>A DateTime converted to UTC</returns>
        public static DateTime FromUsaTimeZone(this DateTime date, string? state)
        {
            return DateHelper.FromUsaTimeZone(date, state);
        }

        /// <summary>
        /// Converts the current DateTime into UTC based on the specified time zone
        /// </summary>
        /// <param name="date">The date/time to convert</param>
        /// <param name="timeZone">The time zone of the date/time provided</param>
        /// <returns>A DateTime converted to UTC</returns>
        public static DateTime FromTimeZoneToUtc(this DateTime date, string timeZone)
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(DateHelper.GetTimeZoneName(timeZone));
            if (tz.IsDaylightSavingTime(date))
            {
                var hours = (tz.BaseUtcOffset.TotalHours * -1) - 1;
                return (new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc)).AddHours(hours);
            }
            else
            {
                var hours = (tz.BaseUtcOffset.TotalHours * -1);
                return (new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc)).AddHours(hours);
            }
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