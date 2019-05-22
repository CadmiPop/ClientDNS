using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ClientDNS;

namespace ServerDNS
{
    public class DNS
    {
        private UdpClient _socket = new UdpClient(53);
        private byte[] message;
        private byte[] answerBytes;

        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 50);

        public DNS()
        {
            while (true)
            {
                message = Receive();
                var query = new DnsQuery(message).GetBytes();
                var hostname = new DnsQuery(query).GetName();
                byte[] responsePacket;

                Console.WriteLine(hostname);
                if (ItContains(hostname))
                    responsePacket = query.Concat(answerBytes).ToArray();
                else
                    responsePacket = SendRequestToAnotherServer();

                Send(responsePacket);
            }
        }

        private byte[] SendRequestToAnotherServer()
        {
            var endpoint = new IPEndPoint(IPAddress.Parse("8.8.8.8"), 53);
            _socket.Send(message, message.Length, endpoint);
            return _socket.Receive( ref endpoint);
        }

        private bool ItContains(string hostname)
        {
            var itContains = nameIp.FirstOrDefault(n => n.Key == hostname).Value;
            if (itContains != null)
            {
                byte[] answerHeader = new Answer().GetBytesHeader();
                answerBytes = answerHeader.Concat(itContains).ToArray();
                return true;
            }
            return false;
        }

        public void Send(byte[] message)
        {
            _socket.Send(message, message.Length, groupEP);
        }

        public byte[] Receive()
        {
            return _socket.Receive(ref groupEP);
        }

        private Dictionary<string, byte[]> nameIp = new Dictionary<string, byte[]>()
        {
            {"www.asdsadadas.com", new byte[]{ 192, 168, 16, 1 } },
            { "www.yahoo.com" , new byte[]{ 192,168,1,1 } },
            {"www.google.com", new byte[]{ 192, 168, 16, 1 } },
            {"www.bing.com" ,new byte[]{ 192,168,16,1 } },
            {"www.digg.com", new byte[]{ 50,18,45,6 } },
            {"www.theonion.com", new byte[]{151,101,2,166 } },
            {"www.hush.com", new byte[] {65,39,178,43 } },
        };

        private void WriteAnswer()
        {
            var b = new Reponse(answerBytes);
            b.Getip(b.answers);
        }
    }
}
