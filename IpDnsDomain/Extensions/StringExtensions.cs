using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Test")]
namespace IpDnsDomain.Extensions;

internal static class StringExtensions
{
    private static string[] CreateHttpVariantsA(this string input)
    {


        //if (!input.StartsWith("localhost", StringComparison.InvariantCultureIgnoreCase))
        //    if (input.Split(".").Length == 1 && !input.StartsWith("["))
        //        return [];

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

    /// <summary>
    /// Create HttpVariants for adresses & Ipv4 & Ipv6
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string[] CreateHttpVariants(this string str)
    {
        var repurl = "http://" + str.Replace("https://", "").Replace("http://", "");

        if (!Uri.TryCreate(repurl, UriKind.Absolute, out var uri))
        {
            return [];
        }

        if (uri.Host.Length > 255)
        {
            return [];
        }

        if (!uri.IsWellFormedOriginalString())
        {
            return [];
        }

        foreach (string part in uri.Host.Split('.'))
        {
            if (part.Length > 63)
            {
                return [];
            }
        }

        if (uri.HostNameType == UriHostNameType.Unknown)
        {
            return [];
        }

        //dns proofs
        if (uri.HostNameType == UriHostNameType.Dns)
        {
            var dotcontains = uri.Host.Contains(".");
            //is localhost address
            if (!(uri.Host.ToLower() == "localhost") && !dotcontains)
            {
                return [];
            }
            //domain len min lenght 2
            if (dotcontains && uri.Host.Split(".").Last().Length < 2)
            {
                return [];
            }
        }

        if (uri.HostNameType == UriHostNameType.IPv4 && str.Count(c => c == '.') != 3)
        {
            return [];
        }

        return str.CreateHttpVariantsA();
    }
}
