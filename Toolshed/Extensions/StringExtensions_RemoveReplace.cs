using System.Text.RegularExpressions;

namespace Toolshed
{
    public static partial class StringExtensions
    {
        public static string RemoveSpaces(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return s.Replace(" ", "");
        }

        /// <summary>
        /// Removes all characters that are numbers (digits)
        /// </summary>
        /// <returns>A string without the numbers</returns>
        public static string RemoveNumbers(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return Regex.Replace(s, @"\d", string.Empty, RegexOptions.None);
        }
        /// <summary>
        /// Replaces all characters that are numbers (digits) with the specified replacement string
        /// </summary>
        /// <returns>A string with the replaced numbers, if any</returns>
        public static string ReplaceNumbers(this string? s, string replacement)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return Regex.Replace(s, @"\d", replacement, RegexOptions.None);
        }


        /// <summary>
        /// Removes all the non-alpha (only words, numbers and the underscore remain)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceNonAlpha(this string? s, string replacement)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return Regex.Replace(s, @"\W", replacement, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Removes all non-alpha characters from the string
        /// </summary>
        /// <returns></returns>
        public static string RemoveNonAlpha(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return Regex.Replace(s, @"\W", "", RegexOptions.IgnoreCase);
        }


        public static string RemoveNonNumbers(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return Regex.Replace(s, @"\D", string.Empty, RegexOptions.None);
        }





        /// <summary>
        /// Replaces all multi-white space character with a single white space character
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReduceWhiteSpace(this string? s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            string pattern = @"\s{2,}";
            return Regex.Replace(s, pattern, " ", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }

    }
}