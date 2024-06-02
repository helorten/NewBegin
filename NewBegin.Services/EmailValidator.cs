using System.Globalization;
using System.Text.RegularExpressions;

namespace NewBegin.Services
{
    public class EmailValidator
    {
        private static readonly Regex EmailRegex = new Regex(
       @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
       RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static async Task<bool> IsValidEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 256)
                return false;

            try
            {
                // Perform a basic format check
                if (!EmailRegex.IsMatch(email))
                    return false;

                // Normalize the domain asynchronously
                email = await Task.Run(() => Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200)));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    var domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }

                // Perform a final regex check after normalization
                return EmailRegex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
