[中文](README.md) | English

# UDP Communication Test Project

A C# project demonstrating UDP network communication, focusing on two modes: Broadcast and Multicast. The project consists of four independent applications for testing UDP broadcast and multicast functionality.

## Project Structure

- `UdpTestBroadcastServer`: UDP Broadcast Server
- `UdpTestBroadcastClient`: UDP Broadcast Client
- `UdpTestMulticastServer`: UDP Multicast Server
- `UdpTestMulticastClient`: UDP Multicast Client

## Features

### Broadcast Mode
- Server broadcasts messages to address (255.255.255.255:7788)
- Client listens on port 7788 for broadcast messages
- Suitable for message broadcasting within local networks

### Multicast Mode
- Uses local multicast address (224.0.0.123:7789)
- Both server and clients need to join the same multicast group
- Only clients that join the multicast group can receive messages
- More efficient group communication method

## Technical Requirements

- .NET Framework 4.7.2
- Visual Studio 2019 or higher (recommended)

## Usage

### Testing Broadcast
1. Run UdpTestBroadcastServer.exe
2. Run one or more UdpTestBroadcastClient.exe
3. Observe the messages received by the clients

### Testing Multicast
1. Run UdpTestMulticastServer.exe
2. Run one or more UdpTestMulticastClient.exe
3. Observe the messages received by the clients

## Important Notes

1. Broadcast Mode
   - Broadcast messages are sent to all devices in the network
   - May be blocked by firewalls
   - Suitable for local network environments

2. Multicast Mode
   - Uses local multicast addresses (224.0.0.0～224.0.0.255)
   - These addresses are reserved for routing protocols and other purposes
   - Routers typically don't forward IP packets in this range
   - Better suited for multicast communication within local networks

## Code Examples

### Broadcast Server
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

### Multicast Server
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

## Contributions

Issues and improvements are welcome!

## License

MIT License
