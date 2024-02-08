using System;
using System.Collections.Generic;

namespace DapperIntro;

public partial class Teacher
{
    public int Id { get; set; }

    public int? PersonId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Person? Person { get; set; }

    public virtual ICollection<StudyPlan> StudyPlans { get; set; } = new List<StudyPlan>();
}
