using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Xml;

namespace Toolshed
{
    public static class ConfigurationHelper
    {
        const string NullEmptyAppSetting = "AppSetting had no value or the key was missing";


        /// <summary>
        /// Get the value of the specified key from AppSettings
        /// </summary>
        /// <param name="key">The key in the appSettings</param>
        /// <param name="throwExceptionOnMissingValue">Indicates whether to throw an exception on a missing or empty value</param>
        /// <returns>A string with the value of the entry or empty of the key is not found and throwExceptionOnMissingValue = false</returns>
        /// <exception cref="">ArgumentNullException (if throwExceptionOnMissingValue = true)</exception>
        private static string GetAppSetting(string key, bool throwExceptionOnMissingValue)
        {
            var value = ConfigFileHelper.GetAppSettingValue(key);
            if (throwExceptionOnMissingValue && string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(key, NullEmptyAppSetting);
            }

            return value;
        }

        /// <summary>
        /// Returns the value of the specified key from the AppSetting in the config file
        /// </summary>
        /// <param name="key">The key of the AppSetting entry</param>
        /// <returns>A string representing the value found</returns>
        /// <exception cref="ArgumentNullException">An ArgumentNullException is thrown if no value is found.</exception>
        public static string GetAppSetting(string key)
        {
            return GetAppSetting(key, true);
        }

        /// <summary>
        /// Returns the value of the specfied key from the AppSetting in the config file or the default value provided if no entry is found
        /// </summary>
        /// <param name="key">The key of the AppSetting entry</param>
        /// <param name="defaultValue">The default value to return if no value or entry is found. This can be null.</param>
        /// <returns>A string representing the value found</returns>
        /// <exception cref="ArgumentNullException">An ArgumentNullException is thrown if no value is found and no default value specified.</exception>
        public static string GetAppSetting(string key, string defaultValue)
        {
            var value = GetAppSetting(key, false);
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return value;
        }

        /// <summary>
        /// Returns the value of the specified key from the AppSetting in the config file or the default value provided if no entry is found. If value or default value is provided an exception will be thrown.
        /// </summary>
        /// <param name="key">The key of the AppSetting entry</param>
        /// <param name="defaultValue">The default value to return if no value or entry is found. This can be null.</param>
        /// <returns>A boolean representing the value found</returns>
        public static bool GetAppSetting(string key, bool? defaultValue = null)
        {
            var val = GetInternalAppSetting(key, defaultValue.HasValue);
            return (string.IsNullOrEmpty(val)) ? defaultValue.Value : Convert.ToBoolean(val);
        }

        /// <summary>
        /// Returns the value of the specified key from the AppSetting or the default value provided if no entry is found. If no value or default value is provided an exception will be thrown.
        /// </summary>
        /// <param name="key">The key of the AppSetting entry</param>
        /// <param name="defaultValue">The default value to return if no value or entry is found. This can be null.</param>
        /// <returns>An int representing the value found</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int GetAppSetting(string key, int? defaultValue = null)
        {
            var val = GetInternalAppSetting(key, defaultValue.HasValue);
            return (string.IsNullOrEmpty(val)) ? defaultValue.Value : Convert.ToInt32(val);
        }

        /// <summary>
        /// Returns the value of the specified key from the AppSetting or the default value provided if no entry is found. If no value or default value is provided an exception will be thrown.
        /// </summary>
        /// <param name="key">The key of the AppSetting entry</param>
        /// <param name="defaultValue">The default value to return if no value or entry is found. This can be null.</param>
        /// <returns>A long representing the value found</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static long GetAppSetting(string key, long? defaultValue = null)
        {
            var val = GetInternalAppSetting(key, defaultValue.HasValue);
            return (string.IsNullOrEmpty(val)) ? defaultValue.Value : Convert.ToInt64(val);
        }

        /// <summary>
        /// Returns the value of the specified key from the AppSetting or the default value provided if no entry is found. If no value or default value is provided an exception will be thrown.
        /// </summary>
        /// <param name="key">The key of the AppSetting entry</param>
        /// <param name="defaultValue">The default value to return if no value or entry is found. This can be null.</param>
        /// <returns>A double representing the value found</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double GetAppSetting(string key, double? defaultValue = null)
        {
            var val = GetInternalAppSetting(key, defaultValue.HasValue);
            return (string.IsNullOrEmpty(val)) ? defaultValue.Value : Convert.ToDouble(val);
        }

        /// <summary>
        /// Returns the value of the specified key from the AppSetting or the default value provided if no entry is found. If no value or default value is provided an exception will be thrown.
        /// </summary>
        /// <param name="key">The key of the AppSetting entry</param>
        /// <param name="defaultValue">The default value to return if no value or entry is found. This can be null.</param>
        /// <returns>A DateTime representing the value found</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime GetAppSetting(string key, DateTime? defaultValue = null)
        {
            var val = GetInternalAppSetting(key, defaultValue.HasValue);
            return (string.IsNullOrEmpty(val)) ? defaultValue.Value : Convert.ToDateTime(val);
        }


