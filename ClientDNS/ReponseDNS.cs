using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientDNS
{
    public class ReponseDNS
    {
        public byte[] receviedBytes;
        private short id;
        private Flags flags;
        private short questions;
        private short answersRRs;
        private short authorityRRs;
        private short additionalRRs;


        public ReponseDNS(byte[] receviedBytes)
        {
            Array.Resize(ref receviedBytes, 12);
            this.receviedBytes = receviedBytes;
            id = GetId();
            flags = GetFlags();
            questions = GetQuestions();
            answersRRs = GetAnswersCount();
            authorityRRs = GetAuthorityRRs();
            additionalRRs = GetAdditionalRRS();
        }

        public short GetId()
        {
            return BitConverter.ToInt16(receviedBytes.Take(2).Reverse().ToArray());
        }

        public Flags GetFlags()
        {
            return (Flags)BitConverter.ToInt16(receviedBytes.Skip(2).Take(2).ToArray());
        }

        public short GetQuestions()
        {
            return BitConverter.ToInt16(receviedBytes.Skip(4).Take(2).ToArray());
        }

        public short GetAnswersCount()
        {
            return BitConverter.ToInt16(receviedBytes.Skip(6).Take(2).ToArray());
        }

        public short GetAuthorityRRs()
        {
            return BitConverter.ToInt16(receviedBytes.Skip(8).Take(2).ToArray());
        }

        public short GetAdditionalRRS()
        {
            return BitConverter.ToInt16(receviedBytes.Skip(10).Take(2).ToArray());
        }
    }
}
