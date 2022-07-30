using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toolshed
{
    public static class LinqExtensions
    {
        public static double AverageOrDefault<T>(this IEnumerable<T> list, Func<T, double> selector)
        {
            if (list == null || !list.Any())
            {
                return 0;
            }

            return list.Select(selector).Average();
        }
        public static double AverageOrDefault<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
            if (list == null || !list.Any())
            {
                return 0;
            }

            return list.Select(selector).Average();
        }


        public static double SumOrDefault<T>(this IEnumerable<T> list, Func<T, double> selector)
        {
            if (list == null || !list.Any())
            {
                return 0;
            }

            return list.Select(selector).Sum();
        }
        public static int SumOrDefault<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
            if (list == null || !list.Any())
            {
                return 0;
            }

            return list.Select(selector).Sum();
        }


        public static DateTime MaxOrDefault<T>(this IEnumerable<T> list, Func<T, DateTime> selector, DateTime? defaultValue = null)
        {
            if (list == null || !list.Any())
            {
                return defaultValue.GetValueOrDefault(DateTime.MaxValue);
            }

            return list.Select(selector).Max();
        }
        
        
        /// <summary>
        /// Checks the list for items and returns 0 if the IEnumerable is null or empty, otherwise returns the count using Count()
        /// </summary>        
        public static int CountOrDefault<T>(this IEnumerable<T> list)
        {
            if (list == null || !list.Any())
            {
                return 0;
            }

            return list.Count();
        }
    }
}
