using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace DelegateButton;

public class MyCommand : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        MessageBox.Show("Hello World");
    }

    public event EventHandler? CanExecuteChanged; // не обращаем внимания
}

public class MyCommand2 : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        MessageBox.Show("Salam Dunya");
    }

    public event EventHandler? CanExecuteChanged; // не обращаем внимания
}

public class MainWindowViewModel : ViewModelBase
{
    public MyCommand ClickCommand
    {
        get => new();
    }

    public MyCommand2 SecondClickCommand
    {
        get => new();
    }
}