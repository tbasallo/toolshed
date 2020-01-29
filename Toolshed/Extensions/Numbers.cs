﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Toolshed
{
    public static partial class Numbers
    {
        //Not sure if I needed it, but I loved the potential, so it's here
        //SO: https://stackoverflow.com/questions/954198/what-is-the-best-or-most-interesting-use-of-extension-methods-youve-seen/954254#954254
        /// <summary>
        /// Allows for iterating from the current number to the specified number
        /// </summary>
        /// <param name="toNumber">The number to iterate to</param>
        /// <returns></returns>
        public static IEnumerable<int> To(this int fromNumber, int toNumber)
        {
            while (fromNumber < toNumber)
            {
                yield return fromNumber;
                fromNumber++;
            }
        }

        /// <summary>
        /// Returns the number rounded to the largest segment with the suffix of K,M,B for thousand, million or billion
        /// </summary>
        public static string ToSemanticValue(this int number)
        {
            var amount = Convert.ToDouble(number);
            return amount.ToSemanticValue();
        }

        /// <summary>
        /// Returns the number rounded to the largest segment with the suffix of K,M,B for thousand, million or billion
        /// </summary>
        public static string ToSemanticValue(this long number)
        {
            var amount = Convert.ToDouble(number);
            return amount.ToSemanticValue();
        }

        /// <summary>
        /// Returns the number rounded to the largest segment with the suffix of K,M,B for thousand, million or billion
        /// </summary>
        public static string ToSemanticValue(this double number)
        {
            if (number >= 1000000000)
            {
                return Math.Round(((number / 1000000000) * 10)) / 10 + "B";
            }
            if (number >= 1000000)
            {
                return Math.Round(((number / 1000000) * 10)) / 10 + "M";
            }
            if (number >= 1000)
            {
                return Math.Round(((number / 1000) * 10)) / 10 + "K";
            }

            if (number < 0)
            {

                if (number >= 1000000000)
                {
                    return Math.Round(((number / 1000000000) * 10)) / 10 * -1 + "B";
                }
                if (number >= 100000000)
                {
                    return Math.Round(((number / 100000000) * 10)) / 10 * -1 + "M";
                }
                if (number >= 1000)
                {
                    return Math.Round(((number / 1000) * 10)) / 10 * -1 + "K";
                }
            }

            return Math.Round(number, 2).ToString();
        }

        /// <summary>
        /// Adds the ordinal suffix for st, nd, rd and th.
        /// </summary>
        public static string ToOrdinal(this int number)
        {
            string suffix = "th";

            // gets condition for 11, 12, 13
            int preTeen = ((number % 100) / 10);
            if (preTeen != 1)
            {
                int lastDigit = (number % 10);
                switch (lastDigit)
                {
                    case 1:
                        suffix = "st";
                        break;
                    case 2:
                        suffix = "nd";
                        break;
                    case 3:
                        suffix = "rd";
                        break;
                }
            }
            return string.Format("{0}{1}", number, suffix);
        }

        /// <summary>
        /// Adds the ordinal suffix for st, nd, rd and th.
        /// </summary>
        public static string ToOrdinal(this short number)
        {
            string suffix = "th";

            // gets condition for 11, 12, 13
            int preTeen = ((number % 100) / 10);
            if (preTeen != 1)
            {
                int lastDigit = (number % 10);
                switch (lastDigit)
                {
                    case 1:
                        suffix = "st";
                        break;
                    case 2:
                        suffix = "nd";
                        break;
                    case 3:
                        suffix = "rd";
                        break;
                }
            }
            return string.Format("{0}{1}", number, suffix);
        }

        /// <summary>
        /// Returns the file size as a descriptive string (12MB)
        /// </summary>
        public static string ToFileSize(this int bytes)
        {
            if (bytes == 0)
            {
                return "0 MB";
            }

            string filesize = "MB";
            int divisor = 0;

            if (bytes >= 1073741824)
            {
                divisor = 1073741824;
                filesize = "GB";
            }
            else if (bytes >= 1048576)
            {
                divisor = 1048576;
            }
            else if (bytes >= 1024)
            {
                divisor = 1024;
                filesize = "KB";
            }
            else
            {
                return string.Format("{0:##.##} bytes", bytes);
            }

            return string.Format("{0:##.##} {1}", Arithmetic.Divide(bytes, divisor), filesize);
        }

        /// <summary>
        /// Returns the file size as a descriptive string (12MB)
        /// </summary>
        public static string ToFileSize(this double bytes)
        {
            if (bytes == 0)
            {
                return "0 MB";
            }

            string filesize = "MB";
            int divisor = 0;

            if (bytes >= 1073741824)
            {
                divisor = 1073741824;
                filesize = "GB";
            }
            else if (bytes >= 1048576)
            {
                divisor = 1048576;
            }
            else if (bytes >= 1024)
            {
                divisor = 1024;
                filesize = "KB";
            }
            else
            {
                return string.Format("{0:##.##} bytes", bytes);
            }

            return string.Format("{0:##.##} {1}", Arithmetic.Divide(bytes, divisor), filesize);
        }

        /// <summary>
        /// Returns the file size as a descriptive string (12MB)
        /// </summary>
        public static string ToFileSize(this long bytes)
        {
            if (bytes == 0)
            {
                return "0 MB";
            }

            string filesize = "MB";
            int divisor = 0;

            if (bytes >= 1073741824)
            {
                divisor = 1073741824;
                filesize = "GB";
            }
            else if (bytes >= 1048576)
            {
                divisor = 1048576;
            }
            else if (bytes >= 1024)
            {
                divisor = 1024;
                filesize = "KB";
            }
            else
            {
                return string.Format("{0:##.##} bytes", bytes);
            }

            return string.Format("{0:##.##} {1}", Arithmetic.Divide(bytes, divisor), filesize);
        }

        /// <summary>
        /// Formats the nullable value with the specified format if the number is not null, 
        /// otherwise, returns the default value
        /// </summary>
        /// <param name="format">The format to use if the number has a value</param>
        /// <param name="defaultValue">The value to return if the number is null. Defaults to ""</param>
        public static string ToFormat(this int? d, string format, string defaultValue = "")
        {
            if (!d.HasValue)
            {
                return defaultValue;
            }

            return d.Value.ToString(format);
        }

        /// <summary>
        /// Formats the nullable value with the specified format if the number is not null, 
        /// otherwise, returns the default value
        /// </summary>
        /// <param name="format">The format to use if the number has a value</param>
        /// <param name="defaultValue">The value to return if the number is null. Defaults to ""</param>
        public static string ToFormat(this double? d, string format, string defaultValue = "")
        {
            if (!d.HasValue)
            {
                return defaultValue;
            }

            return d.Value.ToString(format);
        }

        /// <summary>
        /// Formats the nullable value with the specified format if the number is not null, 
        /// otherwise, returns the default value
        /// </summary>
        /// <param name="format">The format to use if the number has a value</param>
        /// <param name="defaultValue">The value to return if the number is null. Defaults to ""</param>
        public static string ToFormat(this long? d, string format, string defaultValue = "")
        {
            if (!d.HasValue)
            {
                return defaultValue;
            }

            return d.Value.ToString(format);
        }

        /// <summary>
        /// Returns the number with a trailing percent and the space removed, unless overwritten
        /// </summary>        
        /// <param name="format">The format used, defaults to p1</param>
        /// <param name="decimalPlaces">The number of paces after the decimal</param>        
        /// <param name="defaultValue">The value return if the INT is null</param>
        /// <returns>The number as a string with the trailing %</returns>
        public static string ToHtmlPercent(this int? d, int decimalPlaces = 1, bool removeSpacePriorToPercent = true, string defaultValue = "")
        {
            if (!d.HasValue)
            {
                return defaultValue;
            }

            return d.ToHtmlPercent(decimalPlaces, removeSpacePriorToPercent);
        }

        /// <summary>
        /// Returns the number with a trailing percent and the space removed, unless overwritten
        /// </summary>        
        /// <param name="decimalPlaces">The number of paces after the decimal</param>        
        /// <returns>The number as a string with the trailing %</returns>
        public static string ToHtmlPercent(this int d, int decimalPlaces = 1, bool removeSpacePriorToPercent = true)
        {
            if (removeSpacePriorToPercent)
            {
                return d.ToString("p" + decimalPlaces).RemoveSpaces();
            }

            return d.ToString("p" + decimalPlaces);
        }


        /// <summary>
        /// Indicates whether this number is greater than the threshold provided
        /// </summary>
        public static bool IsGreaterThan(this int value, int threshold)
        {
            return value > threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than the threshold provided
        /// </summary>
        public static bool IsLessThan(this int value, int threshold)
        {
            return value < threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than or equal to the threshold provided
        /// </summary>
        public static bool IsLessThanEqualTo(this int value, int threshold)
        {
            return value <= threshold;
        }
        /// <summary>
        /// Indicates whether this number is greater than or equal to the threshold provided
        /// </summary>
        public static bool IsGreaterThanEqualTo(this int value, int threshold)
        {
            return value >= threshold;
        }
        /// <summary>
        /// Indicates whether this number is a postive number, greater than or equal to 0
        /// </summary>
        public static bool IsPositive(this int value)
        {
            return value >= 0;
        }
        /// <summary>
        /// Indicates whether this number is a negative number, less than 0
        /// </summary>
        public static bool IsNegative(this int value, int threshold)
        {
            return value < 0;
        }
        /// <summary>
        /// Indicates whether this number is within the range, including the start and end of the range
        /// </summary>
        public static bool IsInRange(this int value, int startRange, int endRange)
        {
            return (value.IsGreaterThanEqualTo(startRange) && value.IsLessThanEqualTo(endRange));
        }

        /// <summary>
        /// Indicates whether this number is greater than the threshold provided
        /// </summary>
        public static bool IsGreaterThan(this double value, double threshold)
        {
            return value > threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than the threshold provided
        /// </summary>
        public static bool IsLessThan(this double value, double threshold)
        {
            return value < threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than or equal to the threshold provided
        /// </summary>
        public static bool IsLessThanEqualTo(this double value, double threshold)
        {
            return value <= threshold;
        }
        /// <summary>
        /// Indicates whether this number is greater than or equal to the threshold provided
        /// </summary>
        public static bool IsGreaterThanEqualTo(this double value, double threshold)
        {
            return value >= threshold;
        }
        /// <summary>
        /// Indicates whether this number is a postive number, greater than or equal to 0
        /// </summary>
        public static bool IsPositive(this double value)
        {
            return value >= 0;
        }
        /// <summary>
        /// Indicates whether this number is a negative number, less than 0
        /// </summary>
        public static bool IsNegative(this double value, double threshold)
        {
            return value < 0;
        }
        /// <summary>
        /// Indicates whether this number is within the range, including the start and end of the range
        /// </summary>
        public static bool IsInRange(this double value, double startRange, double endRange)
        {
            return (value.IsGreaterThanEqualTo(startRange) && value.IsLessThanEqualTo(endRange));
        }

        /// <summary>
        /// Indicates whether this number is greater than the threshold provided
        /// </summary>
        public static bool IsGreaterThan(this long value, long threshold)
        {
            return value > threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than the threshold provided
        /// </summary>
        public static bool IsLessThan(this long value, long threshold)
        {
            return value < threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than or equal to the threshold provided
        /// </summary>
        public static bool IsLessThanEqualTo(this long value, long threshold)
        {
            return value <= threshold;
        }
        /// <summary>
        /// Indicates whether this number is greater than or equal to the threshold provided
        /// </summary>
        public static bool IsGreaterThanEqualTo(this long value, long threshold)
        {
            return value >= threshold;
        }
        /// <summary>
        /// Indicates whether this number is a postive number, greater than or equal to 0
        /// </summary>
        public static bool IsPositive(this long value)
        {
            return value >= 0;
        }
        /// <summary>
        /// Indicates whether this number is a negative number, less than 0
        /// </summary>
        public static bool IsNegative(this long value)
        {
            return value < 0;
        }
        /// <summary>
        /// Indicates whether this number is within the range, including the start and end of the range
        /// </summary>
        public static bool IsInRange(this long value, long startRange, long endRange)
        {
            return (value.IsGreaterThanEqualTo(startRange) && value.IsLessThanEqualTo(endRange));
        }

        /// <summary>
        /// Indicates whether this number is greater than the threshold provided
        /// </summary>
        public static bool IsGreaterThan(this byte value, byte threshold)
        {
            return value > threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than the threshold provided
        /// </summary>
        public static bool IsLessThan(this byte value, byte threshold)
        {
            return value < threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than or equal to the threshold provided
        /// </summary>
        public static bool IsLessThanEqualTo(this byte value, byte threshold)
        {
            return value <= threshold;
        }
        /// <summary>
        /// Indicates whether this number is greater than or equal to the threshold provided
        /// </summary>
        public static bool IsGreaterThanEqualTo(this byte value, byte threshold)
        {
            return value >= threshold;
        }
        /// <summary>
        /// Indicates whether this number is a postive number, greater than or equal to 0
        /// </summary>
        public static bool IsPositive(this byte value)
        {
            return value >= 0;
        }
        /// <summary>
        /// Indicates whether this number is a negative number, less than 0
        /// </summary>
        public static bool IsNegative(this byte value)
        {
            return value < 0;
        }
        /// <summary>
        /// Indicates whether this number is within the range, including the start and end of the range
        /// </summary>
        public static bool IsInRange(this byte value, byte startRange, byte endRange)
        {
            return (value.IsGreaterThanEqualTo(startRange) && value.IsLessThanEqualTo(endRange));
        }
    }
}
