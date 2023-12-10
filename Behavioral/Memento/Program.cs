using Memento.Services;


WeatherService weatherService =
    new(new DownloadService("https://api.openweathermap.org/data/2.5/weather?q={cityname}&appid=2b1fd2d7f77ccf1b7de9b441571b39b8&units=metric"),
    new SnapshotService());


while (true)
{
    int selection = 0;

    Console.WriteLine("1. Get weather");
    Console.WriteLine("2. Get previous weather");

    selection = int.Parse(Console.ReadLine());
    switch (selection)
    {
        case 1:

            Console.WriteLine("Enter city name: ");
            string cityName = Console.ReadLine();
            weatherService.GetWeather(cityName);
            break;
        case 2:
            Console.WriteLine(weatherService.GetPreviousWeather().main.temp);
            break;
    }


}



