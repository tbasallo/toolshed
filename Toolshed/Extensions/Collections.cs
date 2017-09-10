using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Toolshed
{
    public static class Collections
    {
        /// <summary>
        /// Returns whether the collection is null or empty
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsNullOrEmpty(this ICollection list)
        {
            return list == null || list.Count == 0;
        }
    }
}
