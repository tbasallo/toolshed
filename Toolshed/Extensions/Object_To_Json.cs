using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Toolshed
{
    public static class ObjectJsonExtensions
    {
        /// <summary>
        /// Returns a JSON string for the specified object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="propertyNameCaseInsensitive"></param>
        /// <param name="maxDepth"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T model, bool propertyNameCaseInsensitive = true, int maxDepth = 10)
        {
            if (model == null)
            {
                return "{}";
            }

            return JsonSerializer.Serialize(model, new JsonSerializerOptions { MaxDepth = maxDepth, PropertyNameCaseInsensitive = propertyNameCaseInsensitive });
        }

        /// <summary>
        /// Returns the specified object T from the proivided string. Return the default if the string is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="propertyNameCaseInsensitive"></param>
        /// <param name="maxDepth"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string model, bool propertyNameCaseInsensitive = true, int maxDepth = 10)
        {
            if (model == null)
            {
                return default;
            }
            if(string.IsNullOrWhiteSpace(model))
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(model, new JsonSerializerOptions { MaxDepth = maxDepth, PropertyNameCaseInsensitive = propertyNameCaseInsensitive });
        }
    }
}
