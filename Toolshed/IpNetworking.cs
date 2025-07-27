using System.Net;

namespace Toolshed
{
    public static class IpNetworking
    {
        /// <summary>
        /// Returns the IPv4 address of the UserHostAddress (requestor)
        /// </summary>
        /// <param name="userHostAddress">HttpContext.Current.Request.UserHostAddress</param>
        /// <returns></returns>
        public static string GetIP4Address(string userHostAddress)
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(userHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }
    }
}
