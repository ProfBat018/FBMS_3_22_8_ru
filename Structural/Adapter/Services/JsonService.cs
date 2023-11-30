using Adapter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Adapter.Services;

static class JsonService
{
    public static T Deserialize<T>(string json) where T : IEntity
    {
        return JsonSerializer.Deserialize<T>(json);
    }
    public static string Serialize<T>(T entity) where T : IEntity
    {
        return JsonSerializer.Serialize(entity);
    }
}
