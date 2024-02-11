using System;
using System.Collections.Generic;
using Relationship.Services;

namespace Relationship;

public  class Employee : IEntity
{
    public int Id { get; set; }

    public decimal Salary { get; set; }

    public int Experience { get; set; }

    public  ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
