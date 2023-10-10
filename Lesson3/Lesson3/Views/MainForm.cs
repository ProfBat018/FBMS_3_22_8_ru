using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lesson3.Program;

namespace Lesson3.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            taskslistBox.DataSource = ToDos;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddView.ShowDialog();
        }

        private void taskslistBox_DoubleClick(object sender, EventArgs e)
        {
            EditView.EditItem(taskslistBox.SelectedIndex);
        }
    }
}
