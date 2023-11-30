// Builder 



using Builder.Entities;
using Builder.Services.Classes;
using Builder.Services.Interfaces;

ICarBuilder builder = new CarBuilder();

Director director = new Director(builder);

Car car = director.BuildCarWithSportEngine();


car.Show();