using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Model;
class SearchQuery
{
    public string CityName { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
