using System;

namespace Toolshed
{
    public static class Arithmetic
    {
        public static double Divide(int dividend, int divisor, int? decimals = null)
        {
            return Divide(Convert.ToDouble(dividend), Convert.ToDouble(divisor), decimals);
        }
        public static double Divide(int dividend, double divisor, int? decimals = null)
        {
            return Divide(Convert.ToDouble(dividend), divisor, decimals);
        }


        //DOUBLE

        public static double Divide(double dividend, int divisor, int? decimals = null)
        {
            return Divide(dividend, Convert.ToDouble(divisor), decimals);
        }
        public static double Divide(double dividend, double divisor, int? decimals = null)
        {
            if (decimals.HasValue)
            {
                return Math.Round(dividend / divisor, decimals.Value);
            }
            else
            {
                return dividend / divisor;
            }
        }
        /// <summary>
        /// Divides the two numbers, returning a double with the specified number of decimal places. If either the dividend or divisor is null, the default value will be returned (defaults to 0).
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <param name="decimals"></param>
        /// <param name="defaultValue">The value returned if either the dividend or divisor is null</param>
        /// <returns></returns>
        public static double Divide(double? dividend, double? divisor, int? decimals = null, double defaultValue = 0)
        {
            if (dividend.HasValue && divisor.HasValue)
            {
                return Divide(dividend.Value, divisor.Value, decimals);
            }

            return defaultValue;
        }
        public static decimal Divide(decimal dividend, decimal divisor, int? decimals = null)
        {
            if (decimals.HasValue)
            {
                return Math.Round(dividend / divisor, decimals.Value);
            }
            else
            {
                return dividend / divisor;
            }
        }


        //DECIMALS

        /// <summary>
        /// Divides the two numbers, returning a double with the specified number of decimal places. If either the dividend or divisor is null, the default value will be returned (defaults to 0).
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <param name="decimals"></param>
        /// <param name="defaultValue">The value returned if either the dividend or divisor is null</param>
        /// <returns></returns>
        public static decimal Divide(decimal dividend, decimal divisor, int? decimals = null, decimal defaultValue = 0)
        {
            if (divisor > 0)
            {
                if (decimals.HasValue)
                {
                    return Math.Round(dividend / divisor, decimals.Value);
                }
                else
                {
                    return dividend / divisor;
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Divides the two numbers, returning a double with the specified number of decimal places. If either the dividend or divisor is null, the default value will be returned (defaults to 0).
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <param name="decimals"></param>
        /// <param name="defaultValue">The value returned if either the dividend or divisor is null</param>
        /// <returns></returns>
        public static decimal Divide(decimal? dividend, decimal? divisor, int? decimals = null, decimal defaultValue = 0)
        {
            if (dividend.HasValue && divisor.HasValue)
            {
                return Divide(dividend.Value, divisor.Value, decimals);
            }

            return defaultValue;
        }

        public static int GetQuintile(int rank, int totalRanked)
        {
            var quintileSize = Divide(totalRanked, 5);

            if (quintileSize < 1)
            {
                return 1;
            }

            int q = 1;
            for (double i = quintileSize; i <= totalRanked + 1; i = i + quintileSize)
            {
                if (rank <= i || q == 5)
                {
                    return q;
                }

                q++;
            }

            return q;
        }
        public static int GetQuintileSize(int totalRanked)
        {
            var quintileSize = (int)Divide(totalRanked, 5);

            if (quintileSize < 1)
            {
                return 1;
            }

            return quintileSize;
        }
    }
}
