using System;
using System.Net;

namespace ClientDNS
{
    class Program
    {
        static void Main(string[] args)
        {
            DNS client = new DNS(new DnsQuery("vortex.data.microsoft.com"));
       }
    }
}
