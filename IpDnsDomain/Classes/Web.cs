namespace IpDnsDomain.Classes;

internal abstract class Web
{
    private readonly HttpClient Client = new HttpClient()
    {
        Timeout = TimeSpan.FromSeconds(3)
    };

    public readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

    public TimeSpan Timeout { get => Client.Timeout; set => Client.Timeout = value; }

    public async Task<HttpResponseMessage> GetUrlAsync(string url)
        => await Client.GetAsync(url, tokenSource.Token);

    public HttpResponseMessage GetUrl(string url)
        => Task.Run(() => Client.GetAsync(url, tokenSource.Token)).GetAwaiter().GetResult();
}
