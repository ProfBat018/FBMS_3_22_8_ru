using System.Net;
using System.Net.Sockets;
using System.Text;

Socket socket = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
IPAddress ip = IPAddress.Parse("255.255.255.255");

socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.Broadcast, true);

IPEndPoint endpoint = new(ip, 57195);

socket.Connect(endpoint);

while (true)
{
    Console.WriteLine("Enter message: ");
    byte[] data = Encoding.ASCII.GetBytes(Console.ReadLine());

    socket.Send(data, data.Length, SocketFlags.Broadcast);
}