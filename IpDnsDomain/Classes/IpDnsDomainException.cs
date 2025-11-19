namespace IpDnsDomain.Classes
{
    public class IpDnsDomainException : Exception
    {
        public IpDnsDomainException() { }

        public IpDnsDomainException(string message) : base(message) { }

        public IpDnsDomainException(String message, Exception innerException) : base(message, innerException) { }
    }
}
