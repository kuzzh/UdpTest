using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace UdpTestMulticastServer
{
    internal class MulticastServer
    {
        static void Main(string[] args)
        {
            var udpServer = new UdpClient(); 
            // 局部多播地址：在224.0.0.0～224.0.0.255之间，这是为路由协议和其他用途保留的地址，路由器并不转发属于此范围的IP包
            udpServer.JoinMulticastGroup(IPAddress.Parse("224.0.0.123")); // 加入组播
            var multicast = new IPEndPoint(IPAddress.Parse("224.0.0.123"), 7789); // 向 224.0.0.123:7789 发送组播消息
            var bytes = Encoding.UTF8.GetBytes("Hello World!");
            while (true)
            {
                udpServer.Send(bytes, bytes.Length, multicast);
                Console.WriteLine("已发送：{0} bytes", bytes.Length);
                Thread.Sleep(1000);
            }
        }
    }
}
