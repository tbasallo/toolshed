﻿using System.Buffers.Text;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Toolshed
{
    public static partial class StringExtensions
    {

        /// <summary>
        /// Need to do some testing to see if linq/regex (compile?) is the best way to do this
        /// </summary>
        /// <param name="s"></param>
        /// <param name="useLinq"></param>
        /// <returns></returns>
        public static string SeparateOnPascal(this string? s, bool useLinq = true)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            if (useLinq)
            {
                var result = s.SelectMany((c, i) => i != 0 && char.IsUpper(c) && !char.IsUpper(s[i - 1]) ? new char[] { ' ', c } : new char[] { c });
                return new String(result.ToArray());
            }

            Regex r = new Regex(RegexPatterns.PascalSplit);
            return r.Replace(s, " ");
        }





        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by the specified string. A parameter specifies whether to return empty array elements.
        /// </summary>
        /// <param name="s">extension method - this string</param>
        /// <param name="delimiter">The string that is delimited on</param>
        /// <param name="options">A StringSplitOptions that determines whether to return empty array elements (defaults to RemoveEmptyEntries)</param>
        /// <returns>A string array string[]</returns>
        public static string[] Split(this string? s, string delimiter, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            if (string.IsNullOrEmpty(s)) return [];

            return s.Split(new string[] { delimiter }, options);
        }

        /// <summary>
        /// Returns a string that contains only alpha numeric characters and replaces others with a dash (single dashes)
        /// </summary>
        public static string ToUrlFriendly(this string? s)
        {
            return s.ToUrlFriendly('-');
        }
        /// <summary>
        /// Returns a string that contains only alpha numeric characters and replaces others with the specified character
        /// </summary>
        public static string ToUrlFriendly(this string? s, char delimiter)
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
        public static string ToUrlPathFriendly(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            return s.ToUrlPathFriendly('-');
        }
        /// <summary>
        /// Returns a string that contains only alpha numeric characters and the forward slash (/) and replaces others with the specified character
        /// </summary>
        public static string ToUrlPathFriendly(this string? s, char delimiter)
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



        public static string MakePlural(this string? s, int value)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            if (value == 1)
            {
                return s;
            }

            return s + "s";
        }
        public static string MakePlural(this string? s, double value)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            if (value == 1)
            {
                return s;
            }

            return s + "s";
        }

        /// <summary>
        /// Returns the specified string with a prefix of a or an based on the English grammar rules (vowels get AN and the rets get A)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string PrefixA(this string? s)
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


        public static bool LengthIsOutOfIndex(this string? s, int minimumLength, int maximumLength)
        {
            if (string.IsNullOrEmpty(s)) return true;

            return (s.Length.IsInRange(minimumLength, maximumLength));
        }

        public static string TrimSafely(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            return s.Trim();
        }

        public static string ToUpperSafely(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            return s.ToUpper();
        }
        public static string ToUpperTrimSafely(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            return s.ToUpper().Trim();
        }

        /// <summary>
        /// Returns the specified string up to the length provided if the string's length is greater than the provided length, other returns the original string
        /// </summary>
        /// <param name="length">The maximum length  of the specified string you want returned</param>
        /// <returns></returns>
        public static string SubstringTo(this string? s, int length)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            if (s.Length > length)
            {
                return s[..length];
            }

            return s;

        }

        public static string ToLowerInvariantTrimSafely(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return s.ToLowerInvariant().Trim();
        }
        public static string ToLowerInvariant(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return s.ToLower();
        }
        public static string ToLowerInvariantSafely(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return s.ToLower();
        }

        /// <summary>
        /// returns a 10 digit number as (xxx) xxx-xxxx and a 7 digit number like xxx-xxxx and an 11 number that starts with 1 as 1 (xxxx) xxxx-xxxx otherwise returns the original string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToTelephoneNumber(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            switch (s.Length)
            {
                case 7:
                    return string.Format("{0}-{1}", s[0..3], s[^4..]);
                case 10:
                    return string.Format("({0}) {1}-{2}", s[0..3], s[3..6], s[^4..]);
                case 11:
                    if (s.StartsWith("1"))
                    {
                        return string.Format("1 ({0}) {1}-{2}", s[1..4], s[4..7], s[^4..]);
                    }
                    break;
            }

            return s;
        }

        /// <summary>
        /// This cleans the specified string by removing any non number characters and then returning the last 10 digits. This eliminates the
        /// leading 1 that some auto-fillers populate.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetFixedTelephoneNumber(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                if (!(s[i] >= '0' && s[i] <= 9))
                {
                    s = s.RemoveNonNumbers();
                    return s.Length >= 10 ? s[^10..] : s;
                }
            }

            return s.Length >= 10 ? s[^10..] : s;
        }

        /// <summary>
        /// Returns the string using the current culture's title case rules
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            //you have to lowercase it first, otherwise it will not change "case it"
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLowerInvariant()).TrimSafely();
        }

        /// <summary>
        /// Returns NULL for string that are null, empty or whitespace. Additionally, if an array of strings is provided, a match will also return NULL (case sensitive)
        /// </summary>
        /// <param name="nullQualifyingString">An option list of strings that are checked to return null </param>
        /// <returns></returns>
        public static string? ToNullIfEmpty(this string? s, bool trimString = false, bool toUpper = false, string[]? nullQualifyingString = null)
        {
            if (s == null)
            {
                return null;
            }
            if (s.Length == 0)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            if (nullQualifyingString != null)
            {
                if (nullQualifyingString.Contains(s))
                {
                    return null;
                }
            }

            if (trimString && toUpper)
            {
                return s.ToUpper().Trim();
            }
            else if (trimString)
            {
                return s.Trim();
            }
            else if (toUpper)
            {
                return s.ToUpperInvariant();
            }

            return s;
        }

        /// <summary>
        /// Returns the string using the format provided if the string passes string.IsNullOrWhiteSpace otherwise return an empty string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format">The format to apply to the string of the string is valid</param>
        /// <returns>A formatted string using the provided format</returns>
        public static string ToFormat(this string? s, string format)
        {
            return !string.IsNullOrWhiteSpace(s) ? string.Format(format, s) : string.Empty;
        }

        /// <summary>
        /// Retrieves the value of the string or the default value if null, empty or white space
        /// </summary>
        /// <param name="defaultValue">The value to return if the string is null, empty or white space</param>
        /// <returns></returns>
        public static string ToValue(this string? s, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(s) ? defaultValue : s;
        }

        /// <summary>
        /// Returns a string as a byte array. If using for encoding a Base64 string, use ToBase64 instead
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return [];

            return Encoding.UTF8.GetBytes(s);
        }

        /// <summary>
        /// Returns a UTF8 Base64 string from the current string
        /// </summary>
        /// <param name="s"></param>
        /// <returns>A base64 string</returns>
        public static string ToBase64(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
        }

        /// <summary>
        /// Returns the current UTF8 BASE64 string as the original string
        /// </summary>
        /// <returns>A string from base 64</returns>
        public static string FromBase64(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            return Encoding.UTF8.GetString(Convert.FromBase64String(s));
        }


        /// <summary>
        /// Returns a UTF8 Base64 string from the current string
        /// </summary>
        /// <param name="s"></param>
        /// <returns>A base64 string</returns>
        public static string ToBase64Url(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            return Base64Url.EncodeToString(Encoding.UTF8.GetBytes(s));
        }

        /// <summary>
        /// Returns the current UTF8 BASE64 string as the original string
        /// </summary>
        /// <returns>A string from base 64</returns>
        public static string FromBase64Url(this string? s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            return Encoding.UTF8.GetString(Base64Url.DecodeFromChars(s));
        }

        /// <summary>
        /// Converts the specified string to a JavaScript-safe format by escaping single quotes.
        /// </summary>
        /// <param name="s">The input string to be converted. If <paramref name="s"/> is <see langword="null"/> or empty, the original
        /// value is returned.</param>
        /// <returns>A string with single quotes escaped for safe use in JavaScript contexts.</returns>
        public static string ToJavaScriptSafeString(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (s.Length == 0) return string.Empty;

            return s.Replace("'", "\'");
        }


        /// <summary>
        /// Returns the current string into groups made up of the number of characters specified in characterGroupSize.
        /// e.g., a string with a length of 800 and a lengthGroupSize of 200 will return four groups of a string with a length of 200.
        /// </summary>
        /// <param name="lengthGroupSize">The maximum length of each string returned</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitBy(this string? s, int lengthGroupSize)
        {
            if (string.IsNullOrEmpty(s)) yield break;

            if (s.Length <= lengthGroupSize)
            {
                yield return s;
            }

            if (lengthGroupSize < 1) throw new ArgumentException("groupSize must be greater than 0", "groupSize");

            for (int i = 0; i < s.Length; i += lengthGroupSize)
            {
                if (lengthGroupSize + i > s.Length)
                    lengthGroupSize = s.Length - i;

                yield return s.Substring(i, lengthGroupSize);
            }
        }
    }
}