using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.Services.Interfaces;

interface IJsonService
{
    public T Deserialize<T>(string json);
}
