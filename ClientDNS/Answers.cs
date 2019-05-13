using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ClientDNS
{
    public class Answers
    {

        public IEnumerable<byte> receviedBytes;

        public List<Reponse> answers = new List<Reponse>();

        public Answers(IEnumerable<byte> receviedBytes)
        {
            this.answers = answers;
            this.receviedBytes = receviedBytes;
            GetAnswers();
        }

        public void GetAnswers()
        {
            while (receviedBytes.Count() > 0)
            {
                var labelLength = BitConverter.ToInt16(receviedBytes.Skip(10).Take(2).Reverse().ToArray());
                var answer = receviedBytes.Take(12).Concat(receviedBytes.Skip(12).Take(labelLength)).ToArray();
                answers.Add(new Reponse(answer));
                receviedBytes = receviedBytes.Skip(answer.Count()).Take(receviedBytes.Count()).ToArray();
            }
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
