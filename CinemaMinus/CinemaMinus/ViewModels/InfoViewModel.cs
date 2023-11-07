using CinemaMinus.Messages;
using CinemaMinus.Models;
using CinemaMinus.Services.Classes;
using CinemaMinus.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.ViewModels;

class InfoViewModel : ViewModelBase
{
    private readonly IMessenger _messenger;
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;


    public Result Movie { get; set; }

    public InfoViewModel(IMessenger messenger, INavigationService navigationService, IDataService dataService)
    {
        _messenger = messenger;

        _messenger.Register<DataMessage>(this, (message) =>
        {
            Movie = message.Data as Result;
        });
        _navigationService = navigationService;
        _dataService = dataService;
    }

    public ButtonCommand BackCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<SearchViewModel>();
        });
    }

    public ButtonCommand OrderCommand
    {
        get => new(() =>
        {
            _dataService.SendData(Movie);
            _navigationService.NavigateTo<OrderViewModel>();
        });
    }
}
