using CinemaMinus.Models;
using CinemaMinus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.Services.Classes;

class CinemaManagerService : ICinemaManagerService
{
    private IJsonService _jsonService;
    private IDownloadService _downloadService;

    public CinemaManagerService(IDownloadService downloadService, IJsonService jsonService)
    {
        _downloadService = downloadService;
        _jsonService = jsonService;
    }


    public SearchModel GetMovies(string movieName, string page="1")
    {
        try
        {
            var json = _downloadService.DownloadData(movieName, page);
            
            return _jsonService.Deserialize<SearchModel>(json) ?? throw new NullReferenceException();
        }
        catch
        {
            throw;
        }
    }
}
