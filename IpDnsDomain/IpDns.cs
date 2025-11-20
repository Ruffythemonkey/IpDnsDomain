using IpDnsDomain.Classes;
using IpDnsDomain.Extensions;
using IpDnsDomain.Models;
using System.Runtime.CompilerServices;

namespace IpDnsDomain
{
    internal class IpDns : Web
    {
        public IpDnsUrl? IsValidUrl(string url)
        {
            tokenSource?.Cancel();
            tokenSource?.Dispose();
            tokenSource = new();

            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    var result = GetUrl(item);
                    result.StatusProcessing();
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
            if (tokenSource != null)
                await tokenSource.CancelAsync();
            tokenSource?.Dispose();
            tokenSource = new();

            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    var result = await GetUrlAsync(item);
                    result.StatusProcessing();
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
            throw new IpDnsDomainException("url is unattainable");
        }

        public async Task<IpDnsUrl?> TryIsValidUrlAsync(string url)
        {
            if (tokenSource != null)
                await tokenSource.CancelAsync();
            tokenSource?.Dispose();
            tokenSource = new();

            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    var result = await GetUrlAsync(item);
                    //result.StatusProcessing();
                    return new() { OrginalUrl = url, ReachableUrl = item };
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception)
                {
                   
                }
            }
            return null;
        }

        public bool TryIsValidUrl(string url, out IpDnsUrl? result)
        {
            result = null;
            tokenSource?.Cancel();
            tokenSource?.Dispose();
            tokenSource = new();

            foreach (var item in url.CreateHttpVariants())
            {
                try
                {
                    var req = GetUrl(item);
                    //req.StatusProcessing();

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
