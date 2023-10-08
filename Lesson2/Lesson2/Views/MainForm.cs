using Lesson2.Model;
using Lesson2.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2.Views
{
    public partial class MainForm : Form
    {
        public MainFormPresenter Presenter { get; set; }
        public MainForm()
        {
            InitializeComponent();

            Presenter = new()
            {
                View = this
            };
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Car carToAdd = new()
            {
                Make = makeTextBox.Text,
                Model = modelTextBox.Text,
                ProductionDate = productionPicker.Value
            };

            Presenter.AddCar(carToAdd);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Presenter.DeleteCar(carsListBox.SelectedItem as Car);
        }

        public void UpdateView(IEnumerable<Car> cars)
        {
            carsListBox.Items.Clear();

            foreach (var car in cars)
            {
                carsListBox.Items.Add(car);
            }
        }

        public void ShowImage(string photo)
        {
            carPictureBox.Image = Image.FromFile(photo);
        }

        public void ResetForm()
        {
            makeTextBox.Text = "";
            modelTextBox.Text = "";
            productionPicker.Value = DateTime.Now;
            carPictureBox.Image = null;
        }

        private void carsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Car car = carsListBox.SelectedItem as Car;

            if (car != null)
            {
                makeTextBox.Text = car.Make;
                modelTextBox.Text = car.Model;
                productionPicker.Value = car.ProductionDate;
                carPictureBox.Image = Image.FromFile(car.ImagePhoto);
            }
        }
    }
}
