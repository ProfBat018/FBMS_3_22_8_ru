using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Services;

class DownloadService
{
    private readonly string _downloadPath;

    public DownloadService(string downloadPath)
    {
        _downloadPath = downloadPath;
    }

    public string Download(string cityname)
    {
        Console.WriteLine($"Downloading from {_downloadPath}");

        WebClient client = new();

        cityname = _downloadPath.Replace("{cityname}", cityname);

        return client.DownloadString(cityname) ?? throw new NullReferenceException("Error while downloading");
    }


}
