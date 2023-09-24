using Events;



TaxiPark taxiPark = new();
void Add(Car car)
{
    taxiPark.Cars.Add(car);
}

void Remove(Car car)
{
    taxiPark.Cars.Remove(car);
}


taxiPark.CarManager += Add;

taxiPark.AddCar(new Car("BMW", "X5", DateTime.Parse("2023/1/1")));






