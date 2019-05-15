using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerDNS
{
    public class DNS
    {
        private UdpClient _socket = new UdpClient(53);
        private byte[] message;
        private byte[] dMessage = new byte[] {5,5,6,6};
        
        private List<Tuple<string, string>> nameIp =  new List<Tuple<string, string>>(){};

        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 53);

        public DNS()
        {
            while (true)
            {
                message = Receive();
                Console.WriteLine(Encoding.ASCII.GetString(message));
                Send(message);
                Console.WriteLine("this message was sent" + Encoding.ASCII.GetString(message));
            }
        }

        public void Send(byte[] message)
        {
            _socket.Send(message, message.Length,groupEP);                      
        }

        public byte [] Receive()
        {
            return _socket.Receive(ref groupEP);
        }

        {"www.yahoo.com" ,"98.137.149.56" },
    {"www.hotmail.com", "65.55.72.135" },
{"www.bing.com", "65.55.175.254" },
{"www.digg.com","64.191.203.30"},
{"www.theonion.com", "97.107.137.164"},
{"www.hush.com", "65.39.178.43" },
{"www.gamespot.com","216.239.113.172" },
{"www.ign.com", "69.10.25.46" },
{"www.cracked.com", "98.124.248.77" },
{"www.sidereel.com", "144.198.29.112"},
{"www.github.com", "207.97.227.239" }
        
    }
}
