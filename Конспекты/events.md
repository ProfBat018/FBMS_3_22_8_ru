# Объяснение событий 

```cs
   public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
```

События запускают нужный нам делегат. По факту код выше реагирует каждый раз когда 
меняется состояние команды. 

`add` - это ключевое слово, которое добавляет делегат в список делегатов.
`remove` - удаляет делегат из списка делегатов.

`RequerySuggested` - это событие, которое запускается каждый раз когда меняется состояние команды.

`value` - это делегат, который мы добавляем или удаляем из списка делегатов.

```cs

class ButtonCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    private Action _action;
    private Func<bool> _canExecute;

    public ButtonCommand(Action action, Func<bool> canExecute)
    {
        _action = action;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute();
    }
    public void Execute(object? parameter)
    {
        _action();
    }
}
```

