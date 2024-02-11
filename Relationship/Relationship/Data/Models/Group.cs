using System;
using System.Collections.Generic;
using Relationship.Services;

namespace Relationship;

public class Group: IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Course { get; set; }

    public int FacultyId { get; set; }

    public  Faculty? Faculty { get; set; }

    public  ICollection<GroupDatum> GroupData { get; set; } = new List<GroupDatum>();

    public  ICollection<StudyPlan> StudyPlans { get; set; } = new List<StudyPlan>();
}
