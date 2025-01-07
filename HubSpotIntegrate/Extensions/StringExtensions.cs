using System.Text.RegularExpressions;
namespace HubSpotIntegrate.Extensions
{
    /// <summary>
    /// Provides extension methods for string manipulation.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Extracts an 11-digit number from the given string.
        /// </summary>
        /// <param name="str">The input string from which to extract the number.</param>
        /// <returns>
        /// A string containing the first 11-digit number found in the input string,
        /// or null if no such number is found.
        /// </returns>
        public static string? ExtractNumbersFromString(this string str)
        {
            string pattern = @"\b\d{11}\b";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(str);

            return match.Value;
        }
    }
}