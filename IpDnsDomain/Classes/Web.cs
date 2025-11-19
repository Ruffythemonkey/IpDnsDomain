namespace IpDnsDomain.Classes;

internal abstract class Web
{
    private readonly HttpClient Client = new HttpClient()
    {
        Timeout = TimeSpan.FromSeconds(3)
    };

    public TimeSpan Timeout { get => Client.Timeout; set => Client.Timeout = value; }

    public async Task<HttpResponseMessage> GetUrlAsync(string url)
        => await Client.GetAsync(url);

    public HttpResponseMessage GetUrl(string url)
        => Task.Run(() => Client.GetAsync(url)).GetAwaiter().GetResult();
}
