namespace IpDnsDomain.Extensions
{
    internal static class HttpResponseMessageExtension
    {
        public static void StatusProcessing(this HttpResponseMessage message)
        {
            //301 exception Handler
            if (message.StatusCode == System.Net.HttpStatusCode.Moved ||
                message.StatusCode == System.Net.HttpStatusCode.MovedPermanently)
            {
                
            }
            else
            {
                message.EnsureSuccessStatusCode();
            }
        }
    }
}
