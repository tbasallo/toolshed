using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace Toolshed;

/// <summary>
/// Methods and helpers related to cryptography and hashing
/// </summary>
public static class Crypto
{

    /// <summary>
    /// Returns a one-way hash for the given string using the SHA256 algorithm.
    /// The result is encoded using Base64 encoding (not the Base64Url) which may result in some differences in the output.
    /// </summary>
    /// <param name="input">The input string to hash.</param>
    /// <returns>The one-way hash as a Base64Url-encoded string.</returns>
    public static string ToOneWayHashBase64(this string s)
    {
        return Convert.ToBase64String(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(s)));
    }



    /// <summary>
    /// Returns a one-way hash for the given string using the SHA256 algorithm
    /// The result is encoded using Base64Url encoding.
    /// </summary>
    /// <param name="input">The input string to hash.</param>
    /// <returns>The one-way hash as a Base64Url-encoded string.</returns>
    public static string ToOneWayHashBase64Url(this string s)
    {
        return Base64Url.EncodeToString(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(s)));
    }

    /// <summary>
    /// Returns a one-way hash for the given string using the SHA256 algorithm
    /// The result is a hexadecimal string.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ToOneWayHashAsHex(this string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return string.Empty;
        }

        // Convert to hexadecimal format
        return Convert.ToHexStringLower(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(s.ToLowerInvariantTrimSafely())));
    }


    /// <summary>
    /// Generates an HMAC (Hash-based Message Authentication Code) for the given string using the specified key and hashing algorithm.
    /// The string returned is encoded using Base64Url encoding not the Base64 which may result in some differences in the output.
    /// </summary>
    /// <param name="message">The input string to hash.</param>
    /// <param name="key">The secret key used for the HMAC.</param>
    /// <returns>The HMAC as a Base64Url-encoded string.</returns>
    public static string ToHMAC(this string message, string key)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException(nameof(message), "Message cannot be null or empty.");

        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");

        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
        return Base64Url.EncodeToString(hash);
    }

    /// <summary>
    /// Verifies if the provided HMAC matches the HMAC generated for the given message and key.
    /// </summary>
    /// <param name="message">The original message.</param>
    /// <param name="key">The secret key used to generate the HMAC.</param>
    /// <param name="providedHmac">The HMAC value to verify.</param>
    /// <returns>True if the provided HMAC matches the generated HMAC; otherwise, false.</returns>
    public static bool IsHMACValid(this string message, string key, string providedHmac, bool checkForBase64Conversion = false)
    {
        if (string.IsNullOrEmpty(key))
        {
            return false;
        }

        if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(providedHmac))
        {
            //if both are empty, we consider it valid; I don;t make the rules
            return (string.IsNullOrEmpty(message) && string.IsNullOrEmpty(providedHmac));
        }

        // Generate the HMAC for the message using the provided key
        var generatedHmac = message.ToHMAC(key);

        // Compare the provided HMAC with the generated HMAC in a time-safe manner
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(providedHmac),
            Encoding.UTF8.GetBytes(generatedHmac)
        );
    }
}
