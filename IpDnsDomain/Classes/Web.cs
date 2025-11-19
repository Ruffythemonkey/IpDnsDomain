namespace IpDnsDomain.Classes;

internal abstract class Web
{
    private readonly HttpClient Client = new HttpClient(new HttpClientHandler()
    {
        AllowAutoRedirect = true
    })
    {
        Timeout = TimeSpan.FromSeconds(3)
    };

    public CancellationTokenSource tokenSource = new CancellationTokenSource();

    public TimeSpan Timeout { get => Client.Timeout; set => Client.Timeout = value; }

    public async Task<HttpResponseMessage> GetUrlAsync(string url)
        => await Client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, tokenSource.Token);

    public HttpResponseMessage GetUrl(string url)
        => Task.Run(() => Client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, tokenSource.Token)).GetAwaiter().GetResult();
}
