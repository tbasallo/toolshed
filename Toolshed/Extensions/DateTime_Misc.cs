using System;

namespace Toolshed
{
    public static partial class DateHelperExtensions
    {
        /// <summary>
        /// Returns a DateOnly instance from the DateTime 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateOnly AsDateOnly(this DateTime date)
        {
            return DateOnly.FromDateTime(date);
        }

        /// <summary>
        /// Rounds the datetime based on the specified DateTimeRoundTo
        /// </summary>
        public static DateTime Round(this DateTime d, DateTimeRoundTo dateTimeRoundTo)
        {
            DateTime dtRounded = new DateTime();

            switch (dateTimeRoundTo)
            {
                case DateTimeRoundTo.Second:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                    if (d.Millisecond >= 500) dtRounded = dtRounded.AddSeconds(1);
                    break;
                case DateTimeRoundTo.Minute:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0);
                    if (d.Second >= 30) dtRounded = dtRounded.AddMinutes(1);
                    break;
                case DateTimeRoundTo.Hour:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0);
                    if (d.Minute >= 30) dtRounded = dtRounded.AddHours(1);
                    break;
                case DateTimeRoundTo.Day:
                    dtRounded = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                    if (d.Hour >= 12) dtRounded = dtRounded.AddDays(1);
                    break;
            }

            return dtRounded;
        }
    }
}