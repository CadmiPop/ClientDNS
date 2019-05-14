using System;
using System.Linq;
using ClientDNS;
using Xunit;
using System.Collections;

namespace ClientDNSFacts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var query = new Query("www.google.com");

            var actual = query.GetBytes();

            var expected = new byte[] {
                0x03, 0x77, 0x77, 0x77, 0x06, 0x67, 0x6f, 0x6f,
                0x67, 0x6c, 0x65, 0x03, 0x63, 0x6f, 0x6d, 0x00,
                0x00, 0x01, 0x00, 0x01
            };

            Assert.Equal(expected, actual);
        }
    }
}
