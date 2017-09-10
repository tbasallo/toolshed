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
        public static double Divide(double dividend, int divisor, int? decimals = null)
        {
            return Divide(dividend, Convert.ToDouble(divisor), decimals);
        }
        public static double Divide(double? dividend, double? divisor, int? decimals = null, double defaultValue = 0)
        {
            if (dividend.HasValue && divisor.HasValue)
            {
                return Divide(dividend.Value, divisor.Value, decimals);
            }

            return defaultValue;
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
