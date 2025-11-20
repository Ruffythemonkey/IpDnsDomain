# IpDnsDomain ✅

# Validating Address or Ip is Reachble
```c#
var result = DomainValidator.GetIpDnsUrl("[2a02:2e0:3fe:1001:302::]");
var result = DomainValidator.GetIpDnsUrl("http://heise.de");
var result = DomainValidator.GetIpDnsUrl("localhost");
var result = DomainValidator.GetIpDnsUrl("192.168.178.111:234");
var result = DomainValidator.GetIpDnsUrl("[2a02:2e0:3fe:1001:302::]:22");
var result = DomainValidator.TryGetIpDnsUrl("https://heise.de", out var ipDnsUrl);
var result = DomainValidator.TryGetIpDnsUrl("google.com", out var ipDnsUrl);

if((await DomainValidator.GetIpDnsUrlAsync("192.168.178.111:234")) is IpDnsUrl domain)
{
  //this is an domainaddress, ipv4, ipv6 (with ports or without ports) which is reachable
   var domain = doamin.ReachableUrl;
}

```

# is this Thread-Safe?
Yes is fully Paralell save

# can it use local lan network addresses
Yes all Protocols are usable 
valid addresses without -> dot <- are not accepted only localhost

# Nuget 📦 
https://www.nuget.org/packages/IpDnsDomain/