        /// <summary>
        /// Returns a string[] of the delimited values with specified key from the AppSetting.
        /// </summary>
        /// <param name="key">The key of the AppSetting entry</param>
        /// <param name="delimiter">The delimiter to use to convert the value into a string. Default is a comma (,)</param>
        /// <returns>A string array (string[]) or null if no value is found</returns>
        public static string[] GetAppSettingStringArray(string appSettingName, char delimiter = ',', StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            string s = GetAppSetting(appSettingName);
            if (!string.IsNullOrWhiteSpace(s))
            {
                if (s.IndexOf(delimiter) > 0)
                {
                    return s.Split(new char[] { delimiter }, options);
                }
                else
                {
                    return new string[1] { s };
                }
            }

            return null;
        }


        /// <summary>
        /// Returns a string value of the matching key in the provided NameValueCollection.
        /// </summary>
        /// <exception cref="">Throws an exception if a matching key is not found and no default value provided</exception>
        /// <param name="config"></param>
        /// <param name="valueName"></param>
        /// <param name="defaultValue"></param>
        public static string GetStringValue(NameValueCollection config, string valueName, string defaultValue = "")
        {
            //TODO: does the exception comments show and whats the error
            var value = config[valueName];



            if (string.IsNullOrEmpty(valueName) && string.IsNullOrWhiteSpace(defaultValue))
            {
                throw new ArgumentNullException(valueName, valueName + " must have a value");
            }

            if (string.IsNullOrEmpty(valueName))
            {
                return defaultValue;
            }

            return value;
        }

        /// <summary>
        /// Returns a boolean value of the matching key in the provided NameValueCollection.
        /// </summary>
        /// <exception cref="">Throws an exception no default value is provided and a matching key is not found or cannot be converted to boolean.</exception>
        /// <param name="config"></param>
        /// <param name="valueName"></param>
        /// <param name="defaultValue"></param>
        public static bool GetBooleanValue(NameValueCollection config, string valueName, bool? defaultValue = null)
        {
            string sValue = config[valueName];

            if (sValue == null)
            {
                if (defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }
                else
                {

                }
            }

            if (bool.TryParse(sValue, out bool result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(valueName + " must be boolean");
            }
        }

        /// <summary>
        /// Returns an int value of the matching key in the provided NameValueCollection.
        /// </summary>
        /// <exception cref="">Throws an exception no default value is provided and a matching key is not found or cannot be converted to int.</exception>
        /// <param name="config"></param>
        /// <param name="valueName"></param>
        /// <param name="defaultValue"></param>
        public static int GetIntValue(NameValueCollection config, string valueName, int defaultValue, int minValueAllowed = 0, int maxValueAllowed = Int32.MaxValue)
        {
            string sValue = config[valueName];

            if (sValue == null)
            {
                return defaultValue;
            }

            if (!Int32.TryParse(sValue, out int v))
            {
                throw new ArgumentNullException(valueName, valueName + " must be a number");
            }

            if (v < minValueAllowed || v > maxValueAllowed)
            {
                throw new ArgumentException(string.Format("{0} must be > than {1} and < {2}", valueName, minValueAllowed, maxValueAllowed));
            }

            return v;
        }

        /// <summary>
        /// Returns the connectionstring value using the key provided
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultKeyValue"></param>
        public static string GetConnectionStringValue(string name, string defaultKeyValue = null)
        {
            var value = ConfigFileHelper.GetConnectionStringValue(name);
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name, "The specified connection string was not found or had no value");
            }

            return value;
        }


        private static string GetInternalAppSetting(string key, bool hasValue)
        {
            var val = GetAppSetting(key, false);
            if (string.IsNullOrEmpty(val) && !hasValue)
            {
                throw new ArgumentNullException(key, "No AppSetting with a key of " + key + " or it has no value. The key must have a value or a default provided");
            }

            return val;
        }
    }


    internal static class ConfigFileHelper
    {
        static string m_ConfigFile;

        internal static string GetConnectionStringValue(string name)
        {
            var nodes = GetAppSettingsSection();
            foreach (XmlNode node in nodes.ChildNodes)
            {
                if (node.Attributes["name"].Value.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return node.Attributes["value"].Value;
                }
            }

            return null;
        }
        internal static string GetAppSettingValue(string key)
        {
            var nodes = GetAppSettingsSection();
            foreach (XmlNode node in nodes.ChildNodes)
            {
                if (node.Attributes["key"].Value.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    return node.Attributes["value"].Value;
                }
            }

            return null;
        }

        private static XmlNode GetAppSettingsSection()
        {
            EnsureConfigFile();

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(m_ConfigFile);
            return xdoc.SelectSingleNode("/configuration/appSettings");
        }
        private static XmlNode GetConnectionStringsSection()
        {
            EnsureConfigFile();

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(m_ConfigFile);
            return xdoc.SelectSingleNode("/configuration/connectionStrings");
        }
        private static void EnsureConfigFile()
        {
            if (m_ConfigFile.IsNotNull())
            {
                return;
            }

            var f = AppContext.BaseDirectory;

            if(f.Contains("\\bin\\"))
            {
                f = f.Substring(0, f.IndexOf("\\bin"));
            }

            if (File.Exists(Path.Combine(f, "web.config")))
            {
                m_ConfigFile = Path.Combine(f, "web.config");
                return;
            }
            else if (File.Exists(Path.Combine(f, "app.config")))
            {
                m_ConfigFile = Path.Combine(f, "app.config");
                return;
            }

            throw new ApplicationException("A config file must exist to use ConfigurationHelper");
        }
    }
}
