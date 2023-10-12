using Lesson3.Models;
using Lesson3.Presenters;
using Lesson3.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public static class ToDoVpContext
    {
        public static BindingList<ToDoItem> ToDos { get; set; } = new();
        public static MainForm MainView { get; set; } = new();
        public static AddForm AddView { get; set; } = new();
        public static EditForm EditView { get; set; } = new();

        public static MainFormPresenter MainPresenter { get; set; } = new();
        public static AddFormPresenter AddPresenter { get; set; } = new();
        public static EditFormPresenter EditPresenter { get; set; } = new();
    }
}
