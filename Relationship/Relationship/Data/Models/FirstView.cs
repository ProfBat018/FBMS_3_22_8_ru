using System;
using System.Collections.Generic;
using Relationship.Services;

namespace Relationship;

public class FirstView: IEntity
{
    public string Name { get; set; }

    public int? Gpa { get; set; }
}
