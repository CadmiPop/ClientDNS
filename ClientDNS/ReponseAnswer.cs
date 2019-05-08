using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ClientDNS
{
    public class ReponseAnswer
    {
        //private readonly string name;
        //private QueryType type;
        //private QueryClass Class;
        //private int timeToLive;
        //private int dataLength;
        //private readonly string ip;

        private byte[] receviedBytes;

        public ReponseAnswer(byte [] receviedBytes)
        {
            this.receviedBytes = receviedBytes;
        }

        public byte[] GetAnswerName()
        {
            return receviedBytes.Take(2).ToArray();
        }

        public QueryType GetQueryType()
        {
            return (QueryType)BitConverter.ToInt16(receviedBytes.Skip(2).Take(2).Reverse().ToArray());
        }

        public QueryClass GetQueryClass()
        {
            return (QueryClass) BitConverter.ToInt16(receviedBytes.Skip(4).Take(2).Reverse().ToArray());
        }

        public int GetTimeToLive()
        {
            return BitConverter.ToInt32(receviedBytes.Skip(6).Take(4).Reverse().ToArray());
        }

        public int GetDataLength()
        {
            return BitConverter.ToInt16(receviedBytes.Skip(10).Take(2).Reverse().ToArray());
        }

        public string GetIp()
        {
            var array = receviedBytes.Skip(12).Take(4).ToArray();
            return String.Join(".", array.Select(p => p.ToString()).ToArray());            
        }
    }
}
