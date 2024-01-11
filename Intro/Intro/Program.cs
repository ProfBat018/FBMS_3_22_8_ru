using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

// Это по сути тот самый паттерн Builder

var builder = new ConfigurationBuilder();
builder.AddJsonFile("appsettings.json");

var config = builder.Build();
using SqlConnection conn = new(config.GetConnectionString("Default"));

conn.Open();
var command = new SqlCommand("select * from People", conn);

if (true)
{
    using var res = command.ExecuteReader();

    while (res.Read())
    {
        // Console.WriteLine($"{res[0]}\t{res[1]}");
        Console.WriteLine(res.GetInt32(0));
    }
}

command = new SqlCommand("insert into People(Name, Surname, Age) values(N'Test', N'Test', 22)", conn);

var res2 = command.ExecuteNonQuery();

Console.WriteLine(res2);

