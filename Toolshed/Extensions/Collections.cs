using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Toolshed
{
    public static class Collections
    {
        /// <summary>
        /// Indicates whether the collection is null or empty
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> list)
        {
            return list == null || list.Count == 0;
        }

        /// <summary>
        /// Indicates whether the collection has items
        /// <para>Uses the count property in the ICollection interface</para>
        /// </summary>
        public static bool HasItems<T>(this ICollection<T> collection)
        {
            if (collection == null)
            {
                return false;
            }

            return collection.Count > 0;
        }

        /// <summary>
        /// Returns a random object from the collection.
        /// <para>Will return null if the collection is null or has 0 items</para>
        /// </summary>
        public static T GetRandom<T>(this ICollection<T> collection)
        {
            if(collection.IsNullOrEmpty())
            {
                return default(T);
            }

            if (collection.Count == 1)
            {
                return collection.ElementAt(0);
            }

            return collection.ElementAt(new Random().Next(collection.Count));
        }

        /// <summary>
        /// Returns the collection as a delimited string. For example, a collection of strings ["a", "b", "c", "d"] is returned as "a,b,c,d"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection of items to delimit into a string</param>
        /// <param name="delimiter">The delimiter to use to separate the collection items, Defaults to ","</param>
        /// <param name="format">An optional format string that can be used to format each item while being delimited. Should use the following format: {0:p2}</param>
        /// <param name="spaceBetweenDelimiter">Indicates whether a space should be inserted between the end of one delimiter and the start of the next item: "a,b,c" vs. "a, b, c"</param>
        /// <param name="ignoreNullValues">If true, removes null values from the returned string. Defaults to false (i.e will return a,c)</param>
        /// <returns>A string where the collection items are delimited using the specified delimiter</returns>
        public static string ToDelimitedString<T>(this ICollection<T> collection, string delimiter = ",", string format = null, bool spaceBetweenDelimiter = true, bool ignoreNullValues = false) where T : IComparable
        {
            if (collection.Count < 1)
            {
                return string.Empty;
            }

            if (collection.Count == 1)
            {
                if(string.IsNullOrWhiteSpace(format)) { return collection.ElementAt(0).ToString(); }
                return string.Format(format, collection.ElementAt(0).ToString());
            }

            //no point in putting two empty spaces between the words
            if (delimiter == " " && spaceBetweenDelimiter)
            {
                spaceBetweenDelimiter = false;
            }

            var sb = new StringBuilder();
            delimiter = spaceBetweenDelimiter.ToString(delimiter + " ", delimiter);

            if (string.IsNullOrWhiteSpace(format))
            {
                foreach (var item in collection)
                {
                    if (ignoreNullValues && item == null)
                    {
                        continue;
                    }
                    sb.AppendFormat("{0}{1}", item, delimiter);
                }
            }
            else
            {
                foreach (var item in collection)
                {
                    if (ignoreNullValues && item == null)
                    {
                        continue;
                    }
                    sb.AppendFormat(format, item + delimiter);
                }
            }

            return sb.Remove(sb.Length - delimiter.Length, delimiter.Length).ToString().TrimEnd();
        }

        /// <summary>
        /// Returns the collection as a delimited string. For example, a collection of strings ["a", "b", "c", "d"] is returned as "a,b,c,d"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection of items to delimit into a string</param>
        /// <param name="delimiter">The delimiter to use to separate the collection items, Defaults to ","</param>
        /// <param name="format">An optional format string that can be used to format each item while being delimited. Should use the following format: {0:p2}</param>
        /// <param name="spaceBetweenDelimiter">Indicates whether a space should be inserted between the end of one delimiter and the start of the next item: "a,b,c" vs. "a, b, c"</param>
        /// <param name="ignoreNullValues">If true, removes null values from the returned string. Defaults to false (i.e will return a,c)</param>
        /// <returns>A string where the collection items are delimited using the specified delimiter</returns>
        public static string ToDelimitedString(this ICollection<string> collection, string delimiter = ",", string format = null, bool spaceBetweenDelimiter = true, bool ignoreNullValues = false)
        {
            if (collection.Count < 1)
            {
                return string.Empty;
            }

            if (collection.Count == 1)
            {
                if (string.IsNullOrWhiteSpace(format)) { return collection.ElementAt(0); }
                return string.Format(format, collection.ElementAt(0));
            }

            //no point in putting two empty spaces between the words
            if (delimiter == " " && spaceBetweenDelimiter)
            {
                spaceBetweenDelimiter = false;
            }

            var sb = new StringBuilder();
            delimiter = spaceBetweenDelimiter ? delimiter + " " : delimiter;

            if (string.IsNullOrWhiteSpace(format))
            {
                foreach (var item in collection)
                {
                    if (ignoreNullValues && item == null)
                    {
                        continue;
                    }
                    sb.AppendFormat("{0}{1}", item, delimiter);
                }
            }
            else
            {
                foreach (var item in collection)
                {
                    if (ignoreNullValues && item == null)
                    {
                        continue;
                    }
                    sb.AppendFormat(format, item + delimiter);
                }
            }

            return sb.Remove(sb.Length - delimiter.Length, delimiter.Length).ToString().TrimEnd();
        }


        /// <summary>
        /// Returns the collection as a JavaScript array (e.g., ["val1","val2","val3"])
        /// </summary>
        public static string ToJavascriptArray<T>(this ICollection<T> collection)
        {
            if (collection.Count < 1)
            {
                return "[]";
            }

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var item in collection)
            {
                sb.AppendFormat("'{0}',", item);
            }

            //get rid of the last comma and return
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");

            return sb.ToString();
        }
        
        /// <summary>
        /// Returns the specified list as an IEnumerable of the same list type of sizes no more than the specified group size.
        /// </summary>
        public static IEnumerable<List<T>> SplitBy<T>(List<T> list, int groupSize)
        {
            if (list == null || list.Count == 0) yield break;

            if (list.Count <= groupSize)
            {
                yield return list;
            }

            if (groupSize < 1) throw new ArgumentException("groupSize must be greater than 0", "groupSize");

            for (int i = 0; i < list.Count; i += groupSize)
            {
                yield return list.GetRange(i, Math.Min(groupSize, list.Count - i));
            }
        }


        public static (double beforeValue, double afterValue) GetBeforeAndAfterValues(this IEnumerable<double> source, double value, double defaultBefore = double.MinValue, double defaultAfter = double.MaxValue)
        {
            double before = defaultBefore;
            double after = defaultAfter;
            foreach (var x in source)
            {
                if (x <= value && x > before)
                {
                    before = x;
                }
                if (x >= value && x <= after)
                {
                    after = x;
                }
            }

            return (before, after);
        }
    }
}
