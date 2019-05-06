﻿using System;
using System.Linq;
using ClientDNS;
using Xunit;
using System.Collections;

namespace ClientDNSFacts
{
    public class DNSReponseFacts
    {
        [Fact]
        public void TestDNsReponse()
        {
            byte [] array = new byte[] {
                0x32, 0x45, 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x77, 0x77, 0x77,
                06, 0x67, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x01, 0x00, 0x01,
                0xc0, 0x0c, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x01, 0x0c, 0x00, 0x04, 0xac, 0xd9, 0x14, 0x04
            };
           
            var DNSreponse = new DNSResponse(array);

            //var actual = DNSreponse.GetBytes();

            var expected = new byte[] {
                0x32, 0x45, 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x77, 0x77, 0x77,
                06, 0x67, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x01, 0x00, 0x01
            };

            //Assert.Equal(expected, actual);
        }
    }
}