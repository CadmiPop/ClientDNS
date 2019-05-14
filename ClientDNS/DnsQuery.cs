﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ClientDNS
{
    public class DnsQuery
    {
        private string name;
        private byte[] array;
        private short id;
        private Flags flags;
        private short questions;
        private short answerRRs;
        private short authorityRRS;
        private short aditionalRRS;
        private Query query;

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
        }

        public byte[] GetBytes()
        {
            var array = new byte[] { };
            return array
                .Concat(ConvertToByte(id))
                .Concat(ConvertToByteU((ushort)flags))
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
    }
}
