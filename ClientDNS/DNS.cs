using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientDNS
{
    public class DNS
    {
        private UdpClient _socket = new UdpClient(53);
        private byte[] message;
        IPEndPoint point = new IPEndPoint(IPAddress.Parse("1.1.1.1"), 53);
        private Byte[] AnswersBytes;


        public DNS(DnsQuery query)
        {
            message = query.GetBytes();
            Connect(point);
            Send(message);
            AnswersBytes = Receive();
            WriteAnswer();
        }

        private void WriteAnswer()
        {
            var b = new Reponse(AnswersBytes);
            b.Getip(b.answers);
            Console.Read();
        }

        public void Connect(IPEndPoint point)
        {
            _socket.Connect(point);
        }

        public byte[] Receive()
        {
            return _socket.Receive(ref point);           
        }

        private void Send(byte[] message)
        {
            _socket.Send(message, message.Length);
        }


    }
}
