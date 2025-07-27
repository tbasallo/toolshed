namespace Toolshed
{
    public partial class DateHelper
    {
        /// <summary>
        /// Returns the quarter that the date provided is in
        /// </summary>
        /// <returns>An integer indicating the quarter that the date is in</returns>
        public static int GetQuarter(this DateTime date)
        {
            if (date.Month > 9) return 4;
            else if (date.Month > 6) return 3;
            else if (date.Month > 3) return 2;

            return 1;
        }
    }
}
