using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClientDNS
{
    public class Query
    {
        private readonly string name;
        private QueryType type;
        private QueryClass Class;

        private byte[] nameByte= new byte[]{};

        public Query(string name, QueryType type = QueryType.QUERY, QueryClass Class = QueryClass.INTERNET)
        {
            this.name = name;
            this.type = type;
            this.Class = Class;
        }

        public byte[] GetBytes()
        {
            var labels = name.Split(".")
                .SelectMany(l => new[] { (byte)l.Length }.Concat(Encoding.Default.GetBytes(l)))
                .Concat(new byte[] { 0 });
            return labels
                .Concat(ConvertToByte((short)type))
                .Concat(ConvertToByte((short)Class))
                .ToArray();
        }

        private IEnumerable<byte> ConvertToByte(short value)
        {
            return BitConverter.GetBytes(value).Reverse();
        }
    }
}
