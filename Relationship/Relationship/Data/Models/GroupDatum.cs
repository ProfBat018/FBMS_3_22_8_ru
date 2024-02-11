using System;
using System.Collections.Generic;
using Relationship.Services;

namespace Relationship;

public class GroupDatum: IEntity
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int GroupId { get; set; }

    public  Group Group { get; set; }

    public Student Student { get; set; }
}
