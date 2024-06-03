using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class EmailValidator
{
    private static readonly Regex EmailRegex = new Regex(
        @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static async Task<bool> IsValidEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || email.Length > 256)
            return false;

        try
        {
            if (!EmailRegex.IsMatch(email))
                return false;

            var match = Regex.Match(email, @"(@)(.+)$");

            if (!match.Success || match.Groups.Count != 3)
                return false;

            string localPart = email.Substring(0, match.Index);
            string domainPart = match.Groups[2].Value;

            string asciiDomain = await Task.Run(() => {
                var idn = new IdnMapping();
                return idn.GetAscii(domainPart);
            });

            string normalizedEmail = localPart + "@" + asciiDomain;

            return EmailRegex.IsMatch(normalizedEmail);
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
