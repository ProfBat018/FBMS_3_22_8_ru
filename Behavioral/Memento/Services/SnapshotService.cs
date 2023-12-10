using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memento.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Memento.Services;

class SnapshotService
{
    private Dictionary<string, Forecast>? _snapshots;

    public void AddSnapshot(string query, Forecast forecast)
    {
        using FileStream fs = new("snapshots.json", FileMode.OpenOrCreate);
        using StreamReader sr = new(fs);

        var json = sr.ReadToEnd();

        if (json.Length > 0)
            _snapshots = JsonSerializer.Deserialize<Dictionary<string, Forecast>>(json);
        else
            _snapshots = new();

        _snapshots.Add(query, forecast);

        fs.Close();

        using FileStream fs2 = new("snapshots.json", FileMode.Truncate);

        var JsonSerial = JsonSerializer.Serialize(_snapshots);

        using StreamWriter sw = new(fs2);

        sw.WriteLine(JsonSerial);

        Console.WriteLine("Snapshot saved");
    }

    public Forecast GetSnapshots()
    {
        using FileStream fs = new("snapshots.json", FileMode.OpenOrCreate);
        using StreamReader sr = new(fs);

        var json = sr.ReadToEnd();

        _snapshots = JsonSerializer.Deserialize<Dictionary<string, Forecast>>(json);

        Console.WriteLine("Snapshots loaded");

        Console.WriteLine("Enter id to load data...");

        int i = 0;
        foreach (var item in _snapshots)
        {
            i++;
            Console.WriteLine($"{i}. {item}");
        }

        int selection = int.Parse(Console.ReadLine());

        return _snapshots.ElementAt(selection - 1).Value;
    }
}
