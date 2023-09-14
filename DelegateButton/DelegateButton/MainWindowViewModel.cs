using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using MyButtonCommand;

namespace DelegateButton;

public class MainWindowViewModel : ViewModelBase
{
    public MyCommand ClickCommand { get => new(() => MessageBox.Show("Hello World"));}
    public MyCommand SecondClickCommand { get => new(() => MessageBox.Show("Salam Dunya!"));}
}

