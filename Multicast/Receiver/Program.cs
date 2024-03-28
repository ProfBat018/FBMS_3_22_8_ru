using System.Net;
using System.Net.Sockets;
using System.Text;

Socket socket = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

IPEndPoint endpoint = new(IPAddress.Any, 57195);
socket.Bind(endpoint);

IPAddress ip = IPAddress.Parse("224.5.6.7");

socket.SetSocketOption(SocketOptionLevel.IP,
    SocketOptionName.AddMembership,
        new MulticastOption(ip, IPAddress.Any));

while (true)
{
    byte[] bytes = new byte[1024];
    socket.Receive(bytes, SocketFlags.Multicast);

    var result = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
    Console.WriteLine(result);
}