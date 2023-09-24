using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class TaxiPark
    {
        private event CarAction? ManagerEvent;
        public CarAction? CarManager { get; set; }
        public List<Car> Cars { get; set; }

        public TaxiPark()
        {
            Cars = new();
            ManagerEvent += CarManager;
        }
        public void AddCar(Car car)
        {
            ManagerEvent?.Invoke(car);
        }

        public void RemoveCar(Car car)
        {
            ManagerEvent?.Invoke(car);
        }
    }
}
