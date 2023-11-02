using CinemaMinus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.Services.Interfaces;

interface IDataService
{
    public void SendData<T>(T data) where T: IData;
}
