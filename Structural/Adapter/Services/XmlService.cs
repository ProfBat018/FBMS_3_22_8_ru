using Adapter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Adapter.Services;

static class XmlService
{
    public static T Deserialize<T>(string xml) where T : IEntity
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(xml);
        
        
        return (T)serializer.Deserialize(reader);
    }

    public static string Serialize<T>(T entity) where T : IEntity
    {
        var serializer = new XmlSerializer(typeof(T));
        using var writer = new StringWriter();
        
        serializer.Serialize(writer, entity);
        return writer.ToString();
    }
}
