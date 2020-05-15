using System;
using System.Collections.Generic;
using System.Globalization;

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
                        return LinuxTimeZones.Mountain;
                    }
                    else
                    {
                        return WindowsTimeZones.Mountain;
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



    }
}
