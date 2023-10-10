using Lesson3.Models;
using Lesson3.Presenters;
using Lesson3.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lesson3
{
    internal static class Program
    {

        public static BindingList<ToDoItem> ToDos { get; set; } = new();
        public static MainForm MainView { get; set; } = new();
        public static AddForm AddView { get; set; } = new();
        public static EditForm EditView { get; set; } = new();


        public static MainFormPresenter MainPresenter { get; set; } = new();
        public static AddFormPresenter AddPresenter { get; set; } = new();
        public static EditFormPresenter EditPresenter { get; set; } = new();


        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(MainView);
        }
    }
}