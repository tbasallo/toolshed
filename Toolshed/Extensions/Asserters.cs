using System;
using System.Collections.Generic;
using System.Text;

namespace Toolshed
{
    public static class Asserters
    {
        /// <summary>
        /// Indicates whether the object is null
        /// </summary>
        /// <param name="o">Since this is an extension method we can actually check ourself for null. Cool!</param>
        /// <returns>A boolean indicating if the object is null</returns>
        public static bool IsNull(this object o)
        {
            return (o == null);
        }

        /// <summary>
        /// Indicates whether the object is not null
        /// </summary>
        /// <param name="o">Since this is an extension method we can actually check ourself for null. Cool!</param>
        /// <returns>A boolean indicating if the object is not null</returns>
        public static bool IsNotNull(this object o)
        {
            return (o != null);
        }
    }
}
