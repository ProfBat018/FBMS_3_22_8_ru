using MongoDB.Bson;
using MongoDB.Driver;

var connectionString = "mongodb+srv://profbat018:Elvin123@dartwayner.vw6cbwo.mongodb.net/?retryWrites=true&w=majority";

var client = new MongoClient(connectionString);


var restaurants = client.GetDatabase("sample_restaurants").GetCollection<BsonDocument>("restaurants");
var neighborhoods = client.GetDatabase("sample_restaurants").GetCollection<BsonDocument>("neighborhoods");

// var res = restaurants.AsQueryable().Where(r => r["borough"] == "Bronx").Select(r => r["name"]).ToList();
// foreach (var r in res)
// {
//     Console.WriteLine(r);
// }

// var res = restaurants.AsQueryable().Where(r => r["cuisine"] == "Jewish/Kosher");

// foreach (var r in res)
// {
//     Console.WriteLine(r);
// }







