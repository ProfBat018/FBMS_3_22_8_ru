using System.Net;
using System.Net.Sockets;
using System.Text;

Socket socket = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
IPAddress ip = IPAddress.Any;

socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.Broadcast, true);

IPEndPoint endpoint = new(ip, 57195);

socket.Connect(endpoint);

while (true)
{
    byte[] bytes = new byte[1024];
    socket.Receive(bytes, SocketFlags.Broadcast);

    var result = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
    Console.WriteLine(result);
}



