using Lesson2.Model;
using Lesson2.Services;
using Lesson2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Presenters;
public class MainFormPresenter
{

    private ShowroomManagerService _managerService = new();
    public MainForm View { get; init; }

    public void AddCar(Car car)
    {
        string photo = _managerService.BrowsePhoto();
        car.ImagePhoto = photo;

        View.ShowImage(photo);

        _managerService.AddCar(car);

        View.UpdateView(_managerService.Cars);
    }

    public void DeleteCar(Car car)
    {
        _managerService.DeleteCar(car);

        View.UpdateView(_managerService.Cars);
        View.ResetForm();
    }
}
