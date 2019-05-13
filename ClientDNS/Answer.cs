using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientDNS
{
    public class Answer
    {
        private byte[] answerBytes;
        private ReponseDNS head;
        private ReponseQuery query;
        private List<Answer> answers;
        

        public Answer(byte[] Bytes)
        {
            this.answerBytes = Bytes;
            head = new ReponseDNS(answerBytes);
            query = new ReponseQuery(answerBytes.Skip(head.receviedBytes.Length).ToArray());           
            answers = new Answers(answerBytes.Skip(head.receviedBytes.Length + query.skiplength)).answers;
            
        }

        //public IEnumerable<byte> GetAnswerName()
        //{
        //    return answer.Take(2).Reverse().ToArray();
        //}

        //public QueryType GetQueryType()
        //{
        //    return (QueryType)BitConverter.ToInt16(answer.Skip(2).Take(2).Reverse().ToArray());
        //}

        //public QueryClass GetQueryClass()
        //{
        //    return (QueryClass)BitConverter.ToInt16(answer.Skip(4).Take(2).Reverse().ToArray());
        //}

        //public int GetTimeToLive()
        //{
        //    return BitConverter.ToInt32(answer.Skip(6).Take(4).Reverse().ToArray());
        //}

        //public int GetDataLength()
        //{
        //    return BitConverter.ToInt16(answer.Skip(10).Take(2).Reverse().ToArray());
        //}

        //public string GetIp()
        //{
            
        //}
    }
}
