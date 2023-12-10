using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memento.Model;

namespace Memento.Services;
class WeatherService
{
    private readonly DownloadService _downloadService;
    private readonly SnapshotService _snapshotService;

    public WeatherService(DownloadService downloadService, SnapshotService snapshotService)
    {
        _downloadService = downloadService;
        _snapshotService = snapshotService;
    }

    public Forecast GetWeather(string cityname)
    {

        string json = _downloadService.Download(cityname);
        var data = SerializationService.Deserialize<Forecast>(json);

        _snapshotService.AddSnapshot(cityname, data);

        return data;
    }

    public Forecast GetPreviousWeather()
    {
        return _snapshotService.GetSnapshots();
    }
}
