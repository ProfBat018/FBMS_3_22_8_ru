using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress ipAddr = IPAddress.Parse("172.20.29.36");
IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

Socket sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

// Connection to server

try
{
    sListener.Connect(ipEndPoint);

    while (true)
    {
        
        Console.Write("Enter message: ");
        string message = Console.ReadLine();

        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

        sListener.Send(messageBytes);

        byte[] bytes = new byte[1024];

        int bytesRec = sListener.Receive(bytes);

        Console.WriteLine("Server response: " + Encoding.UTF8.GetString(bytes, 0, bytesRec));
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

