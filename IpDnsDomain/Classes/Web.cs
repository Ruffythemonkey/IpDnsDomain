namespace IpDnsDomain.Classes;

internal abstract class Web
{
    private readonly HttpClient Client = new HttpClient(new HttpClientHandler()
    {
        AllowAutoRedirect = true
    })
    {
        Timeout = TimeSpan.FromSeconds(3),
    };

    public CancellationTokenSource tokenSource = new CancellationTokenSource();

    public Web()
        => UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:120.0) Gecko/20100101 Firefox/120.0";

    public string UserAgent
    {
        get => Client.DefaultRequestHeaders.UserAgent.ToString();
        set {
            if (string.IsNullOrEmpty(value))
                return;
            Client.DefaultRequestHeaders.Remove("User-Agent");
            Client.DefaultRequestHeaders.Add("User-Agent", value);
        }
    }

    public TimeSpan Timeout { get => Client.Timeout; set => Client.Timeout = value; }

    public async Task<HttpResponseMessage> GetUrlAsync(string url)
        => await Client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, tokenSource.Token);

    public HttpResponseMessage GetUrl(string url)
        => Task.Run(() => Client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, tokenSource.Token)).GetAwaiter().GetResult();
}
