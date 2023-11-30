using Adapter.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Services;
internal class XmlToJsonAdapter
{
    public static string ConvertXmlToJson(string xml)
    {
        var valCurs = XmlService.Deserialize<ValCurs>(xml);
        return JsonConvert.SerializeObject(valCurs, Formatting.Indented);
    }
}
