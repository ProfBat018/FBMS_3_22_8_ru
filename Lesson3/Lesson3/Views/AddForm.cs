using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lesson3.ToDoVpContext;

namespace Lesson3.Views
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddPresenter.AddTask(new()
            {
                Name = nameTextBox.Text,
                DueTime = duePicker.Value,
                IsDone = false
            });

        }
    }
}
