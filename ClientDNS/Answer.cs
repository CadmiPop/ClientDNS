using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ClientDNS
{
    public class Answer
    {
        private readonly string name;
        private QueryType type;
        private QueryClass Class;
        private readonly string ip;

        private byte[] receviedBytes = new byte[] { };

        public Answer(string name, QueryType type = QueryType.QUERY, QueryClass Class = QueryClass.INTERNET)
        {
            this.name = name;
            this.type = type;
            this.Class = Class;
            this.ip = ip;
        }

    }
}
