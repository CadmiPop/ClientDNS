using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ClientDNS
{
    public class DnsQuery
    {
        public string name;
        private byte[] array;
        private short id;
        public Flags flags;
        private short questions;
        public short answerRRs;
        private short authorityRRS;
        private short aditionalRRS;
        private Query query;
        private ReponseQuery nameQuery;

        public DnsQuery(string name, short? id = null)
        {
            this.id = id ?? (short)new Random().Next(short.MaxValue);
            this.name = name;
            query = new Query(name);
            this.flags = Flags.RecursionDesired;
            questions = 1;
            answerRRs = 0;
            authorityRRS = 0;
            aditionalRRS = 0;
        }

        public DnsQuery(byte[] array)
        {
            this.array = array;
            this.id = GetId();
        //    this.flags =0x8180;
            questions = 1;
            answerRRs = 1 ;
            authorityRRS = 0;
            aditionalRRS = 0;
            this.name = GetName();
            this.query = new Query(name);
        }

        public string GetName()
        {
            IEnumerable<byte> a = array.Skip(12).TakeWhile(l => l != 0);
            string name = "";
            while (a.Count() > 1)
            {
                name = string.Concat(name, GetLabel(ref a)) + ".";
            }
            return name.TrimEnd('.');
        }

        public string GetLabel(ref IEnumerable<byte> name)
        {
            var result = name.Skip(1).Take(name.ElementAt(0));
            name = name.TakeLast(name.Count() - result.Count() - 1);
            return Encoding.ASCII.GetString(result.ToArray());
        }

        public byte[] GetBytes()
        {
            var array = new byte[] { };
            return array
                .Concat(ConvertToByte(id))
                .Concat(ConvertToByteU(0x8180))
                .Concat(ConvertToByte(questions))
                .Concat(ConvertToByte(answerRRs))
                .Concat(ConvertToByte(authorityRRS))
                .Concat(ConvertToByte(aditionalRRS))
                .Concat(query.GetBytes())
                .ToArray();
        }

        private byte[] ConvertToByte(short value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        private byte[] ConvertToByteU(ushort value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        public short GetId() => BitConverter.ToInt16(array.Take(2).Reverse().ToArray());

        public Flags GetFlags() => (Flags)BitConverter.ToUInt16(array.Skip(2).Take(2).Reverse().ToArray());

        public short GetQueryCount() => BitConverter.ToInt16(array.Skip(4).Take(2).Reverse().ToArray());

        public short GetAnswerCount() => BitConverter.ToInt16(array.Skip(6).Take(2).Reverse().ToArray());

        public short GetAuthorityRecords() => BitConverter.ToInt16(array.Skip(8).Take(2).Reverse().ToArray());

        public short GetAdditionalRecords() => BitConverter.ToInt16(array.Skip(10).Take(2).Reverse().ToArray());

    }

}
