using Lesson3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson3.Program;

namespace Lesson3.Presenters
{
    public class AddFormPresenter
    {
        public void AddTask(ToDoItem item)
        {
            item.ImagePath = BrowsePhoto();

            ToDos.Add(item);
            AddView.Close();
        }

        private string BrowsePhoto()
        {
            var fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp) | *.jpg; *.jpeg; *.png; *.bmp";

            DialogResult res = fileDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                return fileDialog.FileName;
            }
            else
            {
                return "poster.png";
            }
        }
    }
}
