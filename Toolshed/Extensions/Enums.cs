using System;

namespace Toolshed
{
    public static class Enums
    {
        /// <summary>
        /// Returns an enum as a string separated on every uppercase letter 
        /// <para>(e.g., SpecialPurpose returns as Special Purpose</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>A string separated on every capital letter</returns>
        public static string ToPascaledString(this Enum sender)
        {
            return sender.ToString().SeparateOnPascal(true);
        }

        /// <summary>
        /// Parses the provided string into its Enum type.
        /// <para>In System namespace, but Webchanix.Toolshed.EnumExtensions</para>
        /// </summary>
        /// <param name="defaultValue">The default value to use if the string is not valid, TResult is not an enum or an exception is thrown and the throwErrorOnException parameter is false</param>
        /// <param name="throwErrorOnException">Indicates whther an exception should be swallowed and the default value returned or thrown</param>
        /// <returns>An enum parsed from the provided string</returns>
        public static T ConvertToEnum<T>(this string? source, T defaultValue, bool throwErrorOnException = false)
        {
            if (!typeof(T).IsEnum || string.IsNullOrWhiteSpace(source))
            {
                return defaultValue;
            }

            try
            {
                return (T)Enum.Parse(typeof(T), source);
            }
            catch (Exception)
            {
                if (throwErrorOnException)
                {
                    throw;
                }
            }

            return defaultValue;
        }
    }
}
