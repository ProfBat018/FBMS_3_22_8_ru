using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Channels;
using System.Xml.Serialization;
using Lesson7;

#region Inheritance
/*
Person p1 = new Student("Ivan", "Ivanov", "Group 1");

Console.WriteLine(p1.GetId());
Console.WriteLine(p1.Name);
Console.WriteLine(p1.Surname);

abstract class Person
{
    protected readonly string _id;
    protected string _name;
    protected string _surname;

    public virtual string Name
    {
        get => _name;
        set => _name = value;
    }

    public virtual string Surname
    {
        get => _surname;
        set => _surname = value;
    }

    public virtual string GetId() => _id;

    public Person(string name, string surname)
    {
        _id = Guid.NewGuid().ToString();
        _name = name;
        _surname = surname;
    }
}

class Student : Person
{
    private readonly string _group;
    
    public Student(string name, string surname, string group) : base(name, surname)
    {
        _group = group;
    }

    public override string Name
    {
        get => $"Student: {_name}";
        set => _name = value;
    }
    
    public override string Surname
    {
        get => $"Student: {_surname}";
        set => _surname = value;
    }

    public string GetGroup() => _group;
}
*/


#endregion

#region Serialization
#region CreateClassroom


Classroom classroom = new(4);

List<Student> students = new()
{
    new("Ivan", "Ivanov"),
    new("Petr", "Petrov"),
    new("Sidor", "Sidorov"),
    new("Ivan", "Ivanov"),
};

try
{
    classroom.AddStudents(students);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

#endregion

#region ProblemDefinition

// using FileStream fs = new("classroom.txt", FileMode.OpenOrCreate);
// using StreamWriter sw = new(fs);
// sw.WriteLine(classroom.ToString());

// using StreamReader sr = new(fs);

// string res = sr.ReadToEnd();

#endregion

#region BinarySerizalization
//
// BinaryFormatter formatter = new();
//
// using FileStream fs = new("classroom.bin", FileMode.OpenOrCreate);
//
// #pragma warning disable SYSLIB0011
// formatter.Serialize(fs, classroom);
// #pragma warning restore SYSLIB0011

#endregion

#region XMLSerialization

// XmlSerializer xmlSerializer = new(typeof(Classroom));
// using FileStream fs = new("classroom.xml", FileMode.OpenOrCreate);
//
// xmlSerializer.Serialize(fs, classroom);


#endregion

#region JsonSerialization

 // using FileStream fs = new("classroom.json", FileMode.OpenOrCreate);
 // using StreamWriter sw = new(fs);
 //
 // string json = JsonSerializer.Serialize(classroom);
 //
 // sw.WriteLine(json);


#endregion
#endregion

#region Deserialization

#region BinaryDeserialization 
/*
BinaryFormatter formatter = new();

using FileStream fs = new("classroom.bin", FileMode.OpenOrCreate);

// Pattern matching - это сопоставление с образцом,
// то есть мы сопоставляем объект, который мы получили из файла
// с типом Classroom, если это так, то мы присваиваем его переменной newClassroom
// и выводим на экран
#pragma warning disable SYSLIB0011

if (formatter.Deserialize(fs) is Classroom newClassroom)
{
    Console.WriteLine(newClassroom);
    newClassroom.IncreaseMaxStudentsCount(12);
}

#pragma warning restore SYSLIB0011
*/

#endregion

#region XMLDeserialization

// XmlSerializer xmlSerializer = new(typeof(Classroom));
//
// using FileStream fs = new("classroom.xml", FileMode.OpenOrCreate);
//
// if (xmlSerializer.Deserialize(fs) is Classroom newClassroom)
// {
//     Console.WriteLine(newClassroom);
// }


#endregion

#region JsonDeserialization
/*
using FileStream fs = new("classroom.json", FileMode.OpenOrCreate);
using StreamReader sr = new(fs);

string json = sr.ReadToEnd();

Classroom? newClassroom = JsonSerializer.Deserialize<Classroom>(json);

if (newClassroom != null)
{
    Console.WriteLine(newClassroom);
}

*/

#endregion

#endregion




