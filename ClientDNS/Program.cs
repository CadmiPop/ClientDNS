using System;
using System.Net;

namespace ClientDNS
{
    class Program
    {
        static void Main(string[] args)
        {
            DNS client = new DNS(new DnsQuery("www.google.com", Flags.Response, id: 0x00003245));
       }
    }
}
