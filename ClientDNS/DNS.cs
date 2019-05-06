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
        private UdpClient _socket = new UdpClient();
        public string url = "www.google.com";
        public byte[] message;
        IPEndPoint point = new IPEndPoint(IPAddress.Parse("8.8.8.8"), 53);
        private Byte[] receiveBytes;

        public DNS(DnsQuery query)
        {
            message = query.GetBytes();
            Connect(point);
            Send(message);
            Receive();
        }

        public void Connect(IPEndPoint point)
        {
            _socket.Connect(point);
            Console.WriteLine("Connection established");
        }

        public void Receive()
        {
            byte[] array = _socket.Receive(ref point);
            Console.WriteLine(Encoding.ASCII.GetString(array));
        }

        private void Send(byte[] message)
        {
            _socket.Send(message, message.Length);
        }
    }
}
