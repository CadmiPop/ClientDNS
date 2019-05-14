using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientDNS
{
    public class Reponse
    {
        private byte[] answerBytes;
        private ReponseDNS head;
        private ReponseQuery query;
        public List<Answer> answers;
        

        public Reponse(byte[] Bytes)
        {
            this.answerBytes = Bytes;
            head = new ReponseDNS(answerBytes);
            query = new ReponseQuery(answerBytes.Skip(head.receviedBytes.Length).ToArray());           
            answers = new Answers(answerBytes.Skip(head.receviedBytes.Length + query.skiplength)).answers;           
        }

        public void Getip(List<Answer> answers)
        {
            var b = new string[]{};
            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine(answers[i].GetIp());
            }
        }
    }
}
