using CinemaMinus.Services.Classes;
using CinemaMinus.Services.Interfaces;
using CinemaMinus.ViewModels;
using CinemaMinus.Views;
using GalaSoft.MvvmLight.Messaging;
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
            Container.RegisterSingleton<IJsonService, JsonService>();
            Container.RegisterSingleton<IDownloadService, DownloadService>();
            Container.RegisterSingleton<ICinemaManagerService, CinemaManagerService>();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IDataService, DataService>();


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
