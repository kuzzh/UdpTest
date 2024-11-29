using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace UdpTestBroadcastServer
{
    internal class BroadcastServer
    {
        static void Main(string[] args)
        {
            var udpServer = new UdpClient();
            var endPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 7788); // 向 255.255.255.255:7788 发送广播消息
            var bytes = Encoding.UTF8.GetBytes("Hello World!");
            while (true)
            {
                udpServer.Send(bytes, bytes.Length, endPoint);
                Console.WriteLine("已发送：{0} bytes", bytes.Length);
                Thread.Sleep(1000);
            }
        }
    }
}
