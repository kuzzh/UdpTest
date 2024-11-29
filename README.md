中文 | [English](README-en.md)

# UDP通信测试项目

这是一个用C#编写的UDP网络通信测试项目，主要演示了UDP通信中的广播（Broadcast）和多播（Multicast）两种模式。项目包含四个独立的应用程序，分别用于测试UDP广播和多播功能。

## 项目结构

- `UdpTestBroadcastServer`: UDP广播服务器
- `UdpTestBroadcastClient`: UDP广播客户端
- `UdpTestMulticastServer`: UDP多播服务器
- `UdpTestMulticastClient`: UDP多播客户端

## 功能特点

### 广播模式
- 服务器向广播地址（255.255.255.255:7788）发送消息
- 客户端监听7788端口接收广播消息
- 适用于局域网内的消息广播

### 多播模式
- 使用局部多播地址（224.0.0.123:7789）
- 服务器和客户端都需要加入相同的多播组
- 只有加入多播组的客户端才能接收消息
- 更高效的组播通信方式

## 技术要求

- .NET Framework 4.7.2
- Visual Studio 2019或更高版本（推荐）

## 使用方法

### 广播测试
1. 运行 UdpTestBroadcastServer.exe
2. 运行一个或多个 UdpTestBroadcastClient.exe
3. 观察客户端接收到的消息

### 多播测试
1. 运行 UdpTestMulticastServer.exe
2. 运行一个或多个 UdpTestMulticastClient.exe
3. 观察客户端接收到的消息

## 注意事项

1. 广播模式
   - 广播消息会发送给网络中的所有设备
   - 可能会被防火墙阻止
   - 适用于局域网环境

2. 多播模式
   - 使用了局部多播地址（224.0.0.0～224.0.0.255）
   - 这些地址是为路由协议和其他用途保留的
   - 路由器通常不会转发此范围的IP包
   - 更适合局域网内的组播通信

## 代码示例

### 广播服务器
```csharp
var udpServer = new UdpClient();
var endPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 7788);
var bytes = Encoding.UTF8.GetBytes("Hello World!");
while (true)
{
    udpServer.Send(bytes, bytes.Length, endPoint);
    Thread.Sleep(1000);
}
```

### 多播服务器
```csharp
var udpServer = new UdpClient();
udpServer.JoinMulticastGroup(IPAddress.Parse("224.0.0.123"));
var multicast = new IPEndPoint(IPAddress.Parse("224.0.0.123"), 7789);
var bytes = Encoding.UTF8.GetBytes("Hello World!");
while (true)
{
    udpServer.Send(bytes, bytes.Length, multicast);
    Thread.Sleep(1000);
}
```

## 贡献

欢迎提交问题和改进建议！

## 许可证

MIT License
