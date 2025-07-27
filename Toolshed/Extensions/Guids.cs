namespace Toolshed
{
    public static class Guids
    {
        /// <summary>
        /// Indicates whether this Guid is empty (equal to all zeros (0))
        /// </summary>
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        /// <summary>
        /// Indicates whether this Guid is null (no value) or empty (equal to all zeros (0))
        /// </summary>
        public static bool IsNullOrEmpty(this Guid? value)
        {
            if (value.HasValue)
            {
                return value == Guid.Empty;
            }

            return true;
        }
    }
}
