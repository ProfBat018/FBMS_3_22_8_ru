using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;

// Server
// 127.0.0.1 - localhost 

TcpListener listener = new(IPAddress.Parse("127.0.0.1"), 43001); // класс, который слушает подключения 

listener.Start(); // Start server 

while (true)
{
    var client = await listener.AcceptTcpClientAsync(); // Accept all clients 

    var clientStream = client.GetStream();


    var buffer = new byte[1024];

    await clientStream.ReadAsync(buffer, 0, 1024);

    var clientName = Encoding.Unicode.GetString(buffer, 0, 1024); // превращает из массива байтов в строук


    Console.WriteLine($"Client Name: {clientName}\t{client.Connected}");

    while (true)
    {
        Console.WriteLine("Enter message: ");
        string message = Console.ReadLine();
        string data = $"{clientName}\t{message}";
        var bytes = Encoding.Unicode.GetBytes(data);

        await clientStream.WriteAsync(bytes, 0, bytes.Length);
    }
}