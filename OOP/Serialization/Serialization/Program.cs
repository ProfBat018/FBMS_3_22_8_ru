
using System.Text.Json;
using System.Threading.Channels;

#region Serialization

// Person p1 = new()
// {
//     Name = "Elvin",
//     Surname = "Azimov",
//     Age = 21
// };
//
// using FileStream fs = new("data.json", FileMode.OpenOrCreate);
// using StreamWriter sw = new(fs);
// string json = JsonSerializer.Serialize(p1);
//
// sw.Write(json);
//


#endregion

#region Deserialization

using FileStream fs = new("data.json", FileMode.Open);
using StreamReader sr = new(fs);

string json = sr.ReadToEnd();

Person p2 = JsonSerializer.Deserialize<Person>(json);

Console.WriteLine(p2);


#endregion


class Person
{
     public string Name { get; set; }
     public string Surname { get; set; }
     public int Age { get; set; }
     
     public override string ToString()
     {
         return $"Name: {Name}\nSurname: {Surname}\nAge: {Age}";
     }
}