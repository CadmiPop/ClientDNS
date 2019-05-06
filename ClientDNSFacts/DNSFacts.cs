using System;
using System.Linq;
using ClientDNS;
using Xunit;
using System.Collections;

namespace ClientDNSFacts
{
    public class DNSFacts
    {
        [Fact]
        public void TestDNsQuery()
        {
            var DNSquery = new DnsQuery("www.google.com", id:0x00003245);

            var actual = DNSquery.GetBytes();

            var expected = new byte[] {
                0x32, 0x45, 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x77, 0x77, 0x77,
                06, 0x67, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x01, 0x00, 0x01
            };

            Assert.Equal(expected, actual);
        }
        

    }
}
