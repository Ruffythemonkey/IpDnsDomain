using IpDnsDomain.Classes;
using IpDnsDomain.Extensions;
using IpDnsDomain.Models;

namespace IpDnsDomain
{
    internal class IpDns : Web
    {
        public IpDnsUrl? IsValidUrl(string url)
        {
            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    tokenSource.Cancel();
                    tokenSource.TryReset();

                    var result = GetUrl(item);
                    result.EnsureSuccessStatusCode();
                    return new() { OrginalUrl = url, ReachableUrl = item };
                }
                catch(OperationCanceledException)
                {
                    return null;
                }
                catch (Exception)
                {
                }
            }
            throw new IpDnsDomainException("url is not unattainable");
        }

        public async Task<IpDnsUrl?> IsValidUrlAsync(string url)
        {
            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    await tokenSource.CancelAsync();
                    tokenSource.TryReset();

                    var result = await GetUrlAsync(item);
                    result.EnsureSuccessStatusCode();
                    return new() { OrginalUrl = url, ReachableUrl = item };
                }
                catch(OperationCanceledException) 
                {
                    return null;
                }
                catch (Exception)
                {
                }
            }
            throw new IpDnsDomainException("url is not unattainable");
        }

        public bool TryIsValidUrl(string url, out IpDnsUrl? result)
        {
            result = null;

            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    tokenSource.Cancel();
                    tokenSource.TryReset();

                    var req = GetUrl(item);
                    req.EnsureSuccessStatusCode();
                    result = new() { OrginalUrl = url, ReachableUrl = item };
                    return true;
                }
                catch (OperationCanceledException)
                {
                    return false;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
    }

}
