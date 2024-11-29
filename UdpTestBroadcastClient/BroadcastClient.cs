using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace UdpTestBroadcastClient
{
    internal class BroadcastClient
    {
        static void Main(string[] args)
        {
            var udpClient = new UdpClient(7788); // 接收广播消息的端口：7788
            var remoteEp = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 0); // 接收 255.255.255.255 发送的广播消息
            while (true)
            {
                var bytes = udpClient.Receive(ref remoteEp);
                var text = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(text);
            }
        }
    }
}
