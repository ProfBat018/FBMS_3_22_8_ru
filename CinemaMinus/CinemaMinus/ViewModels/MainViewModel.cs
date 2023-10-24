using CinemaMinus.Services.Classes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaMinus.ViewModels;

class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentView;
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value); // Функция Set() автоматически вызывает PropertyChanged.
        }
    }

    private readonly CinemaManagerService _cinemaManager;

    public MainViewModel(CinemaManagerService cinemaManager)
    {
        _cinemaManager = cinemaManager;
        
        CurrentView = App.Container.GetInstance<InfoViewModel>();
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
