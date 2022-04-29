using System;
using System.Collections.Generic;
using System.Text;

namespace Toolshed
{
    /// <summary>
    /// Converts values to expected type with no exceptions or returns the specified default value
    /// </summary>
    public static class ConvertSafely
    {
        public static T TryGetConvertedValue<T>(Func<T> exp, T defaultValue)
        {
            try
            {
                object val = exp.Invoke();
                return (T)val;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static DateTime ToDateTime(string value, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (DateTime.TryParse(value, out DateTime d))
            {
                return d;
            }

            return defaultValue;
        }
        public static DateTime? ToDateTime(string value, DateTime? defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (DateTime.TryParse(value, out DateTime d))
            {
                return d;
            }

            return defaultValue;
        }


        public static Guid ToGuid(string value, Guid defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (value.IsGuid())
                return new Guid(value);

            return defaultValue;
        }
        public static bool ToBool(string value, bool defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (bool.TryParse(value, out bool b))
            {
                return b;
            }

            return defaultValue;
        }
        public static bool? ToBool(string value, bool? defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (bool.TryParse(value, out bool b))
            {
                return b;
            }

            return defaultValue;
        }

        public static byte ToByte(string value, byte defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (byte.TryParse(value, out byte b))
            {
                return b;
            }

            return defaultValue;
        }
        public static byte ToShort(object value, byte defaultValue)
        {
            if (value == null) return defaultValue;

            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static short ToShort(string value, short defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (value.IndexOf(",") >= 0)
            {
                value = value.Replace(",", string.Empty);
            }

            if (short.TryParse(value, out short i))
            {
                return i;
            }

            return defaultValue;
        }
        public static short? ToShort(string value, short? defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (value.IndexOf(",") >= 0)
            {
                value = value.Replace(",", string.Empty);
            }

            if (short.TryParse(value, out short i))
            {
                return i;
            }

            return defaultValue;
        }
        public static short ToShort(object value, short defaultValue)
        {
            if (value == null) return defaultValue;

            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int ToInt(string value, int defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            value = value.Replace(",", string.Empty);
            if (int.TryParse(value, out int i))
            {
                return i;
            }

            return defaultValue;
        }
        public static int? ToInt(string value, int? defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (value.IndexOf(",") >= 0)
            {
                value = value.Replace(",", string.Empty);
            }

            if (int.TryParse(value, out int i))
            {
                return i;
            }

            return defaultValue;
        }
        public static int ToInt(object value, int defaultValue)
        {
            if (value == null) return defaultValue;

            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static double ToDouble(string value, double defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if(value.IndexOf(",") >= 0)
            {
                value = value.Replace(",", string.Empty);
            }

            if (double.TryParse(value, out double d))
            {
                return d;
            }

            return defaultValue;
        }
        public static double? ToDouble(string value, double? defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (value.IndexOf(",") >= 0)
            {
                value = value.Replace(",", string.Empty);
            }

            if (double.TryParse(value, out double d))
            {
                return d;
            }

            return defaultValue;
        }
        public static double ToDouble(object value, double defaultValue)
        {
            if (value == null) return defaultValue;

            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return defaultValue;
            }
        }
        

        public static long ToLong(string value, long defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;
            
            if (long.TryParse(value, out long l))
            {
                return l;
            }

            return defaultValue;
        }
        public static long? ToLong(string value, long? defaultValue)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (long.TryParse(value, out long l))
            {
                return l;
            }

            return defaultValue;
        }
        public static long ToLong(object value, long defaultValue)
        {
            if (value == null) return defaultValue;

            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return defaultValue;
            }
        }

    }

}
