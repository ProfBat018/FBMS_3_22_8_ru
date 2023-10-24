using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MvvmFirst.Services
{
    public class ButtonCommand : ICommand
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
}
