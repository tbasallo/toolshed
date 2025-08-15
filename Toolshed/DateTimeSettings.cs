using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolshed;

/// <summary>
/// Default settings for Toolshed date time extensions that can be set globally.
/// </summary>
public class DateTimeSettings
{
    /// <summary>
    /// Determines whether the time of day should be displayed with a space between the hour and time of day,, i.e. 9AM and 9 AM.
    /// This is as a default for all Toolshed date time extensions. The default is false, meaning it will not add a space.
    /// </summary>
    public static bool SpaceBetweenTimeOfDay { get; set; }

    /// <summary>
    /// The delimiter used for the URL Friendly and Path Friendly extensions. The default is a hyphen (-).
    /// </summary>
    public static string UrlFriendlyDelimiter { get; set; } = "-";
}
