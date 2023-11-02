using CinemaMinus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.Services.Interfaces;

interface ICinemaManagerService
{
    public SearchModel GetMovies(string movieName, string page = "1");
}
