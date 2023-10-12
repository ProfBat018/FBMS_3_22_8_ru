using Lesson3.Models;
using Lesson3.Presenters;
using Lesson3.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using static Lesson3.ToDoVpContext;

namespace Lesson3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // инициализация конфигурации. Берет все по умолчанию
            Application.Run(MainView); // Создает главное окно и запускает его
        }
    }
}