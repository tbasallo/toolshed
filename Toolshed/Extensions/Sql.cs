using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Toolshed
{
    public static class Sql
    {
        /// <summary>
        /// Returns a string that can be used in a T-SQL statement. The returned string is comma delimited wrapped in parenthesis: ('x','y','z')
        /// </summary>
        public static string ToSqlSelectInClause(this IEnumerable<DateTime> collection)
        {
            if (collection.Count() == 0)
            {
                return "()";
            }

            StringBuilder sb = new StringBuilder("(");
            foreach (var item in collection)
            {
                sb.AppendFormat("'{0}',", item);
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            return sb.ToString();
        }
        /// <summary>
        /// Returns a string that can be used in a T-SQL statement. The returned string is comma delimited wrapped in parenthesis: ('x','y','z')
        /// </summary>
        public static string ToSqlSelectInClause(this IEnumerable<double> collection)
        {
            if (collection.Count() == 0)
            {
                return "()";
            }

            StringBuilder sb = new StringBuilder("(");
            foreach (var item in collection)
            {
                sb.AppendFormat("'{0}',", item);
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            return sb.ToString();
        }
        /// <summary>
        /// Returns a string that can be used in a T-SQL statement. The returned string is comma delimited wrapped in parenthesis: ('x','y','z')
        /// </summary>
        public static string ToSqlSelectInClause(this IEnumerable<int> collection)
        {
            if (collection.Count() == 0)
            {
                return "()";
            }

            StringBuilder sb = new StringBuilder("(");
            foreach (var item in collection)
            {
                sb.AppendFormat("'{0}',", item);
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            return sb.ToString();
        }
        /// <summary>
        /// Returns a string that can be used in a T-SQL statement. The returned string is comma delimited wrapped in parenthesis: ('x','y','z')
        /// </summary>
        public static string ToSqlSelectInClause(this IEnumerable<long> collection)
        {
            if (collection.Count() == 0)
            {
                return "()";
            }

            StringBuilder sb = new StringBuilder("(");
            foreach (var item in collection)
            {
                sb.AppendFormat("'{0}',", item);
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            return sb.ToString();
        }
        /// <summary>
        /// Returns a string that can be used in a T-SQL statement. The returned string is comma delimited wrapped in parenthesis: ('x','y','z')
        /// </summary>
        public static string ToSqlSelectInClause(this IEnumerable<string> collection)
        {
            if (collection.Count() == 0)
            {
                return "()";
            }


            StringBuilder sb = new StringBuilder("(");

            foreach (var item in collection)
            {
                sb.AppendFormat("'{0}',", item);
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            return sb.ToString();
        }

    }
}
