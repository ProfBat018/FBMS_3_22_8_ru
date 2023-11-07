using CinemaMinus.Messages;
using CinemaMinus.Models;
using CinemaMinus.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.ViewModels;
class OrderViewModel : ViewModelBase
{
    public Result Movie{ get; set; }
    public CinemaHall Hall { get => hall; set => Set(ref hall, value); }

    private readonly IMessenger _messenger;
    private readonly INavigationService _navigationService;
    private CinemaHall hall;

    public OrderViewModel(IMessenger messenger, INavigationService navigationService)
    {
        _messenger = messenger;
        _navigationService = navigationService;

        _messenger.Register<DataMessage>(this, (message) =>
        {
            Movie = message.Data as Result;
        });

        Hall = new CinemaHall(5);


        //Hall.Seats = new();
        //for (int i = 0; i < Hall.Rows.Count; i++)
        //{
        //    for (int j = 0; j < Hall.Cols; j++)
        //    {
        //        Hall.Seats.Add(new Seat()
        //        {
        //            Number = j + 1,
        //        });
        //    }
        //}
    }



}
