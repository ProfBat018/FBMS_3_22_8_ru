using System.Net;
using System.Net.Sockets;
using System.Text;

var ipAddr = IPAddress.Parse("172.20.29.36");
var ipEndPoint = new IPEndPoint(ipAddr, 11000);

Socket sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

try
{
    sListener.Bind(ipEndPoint); // связываю прослушку с конечной точкой
    // начинаю прослушку.
    // backlog - максимальное количество клиентов, которые могут подключиться к серверу

    sListener.Listen(10);
    Socket handler = sListener.Accept(); // принимаю входящее подключение

    while (true)
    {
        Console.WriteLine($"Waiting for a connection from port {ipAddr}");

        string? data = null;
        byte[] buffer = new byte[1024]; // буфер для получаемых данных

        handler.Receive(buffer); // Receive возвращает количество полученных байтов

        data = Encoding.UTF8.GetString(buffer, 0, buffer.Length); // конвертирую байты в строку

        Console.WriteLine($"Received data: {data}\nEnter your message to client: ");

        var response = Console.ReadLine();

        handler.Send(Encoding.UTF8.GetBytes($"Message from server: {response}"));
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    sListener.Shutdown(SocketShutdown.Both);
    sListener.Close();
}