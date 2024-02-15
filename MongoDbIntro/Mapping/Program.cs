using Mapping;
using Mapping.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Entities;



DbService dbService = new();

//
// var cars = new List<Car>()
// {
//     new Car()
//     {
//         Make = "Ford",
//         Model = "Fusion",
//         ProductionDate = DateTime.UtcNow,
//         EngineType = new Engine()
//         {
//             Name = "EcoBoost",
//             Power = 200,
//             Volume = 2000
//         }
//     },
//     new Car()
//     {
//         Make = "Chevrolet",
//         Model = "Camaro",
//         ProductionDate = DateTime.UtcNow,
//         EngineType = new Engine()
//         {
//             Name = "V8",
//             Power = 455,
//             Volume = 6200
//         }
//     },
//     new Car()
//     {
//         Make = "Dodge",
//         Model = "Challenger",
//         ProductionDate = DateTime.UtcNow,
//         EngineType = new Engine()
//         {
//             Name = "V8",
//             Power = 375,
//             Volume = 5700
//         }
//     }
// };
//
//     

var engines = new List<Engine>()
{
    new Engine()
    {
        Name = "EcoBoost",
        Power = 200,
        Volume = 2000
    },
    new Engine()
    {
        Name = "V8",
        Power = 455,
        Volume = 6200
    },
    new Engine()
    {
        Name = "V8",
        Power = 375,
        Volume = 5700
    }
};


dbService.AddData(engines);




