using System;
using System.Collections.Generic;
using Relationship.Services;

namespace Relationship;

public  class StudyPlan: IEntity
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int GroupId { get; set; }

    public  Group Group { get; set; }

    public  Teacher Teacher { get; set; }
}
