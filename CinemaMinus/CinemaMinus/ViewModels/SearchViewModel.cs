using CinemaMinus.Models;
using CinemaMinus.Services.Classes;
using CinemaMinus.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaMinus.ViewModels;
class SearchViewModel : ViewModelBase
{

    private string searchQuery;
    
    private SearchModel searchResult = new();

    private readonly ICinemaManagerService _cinemaManagerService;
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;


    public Result SelectedMovie { get; set; }
    public SearchModel SearchResult
    {
        get => searchResult;
        set => Set(ref searchResult, value);
    }

    public string SearchQuery { get => searchQuery; set => Set(ref searchQuery, value); }

    public SearchViewModel(ICinemaManagerService cinemaManagerService, INavigationService navigationService, IDataService dataService)
    {
        _cinemaManagerService = cinemaManagerService;
        _navigationService = navigationService;
        _dataService = dataService;
    }

    public ButtonCommand SearchCommand
    {
        get => new(
    () =>
    {
        SearchResult = _cinemaManagerService.GetMovies(SearchQuery);
    },
    () =>
    {
        return !string.IsNullOrWhiteSpace(SearchQuery) && SearchQuery.Length > 3;
    });
    }

    public ButtonCommand MoreInfoCommand
    {
        get => new(
        () =>
        {
            _dataService.SendData(SelectedMovie);   
            _navigationService.NavigateTo<InfoViewModel>();
        });
    }
}
