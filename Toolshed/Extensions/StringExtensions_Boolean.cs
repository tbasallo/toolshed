﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Toolshed
{
    public static partial class StringExtensions
    {
        public static bool ToBoolean(this string value, string trueValue, bool? defaultValue = null, bool isCaseSensitive = false)
        {
            if (string.IsNullOrEmpty(value))
            {
                if (!defaultValue.HasValue) throw new ArgumentNullException(nameof(value), "string cannot be null or you must provide a default value");
                return defaultValue.Value;
            }

            var caseSensitivity = isCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            return value.Equals(trueValue, caseSensitivity);
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
        /// Indicates if the string's length is within the specified values
        /// </summary>
        /// <param name="minimumLength"></param>
        /// <param name="maximumLength"></param>
        /// <returns></returns>
        public static bool IsLengthWithinRange(this string s, int minimumLength, int maximumLength)
        {
            if (s == null) return false;
            return (s.Length.IsInRange(minimumLength, maximumLength));
        }


        /// <summary>
        /// Indicates if the string is equal to the specified value using the selected StringComparison type (defaults to OrdinalIgnoreCase)
        /// </summary>
        /// <returns>Boolean indicating if the values are equal</returns>
        public static bool IsEqualTo(this string s, string value, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            if (s == null) return false;
            if (value == null) return false;
            return s.Equals(value, comparisonType);
        }

        /// <summary>
        /// Indicates if the specified values is found in this string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="value"></param>
        /// <param name="comparisonType"></param>
        /// <returns>Boolean indicating if the specified value is in this string. Should this be called HasValue, IsWithin, ....</returns>
        public static bool IsContained(this string s, string value, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            if (s == null) return false;
            if (value == null) return false;
            return s.IndexOf(value, comparisonType) > -1;
        }


        //makes built-in methods easier

        //
        // Summary:
        //     Indicates whether a specified string is null, empty, or consists only of white-space
        //     characters.
        //
        // Returns:
        //     true if the value parameter is null or System.String.Empty, or if value consists
        //     exclusively of white-space characters.
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

/// <summary>
        /// Indicates if there are numbers in this string
        /// </summary>
        /// <returns>Boolean indicating if the specified value has a number</returns>
        public static bool HasNumbers(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;

            return Regex.IsMatch(s, @"\d", RegexOptions.None);
        }

    }
}