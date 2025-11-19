using IpDnsDomain.Classes;
using IpDnsDomain.Extensions;
using IpDnsDomain.Models;

namespace IpDnsDomain
{
    internal class IpDns : Web
    {
        public IpDnsUrl IsValidUrl(string url)
        {
            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    var result = GetUrl(item);
                    result.EnsureSuccessStatusCode();
                    return new() { OrginalUrl = url, ReachableUrl = item};
                }
                catch (Exception)
                {
                }
            }
            throw new IpDnsDomainException("url is not unattainable");
        }

        public async Task<IpDnsUrl> IsValidUrlAsync(string url)
        {
            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    var result = await GetUrlAsync(item);
                    result.EnsureSuccessStatusCode();
                    return new() { OrginalUrl = url, ReachableUrl = item };
                }
                catch (Exception)
                {
                }
            }
            throw new IpDnsDomainException("url is not unattainable");
        }
    }

}
