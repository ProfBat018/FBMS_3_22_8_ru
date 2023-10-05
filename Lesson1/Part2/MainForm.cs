using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part2
{
    public partial class MainForm : Form
    {
        private string? imagePath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Person personToAdd = new()
            {
                Name = nameTextBox.Text,
                Surname = surnameTextBox.Text,
                BirthDate = birthDatePicker.Value,
                ImagePath = imagePath ?? "user.png"
            };

            if (InputCheckers.checkAll(personToAdd))
            {
                peopleListBox.Items.Add(personToAdd);
                personPictureBox.Image = Image.FromFile(personToAdd.ImagePath);

                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                birthDatePicker.Value = DateTime.Now;
                imagePath = null;
            }
            else
            {
                MessageBox.Show("Invalid input");
                return;
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            peopleListBox.Items.Remove(peopleListBox.SelectedItem);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp) | *.jpg; *.jpeg; *.png; *.bmp";

            DialogResult res = fileDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                imagePath = fileDialog.FileName;
            }
        }

        private void peopleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person? person = peopleListBox.SelectedItem as Person;

            if (person != null)
            {
                nameTextBox.Text = person.Name;
                surnameTextBox.Text = person.Surname;
                birthDatePicker.Value = person.BirthDate;
                personPictureBox.Image = Image.FromFile(person.ImagePath);
            }
        }
    }
}
