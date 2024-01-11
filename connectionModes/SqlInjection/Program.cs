using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.AddJsonFile("appsettings.json");

var config = builder.Build();
using SqlConnection conn = new(config.GetConnectionString("Default"));

conn.Open();

Console.WriteLine("Enter name: ");
var name = Console.ReadLine();

Console.WriteLine("Enter surname: ");
var surname = Console.ReadLine();

Console.WriteLine("Enter age: ");
var age = Console.ReadLine();

var parameters = new[]
{
    new SqlParameter("@name", name),
    new SqlParameter("@surname", surname),
    new SqlParameter("@age", age)
};

var cmd = new SqlCommand("insert into People(Name, Surname, Age) values(@name,@surname,@age)", conn);

cmd.Parameters.AddRange(parameters);

Console.WriteLine(cmd.CommandText);

var res = cmd.ExecuteNonQuery();

// var cmd = new SqlCommand($"insert into People(Name, Surname, Age) values(N'{name}',N'{surname}',{age})", conn);
//
// Console.WriteLine(cmd.CommandText);
//
// var res = cmd.ExecuteNonQuery();
//
// // Elvin Azimov 22); drop database Academy_11 --



