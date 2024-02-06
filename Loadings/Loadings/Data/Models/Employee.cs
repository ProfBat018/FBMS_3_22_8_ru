using System;
using System.Collections.Generic;

namespace Loadings;

public partial class Employee
{
    public int Id { get; set; }

    public decimal Salary { get; set; }

    public int Experience { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
