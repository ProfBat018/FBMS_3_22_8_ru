using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.Services.Interfaces;

interface IDownloadService 
{
    public string DownloadData(string movieName, string page);
}
