using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PropertyChangedCommand.ViewModels;


class MainViewModel : BindableBase
{
    private string searchText = "Buenos dias";
    public string SearchText 
    { 
        get => searchText; 
        set
        {
            SetProperty(ref searchText, value);
        }
    }

    public MainViewModel()
    {
        SearchCommand = new DelegateCommand(
        () =>
        {
            MessageBox.Show("🤑🤑🤑");
        },
        () =>
        {
            if (!String.IsNullOrEmpty(SearchText))
            {
                if (SearchText.Length > 3)
                {
                    return true;
                }
            }
            return false;
        }).ObservesProperty(() => SearchText);
    }

    public DelegateCommand SearchCommand { get; private set; }
}
