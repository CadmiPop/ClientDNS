using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClientDNS
{
    public class Answer
    {
        public byte[] receivedBytes;
        public byte[] ipAddress;

        public Answer(byte[] receivedBytes)
        {
            this.receivedBytes = receivedBytes;
        }

        public Answer(byte[] receivedBytes, byte[] ipAddress)
        {
            this.receivedBytes = receivedBytes;
            this.ipAddress = ipAddress;
        }

        public Answer()
        {

        }

        public byte[] GetBytesHeader()
        {
            return new byte[] { 192, 12, 0, 1, 0, 1, 0, 0, 1, 0, 0, 4 };
        }

        public IEnumerable<byte> GetAnswerName()
        {
            return receivedBytes.Take(2).Reverse().ToArray();
        }

        public QueryType GetQueryType()
        {
            return (QueryType)BitConverter.ToInt16(receivedBytes.Skip(2).Take(2).Reverse().ToArray());
        }

        public QueryClass GetQueryClass()
        {
            return (QueryClass)BitConverter.ToInt16(receivedBytes.Skip(4).Take(2).Reverse().ToArray());
        }

        public int GetTimeToLive()
        {
            return BitConverter.ToInt32(receivedBytes.Skip(6).Take(4).Reverse().ToArray());
        }

        public int GetDataLength()
        {
            return BitConverter.ToInt16(receivedBytes.Skip(10).Take(2).Reverse().ToArray());
        }

        public string GetIp()
        {
            if (GetQueryType() == QueryType.CNAME)
                return "CNAME";

            return receivedBytes.Skip(12)
                .Take(GetDataLength())
                .Select(s => s.ToString())
                .Aggregate((result, item) => result + '.' + item);
        }
    }
}
