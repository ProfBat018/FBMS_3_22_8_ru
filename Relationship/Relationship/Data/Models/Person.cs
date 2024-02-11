using System;
using System.Collections.Generic;
using Relationship.Services;

namespace Relationship;

public class Person : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; } 

    public int Age { get; set; }

    public  ICollection<Student> Students { get; set; } = new List<Student>();

    public  ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
