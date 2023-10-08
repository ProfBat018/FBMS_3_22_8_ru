using Lesson2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Services;

public class ShowroomManagerService
{
    public List<Car> Cars { get; set; } = new();

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }

    public void DeleteCar(Car car)
    {
        Cars.Remove(car);
    }

    public string BrowsePhoto()
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
