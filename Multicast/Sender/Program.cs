using System.Net;
using System.Net.Sockets;
using System.Text;

// Socket - это класс для работы с сокетами. Это класс, который описывает тип подключения, тип сокета и тип протокола. 
// То есть чтобы настроить подключение нам нужно понять какой Socket 

// Зачем нужны сокеты?
// Сокеты - это класс, который хранит в себе информацию о сетевом соединении

// AddressFamily.InterNetwork - семейство адресов, которое используется для сокета
// InterNetwork - используется для IPv4

// SocketType.Dgram - тип сокета (датаграммный)
// ProtocolType.Udp - протокол, который используется для сокета

// Мультикаст протоколы начинаются с 224.0.0.0


Socket socket = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
IPAddress ip = IPAddress.Parse("224.5.6.7");

socket.SetSocketOption(SocketOptionLevel.IP,
    SocketOptionName.AddMembership, new MulticastOption(ip));

IPEndPoint endpoint = new(ip, 57195);

socket.Connect(endpoint);

while (true)
{
    Console.WriteLine("Enter message: ");
    byte[] data = Encoding.ASCII.GetBytes(Console.ReadLine());

    // SocketFlags.Multicast - флаг, который говорит, что мы отправляем мультикаст
    // нашему PDU - Packet Data Unit придается информация о том, что это мультикаст
    
    socket.Send(data, data.Length, SocketFlags.Multicast);
}
