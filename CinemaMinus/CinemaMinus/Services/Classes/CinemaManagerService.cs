using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.Services.Classes;

class CinemaManagerService
{
    private readonly JsonService _jsonService;
    private readonly DownloadService _downloadService;

    public CinemaManagerService(JsonService jsonService, DownloadService downloadService)
    {
        _jsonService = jsonService;
        _downloadService = downloadService;
    }
}
