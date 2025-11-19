using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Test")]
namespace IpDnsDomain.Extensions;


internal static class StringExtensions
{

    /// <summary>
    /// Create HttpVariants for adresses & Ipv4 & Ipv6
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string[] CreateHttpVariants(this string input)
    {

      
        if (!input.StartsWith("localhost", StringComparison.InvariantCultureIgnoreCase))
            if (input.Split(".").Length == 1 && !input.StartsWith("["))
                return [];

        string clear = input
            .Replace("https://", "", StringComparison.OrdinalIgnoreCase)
            .Replace("http://", "", StringComparison.OrdinalIgnoreCase);

        return input switch
        {
            var s when s.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                => new[] { $"https://{clear}", $"http://{clear}" },

            var s when s.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                => new[] { $"http://{clear}", $"https://{clear}" },

            _ => new[] { $"https://{clear}", $"http://{clear}" }
        };
    }

}
