using System.Data;
using System.Data.SqlClient;
using System.Threading.Channels;
using Dapper;
using DapperIntro;

var connectionString = "Data Source=localhost;Initial Catalog=Academy;User Id=sa;Password=Elvin123;";

using IDbConnection conn = new SqlConnection(connectionString);

#region Part1
// var sql = "SELECT * FROM People";
//
// var people = conn.Query<Person>(sql);
//
// foreach (var person in people)
// {
//     Console.WriteLine($"{person.Id} {person.Name} {person.Surname} {person.Age}");
// }
#endregion

#region Part2

// var sql = "INSERT INTO People (Name, Surname, Age) VALUES (@Name, @Surname, @Age)";
//
// var person = new Person
// {
//     Name = "Rustam",
//     Surname = "Niftaliev",
//     Age = 26
// };
//
// int res = conn.Execute(sql, person);
//
// Console.WriteLine($"Rows affected: {res}");

#endregion

#region Part3

// var sql = "select AVG(Age) from People";
//
// var avgAge = conn.ExecuteScalar<int>(sql);
//
// Console.WriteLine($"Average age: {avgAge}");

#endregion

#region Part4

// var sql = "select * from People where Id = @Id and Name = @Name";
//
// var person = conn.QuerySingle<Person>(sql, new {Id = 1, Name="Elnur"});
// // var person = conn.QuerySingle(sql, new {Id = 1, Name="Elnur"});
//
// Console.WriteLine($"{person.Id} {person.Name} {person.Surname} {person.Age}");

#endregion

#region Part5

// var sql = "select * from Students s inner join People p on s.PersonId = p.Id";
//
// var students = conn.Query<Student, Person, Student>(sql, (student, person) =>
// {
//     student.Person = person;
//     return student;
// }, splitOn: "Id");
//
//
// foreach (var student in students)
// {
//     Console.WriteLine($"{student.Id} {student.Person.Name} {student.Person.Surname} {student.Person.Age} {student.GPA}");
// }

#endregion

#region Part6

// var sql = "select * from GroupData gd " +
//           "inner join Groups g on gd.GroupId = g.Id " +
//           "inner join Faculty f on g.FacultyId = f.Id";
//
//
// var groups = conn.Query<GroupDatum, Group, Faculty, GroupDatum>(sql, (gd, g, f) =>
// {
//         gd.Group = g;
//         gd.Group.Faculty = f;
//     return gd;
// }, splitOn: "Id,Id");
//
// foreach (var groupDatum in groups)
// {
//     Console.WriteLine($"{groupDatum.Id} {groupDatum.Group.Name} {groupDatum.Group.Faculty.Name}");
// }


#endregion
