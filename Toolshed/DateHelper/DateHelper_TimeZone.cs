using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Toolshed
{
    /// <summary>
    /// Various static methods that perform routinely performed actions on dates and times
    /// </summary>
    public static partial class DateHelper
    {
        /// <summary>
        /// Returns the official time zone name for the current OS using the specified time zone name - which may be the same :)
        /// <para>The name to check against for the know three known formats</para>
        /// </summary>
        public static string GetTimeZoneName(string timeZone)
        {
            switch (timeZone.ToUpperInvariant())
            {
                case "EST":
                case "EASTERN STANDARD TIME":
                case "EASTERN":
                case "US/EASTERN":
                case "AMERICA/NEW_YORK":
                    if (OsHelper.IsLinux)
                    {
                        return LinuxTimeZones.Eastern;
                    }
                    else
                    {
                        return WindowsTimeZones.Eastern;
                    }

                case "CST":
                case "CENTRAL STANDARD TIME":
                case "US/CENTRAL":
                case "CENTRAL":
                case "AMERICA/CHICAGO":
                    if (OsHelper.IsLinux)
                    {
                        return LinuxTimeZones.Central;
                    }
                    else
                    {
                        return WindowsTimeZones.Central;
                    }

                case "MST":
                case "MOUNTAIN STANDARD TIME":
                case "US/MOUNTAIN":
                case "MOUNTAIN":
                case "AMERICA/DENVER":
                    if (OsHelper.IsLinux)
                    {
                        return LinuxTimeZones.Mountain;
                    }
                    else
                    {
                        return WindowsTimeZones.Mountain;
                    }
                case "MDT":
                case "US MOUNTAIN STANDARD TIME":
                case "USMOUNTAIN":
                case "AMERICA/PHOENIX":
                    if (OsHelper.IsLinux)
                    {
                        return LinuxTimeZones.USMountain;
                    }
                    else
                    {
                        return WindowsTimeZones.USMountain;
                    }

                case "PST":
                case "PACIFIC":
                case "PACIFIC STANDARD TIME":
                case "US/PACIFIC":
                case "AMERICA/LOS_ANGELES":
                    if (OsHelper.IsLinux)
                    {
                        return LinuxTimeZones.Pacific;
                    }
                    else
                    {
                        return WindowsTimeZones.Pacific;
                    }
            }

            if (OsHelper.IsLinux)
            {
                return LinuxTimeZones.Eastern;
            }
            else
            {
                return WindowsTimeZones.Eastern;
            }
        }



        /// <summary>
        /// Returns the DateTime in the state's MAIN (majority) time zone.
        /// </summary>
        /// <param name="state">The 2 letter state that the time zone is for</param>
        /// <returns></returns>
        public static DateTime ToUsaStateTimeZone(DateTime date, string state, bool throwExceptionForBadArgument = false)
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
        /// Converts the current DateTime into UTC based on the state's time zone
        /// </summary>
        /// <param name="state">The USA state  for the DateTime</param>
        /// <returns>A DateTime converted to UTC</returns>
        public static DateTime FromUsaTimeZone(DateTime date, string state)
        {
            var s = UnitedStates.Get50States().Where(d => d.Abbreviation.IsEqualTo(state)).FirstOrDefault();
            return date.FromTimeZoneToUtc(s.TimeZone);
        }
    }
}
