using System.ComponentModel.DataAnnotations;

namespace Back;

public class Forecast
{
    public Forecast()
    {
        
    }
    public Forecast(string date, int temperatureC, string summary)
    {
        this.date = date;
        this.temperatureC = temperatureC;
        this.summary = summary;

    }

    [Key] public Guid id { get; set; } = Guid.NewGuid();
    public string date { get; set; }
    public int temperatureC { get; set; }
    public string summary { get; set; }

    
    
}