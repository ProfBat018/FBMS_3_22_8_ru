using System.Data;
using System.Data.SqlClient;
using Dapper;
using Inheritance;

using IDbConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Showroom;User Id=sa; Password=Elvin123;");

conn.Open();


var sql = "select * from Transport";

using var reader = conn.ExecuteReader(sql);

var transportToCarParser = reader.GetRowParser<Car>();
var transportToBicycleParser = reader.GetRowParser<Bicycle>();

while (reader.Read())
{
    var discriminator = (TransportType)reader.GetInt32(reader.GetOrdinal("TrasnportType"));

    switch (discriminator)
    {
        case TransportType.Car:
            var car = transportToCarParser(reader);
            Console.WriteLine($"Car: {car.Make} {car.Model}");
            break;
        case TransportType.Bicycle:
            var bicycle = transportToBicycleParser(reader);
            Console.WriteLine($"Bicycle: {bicycle.Make} {bicycle.Model}");
            break;
    }
}








