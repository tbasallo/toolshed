namespace Toolshed
{
    public static partial class Numbers
    {
        private const long BYTES_IN_GB = 1073741824;
        private const long BYTES_IN_MB = 1048576;
        private const long BYTES_IN_KB = 1024;

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
                var absNumber = Math.Abs(number);
                if (absNumber >= 1000000000)
                {
                    return "-" + Math.Round(((absNumber / 1000000000) * 10)) / 10 + "B";
                }
                if (absNumber >= 1000000)
                {
                    return "-" + Math.Round(((absNumber / 1000000) * 10)) / 10 + "M";
                }
                if (absNumber >= 1000)
                {
                    return "-" + Math.Round(((absNumber / 1000) * 10)) / 10 + "K";
                }
            }

            return Math.Round(number, 2).ToString();
        }

        /// <summary>
        /// Returns the number rounded to the largest segment with the suffix of K,M,B for thousand, million or billion
        /// </summary>
        public static string ToSemanticValue(this decimal number)
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
                var absNumber = Math.Abs(number);
                if (absNumber >= 1000000000)
                {
                    return "-" + Math.Round(((absNumber / 1000000000) * 10)) / 10 + "B";
                }
                if (absNumber >= 1000000)
                {
                    return "-" + Math.Round(((absNumber / 1000000) * 10)) / 10 + "M";
                }
                if (absNumber >= 1000)
                {
                    return "-" + Math.Round(((absNumber / 1000) * 10)) / 10 + "K";
                }
            }

            return Math.Round(number, 2).ToString();
        }

        /// <summary>
        /// Returns the number rounded to the largest segment with the suffix of K,M,B for thousand, million or billion
        /// </summary>
        public static string ToSemanticValue(this float number)
        {
            var amount = Convert.ToDouble(number);
            return amount.ToSemanticValue();
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
        /// Adds the ordinal suffix for st, nd, rd and th.
        /// </summary>
        public static string ToOrdinal(this decimal number)
        {
            string suffix = "th";

            // gets condition for 11, 12, 13
            int preTeen = ((int)(number % 100) / 10);
            if (preTeen != 1)
            {
                int lastDigit = ((int)number % 10);
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
        public static string ToOrdinal(this float number)
        {
            string suffix = "th";

            // gets condition for 11, 12, 13
            int preTeen = ((int)(number % 100) / 10);
            if (preTeen != 1)
            {
                int lastDigit = ((int)number % 10);
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
            long divisor;

            if (bytes >= BYTES_IN_GB)
            {
                divisor = BYTES_IN_GB;
                filesize = "GB";
            }
            else if (bytes >= BYTES_IN_MB)
            {
                divisor = BYTES_IN_MB;
            }
            else if (bytes >= BYTES_IN_KB)
            {
                divisor = BYTES_IN_KB;
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
            long divisor;

            if (bytes >= BYTES_IN_GB)
            {
                divisor = BYTES_IN_GB;
                filesize = "GB";
            }
            else if (bytes >= BYTES_IN_MB)
            {
                divisor = BYTES_IN_MB;
            }
            else if (bytes >= BYTES_IN_KB)
            {
                divisor = BYTES_IN_KB;
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
            long divisor;

            if (bytes >= BYTES_IN_GB)
            {
                divisor = BYTES_IN_GB;
                filesize = "GB";
            }
            else if (bytes >= BYTES_IN_MB)
            {
                divisor = BYTES_IN_MB;
            }
            else if (bytes >= BYTES_IN_KB)
            {
                divisor = BYTES_IN_KB;
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
        public static string ToFileSize(this decimal bytes)
        {
            if (bytes == 0)
            {
                return "0 MB";
            }

            string filesize = "MB";
            long divisor;

            if (bytes >= BYTES_IN_GB)
            {
                divisor = BYTES_IN_GB;
                filesize = "GB";
            }
            else if (bytes >= BYTES_IN_MB)
            {
                divisor = BYTES_IN_MB;
            }
            else if (bytes >= BYTES_IN_KB)
            {
                divisor = BYTES_IN_KB;
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
        public static string ToFileSize(this float bytes)
        {
            if (bytes == 0)
            {
                return "0 MB";
            }

            string filesize = "MB";
            long divisor;

            if (bytes >= BYTES_IN_GB)
            {
                divisor = BYTES_IN_GB;
                filesize = "GB";
            }
            else if (bytes >= BYTES_IN_MB)
            {
                divisor = BYTES_IN_MB;
            }
            else if (bytes >= BYTES_IN_KB)
            {
                divisor = BYTES_IN_KB;
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
        /// Formats the nullable value with the specified format if the number is not null,
        /// otherwise, returns the default value
        /// </summary>
        /// <param name="format">The format to use if the number has a value</param>
        /// <param name="defaultValue">The value to return if the number is null. Defaults to ""</param>
        public static string ToFormat(this decimal? d, string format, string defaultValue = "")
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
        public static string ToFormat(this float? d, string format, string defaultValue = "")
        {
            if (!d.HasValue)
            {
                return defaultValue;
            }

            return d.Value.ToString(format);
        }

        /// <summary>
        /// Converts a double value to an HTMl friendly version.
        /// </summary>
        /// <param name="format">THe extact  version to display. By default it will use p1 or 1 place after the decimal.</param>
        /// <param name="defaultValueForNanOrInfinity">TH evalue to display instead of NaN or Inifinity. Specify null if Nan or Infinity is desired.</param>
        /// <param name="overrideValueForZeroResult">The value to display instead of 0. Specify null (default) to display 0</param>
        /// <param name="removeSpaces">Whether to display a space between the value and the %, e.g., 34.45% vs. 34.45 %</param>
        /// <returns>A string that looks like 34.45% where string.format(value, format) would be true.</returns>
        public static string ToHtmlPercent(this int value, string format = "p1", string defaultValueForNanOrInfinity = "", string overrideValueForZeroResult = null, string overrideValueFor1 = null, bool removeSpaces = true)
        {
            if (!format.StartsWith("p"))
            {
                throw new ArgumentException("Format must start with p to represent a percentage, e.g., p1, p2, etc.", format);
            }

            if (value == 0 && overrideValueForZeroResult != null)
            {
                return overrideValueForZeroResult;
            }

            if (value == 1 && overrideValueFor1 != null)
            {
                return overrideValueFor1;
            }

            if ((double.IsNaN(value) || double.IsInfinity(value)) && defaultValueForNanOrInfinity != null)
            {
                return defaultValueForNanOrInfinity;
            }

            if (removeSpaces)
            {
                return value.ToString(format).RemoveSpaces();
            }
            else
            {
                return value.ToString(format);
            }
        }

        /// <summary>
        /// Converts a double value to an HTMl friendly version.
        /// </summary>
        /// <param name="format">THe extact  version to display. By default it will use p1 or 1 place after the decimal.</param>
        /// <param name="defaultValueForNanOrInfinityOrNull">The value to display for NULL values or instead of NaN or Inifinity. Specify null if Nan or Infinity is desired.</param>
        /// <param name="overrideValueForZeroResult">The value to display instead of 0. Specify null (default) to display 0</param>
        /// <param name="removeSpaces">Whether to display a space between the value and the %, e.g., 34.45% vs. 34.45 %</param>
        /// <returns>A string that looks like 34.45% where string.format(value, format) would be true.</returns>
        public static string ToHtmlPercent(this int? value, string format = "p1", string defaultValueForNanOrInfinityOrNull = "", string overrideValueForZeroResult = null, string overrideValueFor1 = null, bool removeSpaces = true)
        {
            if (!value.HasValue)
            {
                return defaultValueForNanOrInfinityOrNull;
            }

            return value.Value.ToHtmlPercent(format, defaultValueForNanOrInfinityOrNull, overrideValueForZeroResult, overrideValueFor1, removeSpaces);
        }

        /// <summary>
        /// Converts a double value to an HTMl friendly version.
        /// </summary>
        /// <param name="format">THe extact  version to display. By default it will use p1 or 1 place after the decimal.</param>
        /// <param name="defaultValueForNanOrInfinity">TH evalue to display instead of NaN or Inifinity. Specify null if Nan or Infinity is desired.</param>
        /// <param name="overrideValueForZeroResult">The value to display instead of 0. Specify null (default) to display 0</param>
        /// <param name="removeSpaces">Whether to display a space between the value and the %, e.g., 34.45% vs. 34.45 %</param>
        /// <returns>A string that looks like 34.45% where string.format(value, format) would be true.</returns>
        public static string ToHtmlPercent(this double value, string format = "p1", string defaultValueForNanOrInfinity = "", string overrideValueForZeroResult = null, string overrideValueFor1 = null, bool removeSpaces = true)
        {
            if (!format.StartsWith("p"))
            {
                throw new ArgumentException("Format must start with p to represent a percentage, e.g., p1, p2, etc.", format);
            }

            if (value == 0 && overrideValueForZeroResult != null)
            {
                return overrideValueForZeroResult;
            }

            if (value == 1 && overrideValueFor1 != null)
            {
                return overrideValueFor1;
            }

            if ((double.IsNaN(value) || double.IsInfinity(value)) && defaultValueForNanOrInfinity != null)
            {
                return defaultValueForNanOrInfinity;
            }

            if (removeSpaces)
            {
                return value.ToString(format).RemoveSpaces();
            }
            else
            {
                return value.ToString(format);
            }
        }

        /// <summary>
        /// Converts a double value to an HTMl friendly version.
        /// </summary>
        /// <param name="format">THe extact  version to display. By default it will use p1 or 1 place after the decimal.</param>
        /// <param name="defaultValueForNanOrInfinityOrNull">The value to display for NULL values or instead of NaN or Inifinity. Specify null if Nan or Infinity is desired.</param>
        /// <param name="overrideValueForZeroResult">The value to display instead of 0. Specify null (default) to display 0</param>
        /// <param name="removeSpaces">Whether to display a space between the value and the %, e.g., 34.45% vs. 34.45 %</param>
        /// <returns>A string that looks like 34.45% where string.format(value, format) would be true.</returns>
        public static string ToHtmlPercent(this double? value, string format = "p1", string defaultValueForNanOrInfinityOrNull = "", string overrideValueForZeroResult = null, string overrideValueFor1 = null, bool removeSpaces = true)
        {
            if (!value.HasValue)
            {
                return defaultValueForNanOrInfinityOrNull;
            }

            return value.Value.ToHtmlPercent(format, defaultValueForNanOrInfinityOrNull, overrideValueForZeroResult, overrideValueFor1, removeSpaces);
        }

        /// <summary>
        /// Converts a double value to an HTMl friendly version.
        /// </summary>
        /// <param name="format">THe extact  version to display. By default it will use p1 or 1 place after the decimal.</param>
        /// <param name="defaultValueForNanOrInfinity">TH evalue to display instead of NaN or Inifinity. Specify null if Nan or Infinity is desired.</param>
        /// <param name="overrideValueForZeroResult">The value to display instead of 0. Specify null (default) to display 0</param>
        /// <param name="removeSpaces">Whether to display a space between the value and the %, e.g., 34.45% vs. 34.45 %</param>
        /// <returns>A string that looks like 34.45% where string.format(value, format) would be true.</returns>
        public static string ToHtmlPercent(this decimal value, string format = "p1", string defaultValueForNanOrInfinity = "", string overrideValueForZeroResult = null, string overrideValueFor1 = null, bool removeSpaces = true)
        {
            if (!format.StartsWith("p"))
            {
                throw new ArgumentException("Format must start with p to represent a percentage, e.g., p1, p2, etc.", format);
            }

            if (value == 0 && overrideValueForZeroResult != null)
            {
                return overrideValueForZeroResult;
            }

            if (value == 1 && overrideValueFor1 != null)
            {
                return overrideValueFor1;
            }

            if (removeSpaces)
            {
                return value.ToString(format).RemoveSpaces();
            }
            else
            {
                return value.ToString(format);
            }
        }

        /// <summary>
        /// Converts a double value to an HTMl friendly version.
        /// </summary>
        /// <param name="format">THe extact  version to display. By default it will use p1 or 1 place after the decimal.</param>
        /// <param name="defaultValueForNanOrInfinityOrNull">The value to display for NULL values or instead of NaN or Inifinity. Specify null if Nan or Infinity is desired.</param>
        /// <param name="overrideValueForZeroResult">The value to display instead of 0. Specify null (default) to display 0</param>
        /// <param name="removeSpaces">Whether to display a space between the value and the %, e.g., 34.45% vs. 34.45 %</param>
        /// <returns>A string that looks like 34.45% where string.format(value, format) would be true.</returns>
        public static string ToHtmlPercent(this decimal? value, string format = "p1", string defaultValueForNanOrInfinityOrNull = "", string overrideValueForZeroResult = null, string overrideValueFor1 = null, bool removeSpaces = true)
        {
            if (!value.HasValue)
            {
                return defaultValueForNanOrInfinityOrNull;
            }

            return value.Value.ToHtmlPercent(format, defaultValueForNanOrInfinityOrNull, overrideValueForZeroResult, overrideValueFor1, removeSpaces);
        }

        /// <summary>
        /// Converts a double value to an HTMl friendly version.
        /// </summary>
        /// <param name="format">THe extact  version to display. By default it will use p1 or 1 place after the decimal.</param>
        /// <param name="defaultValueForNanOrInfinity">TH evalue to display instead of NaN or Inifinity. Specify null if Nan or Infinity is desired.</param>
        /// <param name="overrideValueForZeroResult">The value to display instead of 0. Specify null (default) to display 0</param>
        /// <param name="removeSpaces">Whether to display a space between the value and the %, e.g., 34.45% vs. 34.45 %</param>
        /// <returns>A string that looks like 34.45% where string.format(value, format) would be true.</returns>
        public static string ToHtmlPercent(this float value, string format = "p1", string defaultValueForNanOrInfinity = "", string overrideValueForZeroResult = null, string overrideValueFor1 = null, bool removeSpaces = true)
        {
            if (!format.StartsWith("p"))
            {
                throw new ArgumentException("Format must start with p to represent a percentage, e.g., p1, p2, etc.", format);
            }

            if (value == 0 && overrideValueForZeroResult != null)
            {
                return overrideValueForZeroResult;
            }

            if (value == 1 && overrideValueFor1 != null)
            {
                return overrideValueFor1;
            }

            if ((float.IsNaN(value) || float.IsInfinity(value)) && defaultValueForNanOrInfinity != null)
            {
                return defaultValueForNanOrInfinity;
            }

            if (removeSpaces)
            {
                return value.ToString(format).RemoveSpaces();
            }
            else
            {
                return value.ToString(format);
            }
        }

        /// <summary>
        /// Converts a double value to an HTMl friendly version.
        /// </summary>
        /// <param name="format">THe extact  version to display. By default it will use p1 or 1 place after the decimal.</param>
        /// <param name="defaultValueForNanOrInfinityOrNull">The value to display for NULL values or instead of NaN or Inifinity. Specify null if Nan or Infinity is desired.</param>
        /// <param name="overrideValueForZeroResult">The value to display instead of 0. Specify null (default) to display 0</param>
        /// <param name="removeSpaces">Whether to display a space between the value and the %, e.g., 34.45% vs. 34.45 %</param>
        /// <returns>A string that looks like 34.45% where string.format(value, format) would be true.</returns>
        public static string ToHtmlPercent(this float? value, string format = "p1", string defaultValueForNanOrInfinityOrNull = "", string overrideValueForZeroResult = null, string overrideValueFor1 = null, bool removeSpaces = true)
        {
            if (!value.HasValue)
            {
                return defaultValueForNanOrInfinityOrNull;
            }

            return value.Value.ToHtmlPercent(format, defaultValueForNanOrInfinityOrNull, overrideValueForZeroResult, overrideValueFor1, removeSpaces);
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
        public static bool IsNegative(this int value)
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
        public static bool IsNegative(this double value)
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
        /// Indicates whether this number is within the range, including the start and end of the range
        /// </summary>
        public static bool IsInRange(this byte value, byte startRange, byte endRange)
        {
            return (value.IsGreaterThanEqualTo(startRange) && value.IsLessThanEqualTo(endRange));
        }

        /// <summary>
        /// Indicates whether this number is greater than the threshold provided
        /// </summary>
        public static bool IsGreaterThan(this decimal value, decimal threshold)
        {
            return value > threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than the threshold provided
        /// </summary>
        public static bool IsLessThan(this decimal value, decimal threshold)
        {
            return value < threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than or equal to the threshold provided
        /// </summary>
        public static bool IsLessThanEqualTo(this decimal value, decimal threshold)
        {
            return value <= threshold;
        }
        /// <summary>
        /// Indicates whether this number is greater than or equal to the threshold provided
        /// </summary>
        public static bool IsGreaterThanEqualTo(this decimal value, decimal threshold)
        {
            return value >= threshold;
        }
        /// <summary>
        /// Indicates whether this number is a postive number, greater than or equal to 0
        /// </summary>
        public static bool IsPositive(this decimal value)
        {
            return value >= 0;
        }
        /// <summary>
        /// Indicates whether this number is a negative number, less than 0
        /// </summary>
        public static bool IsNegative(this decimal value)
        {
            return value < 0;
        }
        /// <summary>
        /// Indicates whether this number is within the range, including the start and end of the range
        /// </summary>
        public static bool IsInRange(this decimal value, decimal startRange, decimal endRange)
        {
            return (value.IsGreaterThanEqualTo(startRange) && value.IsLessThanEqualTo(endRange));
        }

        /// <summary>
        /// Indicates whether this number is greater than the threshold provided
        /// </summary>
        public static bool IsGreaterThan(this float value, float threshold)
        {
            return value > threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than the threshold provided
        /// </summary>
        public static bool IsLessThan(this float value, float threshold)
        {
            return value < threshold;
        }
        /// <summary>
        /// Indicates whether this number is less than or equal to the threshold provided
        /// </summary>
        public static bool IsLessThanEqualTo(this float value, float threshold)
        {
            return value <= threshold;
        }
        /// <summary>
        /// Indicates whether this number is greater than or equal to the threshold provided
        /// </summary>
        public static bool IsGreaterThanEqualTo(this float value, float threshold)
        {
            return value >= threshold;
        }
        /// <summary>
        /// Indicates whether this number is a postive number, greater than or equal to 0
        /// </summary>
        public static bool IsPositive(this float value)
        {
            return value >= 0;
        }
        /// <summary>
        /// Indicates whether this number is a negative number, less than 0
        /// </summary>
        public static bool IsNegative(this float value)
        {
            return value < 0;
        }
        /// <summary>
        /// Indicates whether this number is within the range, including the start and end of the range
        /// </summary>
        public static bool IsInRange(this float value, float startRange, float endRange)
        {
            return (value.IsGreaterThanEqualTo(startRange) && value.IsLessThanEqualTo(endRange));
        }
    }
}
