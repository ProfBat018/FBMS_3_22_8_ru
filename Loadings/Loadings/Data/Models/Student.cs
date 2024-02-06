using System;
using System.Collections.Generic;

namespace Loadings;

public partial class Student
{
    public int Id { get; set; }

    public int? PersonId { get; set; }

    public int? Gpa { get; set; }

    public virtual ICollection<GroupDatum> GroupData { get; set; } = new List<GroupDatum>();

    public virtual Person? Person { get; set; }
}
