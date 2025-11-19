using IpDnsDomain.Classes;
using IpDnsDomain.Extensions;
using IpDnsDomain.Models;

namespace IpDnsDomain
{
    internal class IpDns : Web
    {
        public IpDnsUrl? IsValidUrl(string url)
        {
            tokenSource.Cancel();
            tokenSource.Dispose();
            tokenSource = new();

            foreach (var item in url.CreateHttpVariants())
            {
                try
                {


                    var result = GetUrl(item);
                    result.EnsureSuccessStatusCode();
                    return new() { OrginalUrl = url, ReachableUrl = item };
                }
                catch (OperationCanceledException)
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
            await tokenSource.CancelAsync();
            tokenSource.Dispose();
            tokenSource = new();

            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    var result = await GetUrlAsync(item);
                    result.EnsureSuccessStatusCode();
                    return new() { OrginalUrl = url, ReachableUrl = item };
                }
                catch (OperationCanceledException)
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
            tokenSource.Cancel();
            tokenSource = new();

            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
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
