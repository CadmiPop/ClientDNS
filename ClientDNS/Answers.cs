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

        public List<Answer> answers = new List<Answer>();

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
                answers.Add(new Answer(answer));
                receviedBytes = receviedBytes.Skip(answer.Count()).Take(receviedBytes.Count()).ToArray();
            }
        }        
    }
}
