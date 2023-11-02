using CinemaMinus.Messages;
using CinemaMinus.Models;
using CinemaMinus.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.Services.Classes;

class DataService : IDataService
{
    private readonly IMessenger _messenger;

    public DataService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendData<T>(T data) where T : IData
    {
        _messenger.Send(new DataMessage()
        {
            Data = data
        });
    }
}
