namespace Toolshed
{
    public static class BoolenExtensions
    {
        /// <summary>
        /// Returns one of the two specified strings depending on whether it's true or false
        /// </summary>
        public static string ToString(this bool s, string ifTrue, string ifFalse)
        {
            return (s) ? ifTrue : ifFalse;
        }

        /// <summary>
        /// Returns one of the three specified strings depending on whether it's true, false or null
        /// </summary>
        public static string ToString(this bool? s, string ifTrue, string ifFalse, string ifNull)
        {
            if (s.HasValue)
            {
                return (s.Value) ? ifTrue : ifFalse;
            }

            return ifNull;
        }

        /// <summary>
        /// returns one of two objects depending the whether it's true or false
        /// </summary>
        public static object ToObject(this bool s, object ifTrue, object ifFalse)
        {
            return (s) ? ifTrue : ifFalse;
        }

        /// <summary>
        /// Returns one of the three objects depending on whether it's true, false or null
        /// </summary>
        public static object ToObject(this bool? s, object ifTrue, object ifFalse, object ifNull)
        {
            if (s.HasValue)
            {
                return (s.Value) ? ifTrue : ifFalse;
            }

            return ifNull;
        }
    }
}
