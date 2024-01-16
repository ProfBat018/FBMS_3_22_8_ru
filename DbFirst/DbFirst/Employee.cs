using System;
using System.Collections.Generic;

namespace DbFirst;

public class Employee
{
    public int Id { get; set; }

    public decimal Salary { get; set; }

    public int Experience { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
