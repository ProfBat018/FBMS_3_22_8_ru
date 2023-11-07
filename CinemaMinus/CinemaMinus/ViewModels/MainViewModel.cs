using CinemaMinus.Messages;
using CinemaMinus.Services.Classes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;

namespace CinemaMinus.ViewModels;


class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentView;

    private readonly IMessenger _messenger;
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value); // Функция Set() автоматически вызывает PropertyChanged.
        }
    }


    public MainViewModel(IMessenger messenger)
    {
        _messenger = messenger;
        CurrentView = App.Container.GetInstance<OrderViewModel>();

        _messenger.Register<NavigationMessage>(this, message =>
        {
            CurrentView = message.ViewModelType;
        });
    }

    public RelayCommand First { get => new(() =>
    {
        CurrentView = App.Container.GetInstance<InfoViewModel>();
    });}

    public RelayCommand Second { get => new(() =>
    {
        CurrentView = App.Container.GetInstance<SearchViewModel>();
    });}

    public RelayCommand Third { get => new(() =>
    {
        CurrentView = App.Container.GetInstance<OrderViewModel>();
    });}
}
