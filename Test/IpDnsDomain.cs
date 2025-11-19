using IpDnsDomain;
using IpDnsDomain.Extensions;
using IpDnsDomain.Models;

namespace Test
{
    public class IpDnsDomain
    {

        [Fact]
        public void StringToHttpScheme()
        {
            var urls = "localhost.de".CreateHttpVariants();

            Assert.NotEmpty(urls);
            Assert.All(urls, e => e.StartsWith("http"));
        }

        [Fact]
        public void ValidateIpv4()
        {
            //heise.de
            var result = DomainValidator.GetIpDnsUrl("193.99.144.80");
            Assert.IsType<IpDnsUrl>(result);
        }

        [Fact]
        public async Task ValidateAsync()
        {
            var result = await DomainValidator.GetIpDnsUrlAsync("heise.de");
            Assert.IsType<IpDnsUrl>(result);
        }

        [Fact]
        public void ValidateIpv6()
        {
            //heise.de
            var result = DomainValidator.GetIpDnsUrl("[2a02:2e0:3fe:1001:302::]");
            Assert.IsType<IpDnsUrl>(result);
        }

        [Fact]
        public void ValidateAdress()
        {

            var result = DomainValidator.GetIpDnsUrl("http://heise.de");
            Assert.IsType<IpDnsUrl>(result);
        }

        [Fact]
        public void TryValidating()
        {

            var result = DomainValidator.TryGetIpDnsUrl("https://heise.de", out var ipDnsUrl);

            Assert.True(result);
            Assert.NotNull(ipDnsUrl);
        }

        [Fact]
        public async Task ValidatingParalell()
        {
            List<Task<IpDnsUrl?>> tasks = new List<Task<IpDnsUrl?>>
            {
                DomainValidator.GetIpDnsUrlAsync("google.de"),
                DomainValidator.GetIpDnsUrlAsync("youtube.com"),
                DomainValidator.GetIpDnsUrlAsync("heise.de"),
                DomainValidator.GetIpDnsUrlAsync("computerbase.de")
            };

            var results = await Task.WhenAll(tasks);

            Assert.IsType<IpDnsUrl>(results.Last());
        }
    }
}
