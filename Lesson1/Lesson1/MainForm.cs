using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson1
{
    public partial class MainForm : Form
    {
        private static int counter = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void clickmeButton_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;

            MessageBox.Show(mouseEventArgs.Button.ToString());
            
            counter++;
            counterLabel.Text = counter.ToString();
        }
    }
}
