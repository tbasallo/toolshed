using System;
using System.Collections.Generic;
using System.Text;

namespace Toolshed
{
    public static class Numbers
    {
        //Not sure if I needed it, but I loved the potential, so it's here
        //SO: https://stackoverflow.com/questions/954198/what-is-the-best-or-most-interesting-use-of-extension-methods-youve-seen/954254#954254
        /// <summary>
        /// Allows for iterating from the current number to the specified number
        /// </summary>
        /// <param name="toNumber">The number to iterate to</param>
        /// <returns></returns>
        public static IEnumerable<int> To(this int fromNumber, int toNumber)
        {
            while (fromNumber < toNumber)
            {
                yield return fromNumber;
                fromNumber++;
            }
        }
    }
}
