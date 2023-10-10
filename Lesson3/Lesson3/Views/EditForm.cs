using Lesson3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lesson3.Program;

namespace Lesson3.Views
{
    public partial class EditForm : Form
    {

        private ToDoItem itemToEdit;
        private int index;
        public EditForm()
        {
            InitializeComponent();
        }

        public void EditItem(int index)
        {
            nameTextBox.Text = ToDos[index].Name;
            duePicker.Value = ToDos[index].DueTime;
            checkBox1.Checked = ToDos[index].IsDone;
            taskPictureBox.Image = Image.FromFile(ToDos[index].ImagePath);

            ShowDialog();

            this.index = index;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            itemToEdit = new ToDoItem()
            {
                Name = nameTextBox.Text,
                DueTime = duePicker.Value,
                ImagePath = ToDos[index].ImagePath,
                IsDone = false
            };

            ToDos[index] = itemToEdit;

            EditView.Close();
        }
    }
}
