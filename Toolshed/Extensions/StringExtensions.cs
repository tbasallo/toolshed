using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Toolshed
{
    public static class StringExtensions
    {
        public static bool ToBoolean(this string value, string trueValue, bool? defaultValue = null, bool isCaseSensitive = false)
        {
            if (string.IsNullOrEmpty(value))
            {
                if (!defaultValue.HasValue) throw new ArgumentNullException("value", "string cannot be null or you must provide a default value");
                return defaultValue.Value;
            }

            var caseSensitivity = isCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            return value.Equals(trueValue, caseSensitivity);
        }

        /// <summary>
        /// Need to do some testing to see if linq/regex (compile?) is the best way to do this
        /// </summary>
        /// <param name="s"></param>
        /// <param name="useLinq"></param>
        /// <returns></returns>
        public static string SeparateOnPascal(this string s, bool useLinq = true)
        {
            if (useLinq)
            {
                var result = s.SelectMany((c, i) => i != 0 && char.IsUpper(c) && !char.IsUpper(s[i - 1]) ? new char[] { ' ', c } : new char[] { c });
                return new String(result.ToArray());
            }

            Regex r = new Regex(RegexPatterns.PascalSplit);
            return r.Replace(s, " ");
        }


        public static string RemoveSpaces(this string s)
        {
            return s.Replace(" ", "");
        }
        /// <summary>
        /// Returns a boolean indicating whether this string is a Regex email match
        /// </summary>
        public static bool IsEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(RegexPatterns.Email);
            return regex.IsMatch(email);
        }
        public static bool IsAbsoluteUrl(this string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            Regex regex = new Regex(RegexPatterns.Url);
            return regex.IsMatch(url);
        }
        public static bool IsGuid(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            Regex regex = new Regex(RegexPatterns.Guid);
            return regex.IsMatch(value);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by the specified string. A parameter specifies whether to return empty array elements.
        /// </summary>
        /// <param name="s">extension method - this string</param>
        /// <param name="delimiter">The string that is delimited on</param>
        /// <param name="options">A StringSplitOptions that determines whether to return empty array elements (defaults to RemoveEmptyEntries)</param>
        /// <returns>A string array string[]</returns>
        public static string[] Split(this string s, string delimiter, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return s.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Returns a string that contains only alpha numeric characters and replaces others with a dash (single dashes)
        /// </summary>
        public static string ToUrlFriendly(this string s)
        {
            return s.ToUrlFriendly('-');
        }
        /// <summary>
        /// Returns a string that contains only alpha numeric characters and replaces others with the specified character
        /// </summary>
        public static string ToUrlFriendly(this string s, char delimiter)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            s = s.Trim();
            /// only keep safe URL characters
            /// A-B, 0-9, ., -, /
            s = Regex.Replace(s, @"[^\w\d]", delimiter.ToString(), RegexOptions.IgnoreCase);
            ///replace more than a single dash in a row with one dash
            s = Regex.Replace(s, @"\" + delimiter.ToString() + "{2,}", "-", RegexOptions.IgnoreCase);
            ///replaces dashes in the begining and end
            s = Regex.Replace(s, "\\A" + delimiter.ToString() + "+|" + delimiter.ToString() + "\\z", "", RegexOptions.IgnoreCase);

            return s;
        }

        /// <summary>
        /// Returns a string that contains only alpha numeric characters and the forward slash (/) with a dash (-)
        /// </summary>
        public static string ToUrlPathFriendly(this string s)
        {
            return s.ToUrlPathFriendly('-');
        }
        /// <summary>
        /// Returns a string that contains only alpha numeric characters and the forward slash (/) and replaces others with the specified character
        /// </summary>
        public static string ToUrlPathFriendly(this string s, char delimiter)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            s = s.Trim();
            /// only keep safe URL characters
            /// A-B, 0-9, ., -, /
            s = Regex.Replace(s, @"[^\w\d//]", delimiter.ToString(), RegexOptions.IgnoreCase);
            ///replace more than a single dash in a row with one dash
            s = Regex.Replace(s, @"\" + delimiter.ToString() + "{2,}", "-", RegexOptions.IgnoreCase);
            ///replaces dashes in the begining and end
            s = Regex.Replace(s, "\\A" + delimiter.ToString() + "+|" + delimiter.ToString() + "\\z", "", RegexOptions.IgnoreCase);

            return s;
        }

        /// <summary>
        /// Removes all the non-alpha (only words, numbers and the underscore remain)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceNonAlpha(this string s, string replacement)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return Regex.Replace(s, @"\W", replacement, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Removes all non-alpha characters from the string
        /// </summary>
        /// <returns></returns>
        public static string RemoveNonAlpha(this string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return Regex.Replace(s, @"\W", "", RegexOptions.IgnoreCase);
        }

        public static string MakePlural(this string s, int value)
        {
            if (value == 1)
            {
                return s;
            }

            return s + "s";
        }
        public static string MakePlural(this string s, double value)
        {
            if (value == 1)
            {
                return s;
            }

            return s + "s";
        }
        public static string PrefixA(this string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (s.StartsWith("a", StringComparison.OrdinalIgnoreCase))
            {
                return "an " + s;
            }

            if (s.StartsWith("e", StringComparison.OrdinalIgnoreCase))
            {
                return "an " + s;
            }

            if (s.StartsWith("i", StringComparison.OrdinalIgnoreCase))
            {
                return "an " + s;
            }

            if (s.StartsWith("o", StringComparison.OrdinalIgnoreCase))
            {
                return "an " + s;
            }

            if (s.StartsWith("u", StringComparison.OrdinalIgnoreCase))
            {
                return "an " + s;
            }

            return "a " + s;
        }
        public static bool LengthIsOutOfIndex(this string s, int minimumLength, int maximumLength)
        {
            int length = s.Length;
            return (length.IsInRange(minimumLength, maximumLength));
        }

        public static string TrimSafely(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            return s.Trim();
        }

        public static string ToUpperSafely(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            return s.ToUpper();
        }
        public static string ToLowerInvariantSafely(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            return s.ToLowerInvariant();
        }
        public static string ToLowerInvariant(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return s.ToLower();
        }
        public static string ToTelephoneNumber(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            switch (s.Length)
            {
                case 7:
                    return string.Format("{0}-{1}", s.Substring(0, 3), s.Substring(3));
                case 10:
                    return string.Format("({0}) {1}-{2}", s.Substring(0, 3), s.Substring(3, 3), s.Substring(6));
            }

            return s;
        }

        public static string ToUpperTrimSafely(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return s.ToUpper().Trim();
        }
        public static string ToTitleCase(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            //you have to lowercase it first, otherwise it will not change "case it"
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLowerInvariant()).TrimSafely();
        }

        public static string RemoveNonNumbers(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return Regex.Replace(s, @"\D", string.Empty, RegexOptions.None);
        }

        /// <summary>
        /// Returns the string using the fromat provided if the string passes string.IsNullOrWhiteSpace otherwise return an empty string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format">The format to apply to the string of the string is valid</param>
        /// <returns>A formatted string using the provided format</returns>
        public static string ToFormat(this string s, string format)
        {
            return !string.IsNullOrWhiteSpace(s) ? string.Format(format, s) : string.Empty;
        }

        /// <summary>
        /// Retrieves the value of the string or the default value if null, empty or white space
        /// </summary>
        /// <param name="defaultValue">The value to return if the string is null, empty or white space</param>
        /// <returns></returns>
        public static string ToValue(this string s, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(s) ? defaultValue : s;
        }

        public static byte[] ToByteArray(this string s)
        {
            if (string.IsNullOrEmpty(s)) return null;

            var encoding = new UTF8Encoding();
            return encoding.GetBytes(s);
        }

        public static string ToJavascriptSafeString(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            var e = s.Replace("'", "\'");
            var d = Regex.Replace(s, @"'", "\'");
            return d;
        }

        /// <summary>
        /// Replaces all multi-white space character with a single white space character
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReduceWhiteSpace(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            string pattern = @"\s{2,}";
            return Regex.Replace(s, pattern, " ", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }
    }

}
