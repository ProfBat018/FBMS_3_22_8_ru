using System.Net;

namespace SOLID.Services.Classes;

public class ApiService
{
    public string GetData(string link)
    {
        WebClient client = new();
        try
        {
            string? res = client.DownloadString(link);
            return res ?? throw new NullReferenceException("Json is null");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}