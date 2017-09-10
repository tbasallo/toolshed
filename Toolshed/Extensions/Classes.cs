using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toolshed
{
    public static class Classes
    {
        /// <summary>
        /// Trims all string properties (front and back)
        /// </summary>
        public static void TrimStringProperties<T>(this T input) where T : class
        {
            var stringProperties = input.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                var currentValue = (string)stringProperty.GetValue(input, null);
                if (!string.IsNullOrWhiteSpace(currentValue))
                {
                    stringProperty.SetValue(input, currentValue.Trim(), null);
                }
            }
        }

    }
}
