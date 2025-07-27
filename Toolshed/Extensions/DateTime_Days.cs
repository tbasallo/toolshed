namespace Toolshed
{
    public static partial class DateHelperExtensions
    {




        /// <summary>
        /// Returns yesterday by subtracting one day
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime Yesterday(this DateTime date)
        {
            return date.AddDays(-1);
        }

        /// <summary>
        /// Returns tomorrow by adding one day
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime Tomorrow(this DateTime date)
        {
            return date.AddDays(1);
        }

        /// <summary>
        /// Returns last week by subtracting 7 days days
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime LastWeek(this DateTime date)
        {
            return date.AddDays(-7);
        }

        /// <summary>
        /// Returns next week by adding 7 days days
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateTime NextWeek(this DateTime date)
        {
            return date.AddDays(-7);
        }


        /// <summary>
        /// Returns yesterday by subtracting one day
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly Yesterday(this DateOnly date)
        {
            return date.AddDays(-1);
        }

        /// <summary>
        /// Returns tomorrow by adding one day
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly Tomorrow(this DateOnly date)
        {
            return date.AddDays(1);
        }

        /// <summary>
        /// Returns last week by subtracting 7 days days
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly LastWeek(this DateOnly date)
        {
            return date.AddDays(-7);
        }

        /// <summary>
        /// Returns next week by adding 7 days days
        /// <para>The default start of week is used</para>
        /// </summary>
        public static DateOnly NextWeek(this DateOnly date)
        {
            return date.AddDays(-7);
        }
    }
}