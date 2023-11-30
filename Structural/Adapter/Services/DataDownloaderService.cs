using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Services;

static class DataDownloaderService
{
    static readonly WebClient client;
    static readonly string url;

    static DataDownloaderService()
    {
        client = new();
        url = $"https://www.cbar.az/currencies/{DateTime.Now.ToString("dd.MM.yyyy")}.xml";
    }

    public static string DownloadData()
    {
        return client.DownloadString(url);
    }
}
