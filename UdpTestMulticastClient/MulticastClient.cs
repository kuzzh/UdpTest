using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace UdpTestMulticastClient
{
    internal class MulticastClient
    {
        static void Main(string[] args)
        {
            var udpServer = new UdpClient(7789); // 接收组播消息的端口号
            // 局部多播地址：在224.0.0.0～224.0.0.255之间，这是为路由协议和其他用途保留的地址，路由器并不转发属于此范围的IP包
            udpServer.JoinMulticastGroup(IPAddress.Parse("224.0.0.123")); // 加入组播
            var remoteEp = new IPEndPoint(IPAddress.Parse("224.0.0.123"), 0); // 远端发送组播的地址，0表示任意可用端口
            while (true)
            {
                var bytes = udpServer.Receive(ref remoteEp);
                var text = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(text);
            }
        }
    }
}
