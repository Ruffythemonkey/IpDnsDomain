using IpDnsDomain.Models;

namespace IpDnsDomain
{
    public static class DomainValidator
    {
        private static readonly IpDns _dns = new IpDns();

        /// <summary>
        /// Gets or sets the maximum duration to wait for a DNS operation to complete before timing out.
        /// </summary>
        /// <remarks>Setting this property affects all DNS queries performed by the system. A shorter
        /// timeout may result in failed queries under slow network conditions, while a longer timeout may delay error
        /// reporting for unreachable hosts.</remarks>
        public static TimeSpan Timeout { get => _dns.Timeout; set => _dns.Timeout = value; }

        /// <summary>
        /// Validates the specified address or IP string and returns an IpDnsUrl representing the result.
        /// </summary>
        /// <param name="AdressOrIp">The address or IP string to validate. This can be a domain name, URL, or IPv4/IPv6 address.</param>
        /// <returns>An IpDnsUrl instance containing the parsed and validated address or IP information. If the input is not
        /// valid, the returned object may indicate an invalid state.</returns>
        public static IpDnsUrl GetIpDnsUrl(string AdressOrIp)
            => _dns.IsValidUrl(AdressOrIp);

        /// <summary>
        /// Asynchronously resolves the specified address or IP to an <see cref="IpDnsUrl"/> instance, validating
        /// whether it is a well-formed URL or IP address.
        /// </summary>
        /// <param name="AdressOrIp">The address or IP string to validate and resolve. This value should be a well-formed URL or a valid IP
        /// address.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IpDnsUrl"/>
        /// instance representing the resolved address or IP information.</returns>
        public static async Task<IpDnsUrl> GetIpDnsUrlAsync(string AdressOrIp)
            => await _dns.IsValidUrlAsync(AdressOrIp);

        /// <summary>
        /// Attempts to parse the specified address or IP string as an IpDnsUrl.
        /// </summary>
        /// <param name="AddressOrIp">The address or IP string to parse. Cannot be null.</param>
        /// <param name="result">When this method returns, contains the parsed IpDnsUrl if the operation succeeded; otherwise, null.</param>
        /// <returns>true if the address or IP string was successfully parsed as an IpDnsUrl; otherwise, false.</returns>
        public static bool TryGetIpDnsUrl(string AddressOrIp, out IpDnsUrl? result)
            => _dns.TryIsValidUrl(AddressOrIp, out result);

    }
}
