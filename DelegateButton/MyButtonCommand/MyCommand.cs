using System.Windows.Input;

namespace MyButtonCommand;


public class MyCommand : ICommand
{
    private Action _action;
    
    public MyCommand(Action action)
    {
        _action = action;    
    }
    
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _action();
    }

    public event EventHandler? CanExecuteChanged; // не обращаем внимания
}

