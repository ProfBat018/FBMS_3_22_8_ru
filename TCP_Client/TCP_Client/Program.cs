using System.Net.Sockets;
using System.Text;

// Client 
TcpClient client = new(); // TcpClient - класс для работы с сетью 

Console.Write("Enter your username: ");
var username = Console.ReadLine();

if (username != null)
{
    var buffer = Encoding.Unicode.GetBytes(username); // конвертирует строку в массив байтов

    await client.ConnectAsync("127.0.0.1", 43001); // подключение к серверу по порту 12001 и адресу 

    var clientStream = client.GetStream(); // получаем поток для чтения и записи
    
    await clientStream.WriteAsync(buffer, 0, buffer.Length); // записываем в поток данные 

    Console.WriteLine($"Client connected: {client.Connected}");

    StringBuilder sb = new();
    while (true)
    {
        if (clientStream.DataAvailable)
        {
            buffer = new byte[1024]; // создаем буфер для чтения данных 

            await clientStream.ReadAsync(buffer, 0, 1024); // читаем данные из потока
            var clientData = Encoding.Unicode.GetString(buffer);
            Console.WriteLine(clientData);
        }
    }
}