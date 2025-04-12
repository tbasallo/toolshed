namespace Toolshed
{
    public static partial class Numbers
    {
        /// <summary>
        /// Returns the the percentage of the number as a value of the specified value (dividend) rounded to the specified decimal point
        /// </summary>
        /// <param name="dividend">The number to divide by</param>
        /// <param name="round">Optional value round the result by</param>
        public static double DivideBy(this int d, double dividend, int? round = null)
        {
            return Arithmetic.Divide(d, dividend, round);
        }
        /// <summary>
        /// Returns the the percentage of the number as a value of the specified value (dividend) rounded to the specified decimal point
        /// </summary>
        /// <param name="dividend">The number to divide by</param>
        /// <param name="round">Optional value round the result by</param>
        public static double DivideBy(this int d, int dividend, int? round = null)
        {
            return Arithmetic.Divide(d, dividend, round);
        }
        /// <summary>
        /// Returns the the percentage of the number as a value of the specified value (dividend) rounded to the specified decimal point
        /// </summary>
        /// <param name="dividend">The number to divide by</param>
        /// <param name="round">Optional value round the result by</param>


        /// <summary>
        /// Returns the the percentage of the number as a value of the specified value (dividend) rounded to the specified decimal point
        /// </summary>
        /// <param name="dividend">The number to divide by</param>
        /// <param name="round">Optional value round the result by</param>
        public static double DivideBy(this double d, int dividend, int? round = null)
        {
            return Arithmetic.Divide(d, dividend, round);
        }
        /// <summary>
        /// Returns the the percentage of the number as a value of the specified value (dividend) rounded to the specified decimal point
        /// </summary>
        /// <param name="dividend">The number to divide by</param>
        /// <param name="round">Optional value round the result by</param>
        public static double DivideBy(this double d, double dividend, int? round = null)
        {
            return Arithmetic.Divide(d, dividend, round);
        }


        /// <summary>
        /// Returns the the percentage of the number as a value of the specified value (dividend) rounded to the specified decimal point
        /// </summary>
        /// <param name="dividend">The number to divide by</param>
        /// <param name="round">Optional value round the result by</param>
        public static double DivideBy(this long d, int dividend, int? round = null)
        {
            return Arithmetic.Divide(d, dividend, round);
        }
        /// <summary>
        /// Returns the the percentage of the number as a value of the specified value (dividend) rounded to the specified decimal point
        /// </summary>
        /// <param name="dividend">The number to divide by</param>
        /// <param name="round">Optional value round the result by</param>
        public static double DivideBy(this long d, double dividend, int? round = null)
        {
            return Arithmetic.Divide(d, dividend, round);
        }
    }
}
