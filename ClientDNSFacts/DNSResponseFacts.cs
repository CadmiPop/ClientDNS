using System;
using System.Linq;
using ClientDNS;
using Xunit;
using System.Collections;
using System.Collections.Generic;

namespace ClientDNSFacts
{
    public class DNSReponseFacts
    {
        [Fact]
        public void TestReponseDNS()
        {
            var array = new ReponseDNS(new byte[] {
                0x32, 0x45, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x77, 0x77, 0x77,
                0x06, 0x67, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x01, 0x00, 0x01,

            });

            var id = array.GetId();
            var flags = array.GetFlags();
            var questions = array.GetQuestions();
            var answersRRs = array.GetAnswersCount();
            var authorityRRs = array.GetAuthorityRRs();
            var additionalRRs = array.GetAdditionalRRS();
            //Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestReponseQuerry()
        {
            var array = new ReponseQuery(new byte[] {
                0x03, 0x77, 0x77, 0x77, 0x06, 0x67, 0x6f, 0x6f, 0x67, 0x6c,
                0x65, 0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x01, 0x00, 0x01,

            });
            IEnumerable<byte> fmm = new byte[]
            {
                0x03, 0x77, 0x77, 0x77, 0x06, 0x67, 0x6f, 0x6f, 0x67, 0x6c,
                0x65, 0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x01, 0x00, 0x01,
            };

            var a = array.GetLabel(ref fmm);
            var b = array.GetName();
            var nameLength = array.GetNameLength();
            var lablesCount = array.GetLabelsCount();
            var querytype = array.GetQueryType();
            var queryClass = array.GetQueryClass();
            //Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAnswer()
        {
            var array = new ReponseAnswer(new byte[]
            {               
                0xc0, 0x0c, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x01, 0x0c, 0x00, 0x04, 0xac, 0xd9, 0x14, 0x04
            });

            var name = array.GetAnswerName();
            var querytype = array.GetQueryType();
            var queryClass = array.GetQueryClass();
            var timetolive = array.GetTimeToLive();
            var dataLength = array.GetDataLength();
            var ip = array.GetIp();
            //Assert.Equal(expected, actual);
        }
    }
}
