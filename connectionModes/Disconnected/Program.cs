using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.AddJsonFile("appsettings.json");

var config = builder.Build();
using SqlConnection conn = new(config.GetConnectionString("Default"));


conn.Open();

var ds = new DataSet();

SqlDataAdapter adapter2 = new("select * from People", conn);

adapter2.Fill(ds);

var cmd = new SqlCommand("update People set Name = N'Elnur' where Id = 1", conn);

adapter2.UpdateCommand = cmd;
adapter2.UpdateCommand.ExecuteNonQuery();

adapter2.Update(ds);
