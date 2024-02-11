using System;
using System.Collections.Generic;
using Relationship.Services;

namespace Relationship;

public  class Faculty: IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}
