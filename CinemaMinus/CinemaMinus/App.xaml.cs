using CinemaMinus.Services.Classes;
using CinemaMinus.ViewModels;
using CinemaMinus.Views;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaMinus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        public void Register()
        {
            Container.RegisterSingleton<JsonService>();
            Container.RegisterSingleton<DownloadService>();
            Container.RegisterSingleton<CinemaManagerService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<SearchViewModel>();
            Container.RegisterSingleton<OrderViewModel>();
            Container.RegisterSingleton<InfoViewModel>();


            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = new MainView();

            window.DataContext = Container.GetInstance<MainViewModel>();

            window.ShowDialog();
        }
    }
}
