using System.Net.Sockets;
using System.Net;
using System.Text;


var sender = new UdpClient();

var receiverPort = 12001;
var address = IPAddress.Parse("224.0.0.1");

var receiver = new UdpClient(receiverPort);

try
{
    receiver.JoinMulticastGroup(address, 20);

    IPEndPoint receiverEP = null;

    while (true)
    {
        var result = receiver.Receive(ref receiverEP);
        var receivedData = Encoding.ASCII.GetString(result);
        Console.WriteLine(receivedData);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
finally
{
    receiver.Close();
}