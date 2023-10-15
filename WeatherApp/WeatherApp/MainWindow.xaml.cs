using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.Services;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DateTime GetDateByUnixSeconds(int seconds)
        {
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(seconds);
            return date;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.google.com",
                UseShellExecute = true
            });

            //try
            //{
            //    Forecast res = WeatherService.GetWeatherByCity(searchBox.Text);

            //    tempLbl.Content = $"{res.Main.Temp}°C";
            //    weatherImg.Source = new BitmapImage(new Uri($"http://openweathermap.org/img/w/{res.Weather[0].Icon}.png"));

            //    feelsLikeLbl.Content = $"Feels like {res.Main.FeelsLike}°C";
            //    pressureLbl.Content = $"Pressure: {res.Main.Pressure}";


            //    sunsetLbl.Content = GetDateByUnixSeconds(res.Sys.Sunset).AddSeconds(res.Timezone).ToString("HH:mm:ss");
            //    sunriseLbl.Content = GetDateByUnixSeconds(res.Sys.Sunrise).AddSeconds(res.Timezone).ToString("HH:mm:ss");

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
