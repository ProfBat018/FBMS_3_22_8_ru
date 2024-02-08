using System;
using System.Collections.Generic;

namespace DapperIntro;

public partial class GroupDatum
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Student? Student { get; set; }
}
