using System.Runtime.InteropServices;

namespace Toolshed
{
    public static class OsHelper
    {
        //https://stackoverflow.com/questions/5116977/how-to-check-the-os-version-at-runtime-e-g-windows-or-linux-without-using-a-con
        //https://devblogs.microsoft.com/dotnet/announcing-the-windows-compatibility-pack-for-net-core/


        /// <summary>
        /// Returns boolean indicating if the current system is Linux
        /// </summary>
        public static bool IsLinux
        {
            get
            {
                return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            }
        }

        /// <summary>
        /// Returns boolean indicating if the current system is Windows
        /// </summary>
        public static bool IsWindows
        {
            get
            {
                return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            }
        }
    }
}
